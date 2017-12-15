namespace Phychips.PR9200
{
    partial class FormBookImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.hyperlinkLabelControl1 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.chkUpdate = new DevExpress.XtraEditors.CheckEdit();
            this.btnExcel = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdTemp = new DevExpress.XtraGrid.GridControl();
            this.gvTemp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grdSystem = new DevExpress.XtraGrid.GridControl();
            this.gvSystem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1148, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 28);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导入图书";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1245, 755);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1239, 726);
            this.xtraTabPage1.Text = "待导入图书信息";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1239, 726);
            this.panelControl2.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdTemp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.36364F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1239, 726);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.hyperlinkLabelControl1);
            this.groupControl1.Controls.Add(this.chkUpdate);
            this.groupControl1.Controls.Add(this.btnExcel);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1233, 84);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "图书导入";
            // 
            // hyperlinkLabelControl1
            // 
            this.hyperlinkLabelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hyperlinkLabelControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hyperlinkLabelControl1.Location = new System.Drawing.Point(1131, 3);
            this.hyperlinkLabelControl1.Name = "hyperlinkLabelControl1";
            this.hyperlinkLabelControl1.Size = new System.Drawing.Size(96, 14);
            this.hyperlinkLabelControl1.TabIndex = 4;
            this.hyperlinkLabelControl1.Text = "<href=\"https://www.baidu.com/img/bd_logo1.png\">下载图书信息模板</href>";
            // 
            // chkUpdate
            // 
            this.chkUpdate.EditValue = true;
            this.chkUpdate.Location = new System.Drawing.Point(1007, 39);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Properties.Caption = "图书存在时更新";
            this.chkUpdate.Size = new System.Drawing.Size(106, 19);
            this.chkUpdate.TabIndex = 3;
            // 
            // btnExcel
            // 
            this.btnExcel.EditValue = "请选择要导入的excel图书信息文件";
            this.btnExcel.Location = new System.Drawing.Point(108, 35);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Properties.AutoHeight = false;
            this.btnExcel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "btnOpenExcel", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnExcel.Properties.NullText = "请选择要导入的excel图书文件";
            this.btnExcel.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_Properties_ButtonClick);
            this.btnExcel.Size = new System.Drawing.Size(879, 28);
            this.btnExcel.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "选择Excel文件";
            // 
            // grdTemp
            // 
            this.grdTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTemp.Location = new System.Drawing.Point(3, 93);
            this.grdTemp.MainView = this.gvTemp;
            this.grdTemp.Name = "grdTemp";
            this.grdTemp.Size = new System.Drawing.Size(1233, 564);
            this.grdTemp.TabIndex = 3;
            this.grdTemp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTemp});
            // 
            // gvTemp
            // 
            this.gvTemp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn19,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.gvTemp.GridControl = this.grdTemp;
            this.gvTemp.Name = "gvTemp";
            this.gvTemp.OptionsView.ShowAutoFilterRow = true;
            this.gvTemp.OptionsView.ShowFooter = true;
            this.gvTemp.OptionsView.ShowGroupPanel = false;
            this.gvTemp.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTemp_CustomDrawRowIndicator);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "ISBN";
            this.gridColumn10.FieldName = "isbn_no";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "isbn_no", "图书总数：{0}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 180;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "图书名称";
            this.gridColumn11.FieldName = "图书名称";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 130;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "作者";
            this.gridColumn12.FieldName = "作者";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 130;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "出版社";
            this.gridColumn13.FieldName = "出版社";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            this.gridColumn13.Width = 130;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "出版日期";
            this.gridColumn14.FieldName = "出版日期";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 130;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "价格";
            this.gridColumn15.FieldName = "价格";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 5;
            this.gridColumn15.Width = 130;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "年龄";
            this.gridColumn19.FieldName = "年龄";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 8;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "简介";
            this.gridColumn16.FieldName = "简介";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 6;
            this.gridColumn16.Width = 130;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "描述";
            this.gridColumn17.FieldName = "描述";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 7;
            this.gridColumn17.Width = 130;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "创建日期";
            this.gridColumn18.FieldName = "采集时间";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 9;
            this.gridColumn18.Width = 137;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnRemove);
            this.panelControl1.Controls.Add(this.btnExport);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 663);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1233, 60);
            this.panelControl1.TabIndex = 6;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(1067, 16);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 28);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "移除选中行";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.tableLayoutPanel2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1239, 726);
            this.xtraTabPage2.Text = "系统图书信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.grdSystem, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 726F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1239, 726);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // grdSystem
            // 
            this.grdSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSystem.Location = new System.Drawing.Point(3, 3);
            this.grdSystem.MainView = this.gvSystem;
            this.grdSystem.Name = "grdSystem";
            this.grdSystem.Size = new System.Drawing.Size(1233, 720);
            this.grdSystem.TabIndex = 1;
            this.grdSystem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSystem});
            // 
            // gvSystem
            // 
            this.gvSystem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gvSystem.GridControl = this.grdSystem;
            this.gvSystem.Name = "gvSystem";
            this.gvSystem.OptionsView.ShowAutoFilterRow = true;
            this.gvSystem.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gvSystem.OptionsView.ShowFooter = true;
            this.gvSystem.OptionsView.ShowGroupPanel = false;
            this.gvSystem.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvSystem_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ISBN";
            this.gridColumn1.FieldName = "isbn_no";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "isbn_no", "图书总数：{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 180;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "图书名称";
            this.gridColumn2.FieldName = "book_name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 130;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "作者";
            this.gridColumn3.FieldName = "author";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 130;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "出版社";
            this.gridColumn4.FieldName = "press";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 130;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "出版日期";
            this.gridColumn5.FieldName = "publication_date";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 130;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "价格";
            this.gridColumn6.FieldName = "price";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 130;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "简介";
            this.gridColumn7.FieldName = "brief";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 130;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "描述";
            this.gridColumn8.FieldName = "describe";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 130;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "创建日期";
            this.gridColumn9.FieldName = "create_time";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 137;
            // 
            // FormBookImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 755);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormBookImport";
            this.Text = "图书信息操作";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormBookImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSystem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdSystem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSystem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdTemp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTemp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControl1;
        private DevExpress.XtraEditors.CheckEdit chkUpdate;
        private DevExpress.XtraEditors.ButtonEdit btnExcel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}