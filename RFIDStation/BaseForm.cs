using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infrastructure;
namespace RFIDStation
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
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
            if (fm != null)
            {
                WinAPI.AnimateWindow(fm == null ? Handle : fm.Handle, 500, WinAPI.AW_CENTER | WinAPI.AW_HIDE);
            }
        }
        protected virtual void OnStartAnimat(XtraForm fm = null)
        {
            if (fm != null)
            {
                WinAPI.AnimateWindow(fm == null ? Handle : fm.Handle, 500, WinAPI.AW_HOR_POSITIVE);
            }
        }
    }
}
