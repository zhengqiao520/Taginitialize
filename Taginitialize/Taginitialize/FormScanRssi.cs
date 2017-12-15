using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phychips.PR9200
{
    public partial class FormScanRssi : Form
    {
        public FormScanRssi()
        {
            InitializeComponent();
        }

        public BarChart.HBarChart HbcRssi
        {
            get { return hbcRssi; }         
        }

    }
}
