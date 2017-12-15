using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phychips.Helper;

namespace Phychips.PR9200
{
    public partial class FormTagInfoReserved : Form
    {
        public byte[] KillPwWrt = null;
        public byte[] AccessPwWrt = null;

        public FormTagInfoReserved()
        {
            InitializeComponent();
        }

        public System.Windows.Forms.TextBox TextBoxKillPwRd
        {
            get { return textBoxKillPwRd; }            
        }
        public System.Windows.Forms.TextBox TextBoxAccessPwRd
        {
            get { return textBoxAccessPwRd; }            
        }
        public System.Windows.Forms.TextBox TextBoxAccessPwWrt
        {
            get { return textBoxAccessPwWrt; }            
        }
        public System.Windows.Forms.TextBox TextBoxKillPwWrt
        {
            get { return textBoxKillPwWrt; }            
        }

        private void buttonKillPwWrite_Click(object sender, EventArgs e)
        {
            if (textBoxKillPwWrt.Text.Length == 0) return;

            ByteBuilder bb = new ByteBuilder();

            try
            {
                KillPwWrt = StringHelper.ArgStringHexToByte(this.textBoxKillPwWrt.Text);
                if (KillPwWrt.Length != 4)
                {
                    KillPwWrt = null;
                    throw (new Exception("Kill password length must be 4 bytes or 2 words"));                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonAccessPwWrite_Click(object sender, EventArgs e)
        {
            if (textBoxAccessPwWrt.Text.Length == 0) return;

            ByteBuilder bb = new ByteBuilder();

            try
            {
                AccessPwWrt = StringHelper.ArgStringHexToByte(this.textBoxAccessPwWrt.Text);
                if (AccessPwWrt.Length != 4)
                {
                    AccessPwWrt = null;
                    throw (new Exception("Access password length must be 4 bytes or 2 words"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

 
    }
}
