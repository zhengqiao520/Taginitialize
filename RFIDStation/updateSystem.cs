using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RFIDStation
{
    public partial class updateSystem : Form
    {
        public updateSystem()
        {
            InitializeComponent();
        }

        private void textBoxFilePath_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void updateSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Close();
        }
    }
}