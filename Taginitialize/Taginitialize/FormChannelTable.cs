using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Phychips.Helper;
using Phychips.Rcp;

namespace Phychips.PR9200
{
    public partial class FormChannelTable : Form
    {
        private const int SIZE_MAX = 50;
        private int m_nSize = 0;
        private byte[] m_aChannel = null;

        public bool isDisplayed = false;

        public FormChannelTable()
        {
            InitializeComponent();
        }

        public byte[] GetChannelTable()
        {
            return m_aChannel;
        }

        private void FormChannelTable_Load(object sender, EventArgs e)
        {
            this.listViewEx1.textBoxLeave += validate_channel;
            
            isDisplayed = true;    
        }

        private void FormChannelTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            isDisplayed = false;
        }

        public void SetChannel(byte[] byteArrayChannel)
        {
            listViewEx1.Items.Clear();

            m_nSize = byteArrayChannel.Length;
            for (int i = 0; i < m_nSize; i++)
            {
                ListViewItem lvi = new ListViewItem((i+1).ToString("D2"));
                lvi.SubItems.Add(byteArrayChannel[i].ToString("D2"));
                this.listViewEx1.Items.Add(lvi);
                this.listViewEx1.AddEditableCell(i, 1);                
            }
        }

        private void buttonAddChannel_Click(object sender, EventArgs e)
        {
            radioButtonOpt.Checked = true;

            if (m_nSize >= SIZE_MAX) return;

            ListViewItem lvi = new ListViewItem((this.listViewEx1.Items.Count + 1).ToString("D2"));
            lvi.SubItems.Add("1");
            this.listViewEx1.Items.Add(lvi);
            this.listViewEx1.AddEditableCell(this.listViewEx1.Items.Count - 1, 1);
            
            m_nSize++;
        }

        private void buttonRemoveChannel_Click(object sender, EventArgs e)
        {
            radioButtonOpt.Checked = true;

            if (this.listViewEx1.SelectedItems == null || this.listViewEx1.SelectedItems.Count == 0)
            {
                if (this.listViewEx1.Items.Count > 0)
                {
                    this.listViewEx1.Items.Remove(this.listViewEx1.Items[this.listViewEx1.Items.Count - 1]);
                }                
            }
            else
            {
                try
                {
                    for (int i = this.listViewEx1.Items.Count; i >=0; i--)
                    {
                        if (this.listViewEx1.Items[i-1].Selected)
                        {
                            this.listViewEx1.Items.Remove(this.listViewEx1.Items[i-1]);
                        }                        
                    }
                    
                    for (int i = 0; i < this.listViewEx1.Items.Count; i++)
                    {
                        this.listViewEx1.Items[i].SubItems[0].Text = (i + 1).ToString("D2");
                    }
                }
                catch
                {

                }
            }

            m_nSize--;
        }

        private void buttonUpdateTable_Click(object sender, EventArgs e)
        {
            m_aChannel = new byte[this.listViewEx1.Items.Count];

            for (int i = 0; i < this.listViewEx1.Items.Count; i++)
            {
                try
                {
                    m_aChannel[i] = byte.Parse(this.listViewEx1.Items[i].SubItems[1].Text);
                }
                catch
                {

                }
            }

            ByteBuilder bb = new ByteBuilder();
            bb.Clear();

            bb.Append((byte)this.GetChannelTable().Length);
            bb.Append(this.GetChannelTable());

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_HOPPING_TBL, bb.GetByteArray()))) { }
            bb.Clear();
        }

        public void validate_channel(object sender, EventArgs e)
        {
            CustomListView.ListViewEx.TextBoxLeaveEventArg te = (CustomListView.ListViewEx.TextBoxLeaveEventArg)e;

            try
            {
                byte ch = byte.Parse(this.listViewEx1.Items[te.Row].SubItems[te.Col].Text);
                if(ch >= SIZE_MAX)
                    this.listViewEx1.Items[te.Row].SubItems[1].Text = "Invalid Channel";
            }
            catch
            {
                this.listViewEx1.Items[te.Row].SubItems[te.Col].Text = "Invalid Channel";
            }
        }

        System.Threading.Thread scan;

        private void buttonScan_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Check the Antenna Connection", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                radioButtonOpt.Checked = true;
                System.Threading.Thread.Sleep(1000);
                listViewEx1.Items.Clear();

                if (scan == null || scan.IsAlive == false)
                {
                    scan = new System.Threading.Thread(scanChannel);
                }

                scan.Start();
            }            
        }

        private void scanChannel()
        {
            toggleEnable();

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_OPT_FH_TABLE, null))) { }

            System.Threading.Thread.Sleep(5000);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_GET_HOPPING_TBL, null))) { }

            toggleEnable();
        }

        private void toggleEnable()
        {
            if (!InvokeRequired)
            {
                this.Enabled = !this.Enabled;
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.Enabled = !this.Enabled;
                }));
            }            
        }

        private void radioButtonOpt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOpt.Checked)
            {
                RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_FH_MODE, new byte[] { 0x01 }));
            }
            else
            {
                RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_FH_MODE, new byte[] { 0x00 }));
            }
        }
    }
}
