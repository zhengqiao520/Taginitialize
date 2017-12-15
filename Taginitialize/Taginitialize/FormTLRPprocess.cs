using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phychips.PR9200
{
    public partial class FormTLRPprocess : Form
    {
        public delegate void SendMsgDele(bool AbortFlag);
        public event SendMsgDele SendMsg;

        public FormTLRPprocess()
        {
            InitializeComponent();            
        }

        private void FormTLRPprocess_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Measured Data will be lost","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SendMsg(true);
            }            
        }
    }
}
