using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Phychips.PR9200
{
    public partial class FormDownload : Form
    {
        public FormDownload()
        {
            InitializeComponent();
        }

        public void ParseRsp(byte[] data)
        {
            ucDownloader1.ParseRsp(data);
        }

        public void test(byte[] data)
        {
            ucDownloader1.ParseRsp(data);
        }

        private void FormDownload_FormClosing(object sender, FormClosingEventArgs e)
        {
            focused = false;
        }

        public bool focused = false;

        private void FormDownload_Load(object sender, EventArgs e)
        {
            focused = true;
        }

    }
}
