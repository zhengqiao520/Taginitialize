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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Phychips.Rcp;
using Phychips.Helper;
using BarChart;

namespace Phychips.PR9200
{
    public partial class ucHwControl : UserControl
    {
        public ucHwControl()
        {
            InitializeComponent();
        }

        private bool IsInitialized = false;

        public const byte PR9200 = 0x00;
        public const byte PRM92x = 0x01;        

        public const byte KOREA = 0x11;
        public const byte NORTHAMERICA = 0x21;
        public const byte EUROPE = 0x31;
        public const byte JAPAN = 0x41;
        public const byte CHINA = 0x51;
        public const byte BRAZIL1 = 0x61;

        public byte FirmwareType = PR9200;

        public byte ModuleType = 0x00;       

        public byte TargetBand = KOREA;

        public int curr_main, curr_sub, curr_fix;
        
        public float MaxPower = 25f;
        public float MinPower = 15f;
        public float CurrPower = 25f;

        public bool source = false;

        public string PARTNUMBER = string.Empty;

        FormChannelTable formChannelTable = new FormChannelTable();

        private void ucHwControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            this.cbChExt.Items.Clear();

            this.cbChExt.Items.AddRange(new object[] {
            "00",
            "50"});
            
            this.cbChExt.SelectedIndex = 0;

            IsInitialized = true;
            
            SetFreq();
        }

        public bool rSetFlag = false;

