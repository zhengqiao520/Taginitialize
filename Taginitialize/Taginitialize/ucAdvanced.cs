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
using System.Collections;

namespace Phychips.PR9200
{
    public partial class ucAdvanced : UserControl
    {
        public ucAdvanced()
        {
            InitializeComponent();
        }

        private void ucAdvanced_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            this.comboBoxSleep.Items.Add((string)"Sleep");
            this.comboBoxSleep.Items.Add((string)"Deep Slee");
            this.comboBoxSleep.SelectedIndex = 0;
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
                    case RcpProtocol.RCP_GET_TEMPERATURE:
                        this.textBoxTemperature.Text = ((int)buf[5]).ToString();
                        break;
                    case RcpProtocol.RCP_GET_ADC:
                        this.textBoxADC.Text = ((int)buf[5]).ToString();
                        break;
                }
            }
        }

        private void buttonGetTemperature_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_GET_TEMPERATURE, null))) { }
        }

        private void buttonResetSystem_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RESET, null))) { }
        }

        private void buttonDeepSleep_Click(object sender, EventArgs e)
        {
            byte[] param = new byte[1];
            param[0] = (byte) this.comboBoxSleep.SelectedIndex;

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_CTL_RD_PWR, param))) { }
        }

        private void buttonGetADC_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_GET_ADC, null))) { }
        }     
    }
}
