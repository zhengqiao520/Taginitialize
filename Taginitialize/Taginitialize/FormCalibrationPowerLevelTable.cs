using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Phychips.Rcp;
using Phychips.Helper;
using BarChart;
using System.Collections;
using System.IO;
using System.IO.Ports;
using Ivi.Visa.Interop;
using System.Threading;
using Phychips.Driver;



namespace Phychips.PR9200
{
    public partial class FormCalibrationPowerLevellTable : Form
    {
        //private Ivi.Visa.Interop.ResourceManager rm;
        //private Ivi.Visa.Interop.IMessage msg;
        private Ivi.Visa.Interop.FormattedIO488 ioSpectrumAnalyzer;

        public FormCalibrationPowerLevellTable()
        {
            InitializeComponent();
            
        }

        private void FormCalibrationPowerLevellTable_Load(object sender, System.EventArgs e)
        {
            ioSpectrumAnalyzer = new Ivi.Visa.Interop.FormattedIO488();

            button_CP_TBL.Enabled = false;

            /*
            for (int i = 17; i > 0; i--)
            {
                comboBox_Range.Items.Add(i.ToString());
            }
             */

            cb_region.SelectedIndex = 0;

        }

        UInt16[] MatchedOffset = new UInt16[21];  


        GpibAgilent m_Spectrum1 = new GpibAgilent();

        public bool DirectWrite(GpibAgilent dev, string cmd)
        {
            if (!dev.GpibWrt(cmd))
                return false;

            return true;
        }

        public string[] measureVal = new string[55];
        float temp;

        public bool DirectRead(GpibAgilent dev, ref float rdata, string pow)
        {
            string strRx;
            string[] temp;

            if (!dev.GpibRd(out strRx))
                return false;

            strRx = strRx.Replace(" ", string.Empty);
            temp = strRx.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //modify yjseon
            temp.CopyTo(measureVal, 0);
            //end modify
            rdata = (float)(double.Parse(temp[0]) * Math.Pow(10, double.Parse(pow)));

            return true;
        }


        public UInt16[] refModulePwr = null;

        Thread newThread;

        public int regionVal;

        private void reader_operate()
        {
            byte region = 0x11;
            byte[] param = new byte[2];
            UInt16 power = 200;
            ByteBuilder bb = new ByteBuilder();

           

            if (!InvokeRequired)
            {
                regionVal = this.cb_region.SelectedIndex;
                // return;
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                regionVal = this.cb_region.SelectedIndex;
            }));


            if (RcpProtocol.Instance.m_bRcpReceivedPacket != false)
            {
                RcpProtocol.Instance.m_bRcpReceivedPacket = false;
            }

