using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using Phychips.Helper;
using Phychips.Driver;
using Phychips.Rcp;
using System.Diagnostics;

namespace Phychips.PR9200
{
    public partial class ucDownloader : UserControl
    {
        private const int BOOTLOADERVER_BASE = 0x5AA55A00;
        private const int REG_VER_ADDRESS = 0;
        private const int APP_END = 0xF000;
        private const int PACKET_SIZE = 16;
        private const int PACKET_EX_SIZE = 1024;
        private const uint BOOTLOADER_VER_LEGACY = 0xffffffff;
        private const uint DOWNLOAD_MODE_LEGACY = 0xffffffff;
        private const uint DOWNLOAD_MODE_NEW = 0x0A;

        private volatile bool m_bReceived = false;
        public bool source = false;        
        private uint m_readerBootloaderVer = 0;
        private uint m_nImageBootloaderVersion = 0;
        private uint m_nImageVersion = 0;
        private uint m_nDownloadMode = 0;        
        
        private bool m_bRcpReceived = false;
        public byte ReadMod;

        int m_nCmdCnt;
        int m_nAddMax;

        System.Timers.Timer RxCheckTimer = new System.Timers.Timer();

        public ucDownloader()
        {
            InitializeComponent();
        }

        private void FormDownloader_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;            

            this.textBoxReaderBootLoader.Text = "0x" + BOOTLOADER_VER_LEGACY.ToString("X02");

            if ((this.textBoxCodeList.Text != "") && (this.textBoxFilename.Text != ""))
                this.buttonUpdate.Enabled = true;
            else
                this.buttonUpdate.Enabled = false;

            GetInfo();

            RxCheckTimer.Interval = 1 * 100;
            RxCheckTimer.Elapsed += RxCheckTimer_Elapsed;
        }

        private Thread monThread = null;

        public void GetInfo()
        {
            this.textBoxBand.Text = "";
            this.textBoxInfoModel.Text = "";
            this.textBoxInfoFWVER.Text = "";
            this.textBoxInfoREGVER.Text = "";

            if (monThread == null || monThread.IsAlive == false)
            {
                monThread = new Thread(new ThreadStart(ThreadReadInfo));
                monThread.Start();
            }
        }

