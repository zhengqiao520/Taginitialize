using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace RFIDStation
{
    public partial class NfcTools : Form
    {
        public delegate void Delegate(object obj);
        private int serialDevice;                   //´®¿ÚÉè±¸
        public static Thread txFrameThread = null;

        public NfcTools()
        {
            InitializeComponent();
            serialDevice = -1;
        }

        private void NfcTools_Load(object sender, EventArgs e)
        {

        }
    }
}