            //switch ((string)cbRegion.SelectedItem)
            switch (regionVal)
            {
                case 0://"Korea":// Korea (0x11)
                    region = 0x11;
                    param[0] = 0x14;
                    param[1] = 0;
                    break;
                case 1://""US":// US (0x21)
                    region = 0x21;
                    param[0] = 1;
                    param[1] = 0;
                    break;
                case 2://""US2":// US2 (0x22)
                    region = 0x22;
                    param[0] = 0x19;
                    param[1] = 0;
                    break;
                case 3://""Europe":// Europe (0x31)
                    region = 0x31;
                    param[0] = 0x0A;
                    param[1] = 0;
                    break;
                case 4://""Japan":// Japan (0x41)
                    region = 0x41;
                    param[0] = 0x18;
                    param[1] = 0;
                    break;
                case 5://""China1":// China1 (0x51)
                    region = 0x51;
                    param[0] = 1;
                    param[1] = 0;
                    break;
                case 6://""China2":// China2 (0x52)
                    region = 0x52;
                    param[0] = 1;
                    param[1] = 0;
                    break;
            }

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_REGION, new byte[] { region }))) { return; }

            WaitForReceived();

            // System.Threading.Thread.Sleep(100);           

            if (param[1] < 10) param[1] = (byte)((byte)param[1] * ((byte)10));

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CH, param))) { }

            WaitForReceived();

            bb.Append((UInt16)power);
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_TX_PWR, bb.GetByteArray()))) { }
            bb.Clear();
            WaitForReceived();
            System.Threading.Thread.Sleep(100);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0xFF }))) { }
            bb.Clear();
            WaitForReceived();
            System.Threading.Thread.Sleep(500);


        }

        private void equipment_Setup()
        {


            DirectWrite(m_Spectrum1, "DISP:WIND:TRAC:Y:RLEV:OFFS 10.6dB");
            System.Threading.Thread.Sleep(100);

            DirectWrite(m_Spectrum1, "DISP:WIND:TRAC:Y:RLEV 30dBm");
            System.Threading.Thread.Sleep(100);

            switch (regionVal)
            {
                case 0:
                    DirectWrite(m_Spectrum1, "FREQ:CENT 920.9MHz");            //korea
                    System.Threading.Thread.Sleep(50);
                    break;
                case 1:
                    DirectWrite(m_Spectrum1, "FREQ:CENT 902.75MHz");             //US
                    System.Threading.Thread.Sleep(50);
                    break;
                case 2:
                    DirectWrite(m_Spectrum1, "FREQ:CENT 921.9MHz");             //us2
                    System.Threading.Thread.Sleep(50);
                    break;
                case 3:
                    DirectWrite(m_Spectrum1, "FREQ:CENT 866.9MHz");            //Europe
                    System.Threading.Thread.Sleep(50);
                    break;
                case 4:
                    DirectWrite(m_Spectrum1, "FREQ:CENT 920.6MHz");             //japan
                    System.Threading.Thread.Sleep(50);
                    break;
                case 5:
                    DirectWrite(m_Spectrum1, "FREQ:CENT 840.375MHz");             //China
                    System.Threading.Thread.Sleep(50);
                    break;
                case 6:
                    DirectWrite(m_Spectrum1, "FREQ:CENT 920.125MHz");           //china2
                    System.Threading.Thread.Sleep(50);
                    break;
            }

            DirectWrite(m_Spectrum1, "FREQ:SPAN 50KHz");
            System.Threading.Thread.Sleep(100);
        }


        private void StartCalibration()
        {


            ByteBuilder bb = new ByteBuilder();

            UInt16 power = 200;
            double ReadData = 0;
            double StartPosition = 0;
            int tblSize = 0;

            if (RcpProtocol.Instance.m_bRcpReceivedPacket != false)
            {
                RcpProtocol.Instance.m_bRcpReceivedPacket = false;
            }

            if (!InvokeRequired)
            {
                lb_calConfirm.Text = "Processing";
                lb_calConfirm.ForeColor = Color.Blue;
                // return;
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                lb_calConfirm.Text = "Processing";
                lb_calConfirm.ForeColor = Color.Blue;
            }));

           

            if (!InvokeRequired)
            {
                StartPosition = Convert.ToDouble(comboBox_StartPosition.Text);
                // return;
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                StartPosition = Convert.ToDouble(comboBox_StartPosition.Text);
            }));


            int Range = 0;

            if (!InvokeRequired)
            {
                Range = Convert.ToInt32(comboBox_Range.Text);
                // return;
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                Range = Convert.ToInt32(comboBox_Range.Text);
            }));


            equipment_Setup();

            reader_operate();
            System.Threading.Thread.Sleep(100);
         

            for (int i = 0; i < MatchedOffset.Length; i++)
            {

                if (StartPosition == Range)
                {
                    tblSize = i + 1;
                }

                while (StartPosition >= Range)
                {

                    DirectWrite(m_Spectrum1, "CALC:MARK1:MAX");
                    System.Threading.Thread.Sleep(100);

                    DirectWrite(m_Spectrum1, "CALC:MARK1:Y?");
                    System.Threading.Thread.Sleep(100);

                    DirectRead(m_Spectrum1, ref temp, "0");


                    ReadData = temp;//(double)ioSpectrumAnalyzer.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    System.Threading.Thread.Sleep(100);


                    if (StartPosition < ReadData)
                    {
                        bb.Append((UInt16)(power--));
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_TX_PWR, bb.GetByteArray()))) { }
                        bb.Clear();
                        //System.Threading.Thread.Sleep(100);
                        bb.Clear();

                        WaitForReceived();
                    }
                    else
                    {
                        // MatchedOffset[j] = (power - 200f) / 10;
                        MatchedOffset[i] = power;
                        break;
                    }

                    if (power < 100) break;

                }

                StartPosition -= 0.5f;

            }

            if (!InvokeRequired)
            {
                StartPosition = Convert.ToDouble(comboBox_StartPosition.Text);
            }
            this.Invoke(new MethodInvoker(delegate()
            {
                StartPosition = Convert.ToDouble(comboBox_StartPosition.Text);
            }));


            for (int i = 0; i < MatchedOffset.Length; i++)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(StartPosition - (0.5 * i)));
                if (!InvokeRequired)
                {
                    lvi.SubItems.Add(Convert.ToString(MatchedOffset[i]));
                    this.listViewEx2.Items.Add(lvi);
                }
                this.Invoke(new MethodInvoker(delegate()
                {
                    lvi.SubItems.Add(Convert.ToString(MatchedOffset[i]));
                    this.listViewEx2.Items.Add(lvi);
                }));



            }


            //////////Reset / Registry Update /////////////    

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
            WaitForReceived();
          //  System.Threading.Thread.Sleep(100);


            System.Threading.Thread.Sleep(500);

            /////////Table Update//////

            // DisplayMsgString(Convert.ToString(tblSize));

            refModulePwr = new UInt16[tblSize];

            for (int j = 0; j < tblSize; j++)
            {
                refModulePwr[j] = MatchedOffset[j];
            }

            bb.Append((byte)(refModulePwr.Length * 2));

            for (int i = 0; i < refModulePwr.Length; i++)
            {
                bb.Append((UInt16)refModulePwr[i]);
            }

            if (!RcpProtocol.Instance.SendBytePkt
                    (RcpProtocol.Instance.BuildCmdPacketByte
                        (RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODULE_PWR_TBL, bb.GetByteArray()))) { }

            bb.Clear();

            WaitForReceived();
         //   System.Threading.Thread.Sleep(100);

            bb.Append(0x01);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_UPDATE_FLASH, bb.GetByteArray()))) { }

            WaitForReceived();
         //   System.Threading.Thread.Sleep(100);

           // float power = 0f;
            ///////////Calibration Confirmation////////////////////
            System.Threading.Thread.Sleep(500);
            cal_confirmation();

           
  

        }

        public void cal_confirmation()
        {
            ByteBuilder bb = new ByteBuilder();

            float power = 0f;
            double ReadData = 0;
            byte region = 0x11;
            byte[] param = new byte[2];
            double ConfirmData = 0;

            if (RcpProtocol.Instance.m_bRcpReceivedPacket != false)
            {
                RcpProtocol.Instance.m_bRcpReceivedPacket = false;
            }

            //switch ((string)cbRegion.SelectedItem)
            switch (regionVal)
            {
                case 0://"Korea":// Korea (0x11)
                    region = 0x11;
                    param[0] = 0x14;
                    param[1] = 0;
                    break;
                case 1://""US":// US (0x21)
                    region = 0x21;
                    param[0] = 1;
                    param[1] = 0;
                    break;
                case 2://""US2":// US2 (0x22)
                    region = 0x22;
                    param[0] = 0x19;
                    param[1] = 0;
                    break;
                case 3://""Europe":// Europe (0x31)
                    region = 0x31;
                    param[0] = 0x0A;
                    param[1] = 0;
                    break;
                case 4://""Japan":// Japan (0x41)
                    region = 0x41;
                    param[0] = 0x18;
                    param[1] = 0;
                    break;
                case 5://""China1":// China1 (0x51)
                    region = 0x51;
                    param[0] = 1;
                    param[1] = 0;
                    break;
                case 6://""China2":// China2 (0x52)
                    region = 0x52;
                    param[0] = 1;
                    param[1] = 0;
                    break;
            }

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_REGION, new byte[] { region }))) { return; }

            WaitForReceived();

            // System.Threading.Thread.Sleep(100);       

            if (param[1] < 10) param[1] = (byte)((byte)param[1] * ((byte)10));

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CH, param))) { }

            WaitForReceived();

            if (!InvokeRequired)
            {
                power = (float)(Convert.ToDouble(this.comboBox_StartPosition.Text));
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                //power = (float)(Convert.ToDouble((string)this.comboBox_StartPosition.SelectedItem));
                power = (float)(Convert.ToDouble(this.comboBox_StartPosition.Text));
            }));

         
            bb.Append((UInt16)((power) * 10));

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODULE_TX_PWR, bb.GetByteArray()))) { }
            bb.Clear();
            WaitForReceived();

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0xFF }))) { }
            
            WaitForReceived();

            System.Threading.Thread.Sleep(1000);

            DirectWrite(m_Spectrum1, "CALC:MARK1:MAX");
            System.Threading.Thread.Sleep(100);

            DirectWrite(m_Spectrum1, "CALC:MARK1:Y?");
            System.Threading.Thread.Sleep(100);

            DirectRead(m_Spectrum1, ref temp, "0");

            if (!InvokeRequired)
            {
                ConfirmData = Convert.ToDouble(comboBox_StartPosition.Text);
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                ConfirmData = Convert.ToDouble(comboBox_StartPosition.Text);
            }));

           

            ReadData = temp;//(double)ioSpectrumAnalyzer.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);

            if (ReadData <= ConfirmData+1 && ReadData >=  ConfirmData - 0.5f)
            {
                if (!InvokeRequired)
                {
                    lb_calConfirm.Text = "Pass";
                    lb_calConfirm.ForeColor = Color.Blue;
                    button_CP_TBL.Enabled = true;
                    
                    // return;
                }

                this.Invoke(new MethodInvoker(delegate()
                {
                    lb_calConfirm.Text = "Pass";
                    lb_calConfirm.ForeColor = Color.Blue;
                    button_CP_TBL.Enabled = true;
                }));
            }
            else
            {

                if (!InvokeRequired)
                {
                    lb_calConfirm.Text = "Fail";
                    lb_calConfirm.ForeColor = Color.Red;
                    button_CP_TBL.Enabled = true;

                    // return;
                }

                this.Invoke(new MethodInvoker(delegate()
                {
                    lb_calConfirm.Text = "Fail";
                    lb_calConfirm.ForeColor = Color.Red;
                    button_CP_TBL.Enabled = true;
                }));
            }

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0x00 }))) { }
            
            
            
        }


        public void SaveToFile(string filename)
        {
            
            string path = Directory.GetCurrentDirectory();

            string date = String.Format("{0}{1}{2}.{3}{4}{5}", DateTime.Now.Year.ToString("0000"), DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"), DateTime.Now.Hour.ToString("00"), DateTime.Now.Minute.ToString("00"), DateTime.Now.Second.ToString("00"));

            path += String.Format("\\{0}_{1}.csv", filename, date);

            try
            {
                Stream saveStream = File.Open(path, FileMode.Create, FileAccess.Write);
                StreamWriter saveWriter = new StreamWriter(saveStream);

                saveWriter.WriteLine(textBox_moduleName.Text);

                string temp_columns = "";

                for (int i = 0; i < listViewEx2.Columns.Count; i++)
                {
                    temp_columns += string.Format("\t{0}", this.listViewEx2.Columns[i].Text);
                }

                saveWriter.WriteLine(temp_columns);

                for (int j = 0; j < this.listViewEx2.Items.Count; j++)
                {
                    temp_columns = "";

                    for (int k = 0; k < this.listViewEx2.Columns.Count; k++)
                    {
                        temp_columns += string.Format("\t{0}", this.listViewEx2.Items[j].SubItems[k].Text);
                    }

                    saveWriter.WriteLine(temp_columns);
                }

                saveWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "내용이 없습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }

        private void button_ConnectGPIO_Click(object sender, System.EventArgs e)
        {
           
                if (m_Spectrum1.GpibOpen(Convert.ToInt16(tb_gpibNum.Text)))
                {
                    this.label_Information.Text = "MSG > Spectrum Analyzer 1 is connected\r\n";
                    DirectWrite(m_Spectrum1, "*RST");
                    DirectWrite(m_Spectrum1, "DISP:WIND:TRAC:Y:RLEV:OFFS 10dB");
                    DirectWrite(m_Spectrum1, "DISP:WIND:TRAC:Y:RLEV 30dBm");
                }
                else
                    this.label_Information.Text ="MSG > Spectrum Analyzer 1 is not connected\r\n";
               
        }

        private void button_StartCalibration_Click(object sender, EventArgs e)
        {
            newThread = new Thread(StartCalibration);

            try
            {
                newThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "실행할 수 없습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_CP_TBL_Click(object sender, EventArgs e)
        {
            //SaveToFile(textBox_moduleName.Text);
            ;
        }

        private double __gRange_minVal = 0f;
        private double __gRange_maxVal = 0f;
       

        public bool compare_DynamicRange(double min_range, double max_range)
        {

            ByteBuilder bb = new ByteBuilder();

            UInt16 minRange_power = 100;
            UInt16 maxRange_power = 200;

            bool dynmic_range_Flag = false;
          

            //  double margine_power = Convert.ToDouble(cmd_data[3]);

            double ReadData = 0f;

            bb.Append((UInt16)(minRange_power));
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_TX_PWR, bb.GetByteArray()))) { }
            bb.Clear();

            WaitForReceived();

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0xFF }))) { }

            WaitForReceived();

            System.Threading.Thread.Sleep(500);

            DirectWrite(m_Spectrum1, "CALC:MARK1:MAX");
            System.Threading.Thread.Sleep(100);

            DirectWrite(m_Spectrum1, "CALC:MARK1:Y?");
            System.Threading.Thread.Sleep(100);

            DirectRead(m_Spectrum1, ref temp, "0");


            ReadData = temp;//(double)ioSpectrumAnalyzer.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);

            System.Threading.Thread.Sleep(100);

            if (ReadData <= min_range && (ReadData > (min_range - 2)))
            {
                dynmic_range_Flag = true;
                __gRange_minVal = ReadData;
            }
            else
            {
                dynmic_range_Flag = false;
                return dynmic_range_Flag;
            }

            //System.Threading.Thread.Sleep(1000);

            bb.Append((UInt16)(maxRange_power));
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_TX_PWR, bb.GetByteArray()))) { }
            bb.Clear();

            WaitForReceived();

            System.Threading.Thread.Sleep(500);

            DirectWrite(m_Spectrum1, "CALC:MARK1:MAX");
            System.Threading.Thread.Sleep(100);

            DirectWrite(m_Spectrum1, "CALC:MARK1:Y?");
            System.Threading.Thread.Sleep(100);

            DirectRead(m_Spectrum1, ref temp, "0");


            ReadData = temp;//(double)ioSpectrumAnalyzer.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
            System.Threading.Thread.Sleep(100);

            // DisplayMsgString("max power :" + Convert.ToString(ReadData) + "\r\n");


            if (ReadData > (max_range + 0.8f))
            {
                dynmic_range_Flag = true;
                __gRange_maxVal = ReadData;
            }
            else
            {
                dynmic_range_Flag = false;
                return dynmic_range_Flag;
            }


            return dynmic_range_Flag;

        }

       
     
        private void fb_param_set(string[] fb_parm)
        {
            ByteBuilder bb = new ByteBuilder();

            byte txLPF;
            byte fb_res1;
            byte fb_res2;


            try
            {
                txLPF = Convert.ToByte(fb_parm[0]);
                fb_res1 = Convert.ToByte(fb_parm[1]);
                fb_res2 = Convert.ToByte(fb_parm[2]);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bb.Append(txLPF);
            bb.Append(fb_res1);
            bb.Append(fb_res2);


            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_FB_PARAM, bb.GetByteArray()))) { }
        }

        private void init_fb_label()
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;

            lb_dynmic_Rng.Text = "Processing";
        }

        private void regUpdate()
        {
            ByteBuilder bb = new ByteBuilder();
            bb.Append(0x01);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_UPDATE_FLASH, bb.GetByteArray()))) { }
        }

        private void button_Set_FB_Value_Click(object sender, EventArgs e)
        {
            double dymc_min ;//= Convert.ToDouble(cb_dynmc_rng_min.Text);
            double dymc_max ;//= Convert.ToDouble(cb_dynmc_rng_max.Text);
            string[] fb_parm = new string[3];
            //bool dynamicRngFlg = false;    

            dymc_min = Convert.ToDouble(this.cb_dynmc_rng_min.Text);
            dymc_max = Convert.ToDouble(this.cb_dynmc_rng_max.Text);

            if (!InvokeRequired)
            {
                regionVal = this.cb_region.SelectedIndex;
                // return;
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                regionVal = this.cb_region.SelectedIndex;
            }));

            init_fb_label();

            equipment_Setup();


            //Reference 1 Test
            fb_parm[0] = this.ref1_cb_txlpf.Text;
            fb_parm[1] = this.ref1_cb_fbRes1.Text;
            fb_parm[2] = this.ref1_cb_fbRes2.Text;
            label1.ForeColor = Color.Blue;

            fb_param_set(fb_parm);

            WaitForReceived();

            byte region = 0x11;
            byte[] param = new byte[2];            

            if (RcpProtocol.Instance.m_bRcpReceivedPacket != false)
            {
                RcpProtocol.Instance.m_bRcpReceivedPacket = false;
            }

            switch (regionVal)
            {
                case 0://"Korea":// Korea (0x11)
                    region = 0x11;
                    param[0] = 0x14;
                    param[1] = 0;
                    break;
                case 1://""US":// US (0x21)
                    region = 0x21;
                    param[0] = 1;
                    param[1] = 0;
                    break;
                case 2://""US2":// US2 (0x22)
                    region = 0x22;
                    param[0] = 0x19;
                    param[1] = 0;
                    break;
                case 3://""Europe":// Europe (0x31)
                    region = 0x31;
                    param[0] = 0x0A;
                    param[1] = 0;
                    break;
                case 4://""Japan":// Japan (0x41)
                    region = 0x41;
                    param[0] = 0x18;
                    param[1] = 0;
                    break;
                case 5://""China1":// China1 (0x51)
                    region = 0x51;
                    param[0] = 1;
                    param[1] = 0;
                    break;
                case 6://""China2":// China2 (0x52)
                    region = 0x52;
                    param[0] = 1;
                    param[1] = 0;
                    break;
            }

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_REGION, new byte[] { region }))) { }

            WaitForReceived();

            // System.Threading.Thread.Sleep(100);           

            if (param[1] < 10) param[1] = (byte)((byte)param[1] * ((byte)10));

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CH, param))) { }

            WaitForReceived();


            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label1.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";

                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }
            else
            {                
                fb_parm[0] = ref2_cb_txlpf.Text;
                fb_parm[1] = ref2_cb_fbRes1.Text;
                fb_parm[2] = ref2_cb_fbRes2.Text;
                label2.ForeColor = Color.Blue;
            }

            fb_param_set(fb_parm);

            WaitForReceived();

            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label2.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";
                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }
            else
            {
                fb_parm[0] = ref3_cb_txlpf.Text;
                fb_parm[1] = ref3_cb_fbRes1.Text;
                fb_parm[2] = ref3_cb_fbRes2.Text;
                label3.ForeColor = Color.Blue;
            }

            fb_param_set(fb_parm);
            WaitForReceived();

            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label3.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";
                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }
            else
            {
                fb_parm[0] = ref4_cb_txlpf.Text;
                fb_parm[1] = ref4_cb_fbRes1.Text;
                fb_parm[2] = ref4_cb_fbRes2.Text;
                label4.ForeColor = Color.Blue;
            }

            fb_param_set(fb_parm);
            WaitForReceived();

            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label4.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";
                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }
            else
            {
                fb_parm[0] = ref5_cb_txlpf.Text;
                fb_parm[1] = ref5_cb_fbRes1.Text;
                fb_parm[2] = ref5_cb_fbRes2.Text;
                label5.ForeColor = Color.Blue;
            }

            fb_param_set(fb_parm);
            WaitForReceived();

            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label5.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";
                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }
            else
            {
                fb_parm[0] = ref6_cb_txlpf.Text;
                fb_parm[1] = ref6_cb_fbRes1.Text;
                fb_parm[2] = ref6_cb_fbRes2.Text;
                label6.ForeColor = Color.Blue;
            }

            fb_param_set(fb_parm);
            WaitForReceived();

            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label6.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";
                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }
            else
            {
                fb_parm[0] = ref7_cb_txlpf.Text;
                fb_parm[1] = ref7_cb_fbRes1.Text;
                fb_parm[2] = ref7_cb_fbRes2.Text;
                label7.ForeColor = Color.Blue;
            }

            fb_param_set(fb_parm);
            WaitForReceived();

            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label7.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";
                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }
            else
            {
                fb_parm[0] = ref8_cb_txlpf.Text;
                fb_parm[1] = ref8_cb_fbRes1.Text;
                fb_parm[2] = ref8_cb_fbRes2.Text;
                label8.ForeColor = Color.Blue;
            }

            fb_param_set(fb_parm);
            WaitForReceived();

            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label8.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";
                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }
            else
            {
                fb_parm[0] = ref9_cb_txlpf.Text;
                fb_parm[1] = ref9_cb_fbRes1.Text;
                fb_parm[2] = ref9_cb_fbRes2.Text;
                label9.ForeColor = Color.Blue;
            }

            fb_param_set(fb_parm);
            WaitForReceived();

            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label9.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";
                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }
            else
            {
                fb_parm[0] = ref10_cb_txlpf.Text;
                fb_parm[1] = ref10_cb_fbRes1.Text;
                fb_parm[2] = ref10_cb_fbRes2.Text;
                label10.ForeColor = Color.Blue;
            }

            fb_param_set(fb_parm);
            WaitForReceived();

            if (compare_DynamicRange(dymc_min, dymc_max))
            {
                label10.ForeColor = Color.Red;
                lb_dynmic_Rng.Text = "PASS";
                ////Reset / FB SET / REG UPDATE ////
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
                WaitForReceived();
                //  System.Threading.Thread.Sleep(100)

                System.Threading.Thread.Sleep(500);

                fb_param_set(fb_parm);

                WaitForReceived();

                regUpdate();
                return;
            }

            lb_dynmic_Rng.Text = "FAIL";
            return;


        }

        private void WaitForReceived()
        {
            // RcpProtocol.Instance.m_bRcpReceived = false;
            for (int j = 0; j < 20; j++)
            {
                System.Threading.Thread.Sleep(20);
                if (RcpProtocol.Instance.m_bRcpReceivedPacket) break;
            }

            RcpProtocol.Instance.m_bRcpReceivedPacket = false;
        }

        private void cb_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            regionVal = cb_region.SelectedIndex;
        }

      

           

      
    }
}
