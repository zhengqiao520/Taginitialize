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
using Phychips.Helper;
using System.Collections;
using Phychips.Rcp;

namespace Phychips.PR9200
{
    public partial class ucProtocol : UserControl
    {
        private bool m_bGetQryRequired = false;

        public ucProtocol()
        {
            InitializeComponent();
            TabAirInterfaceInitialize();

        }

        private void UcTabAirInterface_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            //
        }
        
        private void TabAirInterfaceInitialize()
        {
            comboBoxSelTarget.Items.Clear();
            comboBoxSelTarget.Items.Add((string)"S0");
            comboBoxSelTarget.Items.Add((string)"S1");
            comboBoxSelTarget.Items.Add((string)"S2");
            comboBoxSelTarget.Items.Add((string)"S3");
            comboBoxSelTarget.Items.Add((string)"SL");
            comboBoxSelTarget.SelectedIndex = 0;

            comboBoxSelAction.Items.Clear();
            comboBoxSelAction.Items.Add((string)"000");
            comboBoxSelAction.Items.Add((string)"001");
            comboBoxSelAction.Items.Add((string)"010");
            comboBoxSelAction.Items.Add((string)"011");
            comboBoxSelAction.Items.Add((string)"100");
            comboBoxSelAction.Items.Add((string)"101");
            comboBoxSelAction.Items.Add((string)"110");
            comboBoxSelAction.Items.Add((string)"111");
            comboBoxSelAction.SelectedIndex = 0;

            comboBoxSelMemBank.Items.Clear();
            comboBoxSelMemBank.Items.Add((string)"RFU");
            comboBoxSelMemBank.Items.Add((string)"EPC");
            comboBoxSelMemBank.Items.Add((string)"TID");
            comboBoxSelMemBank.Items.Add((string)"User");
            comboBoxSelMemBank.SelectedIndex = 1;

            tbSelPointer.Text = "0000";
            tbSelLength.Text = "0";

            comboBoxSelTruncate.Items.Clear();
            comboBoxSelTruncate.Items.Add((string)"Disable");
            comboBoxSelTruncate.Items.Add((string)"Enable");
            comboBoxSelTruncate.SelectedIndex = 0;
            
            comboBoxQryDr.Items.Clear();
            comboBoxQryDr.Items.Add((string)"8");
            comboBoxQryDr.Items.Add((string)"64/3");
            comboBoxQryDr.SelectedIndex = 1;

            comboBoxQryTRext.Items.Clear();
            comboBoxQryTRext.Items.Add((string)"No pilot tone");
            comboBoxQryTRext.Items.Add((string)"Use pilot tone");
            comboBoxQryTRext.SelectedIndex = 0;

            comboBoxQryM.Items.Clear();
            comboBoxQryM.Items.Add((string)"1");
            comboBoxQryM.Items.Add((string)"2");
            comboBoxQryM.Items.Add((string)"4");
            comboBoxQryM.Items.Add((string)"8");
            comboBoxQryM.SelectedIndex = 3;

            comboBoxQrySel.Items.Clear();
            comboBoxQrySel.Items.Add((string)"ALL");
            comboBoxQrySel.Items.Add((string)"ALL");
            comboBoxQrySel.Items.Add((string)"~SL");
            comboBoxQrySel.Items.Add((string)"SL");
            comboBoxQrySel.SelectedIndex = 0;

            comboBoxQrySession.Items.Clear();
            comboBoxQrySession.Items.Add((string)"S0");
            comboBoxQrySession.Items.Add((string)"S1");
            comboBoxQrySession.Items.Add((string)"S2");
            comboBoxQrySession.Items.Add((string)"S3");
            comboBoxQrySession.SelectedIndex = 0;

            comboBoxQryTarget.Items.Clear();
            comboBoxQryTarget.Items.Add((string)"A");
            comboBoxQryTarget.Items.Add((string)"B");
            comboBoxQryTarget.SelectedIndex = 0;

            comboBoxQryQ.Items.Clear();
            for (int i = 0; i < 16; i++)
            {
                comboBoxQryQ.Items.Add(i.ToString("D02"));
            }
            comboBoxQryQ.SelectedIndex = 4;

            this.comboBoxAntiCol.Items.Add((string)"0:Fixed Q");
            this.comboBoxAntiCol.Items.Add((string)"1:Dynamic Q (Mode 1)");
            this.comboBoxAntiCol.Items.Add((string)"2:Dynamic Q (Mode 2)");
            this.comboBoxAntiCol.SelectedIndex = 0;
        }

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
                    case RcpProtocol.RCP_CMD_GET_C_SEL_PARM:
                        SetSelectValue(Data);

