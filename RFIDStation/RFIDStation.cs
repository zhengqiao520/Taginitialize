using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace RFIDStation
{
    public partial class RFIDStation : Form
    {
        private int serialDevice;                   //串口设备
        private int hHFREADERDLLModule;               //dll句柄
        private ISO15693 iso15693Form;
        private felica felicaForm;
        private EmulateNfcType2Tag simulateNfcType2Form;
        private updateSystem updateSystemForm;
        private uartDebug uartDebugForm;
        private NfcTools nfcToolsForm;

        /// <summary>
        /// 定义打开此窗体的父窗体
        /// </summary>
        public Form fatherForm;

        private void ShowComInfo()
        {
            if (serialDevice > 0)
            {
                this.toolStripStatusLabelState.Text = "状态：Open";
            }
            else
            {
                this.toolStripStatusLabelState.Text = "状态：Close";
               
            }
        }

        public RFIDStation()
        {
            InitializeComponent();

            hHFREADERDLLModule = 0;
            hHFREADERDLLModule = hfReaderDll.LoadLibrary("HFREADER.dll");

            if (hHFREADERDLLModule <= 0)
            {
                MessageBox.Show("装载HFREADER.dll文件失败，请确认HFREADER.dll文件是否存在");
                System.Environment.Exit(0);
            }

            serialDevice = -1;
            this.comboBoxTool.SelectedIndex = 0;
            this.comboBoxRelayFreq.SelectedIndex = 0;
            this.comboBoxOut2Freq.SelectedIndex = 0;
            this.comboBoxOut1Freq.SelectedIndex = 0;
            this.comboBoxComInterface.SelectedIndex = 0;
            this.textBoxPid.Text = "5050";
            this.textBoxVid.Text = "0505";
            this.Load += RFIDStation_Load1;
        }

        private void RFIDStation_Load1(object sender, EventArgs e)
        {
        
        }


        private bool GetUsbAddr(ushort[] addArray)
        {
            bool b = false;
            byte[] buffer = new Byte[255];
            if (GetHexInput(textBoxVid.Text, buffer, 2) > 0)
            {
                addArray[0] = (ushort)(buffer[0] * 256 + buffer[1]);
                if (GetHexInput(textBoxPid.Text, buffer, 2) > 0)
                {
                    addArray[1] = (ushort)(buffer[0] * 256 + buffer[1]);
                    b = true;
                }
            }

            return b;
        }


        private bool InitReader()
        {
            bool initReadStatus = true;
            if (serialDevice <= 0)
            {
                ushort[] usbAddr = new ushort[2];
                GetUsbAddr(usbAddr);
                serialDevice = hfReaderDll.hfReaderOpenUsb(usbAddr[0], usbAddr[1]);
                if (serialDevice > 0)
                {
                    this.buttonOpenSerial.Text = "关闭";
                    EnableSonForm();
                    this.comboBoxComInterface.Enabled = false;
                    //this.comboBoxTool.Enabled = true;
                }
                else
                {
                    MessageBox.Show("串口打开失败,请确认读卡器已连接！", "系统提示");
                    this.comboBoxTool.Enabled = false;
                    initReadStatus = false;
                }
            }
            else
            {
                int op = 0;
                op = hfReaderDll.hfReaderCloseUsb(serialDevice);
                if (op >= 0)
                {
                    this.buttonOpenSerial.Text = "打开";
                    DisableSonForm();
                }
                serialDevice = -1;
                this.comboBoxComInterface.Enabled = true;
                this.comboBoxTool.Enabled = false;

                ShowComInfo();
                buttonRFControl_Click(null, null);
                buttonTrgCtrl_Click(null, null);
                Hide();
            }
            return initReadStatus;
        }
        private void buttonOpenSerial_Click(object sender, EventArgs e)
        {
           
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

        private bool GetDeviceAddr(ushort[] addArray)
        {
            bool b = false;
            byte[] buffer = new Byte[255];
            if (GetHexInput(textBoxSrcAddr.Text, buffer, 2) > 0)
            {
                addArray[0] = (ushort)(buffer[0] * 256 + buffer[1]);
                if (GetHexInput(textBoxDestAddr.Text, buffer, 2) > 0)
                {
                    addArray[1] = (ushort)(buffer[0] * 256 + buffer[1]);
                    b = true;
                }
            }

            return b;
        }

        private void LockUart()
        {
            if ((iso15693Form != null) && (!iso15693Form.IsDisposed))
            {
                if (this.radioButtonISO15693.Checked)
                {
                    while (iso15693Form.bOperatingSerial) ;
                    iso15693Form.bOperatingSerial = true;
                }
            }
        }
        private void UnlockUart()
        {
            if ((iso15693Form != null) && (!iso15693Form.IsDisposed))
            {
                if (this.radioButtonISO15693.Checked)
                {
                    iso15693Form.bOperatingSerial = false;
                }
            }
        }

        public void DisplaySendInf(Byte[] pSendBuf, String cmdNmae)
        {
            String text = this.textBoxInf.Text;
            int i = 0;
            int len = pSendBuf[2] + 3;
            String s = cmdNmae;
            for (i = 0; i < len; i++)
            {
                s += pSendBuf[i].ToString("X").PadLeft(2, '0');
                s += " ";
            }
            s += "\r\n";
            this.textBoxInf.Text = s + text;
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
            this.textBoxInf.Text = s + text;
        }

        private void buttonConfigReader_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];
            Byte WorkMode = 0;
            ushort ReaderAddr = 0;
            Byte cmdMode = 0;
            Byte AFICtrl = 0;
            Byte UIDSendMode = 0;
            Byte tagStatus = 0;
            Byte baudrate = 0;
            Byte BeepStatus = 0;
            Byte AFI = 0;
            HFREADER_CONFIG pReaderConfig = new HFREADER_CONFIG();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (this.radioButtonISO15693.Checked)
            {
                WorkMode |= hfReaderDll.HFREADER_CFG_TYPE_ISO15693;
            }
            else if (this.radioButtonISO14443A.Checked)
            {
                WorkMode |= hfReaderDll.HFREADER_CFG_TYPE_ISO14443A;
            }
            else if (this.radioButtonISO14443B.Checked)
            {
                WorkMode |= hfReaderDll.HFREADER_CFG_TYPE_ISO14443B;
            }
            else if (this.radioButtonFelica.Checked)
            {
                WorkMode |= hfReaderDll.HFREADER_CFG_TYPE_FELICA;
            }
            else if (this.radioButtonNfcType2Tag.Checked)
            {
                WorkMode |= hfReaderDll.HFREADER_CFG_TYPE_NFCTYPE2TAG;
            }

            if (this.radioButtonWorkModeInventory.Checked)
            {
                WorkMode |= hfReaderDll.HFREADER_CFG_WM_INVENTORY;
            }
            else
            {
                WorkMode |= hfReaderDll.HFREADER_CFG_WM_EAS;
            }
            pReaderConfig.workMode = WorkMode;

            if (this.radioButtonCmdModeAuto.Checked)
            {
                cmdMode = hfReaderDll.HFREADER_CFG_INVENTORY_AUTO;
            }
            else
            {
                cmdMode = hfReaderDll.HFREADER_CFG_INVENTORY_TRIGGER;
            }
            pReaderConfig.cmdMode = cmdMode;

            if (this.radioButtonUIDModeAuto.Checked)
            {
                UIDSendMode = hfReaderDll.HFREADER_CFG_UID_ACTIVE;
            }
            else
            {
                UIDSendMode = hfReaderDll.HFREADER_CFG_UID_POSITIVE;
            }
            pReaderConfig.uidSendMode = UIDSendMode;

            if (this.radioButtonBeepModeEnable.Checked)
            {
                BeepStatus = hfReaderDll.HFREADER_CFG_BUZZER_ENABLE;
            }
            else
            {
                BeepStatus = hfReaderDll.HFREADER_CFG_BUZZER_DISABLE;
            }
            pReaderConfig.beepStatus = BeepStatus;

            if (this.radioButtonAFIModeEnable.Checked)
            {
                AFICtrl = hfReaderDll.HFREADER_CFG_AFI_ENABLE;
            }
            else
            {
                AFICtrl = hfReaderDll.HFREADER_CFG_AFI_DISABLE;
            }
            pReaderConfig.afiCtrl = AFICtrl;

            if (this.radioButtonTagModeQuiet.Checked)
            {
                tagStatus = hfReaderDll.HFREADER_CFG_TAG_QUIET;
            }
            else
            {
                tagStatus = hfReaderDll.HFREADER_CFG_TAG_NOQUIET;
            }
            pReaderConfig.tagStatus = tagStatus;

            if (this.radioButtonBR9600.Checked)
            {
                baudrate = hfReaderDll.HFREADER_CFG_BAUDRATE9600;
            }
            else if (this.radioButtonBR115200.Checked)
            {
                baudrate = hfReaderDll.HFREADER_CFG_BAUDRATE115200;
            }
            else
            {
                baudrate = hfReaderDll.HFREADER_CFG_BAUDRATE38400;
            }
            pReaderConfig.baudrate = baudrate;

            if (GetHexInput(this.textBoxAFI.Text, buffer, 1) > 0)
            {
                AFI = buffer[0];
            }
            else
            {
                return;
            }
            pReaderConfig.afi = AFI;

            if (GetHexInput(this.textBoxReaderAddr.Text, buffer, 2) > 0)
            {
                ReaderAddr = (ushort)(buffer[0] * 256 + buffer[1]);
            }
            else
            {
                return;
            }
            pReaderConfig.readerAddr = ReaderAddr;

            LockUart();
            int rlt = hfReaderDll.hfReaderSetConfig(serialDevice, addrArray[0], addrArray[1], ref pReaderConfig, sendBuffer, rcvBuffer);
            UnlockUart(); 
            if (rlt > 0)
            {
                if (pReaderConfig.result.flag == 0)
                {
                    this.radioButtonCfgRltOpOK.Checked = true;
                }
                else
                {
                    this.radioButtonCfgRltOpFail.Checked = true;
                }

                this.textBoxCfgRltSrcAddr.Text = pReaderConfig.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxCfgRltDestAddr.Text = pReaderConfig.result.targetAddr.ToString("X").PadLeft(4, '0');
            }
            DisplayRcvInf(rcvBuffer, "设置读写器配置参数返回：");
            DisplaySendInf(sendBuffer, "设置读写器配置参数：");

        }

        private void buttonReadConfiguration_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            HFREADER_CONFIG pReaderConfig = new HFREADER_CONFIG();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            LockUart();
            int rlt = hfReaderDll.hfReaderGetConfig(serialDevice, addrArray[0], addrArray[1], ref pReaderConfig, sendBuffer, rcvBuffer);
            UnlockUart();
            if (rlt > 0)
            {
                this.radioButtonCfgRltOpOK.Checked = false;
                this.radioButtonCfgRltOpFail.Checked = false;
                //if (pReaderConfig.Flag == 0)
                {
                    Byte mode = (Byte)(pReaderConfig.workMode);
                    if ((mode & hfReaderDll.HFREADER_CFG_TYPE_MASK) == hfReaderDll.HFREADER_CFG_TYPE_ISO15693)
                    {
                        this.radioButtonISO15693.Checked = true;
                    }
                    else if ((mode & hfReaderDll.HFREADER_CFG_TYPE_MASK) == hfReaderDll.HFREADER_CFG_TYPE_ISO14443A)
                    {
                        this.radioButtonISO14443A.Checked = true;
                    }
                    else if ((mode & hfReaderDll.HFREADER_CFG_TYPE_MASK) == hfReaderDll.HFREADER_CFG_TYPE_ISO14443B)
                    {
                        this.radioButtonISO14443B.Checked = true;
                    }
                    else if ((mode & hfReaderDll.HFREADER_CFG_TYPE_MASK) == hfReaderDll.HFREADER_CFG_TYPE_FELICA)
                    {
                        this.radioButtonFelica.Checked = true;
                    }
                    else if((mode & hfReaderDll.HFREADER_CFG_TYPE_MASK) == hfReaderDll.HFREADER_CFG_TYPE_NFCTYPE2TAG)
                    {
                        this.radioButtonNfcType2Tag.Checked = true;
                    }

                    if ((mode & hfReaderDll.HFREADER_CFG_WM_MASK) == hfReaderDll.HFREADER_CFG_WM_INVENTORY)
                    {
                        this.radioButtonWorkModeInventory.Checked = true;
                    }
                    else
                    {
                        this.radioButtonWorkModeEAS.Checked = true;
                    }

                    if (pReaderConfig.cmdMode == hfReaderDll.HFREADER_CFG_INVENTORY_AUTO)
                    {
                        this.radioButtonCmdModeAuto.Checked = true;
                    }
                    else
                    {
                        this.radioButtonCmdModeTrigle.Checked = true;
                    }
                    

                    if (pReaderConfig.uidSendMode == hfReaderDll.HFREADER_CFG_UID_ACTIVE)
                    {
                        this.radioButtonUIDModeAuto.Checked = true;
                    }
                    else
                    {
                        this.radioButtonUIDModeUnauto.Checked = true;
                    }

                    if (pReaderConfig.beepStatus == hfReaderDll.HFREADER_CFG_BUZZER_ENABLE)
                    {
                        this.radioButtonBeepModeEnable.Checked = true;
                    }
                    else
                    {
                        this.radioButtonBeepModeDisable.Checked = true;
                    }

                    if (pReaderConfig.afiCtrl == hfReaderDll.HFREADER_CFG_AFI_ENABLE)
                    {
                        this.radioButtonAFIModeEnable.Checked = true;
                    }
                    else
                    {
                        this.radioButtonAFIModeDisable.Checked = true;
                    }

                    //标签静默
                    if (pReaderConfig.tagStatus == hfReaderDll.HFREADER_CFG_TAG_QUIET)
                    {
                        this.radioButtonTagModeQuiet.Checked = true;
                    }
                    else
                    {
                        this.radioButtonTagModeUnquiet.Checked = true;
                    }
                    if (pReaderConfig.baudrate == hfReaderDll.HFREADER_CFG_BAUDRATE9600)
                    {
                        this.radioButtonBR9600.Checked = true;
                    }
                    else if (pReaderConfig.baudrate == hfReaderDll.HFREADER_CFG_BAUDRATE115200)
                    {
                        this.radioButtonBR115200.Checked = true;
                    }
                    else
                    {
                        this.radioButtonBR38400.Checked = true;
                    }

                    this.textBoxReaderAddr.Text = pReaderConfig.readerAddr.ToString("X").PadLeft(4, '0');
                    this.textBoxAFI.Text = pReaderConfig.afi.ToString("X").PadLeft(2, '0');
                }

                this.textBoxCfgRltSrcAddr.Text = pReaderConfig.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxCfgRltDestAddr.Text = pReaderConfig.result.srcAddr.ToString("X").PadLeft(4, '0'); 
            }
            DisplayRcvInf(rcvBuffer, "读取读写器配置参数返回：");
            DisplaySendInf(sendBuffer, "读取读写器配置参数：");
        }

        private void buttonDftConfiguration_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            ushort ReaderAddr = 0;
            HFREADER_CONFIG pReaderConfig = new HFREADER_CONFIG();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (GetHexInput(this.textBoxReaderAddr.Text, buffer, 2) > 0)
            {
                ReaderAddr = (ushort)(buffer[0] * 256 + buffer[1]);
            }
            else
            {
                return;
            }
            LockUart();
            int rlt = 0;
            rlt = hfReaderDll.hfReaderDefaultConfig(serialDevice, addrArray[0], addrArray[1], ref pReaderConfig, sendBuffer, rcvBuffer);
            UnlockUart();
            if (rlt > 0)
            {
                this.radioButtonWorkModeInventory.Checked = true;
                this.radioButtonCmdModeAuto.Checked = true;
                this.radioButtonUIDModeUnauto.Checked = true;
                this.radioButtonBeepModeEnable.Checked = true;
                this.radioButtonTagModeQuiet.Checked = true;
                this.radioButtonBR38400.Checked = true;
                this.textBoxReaderAddr.Text = "0001";

                if (pReaderConfig.result.flag == 0)
                {
                    this.radioButtonCfgRltOpOK.Checked = true;
                }
                else
                {
                    this.radioButtonCfgRltOpFail.Checked = true;
                }

                this.textBoxCfgRltSrcAddr.Text = pReaderConfig.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxCfgRltDestAddr.Text = pReaderConfig.result.targetAddr.ToString("X").PadLeft(4, '0');
            }
            DisplayRcvInf(rcvBuffer, "设置默认读写器配置参数返回：");
            DisplaySendInf(sendBuffer, "设置默认读写器配置参数：");

            buttonReadConfiguration_Click(sender, e);
        }

        private void buttonCfgRltReset_Click(object sender, EventArgs e)
        {
            this.textBoxCfgRltSrcAddr.Text = "";
            this.textBoxCfgRltDestAddr.Text = "";
            this.radioButtonCfgRltOpOK.Checked = false;
            this.radioButtonCfgRltOpFail.Checked = false;
        }

        private void buttonRFControl_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            Byte rfCtrl = 0;
            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (this.radioButtonRFOpen.Checked)
            {
                rfCtrl = hfReaderDll.HFREADER_RF_OPEN;
            }
            else if (this.radioButtonRFClose.Checked)
            {
                rfCtrl = hfReaderDll.HFREADER_RF_CLOSE;
            }
            else
            {
                rfCtrl = hfReaderDll.HFREADER_RF_RESET;
            }

            //LockUart();
            int rlt = hfReaderDll.hfReaderCtrlRf(serialDevice, addrArray[0], addrArray[1], rfCtrl, ref pResult, sendBuffer, rcvBuffer);
            //UnlockUart();

            if (rlt > 0)
            {
                if (pResult.flag == 0)
                {
                    this.radioButtonRfRltOpOK.Checked = true;
                }
                else
                {
                    this.radioButtonRfRltOpFail.Checked = true;
                }

                this.textBoxRfRltSrcAddr.Text = pResult.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxRfRltDestAddr.Text = pResult.targetAddr.ToString("X").PadLeft(4, '0');
            }
            DisplayRcvInf(rcvBuffer, "射频控制返回：");
            DisplaySendInf(sendBuffer, "射频控制：");
        }

        private void buttonRfRltReset_Click(object sender, EventArgs e)
        {
            this.textBoxRfRltSrcAddr.Text = "";
            this.textBoxRfRltDestAddr.Text = "";
            this.radioButtonRfRltOpOK.Checked = false;
            this.radioButtonRfRltOpFail.Checked = false;
        }

        private void buttonTrgCtrl_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            Byte trgCtrl = 0;
            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (this.radioButtonTrg.Checked)
            {
                trgCtrl = hfReaderDll.HFREADER_TRG_INVENTORY;
            }
            else
            {
                trgCtrl = hfReaderDll.HFREADER_TRG_NO;
            }

            LockUart();
            int rlt = hfReaderDll.hfReaderTrigger(serialDevice, addrArray[0], addrArray[1], trgCtrl, ref pResult, sendBuffer, rcvBuffer);
            UnlockUart();

            if (rlt > 0)
            {
                if (pResult.flag == 0)
                {
                    this.radioButtonTrgRltOpOK.Checked = true;
                }
                else
                {
                    this.radioButtonTrgRltOpFail.Checked = true;
                }

                this.textBoxTrgRltSrcAddr.Text = pResult.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxTrgRltDestAddr.Text = pResult.targetAddr.ToString("X").PadLeft(4, '0');
            }
            DisplayRcvInf(rcvBuffer, "触发控制返回：");
            DisplaySendInf(sendBuffer, "触发控制：");
        }

        private void buttonTrgRltReset_Click(object sender, EventArgs e)
        {
            this.textBoxTrgRltSrcAddr.Text = "";
            this.textBoxTrgRltDestAddr.Text = "";
            this.radioButtonTrgRltOpOK.Checked = false;
            this.radioButtonTrgRltOpFail.Checked = false;
        }

        private void radioButtonISO14443A_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxWorkMode.Enabled = false;
            this.groupBoxAFIMode.Enabled = false;

            this.groupBoxAFIMode.Enabled = true;
            this.groupBoxTagQuit.Enabled = true;

            this.groupBoxUIDSendMode.Enabled = true;
            this.groupBoxCmdMode.Enabled = true;

            EnableSonForm();
        }

        private void radioButtonISO15693_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxWorkMode.Enabled = true;
            this.groupBoxAFIMode.Enabled = true;

            this.groupBoxAFIMode.Enabled = true;
            this.groupBoxTagQuit.Enabled = true;

            this.groupBoxUIDSendMode.Enabled = true;
            this.groupBoxCmdMode.Enabled = true;

            EnableSonForm();
        }

        private void radioButtonWorkModeEAS_CheckedChanged(object sender, EventArgs e)
        {
            if (this.groupBoxWorkMode.Enabled)
            {
                this.groupBoxCmdMode.Enabled = false;
                this.groupBoxUIDSendMode.Enabled = false;
                this.groupBoxAFIMode.Enabled = false;
                this.groupBoxTagQuit.Enabled = false;
            }
        }

        private void radioButtonWorkModeInventory_CheckedChanged(object sender, EventArgs e)
        {
            if (this.groupBoxWorkMode.Enabled)
            {
                this.groupBoxCmdMode.Enabled = true;
                this.groupBoxUIDSendMode.Enabled = true;
                this.groupBoxAFIMode.Enabled = true;
                this.groupBoxTagQuit.Enabled = true;
            }
        }
        private void EnableSonForm()
        {
            if ((iso15693Form != null) && (!iso15693Form.IsDisposed))
            {
                if (this.radioButtonISO15693.Checked)
                {
                    iso15693Form.EnableIso15693(serialDevice);
                }
            }
            if ((felicaForm != null) && (!felicaForm.IsDisposed))
            {
                if (this.radioButtonFelica.Checked)
                {
                    felicaForm.EnableFelica(serialDevice);
                }
            }
        }
        private void DisableSonForm()
        {
            if ((iso15693Form != null) && (!iso15693Form.IsDisposed))
            {
                iso15693Form.DisableIso15693();
            }
        }
        private void comboBoxTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxTool.SelectedIndex == 2)
            {
                if (updateSystemForm == null || updateSystemForm.IsDisposed)
                {
                    DisableSonForm();
                    updateSystemForm = new updateSystem();
                    updateSystemForm.ShowDialog();
                    this.comboBoxTool.SelectedIndex = 0;
                }
            }
            else if (this.comboBoxTool.SelectedIndex == 1)
            {
                if (uartDebugForm == null || uartDebugForm.IsDisposed)
                {
                    DisableSonForm();
                    uartDebugForm = new uartDebug();
                    uartDebugForm.ShowDialog();
                    this.comboBoxTool.SelectedIndex = 0;
                }
            }
            else if (this.comboBoxTool.SelectedIndex == 3)
            {
                if (nfcToolsForm == null || nfcToolsForm.IsDisposed)
                {
                    DisableSonForm();
                    nfcToolsForm = new NfcTools();
                    nfcToolsForm.ShowDialog();
                    this.comboBoxTool.SelectedIndex = 0;
                }
            }
        }

        private void comboBoxTagOp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialDevice > 0)
            {
                int op = hfReaderDll.hfReaderClosePort(serialDevice);
                if (op >= 0)
                {
                    this.buttonOpenSerial.Text = "打开";
                    //this.comboBoxComPort.Enabled = true;
                    //this.comboBoxBaudrate.Enabled = true;
                    //this.comboBoxTool.Enabled = false;
                    DisableSonForm();
                }
                serialDevice = -1;
            }

            if (serialDevice > 0)
            {
                this.buttonOpenSerial.Text = "关闭";
                //this.comboBoxComPort.Enabled = false;
                //this.comboBoxBaudrate.Enabled = false;

                //this.comboBoxTool.Enabled = true;
                EnableSonForm();
                this.comboBoxComInterface.Enabled = false;
            }

            ShowComInfo();
        }

        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialDevice > 0)
            {
                int op = hfReaderDll.hfReaderClosePort(serialDevice);
                if (op >= 0)
                {
                    this.buttonOpenSerial.Text = "打开";
                    //this.comboBoxComPort.Enabled = true;
                    //this.comboBoxBaudrate.Enabled = true;
                    //this.comboBoxTool.Enabled = false;
                    DisableSonForm();
                }
                serialDevice = -1;
            }

            if (serialDevice > 0)
            {
                this.buttonOpenSerial.Text = "关闭";
                //this.comboBoxComPort.Enabled = false;
                //this.comboBoxBaudrate.Enabled = false;

                //this.comboBoxTool.Enabled = true;
                EnableSonForm();
                this.comboBoxComInterface.Enabled = false;
            }
            ShowComInfo();
        }

        private void buttonClearInfo_Click(object sender, EventArgs e)
        {
            this.textBoxInf.Text = "";
        }

        private void buttonClearIoInput_Click(object sender, EventArgs e)
        {
            this.textBoxGetIoSrcAddr.Text = "";
            this.textBoxGetIoTargetAddr.Text = "";
            this.textBoxIn1.Text = "";
            this.textBoxIn2.Text = "";
            this.textBoxIn3.Text = "";
            this.textBoxIn4.Text = "";
        }

        private void buttonGetIo_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            HFREADER_IO pIo = new HFREADER_IO();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            LockUart();
            int rlt = hfReaderDll.hfReaderGetIo(serialDevice, addrArray[0], addrArray[1], ref pIo, sendBuffer, rcvBuffer);
            UnlockUart();

            if (rlt > 0)
            {
                this.textBoxGetIoSrcAddr.Text = pIo.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxGetIoTargetAddr.Text = pIo.result.targetAddr.ToString("X").PadLeft(4, '0');
                this.textBoxIn1.Text = pIo.in1.ToString("X").PadLeft(8, '0');
                this.textBoxIn2.Text = pIo.in2.ToString("X").PadLeft(8, '0');
                this.textBoxIn3.Text = pIo.in3.ToString("X").PadLeft(8, '0');
                this.textBoxIn4.Text = pIo.in4.ToString("X").PadLeft(8, '0');
            }
            DisplayRcvInf(rcvBuffer, "获取输入事件返回：");
            DisplaySendInf(sendBuffer, "获取输入事件：");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            HFREADER_IO pIo = new HFREADER_IO();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (this.radioButtonRelayOff.Checked)
            {
                pIo.relayState = 0;
            }
            else if (this.radioButtonRelayOn.Checked)
            {
                pIo.relayState = 1;
            }
            else
            {
                pIo.relayState = 2;
            }

            if (this.radioButtonOut2Off.Checked)
            {
                pIo.out2State = 0;
            }
            else if (this.radioButtonOut2On.Checked)
            {
                pIo.out2State = 1;
            }
            else
            {
                pIo.out2State = 2;
            }

            if (this.radioButtonOut1Off.Checked)
            {
                pIo.out1State = 0;
            }
            else if (this.radioButtonOut1On.Checked)
            {
                pIo.out1State = 1;
            }
            else
            {
                pIo.out1State = 2;
            }

            LockUart();
            int rlt = hfReaderDll.hfReaderSetIo(serialDevice, addrArray[0], addrArray[1], ref pIo, sendBuffer, rcvBuffer);
            UnlockUart();

            if (rlt > 0)
            {
                if (pIo.result.flag == 0)
                {
                    this.radioButtonSetIoOk.Checked = true;
                    this.radioButtonSetIoFail.Checked = false;
                }
                else
                {
                    this.radioButtonSetIoOk.Checked = false;
                    this.radioButtonSetIoFail.Checked = true;
                }

                this.textBoxSetIoSrcAddr.Text = pIo.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxSetIoTargetAddr.Text = pIo.result.targetAddr.ToString("X").PadLeft(4, '0');
            }
            DisplayRcvInf(rcvBuffer, "设置输出事件返回：");
            DisplaySendInf(sendBuffer, "设置输出事件：");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBoxSetIoSrcAddr.Text = "";
            this.textBoxSetIoTargetAddr.Text = "";
            this.radioButtonSetIoOk.Checked = false;
            this.radioButtonSetIoFail.Checked = false;
        }

        private void buttonCfgIo_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            HFREADER_IO pIo = new HFREADER_IO();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            pIo.relayFrequent = (uint)(this.comboBoxRelayFreq.SelectedIndex + 1);
            pIo.out2Frequent = (uint)(this.comboBoxOut2Freq.SelectedIndex + 1);
            pIo.out1Frequent = (uint)(this.comboBoxOut1Freq.SelectedIndex + 1);

            if (GetHexInput(this.textBoxRelayCycle.Text, buffer, 1) <= 0)
            {
                return;
            }
            pIo.relayCycle = buffer[0];

            if (GetHexInput(this.textBoxOut2Cycle.Text, buffer, 1) <= 0)
            {
                return;
            }
            pIo.out2Cycle = buffer[0];

            if (GetHexInput(this.textBoxOut1Cycle.Text, buffer, 1) <= 0)
            {
                return;
            }
            pIo.out1Cycle = buffer[0];
            

            LockUart();
            int rlt = hfReaderDll.hfReaderCfgIo(serialDevice, addrArray[0], addrArray[1], ref pIo, sendBuffer, rcvBuffer);
            UnlockUart();

            if (rlt > 0)
            {
                if (pIo.result.flag == 0)
                {
                    this.radioButtonCfgIoOpOk.Checked = true;
                    this.radioButtonCfgIoOpFail.Checked = false;
                }
                else
                {
                    this.radioButtonCfgIoOpOk.Checked = false;
                    this.radioButtonCfgIoOpFail.Checked = true;
                }

                this.textBoxCfgIoSrcAddr.Text = pIo.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxCfgIoTargetAddr.Text = pIo.result.targetAddr.ToString("X").PadLeft(4, '0');
            }
            DisplayRcvInf(rcvBuffer, "配置IO输出事件返回：");
            DisplaySendInf(sendBuffer, "配置IO输出事件：");
        }

        private void buttonClearCfgIo_Click(object sender, EventArgs e)
        {
            this.textBoxCfgIoSrcAddr.Text = "";
            this.textBoxCfgIoTargetAddr.Text = "";
            this.radioButtonCfgIoOpOk.Checked = false;
            this.radioButtonCfgIoOpFail.Checked = false;
        }

        private void radioButtonCmdModeAuto_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxComInterface_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.textBoxVid.Enabled = true;
            this.textBoxPid.Enabled = true;
            this.textBoxVid.Show();
            this.textBoxPid.Show();
            this.labelVid.Show();
            this.labelPid.Show();
        }

        private void buttonGetV_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            HFREADER_VERSION pVersion = new HFREADER_VERSION();
            pVersion.type = new byte[hfReaderDll.HFREADER_VERSION_SIZE];
            pVersion.sv = new byte[hfReaderDll.HFREADER_VERSION_SIZE];
            pVersion.hv = new byte[hfReaderDll.HFREADER_VERSION_SIZE];
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }


            LockUart();
            int rlt = hfReaderDll.hfReaderGetVersion(serialDevice, addrArray[0], addrArray[1], ref pVersion, sendBuffer, rcvBuffer);
            UnlockUart();

            if (rlt > 0)
            {
                if (pVersion.result.flag == 0)
                {
                    this.radioButtonGetVOk.Checked = true;
                    this.textBoxGDeviceType.Text = System.Text.Encoding.Default.GetString(pVersion.type);
                    this.textBoxGDeviceSv.Text = System.Text.Encoding.Default.GetString(pVersion.sv);
                    this.textBoxGDeviceHv.Text = System.Text.Encoding.Default.GetString(pVersion.hv);
                    this.textBoxSDeviceType.Text = System.Text.Encoding.Default.GetString(pVersion.type);
                }
                else
                {
                    this.radioButtonGetVFail.Checked = true;
                    this.textBoxGDeviceType.Text = "";
                    this.textBoxGDeviceSv.Text = "";
                    this.textBoxGDeviceHv.Text = "";
                    this.textBoxSDeviceType.Text = "";
                }

                this.textBoxGetVSrcAddr.Text = pVersion.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxGetVDestAddr.Text = pVersion.result.targetAddr.ToString("X").PadLeft(4, '0');
            }
            DisplayRcvInf(rcvBuffer, "获取版本信息返回：");
            DisplaySendInf(sendBuffer, "获取版本信息：");
        }

        private void buttonSetV_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            HFREADER_VERSION pVersion = new HFREADER_VERSION();
            pVersion.type = new byte[hfReaderDll.HFREADER_VERSION_SIZE];
            pVersion.sv = new byte[hfReaderDll.HFREADER_VERSION_SIZE];
            pVersion.hv = new byte[hfReaderDll.HFREADER_VERSION_SIZE];
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];
            Byte[] str = new byte[hfReaderDll.HFREADER_VERSION_SIZE]; 

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            str = System.Text.Encoding.Default.GetBytes(this.textBoxSDeviceType.Text);
            Array.Copy(str, 0, pVersion.type, 0, str.Length);

            str = System.Text.Encoding.Default.GetBytes(this.textBoxSDeviceSv.Text);
            Array.Copy(str, 0, pVersion.sv, 0, str.Length);

            str = System.Text.Encoding.Default.GetBytes(this.textBoxSDeviceHv.Text);
            Array.Copy(str, 0, pVersion.hv, 0, str.Length); 


            LockUart();
            int rlt = hfReaderDll.hfReaderSetVersion(serialDevice, addrArray[0], addrArray[1], ref pVersion, sendBuffer, rcvBuffer);
            UnlockUart();

            if (rlt > 0)
            {
                if (pVersion.result.flag == 0)
                {
                    this.radioButtonGetVOk.Checked = true;
                }
                else
                {
                    this.radioButtonGetVFail.Checked = true;
                }

                this.textBoxGetVSrcAddr.Text = pVersion.result.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxGetVDestAddr.Text = pVersion.result.targetAddr.ToString("X").PadLeft(4, '0');
            }
            DisplayRcvInf(rcvBuffer, "设置版本信息返回：");
            DisplaySendInf(sendBuffer, "设置版本信息：");
        }

        private void buttonGetVRest_Click(object sender, EventArgs e)
        {
            this.radioButtonGetVFail.Checked = false;
            this.radioButtonGetVOk.Checked = false;
            this.textBoxGDeviceType.Text = "";
            this.textBoxGDeviceSv.Text = "";
            this.textBoxGDeviceHv.Text = "";
            this.textBoxGetVSrcAddr.Text = "";
            this.textBoxGetVDestAddr.Text = "";
        }

        private void buttonSetVReset_Click(object sender, EventArgs e)
        {
            this.radioButtonSetVFail.Checked = false;
            this.radioButtonSetVOk.Checked = false;
            this.textBoxSetVSrcAddr.Text = "";
            this.textBoxSetVDestAddr.Text = "";
        }

        private void radioButtonISO14443B_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxWorkMode.Enabled = false;
            this.groupBoxAFIMode.Enabled = false;

            this.groupBoxAFIMode.Enabled = true;
            this.groupBoxTagQuit.Enabled = true;

            this.groupBoxUIDSendMode.Enabled = true;
            this.groupBoxCmdMode.Enabled = true;

            EnableSonForm();
        }

        private void radioButtonFelica_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxWorkMode.Enabled = false;
            this.groupBoxAFIMode.Enabled = false;

            this.groupBoxAFIMode.Enabled = false;
            this.groupBoxTagQuit.Enabled = false;

            this.groupBoxUIDSendMode.Enabled = true;
            this.groupBoxCmdMode.Enabled = true;

            EnableSonForm();
        }

        private void radioButtonNfcType2Tag_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxWorkMode.Enabled = false;
            this.groupBoxAFIMode.Enabled = false;

            this.groupBoxAFIMode.Enabled = false;
            this.groupBoxTagQuit.Enabled = false;

            this.groupBoxUIDSendMode.Enabled = false;
            this.groupBoxCmdMode.Enabled = false;

            EnableSonForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (serialDevice < 0)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];

            Byte trgCtrl = 0;
            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
            Byte[] sendBuffer = new Byte[1024];
            Byte[] rcvBuffer = new Byte[1024];
            Byte[] ant = new Byte[6];

            if (!GetDeviceAddr(addrArray))
            {
                return;
            }

            if (this.radioButtonAnt1.Checked)
            {
                ant[0] = 0x01;
            }
            else
            {
                ant[0] = 0x00;
            }
            if (this.radioButtonAnt2.Checked)
            {
                ant[1] = 0x01;
            }
            else
            {
                ant[1] = 0x00;
            }
            if (this.radioButtonAnt3.Checked)
            {
                ant[2] = 0x01;
            }
            else
            {
                ant[2] = 0x00;
            }
            if (this.radioButtonAnt4.Checked)
            {
                ant[3] = 0x01;
            }
            else
            {
                ant[3] = 0x00;
            }
            if (this.radioButtonAnt5.Checked)
            {
                ant[4] = 0x01;
            }
            else
            {
                ant[4] = 0x00;
            }
            if (this.radioButtonAnt6.Checked)
            {
                ant[5] = 0x01;
            }
            else
            {
                ant[5] = 0x00;
            }

            LockUart();
            int rlt = hfReaderDll.hfReaderSelectAnt(serialDevice, addrArray[0], addrArray[1], ant, ref pResult, sendBuffer, rcvBuffer);
            UnlockUart();

            if (rlt > 0)
            {
                if (pResult.flag == 0)
                {
                    this.radioButtonCtrlAntRspOk.Checked = true;
                }
                else
                {
                    this.radioButtonCtrlAntRspFail.Checked = true;
                }

                this.textBoxCtrlAntRspSrcAddr.Text = pResult.srcAddr.ToString("X").PadLeft(4, '0');
                this.textBoxCtrlAntRspDestAddr.Text = pResult.targetAddr.ToString("X").PadLeft(4, '0');
            }
            DisplayRcvInf(rcvBuffer, "天线控制返回：");
            DisplaySendInf(sendBuffer, "天线控制：");
        }

        private void buttonCtrlAntRltReset_Click(object sender, EventArgs e)
        {
            this.textBoxCtrlAntRspSrcAddr.Text = "";
            this.textBoxCtrlAntRspDestAddr.Text = "";
            this.radioButtonCtrlAntRspOk.Checked = false;
            this.radioButtonCtrlAntRspFail.Checked = false;
        }

        private void RFIDStation_Load(object sender, EventArgs e)
        {
            bool readerStatus=InitReader();
            if (iso15693Form == null || iso15693Form.IsDisposed)
            {
                iso15693Form = new ISO15693(readerStatus);
                iso15693Form.fatherForm = this;
                if (this.radioButtonISO15693.Checked)
                {
                    iso15693Form.EnableIso15693(serialDevice);
                }
                else
                {
                    iso15693Form.DisableIso15693();
                }
                iso15693Form.Show();
                this.Opacity = 0;
            }
        }

        private void RFIDStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            //显示父窗体
            fatherForm.Visible = true;
        }
    }
}