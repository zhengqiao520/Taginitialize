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
    public partial class FormTagInfoEpc : Form
    {
        public byte[] Epc = null;

        public FormTagInfoEpc()
        {
            InitializeComponent();
        }
        
        public System.Windows.Forms.TextBox TextBoxCrcRd
        {
            get { return textBoxCrcRd; }            
        }

        public System.Windows.Forms.TextBox TextBoxEpcRd
        {
            get { return textBoxEpcRd; }            
        }

        public System.Windows.Forms.TextBox TextBoxEpcWrt
        {
            get { return textBoxEpcWrt; }            
        }

        public System.Windows.Forms.TextBox TextBoxPcRd
        {
            get { return textBoxPcRd; }            
        }
        
        private void buttonEpcWrite_Click(object sender, EventArgs e)
        {
            
            if (textBoxEpcRd.Text.Length == 0) return;

            ByteBuilder bb = new ByteBuilder();

            try
            {
                Epc = StringHelper.ArgStringHexToByte(this.textBoxEpcWrt.Text);
                if (Epc.Length == 0)
                {
                    Epc = null;
                    throw (new Exception("Epc length must be greater then 0"));                    
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
