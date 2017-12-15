using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RFIDStation
{
    public partial class EmulateNfcType2Tag : Form
    {
        private int serialDevice;                   //串口设备
        public bool bOperatingSerial;
        public delegate void Delegate(object obj);

        public EmulateNfcType2Tag()
        {
            InitializeComponent();

            serialDevice = -1;
            bOperatingSerial = false;
        }

        private void clearOpResult()
        {
            this.textBoxOpEmulNfcType2TagRltSrcAddr.Text = "";
            this.textBoxOpEmulNfcType2TagRltDestAddr.Text = "";

            this.radioButtonOpEmulNfcType2TagRltOpOK.Checked = false;
            this.radioButtonOpEmulNfcType2ErrTypeOK.Checked = false;

            this.radioButtonOpEmulNfcType2TagRltOpFail.Checked = false;
            this.radioButtonOpEmulNfcType2ErrTypeCrc.Checked = false;
            this.radioButtonOpEmulNfcType2ErrTypeTag.Checked = false;
            this.radioButtonOpEmulNfcType2ErrTypeRsp.Checked = false;
            this.radioButtonOpEmulNfcType2ErrTypeRsp.Checked = false;
            //this.labelUserTimer.Text = "0ms";
        }

        private void DisplayOpResult(ref HFREADER_OPRESULT pResult)
        {
            this.textBoxOpEmulNfcType2TagRltSrcAddr.Text = pResult.srcAddr.ToString("X").PadLeft(4, '0');
            this.textBoxOpEmulNfcType2TagRltDestAddr.Text = pResult.targetAddr.ToString("X").PadLeft(4, '0');
            if (pResult.flag == 0)
            {
                this.radioButtonOpEmulNfcType2TagRltOpOK.Checked = true;
                this.radioButtonOpEmulNfcType2ErrTypeOK.Checked = true;
            }
            else
            {
                this.radioButtonOpEmulNfcType2TagRltOpFail.Checked = true;
                if (pResult.errType == 0x01)
                {
                    this.radioButtonOpEmulNfcType2ErrTypeTag.Checked = true;
                }
                else if (pResult.errType == 0x02)
                {
                    this.radioButtonOpEmulNfcType2ErrTypeCrc.Checked = true;
                }
                else if (pResult.errType == 0x03)
                {
                    this.radioButtonOpEmulNfcType2ErrTypeRsp.Checked = true;
                }
                else if (pResult.errType == 0x04)
                {
                    this.radioButtonOpEmulNfcType2ErrTypeParam.Checked = true;
                }
                else
                {
                    this.radioButtonOpEmulNfcType2ErrTypeRsp.Checked = true;
                }
            }
            //this.labelUserTimer.Text = pResult.t.ToString("D") + "ms";
        }

        public void EnableEmulNfcType2(int h)
        {
            serialDevice = h;

            this.tabControlNfcType2TagOp.Enabled = true;
        }

        public void DisableEmulNfcType2()
        {
            this.tabControlNfcType2TagOp.Enabled = false;
            serialDevice = -1;
        }

        private void AddDisplayInfo(object obj)
        {
            if (this.textBoxInf.InvokeRequired)
            {
                Delegate d = new Delegate(AddDisplayInfo);
                this.textBoxInf.Invoke(d, obj);

            }
            else
            {
                this.textBoxInf.Text = obj.ToString();
            }
        }

        public void DisplaySendInf(Byte[] pSendBuf, String cmdNmae)
        {
            String text = this.textBoxInf.Text;
            int i = 0;
            int len = pSendBuf[2] + 3;
            String s = cmdNmae;

            {
                for (i = 0; i < len; i++)
                {
                    s += pSendBuf[i].ToString("X").PadLeft(2, '0');
                    s += " ";
                }
            }
            s += "\r\n";
            AddDisplayInfo(s + text);
        }

        public void DisplayRcvInf(Byte[] pRcvBuf, String cmdNmae)
        {
            String text = this.textBoxInf.Text;
            int i = 0;
            int len = pRcvBuf[2] + 3;
            String s = cmdNmae;
            if (pRcvBuf[2] > 0)
            {
                for (i = 0; i < len; i++)
                {
                    s += pRcvBuf[i].ToString("X").PadLeft(2, '0');
                    s += " ";
                }
            }

            s += "\r\n\r\n";
            AddDisplayInfo(s + text);
        }

        public int GetHexInput(String s, Byte[] buffer, int num)
        {
            int i = 0;
            if (s.Length != 2 * num)
            {
                MessageBox.Show("数据长度错误");
                return -1;
            }
            for (i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
                {
                    MessageBox.Show("请以16进制格式输入数据，例如：00 01 FF");
                    return -1;
                }
            }
            for (i = 0; i < num; i++)
            {
                buffer[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
            }

            return num;
        }

        public int GetHexInput(String s, Byte[] buffer)
        {
            int i = 0;
            int num = 0;
            for (i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
                {
                    MessageBox.Show("请以16进制格式输入数据，例如：00 01 FF");
                    return 0;
                }
            }
            num = s.Length / 2;
            for (i = 0; i < num; i++)
            {
                buffer[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
            }

            return num;
        }


        private bool GetDeviceAddr(ushort[] addArray)
        {
            bool b = false;
            byte[] buffer = new Byte[255];
            if (GetHexInput(textBoxEmulNfcType2SrcAddr.Text, buffer, 2) > 0)
            {
                addArray[0] = (ushort)(buffer[0] * 256 + buffer[1]);
                if (GetHexInput(textBoxEmulNfcType2DestAddr.Text, buffer, 2) > 0)
                {
                    addArray[1] = (ushort)(buffer[0] * 256 + buffer[1]);
                    b = true;
                }
            }

            return b;
        }

        private void buttonClearOpEmulNfcType2Tag_Click(object sender, EventArgs e)
        {
            clearOpResult();
        }

        private void buttonClearInfo_Click(object sender, EventArgs e)
        {
            this.textBoxInf.Text = "";
        }

        private void buttonSetUid_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            ISO14443A_UID pUid = new ISO14443A_UID();
            pUid.uid = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_MAX_UID];

            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();

            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxTagUid.Text, pUid.uid, this.textBoxTagUid.Text.Length / 2) <= 0)
            {
                return;
            }
            pUid.len = (uint)(this.textBoxTagUid.Text.Length / 2);
            pUid.type = Convert.ToUInt16(this.textBoxTagType.Text, 16);
            pUid.sak = Convert.ToByte(this.textBoxTagSak.Text, 16);


            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.emulNfcType2SetUID(serialDevice, addrArray[0], addrArray[1], ref pUid, ref pResult, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                DisplayOpResult(ref pResult);
            }
            DisplayRcvInf(rcvBuffer, "设置UID返回：");
            DisplaySendInf(sendBuffer, "设置UID：");
        }

        private void buttonGetUid_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            ISO14443A_UID pUid = new ISO14443A_UID();
            pUid.uid = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_MAX_UID];

            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();

            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxTagUid.Text, pUid.uid, this.textBoxTagUid.Text.Length / 2) <= 0)
            {
                return;
            }


            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.emulNfcType2GetUID(serialDevice, addrArray[0], addrArray[1], ref pUid, ref pResult, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                DisplayOpResult(ref pResult);

                if (pResult.flag == 0)
                {
                    int i = 0;
                    String s = "";
                    this.textBoxTagType.Text = pUid.type.ToString("X").PadLeft(4, '0');
                    this.textBoxTagSak.Text = pUid.sak.ToString("X").PadLeft(2, '0');
                    for (i = 0; i < pUid.len; i++)
                    {
                        s += pUid.uid[i].ToString("X").PadLeft(2, '0');
                    }
                    this.textBoxTagUid.Text = s;
                }

            }
            DisplayRcvInf(rcvBuffer, "获取UID返回：");
            DisplaySendInf(sendBuffer, "获取UID：");
        }

        private void buttonReadEmulNfcType2_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            ushort[] addrArray = new ushort[2];

            ISO14443A_BLOCKPARAM pBlock = new ISO14443A_BLOCKPARAM();

            pBlock.uid.uid = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_MAX_UID];
            pBlock.block = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_M1BLOCK * hfReaderDll.HFREADER_ISO14443A_M1BLOCKNUM_MAX];
            pBlock.key = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_M1_KEY];

            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            Byte[] blockNum = new Byte[1];
            Byte[] blockAddr = new Byte[1];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxREmulNfcType2Addr.Text, blockAddr, 1) <= 0)
            {
                return;
            }
            pBlock.addr = blockAddr[0];

            if (GetHexInput(this.textBoxREmulNfcType2Num.Text, blockNum, 1) <= 0)
            {
                return;
            }
            pBlock.num = blockNum[0];

            if (pBlock.num > hfReaderDll.HFREADER_ISO14443A_MOBLOCKNUM_MAX)
            {
                MessageBox.Show("读取数目超出范围，最多可以读取0x" + hfReaderDll.HFREADER_ISO14443A_MOBLOCKNUM_MAX.ToString("X").PadLeft(2, '0') + "Page");
                pBlock.num = hfReaderDll.HFREADER_ISO14443A_MOBLOCKNUM_MAX;
                this.textBoxREmulNfcType2Num.Text = hfReaderDll.HFREADER_ISO14443A_MOBLOCKNUM_MAX.ToString("X").PadLeft(2, '0');
            }

            pBlock.keyType = 0x00;

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.emulNfcType2ReadBlock(serialDevice, addrArray[0], addrArray[1], ref pBlock, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                if (pBlock.result.flag == 0)
                {
                    String s = "";
                    int j = 0;
                    int i = 0;
                    for (j = 0; j < pBlock.num; j++)
                    {
                        for (i = 0; i < hfReaderDll.HFREADER_ISO14443A_LEN_M0BLOCK; i++)
                        {
                            s += pBlock.block[j * hfReaderDll.HFREADER_ISO14443A_LEN_M0BLOCK + i].ToString("X").PadLeft(2, '0');
                        }
                        s += "\r\n";
                    }
                    this.textBoxREmulNfcType2BlockData.Text = s;
                }

                DisplayOpResult(ref pBlock.result);


            }
            DisplayRcvInf(rcvBuffer, "读标签数据页返回：");
            DisplaySendInf(sendBuffer, "读标签数据页：");
        }

        private void buttonWriteEmulNfcType2_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            ushort[] addrArray = new ushort[2];

            ISO14443A_BLOCKPARAM pBlock = new ISO14443A_BLOCKPARAM();

            pBlock.uid.uid = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_MAX_UID];
            pBlock.block = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_M1BLOCK * hfReaderDll.HFREADER_ISO14443A_M1BLOCKNUM_MAX];
            pBlock.key = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_M1_KEY];

            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            Byte[] blockNum = new Byte[1];
            Byte[] blockAddr = new Byte[1];

            Byte[] data = new Byte[16];


            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxWEmulNfcType2Addr.Text, blockAddr, 1) <= 0)
            {
                return;
            }
            pBlock.addr = blockAddr[0];

            if (GetHexInput(this.textBoxWEmulNfcType2Num.Text, blockNum, 1) <= 0)
            {
                return;
            }
            pBlock.num = blockNum[0];
            if (pBlock.num > hfReaderDll.HFREADER_ISO14443A_MOBLOCKNUM_MAX)
            {
                MessageBox.Show("写入数目超出范围，最多可以写入0x" + hfReaderDll.HFREADER_ISO14443A_MOBLOCKNUM_MAX.ToString("X").PadLeft(2, '0') + "Page");
                pBlock.num = hfReaderDll.HFREADER_ISO14443A_MOBLOCKNUM_MAX;
                this.textBoxWEmulNfcType2Num.Text = hfReaderDll.HFREADER_ISO14443A_MOBLOCKNUM_MAX.ToString("X").PadLeft(2, '0');
            }

            String s = this.textBoxWEmulNfcType2BlockData.Text;
            String[] dataString = new String[64];
            dataString = s.Split('\n');
            if (blockNum[0] > dataString.Length)
            {
                MessageBox.Show("数据不足，请继续填写");
                return;
            }
            else
            {
                int j = 0;
                int i = 0;
                for (i = 0; i < blockNum[0]; i++)
                {
                    int pos = dataString[i].IndexOf('\r');
                    if (pos >= 0)
                    {
                        dataString[i] = dataString[i].Remove(pos);
                    }

                    s = dataString[i];

                    if (GetHexInput(s, data, hfReaderDll.HFREADER_ISO14443A_LEN_M0BLOCK) <= 0)
                    {
                        return;
                    }
                    else
                    {
                        for (j = 0; j < hfReaderDll.HFREADER_ISO14443A_LEN_M0BLOCK; j++)
                        {
                            pBlock.block[i * hfReaderDll.HFREADER_ISO14443A_LEN_M0BLOCK + j] = data[j];
                        }
                    }
                }
            }

            pBlock.keyType = 0x00;

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.emulNfcType2WriteBlock(serialDevice, addrArray[0], addrArray[1], ref pBlock, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                DisplayOpResult(ref pBlock.result);
            }
            DisplayRcvInf(rcvBuffer, "写标签数据页返回：");
            DisplaySendInf(sendBuffer, "写标签数据页：");
        }

        private void buttonClearReadEmulNfcType2_Click(object sender, EventArgs e)
        {
            this.textBoxREmulNfcType2BlockData.Text = "";
        }

        private void buttonClearWriteEmulNfcType2_Click(object sender, EventArgs e)
        {
            this.textBoxWEmulNfcType2BlockData.Text = "";
        }
    }
}