using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RFIDStation
{
    public partial class felica : Form
    {
        private int serialDevice;                   //串口设备
        public bool bOperatingSerial;
        public delegate void Delegate(object obj);

        public felica()
        {
            InitializeComponent();

            serialDevice = -1;
            bOperatingSerial = false;
        }

        private void clearOpResult()
        {
            this.textBoxOpFelicaTagRltSrcAddr.Text = "";
            this.textBoxOpFelicaTagRltDestAddr.Text = "";

            this.radioButtonOpFelicaTagRltOpOK.Checked = false;
            this.radioButtonOpFelicaErrTypeOK.Checked = false;

            this.radioButtonOpFelicaTagRltOpFail.Checked = false;
            this.radioButtonOpFelicaErrTypeCrc.Checked = false;
            this.radioButtonOpFelicaErrTypeTag.Checked = false;
            this.radioButtonOpFelicaErrTypeRsp.Checked = false;
            this.radioButtonOpFelicaErrTypeRsp.Checked = false;
            //this.labelUserTimer.Text = "0ms";
        }

        private void DisplayOpResult(ref HFREADER_OPRESULT pResult)
        {
            this.textBoxOpFelicaTagRltSrcAddr.Text = pResult.srcAddr.ToString("X").PadLeft(4, '0');
            this.textBoxOpFelicaTagRltDestAddr.Text = pResult.targetAddr.ToString("X").PadLeft(4, '0');
            if (pResult.flag == 0)
            {
                this.radioButtonOpFelicaTagRltOpOK.Checked = true;
                this.radioButtonOpFelicaErrTypeOK.Checked = true;
            }
            else
            {
                this.radioButtonOpFelicaTagRltOpFail.Checked = true;
                if (pResult.errType == 0x01)
                {
                    this.radioButtonOpFelicaErrTypeTag.Checked = true;
                }
                else if (pResult.errType == 0x02)
                {
                    this.radioButtonOpFelicaErrTypeCrc.Checked = true;
                }
                else if (pResult.errType == 0x03)
                {
                    this.radioButtonOpFelicaErrTypeRsp.Checked = true;
                }
                else if (pResult.errType == 0x04)
                {
                    this.radioButtonOpFelicaErrTypeParam.Checked = true;
                }
                else
                {
                    this.radioButtonOpFelicaErrTypeRsp.Checked = true;
                }
            }
            //this.labelUserTimer.Text = pResult.t.ToString("D") + "ms";
        }

        public void EnableFelica(int h)
        {
            serialDevice = h;

            this.tabControlFelicaTagOp.Enabled = true;
//             receiveFrameThread = new Thread(new ThreadStart(ReceiveFrame));
//             receiveFrameThread.IsBackground = true;
//             receiveFrameThread.Start();
        }

        public void DisableFelica()
        {
//             if (receiveFrameThread != null)
//             {
//                 receiveFrameThread.Abort();
//             }

            this.tabControlFelicaTagOp.Enabled = false;
            serialDevice = -1;
        }

        private void AddDisplayInfo(object obj)
        {
            if (this.textBoxFelicaInf.InvokeRequired)
            {
                Delegate d = new Delegate(AddDisplayInfo);
                this.textBoxFelicaInf.Invoke(d, obj);

            }
            else
            {
                this.textBoxFelicaInf.Text = obj.ToString();
            }
        }

        public void DisplaySendInf(Byte[] pSendBuf, String cmdNmae)
        {
            String text = this.textBoxFelicaInf.Text;
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
            String text = this.textBoxFelicaInf.Text;
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
            if (GetHexInput(textBoxFelicaSrcAddr.Text, buffer, 2) > 0)
            {
                addArray[0] = (ushort)(buffer[0] * 256 + buffer[1]);
                if (GetHexInput(textBoxFelicaDestAddr.Text, buffer, 2) > 0)
                {
                    addArray[1] = (ushort)(buffer[0] * 256 + buffer[1]);
                    b = true;
                }
            }

            return b;
        }

        public void CtrlUidEnalbe(bool b)
        {
            this.checkBoxUidEnable.Checked = b;
            this.textBoxSelectedFelicaUid.Enabled = b;
            {
                this.radioButtonRequestTagIdle.Text = "正常";
                this.radioButtonRequestTagAll.Text = "重复";
            }
        }

        private void buttonReadFelicaTags_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();
            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];
            Byte mode = 0;

            FELICA_UIDPARAM pUid = new FELICA_UIDPARAM();
            pUid.uid = new Byte[hfReaderDll.HFREADER_FELICA_UID_LEN * hfReaderDll.HFREADER_FELICA_UID_MAX_NUM];
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }
            if (this.checkBoxUidEnable.Checked)
            {
                if (this.radioButtonRequestTagIdle.Checked)
                {
                    mode = hfReaderDll.HFREADER_READ_UID_NORMAL;
                }
                else
                {
                    mode = hfReaderDll.HFREADER_READ_UID_REPEAT;
                }
            }
            else
            {
                if (this.radioButtonRequestTagIdle.Checked)
                {
                    mode = hfReaderDll.HFREADER_READ_UID_NORMAL;
                }
                else
                {
                    mode = hfReaderDll.HFREADER_READ_UID_REPEAT;
                }
            }


            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.felicaGetUID(serialDevice, addrArray[0], addrArray[1], mode, ref pUid, sendBuffer, rcvBuffer);
            bOperatingSerial = false;
            if (rlt > 0)
            {
                this.radioButtonOpFelicaTagRltOpOK.Checked = false;
                this.radioButtonOpFelicaTagRltOpFail.Checked = false;

                this.textBoxOpFelicaTagRltSrcAddr.Text = pUid.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxOpFelicaTagRltDestAddr.Text = pUid.result.targetAddr.ToString("X").PadLeft(4, '0');


                if (pUid.num > 0)
                {
                    int i = 0, j = 0;
                    String s;
                    for (i = 0; i < pUid.num; i++)
                    {
                        s = "";
                        for (j = 0; j < hfReaderDll.HFREADER_FELICA_UID_LEN; j++)
                        {
                            s += pUid.uid[i * hfReaderDll.HFREADER_FELICA_UID_LEN + j].ToString("X").PadLeft(2, '0');
                        }
                        if (this.listBoxTagInfo.FindString(s) < 0)
                        {
                            this.listBoxTagInfo.Items.Add(s);
                        }
                    }
                    this.textBoxReadTagNum.Text = this.listBoxTagInfo.Items.Count.ToString("X").PadLeft(2, '0');
                    this.textBoxRemainTagNum.Text = pUid.remainNum.ToString("X").PadLeft(2, '0');
                }

            }
            DisplayRcvInf(rcvBuffer, "查询场内标签返回：");
            DisplaySendInf(sendBuffer, "查询场内标签：");
        }

        private void buttonClearFelicaInTag_Click(object sender, EventArgs e)
        {
            listBoxTagInfoIn.Items.Clear();
            textBoxFelicaTagInNum.Text = "00";
        }

        private void buttonClearFelicaListBox_Click(object sender, EventArgs e)
        {
            this.textBoxReadTagNum.Text = "00";
            this.textBoxRemainTagNum.Text = "00";
            this.listBoxTagInfo.Items.Clear();
        }

        private void buttonClearOpFelicaTag_Click(object sender, EventArgs e)
        {
            clearOpResult();
        }

        private void buttonClearFelicaInfo_Click(object sender, EventArgs e)
        {
            this.textBoxFelicaInf.Text = "";
        }

        private void buttonDtu_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            clearOpResult();

            ushort[] addrArray = new ushort[2];
            Byte[] rxLen = new Byte[1];

            FELICA_DTU pDtu = new FELICA_DTU();
            pDtu.txFrame = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];
            pDtu.rxFrame = new Byte[hfReaderDll.HFREADER_BUFFER_MAX];

            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxDtuRxLen.Text, rxLen, 1) <= 0)
            {
                return;
            }
            pDtu.rxLen = rxLen[0];

            pDtu.txLen = (uint)(GetHexInput(this.textBoxDtuTx.Text, pDtu.txFrame));

            pDtu.timeout = Convert.ToUInt32(this.textBoxDtuTime.Text, 10);

            while (bOperatingSerial) ;
            bOperatingSerial = true;
            int rlt = hfReaderDll.felicaDtu(serialDevice, addrArray[0], addrArray[1], ref pDtu, sendBuffer, rcvBuffer);
            bOperatingSerial = false;

            if (rlt > 0)
            {
                if (pDtu.result.flag == 0)
                {
                    string s = "";
                    for (uint i = 0; i < pDtu.rxLen; i++)
                    {
                        s += pDtu.rxFrame[i].ToString("X").PadLeft(2, '0');
                    }
                    this.textBoxDtuRx.Text = s;
                    this.textBoxDtuRxLen.Text = pDtu.rxLen.ToString("X").PadLeft(2, '0');
                }
                DisplayOpResult(ref pDtu.result);
            }
            DisplayRcvInf(rcvBuffer, "透传返回：");
            DisplaySendInf(sendBuffer, "透传：");
        }

        private void buttonDtuTxClear_Click(object sender, EventArgs e)
        {
            this.textBoxDtuTx.Text = "";
        }

        private void buttonDtuRxClear_Click(object sender, EventArgs e)
        {
            this.textBoxDtuRx.Text = "";
        }

        private void listBoxTagInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxTagInfo.SelectedItem != null)
            {
                this.textBoxSelectedFelicaUid.Text = this.listBoxTagInfo.SelectedItem.ToString();
            }
        }
    }
}