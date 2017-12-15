using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RFIDStation;
using Infrastructure.Entity;
using DevExpress.XtraEditors;
using System.Diagnostics;
using Infrastructure;
namespace Phychips.PR9200
{
    public partial class TagInitEntry : XtraForm
    {
        private UserInfo user { get; set; }
        FromTaginitialize frmUtralHightReq = null;
        public TagInitEntry(UserInfo userinfo)
        {
            InitializeComponent();
            user = userinfo;
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = $"当前时间:{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}";
        }

        private void buttonClick(object sender, EventArgs e)
        {

           
        }
        private void SetLoginInfo() {

        }

        private void TagInitEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }

        private void btnHighFrequency_Click(object sender, TileItemEventArgs e)
        {
            RFIDStation.RFIDStation frmHightFreq = new RFIDStation.RFIDStation();
            frmHightFreq.fatherForm = this;
            frmHightFreq.Show();
            this.Visible = false;
        }


        private void btnUltrahighFrequency_Click(object sender, TileItemEventArgs e)
        {
            try
            {
                if (frmUtralHightReq == null || frmUtralHightReq.IsDisposed)
                {
                    frmUtralHightReq = new PR9200.FromTaginitialize();
                    frmUtralHightReq.fatherForm = this;
                    this.Visible = false;
                    frmUtralHightReq.Show();
                    return;
                }
                frmUtralHightReq.Show();
            }
            catch(Exception ee) {
                MessageBox.Show(ee.Message, "系统提示");
            }
        }

        private void tileCasher_ItemClick(object sender, TileItemEventArgs e)
        {
            RFIDStation.RFIDStation frmHightFreq = new RFIDStation.RFIDStation();
            frmHightFreq.fatherForm = this;
            frmHightFreq.Show();
            this.Visible = false;
        }

        private void tileItemGoodsOut_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                if (frmUtralHightReq == null || frmUtralHightReq.IsDisposed)
                {
                    frmUtralHightReq = new PR9200.FromTaginitialize();
                    frmUtralHightReq.fatherForm = this;
                    this.Visible = false;
                    frmUtralHightReq.Show();
                    return;
                }
                frmUtralHightReq.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "系统提示");
            }
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            DevExpress.XtraBars.Docking2010.WindowsUIButton button=e.Button as DevExpress.XtraBars.Docking2010.WindowsUIButton;
            switch (button.Tag.ToString()) {
                case "exit":
                    TagInitEntry_FormClosed(null, null);
                    break;
                case "change":
                    this.Close();
                    Process.Start(Application.ExecutablePath);
                    break;
            }
        }

        private void tileBookInfoImport_ItemClick(object sender, TileItemEventArgs e)
        {
            FormBookImport frmBookImport = new PR9200.FormBookImport();
            frmBookImport.fatherForm = this;
            frmBookImport.ShowDialog();
        }

        private void TagInitEntry_Load(object sender, EventArgs e)
        {
            var evn = ConnectInit.IsUATDataBase ? "【测试环境】" : "【生产环境】请谨慎操作！";
            lblDBEnvironment.Text = $"当前登录为：{evn}";
        }
    }
}
