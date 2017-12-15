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
    public partial class FormTagInfoUser : Form
    {
        public byte[] UserData = null;
        public byte[] UserDataAddress = null;
        

        public FormTagInfoUser()
        {
            InitializeComponent();
        }

        public System.Windows.Forms.TextBox TextBoxUserRd
        {
            get { return textBoxUserRd; }            
        }

        public System.Windows.Forms.TextBox TextBoxUserWrt
        {
            get { return textBoxUserWrt; }            
        }
        
        public System.Windows.Forms.Label LabelAddress
        {
            get { return labelAddress; }
        }

        private void buttonKillPwWrite_Click(object sender, EventArgs e)
        {
            if (textBoxUserWrt.Text.Length == 0) return;
            if (LabelAddress.Text.Length == 0) return;

            ByteBuilder bb = new ByteBuilder();

            try
            {                
                UserData = StringHelper.ArgStringHexToByte(this.textBoxUserWrt.Text);
                UserDataAddress = StringHelper.ArgStringHexToByte(this.LabelAddress.Text.Remove(3).PadLeft(4, '0'));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        } 
    }
}