        public void ParseRsp(byte[] Data)
        {
            byte[] buf = Data;
            int len = (buf[3] << 8) + buf[4];
            int cmd_type = (int)buf[2];

            if (len > buf.Length - 5) len = buf.Length;
              
            if (Data.Length >= 8)
            {
                byte cmd = Data[2];

                switch (cmd)
                {
                    case RcpProtocol.RCP_CMD_GET_REGION:
                        
                        if (FirmwareType == PRM92x)
                        {
                            switch (TargetBand)
                            {
                                case KOREA:                                
                                    this.cbRegion.Items.Clear();

                                    this.cbRegion.Items.AddRange(new object[] {
                                        "Korea",
                                        "US",
                                        "Japan",
                                        "China2"});
                                   
                                    switch (buf[5])
                                    {
                                        case 0x11: // Korea (0x11)
                                            this.cbRegion.SelectedIndex = 0;
                                            break;
                                        case 0x22: // US
                                            this.cbRegion.SelectedIndex = 1;
                                            break;
                                        case 0x41:// Japan (0x41)
                                            this.cbRegion.SelectedIndex = 2;
                                            break;
                                        case 0x52:// China2 (0x52)
                                            this.cbRegion.SelectedIndex = 3;
                                            break;
                                    }
                                    break;
                                case EUROPE:
                                    this.cbRegion.Items.Clear();

                                    this.cbRegion.Items.AddRange(new object[] {
                                        "Europe"});

                                    cbRegion.SelectedIndex = 0;
                                    break;
                                case JAPAN:
                                    this.cbRegion.Items.Clear();

                                    this.cbRegion.Items.AddRange(new object[] {
                                        "Japan"});

                                    cbRegion.SelectedIndex = 0;
                                    break;
                                case NORTHAMERICA:
                                case BRAZIL1:
                                    this.cbRegion.Items.Clear();

                                    this.cbRegion.Items.AddRange(new object[] {
                                        "North America",
                                        "Brazil1"});

                                    switch (buf[5])
                                    {
                                        case 0x21: // North America
                                            this.cbRegion.SelectedIndex = 0;
                                            break;
                                        case 0x61: // Brazil1
                                            this.cbRegion.SelectedIndex = 1;
                                            break;
                                    }
                                    break;
                                default:
                                    this.cbRegion.Items.AddRange(new object[] {
                                        "Korea",
                                        "North America",
                                        "US",
                                        "Europe",
                                        "Japan",                                
                                        "China2",
                                        "Brazil1"});

                                    this.cbRegion.SelectedIndex = 0;
                                    break;
                            }
                        }
                        else
                        {
                            this.cbRegion.Items.Clear();

                            this.cbRegion.Items.AddRange(new object[] {
                                "Korea",
                                "North America",
                                "US",
                                "Europe",
                                "Japan",                                
                                "China2",
                                "Brazil1"});

                            switch (buf[5])
                            {
                                case 0x11: // Korea (0x11)
                                    this.cbRegion.SelectedIndex = 0;
                                    break;
                                case 0x21: // North America
                                    this.cbRegion.SelectedIndex = 1;
                                    break;
                                case 0x22: // US
                                    this.cbRegion.SelectedIndex = 2;
                                    break;
                                case 0x31:// EU (0x31)
                                    this.cbRegion.SelectedIndex = 3;
                                    break;
                                case 0x41:// Japan (0x41)
                                    this.cbRegion.SelectedIndex = 4;
                                    break;
                                case 0x52:// China2 (0x52)
                                    this.cbRegion.SelectedIndex = 5;
                                    break;
                                case 0x61:// Brazil1
                                    this.cbRegion.SelectedIndex = 6;
                                    break;
                            }
                        }
                        break;
                    case RcpProtocol.RCP_CMD_GET_CH:
                        {
                            this.cbCh.Text = buf[5].ToString();
                            this.cbChExt.Text = buf[6].ToString();
                        }

                        break;
                    case RcpProtocol.RCP_CMD_SCAN_RSSI:
                        {
                            FormScanRssi formScanRssi = new FormScanRssi();
                            formScanRssi.HbcRssi.Items.Maximum = 40;
                            formScanRssi.HbcRssi.Items.Minimum = 0;

                            formScanRssi.HbcRssi.Items.Clear();

                            for (int i = 0; i < (buf[6] - buf[5] + 1); i++)
                            {
                                formScanRssi.HbcRssi.Items.Add(new HBarItem((double)(90 - Data[i + 8]), (i + Data[5]).ToString(), Color.FromArgb(255, 190, 200, 255)));
                            }

                            formScanRssi.HbcRssi.RedrawChart();

                            cbCh.Text = buf[7].ToString();

                            formScanRssi.ShowDialog();
                        }
                        break;
                    case RcpProtocol.RCP_CMD_GET_TX_OFFSET:
                        {
                            int offset = (buf[5] << 8 | buf[6]);                            
                        }

                        break;
                    case RcpProtocol.RCP_CMD_GET_MODULE_TX_PWR:  // v1.0.4, Get Tx Power
                        {
                            UInt16 cur_pwr = (UInt16)((buf[5] << 8) | buf[6]);
                            UInt16 min_pwr = (UInt16)((buf[7] << 8) | buf[8]);
                            UInt16 max_pwr = (UInt16)((buf[9] << 8) | buf[10]);
                            setPowerValue(cur_pwr, min_pwr, max_pwr);
                        }
                        break;
                    case RcpProtocol.RCP_CMD_GET_MODULATION:
                        {
                            SetModulationValue(Data);                            
                        }
                        break;
                    case RcpProtocol.RCP_CMD_GET_RSSI:
                        {
                            Int16 rssi = (Int16)((Data[5] << 8) | Data[6]);
                            this.SetRssiVal(rssi);
                        }
                        break;
                    case RcpProtocol.RCP_CMD_GET_FH_LBT:
                        {
                            tbReadTime.Text = ((Data[5] << 8) | Data[6]).ToString();
                            tbIdleTime.Text = ((Data[7] << 8) | Data[8]).ToString();
                            tbCwSenseTime.Text = ((Data[9] << 8) | Data[10]).ToString();
                            tbLbtRfLevel.Text = ((float)((Int16)((Data[11] << 8) | Data[12])) / 10).ToString("F1");

                            if ((Data[13] == 1) && (Data[14] == 0)) cbFH.Checked = true;
                            else if ((Data[13] == 0) && (Data[14] == 1)) cbLBT.Checked = true;
                            else if ((Data[13] == 1) && (Data[14] == 1)) cbFHwithLBT.Checked = true;
                            else if ((Data[13] == 2) && (Data[14] == 1)) cbFHwithLBT.Checked = true;
                            else if ((Data[13] == 1) && (Data[14] == 2)) cbLBTwithFH.Checked = true;
                            else
                            {
                                cbFH.Checked = false;
                                cbLBT.Checked = false;
                                cbFHwithLBT.Checked = false;
                                cbLBTwithFH.Checked = false;
                            }
                        }                                            
                        break;
                    case RcpProtocol.RCP_CMD_GET_HOPPING_TBL:
                        SetFrequncyHopppingChannelTable(Data);
                        break;

                    case RcpProtocol.RCP_CMD_GET_MODULE_PWR_TBL:
                        SetModulePowerTable(Data);
                        break;
                }
            }
        }

