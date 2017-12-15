using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Phychips.Rcp;

namespace Phychips.PR9200
{
    public partial class FormTxLeakagePlot : Form
    {
        public static bool TxLeakageTest = false;
        public static bool TxLRP_Rx_Flag = false;
        
        public bool m_bTestProcess = false;
        
        private int refL;
        private int chCnt;
        private int currentPlotCh = 0;

        private bool pbLRPStatus = false;
        private bool SinglePlotDisplayed = false;
        private bool MultiPlotDisplayed = false;
        
        System.Timers.Timer RxCheckTimer = new System.Timers.Timer();

        System.Threading.Thread threadFullScan;

        FormTLRPprocess formProcess = new FormTLRPprocess();

        TxLeakageRSSI tlr = new TxLeakageRSSI();
        LinkedList ll = new LinkedList();

        public FormTxLeakagePlot()
        {
            InitializeComponent();

            this.comboBoxChStep.SelectedIndex = 0;
            this.radioButtonSingleCh.Checked = true;

            formProcess.SendMsg += new FormTLRPprocess.SendMsgDele(_SendMsg);

            RxCheckTimer.Interval = 1 * 100;
            RxCheckTimer.Elapsed += RxCheckTimer_Elapsed;
        }

        void _SendMsg(bool AbortFlag)
        {
            if (AbortFlag)
            {
                if (threadFullScan.IsAlive)
                {
                    threadFullScan.Abort();                    
                    formProcess.Hide();                    
                    this.Enabled = true;
                }
            }
        }

        public void SetDefaultMeaurementParameter(int[] temp)
        {            
            this.chCnt = temp.Length;

            SetComboboxStrtCh(temp);
            SetComboboxEndch(temp);
            
            this.comboBoxStrtCh.SelectedIndex = 0;
            this.comboBoxEndCh.SelectedIndex = 0;
        }

        public int DefaultInductorVal
        {
            set
            {
                this.refL = value - 1;

                try
                {
                    this.comboBoxRange.SelectedIndex = this.refL;
                }
                catch
                {
 
                }
            }
        }

        private void SetComboboxStrtCh(int[] item)
        {
            comboBoxStrtCh.Items.Clear();

            for (int i = 0; i < item.Length; i ++)
            {
                comboBoxStrtCh.Items.Add(item[i].ToString());
            }
        }

        private void SetComboboxEndch(int[] item)
        {
            comboBoxEndCh.Items.Clear();

            for (int i = 0; i < item.Length; i++)
            {
                comboBoxEndCh.Items.Add(item[i].ToString());
            }
        }