        private void ThreadReadInfo()
        {
            // Check the Download Mode
            byte[] param = new byte[1];

            param[0] = ReadMod = FromTaginitialize.RDR_MODEL;
            m_bRcpReceived = false;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RD_INF, param))) { return; }
            this.waitForRcpReceived();

            param[0] = ReadMod = FromTaginitialize.RDR_SN;
            m_bRcpReceived = false;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RD_INF, param))) { return; }
            this.waitForRcpReceived();

            System.Threading.Thread.Sleep(100);

            param[0] = ReadMod = FromTaginitialize.RDR_STATUS;
            m_bRcpReceived = false;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RD_INF, param))) { return; }
            this.waitForRcpReceived();

            m_bRcpReceived = false;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_GET_REGISTRY_ITEM, new byte[] { 0x00, REG_VER_ADDRESS }))) { return; }
            this.waitForRcpReceived();

            m_readerBootloaderVer = BOOTLOADER_VER_LEGACY;
            m_bRcpReceived = false;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_IAP_VER, null))) { return; }
            this.waitForRcpReceived();
        }                
        
        private bool SendDumpCmd(int data)
        {
            byte[] byte_data = new byte[2];

            //m_bStarted = false;

            byte_data[0] = (byte)((data >> 8) & 0xFF);
            byte_data[1] = (byte)(data & 0xFF);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_DUMP, byte_data)))
            {
                MessageBox.Show("Failure to send a packet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        int RxCheckCnt = 0;

        private void UpdateProcess()
        {
            bool bUpdateSuccess = false;
            int add = 0;
            int len = 0;

            if (m_nDownloadMode == DOWNLOAD_MODE_LEGACY)
            {
                len = PACKET_SIZE;
            }
            else
            {
                len = PACKET_EX_SIZE;
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                progressBarUpdate.Maximum = m_nAddMax / len;
            }));

            System.Threading.Thread.Sleep(100);


            try
            {
                while (add < m_nAddMax)
                {
                    byte[] byteSend;    // = BuildSendLine(add);
                    RxCheckCnt = 0;

                    if (m_nDownloadMode == DOWNLOAD_MODE_LEGACY)
                    {
                        byteSend = BuildSendLine(add);
                    }
                    else
                    {
                        byteSend = BuildSendLineEx(add);
                    }

                    m_bReceived = false;

                    if (!Sio.Instance.Send(byteSend))
                    {
                        throw new Exception("Failure to send a packet");
                    }

                    RxCheckTimer.Start();

                    while (!m_bReceived)
                    {
                        if (RxCheckCnt > 100)
                        {
                            throw new Exception("Time Out      ");
                        }                                                
                    }
                    
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        progressBarUpdate.PerformStep();
                    }));

                    //add = add + 0x10;
                    add = add + len;                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (add >= m_nAddMax)
            {
                ByteBuilder bb = new ByteBuilder();
                bb.Append(0xbb);
                bb.Append(0x59);
                for (int i = 0; i < 19; i++)
                {
                    bb.Append(0xff);
                }
                bb.Append(0x7e);
                bb.Append(0x00);
                bb.Append(0x00);

                bUpdateSuccess = true;
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                progressBarUpdate.Value = 0;
            }));

            if (bUpdateSuccess)
            {
                MessageBox.Show("Update complete... Please reset your hardware", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private byte[] BuildSendLineEx(int address)
        {
            ByteBuilder bb = new ByteBuilder();

            bb.Append((byte)RcpProtocol.PREAMBLE);
            bb.Append((byte)'X');
            bb.Append((byte)(address >> 8));
            bb.Append((byte)(address & 0x00FF));

            for (int i = 0; i < PACKET_EX_SIZE; i++)
            {
                bb.Append(rawCode[address + i]);
            }

            bb.Append((byte)RcpProtocol.ENDMARK);
            bb.Append(CRCCalculator.Cal_CRC16(bb.GetByteArray()));

            return bb.GetByteArray();
        }

        private Thread newThread;

        private bool SendStartCode()
        {
            m_bReceived = false;
            if (m_readerBootloaderVer == BOOTLOADER_VER_LEGACY)
            {
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_DOWNLOAD, null)))
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        MessageBox.Show("Failure to send a packet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }

                m_nDownloadMode = DOWNLOAD_MODE_LEGACY;
            }
            else if (m_nImageBootloaderVersion == 0x00)
            {
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_DOWNLOAD, null)))
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        MessageBox.Show("Failure to send a packet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }

                m_nDownloadMode = DOWNLOAD_MODE_LEGACY;
            }
            else
            {
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_DOWNLOAD, new byte[] { 0x0a, 0x10 })))
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        MessageBox.Show("Failure to send a packet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }

                m_nDownloadMode = DOWNLOAD_MODE_NEW;
            }

            int count = 0;
            while (!m_bReceived)
            {
                if (count > 10) return false;

                count++;
                System.Threading.Thread.Sleep(100);
            }
            return true;
        }

        public bool DowngradeRegistry = false;
        public bool UpgragedRegistry = false;       

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {                
                /*
                if(!RcpProtocol.Instance.Open())                 
                {
                    MessageBox.Show("Failure to open port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (textBoxFilename.Text == "")
            {
                MessageBox.Show("No file to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((newThread == null) || (newThread.IsAlive == false))
            {
                newThread = new Thread(new ThreadStart(DumpAndUpdate));
                newThread.Start();
            }
            else
            {
                MessageBox.Show("Previous command is working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFileNew_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rawCode.Length; i++) rawCode[i] = 0xff;

            textBoxCodeList.Clear();
        }

        private const int MAX_CODE_LENGTH = 0x10000;
        private byte[] rawCode = new byte[MAX_CODE_LENGTH];

        private void UpdateDspCode(int START_ADDR, int END_ADDR)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = START_ADDR; i < END_ADDR; i++)
            {
                if ((i % 0x10) == 0 && (i != 0)) sb.AppendLine();

                if ((i % 0x10) == 0)
                {
                    sb.Append(string.Format("{0:X04}   ", i));
                }

                sb.Append(string.Format("{0:X02} ", rawCode[i]));
            }

            if (rawCode[0xC00 - 3] == ((BOOTLOADERVER_BASE >> 8) & 0xff)
                    && rawCode[0xC00 - 2] == ((BOOTLOADERVER_BASE >> 16) & 0xff)
                    && rawCode[0xC00 - 1] == ((BOOTLOADERVER_BASE >> 24) & 0xff))
            {
                groupBoxImageInfo.Show();
                textImageBoxBootloader.Text = "0x" + rawCode[0xC00 - 4].ToString("X02");
                m_nImageBootloaderVersion = rawCode[0xC00 - 4];
                m_nImageVersion = (uint)(rawCode[0x1703] << 24 | rawCode[0x1702] << 16 | rawCode[0x1701] << 8 | rawCode[0x1700]);
                textBoxImageFid.Text = m_nImageVersion.ToString("X08");
            }
            else
            {
                m_nImageBootloaderVersion = 0;
                m_nImageVersion = 0;
                textBoxImageFid.Text = "Legacy";
                textImageBoxBootloader.Text = "Legacy";
            }

            textBoxCodeList.AppendText(sb.ToString());
            textBoxCodeList.Select(0, 0);
            textBoxCodeList.ScrollToCaret();
        }

        public void DumpRegistry()
        {
            StringBuilder sb = new StringBuilder();

            byte[] get_dump = new byte[16];
            byte[] temp = new byte[44];

            int dump_add = 0xFC00;
            int dump_end = 0xFFF0;

            if (dump_end < dump_add)
                return;            

            try
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    textBoxCodeList.AppendText("\r\n");
                }));

                while (dump_add <= dump_end)
                {
                    byte[] byteSend = BuildSendLine(dump_add);

                    if (!SendDumpCmd(dump_add))
                    {
                        progressBarUpdate.Value = 0;

                        return;
                    }

                    //Address
                    sb.Append(string.Format("{0:X04}   ", dump_add));

                    // dump data

                    while (RcpProtocol.Instance.GetDump() == null)
                    {
                        //System.Threading.Thread.Sleep(10);
                    }

                    get_dump = RcpProtocol.Instance.GetDump();

                    for (int i = 0; i < get_dump.Length; i++)
                    {
                        // raw
                        for (int j = 0; j < get_dump.Length; j++)
                        {
                            rawCode[dump_add + j] = get_dump[j];
                        }

                        sb.Append(string.Format("{0:X02} ", get_dump[i]));
                    }

                    sb.Append("\r\n");

                    this.Invoke(new MethodInvoker(delegate()
                    {
                        textBoxCodeList.AppendText(sb.ToString());
                    }));

                    sb.Remove(0, sb.Length);

                    dump_add = dump_add + 0x10;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private const int CODE_LENGTH_WITHOUT_REGISTRY = 0xFC00;

        private void buttonFileOpen_Click(object sender, EventArgs e)
        {
            openFileDialogHex.ShowDialog();
        }

        private void openFileDialogHex_FileOk(object sender, CancelEventArgs e)
        {
            textBoxFilename.Text = openFileDialogHex.FileName;            

            string temp = Path.GetExtension(textBoxFilename.Text);

            temp = temp.ToLower();

            if(temp == ".hex")
            {
                for (int i = 0; i < rawCode.Length; i++) rawCode[i] = 0xff;

                parseHexFile(openFileDialogHex.FileName);

                textBoxCodeList.Clear();
                UpdateDspCode(0x0000, CODE_LENGTH_WITHOUT_REGISTRY);

                buttonUpdate.Enabled = true;
            }
        }
                
        private int nAddMax= 0;

        private void parseHexFile(string filename)
        {
            m_nCmdCnt = 0;
            m_nAddMax = 0;

            using (StreamReader sr = new StreamReader((string)filename))
            {
                string Line;

                try
                {
                    while ((Line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine("Command Line = {0}", nCmdCnt++);
                        m_nCmdCnt++;
                        ParseLine(Line.ToUpper());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("HEX file error in Line " + m_nCmdCnt.ToString() + " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //rawCode[0] = 0x02;
            //rawCode[1] = 0x73;
            //rawCode[2] = 0x00;
        }

        private void ParseLine(string p)
        {
            int length = 0;
            int address = 0;
            int record_type = 0;
            Int16 crc = 0;
            byte[] lineData = new byte[0x20];

            if (p[0] != ':') throw new Exception("Record Mark (:) Error");
            p = p.Remove(0, 1);

            for (int i = 0; i < (p.Length / 2); i++)
            {
                lineData[i] = (byte)((Convert.ToByte(p[i * 2].ToString(), 16) << 4) + Convert.ToByte(p[i * 2 + 1].ToString(), 16));
                crc += lineData[i];
            }

            if ((crc & 0x00ff) != 0x00) throw new Exception("CRC Error");

            length = lineData[0];
            address = (lineData[1] << 8) + lineData[2];
            record_type = lineData[3];
            if (record_type != 0x00) return;

            if (address > (MAX_CODE_LENGTH - 1)) return;

            for (int i = 0; i < length; i++)
            {
                rawCode[address + i] = lineData[4 + i];
            }

            if (m_nAddMax < (address + length)) m_nAddMax = address + length;

            //if (m_nAddMax > APP_END) m_nAddMax = APP_END;
            //System.Console.WriteLine("nAddMax = {0:X04}", nAddMax);
        }

        private byte[] BuildSendLine(int address)
        {
            ByteBuilder bb = new ByteBuilder();

            bb.Append((byte)RcpProtocol.PREAMBLE);
            bb.Append((byte)'W');
            bb.Append((byte)(address >> 8));
            bb.Append((byte)(address & 0x00FF));

            for (int i = 0; i < 0x10; i++)
            {
                bb.Append(rawCode[address + i]);
            }

            bb.Append((byte)RcpProtocol.ENDMARK);
            bb.Append(CRCCalculator.Cal_CRC16(bb.GetByteArray()));

            return bb.GetByteArray();
        }

        public bool ModeISP = false;

        internal void ParseRsp(byte[] Data)
        {
            switch (Data[2])
            {
                case RcpProtocol.RCP_CMD_NACK:                    
                    break;
                case RcpProtocol.RCP_CMD_SET_DOWNLOAD:
                    if (Data[5] == 0x00) m_bReceived = true;
                    break;
                case RcpProtocol.RCP_CMD_GET_RD_INF:
                    {
                        int len = (Data[3] << 8) + Data[4];

                        char[] chars = new char[len];
                        System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                        try { d.GetChars(Data, 5, len, chars, 0); }
                        catch { }

                        if (ReadMod == FromTaginitialize.RDR_MODEL)
                        {
                            this.textBoxInfoModel.Text = new System.String(chars);
                        }

                        if (ReadMod == FromTaginitialize.RDR_SN)
                        {
                            this.textBoxInfoFWVER.Text = new System.String(chars);
                        }

                        if (ReadMod == FromTaginitialize.RDR_STATUS)
                        {
                            switch (Data[6])
                            {
                                case 0x01:
                                case 0x11:
                                    this.textBoxBand.Text = "KR";
                                    break;
                                case 0x02:
                                case 0x21:
                                case 0x22:
                                    this.textBoxBand.Text = "US";
                                    break;
                                case 0x04:
                                case 0x31:
                                    this.textBoxBand.Text = "EU";
                                    break;
                                case 0x08:
                                case 0x41:
                                    this.textBoxBand.Text = "JP";
                                    break;
                                case 0x52:
                                    this.textBoxBand.Text = "CN";
                                    break;
                                case 0x71:
                                    this.textBoxBand.Text = "AH";
                                    break;
                            }
                        }

                        if (ReadMod == FromTaginitialize.RDR_MANFACT)
                        {
                            break;
                        }

                    }
                    break;
                case RcpProtocol.RCP_GET_REGISTRY_ITEM:
                    {
                        int RegVer = (Data[8] << 8) | Data[7];
                        textBoxInfoREGVER.Text = RegVer.ToString("X03");
                    }
                    break;
                case RcpProtocol.RCP_CMD_GET_IAP_VER:
                    {
                        m_readerBootloaderVer = Data[5];
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            this.textBoxReaderBootLoader.Text = "0x" + m_readerBootloaderVer.ToString("X02");
                        }));
                        System.Console.WriteLine("m_readerBootloaderVer = " + m_readerBootloaderVer);
                    }
                    break;
                case RcpProtocol.RCP_CMD_SET_DUMP:
                    break;
            }
            m_bRcpReceived = true;


        }
        
        private void BootloaderDownload()
        {
            bool bUpdateSuccess = false;
            int add = 0;

            System.Threading.Thread.Sleep(3000);

            try
            {
                while (add < nAddMax)
                {
                    byte[] byteSend = BuildSendLine(add);
                    
                    m_bReceived = false;

                    if (!Sio.Instance.Send(byteSend))
                    {
                        throw new Exception("Failure to send a packet");
                    }

                    int count = 0;

                    while (!m_bReceived)
                    {
                        if (count > 100)
                        {
                            throw new Exception("Time Out      ");
                        }

                        count++;
                        System.Threading.Thread.Sleep(20);
                    }

                    this.Invoke(new MethodInvoker(delegate()
                    {
                        progressBarUpdate.PerformStep();
                    }));

                    add = add + 0x10;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (add >= nAddMax) bUpdateSuccess = true;

            this.Invoke(new MethodInvoker(delegate()
            {
                progressBarUpdate.Value = 0;
            }));

            try
            {
                RcpProtocol.Instance.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bUpdateSuccess)
            {
                MessageBox.Show("Update complete... Please reset your hardware", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDump_Click(object sender, EventArgs e)
        {
            /*
            if ((newThread == null) || (newThread.IsAlive == false))
            {
                newThread = new Thread(new ThreadStart(DumpProcess));
                newThread.Start();
            }
            else
            {
                MessageBox.Show("Previous command is working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBoxCodeList.Text = "";
        }

        private void waitForRcpReceived()
        {
            for (int i = 0; i < 500; i++)
            {
                if (m_bRcpReceived)
                    break;
                System.Threading.Thread.Sleep(20);
            }
        }

        private void DumpAndUpdate()
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                buttonUpdate.Enabled = false;
            }));

            this.Invoke(new MethodInvoker(delegate()
            {
                // Progress Bar Settins
                progressBarUpdate.Minimum = 0;
                progressBarUpdate.Maximum = m_nCmdCnt;
                progressBarUpdate.Value = 1;
                progressBarUpdate.Step = 1;
            }));

            if (!SendStartCode())
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    //buttonUpdate.Enabled = true;
                    progressBarUpdate.Value = 0;
                }));

                return;
            }

            //System.Threading.Thread.Sleep(100);

            DumpRegistry();

            UpdateProcess();
        }

        void RxCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RxCheckCnt++;
            RxCheckTimer.Stop();
        }
    }
}
