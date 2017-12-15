using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure;
using Renci.SshNet;
using Infrastructure.Entity;
using Newtonsoft.Json;

namespace Phychips.PR9200
{
    public partial class BaseForm : XtraForm
    {
        public BaseForm()
        {
            InitializeComponent();
            this.Load += BaseForm_Load; ;
            this.FormClosed += BaseForm_FormClosed; ;
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCloseAnimat();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            OnStartAnimat();
        }
        protected virtual void OnCloseAnimat(XtraForm fm = null)
        {
            WinAPI.AnimateWindow(fm == null ? Handle : fm.Handle, 500, WinAPI.AW_CENTER | WinAPI.AW_HIDE);
        }
        protected virtual void OnStartAnimat(XtraForm fm = null)
        {
            WinAPI.AnimateWindow(fm == null ? Handle : fm.Handle, 500, WinAPI.AW_HOR_POSITIVE);
        }
    }
}
