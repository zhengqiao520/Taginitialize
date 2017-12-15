using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.IO;

using Phychips.Rcp;
using Phychips.Helper;

namespace Phychips.PR9200
{
    public partial class FormSensorTag : Form
    {                        
        public FormSensorTag()
        {
            InitializeComponent();
        
        }

        public void ParseRsp(byte[] ba)
        {
            switch(ba[2])
            {
                case RcpProtocol.RCP_CMD_START_AUTO_READ_RFM:
                    userControlSensorTagRFM.ParseRsp(ba);
                    break;

                case RcpProtocol.RCP_CMD_START_AUTO_READ_EM:
                    userControlSensorTagEM.ParseRsp(ba);                    
                    break;
            }                
        }

        private void FormSensorTag_FormClosing(object sender, FormClosingEventArgs e)
        {
            userControlSensorTagRFM.lvEPCupdateThreadFlag = false;
            userControlSensorTagEM.lvEPCupdateThreadFlag = false;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                tabPageRFM.Size = new Size(1003, 583);
                this.Size = new Size(1043, 657);
            }
            else if (tabControl.SelectedIndex == 1)
            {
                tabPageEM.Size = new Size(725, 557);
                this.Size = new Size(769, 657);
            }
        }
    }
}
