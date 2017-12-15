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
    public partial class uartDebug : Form
    {
        public delegate void Delegate(object obj);
        private int serialDevice;                   //´®¿ÚÉè±¸
        public static Thread txFrameThread = null;

        public uartDebug()
        {
            InitializeComponent();
            serialDevice = -1;
        }

        private void uartDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Close();
        }

        public void EnableUartDebug(int h)
        {
            serialDevice = h;

//             txFrameThread = new Thread(new ThreadStart(ReceiveFrame));
//             txFrameThread.IsBackground = true;
//             txFrameThread.Start();
        }

        public void DisableUartDebug()
        {
            if (txFrameThread != null)
            {
                txFrameThread.Abort();
            }

            serialDevice = -1;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

        }
    }
}