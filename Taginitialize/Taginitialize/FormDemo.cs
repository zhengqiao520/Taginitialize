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
using Phychips.Helper;

namespace Phychips.PR9200
{
    public partial class FormDemo : Form
    {
        static private FormDemo _instance;
        static bool Status = false;

        private FormDemo()
        {
            InitializeComponent();
            lvTagInfo.ContextMenuStrip = contextMenuStripTagAccess;
        }

        static public FormDemo Instance()
        {
            if (_instance == null)
            {
                _instance = new FormDemo();
            }
            return _instance;
        }

        public delegate void SendMsgDele(bool msg);
        public event SendMsgDele SendMsg;

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] param = new byte[5];

            param[0] = 0;
            param[1] = 0;
            param[2] = 0;
            param[3] = 0;
            param[4] = 0;

            if (Status == false)
            {
                Status = true;
                button1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "/Icon/64x64/player_stop.png");
                RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD,RcpProtocol.RCP_CMD_STRT_AUTO_READ_RSSI,param));
                this.progressCircle1.Visible = true;
            }
            else
	        {
                RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STOP_AUTO_READ_EX, null));
                Status = false;
                button1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "/Icon/64x64/player_play.png");
                this.progressCircle1.Visible = false;
                SendMsg(false);
	        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lvTagInfo.Items.Clear();
            lbSelectedTag.Text = "Selected Tag : ";
            RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_SEL_PARM, BuildSelectRcpPacket(null)));
            SendMsg(true);
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvTagInfo.SelectedItems.Count == 0)
            {
                return;
            }

            string target = lvTagInfo.SelectedItems[0].SubItems[2].Text;

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_C_SEL_PARM, BuildSelectRcpPacket(target))))
            {
                return;
            }
            else
            {
                lbSelectedTag.Text = "Selected EPC : " + target;
            }    
        }

        private byte[] BuildSelectRcpPacket(string target)
        {
            ByteBuilder bb = new ByteBuilder();

            string[] temp = new string[0];

            if (target != null) temp = target.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            byte[] mask = new byte[0];

            if (target != null)
            {
                mask = new byte[temp.Length];

                for (int i = 0; i < mask.Length; i++)
                {
                    mask[i] = Convert.ToByte(temp[i], 16);
                }
            }

            byte[] param = new byte[7];

            param[0] = 0x01;    // Bank : EPC
            param[1] = 0x00;
            param[2] = 0x00;
            param[3] = 0x00;
            param[4] = 0x20;    // Pointer : head of EPC
            param[5] = Convert.ToByte(temp.Length << 3);
            param[6] = 0;

            bb.Append(param);

            bb.Append(mask);

            return bb.GetByteArray();
        }

        private void FormDemo_Deactivate(object sender, EventArgs e)
        {
            if (Status == true)
            {
                RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_STOP_AUTO_READ_EX, null));
                Status = false;
                button1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "/Icon/64x64/player_play.png");
                this.progressCircle1.Visible = false;
                SendMsg(false);
            }
            
        }
    }
}
