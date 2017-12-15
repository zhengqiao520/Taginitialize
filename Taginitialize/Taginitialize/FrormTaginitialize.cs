//! Copyright (C) 2007 Phychips
//! 
//! PR9200 DEMO
//!
//! Description
//! 	PR9200 DEMO
//!-------------------------------------------------------------------
//! History
//!-------------------------------------------------------------------
//! 1.0	2007/09/01	Jinsung Yi		Initial Release


using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Media;
using System.Timers;
using Phychips.Rcp;
using Phychips.PR9200;
using Phychips.Driver;
using Phychips.Helper;
using System.Data.SqlClient;
namespace Phychips.PR9200
{
    public partial class FrormTaginitialize : Form
    {
        public const byte RDR_MODEL = 0x00;
        public const byte RDR_SN = 0x01;
        public const byte RDR_MANFACT = 0x02;

        public const byte RDR_STATUS = 0xB0;

        private StringBuilder msgSb = new StringBuilder();
        private Thread monThread = null;
        private Thread SyncThread = null;

        public static Phychips.PR9200.FormDownload fd = new FormDownload();
        FormTxLeakagePlot TxLeakageRSSIPlot = new FormTxLeakagePlot();
        FormSensorTag _fST = new FormSensorTag();

        private byte ReadMod = RDR_MODEL;
        private bool InfoReq = false;
        private bool bDisposed = false;

        public bool source = false;
        public bool skipProcess = false;
        public static string SelectedScript = null;

        private bool m_bUpdateLog = false;
        private bool m_bAlive = false;

        private static string CPUID = null;
        private bool leakTable = false;
        

        #region Constructor, Load and Close Event

        public FrormTaginitialize()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void FormSDK_Load(object sender, EventArgs e)
        {
            Text = $"当前数据库标签数量:{TagCount.ToString()}条。";
            CPUID = CpuId;
            if (this.DesignMode)
                return;

            //System.Reflection.Assembly a = typeof(FormSDK).Assembly;
            //String version = a.GetName().Version.Major.ToString() + "." + a.GetName().Version.Minor.ToString() + "." + a.GetName().Version.Build.ToString();
            //this.Text = "RED Utility_v" + version;

            //this.listViewMsg.ContextMenuStrip = contextMenuStrip1;

            tsStatusPortOpen.Text = RcpProtocol.Instance.strConnectionStatus();
            tsStatusPort.Text = RcpProtocol.Instance.mSioConfigPort();
            tsStatusBr.Text = RcpProtocol.Instance.mSioConfigBaud();

            //this.ucHwControl1.InvisibleAdvanced();
            //this.tabControl2.Refresh();

            listViewEPC.ContextMenuStrip = contextMenuStripTagInfo;
            //listViewTagMemory.ContextMenuStrip = contextMenuStripMoreInfo;
            richTextBoxRCPDecoder.ContextMenuStrip = contextMenuStriprichTextBox;

            this.cbTagRwTarMem.SelectedIndex = 0;

            RcpProtocol.Instance.RcpLogEventReceived += RcpLogEventReceived;
            RcpProtocol.Instance.RxRspParsed += RxRspEventReceived;

            RcpProtocol.Instance.EventPortOpened += DspOpenMsg;
            RcpProtocol.Instance.EventPortClosed += DspCloseMsg;

            //ScriptToRCP _singletone_ScriptToRCP = ScriptToRCP.Instance();

            //userControlLeakGuidance.SendEvent += new UserControlLeakGuidance.SendDataHandler(userControlLeakGuidance_SendEvent);
            //userControlLeakGuidance.SendEventbutton += new UserControlLeakGuidance.SendDataButtonHandler(userControlLeakGuidance_SendEventbutton);

            //this.comboBoxSendUID.SelectedIndex = 0;
            //this.comboBoxNewSample.SelectedIndex = 0;
            //this.comboBoxSPISCLK.SelectedIndex = 0;
            //this.comboBoxSPIDelayTimeToInitialSCLK.SelectedIndex = 0;
            //this.comboBoxSPIDelayTimeBetweenBytes.SelectedIndex = 0;

            PortOpenProcess();
        }

