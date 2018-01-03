using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.HSSF;
using Infrastructure;
using Infrastructure.Entity;
using NLog;
using DevExpress.XtraGrid;

namespace Phychips.PR9200
{
    public partial class FormBookImport : Form
    {
        private List<DictBookReadable> listDictBookReadable = new List<DictBookReadable>();
        private List<BooktopicalMappings> listBooktopicalMappings = new List<BooktopicalMappings>();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public Form fatherForm;
        public FormBookImport()
        {
            InitializeComponent();
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        { 
            if (e.Button.Caption == "btnOpenExcel") {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter= "Excel文件|*.xls";
                //| Excel文件 | *.xlsx
                DialogResult dialogResult = ofd.ShowDialog();
                if (dialogResult==DialogResult.OK) {
                    string fileName = ofd.FileName;
                    btnExcel.Text = fileName;
                    grdTemp.DataSource= NPOIHelper.ImportExcel(this.btnExcel.Text);
                    
                }
            }
        }

        private void FormBookImport_Load(object sender, EventArgs e)
        {
            var evn = ConnectInit.IsUATDataBase ? "【测试环境】" : "【生产环境】";
            Text = Text + $" 当前登录为：{evn}";
            this.grdSystem.DataSource = TagInfoDAL.SelectBookInfoList();

            gvSystem.OptionsCustomization.AllowFilter = true;                      
            gvSystem.IndicatorWidth = 80;                       
            gvSystem.OptionsView.ShowIndicator = true;

            gvTemp.OptionsCustomization.AllowFilter = true;
            gvTemp.IndicatorWidth = 80;
            gvTemp.OptionsView.ShowIndicator = true;
            listDictBookReadable=TagInfoDAL.GetDicBookReadable();
            listBooktopicalMappings = TagInfoDAL.GetBookTopicalMappingList();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            panelControl1.Enabled = false;
                if (gvTemp.RowCount == 0)
                {
                    MessageBox.Show("请先选择要导入的图书文件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (gvTemp.RowCount > 300)
                {
                    MessageBox.Show("限制单次可导入数量300条记录,超过记录数请拆分后导入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string resultMsg = string.Empty;
                List<BookInfoExt> failBookList = new List<BookInfoExt>();
                List<BookInfoExt> existsBookList = new List<BookInfoExt>();
                List<BookInfoExt> successBookList = new List<BookInfoExt>();
                int total = 0;
                DataTable table = grdTemp.DataSource as DataTable;
                total = table == null ? 0 : table.Rows.Count;
                logger.Log(LogLevel.Info, $"同步总数：同步图书总数【{total}】本");
                logger.Log(LogLevel.Info, $"操作人:{UserInfo.Instance.user_account}");
                if (null != table && table.Rows.Count > 0)
                {
                    try
                    {
                        List<BookInfoExt> bookInfos = new List<BookInfoExt>();
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            BookInfoExt bookInfo = new BookInfoExt();
                            string msg = string.Empty;
                            DataRow row = table.Rows[i];
                            bookInfo.isbn_no = row["isbn_no"].ToString();
                            bookInfo.book_name = row["图书名称"].ToString();
                            bookInfo.author = row["作者"].ToString();
                            bookInfo.category = "";
                            bookInfo.press = row["出版社"].ToString();
                            bookInfo.publication_date = Convert.ToDateTime(row["出版日期"].ToString());
                            bookInfo.price = row["价格"].ToString() == "" ? 0.00m : decimal.Parse(row["价格"].ToString());
                            bookInfo.brief = string.IsNullOrEmpty(row["简介"].ToString()) ? "暂无简介" : row["简介"].ToString();
                            bookInfo.describe = row["描述"].ToString();
                            bookInfo.topical_name = row["类别标签"].ToString();
                            string readable = row["适读年龄"] == null ? "" : row["适读年龄"].ToString();
                            readable = readable.Replace("岁", "").Replace(" ", "").Replace("-", "-");
                            if (!string.IsNullOrEmpty(readable))
                            {
                                string[] readableArray = readable.Split(new char[] { '-' });
                                bookInfo.min_age = int.Parse(readableArray[0]);
                                bookInfo.max_age = int.Parse(readableArray[1]);
                            }
                            bookInfo.create_time = DateTime.Now;
                            bookInfo.modify_time = null;
                            bookInfos.Add(bookInfo);
                        }

                        TagInfoDAL.BatchInsertBookInfo(bookInfos, out failBookList, out existsBookList, out successBookList, enableUpdate: chkUpdate.Checked);
                        logger.Log(LogLevel.Info, $"失败记录：{string.Join(",", failBookList.Select(item => new { 图书名称 = item.book_name, isbn = item.isbn_no }).ToList())}");
                        logger.Log(LogLevel.Info, $"更新记录：{string.Join(",", existsBookList.Select(item => new { 图书名称 = item.book_name, isbn = item.isbn_no }).ToList())}");
                        MessageBox.Show($"导入记录总数{total}条。\r\n失败{failBookList.Count}条。\r\n其中{existsBookList.Count}条已存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ee)
                    {
                        logger.Log(LogLevel.Error, ee.Message, ee);
                        MessageBox.Show("导入异常:" + ee.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            btnExcel.Text = "";
            grdTemp.DataSource = null;
            this.grdSystem.DataSource = TagInfoDAL.SelectBookInfoList();
            panelControl1.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除选中图书信息?", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
                gvTemp.DeleteRow(gvTemp.FocusedRowHandle);
            }
        }

        private void hyperlinkLabelControl1_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link);
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtISBN_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }

        private void gvSystem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle == GridControl.AutoFilterRowHandle)
                {
                    e.Info.DisplayText = "筛选行";   //筛选行加行标题  
                }
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void gvTemp_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle == GridControl.AutoFilterRowHandle)
                {
                    e.Info.DisplayText = "筛选行";   //筛选行加行标题  
                }
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            grdTemp.DataSource = null;
            btnExcel.Text = null;
        }
    }
}
