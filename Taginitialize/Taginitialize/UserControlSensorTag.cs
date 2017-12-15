﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.IO;

using Phychips.Rcp;

namespace Phychips.PR9200
{
    public partial class UserControlSensorTag : UserControl
    {
        public UserControlSensorTag()
        {
            InitializeComponent();

            listViewEPC.ContextMenuStrip = contextMenuStripTagInfo;
            ChartMonitor.ContextMenuStrip = contextMenuStripChart;

            ChartMonitor.Series[0].Points.AddXY(0, 0);
            ChartMonitor.Series[1].Points.AddXY(0, 0);

            textBoxVMaxVal.Text = ChartMonitor.ChartAreas[0].AxisY.Maximum.ToString();
            textBoxVMinVal.Text = ChartMonitor.ChartAreas[0].AxisY.Minimum.ToString();

            textBoxSMaxVal.Text = ChartMonitor.ChartAreas[0].AxisY2.Maximum.ToString();
            textBoxSMinVal.Text = ChartMonitor.ChartAreas[0].AxisY2.Minimum.ToString();    
        }

        public void ParseRsp(byte[] ba)
        {
            switch (ba[2])
            {
                case RcpProtocol.RCP_CMD_START_AUTO_READ_RFM:
                    updateTagList(ba);
                    break;

                case RcpProtocol.RCP_CMD_READ_MAGNUS_S_SENSOR:

                    break;

                case RcpProtocol.RCP_RSP_FAILURE:

                    break;
            }
        }

        #region Inventory

        private int nTagCnt = 0;
        public bool lvEPCupdateThreadFlag = false;

        private Thread lvEPCupdateThread;
        private Queue<ListViewItem> lvEPCq = new Queue<ListViewItem>();

        int count100ms = 0;

        private string _selectedEPC = string.Empty;

