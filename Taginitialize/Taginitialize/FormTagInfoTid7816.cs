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
    public partial class FormTagInfoTid7816 : Form
    {        
        public FormTagInfoTid7816()
        {
            InitializeComponent();
        }

        public System.Windows.Forms.TextBox TextBoxAc
        {
            get { return textBoxAc; }            
        }

        public System.Windows.Forms.TextBox TextBoxMfgCode
        {
         
            get 
            {
                return textBoxMfgCode;
            }
        }

        public System.Windows.Forms.TextBox TextBoxSn
        {
            get { return textBoxSn; }
            
        }

        public void SetMfg()
        {
            switch (textBoxMfgCode.Text.TrimEnd(new char[] { ' ' }))
            {
                case "04":
                    textBoxMfgName.Text = "NXP";
                    break;
                case "2C":
                    textBoxMfgName.Text = "Impinj";
                    break;
            }
        }

    }
}