        private void FormSDK_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                lvEPCupdateThread.Abort();
                m_bAlive = false;
                RcpProtocol.Instance.Close();
                RcpProtocol.Instance.Dispose();
            }
            catch
            {
            }
            closeToolStripMenuItem_Click(sender, e);
        }

        #endregion

        private void CheckPartNumber()
        {
            string FirmwareVersion = tsFWVersion.Text.Trim();
            string PartNumber = tsPartNumber.Text.Trim();

            if (FirmwareVersion.StartsWith("RED4") && PartNumber.StartsWith("PRM92"))
            {
                ByteBuilder bb = new ByteBuilder();

                switch (PartNumber.Substring(5, 1))
                {
                    case "K":
                        bb.Append(new byte[] { 0x4b, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "C":
                        bb.Append(new byte[] { 0x43, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "U":
                        bb.Append(new byte[] { 0x55, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "J":
                        bb.Append(new byte[] { 0x4a, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "E":
                        bb.Append(new byte[] { 0x45, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "A":
                        bb.Append(new byte[] { 0x41, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                }
            }
            else if (FirmwareVersion.StartsWith("RED5") && PartNumber.StartsWith("PRM92"))
            {
                ByteBuilder bb = new ByteBuilder();

                switch (PartNumber.Substring(5, 1))
                {
                    case "K":
                        bb.Append(new byte[] { 0x4b, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "C":
                        bb.Append(new byte[] { 0x43, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "U":
                        bb.Append(new byte[] { 0x55, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "J":
                        bb.Append(new byte[] { 0x4a, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "E":
                        bb.Append(new byte[] { 0x45, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                    case "A":
                        bb.Append(new byte[] { 0x41, 0x2d, 0x44, 0x4b, 0x2d, 0x30, 0x30, 0x30, 0x20, 0x20 });
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_PART_NUMBER, bb.GetByteArray()))) { }
                        break;
                }
            }
        }

        public void DspCloseMsg(object sender, EventArgs e)
        {
            DisplayMsgString("MSG>Removed a USB to UART bridge ..\r\n");
            m_bAlive = false;

            closeToolStripMenuItem_Click(null, null);
        }

        public void DspOpenMsg(object sender, EventArgs e)
        {
            tsStatusPortOpen.Text = RcpProtocol.Instance.strConnectionStatus();
            tsStatusPort.Text = RcpProtocol.Instance.mSioConfigPort();
            tsStatusBr.Text = RcpProtocol.Instance.mSioConfigBaud();
        }

        public void DisplayMsgString(string s)
        {
            if (bDisposed)
                return;

            if (!InvokeRequired)
            {
                __DisplayMsgString(s);
                return;
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    __DisplayMsgString(s);
                }));
            }
        }

        private void __DisplayMsgString(string s)
        {
            if (!bDisposed)
            {
                msgSb.Append(s);
                s = s.TrimEnd(new char[] { '\r', '\n', ')', ' ' });

                ListViewItem lvt = new ListViewItem(DateTime.Now.Hour.ToString("00") + ":"
                                                    + DateTime.Now.Minute.ToString("00") + ":"
                                                    + DateTime.Now.Second.ToString("00") + " "
                                                    + DateTime.Now.Millisecond.ToString("000"));

                string[] msg = s.Split(new char[] { '>', '(' }, 3, StringSplitOptions.None);

                if (msg.Length == 1 && msg[0] == "") return;

                try
                {
                    string[] sa = msg[1].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // 0xB1 <- RCP_CMD_SET_DOWNLOAD 
                    // 0xB3 <- RCP_CMD_SET_DUMP
                    // 0xB3 <- RCP_CMD_ISP_DUMP
                    // 0xA8 <- RCP_CMD_GET_MODEM_REG
                    if (sa[2] == "B1" || sa[2] == "B3" || sa[2] == "A8")
                    {
                        return;
                    }
                }
                catch
                {

                }

                Color bc = Color.White;

                for (int i = 0; i < msg.Length; i++)
                {
                    if (i == 0)
                    {
                        switch (msg[0])
                        {
                            case "RCP CMD":
                                bc = Color.OldLace;
                                break;
                            case "RCP RSP":
                                bc = Color.Lavender;
                                break;
                        }
                    }

                    lvt.SubItems.Add(msg[i]);
                }

                lvt.BackColor = bc;
                lvt.Font = new Font("Courier", 7);

                //listViewMsg.Visible = false;

                //if (listViewMsg.Items.Count > 1000)
                //{
                //    for (int i = 0; i < 500; i++)
                //    {
                //        listViewMsg.Items.RemoveAt(0);
                //    }
                //}
                //else
                //{
                //    listViewMsg.Items.Add(lvt).EnsureVisible();
                //}
                //listViewMsg.Update();
                //listViewMsg.Visible = true;

                m_bUpdateLog = true;
            }
        }

        public void RCPDecoder(string s)
        {
            if (bDisposed)
                return;

            if (!InvokeRequired)
            {
                __RCPDecoder(s);
                return;
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    __RCPDecoder(s);
                }));
            }
        }

        private void __RCPDecoder(string s)
        {
            string[] strRCP = s.Split(' ');

            if (strRCP[0] == "ERROR")
            {
                string ss = "Failure to Receive Message, Check the USB Connection \r\n";
                RCPDecoderTxtDisplay(ss, Color.Red);
            }
            else if ((strRCP[0] == "RCP") && (strRCP[1] == "CMD>"))
            {
                RCPDecoderTxtDisplay(CodeToMsgTable.CMDRSPDecoder(strRCP));
            }
            else if ((strRCP[0] == "RCP") && (strRCP[1] == "RSP>"))
            {
                if (strRCP[4] == "FF")
                {
                    RCPDecoderTxtDisplay(CodeToMsgTable.FailCase(strRCP), Color.Red);
                }
                else
                {
                    RCPDecoderTxtDisplay(CodeToMsgTable.CMDRSPDecoder(strRCP), Color.Blue);
                }
            }

        }

        private void RCPDecoderTxtDisplay(string s)
        {
            int idxTemp = 0;
            idxTemp = richTextBoxRCPDecoder.Text.Length;

            richTextBoxRCPDecoder.AppendText(s);

            if (s != "")
            {
                richTextBoxRCPDecoder.ScrollToCaret();
            }

            richTextBoxRCPDecoder.Select(idxTemp, richTextBoxRCPDecoder.Text.Length);
            richTextBoxRCPDecoder.SelectionColor = Color.Black;
        }

        private void RCPDecoderTxtDisplay(string s, Color c)
        {
            int idxTemp = 0;
            idxTemp = richTextBoxRCPDecoder.Text.Length;

            richTextBoxRCPDecoder.AppendText(s);

            if (s != "")
            {
                richTextBoxRCPDecoder.ScrollToCaret();
            }

            richTextBoxRCPDecoder.Select(idxTemp, richTextBoxRCPDecoder.Text.Length);
            richTextBoxRCPDecoder.SelectionColor = c;
        }

        public void RcpLogEventReceived(object sender, StringEventArg e)
        {
            DisplayMsgString(e.Data);
            RCPDecoder(e.Data);
        }

        public void RxRspEventReceived(object sender, byteEventArg e)
        {
            if (this.IsDisposed)
                return;

            if (!this.InvokeRequired)
            {
                __ParseRsp(e.Data);
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    __ParseRsp(e.Data);
                }));
            }
        }

        private byte[] m_oReceivedTagMemoryData = null;
        private byte[] m_oTagMemoryReserved = null;
        private byte[] m_oTagMemoryEpc = null;
        private byte[] m_oTagMemoryTid = null;
        private byte[] m_oTagMemoryUser = null;

        private int m_nMemBank = 0;

        private void __ParseRsp(byte[] Data, int? tagType = null)
        {
            m_bAlive = true;

            byte[] buf = Data;
            int len = (buf[3] << 8) + buf[4];
            int cmd_type = (int)buf[2];

            StringBuilder sb = new StringBuilder();

            char[] chars = new char[len];

            System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();

            try
            {
                d.GetChars(buf, 5, len, chars, 0);
            }
            catch
            {
            }

            byte cmd = Data[2];

            if (TxLeakageRSSIPlot.m_bTestProcess == true)
            {
                TxLeakageRSSIPlot.ParseRsp(Data);
            }

            if (Data.Length >= 8)
            {
                switch (cmd)
                {
                    case RcpProtocol.RCP_CMD_READ_C_DT:
                        {
                            m_oReceivedTagMemoryData = new byte[len];

                            for (int i = 0; i < len; i++)
                            {
                                m_oReceivedTagMemoryData[i] = Data[i + 5];
                            }

                            if (TagMemoryAccessFlag == false)
                            {
                                StringBuilder read = new StringBuilder();
                                foreach (byte abyte in m_oReceivedTagMemoryData)
                                {
                                    read.AppendFormat("{0:X02} ", abyte);
                                }
                                txt_TagID.Text = read.ToString();
                                this.textBoxRwData.Text = read.ToString();
                                ////获取 TagID
                                //txt_TagID.Text = read.ToString();
                            }
                            //else if (TagMemoryAccessFlag == true)
                            //{
                            //    ListViewItem lvt = null;

                            //    for (int i = 0; i < ((m_oReceivedTagMemoryData.Length + 15) / 16); i++)
                            //    {
                            //        switch (m_nMemBank)
                            //        {
                            //            case 0:
                            //                m_oTagMemoryReserved = (byte[])m_oReceivedTagMemoryData.Clone();
                            //                lvt = new ListViewItem("00 Reserved");
                            //                lvt.BackColor = Color.AliceBlue;
                            //                break;
                            //            case 1:
                            //                m_oTagMemoryEpc = (byte[])m_oReceivedTagMemoryData.Clone();
                            //                lvt = new ListViewItem("01 EPC");
                            //                lvt.BackColor = Color.AntiqueWhite;
                            //                break;
                            //            case 2:
                            //                m_oTagMemoryTid = (byte[])m_oReceivedTagMemoryData.Clone();
                            //                lvt = new ListViewItem("10 TID");
                            //                lvt.BackColor = Color.Lavender;
                            //                break;
                            //            case 3:
                            //                m_oTagMemoryUser = (byte[])m_oReceivedTagMemoryData.Clone();
                            //                lvt = new ListViewItem("11 USER");
                            //                lvt.BackColor = Color.Beige;
                            //                break;
                            //        }

                            //        lvt.SubItems.Add((i * 8 * 16).ToString("X04"));

                            //        StringBuilder read = new StringBuilder();
                            //        StringBuilder sbcdt = new StringBuilder();
                            //        System.Text.Decoder dcdt = System.Text.Encoding.UTF8.GetDecoder();

                            //        for (int j = i * 16; j < i * 16 + 16; j++)
                            //        {
                            //            if (j < m_oReceivedTagMemoryData.Length)
                            //            {
                            //                read.AppendFormat("{0:X02} ", m_oReceivedTagMemoryData[j]);

                            //                if (m_oReceivedTagMemoryData[j] >= 0x20 && m_oReceivedTagMemoryData[j] < 0x7F)
                            //                {
                            //                    char[] charscdt = new char[1];
                            //                    d.GetChars(m_oReceivedTagMemoryData, j, 1, chars, 0);
                            //                    sb.Append(new System.String(chars));
                            //                }
                            //                else
                            //                {
                            //                    sb.Append(" ");
                            //                }
                            //            }
                            //            else
                            //            {
                            //                break;
                            //            }
                            //        }

                            //        lvt.SubItems.Add(read.ToString());
                            //        lvt.SubItems.Add(sb.ToString());
                            //        lvt.Font = new Font("Courier New", 8);

                            //        //this.listViewTagMemory.Items.Add(lvt);
                            //    }
                            //}
                        }
                        break;
                    case RcpProtocol.RCP_CMD_GET_RD_INF:
                        if (fd.focused)
                        {
                            fd.ParseRsp(Data);
                            break;
                        }
                        if (InfoReq)
                        {
                            if (ReadMod == RDR_MODEL)
                            {
                                tsPartNumber.Text = "Part Number";
                                tsFWVersion.Text = "Firmware Version";

                                tsPartNumber.Text = "    " + new System.String(chars) + "    ";

                                //ucHwControl1.setRegionList(new System.String(chars));
                            }

                            if (ReadMod == RDR_SN)
                            {
                                string charstoString = string.Empty;

                                for (int i = 0; i < chars.Length; i++)
                                {
                                    charstoString += chars[i];
                                }

                                if (charstoString.IndexOf('!') < 0)
                                {
                                    // Do Nothing
                                }
                                else
                                {
                                    charstoString = charstoString.Substring(0, charstoString.IndexOf('!'));
                                }

                                tsFWVersion.Text = "    " + charstoString + "    ";

                                try
                                {
                                    string temp = new System.String(chars);
                                    temp = temp.Replace("__", "&");
                                    string[] temp1 = temp.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                                    string[] temp2 = temp1[1].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                                }
                                catch
                                {
                                }

                            }

                            if (ReadMod == RDR_MANFACT)
                            {
                                if ((tsPartNumber.Text != "Part Number") && (tsFWVersion.Text == "Firmware Version"))
                                {
                                    MessageBox.Show("ISP Mode", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            if (ReadMod == RDR_STATUS)
                            {
                                if (len != 0x1A)
                                {
                                    return;
                                }

                                int startIndex = 5;

                                //ucHwControl1.setRegionValue(Data[startIndex + 1]);

                                //ucHwControl1.setChannelValue(Data[startIndex + 2], 0);

                                UInt16 readTime = (UInt16)((Data[startIndex + 3] << 8) | Data[startIndex + 4]);
                                UInt16 idleTime = (UInt16)((Data[startIndex + 5] << 8) | Data[startIndex + 6]);
                                UInt16 cwSenseTime = (UInt16)((Data[startIndex + 7] << 8) | Data[startIndex + 8]);
                                Int16 lbtRfLevel = (Int16)((Data[startIndex + 9] << 8) | Data[startIndex + 10]);
                                //ucHwControl1.setFhLbtValue(readTime, idleTime, cwSenseTime, lbtRfLevel, Data[startIndex + 11], Data[startIndex + 12], Data[startIndex + 13]);

                                UInt16 cur_pwr = (UInt16)((buf[startIndex + 14] << 8) | buf[startIndex + 15]);
                                UInt16 min_pwr = (UInt16)((buf[startIndex + 16] << 8) | buf[startIndex + 17]);
                                UInt16 max_pwr = (UInt16)((buf[startIndex + 18] << 8) | buf[startIndex + 19]);

                                //ucHwControl1.setPowerValue(cur_pwr, min_pwr, max_pwr);

                                UInt16 blf = (UInt16)((Data[startIndex + 20] << 8) | Data[startIndex + 21]);

                                //ucHwControl1.SetModulationValue(blf, Data[startIndex + 22], Data[startIndex + 23]);

                                //ucTabAirInterface1.setSessionValue(Data[startIndex + 24]);

                                ReadMod = RDR_MODEL;

                                CheckPartNumber();
                            }
                        }
                        break;
                    case RcpProtocol.RCP_CMD_SET_PART_NUMBER:
                        if (tsFWVersion.Text.Trim().StartsWith("RED") && tsPartNumber.Text.Trim().StartsWith("PRM92"))
                        {
                            ByteBuilder bb = new ByteBuilder();

                            bb.Append(0x01);

                            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_UPDATE_FLASH, bb.GetByteArray()))) { }

                            MessageBox.Show("Product Code has been fixed.\r\nPlease reset your hardware..");
                        }
                        break;

                    case RcpProtocol.RCP_CMD_GET_DTC_RESULT:
                    case RcpProtocol.RCP_RSP_REQUESTFAST_LEKAGE_CANCELLATION:
                        RefInductorVal = int.Parse(Data[5].ToString());
                        TxLeakageRSSIPlot.DefaultInductorVal = RefInductorVal;
                        int rsVal = 0;
                        rsVal = int.Parse(Data[8].ToString());

                        if ((rsVal >= 0) && (rsVal <= 30))
                        {
                            progressCircle.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        }
                        else if ((rsVal > 30) && (rsVal <= 50))
                        {
                            progressCircle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0);
                        }
                        else
                        {
                            progressCircle.ForeColor = System.Drawing.Color.FromArgb(250, 128, 0);
                        }
                        /*
                        if (leakTable)
                        {
                            leakTableUpdate(Data);
                        }
                        */
                        //userControlLeakGuidance.ParseRsp(Data);

                        break;

                    case RcpProtocol.RCP_CMD_READ_C_UII_RSSI:
                    case RcpProtocol.RCP_CMD_READ_C_UII:
                        {
                            if (Data[1] == 0x01)
                            {
                                ReadRateTimer.Start();
                            }

                            if (lvEPCupdateThread == null || lvEPCupdateThread.IsAlive == false)
                            {
                                lvEPCupdateThreadFlag = true;
                                lvEPCupdateThread = new Thread(new ThreadStart(lvEPCupdate));
                                lvEPCupdateThread.Start();
                            }

                            StringBuilder hsb = new StringBuilder();

                            this.buttonReadMultiple.Text = " Stop ";

                            string tag_rssi = "";

                            if ((((Data[5] >> 3) + 1) * 2) + 2 < len)
                            {
                                tag_rssi = CalcTagRssi(Data);
                                len -= 4;
                            }

                            for (int i = 5; i < len + 5; i++)
                            {
                                try
                                {
                                    hsb.Append(buf[i].ToString("X2") + " ");
                                }
                                catch
                                {
                                    break;
                                }
                            }

                            bool xi = false;
                            bool xeb = false;
                            int pcMSB;
                            int xpc_w1;

                            ListViewItem lvt = new ListViewItem("0");

                            lvt.SubItems.Add(hsb.ToString().Substring(0, 5));

                            pcMSB = Data[5];

                            if ((pcMSB & 0x02) > 0)
                                xi = true;

                            if (xi)
                            {
                                xpc_w1 = (Data[7]) << 8 + Data[8];

                                if ((xpc_w1 >> 7) > 0)
                                    xeb = true;

                                if (xeb)
                                {
                                    lvt.SubItems.Add(hsb.ToString().Substring(12));
                                }
                                else
                                {
                                    lvt.SubItems.Add(hsb.ToString().Substring(18));
                                }
                            }
                            else
                            {
                                lvt.SubItems.Add(hsb.ToString().Substring(6));
                            }

                            lvt.SubItems.Add("1");
                            lvt.SubItems.Add(tag_rssi);
                            lvt.Font = new Font("Courier New", 8);

                            lvEPCq.Enqueue(lvt);
                        }
                        break;

                    case RcpProtocol.RCP_CMD_READ_C_UII_TID:
                        {
                            int Payload = 0;
                            int PC = 0;
                            int EPCLengthField = 0;
                            int Length = 0;

                            string tid = string.Empty;

                            this.buttonReadMultiple.Text = " Stop ";

                            if (Data[5] == 0x1F)
                            {
                                this.buttonReadMultiple.Text = " Start ";
                                lvEPCupdateThreadFlag = false;

                                ReadRateTimer.Stop();
                            }
                            else
                            {
                                if (Data[1] == 0x01)
                                {
                                    ReadRateTimer.Start();
                                }
                                else if (Data[1] == 0x02)
                                {
                                    if (lvEPCupdateThread == null || lvEPCupdateThread.IsAlive == false)
                                    {
                                        lvEPCupdateThreadFlag = true;
                                        lvEPCupdateThread = new Thread(new ThreadStart(lvEPCupdate));
                                        lvEPCupdateThread.Start();
                                    }

                                    Payload = (Data[3] << 8) | Data[4];

                                    if ((Payload == 0x01) && (Data[5] == 0x1F))
                                    {
                                        break;
                                    }

                                    PC = (Data[5] << 8) | Data[6];
                                    EPCLengthField = PC >> 11;

                                    Length = EPCLengthField * 2 + 2; // EPC Length + PC Length

                                    StringBuilder hsb = new StringBuilder();
                                    StringBuilder hsbTID = new StringBuilder();

                                    for (int i = 5; i < 5 + Length; i++)
                                    {
                                        try
                                        {
                                            hsb.Append(buf[i].ToString("X2") + " ");
                                        }
                                        catch
                                        {
                                            break;
                                        }
                                    }

                                    for (int i = 0; i < (Payload - Length); i++)
                                    {
                                        try
                                        {
                                            hsbTID.Append(buf[5 + Length + i].ToString("X2") + " ");
                                        }
                                        catch
                                        {
                                            break;
                                        }
                                    }

                                    bool xi = false;
                                    bool xeb = false;
                                    int pcMSB;
                                    int xpc_w1;

                                    ListViewItem lvt = new ListViewItem("0");

                                    pcMSB = Data[5];
                                    lvt.SubItems.Add(hsb.ToString().Substring(0, 5));

                                    if ((pcMSB & 0x02) > 0)
                                        xi = true;

                                    if (xi)
                                    {
                                        xpc_w1 = (Data[7]) << 8 + Data[8];

                                        if ((xpc_w1 >> 7) > 0)
                                            xeb = true;

                                        if (xeb)
                                        {
                                            lvt.SubItems.Add(hsb.ToString().Substring(12));
                                        }
                                        else
                                        {
                                            lvt.SubItems.Add(hsb.ToString().Substring(18));
                                        }
                                    }
                                    else
                                    {
                                        lvt.SubItems.Add(hsb.ToString().Substring(6));
                                    }

                                    lvt.SubItems.Add("1");
                                    lvt.SubItems.Add(hsbTID.ToString());
                                    lvt.Font = new Font("Courier New", 8);

                                    lvEPCq.Enqueue(lvt);
                                }
                            }
                        }
                        break;
                    case RcpProtocol.RCP_CMD_STRT_AUTO_READ:
                    case RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX:
                        if (buf[5] == 0x1F)
                        {
                            this.buttonReadMultiple.Text = " Start ";
                            ReadRateTimer.Stop();
                        }
                        else
                        {
                            this.buttonReadMultiple.Text = " Stop ";
                            lvEPCupdateThreadFlag = false;

                            count100ms = 0;
                            //ReadRateTimer.Start();
                        }
                        break;

                    case RcpProtocol.RCP_CMD_STOP_AUTO_READ:
                    case RcpProtocol.RCP_CMD_STOP_AUTO_READ_EX:
                        {
                            this.buttonReadMultiple.Text = " Start ";
                            lvEPCupdateThreadFlag = false;
                            ReadRateTimer.Stop();
                        }
                        break;

                    case RcpProtocol.RCP_CMD_GET_RSSI:
                    case RcpProtocol.RCP_CMD_SCAN_RSSI:
                    case RcpProtocol.RCP_CMD_GET_REGION:
                    case RcpProtocol.RCP_CMD_GET_CH:
                    case RcpProtocol.RCP_CMD_GET_TX_OFFSET:
                    case RcpProtocol.RCP_CMD_GET_TX_PWR:
                    case RcpProtocol.RCP_CMD_GET_FH_LBT:
                    case RcpProtocol.RCP_CMD_GET_HOPPING_TBL:
                    case RcpProtocol.RCP_CMD_GET_MODULATION:
                    case RcpProtocol.RCP_CMD_SET_MODULATION:
                    case RcpProtocol.RCP_CMD_GET_MODULE_PWR_TBL:
                    case RcpProtocol.RCP_CMD_GET_MODULE_TX_PWR:  // v1.0.4, Get Tx Power
                        if (FormTxLeakagePlot.TxLeakageTest == false)
                        {
                            //ucHwControl1.ParseRsp(Data);
                            //ucTabAirInterface1.SetRxModandDR(Data[7], Data[8]);
                        }
                        else
                        {
                            TxLeakageRSSIPlot.ParseRsp(Data);
                        }

                        break;

                    case 0xB3:  // v1.0.4, Get Module Tx Power
                        {
                            if (fd.focused)
                                fd.test(Data);
                            else { }
                            //ucHwControl1.ParseRsp(Data);
                        }
                        break;

                    case RcpProtocol.RCP_CMD_CTL_RESET:
                        ResetOperation();
                        this.buttonReadMultiple.Text = " Start ";
                        break;

                    case RcpProtocol.RCP_CMD_SET_DOWNLOAD:
                        fd.test(Data);
                        break;

                    case RcpProtocol.RCP_GET_REGISTRY_ITEM:


                        if (SyncThread.IsAlive == true)
                        {
                            //ucHwControl1.ModuleType = Data[8];
                        }


                        //if (source | ucHwControl1.source)
                        //{
                        //    source = false;
                        //    ucHwControl1.source = false;
                        //    ucHwControl1.ParseRsp(Data);
                        //}
                        else if (fd.focused)
                        {
                            fd.test(Data);
                        }
                        else if (skipProcess)
                        {
                            skipProcess = false;
                        }
                        else
                        {
                            //if ((ucRegistry1.RegistryThread != null) && (ucRegistry1.RegistryThread.IsAlive == true))
                            //{
                            //    ucRegistry1.ParseRsp(Data);
                            //}
                        }
                        break;

                    case RcpProtocol.RCP_CMD_EM_TRANSPORT:
                        //if ((buf[7] & 0x80) == 0x80)
                        //{
                        //    textBoxGetSensorHandle.Text = "1";
                        //    textBoxEMRxData.Clear();
                        //}
                        //else
                        //{
                        //    int rxBitlen = ((buf[5] << 3) | (buf[6]));
                        //    ByteBuilder src_bb = new ByteBuilder();
                        //    ByteBuilder dst_bb = new ByteBuilder();
                        //    textBoxGetSensorHandle.Text = "0";
                        //    for (int i = 0; i < ((rxBitlen + 7) >> 3); i++)
                        //    {
                        //        src_bb.Append(buf[7 + i]);
                        //    }
                        //    dst_bb.Append(bit_array_shift_l(src_bb.GetByteArray(), (UInt16)rxBitlen, 1));

                        //    string str = StringHelper.ArgByteToStringByte(dst_bb.GetByteArray(0, ((rxBitlen - 1) >> 3)));

                        //    textBoxEMRxData.Text = str;

                        //}
                        break;
                    case RcpProtocol.RCP_CMD_GET_C_SEL_PARM:
                    case RcpProtocol.RCP_CMD_GET_C_QRY_PARM:
                    case RcpProtocol.RCP_CMD_GET_ANTICOL_MODE:
                    case RcpProtocol.RCP_CMD_SET_ANTICOL_MODE:
                    case RcpProtocol.RCP_CMD_GET_SESSION:
                        //ucTabAirInterface1.ParseRsp(Data);
                        break;
                    case RcpProtocol.RCP_CMD_GET_IAP_VER:
                        if (fd.focused)
                        {
                            fd.ParseRsp(Data);
                        }
                        break;
                    case RcpProtocol.RCP_RSP_FAILURE:

                        //if (ucRegistry1.RegistryThread != null)
                        //{
                        //    if ((ucRegistry1.RegistryThread.IsAlive) && (Data[3] == RcpProtocol.RCP_GET_REGISTRY_ITEM))
                        //    {
                        //        ucRegistry1.RegistryThread.Abort();
                        //    }
                        //}
                        break;
                    case RcpProtocol.RCP_GET_TEMPERATURE:
                    case RcpProtocol.RCP_CMD_CALC_DTC:
                    case RcpProtocol.RCP_CMD_GET_FB_PARAM:
                    case RcpProtocol.RCP_CMD_GET_DTC:
                        TxLeakageRSSIPlot.ParseRsp(Data);
                        break;
                    case RcpProtocol.RCP_CMD_SET_CW:
                        break;

                    case RcpProtocol.RCP_CMD_GET_LEAK_CAL_MODE:
                        //userControlLeakGuidance.ParseRsp(Data);
                        break;

                    case RcpProtocol.RCP_CMD_START_AUTO_READ_RFM:
                    case RcpProtocol.RCP_CMD_START_AUTO_READ_EM:
                        if (_fST != null)
                        {
                            _fST.ParseRsp(Data);
                        }
                        break;
                }
            }
            else
            {
                switch (cmd)
                {
                    case RcpProtocol.RCP_CMD_SET_DOWNLOAD:
                        fd.test(Data);
                        break;
                }
            }

            DisplayStatusInfo(Data);
            m_bRcpReceived = true;
        }

        private byte[] bit_array_shift_l(byte[] src, UInt16 BitLength, byte BitOffset)
        {
            UInt16 i;
            byte[] dst = new byte[((BitLength + 7) >> 3)];

            for (i = 0; i < (((BitLength + BitOffset) + 7) >> 3); i++)
            {
                dst[i] = bit_align(src[i], (byte)(8 - BitOffset), BitOffset);

                if (((BitLength >> 3) - i) > 0)
                {
                    dst[i] |= bit_align(src[i + 1], BitOffset, (int)(-8 + BitOffset));
                }
            }
            return dst;
        }

        private byte bit_align(byte source_byte, byte bit_length, int lsb_offset)
        {
            if (lsb_offset > 0)
            {
                return (byte)((source_byte & ((1 << bit_length) - 1)) << lsb_offset);
            }
            else
            {
                return (byte)(((source_byte >> (0 - lsb_offset)) & ((1 << bit_length) - 1)));
            }
        }

        private string CalcTagRssi(byte[] Data)
        {
            double tag_rssi;
            int rssi_i;
            int rssi_q;
            int gain_i;
            int gain_q;
            double rfin_i;
            double rfin_q;

            rssi_i = Data[Data.Length - 7];
            rssi_q = Data[Data.Length - 6];
            gain_i = Data[Data.Length - 5];
            gain_q = Data[Data.Length - 4];

            rfin_i = (20 * Math.Log10(rssi_i) - gain_i - 33 - 30);
            rfin_q = (20 * Math.Log10(rssi_q) - gain_q - 33 - 30);

            rfin_i = Math.Pow(10, (rfin_i / 20));
            rfin_q = Math.Pow(10, (rfin_q / 20));

            tag_rssi = Math.Sqrt(Math.Pow(rfin_i, 2) + Math.Pow(rfin_q, 2));

            return String.Format("{0:0.0}", 20 * Math.Log10(tag_rssi));
        }

        private void DisplayStatusInfo(byte[] data)
        {
            byte cmd = data[2];
            string msg = "";

            if (cmd == 0x22) return;

            if (cmd == 0xFF)
            {
                switch (data[5])
                {
                    case 0x15:
                        msg = "  Fail No Tag";
                        break;
                    case 0x09:
                        msg = "  Fail Access Tag Memory";
                        break;
                }
            }
            else
            {
                switch (cmd)
                {
                    case RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX:
                        {
                            switch (data[5])
                            {
                                case 0x00: msg = "  Start EPC Read"; break;
                                case 0x1F:
                                    msg = "  Complete EPC Read ";
                                    lvEPCupdateThreadFlag = false;
                                    break;
                            }
                        }
                        break;
                    case RcpProtocol.RCP_CMD_STOP_AUTO_READ:
                        msg = "  Stop EPC Read";
                        break;
                    case RcpProtocol.RCP_CMD_READ_C_DT:
                        msg = "  Success TAG Data Read ";
                        break;
                    case RcpProtocol.RCP_CMD_WRIT_C_DT:
                        msg = "  Success TAG Data Write ";
                        break;
                    case RcpProtocol.RCP_CMD_LOCK_C:
                        msg = "  Success TAG Data Lock ";
                        break;
                    case RcpProtocol.RCP_CMD_KILL_RECOM_C:
                        msg = "  Success Tag Data Kill ";
                        break;
                    case RcpProtocol.RCP_CMD_GET_RD_INF:
                        msg = "  Ready..";
                        break;
                    case RcpProtocol.RCP_CMD_NXP_READPROTECT:
                        msg = "  Success ReadProtect ";
                        break;
                    case RcpProtocol.RCP_CMD_NXP_RESET_READPROTECT:
                        msg = "  Success Reset ReadProtect";
                        break;
                    case RcpProtocol.RCP_CMD_NXP_CHANGE_EAS:
                        msg = "  Success Change EAS";
                        break;
                    case RcpProtocol.RCP_CMD_NXP_EAS_ALARM:
                        msg = "  Success EAS Alarm";
                        break;
                    case RcpProtocol.RCP_CMD_NXP_CALIBRATE:
                        msg = "  Success Calibrate";
                        break;
                }
            }

            tsStatusInfo.Text = msg;
        }

        private void ThreadReadInfo()
        {
            if (!m_bAlive && RcpProtocol.Instance.IsOpened())
            {
                getReaderinfoItem();

                if (!this.InvokeRequired)
                {
                    this.tsStatusInfo.Text = "  Ready..  ";
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.tsStatusInfo.Text = "  Ready..  ";
                    }));
                }
            }
        }

        private void getReaderinfoItem()
        {
            byte[] param = new byte[1];

            InfoReq = true;

            System.Threading.Thread.Sleep(500);
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_ANTICOL_MODE, null))) { return; }
            System.Threading.Thread.Sleep(100);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_GET_REGISTRY_ITEM, new byte[] { 0x00, 0x00 }))) { return; }
            System.Threading.Thread.Sleep(100);

            param[0] = ReadMod = RDR_MODEL;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RD_INF, param))) { return; }
            System.Threading.Thread.Sleep(100);

            param[0] = ReadMod = RDR_SN;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RD_INF, param))) { return; }
            System.Threading.Thread.Sleep(100);

            param[0] = ReadMod = RDR_MANFACT;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RD_INF, param))) { return; }
            System.Threading.Thread.Sleep(100);

            param[0] = ReadMod = RDR_STATUS;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RD_INF, param))) { return; }
            System.Threading.Thread.Sleep(100);
        }

        private void tsMenuItemClear_Click(object sender, EventArgs e)
        {
            //listViewMsg.Items.Clear();
            //txtboxRCPHelp.Clear();
            msgSb.Remove(0, msgSb.Length);
        }

        private void tsMenuItemCopy_Click(object sender, EventArgs e)
        {
            //if (listViewMsg.SelectedItems != null && listViewMsg.SelectedItems.Count != 0) Clipboard.SetText(listViewMsg.SelectedItems[0].SubItems[0].Text + "\t" + listViewMsg.SelectedItems[0].SubItems[1].Text + "\t" + listViewMsg.SelectedItems[0].SubItems[2].Text);
        }

        private void tsMenuItemCopyAll_Click(object sender, EventArgs e)
        {
            if (msgSb != null && msgSb.Length != 0) Clipboard.SetText(msgSb.ToString());
        }

        private void defaultSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
        }

        private void ResetOperation()
        {
            m_bAlive = false;

            if (SyncThread == null || SyncThread.IsAlive == false)
            {
                SyncThread = new Thread(new ThreadStart(ThreadReadInfo));
                SyncThread.Start();


            }
        }

        private void tsSoundOff_Click(object sender, EventArgs e)
        {
            //if (this.tsSoundOff.Text == "Sound On")
            //{
            //    this.tsSoundOff.Text = "Sound Off";
            //    soundOn = false;

            //}
            //else
            //{
            //    this.tsSoundOff.Text = "Sound On";
            //    soundOn = true;
            //}
        }

        private void tsSubMenuAbout_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly a = typeof(FrormTaginitialize).Assembly;
            String version = a.GetName().Version.ToString();
            FormAbout fa = new FormAbout();

            fa.SetVersion(version);
            fa.ShowDialog();
        }

        private void tsSubMenuCreateReport_Click(object sender, EventArgs e)
        {
            saveFileDialogReport.ShowDialog();
        }

        private void saveFileDialogReport_FileOk(object sender, CancelEventArgs e)
        {
            if (monThread == null || monThread.IsAlive == false)
            {
                monThread = new Thread(new ThreadStart(CreateReport));
                monThread.Start();
            }
        }

        private void CreateReport()
        {
            Logger.Instance.LogOpen(saveFileDialogReport.FileName);

            // GUI information
            System.Reflection.Assembly a = typeof(FrormTaginitialize).Assembly;
            String version = a.GetName().Version.ToString();
            FormAbout fa = new FormAbout();

            string temp = fa.GetAbout(version);

            Logger.Instance.LogWriteLine(temp);

            try
            {
                // Module information                
                getReaderinfoItem();

                // Registry Dump
                for (int i = 0xFC00; i < 0x10000; i += 0x10)
                {
                    m_bRcpReceived = false;

                    SendDumpCmd(i);
                    this.WaitForReceived();
                }
                Logger.Instance.LogClose();
            }
            catch
            {
                Logger.Instance.LogClose();
            }
        }

        private bool m_bRcpReceived = false;

        private void WaitForReceived()
        {
            for (int j = 0; j < 50; j++)
            {
                System.Threading.Thread.Sleep(10);
                if (m_bRcpReceived) break;
            }
        }

        private bool SendDumpCmd(int data)
        {
            byte[] byte_data = new byte[2];

            byte_data[0] = (byte)((data >> 8) & 0xFF);
            byte_data[1] = (byte)(data & 0xFF);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_DUMP, byte_data))) { }

            return true;
        }

        private int nTagCnt;

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReadMultiple_Click(object sender, EventArgs e)
        {
            if (buttonReadMultiple.Text == " Start ")
            {
                buttonReadMultiple.Text = " Stop ";

                this.listViewEPC.Items.Clear();
                richTextBoxRCPDecoder.Clear();

                nTagCnt = 0;
                lbTagCount.Text = nTagCnt.ToString();

                if (withRSSIToolStripMenuItem.Checked == true)
                {
                    AutoReadRSSI();
                }
                else if (withTIDToolStripMenuItem.Checked == true)
                {
                    AutoReadTID();
                }
                else
                {
                    AutoRead2();
                    AutoReadTID();
                }

                this.toolStripBtnStartread.Enabled = false;
                this.toolStripBtnStopRead.Enabled = true;
            }
            else
            {
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STOP_AUTO_READ_EX, null))) { }

                buttonReadMultiple.Text = " Start ";
                lvEPCupdateThreadFlag = false;

                this.toolStripBtnStartread.Enabled = true;
                this.toolStripBtnStopRead.Enabled = false;
            }
        }

        private void AutoRead2()
        {
            byte[] param = new byte[5];

            UInt16 cycle = 0;
            byte mtnu = 0;
            byte mtime = 0;

            try
            {
                cycle = Convert.ToUInt16(this.textBox_RepeatCycle.Text);
                //mtnu = Convert.ToByte(this.textBox_MTNU.Text);
                mtnu = Convert.ToByte(0);
                mtime = Convert.ToByte(this.textBox_MTIME.Text);
            }
            catch
            {
                this.textBox_RepeatCycle.Text = "0";
                //this.textBox_MTNU.Text = "0";
                this.textBox_MTIME.Text = "0";
                return;
            }

            param[0] = 0x02;    // type C
            param[1] = mtnu;    // MTNU
            param[2] = mtime;   // MTNU
            param[3] = (byte)((cycle & ((UInt16)0xff00)) >> 8);
            param[4] = (byte)(cycle & ((UInt16)0x00FF));

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX, param))) { }
        }

        private void AutoReadRSSI()
        {
            //byte[] param = new byte[5];

            //UInt16 cycle = 0;
            //byte mtnu = 0;
            //byte mtime = 0;

            //try
            //{
            //    cycle = Convert.ToUInt16(this.textBox_RepeatCycle.Text);
            //    mtnu = Convert.ToByte(this.textBox_MTNU.Text);
            //    mtime = Convert.ToByte(this.textBox_MTIME.Text);
            //}
            //catch
            //{
            //    this.textBox_RepeatCycle.Text = "0";
            //    //this.textBox_MTNU.Text = "0";
            //    this.textBox_MTIME.Text = "0";

            //    return;
            //}

            //param[0] = 0x02;    // type C
            //param[1] = mtnu;    // MTNU
            //param[2] = mtime;   // MTIME
            //param[3] = (byte)((cycle & ((UInt16)0xff00)) >> 8);
            //param[4] = (byte)(cycle & ((UInt16)0x00FF));

            //if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_RSSI, param))) { }
        }

        private void AutoReadTID()
        {
            byte[] param = new byte[4];

            UInt16 cycle = 0;
            byte mtnu = 0;
            byte mtime = 0;

            try
            {
                //mtnu = Convert.ToByte(this.textBox_MTNU.Text);
                mtnu = Convert.ToByte(0);
                mtime = Convert.ToByte(this.textBox_MTIME.Text);
                cycle = Convert.ToUInt16(this.textBox_RepeatCycle.Text);
            }
            catch
            {
                //this.textBox_RepeatCycle.Text = "0";
                //this.textBox_MTNU.Text = "0";
                //this.textBox_MTIME.Text = "0";

                return;
            }

            param[0] = mtnu;  // MTNU
            param[1] = mtime; // MTIME
            param[2] = (byte)((cycle & ((UInt16)0xff00)) >> 8);
            param[3] = (byte)(cycle & ((UInt16)0x00FF));

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_UII_TID, param))) { }
        }

        private byte[] BuildSelectRcpPacket(string target)
        {
            ByteBuilder bb = new ByteBuilder();

            string[] temp = new string[0];

            if (target != null) temp = target.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            byte[] mask = new byte[0];

            if (target != null)
            {
                mask = new byte[temp.Length];

                for (int i = 0; i < mask.Length; i++)
                {
                    mask[i] = Convert.ToByte(temp[i], 16);
                }
            }

            byte[] param = new byte[7];

            param[0] = 0x01;    // Bank : EPC
            param[1] = 0x00;
            param[2] = 0x00;
            param[3] = 0x00;
            param[4] = 0x20;    // Pointer : head of EPC
            param[5] = Convert.ToByte(temp.Length << 3);
            param[6] = 0;

            bb.Append(param);

            bb.Append(mask);

            return bb.GetByteArray();
        }

        private Thread newThread = null;

        //private void viewTagMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    TagMemoryAccessFlag = true;
        //    this.tabControlDetails.SelectedTab = this.tabMemoryAccess;

        //    this.listViewTagMemory.Items.Clear();

        //    if (newThread == null || newThread.IsAlive == false)
        //    {
        //        newThread = new Thread(new ThreadStart(TagMemoryView));
        //        newThread.Start();
        //    }

        //    //if (btnControlPanel.Text == "start")
        //    //{
        //    //    btnControlPanel.PerformClick();
        //    //    btnControlPanel.Text = "end";
        //    //}
        //}

        private void TagMemoryView()
        {
            UInt16 uUiiLen = 0;
            string target = null;

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate ()
                {
                    try
                    {
                        if ((listViewEPC.SelectedItems == null) || (listViewEPC.SelectedItems.Count == 0)) return;

                        target = listViewEPC.SelectedItems[0].SubItems[2].Text;

                        if (target.Length == 0) return;

                        uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }));

            if (target == null)
            {
                MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_oTagMemoryReserved = null;
            m_oTagMemoryEpc = null;
            m_oTagMemoryTid = null;
            m_oTagMemoryUser = null;

            for (m_nMemBank = 0; m_nMemBank < 4; m_nMemBank++)
            {
                ByteBuilder bb = new ByteBuilder();
                bb.Append(new byte[] { 0x00, 0x00, 0x00, 0x00 }); // AP
                bb.Append(uUiiLen); // UL
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
                bb.Append((byte)m_nMemBank); // MB
                bb.Append(0); // SA
                bb.Append(0); // SA
                bb.Append(0); // DL
                bb.Append(0); // DL

                m_bRcpReceived = false;
                m_oReceivedTagMemoryData = null;

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_DT, bb.GetByteArray()))) { break; }
                System.Threading.Thread.Sleep(500);
                //this.WaitForReceived();
            }
        }

        private void listViewEPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;
        }

        private void selectThisTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_SEL_PARM, BuildSelectRcpPacket(target))))
            {
                return;
            }
            else
            {
                this.labelSelectedTag.Visible = true;
                this.labelSelectedTag.Text = "Selected EPC : " + target;
            }
        }

        /// <summary>
        /// 获取tagID
        /// </summary>
        private void GetTagID(byte cmd = RcpProtocol.RCP_CMD_READ_C_DT)
        {
            TagMemoryAccessFlag = false;
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            byte[] ap;
            byte uMem;

            try
            {
                //16进制长度
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                //开始位置
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                //长度
                uLength = UInt16.Parse(textBoxRwLength.Text);
                //读取类型
                //uMem = (byte)cbTagRwTarMem.SelectedIndex;
                uMem = (byte)2;
                //进入密钥
                ap = StringHelper.ArgStringHexToByte(textBoxRwAccessPw.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ByteBuilder bb = new ByteBuilder();
            bb.Append(ap); // AP
            bb.Append(uUiiLen); // UL
            if (uUiiLen > 0)
            {
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            }
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uLength); // DL

            m_oReceivedTagMemoryData = null;

            byte[] BuildCmdPacketByte = RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, cmd, bb.GetByteArray());
            if (!RcpProtocol.Instance.SendBytePkt(BuildCmdPacketByte))
            {

            }
        }

        public bool TagMemoryAccessFlag = false;


        /// <summary>
        /// 读取标签信息 2 tagid
        /// </summary>
        /// <param name="typeId"></param>
        private void ReadTagMemory(int? typeId = null)
        {
            TagMemoryAccessFlag = false;
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            byte[] ap;
            byte uMem;

            try
            {
                //16进制长度
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                //开始位置
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                //长度
                uLength = UInt16.Parse(textBoxRwLength.Text);
                //读取类型
                uMem = (null != typeId) ? (byte)typeId : (byte)cbTagRwTarMem.SelectedIndex;
                //进入密钥
                ap = StringHelper.ArgStringHexToByte(textBoxRwAccessPw.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ByteBuilder bb = new ByteBuilder();
            bb.Append(ap); // AP
            bb.Append(uUiiLen); // UL
            if (uUiiLen > 0)
            {
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            }
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uLength); // DL

            m_oReceivedTagMemoryData = null;

            byte[] BuildCmdPacketByte = RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_DT, bb.GetByteArray());
            if (!RcpProtocol.Instance.SendBytePkt(BuildCmdPacketByte))
            {

            }
        }
        /// <summary>
        /// 读取标签内存信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReadTagMemory_Click(object sender, EventArgs e)
        {
            ReadTagMemory();
        }

        /// <summary>
        /// 写入内存标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWriteDataToTag_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            ByteBuilder bb = new ByteBuilder();

            byte[] ap;
            byte uMem;
            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            UInt16 uDtLen;

            try
            {
                ap = StringHelper.ArgStringHexToByte(this.textBoxRwAccessPw.Text);
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                uLength = UInt16.Parse(textBoxRwLength.Text);
                uMem = (byte)cbTagRwTarMem.SelectedIndex;
                uDtLen = (UInt16)(StringHelper.ArgStringHexToByte(textBoxRwData.Text)).Length;
                uDtLen /= 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ap == null) return;

            bb.Append(ap);// AP

            bb.Append(uUiiLen); // UL
            if (uUiiLen > 0)
            {
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            }
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uDtLen); // DL            
            bb.Append(StringHelper.ArgStringHexToByte(textBoxRwData.Text)); // DT

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }

            if (uMem == 0x01) this.listViewEPC.Items.Clear();
        }

        /// <summary>
        /// 清空标签信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBlockEraseTagMemory_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            if (target.Length == 0) return;

            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            byte[] ap;
            byte uMem;

            try
            {
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                uLength = UInt16.Parse(textBoxRwLength.Text);
                uMem = (byte)cbTagRwTarMem.SelectedIndex;
                ap = StringHelper.ArgStringHexToByte(textBoxRwAccessPw.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ByteBuilder bb = new ByteBuilder();
            bb.Append(ap); // AP
            bb.Append(uUiiLen); // UL
            bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uLength); // DL

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_BLOCKERASE_C_DT, bb.GetByteArray()))) { }
        }

        /// <summary>
        /// 批量写入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBlockWriteDataToTag_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            ByteBuilder bb = new ByteBuilder();

            byte[] ap;
            byte uMem;
            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            UInt16 uDtLen;

            try
            {
                ap = StringHelper.ArgStringHexToByte(this.textBoxRwAccessPw.Text);
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                uLength = UInt16.Parse(textBoxRwLength.Text);
                uMem = (byte)cbTagRwTarMem.SelectedIndex;
                uDtLen = (UInt16)(StringHelper.ArgStringHexToByte(textBoxRwData.Text)).Length;
                uDtLen /= 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ap == null) return;

            bb.Append(ap);// AP
            bb.Append(uUiiLen); // UL
            if (uUiiLen > 0)
            {
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            }
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uDtLen); // DL            
            bb.Append(StringHelper.ArgStringHexToByte(textBoxRwData.Text)); // DT

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_BLOCKWRITE_C_DT, bb.GetByteArray()))) { }
        }



        private byte[] GetTarget()
        {
            byte[] ret = null;

            try
            {
                if (listViewEPC.SelectedItems.Count == 0) return null;

                string target = listViewEPC.SelectedItems[0].SubItems[2].Text;
                ret = StringHelper.ArgStringHexToByte(target);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ret;
        }



        private void buttonNxpEasAlarm_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_NXP_EAS_ALARM, null))) { }
        }



        private void TagMemoryInfoModifyReserved(System.Windows.Forms.ListViewItem lvTagInfo)
        {
            FormTagInfoReserved reserved = new FormTagInfoReserved();

            if (m_oTagMemoryReserved.Length >= 8)
            {
                byte[] arrayKillPw = new byte[4];
                byte[] arrayAccessPw = new byte[4];

                Array.Copy(m_oTagMemoryReserved, 0, arrayKillPw, 0, arrayKillPw.Length);
                Array.Copy(m_oTagMemoryReserved, 4, arrayAccessPw, 0, arrayAccessPw.Length);

                reserved.TextBoxKillPwRd.Text = StringHelper.ArgByteToStringByte(arrayKillPw).TrimEnd(new char[] { ' ' });
                reserved.TextBoxKillPwWrt.Text = StringHelper.ArgByteToStringByte(arrayKillPw).TrimEnd(new char[] { ' ' });

                reserved.TextBoxAccessPwRd.Text = StringHelper.ArgByteToStringByte(arrayAccessPw).TrimEnd(new char[] { ' ' });
                reserved.TextBoxAccessPwWrt.Text = StringHelper.ArgByteToStringByte(arrayAccessPw).TrimEnd(new char[] { ' ' });
            }
            else
            {
                return;
            }

            reserved.ShowDialog();
            if (reserved.KillPwWrt != null)
            {
                ByteBuilder bb = new ByteBuilder();

                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append((UInt16)GetTarget().Length); // UL
                bb.Append(GetTarget()); // UII
                bb.Append(0); // MB
                bb.Append(0); // SA
                bb.Append(0); // SA
                bb.Append(0); // DL
                bb.Append(2); // DL                    
                bb.Append(reserved.KillPwWrt); // DT

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }
                else
                {
                    //viewTagMemoryToolStripMenuItem_Click(null, null);
                }
            }
            if (reserved.AccessPwWrt != null)
            {
                ByteBuilder bb = new ByteBuilder();

                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append((UInt16)GetTarget().Length); // UL
                bb.Append(GetTarget()); // UII
                bb.Append(0); // MB
                bb.Append(0); // SA
                bb.Append(2); // SA
                bb.Append(0); // DL
                bb.Append(2); // DL                    
                bb.Append(reserved.AccessPwWrt); // DT

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }
                else
                {
                    //viewTagMemoryToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void TagMemoryInfoModifyEpc(System.Windows.Forms.ListViewItem lvTagInfo)
        {
            FormTagInfoEpc epc = new FormTagInfoEpc();
            if (m_oTagMemoryEpc.Length >= 6)
            {
                byte[] arrayCrc = new byte[2];
                byte[] arrayPc = new byte[2];
                byte[] arrayEpc = new byte[m_oTagMemoryEpc.Length - 4];
                Array.Copy(m_oTagMemoryEpc, 0, arrayCrc, 0, arrayCrc.Length);
                Array.Copy(m_oTagMemoryEpc, 2, arrayPc, 0, arrayPc.Length);
                Array.Copy(m_oTagMemoryEpc, 4, arrayEpc, 0, arrayEpc.Length);
                epc.TextBoxCrcRd.Text = StringHelper.ArgByteToStringByte(arrayCrc);
                epc.TextBoxPcRd.Text = StringHelper.ArgByteToStringByte(arrayPc);
                epc.TextBoxEpcRd.Text = StringHelper.ArgByteToStringByte(arrayEpc).TrimEnd(new char[] { ' ' });
                epc.TextBoxEpcWrt.Text = StringHelper.ArgByteToStringByte(arrayEpc).TrimEnd(new char[] { ' ' });
            }
            else
            {
                return;
            }

            epc.ShowDialog();
            if (epc.Epc != null)
            {
                if (GetTarget() == null)
                {
                    MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UInt16 pc;
                ByteBuilder bb = new ByteBuilder();

                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP                
                bb.Append((UInt16)GetTarget().Length); // UL
                bb.Append(GetTarget()); // UII
                bb.Append(1); // MB
                bb.Append(0); // SA
                bb.Append(1); // SA
                bb.Append(0); // DL
                bb.Append((byte)((epc.Epc.Length + 2) / 2)); // DL
                pc = (UInt16)((m_oTagMemoryEpc[2] << 8) | m_oTagMemoryEpc[3]);
                pc = (UInt16)((pc & 0x07FF) | ((epc.Epc.Length / 2) << 11));
                bb.Append((UInt16)pc);  // PC
                bb.Append(epc.Epc); // DT

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }
                else
                {

                    this.listViewEPC.Items.Clear();

                    byte[] param = new byte[5];
                    param[0] = 0x02; // type C
                    param[1] = 1; // MTNU
                    param[2] = 1; // MTIME
                    param[3] = 0; // cycle
                    param[4] = 0; // cycle

                    //if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STRT_AUTO_READ_EX, param))) { }                    
                }
            }
        }

        private void TagMemoryInfoTid(System.Windows.Forms.ListViewItem lvTagInfo)
        {
            if ((m_oTagMemoryTid.Length >= 3) &&
                (m_oTagMemoryTid[0] == 0xE0))
            {
                FormTagInfoTid7816 tid = new FormTagInfoTid7816();

                byte[] arrayAc = new byte[1];
                byte[] arrayMfgCode = new byte[1];
                byte[] arraySn = new byte[m_oTagMemoryTid.Length - 2];
                Array.Copy(m_oTagMemoryTid, 0, arrayAc, 0, arrayAc.Length);
                Array.Copy(m_oTagMemoryTid, 1, arrayMfgCode, 0, arrayMfgCode.Length);
                Array.Copy(m_oTagMemoryTid, 2, arraySn, 0, arraySn.Length);
                tid.TextBoxAc.Text = StringHelper.ArgByteToStringByte(arrayAc);
                tid.TextBoxMfgCode.Text = StringHelper.ArgByteToStringByte(arrayMfgCode);
                tid.TextBoxSn.Text = StringHelper.ArgByteToStringByte(arraySn);
                tid.SetMfg();

                tid.ShowDialog();
            }
            else if ((m_oTagMemoryTid.Length >= 4) &&
                     (m_oTagMemoryTid[0] == 0xE2))
            {
                FormTagInfoTidEpc tid = new FormTagInfoTidEpc();

                tid.TextBoxAc.Text = m_oTagMemoryTid[0].ToString("X02");
                tid.TextBoxXtid.Text = ((byte)(m_oTagMemoryTid[1] & 0x80) >> 7).ToString("X01");
                tid.TextBoxMdidCode.Text = ((UInt16)(((UInt16)(m_oTagMemoryTid[1] & 0x7F) << 4) | ((UInt16)(m_oTagMemoryTid[2] & 0xF0) >> 4))).ToString("X03");
                tid.TextBoxModelNumberCode.Text = ((UInt16)(((UInt16)(m_oTagMemoryTid[2] & 0x0F) << 8) | ((UInt16)m_oTagMemoryTid[3]))).ToString("X03");
                tid.SetMdidModel();

                if (tid.TextBoxXtid.Text == "1" && m_oTagMemoryTid.Length > 25)
                {
                    tid.TextBoxXtidHeader.Text = m_oTagMemoryTid[4].ToString("0X02") + " " + m_oTagMemoryTid[5].ToString("0X02");

                    tid.TextBoxSn.Text = m_oTagMemoryTid[6].ToString("0X02") + " "
                                         + m_oTagMemoryTid[7].ToString("0X02") + " "
                                         + m_oTagMemoryTid[8].ToString("0X02") + " "
                                         + m_oTagMemoryTid[9].ToString("0X02") + " "
                                         + m_oTagMemoryTid[10].ToString("0X02") + " "
                                         + m_oTagMemoryTid[11].ToString("0X02");

                    tid.TextBoxOptionalCmd.Text = m_oTagMemoryTid[12].ToString("0X02") + " "
                                                + m_oTagMemoryTid[13].ToString("0X02");

                    tid.TextBoxBlockWrtErase.Text = m_oTagMemoryTid[14].ToString("0X02") + " "
                                                + m_oTagMemoryTid[15].ToString("0X02") + " "
                                                + m_oTagMemoryTid[16].ToString("0X02") + " "
                                                + m_oTagMemoryTid[17].ToString("0X02") + " "
                                                + m_oTagMemoryTid[18].ToString("0X02") + " "
                                                + m_oTagMemoryTid[19].ToString("0X02") + " "
                                                + m_oTagMemoryTid[20].ToString("0X02") + " "
                                                + m_oTagMemoryTid[21].ToString("0X02");
                    tid.TextBoxBlockPermalock.Text = m_oTagMemoryTid[22].ToString("0X02") + " "
                                                + m_oTagMemoryTid[23].ToString("0X02") + " "
                                                + m_oTagMemoryTid[24].ToString("0X02") + " "
                                                + m_oTagMemoryTid[25].ToString("0X02");
                }
                tid.ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void TagMemoryInfoModifyUser(System.Windows.Forms.ListViewItem lvTagInfo)
        {
            FormTagInfoUser user = new FormTagInfoUser();

            user.LabelAddress.Text = (lvTagInfo.SubItems[1].Text);
            user.TextBoxUserRd.Text = (lvTagInfo.SubItems[2].Text).TrimEnd(new char[] { ' ' });
            user.TextBoxUserWrt.Text = (lvTagInfo.SubItems[2].Text).TrimEnd(new char[] { ' ' });

            if (GetTarget() == null)
            {
                MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.ShowDialog();

            if (user.UserData != null)
            {
                ByteBuilder bb = new ByteBuilder();

                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append(00);// AP
                bb.Append((UInt16)GetTarget().Length); // UL
                bb.Append(GetTarget()); // UII
                bb.Append(3); // MB
                bb.Append(user.UserDataAddress[0]); // SA
                bb.Append(user.UserDataAddress[1]); // SA
                bb.Append(0); // DL
                bb.Append((byte)(user.UserData.Length / 2)); // DL                    
                bb.Append(user.UserData); // DT

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_WRIT_C_DT, bb.GetByteArray()))) { }
                else
                {
                    //viewTagMemoryToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            try
            {
                //string Temp = this.textBox_SendMessage.Text;

                //Temp = Temp.Trim();

                //string[] packet = Temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                //byte[] send = new byte[packet.Length];

                //for (int i = 0; i < packet.Length; i++)
                //    send[i] = Convert.ToByte(packet[i], 16);

                //if (!RcpProtocol.Instance.SendBytePkt(send)) return;
            }
            catch
            {
            }
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxRCPDecoder.Clear();
        }

        //private void Lockbit_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckBox[] checkBoxArray = new CheckBox[20];
        //    StringBuilder sb = new StringBuilder();            

        //    for (int i = 19; i >= 0; i--)
        //    {
        //        checkBoxArray[i] = (CheckBox)groupBoxLock.Controls["checkbox" + i.ToString()];

        //        if (checkBoxArray[i].Checked)
        //        {
        //            sb.Append("1");
        //        }
        //        else
        //        {
        //            sb.Append("0");
        //        }

        //        if (i == 10)
        //        {
        //            sb.Append("    ");
        //        }
        //        else if ((i % 2 == 0) && (i != 0))
        //        {
        //            sb.Append(" ");
        //        }
        //    }

        //    textBoxLockData.Text = sb.ToString();
        //}

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewEPC.Items.Clear();
            this.lbTagCount.Text = "0";

            labelSelectedTag.Visible = false;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_SEL_PARM, BuildSelectRcpPacket(null)))) { return; }
        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog openScript = new OpenFileDialog();
            string ScriptPath = Directory.GetCurrentDirectory() + "\\Script";


            openScript.Title = "Open Script";
            openScript.InitialDirectory = ScriptPath;
            openScript.Filter = "RTF File(*.rtf)|*.rtf";

            if (openScript.ShowDialog() == DialogResult.OK)
            {
                SelectedScript = openScript.FileName;
            }

            try
            {
                RichTextBox rtBox = new RichTextBox();
                string rtfText = System.IO.File.ReadAllText(SelectedScript);
                rtBox.Rtf = rtfText;

                string ScriptContents = rtBox.Text;
                Thread thr = new Thread(threadParseScript);
                thr.Start();
            }
            catch
            {

            }
        }

        private void threadParseScript()
        {
            RichTextBox rtBox = new RichTextBox();
            string rtfText = System.IO.File.ReadAllText(SelectedScript);
            rtBox.Rtf = rtfText;

            string ScriptContents = rtBox.Text;
            string[] sa;
            sa = ScriptContents.Split('\n');

            for (int i = 0; i < sa.Length; i++)
            {
                sa[i] = sa[i].ToLower();
                ScriptParser sp = new ScriptParser(sa[i]);
                sp.ParseScript();
            }
        }

        private void formScript()
        {
            FormScriptEditor formSE = new FormScriptEditor();
            formSE.ShowDialog();
        }

        private void scriptnEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread threadSE = new Thread(formScript);
            threadSE.SetApartmentState(ApartmentState.STA);
            threadSE.Start();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.tabControlDetails.Enabled = true;
            PortOpenProcess();
        }

        private void PortOpenProcess()
        {
            m_bAlive = false;

            try
            {
                if (RcpProtocol.Instance.Open())
                {
                    DisplayMsgString("MSG>COM port opened..\r\n");

                    //this.tabControl2.Enabled = true;

                    this.openToolStripMenuItem.Enabled = false;
                    this.closeToolStripMenuItem.Enabled = true;
                    this.portSettingsToolStripMenuItem.Enabled = false;

                    this.toolStripBtnConnect.Enabled = false;
                    this.toolStripBtnDisconnect.Enabled = true;
                    this.toolStripBtnPort.Enabled = false;

                    this.tsStatusPortOpen.Text = "OPEN";

                    tsStatusPort.Text = RcpProtocol.Instance.mSioConfigPort();



                    this.timerAutoConnect.Start();





                    //循环调用开始


                    //this.timerProgressCircle.Start();





                    GetReaderInfo();
                    //RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null));
                }
                else
                {
                    this.timerAutoConnect.Stop();

                    if (RcpProtocol.Instance.IsOpened() == false)
                    {
                        MessageBox.Show("Connection Fail\r\n Please Connect PC to RED DK",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    }

                    this.openToolStripMenuItem.Enabled = true;
                    this.closeToolStripMenuItem.Enabled = false;
                    this.portSettingsToolStripMenuItem.Enabled = true;

                    this.toolStripBtnConnect.Enabled = true;
                    this.toolStripBtnDisconnect.Enabled = false;
                    this.toolStripBtnPort.Enabled = true;

                    this.tsStatusPortOpen.Text = "CLOSE";
                }

                //this.btnControlPanel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetReaderInfo()
        {
            if (SyncThread == null || SyncThread.IsAlive == false)
            {
                SyncThread = new Thread(new ThreadStart(ThreadReadInfo));
                SyncThread.Start();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //this.tabControl2.Enabled = false;

                RcpProtocol.Instance.Close();
                DisplayMsgString("MSG>COM port closed..\r\n");
                m_bAlive = false;

                this.openToolStripMenuItem.Enabled = true;
                this.closeToolStripMenuItem.Enabled = false;
                this.portSettingsToolStripMenuItem.Enabled = true;

                this.toolStripBtnConnect.Enabled = true;
                this.toolStripBtnDisconnect.Enabled = false;
                this.toolStripBtnPort.Enabled = true;

                //this.tabControlDetails.Enabled = false;

                #region Button Disable Region

                //ucHwControl1.buttonRegionSet.Enabled = false;
                //ucHwControl1.buttonSetCh.Enabled = false;
                //ucHwControl1.buttonSetTxPwr.Enabled = false;
                //ucHwControl1.buttonSetModulationType.Enabled = false;
                //ucHwControl1.buttonFhLbt.Enabled = false;

                #endregion

                this.timerProgressCircle.Stop();
                this.progressCircle.Visible = false;

                if (sender != null)
                {
                    this.timerAutoConnect.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tsStatusPortOpen.Text = RcpProtocol.Instance.strConnectionStatus();
            tsStatusInfo.Text = "  Status..";
        }

        private void portSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RcpProtocol.Instance.ShowFormConfig();

            tsStatusPortOpen.Text = RcpProtocol.Instance.strConnectionStatus();
            tsStatusPort.Text = RcpProtocol.Instance.mSioConfigPort();
        }

        private void resetModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset the module, Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
            }
            else
            {

            }
        }

        private void scriptEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread threadSE = new Thread(formScript);
            threadSE.SetApartmentState(ApartmentState.STA);
            threadSE.Start();
        }

        private void firmwareDownloaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fd.ShowDialog();
        }

        private void logEnableToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!logEnableToolStripMenuItem2.Checked)
            {
                if (saveFileDialogLog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    logEnableToolStripMenuItem2.Checked = true;
            }
            else
            {
                Logger.Instance.LogClose();

                logEnableToolStripMenuItem2.Checked = false;
            }
        }

        private void saveFileDialogLog_FileOk(object sender, CancelEventArgs e)
        {
            Logger.Instance.LogOpen(saveFileDialogLog.FileName);
        }

        private void moduleInforCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogReport.ShowDialog();
        }

        //private void buttonBroadcastSync_Click(object sender, EventArgs e)
        //{
        //    if (GetTarget() == null)
        //    {
        //        MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    UInt16 uUiiLen = (UInt16)GetTarget().Length;

        //    if (textBoxEmAccessPw.Text.Length == 0) return;
        //    byte[] ap = StringHelper.ArgStringHexToByte(textBoxEmAccessPw.Text);

        //    int current = (int)(DateTime.UtcNow.Ticks / 10000000);

        //    this.labelUTCTime.Text = DateTime.UtcNow.ToString() + ", (0x" + Convert.ToString(current, 16) + ")";

        //    byte[] UTCTime = new byte[4];
        //    UTCTime[0] = (byte)((current >> 24) & 0xff);
        //    UTCTime[1] = (byte)((current >> 16) & 0xff);
        //    UTCTime[2] = (byte)((current >> 8) & 0xff);
        //    UTCTime[3] = (byte)(current & 0xff);

        //    ByteBuilder bb = new ByteBuilder();

        //    try
        //    {

        //        bb.Append(Convert.ToByte(this.textBoxTS.Text, 16));        // TS
        //        bb.Append(ap);          // AP
        //        bb.Append(Convert.ToByte(this.textBoxRM.Text, 16));        // RM
        //        bb.Append(uUiiLen);     // UL
        //        bb.Append(GetTarget()); // UII
        //        bb.Append(0x00);        // sz
        //        bb.Append(0x28);        // sz
        //        bb.Append(0xD1);        // gc
        //        bb.Append(UTCTime);     // gc

        //        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_EM_TRANSPORT, bb.GetByteArray()))) { }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return;
        //    }
        //}

        //private void buttonGetSensorData_Click(object sender, EventArgs e)
        //{
        //    if (GetTarget() == null)
        //    {
        //        MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    UInt16 uUiiLen = (UInt16)GetTarget().Length;

        //    if (textBoxEmAccessPw.Text.Length == 0) return;
        //    byte[] ap = StringHelper.ArgStringHexToByte(textBoxEmAccessPw.Text);

        //    byte SendUID = Convert.ToByte(this.comboBoxSendUID.SelectedIndex);
        //    byte NewSample = Convert.ToByte(this.comboBoxNewSample.SelectedIndex);

        //    ByteBuilder bb = new ByteBuilder();

        //    try
        //    {
        //        string temp = "E001";

        //        byte temp_param = (byte)((SendUID << 7) + (NewSample << 6));

        //        string tempA = Convert.ToString(temp_param, 16);

        //        if (tempA.Length == 1) temp = temp + "0" + Convert.ToString(temp_param, 16);
        //        else temp += Convert.ToString(temp_param, 16);

        //        byte[] gc = StringHelper.ArgStringHexToByte(temp);
        //        UInt16 sz = (UInt16)(gc.Length << 3);
        //        sz -= 6;

        //        bb.Append(Convert.ToByte(this.textBoxTS.Text, 16));        // TS
        //        bb.Append(ap);          // AP
        //        bb.Append(Convert.ToByte(this.textBoxRM.Text, 16));        // RM
        //        bb.Append(uUiiLen); // UL
        //        bb.Append(GetTarget()); // UII
        //        bb.Append(sz);
        //        bb.Append(gc);

        //        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_EM_TRANSPORT, bb.GetByteArray()))) { }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return;
        //    }
        //}

        //private void buttonSendSPI_Click(object sender, EventArgs e)
        //{
        //    if (GetTarget() == null)
        //    {
        //        MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    UInt16 uUiiLen = (UInt16)GetTarget().Length;

        //    if (textBoxEmAccessPw.Text.Length == 0) return;
        //    byte[] ap = StringHelper.ArgStringHexToByte(textBoxEmAccessPw.Text);

        //    byte ResponseSize = Convert.ToByte(this.textBoxSPIResponseSize.Text);
        //    byte SCLK = Convert.ToByte(this.comboBoxSPISCLK.SelectedIndex);
        //    byte DelayToInitialSCLK = Convert.ToByte(this.comboBoxSPIDelayTimeToInitialSCLK.SelectedIndex);
        //    byte DelayBetweenBytes = Convert.ToByte(this.comboBoxSPIDelayTimeBetweenBytes.SelectedIndex);

        //    ByteBuilder bb = new ByteBuilder();

        //    try
        //    {

        //        string temp = "E002";

        //        int temp_command_length = (UInt16)(StringHelper.ArgStringHexToByte(this.textBoxSPICommand.Text)).Length;
        //        byte CommandSize = Convert.ToByte(temp_command_length & 0x07);

        //        byte temp_param = (byte)((CommandSize << 5) + (ResponseSize << 2) + SCLK);
        //        string tempA = Convert.ToString(temp_param, 16);

        //        if (tempA.Length == 1) temp = temp + "0" + Convert.ToString(temp_param, 16);
        //        else temp += Convert.ToString(temp_param, 16);
        //        temp_param = (byte)((DelayToInitialSCLK << 6) + (DelayBetweenBytes << 4));

        //        byte[] temp_command = StringHelper.ArgStringHexToByte(this.textBoxSPICommand.Text);

        //        for (int i = 0; i <= temp_command.Length; i++)
        //        {
        //            if (i != temp_command.Length) temp_param += (byte)(temp_command[i] >> 4);

        //            tempA = Convert.ToString(temp_param, 16);

        //            if (tempA.Length == 1) temp = temp + "0" + Convert.ToString(temp_param, 16);
        //            else temp += Convert.ToString(temp_param, 16);

        //            if (i != temp_command.Length)
        //            {
        //                temp_param = (byte)(temp_command[i] << 4);
        //            }
        //        }

        //        byte[] gc = StringHelper.ArgStringHexToByte(temp);
        //        UInt16 sz = (UInt16)(gc.Length << 3);
        //        sz -= 4;

        //        bb.Append(Convert.ToByte(this.textBoxTS.Text, 16));        // TS
        //        bb.Append(ap);          // AP
        //        bb.Append(Convert.ToByte(this.textBoxRM.Text, 16));        // RM
        //        bb.Append(uUiiLen); // UL
        //        bb.Append(GetTarget()); // UII
        //        bb.Append(sz);
        //        bb.Append(gc);

        //        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_EM_TRANSPORT, bb.GetByteArray()))) { }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return;
        //    }
        //}

        //private void buttonResetAlarms_Click(object sender, EventArgs e)
        //{
        //    if (GetTarget() == null)
        //    {
        //        MessageBox.Show("Select Target Tag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    UInt16 uUiiLen = (UInt16)GetTarget().Length;

        //    if (textBoxEmAccessPw.Text.Length == 0) return;
        //    byte[] ap = StringHelper.ArgStringHexToByte(textBoxEmAccessPw.Text);

        //    ByteBuilder bb = new ByteBuilder();

        //    try
        //    {
        //        string temp = "E004";
        //        temp += "50";

        //        byte[] gc = StringHelper.ArgStringHexToByte(temp);
        //        UInt16 sz = (UInt16)(gc.Length << 3);
        //        sz -= 4;

        //        bb.Append(Convert.ToByte(this.textBoxTS.Text, 16));        // TS
        //        bb.Append(ap);          // AP
        //        bb.Append(Convert.ToByte(this.textBoxRM.Text, 16));        // RM
        //        bb.Append(uUiiLen); // UL
        //        bb.Append(GetTarget()); // UII
        //        bb.Append(sz);
        //        bb.Append(gc);

        //        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_EM_TRANSPORT, bb.GetByteArray()))) { }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return;
        //    }
        //}

        private int RefInductorVal;

        private void leakageRSSIPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (cwThread == null || cwThread.IsAlive == false)
            //{
            //    cwThread = new Thread(new ThreadStart(cwOnOff));
            //    cwThread.Start();
            //}

            //ChannelCnt = ucHwControl1.GetcbchLength;

            //int[] temp = new int[ucHwControl1.cbCh.Items.Count];

            //for (int i = 0; i < ucHwControl1.cbCh.Items.Count; i++)
            //{
            //    temp[i] = int.Parse(ucHwControl1.cbCh.Items[i].ToString());
            //}

            //TxLeakageRSSIPlot.SetDefaultMeaurementParameter(temp);            
            //TxLeakageRSSIPlot.ShowDialog();
        }

        private void cwOnOff()
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_LEAK_CAL_MODE, new byte[] { 0x02 }))) { }
            this.WaitForReceived();

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0xFF }))) { }
            this.WaitForReceived();

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0x00 }))) { }
            this.WaitForReceived();

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_LEAK_CAL_MODE, new byte[] { 0x01 }))) { }
            this.WaitForReceived();
        }

        private void readRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReadRangeCalculator formRRC = new FormReadRangeCalculator();
            formRRC.ShowDialog();
        }

        /// <summary>
        /// 读取长内存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReadTagMemoryEx_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            UInt16 uUiiLen;
            UInt16 uStartAdd;
            UInt16 uLength;
            byte[] ap;
            byte uMem;

            try
            {
                uUiiLen = (UInt16)(StringHelper.ArgStringHexToByte(target)).Length;
                uStartAdd = UInt16.Parse(textBoxRwStartAdd.Text);
                uLength = UInt16.Parse(textBoxRwLength.Text);
                uMem = (byte)cbTagRwTarMem.SelectedIndex;
                ap = StringHelper.ArgStringHexToByte(textBoxRwAccessPw.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ByteBuilder bb = new ByteBuilder();
            bb.Append(ap); // AP
            bb.Append(uUiiLen); // UL
            if (uUiiLen > 0)
            {
                bb.Append(StringHelper.ArgStringHexToByte(target)); // UII
            }
            bb.Append(uMem); // MB
            bb.Append(uStartAdd); // SA
            bb.Append(uLength); // DL

            m_oReceivedTagMemoryData = null;

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_READ_C_DT_EX, bb.GetByteArray()))) { }
        }

        private Thread lvEPCupdateThread;
        private Queue<ListViewItem> lvEPCq = new Queue<ListViewItem>();
        private bool lvEPCupdateThreadFlag = false;

        private void lvEPCupdate()
        {
            System.Threading.Thread.Sleep(500);

            //if (soundThread == null || soundThread.IsAlive == false)
            //{
            //    soundThread = new Thread(new ThreadStart(PlaySound));
            //    soundThread.Start();
            //}

            while (lvEPCupdateThreadFlag == true)
            {
                lvEPCupdateDetail();
            }

            while (lvEPCq.Count > 0)
            {
                lvEPCupdateDetail();
            }

            double tmpCount = count100ms;
            tmpCount /= 10;

            if (!this.InvokeRequired)
            {
                int totalCnt = 0;

                for (int i = 0; i < listViewEPC.Items.Count; i++)
                {
                    totalCnt += int.Parse(listViewEPC.Items[i].SubItems[3].Text);
                }

                RCPDecoderTxtDisplay("Acknowledged Tag Count = " + lbTagCount.Text + "\r\n");
                RCPDecoderTxtDisplay("Total Tag Count = " + totalCnt + "\r\n");
                RCPDecoderTxtDisplay("Total Read Time = " + tmpCount + " [sec]\r\n");
                RCPDecoderTxtDisplay("Read Rate = " + totalCnt / tmpCount + " [tag/sec]\r\n\r\n");
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    int totalCnt = 0;

                    for (int i = 0; i < listViewEPC.Items.Count; i++)
                    {
                        totalCnt += int.Parse(listViewEPC.Items[i].SubItems[3].Text);
                    }

                    RCPDecoderTxtDisplay("Acknowledged Tag Count = " + lbTagCount.Text + "\r\n");
                    RCPDecoderTxtDisplay("Total Tag Count = " + totalCnt + "\r\n");
                    RCPDecoderTxtDisplay("Total Read Time = " + tmpCount + " [sec]\r\n");
                    RCPDecoderTxtDisplay("Read Rate = " + Math.Round(totalCnt / tmpCount, 1) + " [tag/sec]\r\n\r\n");
                }));
            }
        }

        private void lvEPCupdateDetail()
        {
            ListViewItem lvItem;
            int lvIdx = -1;

            if (lvEPCq.Count > 0)
            {
                int tps = 500 / lvEPCq.Count;

                if (!this.InvokeRequired)
                {
                    lvItem = lvEPCq.Dequeue();

                    for (int i = 0; i < this.listViewEPC.Items.Count; i++)
                    {
                        if (this.listViewEPC.Items[i].SubItems[2].Text == lvItem.SubItems[2].Text)
                        {
                            lvIdx = i;
                            listViewEPC.Items[i].SubItems[3].Text = (int.Parse(listViewEPC.Items[i].SubItems[3].Text) + 1).ToString();
                            listViewEPC.Items[i].SubItems[4].Text = lvItem.SubItems[4].Text;
                        }
                    }

                    if (lvIdx == -1)
                    {
                        lbTagCount.Text = (++nTagCnt).ToString();
                        lvItem.SubItems[0].Text = nTagCnt.ToString();
                        listViewEPC.Items.Add(lvItem);
                    }
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        lvItem = lvEPCq.Dequeue();

                        for (int i = 0; i < this.listViewEPC.Items.Count; i++)
                        {
                            if (this.listViewEPC.Items[i].SubItems[2].Text == lvItem.SubItems[2].Text)
                            {
                                lvIdx = i;
                                listViewEPC.Items[i].SubItems[3].Text = (int.Parse(listViewEPC.Items[i].SubItems[3].Text) + 1).ToString();
                                listViewEPC.Items[i].SubItems[4].Text = lvItem.SubItems[4].Text;
                            }
                        }

                        if (lvIdx == -1)
                        {
                            lbTagCount.Text = (++nTagCnt).ToString();
                            lvItem.SubItems[0].Text = nTagCnt.ToString();
                            listViewEPC.Items.Add(lvItem);
                        }
                    }));
                }
                System.Threading.Thread.Sleep(tps);
            }
        }

        private Thread soundThread = null;
        SoundPlayer player = new SoundPlayer("ding.wav");
        public bool soundOn = true;

        private void PlaySound()
        {
            while (lvEPCupdateThread.IsAlive)
            {
                if (soundOn && lvEPCq.Count > 0)
                {
                    player.Play();
                }
                else
                {

                }

                int interval = 200 - lvEPCq.Count;

                if (interval < 150)
                {
                    interval = 150;
                }
                else if (interval > 200)
                {
                    interval = 200;
                }

                System.Threading.Thread.Sleep(interval);
            }
        }

        private void buttonReadOption_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStripReadButton.Show(ptLowerLeft);
        }

        private void withRSSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            withTIDToolStripMenuItem.Checked = false;

            if (withRSSIToolStripMenuItem.Checked == true)
            {
                RCPDecoderTxtDisplay("Tag RSSI Disabled" + "\r\n" + "\r\n");
                withRSSIToolStripMenuItem.Checked = false;
            }
            else
            {
                RCPDecoderTxtDisplay("Tag RSSI Enabled" + "\r\n" + "\r\n");
                withRSSIToolStripMenuItem.Checked = true;

                listViewEPC.Columns[2].Width = 400;
                listViewEPC.Columns[4].Width = 70;

                listViewEPC.Columns[4].Text = "Tag RSSI";
            }
        }

        private void withTIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            withRSSIToolStripMenuItem.Checked = false;

            if (withTIDToolStripMenuItem.Checked == true)
            {
                RCPDecoderTxtDisplay("TID Report Disabled" + "\r\n" + "\r\n");

                withTIDToolStripMenuItem.Checked = false;

                listViewEPC.Columns[2].Width = 400;
                listViewEPC.Columns[4].Width = 70;

                listViewEPC.Columns[4].Text = "Tag RSSI";
            }
            else
            {
                RCPDecoderTxtDisplay("TID Report Enabled" + "\r\n" + "\r\n");
                withTIDToolStripMenuItem.Checked = true;

                listViewEPC.Columns[2].Width = 270;
                listViewEPC.Columns[4].Width = 210;

                listViewEPC.Columns[4].Text = "TID";
            }
        }

        private void secondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secondToolStripMenuItem.Checked == true)
            {
                RCPDecoderTxtDisplay("Conditional Read Disabled(Time)" + "\r\n" + "\r\n");

                textBox_MTIME.Text = "0";
                textBox_RepeatCycle.Text = "0";

                secondToolStripMenuItem.Checked = false;
                ReadConditionItemTime();
            }
            else
            {
                RCPDecoderTxtDisplay("Conditional Read Enabled(Time)" + "\r\n" + "\r\n");

                textBox_RepeatCycle.Text = "0";

                secondToolStripMenuItem.Checked = true;
                cycleToolStripMenuItem.Checked = false;
                ReadConditionItemTime();
            }
        }

        private void cycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cycleToolStripMenuItem.Checked == true)
            {
                RCPDecoderTxtDisplay("Conditional Read Disabled(Cycle)" + "\r\n" + "\r\n");

                textBox_MTIME.Text = "0";
                textBox_RepeatCycle.Text = "0";

                cycleToolStripMenuItem.Checked = false;
                ReadConditionItemCycle();
            }
            else
            {
                RCPDecoderTxtDisplay("Conditional Read Enabled(Cycle)" + "\r\n" + "\r\n");

                textBox_MTIME.Text = "0";

                cycleToolStripMenuItem.Checked = true;
                secondToolStripMenuItem.Checked = false;
                ReadConditionItemCycle();
            }

        }

        private void contextMenuStripReadButton_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        private void ReadConditionItemTime()
        {
            textBox_RepeatCycle.Text = "0";

            labelReadfor.Visible = false;

            labelCycle.Visible = false;
            textBox_RepeatCycle.Visible = false;

            if (secondToolStripMenuItem.Checked == true)
            {
                labelReadfor.Visible = true;

                labelSeconds.Visible = true;
                textBox_MTIME.Visible = true;
            }
            else
            {
                labelReadfor.Visible = false;

                labelSeconds.Visible = false;
                textBox_MTIME.Visible = false;
            }
        }

        private void ReadConditionItemCycle()
        {
            textBox_MTIME.Text = "0";

            labelReadfor.Visible = false;

            labelSeconds.Visible = false;
            textBox_MTIME.Visible = false;

            if (cycleToolStripMenuItem.Checked == true)
            {
                labelReadfor.Visible = true;

                labelCycle.Visible = true;
                textBox_RepeatCycle.Visible = true;
            }
            else
            {
                labelReadfor.Visible = false;

                labelCycle.Visible = false;
                textBox_RepeatCycle.Visible = false;
            }
        }

        private void textBox_MTIME_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(textBox_MTIME.Text);
                if (i >= 255)
                {
                    textBox_MTIME.Text = "255";
                }
                else if (i < 0)
                {
                    textBox_MTIME.Text = "0";
                }
            }
            catch
            {

            }
        }

        private void textBox_RepeatCycle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(textBox_RepeatCycle.Text);
                if (i >= 65535)
                {
                    textBox_RepeatCycle.Text = "65535";
                }
                else if (i < 0)
                {
                    textBox_RepeatCycle.Text = "0";
                }
            }
            catch
            {

            }
        }

        private void timerAutoConnect_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed)
                return;

            if (m_bUpdateLog)
            {
                //listViewMsg.EnsureVisible(listViewMsg.Items.Count - 1);
                m_bUpdateLog = false;
            }

            try
            {
                if (!RcpProtocol.Instance.IsOpened() && RcpProtocol.Instance.IsOpenable())
                {
                    openToolStripMenuItem_Click(null, null);
                }
                else if (tsStatusPortOpen.Text != RcpProtocol.Instance.strConnectionStatus())
                {
                    DspCloseMsg(this, null);
                }
            }
            catch
            {
            }
        }

        int count100ms = 0;

        private void ReadRateTimer_Tick(object sender, EventArgs e)
        {
            count100ms++;
        }


        /// <summary>
        /// 复制tagID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyTagIDToDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0) return;

            string target = listViewEPC.SelectedItems[0].SubItems[2].Text;

            textBoxRwData.Text = target;
            txt_EPCCode.Text = target;

            //this.tabControlDetails.SelectedTab = this.tabMemoryAccess;

            //if (btnControlPanel.Text == "start")
            //{
            //    btnControlPanel.PerformClick();
            //    btnControlPanel.Text = "end";
            //}
        }

        private void clearTagListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewEPC.Items.Clear();
        }

        private int leakinfoCnt = 0;

        private void buttonSetTestInfo_Click(object sender, EventArgs e)
        {
            //leakTable = true;
            //leakinfoCnt = 0;

            //string[] sa = new string[ucHwControl1.cbCh.Items.Count];           
            ////listViewLeak.Items.Clear();

            //for (int i = 0; i < ucHwControl1.cbCh.Items.Count; i++)
            //{
            //    sa[i] = ucHwControl1.cbCh.Items[i].ToString();

            //    ListViewItem lvit = new ListViewItem("0");
            //    lvit.SubItems[0].Text = sa[i];
            //    lvit.SubItems.Add("");

            //    //listViewLeak.Items.Add(lvit);
            //}                        
        }

        private void leakTableUpdate(byte[] Data)
        {
            byte val = Data[8];
            byte idx = (byte)(Data[10] - 1);

            try
            {
                //listViewLeak.Items[idx].SubItems[1].Text = val.ToString();

                //leakinfoCnt++;                

                //if (leakinfoCnt > listViewLeak.Items.Count)
                //{
                //    if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STOP_AUTO_READ_EX, null))) { }

                //    MessageBox.Show("Complete");
                //}
            }
            catch
            {

            }
        }

        private void buttonToCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();

            svd.Title = "Save";
            svd.Filter = "csv files (*.csv)|*.csv";

            string path = string.Empty;
            string line = string.Empty;

            if (svd.ShowDialog() == DialogResult.OK)
            {
                //if (svd.FileName != string.Empty)
                //{
                //    path = svd.FileName;
                //}

                //StreamWriter sw = new StreamWriter(new FileStream(path + ".csv", FileMode.CreateNew));

                //line = "Channel" + "," + "Value";

                //sw.WriteLine(line);

                //for (int i = 0; i < listViewLeak.Items.Count; i++)
                //{
                //    line = listViewLeak.Items[i].SubItems[0].Text + "," + listViewLeak.Items[i].SubItems[1].Text;
                //    sw.WriteLine(line);
                //}

                //sw.Close();

                //MessageBox.Show("success");
            }
        }

        private void timerProgressCircle_Tick(object sender, EventArgs e)
        {
            if (!InvokeRequired)
            {
                if (buttonReadMultiple.Text == " Stop ")
                {
                    this.progressCircle.Visible = true;
                }
                else
                {
                    this.progressCircle.Visible = false;
                }
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    if (buttonReadMultiple.Text == " Stop ")
                    {
                        this.progressCircle.Visible = true;
                    }
                    else
                    {
                        this.progressCircle.Visible = false;
                    }
                }));
            }
        }

        private void userControlLeakGuidance_SendEvent(object obj)
        {
            buttonReadMultiple.Text = " Start ";
        }

        private void userControlLeakGuidance_SendEventbutton(bool b)
        {
            if (b)
            {
                buttonReadMultiple.Enabled = true;
            }
            else
            {
                buttonReadMultiple.Enabled = false;
            }
        }

        #region Hidden Function

        private void offsetPowerTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.ucHwControl1.VisiblePowerOffset_Table();
        }

        private void analogTPEnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.ucHwControl1.VisiableTPEnable();

        }
        //private void decodeSerialToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.ucRegistry1.DecodeSerial();
        //}

        #endregion

        private void toggleLeakInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //userControlLeakGuidance.toggleVisibleLeakInfo();
        }

        private void sensorTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fST = new FormSensorTag();

            _fST.ShowDialog();
        }
        /// <summary>
        /// 列表项点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewEPC_Click(object sender, EventArgs e)
        {
            copyTagIDToDataToolStripMenuItem_Click(null, null);
            ReadTagMemory(2);
        }
        private void textBox1_script_temp_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    string s;

            //    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(textBox1_script_temp.Text));
            //    TextReader tr = new StreamReader(ms, Encoding.ASCII);

            //    s = tr.ReadToEnd();
            //    s.Trim();
            //    s = s.Replace(" ", "");
            //    s = s.ToLower();

            //    if (s[s.Length - 1] == ',')
            //    {
            //        s = s.Substring(0, s.LastIndexOf(','));
            //    }

            //    ScriptParser sp = new ScriptParser(s);

            //    try
            //    {
            //        sp.ParseScript();
            //    }
            //    catch
            //    { 
            //    }
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var tagID = txt_TagID.Text.Trim();
            var epc = txt_EPCCode.Text.Trim();
            var isbn = txt_ISBN.Text.Trim();
            if (string.IsNullOrEmpty(tagID) || string.IsNullOrEmpty(isbn))
            {
                MessageBox.Show("TagID或ISBN编号不能为空！");
                return;
            }
            var param = new object[] { tagID, epc, isbn, CpuId };
            var res = Utility.Instance.ExecuteScalarSp("usp_CheckInsertTag", param) ?? 0;
            int msgCode = int.Parse(res.ToString());
            if (msgCode == 1)
            {
                richTextBoxRCPDecoder.AppendText($"{tagID}同步成功!");
                richTextBoxRCPDecoder.ScrollToCaret();
                Clrear();
            }
            else if (msgCode == 2)
            {
                if (MessageBox.Show("TagID已存在,是否更新ISBN号？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int idxTemp = richTextBoxRCPDecoder.Text.Length;
                    richTextBoxRCPDecoder.AppendText($"记录已存在！更新标签：{tagID}对应的ISBN!");
                    richTextBoxRCPDecoder.Select(idxTemp, richTextBoxRCPDecoder.Text.Length);
                    richTextBoxRCPDecoder.SelectionColor = Color.Black;
                    Clrear();
                    var tagCount = TagCount.ToString();
                    Text = $"当前数据库标签数量:{tagCount}条。";
                }
            }
        }
        private void Clrear()
        {
            listViewEPC.Items.Clear();
            txt_EPCCode.Text = null;
            txt_ISBN.Text = null;
            txt_TagID.Text = null;
        }

        private void txt_ISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave_Click(null, null);
            }
        }
        private string TagCount
        {
            get
            {
                var res = Utility.Instance.ExecuteScalar(CommandType.Text, "select count(0) from TagInfo", null);
                return res != null ? res.ToString() : "";
            }
        }
        private  string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc =
        new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        public  string CpuId
        {
            get
            {
                if (CPUID != null) {
                    return CPUID;
                }
                //Uses first CPU identifier available in order of preference
                //Don't get all identifiers, as it is very time consuming
                string retVal = identifier("Win32_Processor", "UniqueId");
                if (retVal == "") //If no UniqueID, use ProcessorID
                {
                    retVal = identifier("Win32_Processor", "ProcessorId");
                    if (retVal == "") //If no ProcessorId, use Name
                    {
                        retVal = identifier("Win32_Processor", "Name");
                        if (retVal == "") //If no Name, use Manufacturer
                        {
                            retVal = identifier("Win32_Processor", "Manufacturer");
                        }
                        //Add clock speed for extra security
                        retVal += identifier("Win32_Processor", "MaxClockSpeed");
                    }
                }
                return retVal;
            }
        }
        /// <summary>
        /// Export Excel File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(int.Parse(TagCount) > 0))
            {
                MessageBox.Show("数据库记录为空，没有可导出的数据");
            }
            DataSet ds = Utility.Instance.ExecuteDataSet(CommandType.Text, "select TagID,ISBN,CpuID from TagInfo", null);
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                var dt = ds.Tables[0];
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "全部文件(*.*)|*.*|表格文件(*.csv)|*.csv";
                save.FilterIndex = 2;
                save.RestoreDirectory = true;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    string strPath = save.FileName.ToString();

                    if (File.Exists(strPath))
                    {
                        File.Delete(strPath);
                    }
                    StringBuilder strColu = new StringBuilder();
                    StringBuilder strValue = new StringBuilder();
                    int i = 0;
                    try
                    {
                        StreamWriter sw = new StreamWriter(new FileStream(strPath, FileMode.CreateNew), Encoding.GetEncoding("GB2312"));
                        for (i = 0; i <= dt.Columns.Count - 1; i++)
                        {
                            strColu.Append(dt.Columns[i].ColumnName);
                            strColu.Append(",");
                        }
                        strColu.Remove(strColu.Length - 1, 1);//移出掉最后一个,字符  
                        sw.WriteLine(strColu);
                        foreach (DataRow dr in dt.Rows)
                        {
                            strValue.Remove(0, strValue.Length);//移出  
                            for (i = 0; i <= dt.Columns.Count - 1; i++)
                            {
                                var val = dt.Columns[i].Caption == "ISBN" ? "\t" + dr[i].ToString() : dr[i].ToString();
                                strValue.Append(val);
                                strValue.Append(",");
                            }
                            strValue.Remove(strValue.Length - 1, 1);//移出掉最后一个,字符  
                            sw.WriteLine(strValue);
                        }
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }
    }
}