        private void SetFrequncyHopppingChannelTable(byte[] data)
        {   
            int size = data[5];
            if (size > data.Length - 9) return;

            ByteBuilder ba = new ByteBuilder();

            for (int i = 6; i < size + 6; i++)
            {
                ba.Append(data[i]);
            }
            
            formChannelTable.SetChannel(ba.GetByteArray());

            if (formChannelTable.isDisplayed)
            {

            }
            else
            {
                formChannelTable.ShowDialog();                
            }                        
        }

        private void SetFreq()
        {
            if (!IsInitialized) return;

            float ch;
            float chext;
            float freq = 0.0f;
            
            try
            {
                ch = float.Parse(cbCh.Text);
                chext = float.Parse(cbChExt.Text);
            }
            catch
            {
                return;                
            }

            //if( chext < 10 ) chext = chext * 10;
                 
            switch ((string)cbRegion.SelectedItem)
            {
                case "Korea":// Korea (0x11)
                    freq = 917.1f + 0.2f * (ch - 1.0f);                    
                    break;
                case "North America":// North America (0x21)
                    freq = 902.75f + 0.5f * (ch - 1.0f);                     
                    break;
                case "US":// US (0x22)
                    freq = 917.10f + 0.2f * (ch - 1.0f);                    
                    break;
                case "Europe":// Europe (0x31)
                    freq = 865.1f + 0.2f * (ch - 1.0f);                     
                    break;
                case "Japan":// Japan (0x41)
                    freq = 916.0f + 0.2f * (ch - 1.0f);                    
                    break;
                case "China1":// China1 (0x51)
                    freq = 840.125f + 0.25f * ch;                    
                    break;
                case "China2":// China2 (0x52)                    
                    freq = 919.875f + 0.25f * ch;                    
                    break;
                case "Brazil1": // Brazil1 (0x61)
                    if (ch <= (float)38)
                    {
                        freq = 902.128f + 0.138f * (ch - 1.0f);
                    }
                    else if (ch <= (float)64)
                    {
                        freq = 915.128f + 0.167f * (ch - 39.0f);
                    }
                    else if (ch <= 90)
                    {
                        freq = 915.128f + 0.167f * (ch - 39.0f);
                    }
                    else if (ch <= 115)
                    {
                        freq = 915.128f + 0.167f * (ch - 39.0f);
                    }
                    break;
            }

            cbChExt.Enabled = false;
            lbFreqency.Text = freq.ToString();        
        }