        private void radioButtonSingleCh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonSingleCh.Checked == true)
            {
                this.comboBoxEndCh.Enabled = false;
                this.comboBoxEndCh.SelectedIndex = this.comboBoxStrtCh.SelectedIndex;
            }
        }

        private void radioButtonMultiCh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonMultiCh.Checked == true)
            {
                this.comboBoxEndCh.Enabled = true;
            }
        }

        private int StartChVal = 0;
        private int EndChVal = 0;
        private int ChStep = 0;
        private int Range = 0;

        private void comboBoxStrtCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = 0;

            if (this.radioButtonSingleCh.Checked == true)
            {
                this.comboBoxEndCh.SelectedIndex = this.comboBoxStrtCh.SelectedIndex;
            }
            
            if (this.comboBoxStrtCh.SelectedIndex > this.comboBoxEndCh.SelectedIndex)
            {
                temp = this.comboBoxEndCh.SelectedIndex;
                this.comboBoxEndCh.SelectedIndex = this.comboBoxStrtCh.SelectedIndex;
                this.comboBoxStrtCh.SelectedIndex = temp;
            }
        }

        private void comboBoxEndCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = 0;

            if (this.comboBoxStrtCh.SelectedIndex > this.comboBoxEndCh.SelectedIndex)
            {
                temp = this.comboBoxEndCh.SelectedIndex;
                this.comboBoxEndCh.SelectedIndex = this.comboBoxStrtCh.SelectedIndex;
                this.comboBoxStrtCh.SelectedIndex = temp;
            }
        }
        
        double cur_ch = 1;        
        double[] RSSI = new double[51];

        const int RSSI_MAX = 65535;                

        private void buttonMeasure_Click(object sender, EventArgs e)
        {
            if (ll.head != null)
            {
                if (MessageBox.Show("Current Data will be Refreshed. Continue?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    StartMeasure();
                }
            }
            else
            {
                StartMeasure();
            }
        }

        public void ParseRsp(byte[] Data)
        {
            byte[] buf = Data;
            int len = (buf[3] << 8) + buf[4];
            int cmd_type = (int)buf[2];

            if (len > buf.Length - 5) len = buf.Length;

            StringBuilder hsb = new StringBuilder();

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

            if (buf.Length >= 8)
            {
                byte cmd = buf[2];

                switch (cmd)
                {
                    case RcpProtocol.RCP_CMD_GET_MODEM_REG:
                        if (buf[5] == 0x91 && buf[6] == 0x92)
                        {
                            calRSSI(Data[8], Data[9]);
                            storeRSSIValue(Data);
                        }
                        break;
                }
            }
            
            TxLRP_Rx_Flag = true;
        }

        private void WaitForReceived()
        {
            RxCheckTimer.Start();
            while (!TxLRP_Rx_Flag)
            {
                
            }
            RxCheckTimer.Stop();            
        }

        private void FullScan()
        {
            byte i_dtc_112, i_dtc_113;
            DateTime current = DateTime.Now;            
            byte[] DTC_POINT = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                               10,11,12,13,14,15,16,17,18,19,
                               20,21,22,23,24,25,26,27,28,29,
                               30,31};
            
            TxLeakageTest = true;
            m_bTestProcess = true;
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_LEAK_CAL_MODE, new byte[] { 0 })))
            {
            }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            // Set RX Gain
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x01, 0x04, 0x1C, 0x00, 0x1C, 0x00 })))
            {
            }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            // Set DCOC
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x10, 0x11, 0xFF, 0xFF })))
            {
            }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            // Disable AGC
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODEM_REG, new byte[] { 0xE0, 0xE0, 0x03, 0x58 })))
            {
            }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            // Set Inductor
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_INDUCTOR, new byte[] { (byte)Range })))
            {
            }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            // CW ON
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0xFF }))) { }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            for (int i = StartChVal; i <= EndChVal; i = i + ChStep)
            {
                tlr = new TxLeakageRSSI();

                RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CH, new byte[] { (byte)i, 0 }));
                System.Threading.Thread.Sleep(500);                

                InitProcessState();

                for (i_dtc_112 = 0; i_dtc_112 < DTC_POINT.Length; i_dtc_112++)
                {
                    for (i_dtc_113 = 0; i_dtc_113 < DTC_POINT.Length; i_dtc_113++)
                    {                        
                        // Set DTC Value (Address == 112)
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_DTC, new byte[] { 0x70, DTC_POINT[i_dtc_112] }))) { }
                        WaitForReceived(); TxLRP_Rx_Flag = false;

                        // Set DTC Value (Address = 113)
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_DTC, new byte[] { 0x71, DTC_POINT[i_dtc_113] }))) { }
                        WaitForReceived(); TxLRP_Rx_Flag = false;

                        // Set RSSI Enable
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODEM_REG, new byte[] { 0x90, 0x90, 0x03, 0x22 }))) { }
                        WaitForReceived(); TxLRP_Rx_Flag = false;

                        // Get RSSI
                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_MODEM_REG, new byte[] { 0x91, 0x92, 0x03 }))) { }
                        WaitForReceived(); TxLRP_Rx_Flag = false;

                        UpdateProcessState();
                    }
                }
                ll.addToHead(tlr.TLRval, i);
            }            

            System.Threading.Thread.Sleep(30);

            // CW Off
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_CW, new byte[] { 0x00 }))) { }
            m_bTestProcess = false;
            System.Threading.Thread.Sleep(100);

            // Set RX Gain
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x01, 0x04, 0xDC, 0x00, 0xDC, 0x00 })))
            {
            }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            // Enable AGC
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODEM_REG, new byte[] { 0xE0, 0xE0, 0x03, 0x59 })))
            {
            }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            // Set DCOC
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_RF_REG, new byte[] { 0x10, 0x11, 0xF0, 0x7F })))
            {
            }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            // Enable Tx Leakage RSSI Report (Code:0xCA)

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_LEAK_CAL_MODE, new byte[] { 1 })))
            {
            }
            WaitForReceived(); TxLRP_Rx_Flag = false;

            TxLeakageTest = false;

            HideProcessState();
        }

        private void calRSSI(byte rssi_i, byte rssi_q)
        {
            double rssi = Math.Sqrt((rssi_i * rssi_i) + (rssi_q * rssi_q));
            rssi = 20 * Math.Log10(rssi);            
            RSSI[(int)cur_ch] = rssi;            
        }

        int DTC1_idx = 0,
            DTC2_idx = 31;

        private void storeRSSIValue(byte[] Data)
        {
            byte rssi_i, rssi_q;
            double rssi;

            if (Data.Length < 8)
            {
            }
            else
            {
                rssi_i = Data[8];
                rssi_q = Data[9];

                rssi = Math.Sqrt((rssi_i * rssi_i) + (rssi_q * rssi_q));

                tlr.TLRval[DTC1_idx, DTC2_idx] = rssi;
                DTC2_idx--;

                if (DTC2_idx < 0)
                {
                    DTC1_idx++;
                    DTC2_idx = 31;
                }
                if (DTC1_idx >= 32)
                {
                    DTC1_idx = 0;
                    DTC2_idx = 31;
                }
            }
        }

        private void StartMeasure()
        {
            StartChVal = int.Parse(this.comboBoxStrtCh.SelectedItem.ToString());
            EndChVal = int.Parse(this.comboBoxEndCh.SelectedItem.ToString());
            ChStep = int.Parse(this.comboBoxChStep.SelectedItem.ToString());
            Range = this.comboBoxRange.SelectedIndex + 1;

            formProcess.progressBarTotal.Maximum = 0;
            formProcess.progressBarCurrent.Maximum = 1024;

            lvPlotOption.Items.Clear();
            
            //ll.head = null;

            tlr = new TxLeakageRSSI();
            ll = new LinkedList();

            DTC1_idx = 0;
            DTC2_idx = 31;

            for (int i = StartChVal; i <= EndChVal; i = i + ChStep)
            {
                lvPlotOption.Items.Add(i.ToString());
                formProcess.progressBarTotal.Maximum += 1024;
            }

            formProcess.Show();

            if ((threadFullScan == null) || (threadFullScan.IsAlive == false))
            {
                threadFullScan = new System.Threading.Thread(new System.Threading.ThreadStart(FullScan));
                this.Enabled = false;
                threadFullScan.Start();
            }
        }

        private void InitProcessState()
        {
            if (!this.InvokeRequired)
            {
                formProcess.progressBarCurrent.Value = 0;
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                formProcess.progressBarCurrent.Value = 0;
            }));
        }

        private void UpdateProcessState()
        {
            if (!this.InvokeRequired)
            {
                formProcess.progressBarTotal.Value++;
                formProcess.progressBarCurrent.Value++;
            }

            this.Invoke(new MethodInvoker(delegate()
            {
                formProcess.progressBarTotal.Value++;
                formProcess.progressBarCurrent.Value++;
            }));
        }

        private void HideProcessState()
        {
            if (!this.InvokeRequired)
            {
                formProcess.Hide();
                formProcess.progressBarCurrent.Value = 0;

                this.Enabled = true;
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    formProcess.Hide();
                    formProcess.progressBarCurrent.Value = 0;

                    this.Enabled = true;
                }));
            }  
        }

        private void btnSinglePlot_Click(object sender, EventArgs e)
        {
            if (ll.head == null)
            {
                MessageBox.Show("There is no data to be plotted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvPlotOption.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (radioButtonSinglePlot.Checked == true)
            {
                if (ll.head != null)
                {
                    // Single Plot
                    for (int i = 0; i < lvPlotOption.Items.Count; i++)
                    {
                        if (lvPlotOption.Items[i].Checked == true)
                        {
                            pbLRPPlot.Image = ll.SinglePlot(int.Parse(lvPlotOption.Items[i].Text));
                            currentPlotCh = int.Parse(lvPlotOption.Items[i].Text);
                        }
                    }
                    pbLRPStatus = true;
                    SinglePlotDisplayed = true;
                    MultiPlotDisplayed = false;
                }           
            }
            else if (radioButtonMultiPlot.Checked == true)
            {
                // Multi Plot
                int[] SelectedChCnt = new int[lvPlotOption.CheckedItems.Count];

                for (int i = 0; i < SelectedChCnt.Length; i++)
                {
                    SelectedChCnt[i] = int.Parse(lvPlotOption.CheckedItems[i].Text);
                }

                if (ll.head != null)
                {                    
                    pbLRPPlot.Image = ll.MultiPlot(SelectedChCnt);

                    pbLRPStatus = true;
                    SinglePlotDisplayed = false;
                    MultiPlotDisplayed = true;
                }
            }
        }

        private void pbLRPPlot_MouseMove(object sender, MouseEventArgs e)
        {
            string temp = string.Empty;

            txtboxPointInformation.Location = new Point(e.X + 60, e.Y);

            if ((pbLRPStatus == true) && (SinglePlotDisplayed == true))
            {
                txtboxPointInformation.Text = "Channel : " + currentPlotCh.ToString() + "\r\n";
                txtboxPointInformation.Text += "(DTC1, DTC2) = " + "("+ (e.X/11).ToString() + ", "+(31 - e.Y/11).ToString() + ")" + "\r\n";
                txtboxPointInformation.Text += "Tx Lekage RSSI : " + ll.GetPointInformation(currentPlotCh, e.X / 11, e.Y / 11);
            }
            else if ((pbLRPStatus == true) && (MultiPlotDisplayed == true))
            {
                temp = ll.GetPointInformation(e.X / 11, e.Y / 11);
                if (temp != string.Empty)
                {
                    txtboxPointInformation.Text = ll.GetPointInformation(e.X / 11, e.Y / 11);
                    txtboxPointInformation.Visible = true;
                }
                else
                {
                    txtboxPointInformation.Visible = false;
                }                
            }
        }

        private void pbLRPPlot_MouseLeave(object sender, EventArgs e)
        {
            txtboxPointInformation.Visible = false;
        }

        private void pbLRPPlot_MouseEnter(object sender, EventArgs e)
        {
            if (ll.head != null)
            {
                if ((pbLRPStatus == true) && (SinglePlotDisplayed == true))
                {
                    txtboxPointInformation.Visible = true;    
                }
                else if ((pbLRPStatus == true) && (MultiPlotDisplayed == true))
                {
                    txtboxPointInformation.Visible = true;
                }              
            }            
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(400, 415);            
            Graphics g = Graphics.FromImage(img);

            string path = Path.GetDirectoryName(Application.ExecutablePath) +
                              "\\Plot\\" +
                              DateTime.Now.ToString("yyyyMMddhhmmss") +
                              "TLRPlot.jpg";                                    

            g.CopyFromScreen(new Point(this.Location.X + 10, this.Location.Y + 90), new Point(0, 0), img.Size);
            
            img.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void 저장ToolStripButton_Click(object sender, EventArgs e)
        {
            if (ll.head == null)
            {
                MessageBox.Show("There is no data to be saved", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Title = "Save";
                sfd.Filter = "Text Files (*.txt)|*.txt";
                sfd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Plot\\RawData";
                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ll.valToTxt(sfd.FileName);
                }                
            }
        }

        private void LoadToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.AutoUpgradeEnabled = false;
                ofd.Title = "Open File";
                ofd.Filter = "Text Files (*.txt)|*.txt";
                ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Plot\\RawData";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ll.head = null;
                    lvPlotOption.Items.Clear();

                    StreamReader sr = new StreamReader(ofd.FileName);
                    string line = string.Empty;
                    string[] lineArr;

                    int cnt = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.IndexOf("Channel") >= 0)
                        {
                            lineArr = line.Split(':');
                            lineArr[1] = lineArr[1].Trim();

                            tlr = new TxLeakageRSSI();
                            tlr.Ch = int.Parse(lineArr[1]);
                            cnt = 0;
                        }
                        else
                        {
                            lineArr = line.Split('\t');
                            for (int i = 0; i < 32; i++)
                            {
                                tlr.TLRval[i, cnt] = double.Parse(lineArr[i]);
                            }
                            cnt++;

                            if (cnt >= 32)
                            {
                                ll.addToHead(tlr.TLRval, tlr.Ch);
                                lvPlotOption.Items.Add(tlr.Ch.ToString());
                            }
                        }
                    }
                    sr.Close();
                }
            }
            catch
            {
                                
            }
        }

        private void lvPlotOption_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (radioButtonSinglePlot.Checked == true)
            {
                this.lvPlotOption.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.lvPlotOption_ItemCheck);
                for (int i = 0; i < lvPlotOption.Items.Count; i++)
                {
                    if (lvPlotOption.Items[i].Checked == true)
                    {
                        lvPlotOption.Items[i].Checked = false;
                    }
                }
                lvPlotOption.Items[e.Index].Checked = true;
                this.lvPlotOption.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvPlotOption_ItemCheck);
            }
        }

        private void radioButtonSinglePlot_CheckedChanged(object sender, EventArgs e)
        {            
            this.lvPlotOption.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.lvPlotOption_ItemCheck);
            for (int i = 0; i < lvPlotOption.Items.Count; i++)
            {                
                lvPlotOption.Items[i].Checked = false;                
            }
            this.lvPlotOption.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvPlotOption_ItemCheck);
        }

        void RxCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {            
            TxLRP_Rx_Flag = true;
            RxCheckTimer.Stop();
        }
    }
}