                        if (m_bGetQryRequired)
                        {
                            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_C_QRY_PARM, null))) { }
                            m_bGetQryRequired = false;
                        }
                        break;
                    case RcpProtocol.RCP_CMD_GET_C_QRY_PARM:
                        SetQueryValue(Data);
                        break;
                    case RcpProtocol.RCP_CMD_SET_ANTICOL_MODE:
                        {
                            
                            this.buttonSetAntiCol.Enabled = false;

                            
                            //if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_C_SEL_PARM, null))) { }
                            
                            this.buttonSetAntiCol.Enabled = true;
                        }
                        break;
                    case RcpProtocol.RCP_CMD_GET_ANTICOL_MODE:
                        {
                            this.buttonGetAntiCol.Enabled = false;

                            this.comboBoxAntiCol.SelectedIndex = Data[5];

                            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_C_SEL_PARM, null))) { }

                            this.buttonGetAntiCol.Enabled = true;
                        }
                        break;
                    case RcpProtocol.RCP_CMD_GET_SESSION:
                        {
                            switch (buf[5])
                            {
                                case 0:
                                    this.radioButtonSession0.Checked = true;
                                    break;
                                case 1:
                                    this.radioButtonSession1.Checked = true;
                                    break;
                                case 2:
                                    this.radioButtonSession2.Checked = true;
                                    break;
                                case 3:
                                    this.radioButtonSession3.Checked = true;
                                    break;
                                case 0xF0:
                                    this.radioButtonSessionDev.Checked = true;
                                    break;
                            }
                        }
                        break;
                }
            }
        }
        
        private void SetSelectValue(byte[] Data)
        {
            try
            {
                this.comboBoxSelTarget.SelectedIndex = ((Data[5] >> 5) & 0x07);
                this.comboBoxSelAction.SelectedIndex = ((Data[5] >> 2) & 0x07);
                this.comboBoxSelMemBank.SelectedIndex = ((Data[5]) & 0x03);

                this.tbSelPointer.Text = ((Data[8] << 8) | Data[9]).ToString("X04");
                this.tbSelLength.Text = Data[10].ToString();
                this.comboBoxSelTruncate.SelectedIndex = (Data[11] >> 7) & 0x01;

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < ((Data[10] + 7) >> 3); i++)
                {
                    sb.Append(Data[i + 12].ToString("X02"));
                }

                this.tbSelMask.Text = sb.ToString();
            }
            catch
            {

            }
        }

        private void SetQueryValue(byte[] Data)
        {
            try
            {
                this.comboBoxQryDr.SelectedIndex = (Data[5] >> 7) & 0x01;
                this.comboBoxQryM.SelectedIndex = (Data[5] >> 5) & 0x03;
                this.comboBoxQryTRext.SelectedIndex = (Data[5] >> 4) & 0x01;
                this.comboBoxQrySel.SelectedIndex = (Data[5] >> 2) & 0x03;
                this.comboBoxQrySession.SelectedIndex = (Data[5]) & 0x03;
                this.comboBoxQryTarget.SelectedIndex = (Data[6] >> 7) & 0x01;   //! 1bit
                this.comboBoxQryQ.SelectedIndex = (Data[6] >> 3) & 0x0f;   //! 4bit
            }
            catch
            {

            }
        }

        private byte[] BuildQryRcpPacket()
        {         
            byte[] param = new byte[2];            

            param[0] = (byte)
                        (   (comboBoxQryDr.SelectedIndex << 7) 
                        +   (comboBoxQryM.SelectedIndex << 5) 
                        +   (comboBoxQryTRext.SelectedIndex << 4)
                        +   (comboBoxQrySel.SelectedIndex << 2)
                        +   (comboBoxQrySession.SelectedIndex) );
            
            param[1] = (byte) 
                        (   (comboBoxQryTarget.SelectedIndex << 7) 
                        +   (comboBoxQryQ.SelectedIndex << 3));

            return param;
        }
           
        private byte[] BuildSelectRcpPacket()
        {
            ByteBuilder bb = new ByteBuilder();
            int discard;

            byte[] param = new byte[7];
            
            param[0] = (byte)
                        (   (comboBoxSelTarget.SelectedIndex << 5) 
                        +   (comboBoxSelAction.SelectedIndex << 2) 
                        +   (comboBoxSelMemBank.SelectedIndex));
            param[1] = 0;
            param[2] = 0;
            param[3] = (byte)((Convert.ToUInt16(tbSelPointer.Text, 16) & 0xFF00) >> 8);
            param[4] = (byte)((Convert.ToUInt16(tbSelPointer.Text, 16) & 0x00FF));
            param[5] = byte.Parse(tbSelLength.Text);            
            param[6] = 0;

            bb.Append(param);

            byte[] mask = HexEncoding.GetBytes(tbSelMask.Text, out discard);
            Array.Resize(ref mask, ((param[5] + 7) / 8));
            
            if(mask.Length >0)
                bb.Append(mask);

            return bb.GetByteArray();
        }

        private void buttonSetParam_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_SEL_PARM, BuildSelectRcpPacket()))) { return; }
        }
             
        private void buttonGetParam_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_C_SEL_PARM, null))) { return; }

            this.buttonSetSelectParam.Enabled = true;
        }

        private void buttonSetQueryParam_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_QRY_PARM, BuildQryRcpPacket()))) { }
        }

        private void buttonGetQueryParam_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_C_QRY_PARM, null))) { }

            this.buttonSetQueryParam.Enabled = true;
        }

        private void comboBoxQryM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxQryM.SelectedIndex < 2)
            {
                this.comboBoxQryTRext.SelectedIndex = 1;
            }
            else
            {
                this.comboBoxQryTRext.SelectedIndex = 0;
            }
        }

        private void buttonGetAntiCol_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_ANTICOL_MODE, null))) { return; }

            m_bGetQryRequired = true;

            this.buttonSetAntiCol.Enabled = true;
        }

        private void buttonSetAntiCol_Click(object sender, EventArgs e)
        {
            byte[] param = new byte[4];

            param[0] = (byte)this.comboBoxAntiCol.SelectedIndex;
            param[1] = (byte)0x04;
            param[2] = (byte)0x07;
            param[3] = (byte)0x02;

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_ANTICOL_MODE, param))) { return; }

            m_bGetQryRequired = true;
        }

        public void ClickDefaultSetting(object sender, EventArgs e)
        {
        }

        private void buttonGetSession_Click(object sender, EventArgs e)
        {
            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_SESSION, null))) { }

            this.buttonSetSession.Enabled = true;
        }

        private void buttonSetSession_Click(object sender, EventArgs e)
        {
            byte[] s = new byte[1] { 0x00 };

            if (this.radioButtonSessionDev.Checked)
            {
                s[0] = 0xF0;
            }
            else if (this.radioButtonSession0.Checked)
            {
                s[0] = 0;
            }
            else if (this.radioButtonSession1.Checked)
            {
                s[0] = 1;
            }
            else if (this.radioButtonSession2.Checked)
            {
                s[0] = 2;
            }
            else if (this.radioButtonSession3.Checked)
            {
                s[0] = 3;
            }
            else
            {
                return;
            }

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_SESSION, s))) { }
        }

        public void setSessionValue(byte session)
        {
            switch (session)
            {
                case 0:
                    this.radioButtonSession0.Checked = true;
                    break;
                case 1:
                    this.radioButtonSession1.Checked = true;
                    break;
                case 2:
                    this.radioButtonSession2.Checked = true;
                    break;
                case 3:
                    this.radioButtonSession3.Checked = true;
                    break;
                case 0xF0:
                    this.radioButtonSessionDev.Checked = true;
                    break;
            }
        }

        private void radioButtonSession_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonSessionDev.Checked)
                {
                    this.comboBoxSelMemBank.SelectedIndex = 1;  // EPC
                    this.comboBoxQrySession.SelectedIndex = 0;  // S0
                }
                else if (radioButtonSession0.Checked)
                {
                    this.comboBoxSelMemBank.SelectedIndex = 0;  // RFU
                    this.comboBoxQrySession.SelectedIndex = 0;  // S0
                }
                else if (radioButtonSession1.Checked)
                {
                    this.comboBoxSelMemBank.SelectedIndex = 0;  // RFU
                    this.comboBoxQrySession.SelectedIndex = 1;  // S1
                }
                else if (radioButtonSession2.Checked)
                {
                    this.comboBoxSelMemBank.SelectedIndex = 0;  // RFU
                    this.comboBoxQrySession.SelectedIndex = 2;  // S2
                }
                else if (radioButtonSession3.Checked)
                {
                    this.comboBoxSelMemBank.SelectedIndex = 0;  // RFU
                    this.comboBoxQrySession.SelectedIndex = 3;  // S3
                }
            }
            catch
            {
                return;
            }
        }

        public void SetRxModandDR(byte RxMod, byte DR)
        {
            if (RxMod == 0x00)
        	{
                this.comboBoxQryM.SelectedIndex = 0;
	        }
            else if (RxMod == 0x01)
            {
                this.comboBoxQryM.SelectedIndex = 1;
            }
            else if (RxMod == 0x02)
            {
                this.comboBoxQryM.SelectedIndex = 2;
            }
            else if (RxMod == 0x03)
            {
                this.comboBoxQryM.SelectedIndex = 3;
            }

            if (DR == 0x00)
            {
                this.comboBoxQryDr.SelectedIndex = 0;
            }
            else if (DR == 0x01)
            {
                this.comboBoxQryDr.SelectedIndex = 1;
            }

            /*
            this.comboBoxQryM.
            this.comboBoxQryDr.
*/
        }
    }
}
