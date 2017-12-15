using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Phychips.Rcp;
using Phychips.Helper;
using System.IO;


namespace Phychips.PR9200
{
    public partial class RegistryUpdate : Form
    {
        public RegistryUpdate()
        {
            InitializeComponent();
        }

        public delegate void RegistryUpdate_Result(bool result);
        //public event RegistryUpdate_Result registryUpdate_result;

        private void button_UpdateNow_Click(object sender, EventArgs e)
        {
            //this.registryUpdate_result(true);

            ByteBuilder bb = new ByteBuilder();

            bb.Append(0x01);

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_UPDATE_FLASH, bb.GetByteArray()))) { }

            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            //this.registryUpdate_result(false);

            this.Close();
        }
    }
}