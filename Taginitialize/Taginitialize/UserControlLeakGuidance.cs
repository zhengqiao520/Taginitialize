using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;

using Phychips.Rcp;

namespace Phychips.PR9200
{
    public partial class UserControlLeakGuidance : UserControl
    {        
        public UserControlLeakGuidance()
        {
            InitializeComponent();
        }

        public delegate void SendDataHandler(Object obj);
        public event SendDataHandler SendEvent;

        public delegate void SendDataButtonHandler(bool b);
        public event SendDataButtonHandler SendEventbutton;

        List<LeakGuidance> _guidanceInfoArr = new List<LeakGuidance>();

        public void ParseRsp(byte[] ba)
        {
            switch (ba[2])
            {
                case RcpProtocol.RCP_CMD_GET_DTC_RESULT:
                    AddLeakInfo(ba);
                    break;
                case RcpProtocol.RCP_RSP_REQUESTFAST_LEKAGE_CANCELLATION:
                    RspGuidanceRequest(ba);
                    break;
                case RcpProtocol.RCP_CMD_GET_LEAK_CAL_MODE:
                    toggleMode(ba);
                    break;
            }
        }

        private void AddLeakInfo(byte[] ba)
        {
            byte idt  = ba[5];
            byte dtc1 = ba[6];
            byte dtc2 = ba[7];
            byte rssi = ba[8];
            byte ch   = ba[10];

            bool guidance = false;

            if (_guidanceInfoArr.Count == 0)
            {
                LeakGuidance lg = new LeakGuidance(idt, dtc1, dtc2, ch);
                _guidanceInfoArr.Add(lg);
            }
            else
            {
                for (int i = 0; i <_guidanceInfoArr.Count; i++)
                {
                    if (_guidanceInfoArr[i].CH == ch)
                    {
                        LeakGuidance lg = new LeakGuidance(idt, dtc1, dtc2, ch);
                        _guidanceInfoArr[i] = lg;

                        guidance = true;
                    }
                }

                if (guidance == false)
                {
                    LeakGuidance lg = new LeakGuidance(idt, dtc1, dtc2, ch);
                    _guidanceInfoArr.Add(lg);
                }
            }

            ListViewItem lvit = new ListViewItem("0");
            lvit.SubItems[0].Text = ch.ToString();
            lvit.SubItems.Add(idt.ToString());
            lvit.SubItems.Add(dtc1.ToString());
            lvit.SubItems.Add(dtc2.ToString());
            lvit.SubItems.Add(rssi.ToString());

            listViewLeakInfo.Items.Add(lvit);
        }

        private void buttonLeakGuidance_Click(object sender, EventArgs e)
        {            
            if (_guidanceInfoArr.Count != 0)
            {                
                byte[] param = new byte[8];

                // leak guidance info
                param[0] = _guidanceInfoArr[0].IDT;
                param[1] = _guidanceInfoArr[0].DTC1;
                param[2] = _guidanceInfoArr[0].DTC2;
                param[3] = _guidanceInfoArr[0].CH;
                // leak guidance info

                // read command parameter
                param[4] = 0;
                param[5] = 0;
                param[6] = 0;
                param[7] = 0;
                // read command parameter

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_START_READ_FAST_LEKAGE_CANCELLATION, param))) { }
            }
            else
            {
                MessageBox.Show("No Guidance Information", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void RspGuidanceRequest(byte[] ba)
        {
            int cnt = 0;

            try
            {
                cnt = int.Parse(textBoxCnt.Text);

                if (cnt > 0)
                {
                    cnt--;
                    textBoxCnt.Text = cnt.ToString();
                }                    
            }
            catch
            {
 
            }
            
            if (cnt == 0)
            {
                EventSendMethod();
                return;
            }

            if(_guidanceInfoArr.Count == 0)            
            {
                System.Console.WriteLine("no Guidance Information");
            }
            else
            {
                for (int i = 0; i < _guidanceInfoArr.Count; i++)
                {
                    if (_guidanceInfoArr[i].CH == ba[5])
                    {
                        byte[] param = new byte[8];

                        // leak guidance info
                        param[0] = _guidanceInfoArr[i].IDT;
                        param[1] = _guidanceInfoArr[i].DTC1;
                        param[2] = _guidanceInfoArr[i].DTC2;
                        param[3] = _guidanceInfoArr[i].CH;                        
                        // leak guidance info

                        // read command parameter(reserved now)
                        param[4] = 0;
                        param[5] = 0;
                        param[6] = 0;
                        param[7] = 0;
                        // read command parameter(reserved now)

                        if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_START_READ_FAST_LEKAGE_CANCELLATION, param))) { }
                        break;
                    }
                }
            }
        }

        private void buttonGetInfo_Click(object sender, EventArgs e)
        {
            listViewLeakInfo.Items.Clear();

            timerEnableStart.Start();

            groupBoxModeSelection.Enabled = false;
            //buttonLeakGuidance.Enabled = true;

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_OPT_FH_TABLE, null))) { }
        }

        private void EventSendMethod()
        {
            this.SendEvent(null);
        }

        private void checkBoxEnableRegion_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnableRegion.Checked)
            {                
                groupBoxLeakGuidance.Enabled = true;

                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_LEAK_CAL_MODE, null))) { }
            }
            else
            {
                groupBoxLeakGuidance.Enabled = false;
            }
        }

        private void radioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNormal.Checked)
            {
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_LEAK_CAL_MODE, new byte[]{ 0x01 }))) { }

                buttonGetInfo.Enabled = false;
                buttonLeakGuidance.Enabled = false;

                this.SendEventbutton(true); 
            }
        }

        private void radioButtonFast_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFast.Checked)
            {
                if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_LEAK_CAL_MODE, new byte[] { 0x03 }))) { }

                buttonGetInfo.Enabled = true;

                this.SendEventbutton(false);
            }
        }

        private void toggleMode(byte[] ba)
        {
            byte b = ba[5];

            this.radioButtonNormal.CheckedChanged -= this.radioButtonNormal_CheckedChanged;
            this.radioButtonFast.CheckedChanged -= this.radioButtonFast_CheckedChanged;
            
            if (b == 0x03)
            {
                radioButtonFast.Checked = true;
                this.SendEventbutton(false);
            }
            else
            {
                radioButtonNormal.Checked = true;
                this.SendEventbutton(true);                
            }

            this.radioButtonNormal.CheckedChanged += this.radioButtonNormal_CheckedChanged;
            this.radioButtonFast.CheckedChanged += this.radioButtonFast_CheckedChanged;
        }

        private void timerEnableStart_Tick(object sender, EventArgs e)
        {
            groupBoxModeSelection.Enabled = true;
            buttonLeakGuidance.Enabled = true;
            timerEnableStart.Stop();
        }

        public void toggleVisibleLeakInfo()
        {
            this.listViewLeakInfo.Visible = !this.listViewLeakInfo.Visible;
        }
    }
}
