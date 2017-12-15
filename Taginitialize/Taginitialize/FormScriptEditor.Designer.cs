namespace Phychips.PR9200
{
    partial class FormScriptEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScriptEditor));
            this.richTextBoxScript = new System.Windows.Forms.RichTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintpreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.편집ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildRCPOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildRCPOnlyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buildRCPWithArrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도구ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사용자지정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.옵션ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.내용ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인덱스ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.검색ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.새로만들기ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.열기ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.저장ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.인쇄ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.잘라내기ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.복사ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.붙여넣기ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.도움말ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRun = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelGen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxAssistor = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxScript
            // 
            this.richTextBoxScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxScript.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxScript.Name = "richTextBoxScript";
            this.richTextBoxScript.Size = new System.Drawing.Size(771, 588);
            this.richTextBoxScript.TabIndex = 0;
            this.richTextBoxScript.Text = "";
            this.richTextBoxScript.TextChanged += new System.EventHandler(this.richTextBoxScript_TextChanged);
            this.richTextBoxScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxScript_KeyDown);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.편집ToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.도구ToolStripMenuItem,
            this.도움말ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.toolStripSeparator,
            this.SaveToolStripMenuItem,
            this.SaveasToolStripMenuItem,
            this.toolStripSeparator5,
            this.PrintToolStripMenuItem,
            this.PrintpreviewToolStripMenuItem,
            this.toolStripSeparator6,
            this.ExitToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.파일ToolStripMenuItem.Text = "File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewToolStripMenuItem.Image")));
            this.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.NewToolStripMenuItem.Text = "New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.Image")));
            this.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.Image")));
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveasToolStripMenuItem
            // 
            this.SaveasToolStripMenuItem.Name = "SaveasToolStripMenuItem";
            this.SaveasToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.SaveasToolStripMenuItem.Text = "Save As";
            this.SaveasToolStripMenuItem.Click += new System.EventHandler(this.SaveasToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(143, 6);
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PrintToolStripMenuItem.Image")));
            this.PrintToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.PrintToolStripMenuItem.Text = "Print";
            this.PrintToolStripMenuItem.Visible = false;
            // 
            // PrintpreviewToolStripMenuItem
            // 
            this.PrintpreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PrintpreviewToolStripMenuItem.Image")));
            this.PrintpreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintpreviewToolStripMenuItem.Name = "PrintpreviewToolStripMenuItem";
            this.PrintpreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.PrintpreviewToolStripMenuItem.Text = "Print preview";
            this.PrintpreviewToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(143, 6);
            this.toolStripSeparator6.Visible = false;
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // 편집ToolStripMenuItem
            // 
            this.편집ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoToolStripMenuItem,
            this.RedoToolStripMenuItem,
            this.toolStripSeparator7,
            this.CutToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.toolStripSeparator8,
            this.SelectAllToolStripMenuItem});
            this.편집ToolStripMenuItem.Name = "편집ToolStripMenuItem";
            this.편집ToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.편집ToolStripMenuItem.Text = "Edit";
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.UndoToolStripMenuItem.Text = "Undo";
            this.UndoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            this.RedoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.RedoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.RedoToolStripMenuItem.Text = "Redo";
            this.RedoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(141, 6);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CutToolStripMenuItem.Image")));
            this.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.CutToolStripMenuItem.Text = "Cut";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyToolStripMenuItem.Image")));
            this.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.CopyToolStripMenuItem.Text = "Copy";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PasteToolStripMenuItem.Image")));
            this.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.PasteToolStripMenuItem.Text = "Paste";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(141, 6);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.SelectAllToolStripMenuItem.Text = "Select All";
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildRCPOnlyToolStripMenuItem,
            this.buildRunToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // buildRCPOnlyToolStripMenuItem
            // 
            this.buildRCPOnlyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildRCPOnlyToolStripMenuItem1,
            this.buildRCPWithArrayToolStripMenuItem});
            this.buildRCPOnlyToolStripMenuItem.Name = "buildRCPOnlyToolStripMenuItem";
            this.buildRCPOnlyToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.buildRCPOnlyToolStripMenuItem.Text = "Build RCP";
            // 
            // buildRCPOnlyToolStripMenuItem1
            // 
            this.buildRCPOnlyToolStripMenuItem1.Name = "buildRCPOnlyToolStripMenuItem1";
            this.buildRCPOnlyToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.buildRCPOnlyToolStripMenuItem1.Text = "Build RCP Only";
            this.buildRCPOnlyToolStripMenuItem1.Click += new System.EventHandler(this.buildRCPOnlyToolStripMenuItem1_Click);
            // 
            // buildRCPWithArrayToolStripMenuItem
            // 
            this.buildRCPWithArrayToolStripMenuItem.Name = "buildRCPWithArrayToolStripMenuItem";
            this.buildRCPWithArrayToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.buildRCPWithArrayToolStripMenuItem.Text = "Build RCP with Array";
            this.buildRCPWithArrayToolStripMenuItem.Click += new System.EventHandler(this.buildRCPWithArrayToolStripMenuItem_Click);
            // 
            // buildRunToolStripMenuItem
            // 
            this.buildRunToolStripMenuItem.Image = global::Phychips.PR9200.Properties.Resources.player_play;
            this.buildRunToolStripMenuItem.Name = "buildRunToolStripMenuItem";
            this.buildRunToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.buildRunToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.buildRunToolStripMenuItem.Text = "Run";
            this.buildRunToolStripMenuItem.Click += new System.EventHandler(this.buildRunToolStripMenuItem_Click);
            // 
            // 도구ToolStripMenuItem
            // 
            this.도구ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사용자지정ToolStripMenuItem,
            this.옵션ToolStripMenuItem});
            this.도구ToolStripMenuItem.Name = "도구ToolStripMenuItem";
            this.도구ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.도구ToolStripMenuItem.Text = "Tool";
            this.도구ToolStripMenuItem.Visible = false;
            // 
            // 사용자지정ToolStripMenuItem
            // 
            this.사용자지정ToolStripMenuItem.Name = "사용자지정ToolStripMenuItem";
            this.사용자지정ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.사용자지정ToolStripMenuItem.Text = "사용자 지정";
            // 
            // 옵션ToolStripMenuItem
            // 
            this.옵션ToolStripMenuItem.Name = "옵션ToolStripMenuItem";
            this.옵션ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.옵션ToolStripMenuItem.Text = "옵션";
            // 
            // 도움말ToolStripMenuItem
            // 
            this.도움말ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.내용ToolStripMenuItem,
            this.인덱스ToolStripMenuItem,
            this.검색ToolStripMenuItem,
            this.toolStripSeparator9,
            this.정보ToolStripMenuItem});
            this.도움말ToolStripMenuItem.Name = "도움말ToolStripMenuItem";
            this.도움말ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.도움말ToolStripMenuItem.Text = "Help";
            this.도움말ToolStripMenuItem.Visible = false;
            // 
            // 내용ToolStripMenuItem
            // 
            this.내용ToolStripMenuItem.Name = "내용ToolStripMenuItem";
            this.내용ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.내용ToolStripMenuItem.Text = "내용";
            // 
            // 인덱스ToolStripMenuItem
            // 
            this.인덱스ToolStripMenuItem.Name = "인덱스ToolStripMenuItem";
            this.인덱스ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.인덱스ToolStripMenuItem.Text = "인덱스";
            // 
            // 검색ToolStripMenuItem
            // 
            this.검색ToolStripMenuItem.Name = "검색ToolStripMenuItem";
            this.검색ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.검색ToolStripMenuItem.Text = "검색";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(107, 6);
            // 
            // 정보ToolStripMenuItem
            // 
            this.정보ToolStripMenuItem.Name = "정보ToolStripMenuItem";
            this.정보ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.정보ToolStripMenuItem.Text = "정보...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새로만들기ToolStripButton,
            this.열기ToolStripButton,
            this.저장ToolStripButton,
            this.인쇄ToolStripButton,
            this.toolStripSeparator1,
            this.잘라내기ToolStripButton,
            this.복사ToolStripButton,
            this.붙여넣기ToolStripButton,
            this.toolStripSeparator2,
            this.도움말ToolStripButton,
            this.toolStripButtonRun});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1038, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 새로만들기ToolStripButton
            // 
            this.새로만들기ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.새로만들기ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("새로만들기ToolStripButton.Image")));
            this.새로만들기ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.새로만들기ToolStripButton.Name = "새로만들기ToolStripButton";
            this.새로만들기ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.새로만들기ToolStripButton.Text = "새로 만들기";
            this.새로만들기ToolStripButton.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // 열기ToolStripButton
            // 
            this.열기ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.열기ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("열기ToolStripButton.Image")));
            this.열기ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.열기ToolStripButton.Name = "열기ToolStripButton";
            this.열기ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.열기ToolStripButton.Text = "열기";
            this.열기ToolStripButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // 저장ToolStripButton
            // 
            this.저장ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.저장ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("저장ToolStripButton.Image")));
            this.저장ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.저장ToolStripButton.Name = "저장ToolStripButton";
            this.저장ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.저장ToolStripButton.Text = "저장";
            this.저장ToolStripButton.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // 인쇄ToolStripButton
            // 
            this.인쇄ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.인쇄ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("인쇄ToolStripButton.Image")));
            this.인쇄ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.인쇄ToolStripButton.Name = "인쇄ToolStripButton";
            this.인쇄ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.인쇄ToolStripButton.Text = "인쇄";
            this.인쇄ToolStripButton.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // 잘라내기ToolStripButton
            // 
            this.잘라내기ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.잘라내기ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("잘라내기ToolStripButton.Image")));
            this.잘라내기ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.잘라내기ToolStripButton.Name = "잘라내기ToolStripButton";
            this.잘라내기ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.잘라내기ToolStripButton.Text = "잘라내기";
            this.잘라내기ToolStripButton.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // 복사ToolStripButton
            // 
            this.복사ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.복사ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("복사ToolStripButton.Image")));
            this.복사ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.복사ToolStripButton.Name = "복사ToolStripButton";
            this.복사ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.복사ToolStripButton.Text = "복사";
            this.복사ToolStripButton.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // 붙여넣기ToolStripButton
            // 
            this.붙여넣기ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.붙여넣기ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("붙여넣기ToolStripButton.Image")));
            this.붙여넣기ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.붙여넣기ToolStripButton.Name = "붙여넣기ToolStripButton";
            this.붙여넣기ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.붙여넣기ToolStripButton.Text = "붙여넣기";
            this.붙여넣기ToolStripButton.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // 도움말ToolStripButton
            // 
            this.도움말ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.도움말ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("도움말ToolStripButton.Image")));
            this.도움말ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.도움말ToolStripButton.Name = "도움말ToolStripButton";
            this.도움말ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.도움말ToolStripButton.Text = "도움말";
            this.도움말ToolStripButton.Visible = false;
            // 
            // toolStripButtonRun
            // 
            this.toolStripButtonRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRun.Image = global::Phychips.PR9200.Properties.Resources.player_play;
            this.toolStripButtonRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRun.Name = "toolStripButtonRun";
            this.toolStripButtonRun.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRun.Text = "toolStripButtonRun";
            this.toolStripButtonRun.Click += new System.EventHandler(this.buildRunToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGen,
            this.toolStripStatusLabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 643);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1038, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelGen
            // 
            this.toolStripStatusLabelGen.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelGen.Name = "toolStripStatusLabelGen";
            this.toolStripStatusLabelGen.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(4, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBoxScript);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxAssistor);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 588);
            this.splitContainer1.SplitterDistance = 771;
            this.splitContainer1.TabIndex = 5;
            // 
            // richTextBoxAssistor
            // 
            this.richTextBoxAssistor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAssistor.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBoxAssistor.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxAssistor.Name = "richTextBoxAssistor";
            this.richTextBoxAssistor.ReadOnly = true;
            this.richTextBoxAssistor.Size = new System.Drawing.Size(263, 585);
            this.richTextBoxAssistor.TabIndex = 0;
            this.richTextBoxAssistor.Text = "";
            // 
            // FormScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 665);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormScriptEditor";
            this.Text = "Script Editor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxScript;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildRCPOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildRCPOnlyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buildRCPWithArrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintpreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 편집ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도구ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사용자지정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 옵션ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 내용ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 인덱스ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 검색ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem 정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 새로만들기ToolStripButton;
        private System.Windows.Forms.ToolStripButton 열기ToolStripButton;
        private System.Windows.Forms.ToolStripButton 저장ToolStripButton;
        private System.Windows.Forms.ToolStripButton 인쇄ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 잘라내기ToolStripButton;
        private System.Windows.Forms.ToolStripButton 복사ToolStripButton;
        private System.Windows.Forms.ToolStripButton 붙여넣기ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton 도움말ToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBoxAssistor;
        private System.Windows.Forms.ToolStripButton toolStripButtonRun;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
    }
}