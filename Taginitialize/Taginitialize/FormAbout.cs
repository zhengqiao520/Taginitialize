using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Phychips.PR9200
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
        }

        public void SetVersion(string version)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("RED Utility");
            sb.AppendLine("Version : " + version);
            sb.AppendLine();
            sb.AppendLine("(c) 2015 Phychips. All Right Reserved.");

            tbVersion.Text = sb.ToString();
        }

        public string GetAbout(string version)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("RED Utility");
            sb.AppendLine("Version : " + version);
            sb.AppendLine();
            sb.AppendLine("(c) 2015 Phychips. All Right Reserved.");

            return sb.ToString();
        }
    }
}