        private void buttonInventory_Click(object sender, EventArgs e)
        {
            if (buttonInventory.Text == "Start")
            {
                buttonInventory.Text = "Stop";

                listViewEPC.Items.Clear();

                nTagCnt = 0;

                byte[] param = new byte[5];

                param[0] = 0x00;        //  code type
                param[1] = 0x00;        //  mtnu
                param[2] = 0x00;        //  mtime
                param[3] = 0x00;        //  RC  MSB
                param[4] = 0x00;        //  RC  LSB

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_START_AUTO_READ_RFM, param))) { }
            }
            else
            {
                buttonInventory.Text = "Start";
                lvEPCupdateThreadFlag = false;
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STOP_AUTO_READ_EX, null))) { }
            }
        }        

        private void updateTagList(byte[] Data)
        {
            int Payload = 0;
            int PC = 0;
            int EPCLengthField = 0;
            int Length = 0;

            string tid = string.Empty;

            if (Data[5] == 0x1F)
            {
                buttonInventory.Text = "Inventory";

                lvEPCupdateThreadFlag = false;
            }
            else
            {
                if (Data[1] == 0x01)
                {

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

                    PC = (Data[5] << 8) | Data[6];
                    EPCLengthField = PC >> 11;

                    Length = EPCLengthField * 2 + 2; // EPC Length + PC Length

                    StringBuilder hsb = new StringBuilder();
                    string ic = string.Empty;
                    StringBuilder hsbOnchipRSSI = new StringBuilder();
                    StringBuilder hsbCode = new StringBuilder();
                    StringBuilder hsbCalData = new StringBuilder();

                    for (int i = 5; i < 5 + Length; i++)
                    {
                        try
                        {
                            hsb.Append(Data[i].ToString("X2") + " ");
                        }
                        catch
                        {
                            break;
                        }
                    }

                    int CodeTypeIDX = 5 + Length;

                    for (int i = 0; i < 2; i++)
                    {
                        try
                        {
                            hsbOnchipRSSI.Append(Data[6 + Length + i].ToString("X2") + " ");
                        }
                        catch
                        {
                            break;
                        }
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        try
                        {
                            hsbCode.Append(Data[8 + Length + i].ToString("X2") + " ");
                        }
                        catch
                        {
                            break;
                        }
                    }

                    if (Data[CodeTypeIDX] == 0x02)
                    {

                    }
                    else
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            try
                            {
                                hsbCalData.Append(Data[10 + Length + i].ToString("X2") + " ");
                            }
                            catch
                            {
                                break;
                            }
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

                    if (Data[CodeTypeIDX] == 0x02)
                    {
                        ic = "Magnus S2";
                    }
                    else
                    {
                        ic = "Magnus S3";
                    }

                    lvt.SubItems.Add(ic);

                    lvt.SubItems.Add(hsbOnchipRSSI.ToString());

                    lvt.SubItems.Add(hsbCode.ToString());

                    if (Data[CodeTypeIDX] == 0x03)
                    {
                        lvt.SubItems.Add(hsbCalData.ToString());
                        lvt.SubItems.Add(CalculateTemp(Data, CodeTypeIDX).ToString("F2") + " ˚C");
                    }

                    ChartUpdator(Data, lvt.SubItems[2].Text, ic, CodeTypeIDX);

                    lvt.Font = new Font("Courier New", 8);

                    lvEPCq.Enqueue(lvt);


                }
            }
        }

        private void lvEPCupdate()
        {
            System.Threading.Thread.Sleep(500);

            while (lvEPCupdateThreadFlag == true || lvEPCq.Count > 0)
            {
                lvEPCupdateDetail();
            }

            double tmpCount = count100ms;
            tmpCount /= 10;
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

                            listViewEPC.Items[i].SubItems[5].Text = lvItem.SubItems[5].Text;
                            listViewEPC.Items[i].SubItems[6].Text = lvItem.SubItems[6].Text;

                            if (listViewEPC.Items[i].SubItems[4].Text == "Magnus S3")
                            {
                                listViewEPC.Items[i].SubItems[7].Text = lvItem.SubItems[7].Text;
                                listViewEPC.Items[i].SubItems[8].Text = lvItem.SubItems[8].Text;
                            }
                        }
                    }

                    if (lvIdx == -1)
                    {
                        labelReadTagsVal.Text = (++nTagCnt).ToString();
                        lvItem.SubItems[0].Text = nTagCnt.ToString();
                        listViewEPC.Items.Add(lvItem);
                    }
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        lvItem = lvEPCq.Dequeue();

                        for (int i = 0; i < this.listViewEPC.Items.Count; i++)
                        {
                            if (this.listViewEPC.Items[i].SubItems[2].Text == lvItem.SubItems[2].Text)
                            {
                                lvIdx = i;

                                listViewEPC.Items[i].SubItems[3].Text = (int.Parse(listViewEPC.Items[i].SubItems[3].Text) + 1).ToString();

                                listViewEPC.Items[i].SubItems[5].Text = lvItem.SubItems[5].Text;
                                listViewEPC.Items[i].SubItems[6].Text = lvItem.SubItems[6].Text;

                                if (listViewEPC.Items[i].SubItems[4].Text == "Magnus S3")
                                {
                                    listViewEPC.Items[i].SubItems[7].Text = lvItem.SubItems[7].Text;
                                    listViewEPC.Items[i].SubItems[8].Text = lvItem.SubItems[8].Text;
                                }
                            }
                        }

                        if (lvIdx == -1)
                        {
                            labelReadTagsVal.Text = (++nTagCnt).ToString();
                            lvItem.SubItems[0].Text = nTagCnt.ToString();
                            listViewEPC.Items.Add(lvItem);
                        }
                    }));
                }
                System.Threading.Thread.Sleep(tps);
            }
        }

        private void timerUpdateTag_Tick(object sender, EventArgs e)
        {
            count100ms++;
        }

        #endregion

        double xcoordinate = 0;

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewEPC.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                xcoordinate = 0;

                ChartMonitor.Series[0].Points.Clear();
                ChartMonitor.Series[1].Points.Clear();

                ChartMonitor.ChartAreas[0].AxisX.Minimum = 0;
                ChartMonitor.ChartAreas[0].AxisX.Maximum = 10;

                if (listViewEPC.SelectedItems[0].SubItems[4].Text == "Magnus S2")
                {
                    labelPYaxisName.Text = "Sensor Code";

                    labelTagIC.Text = "Magnus S2";

                    ChartMonitor.Series[0].Name = "Sensor Code";

                    groupBoxCodeValue.Text = "Sensor Code";

                    ChartMonitor.ChartAreas[0].AxisY.Minimum = 0;
                    ChartMonitor.ChartAreas[0].AxisY.Maximum = 50;
                    ChartMonitor.ChartAreas[0].AxisY.Interval = 10;
                }
                else if (listViewEPC.SelectedItems[0].SubItems[4].Text == "Magnus S3")
                {
                    labelPYaxisName.Text = "Temperature";

                    labelTagIC.Text = "Magnus S3";

                    ChartMonitor.Series[0].Name = "Temperature";

                    groupBoxCodeValue.Text = "Temperature";

                    ChartMonitor.ChartAreas[0].AxisY.Minimum = 0;
                    ChartMonitor.ChartAreas[0].AxisY.Maximum = 50;
                    ChartMonitor.ChartAreas[0].AxisY.Interval = 5;
                }

                xcoordinate = 0;

                _selectedEPC = listViewEPC.SelectedItems[0].SubItems[2].Text;

                ChartMonitor.Series[0].Points.Clear();
                ChartMonitor.Series[1].Points.Clear();


                ChartMonitor.ChartAreas[0].AxisX.Minimum = 0;
                ChartMonitor.ChartAreas[0].AxisX.Maximum = 10;
            }        
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xcoordinate = 0;

            ChartMonitor.Series[0].Points.Clear();
            ChartMonitor.Series[1].Points.Clear();

            ChartMonitor.ChartAreas[0].AxisX.Minimum = 0;
            ChartMonitor.ChartAreas[0].AxisX.Maximum = 10;

            ChartMonitor.Series[0].Points.AddXY(0, 0);
            ChartMonitor.Series[1].Points.AddXY(0, 0);
        }

        private double CalculateTemp(byte[] ba, int typeIdx)
        {
            double result = 0;
            int offset = 0;
            int temp = 0;            

            double tempCode_ = 0;

            double code1_ = 0;
            double code2_ = 0;

            double temp1_ = 0;
            double temp2_ = 0;

            offset = typeIdx + 3;

            try
            {
                tempCode_ = ba[offset + 0] << 8 | ba[offset + 1];

                temp = ba[offset + 4];
                temp = (temp << 4) + ((ba[offset + 5] >> 3) & 0x0F);
                code1_ = temp;

                temp = ba[offset + 5] & 0x0F;
                temp = (temp << 7) + ((ba[offset + 6] >> 1) & 0x7F);
                temp1_ = temp;

                temp = ba[offset + 6] & 0x01;
                temp = (temp << 8) + ba[offset + 7];
                temp = (temp << 3) + ((ba[offset + 8] >> 5) & 0x07);
                code2_ = temp;

                temp = ba[offset + 8] & 0x1F;
                temp = (temp << 6) + ((ba[offset + 9] >> 2) & 0x3F);
                temp2_ = temp;

                result = ((temp2_ - temp1_) / (code2_ - code1_) * (tempCode_ - code1_) + temp1_ - 800) / 10;
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        private double CalculateSensor(byte[] ba)
        {
            double result = 0;
            int offset = 22;

            result = ba[offset + 0] << 8 | ba[offset + 1];

            return result;
        }

        private double CacluateOnchipRSSI(byte[] ba)
        {
            double result = 0;

            result = ba[20] << 8 | ba[21];

            return result;
        }

        #region Chart Scale

        private void buttonHleft_Click(object sender, EventArgs e)
        {
            if (ChartMonitor.ChartAreas[0].AxisX.Maximum > 10)
            {
                ChartMonitor.ChartAreas[0].AxisX.Minimum--;
                ChartMonitor.ChartAreas[0].AxisX.Maximum--;
            }
        }

        private void buttonHright_Click(object sender, EventArgs e)
        {
            ChartMonitor.ChartAreas[0].AxisX.Minimum++;
            ChartMonitor.ChartAreas[0].AxisX.Maximum++;
        }

        private void textBoxVMaxVal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double temp = double.Parse(textBoxVMaxVal.Text);

                    if (temp > 0)
                    {
                        ChartMonitor.ChartAreas[0].AxisY.Maximum = temp;
                    }
                }
                catch
                {

                }

                ChartMonitor.ChartAreas[0].AxisY.MajorGrid.Interval = (ChartMonitor.ChartAreas[0].AxisY.Maximum - ChartMonitor.ChartAreas[0].AxisY.Minimum) / (double)10;
            }
        }

        private void textBoxVMinVal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double temp = double.Parse(textBoxVMinVal.Text);

                    if (temp >= ChartMonitor.ChartAreas[0].AxisY.Maximum)
                    {
                        temp = ChartMonitor.ChartAreas[0].AxisY.Maximum - 1;
                    }

                    ChartMonitor.ChartAreas[0].AxisY.Minimum = temp;
                }
                catch
                {

                }

                ChartMonitor.ChartAreas[0].AxisY.MajorGrid.Interval = (ChartMonitor.ChartAreas[0].AxisY.Maximum - ChartMonitor.ChartAreas[0].AxisY.Minimum) / (double)10;
            }
        }
        
        private void textBoxSMaxVal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double temp = double.Parse(textBoxSMaxVal.Text);

                    if (temp > 0)
                    {
                        ChartMonitor.ChartAreas[0].AxisY2.Maximum = temp;
                    }
                }
                catch
                {

                }

                ChartMonitor.ChartAreas[0].AxisY2.MajorGrid.Interval = (ChartMonitor.ChartAreas[0].AxisY2.Maximum - ChartMonitor.ChartAreas[0].AxisY2.Minimum) / (double)10;
            }
        }

        private void textBoxSMinVal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double temp = double.Parse(textBoxSMinVal.Text);

                    if (temp >= ChartMonitor.ChartAreas[0].AxisY2.Maximum)
                    {
                        temp = ChartMonitor.ChartAreas[0].AxisY2.Maximum - 1;
                    }

                    ChartMonitor.ChartAreas[0].AxisY2.Minimum = temp;
                }
                catch
                {

                }

                ChartMonitor.ChartAreas[0].AxisY2.MajorGrid.Interval = (ChartMonitor.ChartAreas[0].AxisY2.Maximum - ChartMonitor.ChartAreas[0].AxisY2.Minimum) / (double)10;
            }
        }

        #endregion

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChartMonitor.Series[0].Points.Count == 0)
            {
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.CreateNew));

                sw.WriteLine("{X=Time, Y=Value}");

                for (int i = 0; i < ChartMonitor.Series[0].Points.Count; i++)
                {
                    sw.WriteLine(ChartMonitor.Series[0].Points[i].ToString());
                }

                sw.Close();
            }
        }
        
        private void ChartUpdator(byte[] ba, string s, string type, int typeIdx)
        {
            if (s == _selectedEPC)
            {
                if (type == "Magnus S2")    // sensor code
                {
                    double data = CalculateSensor(ba);
                    double data2 = CacluateOnchipRSSI(ba);

                    if (data > ChartMonitor.ChartAreas[0].AxisY.Maximum)
                    {
                        return;
                    }
                    else
                    {
                        labelTempMonitorVal.Text = "  " + data.ToString("F0") + "  ";

                        labelValidVal.Text = "  " + data2.ToString("F0") + "  ";

                        ChartMonitor.Series[0].Points.AddXY(xcoordinate, data);
                        ChartMonitor.Series[1].Points.AddXY(xcoordinate, data2);

                        xcoordinate++;

                        if (xcoordinate > 11)
                        {
                            ChartMonitor.ChartAreas[0].AxisX.Minimum++;
                            ChartMonitor.ChartAreas[0].AxisX.Maximum++;
                        }
                    }
                }
                else if (type == "Magnus S3")       //  temp code
                {
                    double data = CalculateTemp(ba, typeIdx);
                    double data2 = CacluateOnchipRSSI(ba);

                    if (data == 0 || data > ChartMonitor.ChartAreas[0].AxisY.Maximum)
                    {
                        return;
                    }
                    else
                    {
                        labelTempMonitorVal.Text = data.ToString("F2") + " ˚C";

                        labelValidVal.Text = "  " + data2.ToString("F0") + "  ";

                        ChartMonitor.Series[0].Points.AddXY(xcoordinate, data);
                        ChartMonitor.Series[1].Points.AddXY(xcoordinate, data2);

                        xcoordinate++;

                        if (xcoordinate > 11)
                        {
                            ChartMonitor.ChartAreas[0].AxisX.Minimum++;
                            ChartMonitor.ChartAreas[0].AxisX.Maximum++;
                        }
                    }
                }
            }
            else
            {

            }
        }
    }
}