        private void buttonSetCh_Click(object sender, EventArgs e)
        {
            byte[] param = new byte[2];
 
            try
            {
                param[0] = byte.Parse(cbCh.Text);
                param[1] = byte.Parse(cbChExt.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (param[1] < 10) param[1] = (byte) ((byte) param[1] * ( (byte) 10 ));
       
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CH, param))) { }
        }

        private void buttonSetTxPwr_Click(object sender, EventArgs e)
        {
            ByteBuilder bb = new ByteBuilder();
            float power = 0f;

            try
            {
                power = (float)Convert.ToDouble((string)cbTxPwr.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bb.Append((UInt16)(power*10));

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODULE_TX_PWR, bb.GetByteArray()))) { }
        }

        private void buttonFhssLbt_Click(object sender, EventArgs e)
        {
            ByteBuilder bb = new ByteBuilder();
            
            UInt16 read_time;
            UInt16 idle_time;
            UInt16 sense_time;
            float rf_level;
                        
            try
            {
                read_time = UInt16.Parse(tbReadTime.Text);
                idle_time = UInt16.Parse(tbIdleTime.Text);
                sense_time = UInt16.Parse(tbCwSenseTime.Text);
                rf_level = float.Parse(tbLbtRfLevel.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bb.Append(read_time);
            bb.Append(idle_time);
            bb.Append(sense_time);
            bb.Append((UInt16) (rf_level*10));

            if (cbFH.Checked)
            {
                bb.Append((byte)1);
                bb.Append((byte)0);                
            }

            if (cbLBT.Checked)
            {
                bb.Append((byte)0);
                bb.Append((byte)1);                
            }

            if (cbFHwithLBT.Checked)
            {
                bb.Append((byte)2);
                bb.Append((byte)1);                
            }

            if (cbLBTwithFH.Checked)
            {
                bb.Append((byte)1);
                bb.Append((byte)2);                
            }

            if (cbFH.Checked == false && cbLBT.Checked == false && cbFHwithLBT.Checked == false && cbLBTwithFH.Checked == false)
            {
                bb.Append((byte)0);
                bb.Append((byte)0);
                bb.Append((byte)0);
            }

            //if (cbCW.Checked) bb.Append((byte)1);
            else bb.Append((byte)0);
            
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_FH_LBT, bb.GetByteArray()))) { }
        }

        private void buttonRegionSet_Click(object sender, EventArgs e)
        {
            byte region = 0x01;

            switch ((string)cbRegion.SelectedItem)
            {
                case "Korea":// Korea (0x11)
                    region = 0x11;
                    break;
                case "North America":// North America (0x21)
                    region = 0x21;                    
                    break;
                case "US":// US (0x22)
                    region = 0x22;
                    break;
                case "Europe":// Europe (0x31)
                    region = 0x31;                    
                    break;
                case "Japan":// Japan (0x41)
                    region = 0x41;
                    break;
                case "China1":// China1 (0x51)
                    region = 0x51;                    
                    break;
                case "China2":// China2 (0x52)
                    region = 0x52;                    
                    break;
                case "Brazil1":// Brazil1
                    region = 0x61;
                    break;
            }

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_REGION, new byte[] { region }))) { return; }
        }

        private void buttonRssi_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_RSSI, null))) { }
        }

        internal void SetRssiVal(Int16 rssi)
        {
            float val = (float)rssi/10;
            this.buttonRssi.Text = "Current Channel RSSI is " + "-"+val.ToString("F1") + " dBm";
        }

        private void buttonScanRssi_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SCAN_RSSI, null))) { }
        }

        private void cbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCh.Items.Clear();

            switch ((string)cbRegion.SelectedItem)
            {
                case "Korea":// Korea (0x11)
                    for (int i = 1; i <= 32; i++) cbCh.Items.Add(i.ToString());                    
                    break;
                case "North America":// North America (0x21)
                    for (int i = 1; i <= 50; i++) cbCh.Items.Add(i.ToString());                    
                    break;
                case "US":// US (0x22)
                    for (int i = 1; i <= 50; i++) cbCh.Items.Add(i.ToString());
                    break;
                case "Europe":// Europe (0x31)
                    cbCh.Items.Add("4");
                    cbCh.Items.Add("7");
                    cbCh.Items.Add("10");
                    cbCh.Items.Add("13");                                    
                    break;
                case "Japan":// Japan (0x41)
                    if (FirmwareType == PRM92x)
                    {
                        for (int i = 24; i <= 38; i++) cbCh.Items.Add(i.ToString());
                    }
                    else
                    {
                        for (int i = 1; i <= 38; i++) cbCh.Items.Add(i.ToString());
                    }
                    break;
                case "China1":// China1 (0x51)
                    for (int i = 0; i <= 19; i++) cbCh.Items.Add(i.ToString());                    
                    break;
                case "China2":// China2 (0x52)
                    for (int i = 1; i <= 20; i++) cbCh.Items.Add(i.ToString());                    
                    break;
                case "Brazil1":
                    for (int i = 1; i <= 115; i++) cbCh.Items.Add(i.ToString());
                    break;
            }
                        
            cbCh.SelectedIndex = 0;

            SetFreq();
        }

        private void cbCh_TextChanged(object sender, EventArgs e)
        {
            SetFreq();
        }

        private void cbChExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFreq();
        }

        private void cbCH_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFreq();
        }
        
        private void buttonRegionGet_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_REGION, null))) { }
            System.Threading.Thread.Sleep(50);
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_CH, null))) { }

            this.buttonRegionSet.Enabled = true;
        }

        private void buttonGetCh_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_CH, null))) { }
            this.buttonSetCh.Enabled = true;
        }

        private void buttonTxOn_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0xFF }))) { }
        }

        private void buttonTxOff_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0x00 }))) { }
        }

        private void buttonTpEnable_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x0F, 0x0F, 0x0F }))) { }

            System.Threading.Thread.Sleep(20);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x43, 0x43, 0x7F }))) { }

            System.Threading.Thread.Sleep(20);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODEM_REG, new byte[] { 0xFF, 0xFF, 0x03, 0x28 }))) { }
        }

        new public void Visible()
        {
            this.buttonTpEnable.Visible = true;
        }

        private void buttonGetTxPower_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_MODULE_TX_PWR, null))) { }
            this.buttonSetTxPwr.Enabled = true;
        }

        private void buttonGetFhLbt_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_FH_LBT, null))) { }
            this.buttonFhLbt.Enabled = true;
        }

        private void buttonGetFrequencyTable_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_HOPPING_TBL, null))) { }
        }

        public void InvisibleAdvanced()
        {
            this.buttonGetRegion.Visible = true;
            this.buttonGetCh.Visible = true;
            this.buttonGetTxPower.Visible = true;
            this.buttonGetFhLbt.Visible = true;
            this.buttonGetModulationType.Visible = true;

            this.groupBoxTestFunction.Visible = true;
            
            this.comboBoxModulationType.Items.Clear();

            this.comboBoxModulationType.Items.AddRange(new object[] {"High Speed (M2, 250kHz)",
                                                                     "Multi-tag (M4, 250kHz)",
                                                                     "High Sensitivity (M8, 250kHz)"});

            comboBoxModulationType.SelectedIndex = 1;
        }

        private void buttonSetModulationType_Click(object sender, EventArgs e)
        {
            byte[] data = {0, 0, 0, 0, 0};

            string modulation = this.comboBoxModulationType.SelectedItem.ToString();

            data[0] = 0xff;

            if (modulation == "FM0, 40kHz")
            {
                data[1] = 0x00;
                data[2] = 0x28;
                data[3] = 0x00;
                data[4] = 0x00;
            }
            else if (modulation == "FM0, 80kHz")
            {
                data[1] = 0x00;
                data[2] = 0x50;
                data[3] = 0x00;
                data[4] = 0x00;
            }
            else if (modulation == "FM0, 160kHz")
            {
                data[1] = 0x00;
                data[2] = 0xA0;
                data[3] = 0x00;
                data[4] = 0x01;
            }
            else if (modulation == "FM0, 250kHz")
            {
                data[1] = 0x00;
                data[2] = 0xFA;
                data[3] = 0x00;
                data[4] = 0x01;
            }
            else if (modulation == "FM0, 320kHz")
            {
                data[1] = 0x01;
                data[2] = 0x40;
                data[3] = 0x00;
                data[4] = 0x01;
            }
            else if (modulation == "FM0, 640kHz")
            {
                data[1] = 0x02;
                data[2] = 0x80;
                data[3] = 0x00;
                data[4] = 0x01;
            }
            else if (modulation == "M2, 40kHz")
            {
                data[1] = 0x00;
                data[2] = 0x28;
                data[3] = 0x01;
                data[4] = 0x00;
            }
            else if (modulation == "M2, 80kHz")
            {
                data[1] = 0x00;
                data[2] = 0x50;
                data[3] = 0x01;
                data[4] = 0x00;
            }
            else if (modulation == "M2, 160kHz")
            {
                data[1] = 0x00;
                data[2] = 0xA0;
                data[3] = 0x01;
                data[4] = 0x01;
            }
            else if (modulation == "High Speed (M2, 250kHz)")
            {
                data[1] = 0x00; 
                data[2] = 0xFA;
                data[3] = 0x01;
                data[4] = 0x01;
            }
            else if (modulation == "M2, 320kHz")
            {
                data[1] = 0x01;
                data[2] = 0x40;
                data[3] = 0x01;
                data[4] = 0x01;
            }
            else if (modulation == "M2, 640kHz")
            {
                data[1] = 0x02;
                data[2] = 0x80;
                data[3] = 0x01;
                data[4] = 0x01;
            }
            else if (modulation == "M4, 40kHz")
            {
                data[1] = 0x00;
                data[2] = 0x28;
                data[3] = 0x02;
                data[4] = 0x00;
            }
            else if (modulation == "M4, 80kHz")
            {
                data[1] = 0x00;
                data[2] = 0x50;
                data[3] = 0x02;
                data[4] = 0x00;
            }
            else if (modulation == "M4, 160kHz")
            {
                data[1] = 0x00;
                data[2] = 0xA0;
                data[3] = 0x02;
                data[4] = 0x01;
            }
            else if (modulation == "Multi-tag (M4, 250kHz)")
            {
                data[1] = 0x00;
                data[2] = 0xFA;
                data[3] = 0x02;
                data[4] = 0x01;
            }
            else if (modulation == "M4, 320kHz")
            {
                data[1] = 0x01;
                data[2] = 0x40;
                data[3] = 0x02;
                data[4] = 0x01;
            }
            else if (modulation == "M4, 640kHz")
            {
                data[1] = 0x02;
                data[2] = 0x80;
                data[3] = 0x02;
                data[4] = 0x01;
            }
            else if (modulation == "M8, 40kHz")
            {
                data[1] = 0x00;
                data[2] = 0x28;
                data[3] = 0x03;
                data[4] = 0x00;
            }
            else if (modulation == "M8, 80kHz")
            {
                data[1] = 0x00;
                data[2] = 0x50;
                data[3] = 0x03;
                data[4] = 0x00;
            }
            else if (modulation == "M8, 160kHz")
            {
                data[1] = 0x00;
                data[2] = 0xA0;
                data[3] = 0x03;
                data[4] = 0x01;
            }
            else if (modulation == "High Sensitivity (M8, 250kHz)")
            {
                data[1] = 0x00;
                data[2] = 0xFA;
                data[3] = 0x03;
                data[4] = 0x01;
            }
            else if (modulation == "M8, 320kHz")
            {
                data[1] = 0x01;
                data[2] = 0x40;
                data[3] = 0x03;
                data[4] = 0x01;
            }
            else if (modulation == "M8, 640kHz")
            {
                data[1] = 0x02;
                data[2] = 0x80;
                data[3] = 0x03;
                data[4] = 0x01;
            }
            else if (modulation == "High Speed")
            {
                data[1] = 0x00;
                data[2] = 0xA0;
                data[3] = 0x01;
                data[4] = 0x01;
            }
            else if (modulation == "High Sensitivity")
            {
                data[1] = 0x00;
                data[2] = 0xA0;
                data[3] = 0x03;
                data[4] = 0x01;
            }

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODULATION, data))) { }
        }

        private void buttonGetModulationType_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_MODULATION, null))) { }
            this.buttonSetModulationType.Enabled = true;
        }

        private void SetModulationValue(byte[] Data)
        {
            try
            {
                if ((Data[5] == 0x00) && (Data[6] == 0xFA) && (Data[7] == 0x01))
                    this.comboBoxModulationType.SelectedIndex = 0;      // M2, 250kHz (High Speed)
                else if ((Data[5] == 0x00) && (Data[6] == 0xFA) && (Data[7] == 0x02))
                    this.comboBoxModulationType.SelectedIndex = 1;      // M4, 250kHz (Multi-tag)
                else if ((Data[5] == 0x00) && (Data[6] == 0xFA) && (Data[7] == 0x03))
                    this.comboBoxModulationType.SelectedIndex = 2;      // M8, 250kHz (High Sensitivity)
                else
                    this.comboBoxModulationType.SelectedIndex = 1;
            }
            catch
            {

            }
        }

        public void VisiblePowerOffset_Table()
        {
            //this.gb_offset_pwrTbl.Visible = true;     
        }

        public void VisiableTPEnable()
        {
            this.buttonTpEnable.Visible = true;
        }

        private void buttonGetTxOffset_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_TX_OFFSET, null))) { }
        }

        private void buttonSetTxGainOffset_Click(object sender, EventArgs e)
        {
            try
            {
                ByteBuilder bb = new ByteBuilder();
                
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_TX_OFFSET, bb.GetByteArray()))) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void button_update_pwr_lv_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_MODULE_PWR_TBL, null))) { }
        }

        public UInt16[] refModulePwr = null;
        double[] aCalOffsetTbl = new double[21];

        private void SetModulePowerTable(byte[] data)
        {
            int size = data[5];
            if (size > data.Length - 9) return;

            refModulePwr = new UInt16[(size >> 1)];

            ByteBuilder ba = new ByteBuilder();

            for (int i = 0; i < (size >> 1); i++)
            {                
                refModulePwr[i] = Convert.ToUInt16(data[(i * 2) + 6] << 8);
                refModulePwr[i] += data[i * 2 + 7];
            }

            FormPowerLevellTable formPowerLevelTable = new FormPowerLevellTable();

            formPowerLevelTable.SetPowerLevel(refModulePwr, aCalOffsetTbl);

            if (formPowerLevelTable.ShowDialog() == DialogResult.OK)
            {
                refModulePwr = (UInt16[])formPowerLevelTable.APower.Clone();

                ba.Clear();
                ba.Append((byte)(refModulePwr.Length * 2));

                for (int i = 0; i < refModulePwr.Length; i++)
                {
                    ba.Append((UInt16)refModulePwr[i]);
                }

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODULE_PWR_TBL, ba.GetByteArray()))) { }
            }
        }

        private void cbFH_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbFH.Checked)
            {
                this.cbFHwithLBT.Checked = false;
                this.cbLBT.Checked = false;
                this.cbLBTwithFH.Checked = false;
            }
        }

        private void cbLBT_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbLBT.Checked)
            {
                this.cbFH.Checked = false;
                this.cbFHwithLBT.Checked = false;
                this.cbLBTwithFH.Checked = false;
            }
        }

        private void cbFHwithLBT_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbFHwithLBT.Checked)
            {
                this.cbFH.Checked = false;
                this.cbLBT.Checked = false;
                this.cbLBTwithFH.Checked = false;
            }
        }

        private void cbLBTwithFH_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbLBTwithFH.Checked)
            {
                this.cbFH.Checked = false;
                this.cbFHwithLBT.Checked = false;
                this.cbLBT.Checked = false;
            }
        }

        public void setRegionList(string s)
        {            
            this.PARTNUMBER = s;
            string[] sa = s.Split('-');

            this.cbRegion.Items.Clear();
            
            if (this.ModuleType == 0x04)        //  Module Support All Band
            {
                this.cbRegion.Items.AddRange(new object[] { "Korea",
                                                            "North America",
                                                            "US",
                                                            "Europe",
                                                            "Japan",
                                                            "China2",
                                                            "Brazil1"});
            }
            else                        //  Module has only one SAW Filter
            {                
                if ((sa[0].IndexOf("J") >= 0) || (sa[0].IndexOf("K") >= 0) || (sa[0].IndexOf("U") >= 0) || (sa[0].IndexOf("C") >= 0))
                {
                    this.cbRegion.Items.AddRange(new object[] { "Korea",                                                            
                                                                "US",
                                                                "Japan",
                                                                "China2"});
                }
                else if (sa[0].IndexOf("E") >= 0)
                {
                    this.cbRegion.Items.AddRange(new object[] { "Europe" });
                }
                else if ((sa[0].IndexOf("N") >= 0) || (sa[0].IndexOf("B") >= 0))
                {
                    this.cbRegion.Items.AddRange(new object[] { "North America",
                                                                "Brazil1"});
                }
            }                    
        }

        public void setRegionValue(byte region)
        {
            string[] sa = this.PARTNUMBER.Split('-');

            string s = string.Empty;

            for (int i = 0; i < sa[0].Length; i++)
            {
                s += sa[0][i];
            }

            if ((this.ModuleType == 0x04) || (s.IndexOf('M') >= 0))                    //  Module Support All Band
            {
                switch (region)
                {
                    case 0x11: // Korea
                        this.cbRegion.SelectedIndex = 0;
                        break;
                    case 0x21: // North America
                        this.cbRegion.SelectedIndex = 1;
                        break;
                    case 0x22: // US
                        this.cbRegion.SelectedIndex = 2;
                        break;
                    case 0x31: // Europe
                        this.cbRegion.SelectedIndex = 3;
                        break;
                    case 0x41: // Japan
                        this.cbRegion.SelectedIndex = 4;
                        break;
                    case 0x52: // China2 (0x52)
                        this.cbRegion.SelectedIndex = 5;
                        break;
                    case 0x61: // Brazil
                        this.cbRegion.SelectedIndex = 6;
                        break;
                }
            }
            else                                    //  Module has only one SAW Filter
            {
                if ((s.IndexOf("J") >= 0) || (s.IndexOf("K") >= 0) || (s.IndexOf("U") >= 0) || (s.IndexOf("C") >= 0))
                {
                    switch (region)
                    {
                        case 0x11: // Korea
                            this.cbRegion.SelectedIndex = 0;
                            break;
                        case 0x22: // US
                            this.cbRegion.SelectedIndex = 1;
                            break;
                        case 0x41: // Japan
                            this.cbRegion.SelectedIndex = 2;
                            break;
                        case 0x52: // China2 (0x52)
                            this.cbRegion.SelectedIndex = 3;
                            break;
                    }
                }
                else if (s.IndexOf("E") >= 0)
                {
                    this.cbRegion.SelectedIndex = 0;
                }
                else if (s.IndexOf("N") >= 0 || (s.IndexOf("B") >= 0))
                {
                    switch (region)
                    {
                        case 0x21: // North America
                            this.cbRegion.SelectedIndex = 0;
                            break;
                        case 0x61: // Brazil1
                            this.cbRegion.SelectedIndex = 1;
                            break;
                    }                  
                }
            }             
        }

        public void setChannelValue(byte ch, byte chExt)
        {
            this.cbCh.Text = ch.ToString();
            this.cbChExt.Text = chExt.ToString();
        }

        public void setFhLbtValue(UInt16 readTime, UInt16 IdleTime, UInt16 senseTime, Int16 rfLevel, byte fh, byte lbt, byte cw)
        {
            tbReadTime.Text = readTime.ToString();
            tbIdleTime.Text = IdleTime.ToString();
            tbCwSenseTime.Text = senseTime.ToString();
            tbLbtRfLevel.Text = ((float)(rfLevel / 10)).ToString("F1");

            if ((fh == 1) && (lbt == 0)) cbFH.Checked = true;
            else if ((fh == 0) && (lbt == 1)) cbLBT.Checked = true;
            else if ((fh == 1) && (lbt == 1)) cbFHwithLBT.Checked = true;
            else if ((fh == 2) && (lbt == 1)) cbFHwithLBT.Checked = true;
            else if ((fh == 1) && (lbt == 2)) cbLBTwithFH.Checked = true;
            else
            {
                cbFH.Checked = false;
                cbLBT.Checked = false;
                cbFHwithLBT.Checked = false;
                cbLBTwithFH.Checked = false;
            }
        }

        public void setPowerValue(UInt16 cur_pwr, UInt16 min_pwr, UInt16 max_pwr)
        {
            this.cbTxPwr.Items.Clear();
            int tableLen = ((max_pwr - min_pwr) / 10) * 2;

            for (int i = 0; i <= tableLen; i++)
            {
                cbTxPwr.Items.Add(((float)((float)max_pwr/(float)10 - (0.5 * (float)i))).ToString("F1"));
            }
            /*
            for (int i = 0; i <= tableLen; i++)
            {
                cbTxPwr.Items.Add(((float)(iTxRefPwr - (0.5 * (float)i))).ToString("F1"));
            }
            */

            for (int i = 0; i <= tableLen; i++)
            {
                this.cbTxPwr.SelectedIndex = 0;

                if (cbTxPwr.Items[i].ToString() == (((float)(cur_pwr / (float)10)).ToString("F1")))
                {
                    this.cbTxPwr.SelectedIndex = i;
                    break;
                }
            }
        }

        public void SetModulationValue(UInt16 blf, byte rx_mod, byte rx_dr)
        {
            try
            {
                if ((blf == 0x00FA) && (rx_mod == 0x01))
                    this.comboBoxModulationType.SelectedIndex = 0;      // M2, 250kHz (High Speed)
                else if ((blf == 0x00FA) && (rx_mod == 0x02))
                    this.comboBoxModulationType.SelectedIndex = 1;      // M4, 250kHz (Multi-tag)
                else if ((blf == 0x00FA) && (rx_mod == 0x03))
                    this.comboBoxModulationType.SelectedIndex = 2;      // M8, 250kHz (High Sensitivity)
                else
                    this.comboBoxModulationType.SelectedIndex = 1;
            }
            catch
            {

            }
        }

        public int GetcbchLength
        {
            get
            {
                return cbCh.Items.Count;
            }
        }
    }
}
