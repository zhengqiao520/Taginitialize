using System.Threading;
using System.ComponentModel;
using Phychips.Driver;
using Phychips.Rcp;

namespace Phychips.PR9200
{
    partial class FromTaginitialize
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                bDisposed = true;
                //Sio.Instance.oSp.DataReceived -= SioDataReceived;
                RcpProtocol.Instance.RcpLogEventReceived -= RcpLogEventReceived;
                RcpProtocol.Instance.RxRspParsed -= RxRspEventReceived;
                //RcpProtocol.Instance.RxAutoreadEnd -= ucTagInformation1.RxRspEventAutoreadEndReceived;                                    
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromTaginitialize));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusPortOpen = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusBr = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsPartNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsFWVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firmwareDownloaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rCPLoggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logEnableToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.moduleInforCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.scriptEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leakageRSSIPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensorTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSubMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.functionKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offsetPowerTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analogTPEnableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeSerialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleLeakInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogLog = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogReport = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStripTagInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewTagMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTagIDToDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectThisTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTagListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripMoreInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moreInformationMemoryModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStriprichTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxRCPDecoder = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnPort = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnStartread = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnStopRead = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStripReadButton = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.withRSSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withTIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contitionalReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerAutoConnect = new System.Windows.Forms.Timer(this.components);
            this.ReadRateTimer = new System.Windows.Forms.Timer(this.components);
            this.timerProgressCircle = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReadWriteErase = new System.Windows.Forms.TabPage();
            this.buttonReadTagMemoryEx = new System.Windows.Forms.Button();
            this.buttonBlockWriteDataToTag = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonBlockEraseTagMemory = new System.Windows.Forms.Button();
            this.cbTagRwTarMem = new System.Windows.Forms.ComboBox();
            this.buttonWriteDataToTag = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonReadTagMemory = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxRwStartAdd = new System.Windows.Forms.TextBox();
            this.textBoxRwLength = new System.Windows.Forms.TextBox();
            this.textBoxRwAccessPw = new System.Windows.Forms.TextBox();
            this.textBoxRwData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEPCCode = new System.Windows.Forms.TextBox();
            this.progressCircle = new Utezduyar.Windows.Forms.ProgressCircle();
            this.buttonReadMultiple = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdRecordList = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gvRecordList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label4 = new System.Windows.Forms.Label();
            this.radioBookType = new DevExpress.XtraEditors.RadioGroup();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAutoWiteEPC = new DevExpress.XtraEditors.CheckEdit();
            this.txtISBN = new DevExpress.XtraEditors.TextEdit();
            this.txtTagID = new DevExpress.XtraEditors.TextEdit();
            this.label30 = new System.Windows.Forms.Label();
            this.lueBookInfo = new DevExpress.XtraEditors.LookUpEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnReadTagID = new DevExpress.XtraEditors.SimpleButton();
            this.chkAutoSave = new DevExpress.XtraEditors.CheckEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTagCount = new System.Windows.Forms.Label();
            this.labelSelectedTag = new System.Windows.Forms.Label();
            this.textBox_RepeatCycle = new System.Windows.Forms.TextBox();
            this.textBox_MTIME = new System.Windows.Forms.TextBox();
            this.labelCycle = new System.Windows.Forms.Label();
            this.labelReadfor = new System.Windows.Forms.Label();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.listViewEPC = new System.Windows.Forms.ListView();
            this.cNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cEPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cRssi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStripTagInfo.SuspendLayout();
            this.contextMenuStripMoreInfo.SuspendLayout();
            this.contextMenuStriprichTextBox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStripReadButton.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabReadWriteErase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecordList)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioBookType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoWiteEPC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtISBN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTagID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBookInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoSave.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusPortOpen,
            this.tsStatusPort,
            this.tsStatusBr,
            this.tsPartNumber,
            this.tsFWVersion,
            this.tsStatusInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(892, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusPortOpen
            // 
            this.tsStatusPortOpen.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsStatusPortOpen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStatusPortOpen.Name = "tsStatusPortOpen";
            this.tsStatusPortOpen.Size = new System.Drawing.Size(61, 19);
            this.tsStatusPortOpen.Text = "CLOSE   ";
            // 
            // tsStatusPort
            // 
            this.tsStatusPort.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsStatusPort.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStatusPort.Name = "tsStatusPort";
            this.tsStatusPort.Size = new System.Drawing.Size(45, 19);
            this.tsStatusPort.Text = "COM?";
            // 
            // tsStatusBr
            // 
            this.tsStatusBr.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsStatusBr.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStatusBr.Name = "tsStatusBr";
            this.tsStatusBr.Size = new System.Drawing.Size(52, 19);
            this.tsStatusBr.Text = "115200";
            // 
            // tsPartNumber
            // 
            this.tsPartNumber.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsPartNumber.Name = "tsPartNumber";
            this.tsPartNumber.Size = new System.Drawing.Size(81, 19);
            this.tsPartNumber.Text = "Part Number";
            this.tsPartNumber.Visible = false;
            // 
            // tsFWVersion
            // 
            this.tsFWVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsFWVersion.Name = "tsFWVersion";
            this.tsFWVersion.Size = new System.Drawing.Size(107, 19);
            this.tsFWVersion.Text = "Firmware Version";
            this.tsFWVersion.Visible = false;
            // 
            // tsStatusInfo
            // 
            this.tsStatusInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsStatusInfo.Name = "tsStatusInfo";
            this.tsStatusInfo.Size = new System.Drawing.Size(719, 19);
            this.tsStatusInfo.Spring = true;
            this.tsStatusInfo.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.tsMenuAbout,
            this.functionKeyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.portSettingsToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.connectionToolStripMenuItem.Text = "连接";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.openToolStripMenuItem.Text = "Connect";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.closeToolStripMenuItem.Text = "Disconnect";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // portSettingsToolStripMenuItem
            // 
            this.portSettingsToolStripMenuItem.Name = "portSettingsToolStripMenuItem";
            this.portSettingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.portSettingsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.portSettingsToolStripMenuItem.Text = "Port Settings";
            this.portSettingsToolStripMenuItem.Click += new System.EventHandler(this.portSettingsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firmwareDownloaderToolStripMenuItem,
            this.rCPLoggerToolStripMenuItem,
            this.moduleInforCreatorToolStripMenuItem,
            this.toolStripSeparator1,
            this.scriptEditorToolStripMenuItem,
            this.leakageRSSIPlotToolStripMenuItem,
            this.readRangeToolStripMenuItem,
            this.sensorTagToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.toolsToolStripMenuItem.Text = "工具";
            this.toolsToolStripMenuItem.Visible = false;
            // 
            // firmwareDownloaderToolStripMenuItem
            // 
            this.firmwareDownloaderToolStripMenuItem.Name = "firmwareDownloaderToolStripMenuItem";
            this.firmwareDownloaderToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.firmwareDownloaderToolStripMenuItem.Text = "Firmware Downloader";
            this.firmwareDownloaderToolStripMenuItem.Visible = false;
            this.firmwareDownloaderToolStripMenuItem.Click += new System.EventHandler(this.firmwareDownloaderToolStripMenuItem_Click);
            // 
            // rCPLoggerToolStripMenuItem
            // 
            this.rCPLoggerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logEnableToolStripMenuItem2});
            this.rCPLoggerToolStripMenuItem.Name = "rCPLoggerToolStripMenuItem";
            this.rCPLoggerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.rCPLoggerToolStripMenuItem.Text = "RCP Logger";
            this.rCPLoggerToolStripMenuItem.Visible = false;
            // 
            // logEnableToolStripMenuItem2
            // 
            this.logEnableToolStripMenuItem2.Name = "logEnableToolStripMenuItem2";
            this.logEnableToolStripMenuItem2.Size = new System.Drawing.Size(137, 22);
            this.logEnableToolStripMenuItem2.Text = "Log Enable";
            this.logEnableToolStripMenuItem2.Click += new System.EventHandler(this.logEnableToolStripMenuItem2_Click);
            // 
            // moduleInforCreatorToolStripMenuItem
            // 
            this.moduleInforCreatorToolStripMenuItem.Name = "moduleInforCreatorToolStripMenuItem";
            this.moduleInforCreatorToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.moduleInforCreatorToolStripMenuItem.Text = "Module Info Creator";
            this.moduleInforCreatorToolStripMenuItem.Visible = false;
            this.moduleInforCreatorToolStripMenuItem.Click += new System.EventHandler(this.moduleInforCreatorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // scriptEditorToolStripMenuItem
            // 
            this.scriptEditorToolStripMenuItem.Name = "scriptEditorToolStripMenuItem";
            this.scriptEditorToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.scriptEditorToolStripMenuItem.Text = "Script Editor";
            this.scriptEditorToolStripMenuItem.Visible = false;
            this.scriptEditorToolStripMenuItem.Click += new System.EventHandler(this.scriptEditorToolStripMenuItem_Click);
            // 
            // leakageRSSIPlotToolStripMenuItem
            // 
            this.leakageRSSIPlotToolStripMenuItem.Name = "leakageRSSIPlotToolStripMenuItem";
            this.leakageRSSIPlotToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.leakageRSSIPlotToolStripMenuItem.Text = "Leakage RSSI Plot";
            this.leakageRSSIPlotToolStripMenuItem.Visible = false;
            this.leakageRSSIPlotToolStripMenuItem.Click += new System.EventHandler(this.leakageRSSIPlotToolStripMenuItem_Click);
            // 
            // readRangeToolStripMenuItem
            // 
            this.readRangeToolStripMenuItem.Name = "readRangeToolStripMenuItem";
            this.readRangeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.readRangeToolStripMenuItem.Text = "Read Range Calculator";
            this.readRangeToolStripMenuItem.Click += new System.EventHandler(this.readRangeToolStripMenuItem_Click);
            // 
            // sensorTagToolStripMenuItem
            // 
            this.sensorTagToolStripMenuItem.Name = "sensorTagToolStripMenuItem";
            this.sensorTagToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.sensorTagToolStripMenuItem.Text = "Sensor Tag";
            this.sensorTagToolStripMenuItem.Visible = false;
            this.sensorTagToolStripMenuItem.Click += new System.EventHandler(this.sensorTagToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // tsMenuAbout
            // 
            this.tsMenuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSubMenuAbout});
            this.tsMenuAbout.Name = "tsMenuAbout";
            this.tsMenuAbout.Size = new System.Drawing.Size(42, 20);
            this.tsMenuAbout.Text = "&Info.";
            this.tsMenuAbout.Visible = false;
            // 
            // tsSubMenuAbout
            // 
            this.tsSubMenuAbout.Name = "tsSubMenuAbout";
            this.tsSubMenuAbout.Size = new System.Drawing.Size(105, 22);
            this.tsSubMenuAbout.Text = "About";
            this.tsSubMenuAbout.Click += new System.EventHandler(this.tsSubMenuAbout_Click);
            // 
            // functionKeyToolStripMenuItem
            // 
            this.functionKeyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offsetPowerTableToolStripMenuItem,
            this.analogTPEnableToolStripMenuItem,
            this.resetModuleToolStripMenuItem,
            this.decodeSerialToolStripMenuItem,
            this.toggleLeakInfoToolStripMenuItem});
            this.functionKeyToolStripMenuItem.Name = "functionKeyToolStripMenuItem";
            this.functionKeyToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.functionKeyToolStripMenuItem.Text = "Function Key";
            this.functionKeyToolStripMenuItem.Visible = false;
            // 
            // offsetPowerTableToolStripMenuItem
            // 
            this.offsetPowerTableToolStripMenuItem.Name = "offsetPowerTableToolStripMenuItem";
            this.offsetPowerTableToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.offsetPowerTableToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.offsetPowerTableToolStripMenuItem.Text = "Offset & Power Table";
            this.offsetPowerTableToolStripMenuItem.Visible = false;
            this.offsetPowerTableToolStripMenuItem.Click += new System.EventHandler(this.offsetPowerTableToolStripMenuItem_Click);
            // 
            // analogTPEnableToolStripMenuItem
            // 
            this.analogTPEnableToolStripMenuItem.Name = "analogTPEnableToolStripMenuItem";
            this.analogTPEnableToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F9)));
            this.analogTPEnableToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.analogTPEnableToolStripMenuItem.Text = "Analog_TP_Enable";
            this.analogTPEnableToolStripMenuItem.Click += new System.EventHandler(this.analogTPEnableToolStripMenuItem_Click);
            // 
            // resetModuleToolStripMenuItem
            // 
            this.resetModuleToolStripMenuItem.Name = "resetModuleToolStripMenuItem";
            this.resetModuleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetModuleToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.resetModuleToolStripMenuItem.Text = "Reset Module";
            this.resetModuleToolStripMenuItem.Click += new System.EventHandler(this.resetModuleToolStripMenuItem_Click);
            // 
            // decodeSerialToolStripMenuItem
            // 
            this.decodeSerialToolStripMenuItem.Name = "decodeSerialToolStripMenuItem";
            this.decodeSerialToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.decodeSerialToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.decodeSerialToolStripMenuItem.Text = "Decode Serial";
            // 
            // toggleLeakInfoToolStripMenuItem
            // 
            this.toggleLeakInfoToolStripMenuItem.Name = "toggleLeakInfoToolStripMenuItem";
            this.toggleLeakInfoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.toggleLeakInfoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.toggleLeakInfoToolStripMenuItem.Text = "Toggle Leak Info";
            this.toggleLeakInfoToolStripMenuItem.Click += new System.EventHandler(this.toggleLeakInfoToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemClear,
            this.tsMenuItemCopy,
            this.tsMenuItemCopyAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 70);
            // 
            // tsMenuItemClear
            // 
            this.tsMenuItemClear.Name = "tsMenuItemClear";
            this.tsMenuItemClear.Size = new System.Drawing.Size(99, 22);
            this.tsMenuItemClear.Text = "C&lear";
            this.tsMenuItemClear.Click += new System.EventHandler(this.tsMenuItemClear_Click);
            // 
            // tsMenuItemCopy
            // 
            this.tsMenuItemCopy.Name = "tsMenuItemCopy";
            this.tsMenuItemCopy.Size = new System.Drawing.Size(99, 22);
            this.tsMenuItemCopy.Text = "&Copy";
            this.tsMenuItemCopy.Click += new System.EventHandler(this.tsMenuItemCopy_Click);
            // 
            // tsMenuItemCopyAll
            // 
            this.tsMenuItemCopyAll.Name = "tsMenuItemCopyAll";
            this.tsMenuItemCopyAll.Size = new System.Drawing.Size(99, 22);
            this.tsMenuItemCopyAll.Text = "Copy &All";
            this.tsMenuItemCopyAll.Click += new System.EventHandler(this.tsMenuItemCopyAll_Click);
            // 
            // saveFileDialogLog
            // 
            this.saveFileDialogLog.FileName = "*.log";
            this.saveFileDialogLog.Filter = "Log files (*.log)|*.log";
            this.saveFileDialogLog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogLog_FileOk);
            // 
            // saveFileDialogReport
            // 
            this.saveFileDialogReport.FileName = "*.rpt";
            this.saveFileDialogReport.Filter = "Report files (*.rpt)|*.rpt";
            this.saveFileDialogReport.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogReport_FileOk);
            // 
            // contextMenuStripTagInfo
            // 
            this.contextMenuStripTagInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTagMemoryToolStripMenuItem,
            this.copyTagIDToDataToolStripMenuItem,
            this.selectThisTagToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.clearTagListToolStripMenuItem});
            this.contextMenuStripTagInfo.Name = "contextMenuStripTagInfo";
            this.contextMenuStripTagInfo.Size = new System.Drawing.Size(197, 114);
            // 
            // viewTagMemoryToolStripMenuItem
            // 
            this.viewTagMemoryToolStripMenuItem.Name = "viewTagMemoryToolStripMenuItem";
            this.viewTagMemoryToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.viewTagMemoryToolStripMenuItem.Text = "View Tag Memory";
            // 
            // copyTagIDToDataToolStripMenuItem
            // 
            this.copyTagIDToDataToolStripMenuItem.Name = "copyTagIDToDataToolStripMenuItem";
            this.copyTagIDToDataToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.copyTagIDToDataToolStripMenuItem.Text = "Copy Tag ID to Data";
            this.copyTagIDToDataToolStripMenuItem.Click += new System.EventHandler(this.copyTagIDToDataToolStripMenuItem_Click);
            // 
            // selectThisTagToolStripMenuItem
            // 
            this.selectThisTagToolStripMenuItem.Name = "selectThisTagToolStripMenuItem";
            this.selectThisTagToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.selectThisTagToolStripMenuItem.Text = "Select this Tag";
            this.selectThisTagToolStripMenuItem.Click += new System.EventHandler(this.selectThisTagToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.clearToolStripMenuItem.Text = "Deselect Tag";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // clearTagListToolStripMenuItem
            // 
            this.clearTagListToolStripMenuItem.Name = "clearTagListToolStripMenuItem";
            this.clearTagListToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.clearTagListToolStripMenuItem.Text = "Clear Tag List";
            this.clearTagListToolStripMenuItem.Click += new System.EventHandler(this.clearTagListToolStripMenuItem_Click);
            // 
            // contextMenuStripMoreInfo
            // 
            this.contextMenuStripMoreInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moreInformationMemoryModificationToolStripMenuItem});
            this.contextMenuStripMoreInfo.Name = "contextMenuStripMoreInfo";
            this.contextMenuStripMoreInfo.Size = new System.Drawing.Size(320, 26);
            // 
            // moreInformationMemoryModificationToolStripMenuItem
            // 
            this.moreInformationMemoryModificationToolStripMenuItem.Name = "moreInformationMemoryModificationToolStripMenuItem";
            this.moreInformationMemoryModificationToolStripMenuItem.Size = new System.Drawing.Size(319, 22);
            this.moreInformationMemoryModificationToolStripMenuItem.Text = "More Information / Memory Modification";
            // 
            // contextMenuStriprichTextBox
            // 
            this.contextMenuStriprichTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem});
            this.contextMenuStriprichTextBox.Name = "contextMenuStriprichTextBox";
            this.contextMenuStriprichTextBox.Size = new System.Drawing.Size(133, 26);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // richTextBoxRCPDecoder
            // 
            this.richTextBoxRCPDecoder.Location = new System.Drawing.Point(1327, 378);
            this.richTextBoxRCPDecoder.Name = "richTextBoxRCPDecoder";
            this.richTextBoxRCPDecoder.Size = new System.Drawing.Size(433, 57);
            this.richTextBoxRCPDecoder.TabIndex = 45;
            this.richTextBoxRCPDecoder.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnConnect,
            this.toolStripBtnDisconnect,
            this.toolStripBtnPort,
            this.toolStripSeparator2,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripButton7,
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripSeparator4,
            this.toolStripBtnStartread,
            this.toolStripBtnStopRead,
            this.toolStripButton1,
            this.toolStripSeparator5,
            this.toolStripButton13,
            this.toolStripSeparator6,
            this.toolStripButton14});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(892, 25);
            this.toolStrip1.TabIndex = 48;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnConnect
            // 
            this.toolStripBtnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnConnect.Image = global::Phychips.PR9200.Properties.Resources.connect_established;
            this.toolStripBtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnConnect.Name = "toolStripBtnConnect";
            this.toolStripBtnConnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnConnect.Text = "Connect";
            this.toolStripBtnConnect.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripBtnDisconnect
            // 
            this.toolStripBtnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDisconnect.Image = global::Phychips.PR9200.Properties.Resources.connect_no;
            this.toolStripBtnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDisconnect.Name = "toolStripBtnDisconnect";
            this.toolStripBtnDisconnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnDisconnect.Text = "Disconnect";
            this.toolStripBtnDisconnect.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripBtnPort
            // 
            this.toolStripBtnPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPort.Image = global::Phychips.PR9200.Properties.Resources.usb;
            this.toolStripBtnPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPort.Name = "toolStripBtnPort";
            this.toolStripBtnPort.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnPort.Text = "Port Setting";
            this.toolStripBtnPort.Visible = false;
            this.toolStripBtnPort.Click += new System.EventHandler(this.portSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Phychips.PR9200.Properties.Resources.bottom;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Firmware Downloader";
            this.toolStripButton4.Visible = false;
            this.toolStripButton4.Click += new System.EventHandler(this.firmwareDownloaderToolStripMenuItem_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::Phychips.PR9200.Properties.Resources.toggle_log;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "RCP Logger";
            this.toolStripButton5.Visible = false;
            this.toolStripButton5.Click += new System.EventHandler(this.logEnableToolStripMenuItem2_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::Phychips.PR9200.Properties.Resources.klipper_dock;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Create Module Information";
            this.toolStripButton6.Visible = false;
            this.toolStripButton6.Click += new System.EventHandler(this.moduleInforCreatorToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::Phychips.PR9200.Properties.Resources.kate;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Script Editor";
            this.toolStripButton7.Visible = false;
            this.toolStripButton7.Click += new System.EventHandler(this.scriptEditorToolStripMenuItem_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::Phychips.PR9200.Properties.Resources.kmplot;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "Tx Leakage RSSI Plot";
            this.toolStripButton9.Visible = false;
            this.toolStripButton9.Click += new System.EventHandler(this.leakageRSSIPlotToolStripMenuItem_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = global::Phychips.PR9200.Properties.Resources.kcalc;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton10.Text = "Read Range Calculator";
            this.toolStripButton10.Visible = false;
            this.toolStripButton10.Click += new System.EventHandler(this.readRangeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnStartread
            // 
            this.toolStripBtnStartread.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnStartread.Image = global::Phychips.PR9200.Properties.Resources.player_play;
            this.toolStripBtnStartread.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnStartread.Name = "toolStripBtnStartread";
            this.toolStripBtnStartread.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnStartread.Text = "Start Read";
            this.toolStripBtnStartread.Click += new System.EventHandler(this.buttonReadMultiple_Click);
            // 
            // toolStripBtnStopRead
            // 
            this.toolStripBtnStopRead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnStopRead.Enabled = false;
            this.toolStripBtnStopRead.Image = global::Phychips.PR9200.Properties.Resources.player_stop;
            this.toolStripBtnStopRead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnStopRead.Name = "toolStripBtnStopRead";
            this.toolStripBtnStopRead.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnStopRead.Text = "Stop Read";
            this.toolStripBtnStopRead.Click += new System.EventHandler(this.buttonReadMultiple_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Phychips.PR9200.Properties.Resources.reload;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Reset";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.resetModuleToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = global::Phychips.PR9200.Properties.Resources.kcmsystem;
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton13.Text = "Control Panel";
            this.toolStripButton13.Visible = false;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = global::Phychips.PR9200.Properties.Resources.messagebox_info;
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton14.Text = "About";
            this.toolStripButton14.Visible = false;
            this.toolStripButton14.Click += new System.EventHandler(this.tsSubMenuAbout_Click);
            // 
            // contextMenuStripReadButton
            // 
            this.contextMenuStripReadButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.withRSSIToolStripMenuItem,
            this.withTIDToolStripMenuItem,
            this.contitionalReadToolStripMenuItem});
            this.contextMenuStripReadButton.Name = "contextMenuStripReadButton";
            this.contextMenuStripReadButton.Size = new System.Drawing.Size(177, 70);
            this.contextMenuStripReadButton.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStripReadButton_Closing);
            // 
            // withRSSIToolStripMenuItem
            // 
            this.withRSSIToolStripMenuItem.Name = "withRSSIToolStripMenuItem";
            this.withRSSIToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.withRSSIToolStripMenuItem.Text = "with RSSI";
            this.withRSSIToolStripMenuItem.Click += new System.EventHandler(this.withRSSIToolStripMenuItem_Click);
            // 
            // withTIDToolStripMenuItem
            // 
            this.withTIDToolStripMenuItem.Name = "withTIDToolStripMenuItem";
            this.withTIDToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.withTIDToolStripMenuItem.Text = "with TID";
            this.withTIDToolStripMenuItem.Click += new System.EventHandler(this.withTIDToolStripMenuItem_Click);
            // 
            // contitionalReadToolStripMenuItem
            // 
            this.contitionalReadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secondToolStripMenuItem,
            this.cycleToolStripMenuItem});
            this.contitionalReadToolStripMenuItem.Name = "contitionalReadToolStripMenuItem";
            this.contitionalReadToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.contitionalReadToolStripMenuItem.Text = "Conditional Read";
            // 
            // secondToolStripMenuItem
            // 
            this.secondToolStripMenuItem.Name = "secondToolStripMenuItem";
            this.secondToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.secondToolStripMenuItem.Text = "Seconds";
            this.secondToolStripMenuItem.Click += new System.EventHandler(this.secondToolStripMenuItem_Click);
            // 
            // cycleToolStripMenuItem
            // 
            this.cycleToolStripMenuItem.Name = "cycleToolStripMenuItem";
            this.cycleToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.cycleToolStripMenuItem.Text = "Cycle";
            this.cycleToolStripMenuItem.Click += new System.EventHandler(this.cycleToolStripMenuItem_Click);
            // 
            // timerAutoConnect
            // 
            this.timerAutoConnect.Interval = 2000;
            this.timerAutoConnect.Tick += new System.EventHandler(this.timerAutoConnect_Tick);
            // 
            // ReadRateTimer
            // 
            this.ReadRateTimer.Tick += new System.EventHandler(this.ReadRateTimer_Tick);
            // 
            // timerProgressCircle
            // 
            this.timerProgressCircle.Interval = 500;
            this.timerProgressCircle.Tick += new System.EventHandler(this.timerProgressCircle_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabReadWriteErase);
            this.tabControl1.Location = new System.Drawing.Point(1068, 154);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(429, 291);
            this.tabControl1.TabIndex = 2276;
            // 
            // tabReadWriteErase
            // 
            this.tabReadWriteErase.Controls.Add(this.buttonReadTagMemoryEx);
            this.tabReadWriteErase.Controls.Add(this.buttonBlockWriteDataToTag);
            this.tabReadWriteErase.Controls.Add(this.label6);
            this.tabReadWriteErase.Controls.Add(this.buttonBlockEraseTagMemory);
            this.tabReadWriteErase.Controls.Add(this.cbTagRwTarMem);
            this.tabReadWriteErase.Controls.Add(this.buttonWriteDataToTag);
            this.tabReadWriteErase.Controls.Add(this.label14);
            this.tabReadWriteErase.Controls.Add(this.label3);
            this.tabReadWriteErase.Controls.Add(this.label11);
            this.tabReadWriteErase.Controls.Add(this.buttonReadTagMemory);
            this.tabReadWriteErase.Controls.Add(this.label10);
            this.tabReadWriteErase.Controls.Add(this.textBoxRwStartAdd);
            this.tabReadWriteErase.Controls.Add(this.textBoxRwLength);
            this.tabReadWriteErase.Controls.Add(this.textBoxRwAccessPw);
            this.tabReadWriteErase.Controls.Add(this.textBoxRwData);
            this.tabReadWriteErase.Location = new System.Drawing.Point(4, 24);
            this.tabReadWriteErase.Name = "tabReadWriteErase";
            this.tabReadWriteErase.Padding = new System.Windows.Forms.Padding(3);
            this.tabReadWriteErase.Size = new System.Drawing.Size(421, 263);
            this.tabReadWriteErase.TabIndex = 3;
            this.tabReadWriteErase.Text = "Memory Access";
            this.tabReadWriteErase.UseVisualStyleBackColor = true;
            // 
            // buttonReadTagMemoryEx
            // 
            this.buttonReadTagMemoryEx.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReadTagMemoryEx.Location = new System.Drawing.Point(10, 217);
            this.buttonReadTagMemoryEx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonReadTagMemoryEx.Name = "buttonReadTagMemoryEx";
            this.buttonReadTagMemoryEx.Size = new System.Drawing.Size(155, 30);
            this.buttonReadTagMemoryEx.TabIndex = 66;
            this.buttonReadTagMemoryEx.Text = "Read long tag memory";
            this.buttonReadTagMemoryEx.UseVisualStyleBackColor = true;
            this.buttonReadTagMemoryEx.Click += new System.EventHandler(this.buttonReadTagMemoryEx_Click);
            // 
            // buttonBlockWriteDataToTag
            // 
            this.buttonBlockWriteDataToTag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlockWriteDataToTag.Location = new System.Drawing.Point(9, 179);
            this.buttonBlockWriteDataToTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBlockWriteDataToTag.Name = "buttonBlockWriteDataToTag";
            this.buttonBlockWriteDataToTag.Size = new System.Drawing.Size(156, 30);
            this.buttonBlockWriteDataToTag.TabIndex = 57;
            this.buttonBlockWriteDataToTag.Text = "Block Write data to tag";
            this.buttonBlockWriteDataToTag.UseVisualStyleBackColor = true;
            this.buttonBlockWriteDataToTag.Click += new System.EventHandler(this.buttonBlockWriteDataToTag_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 15);
            this.label6.TabIndex = 55;
            this.label6.Text = "Access Password (HEX)";
            // 
            // buttonBlockEraseTagMemory
            // 
            this.buttonBlockEraseTagMemory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlockEraseTagMemory.Location = new System.Drawing.Point(172, 179);
            this.buttonBlockEraseTagMemory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBlockEraseTagMemory.Name = "buttonBlockEraseTagMemory";
            this.buttonBlockEraseTagMemory.Size = new System.Drawing.Size(156, 30);
            this.buttonBlockEraseTagMemory.TabIndex = 65;
            this.buttonBlockEraseTagMemory.Text = "Block Erase tag memory";
            this.buttonBlockEraseTagMemory.UseVisualStyleBackColor = true;
            this.buttonBlockEraseTagMemory.Click += new System.EventHandler(this.buttonBlockEraseTagMemory_Click);
            // 
            // cbTagRwTarMem
            // 
            this.cbTagRwTarMem.FormattingEnabled = true;
            this.cbTagRwTarMem.Items.AddRange(new object[] {
            "RFU",
            "EPC",
            "TID",
            "User"});
            this.cbTagRwTarMem.Location = new System.Drawing.Point(9, 73);
            this.cbTagRwTarMem.Name = "cbTagRwTarMem";
            this.cbTagRwTarMem.Size = new System.Drawing.Size(84, 23);
            this.cbTagRwTarMem.TabIndex = 43;
            // 
            // buttonWriteDataToTag
            // 
            this.buttonWriteDataToTag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWriteDataToTag.Location = new System.Drawing.Point(172, 144);
            this.buttonWriteDataToTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonWriteDataToTag.Name = "buttonWriteDataToTag";
            this.buttonWriteDataToTag.Size = new System.Drawing.Size(156, 30);
            this.buttonWriteDataToTag.TabIndex = 49;
            this.buttonWriteDataToTag.Text = "Write data to tag";
            this.buttonWriteDataToTag.UseVisualStyleBackColor = true;
            this.buttonWriteDataToTag.Click += new System.EventHandler(this.buttonWriteDataToTag_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 15);
            this.label14.TabIndex = 46;
            this.label14.Text = "Data (HEX)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 44;
            this.label3.Text = "Target Memory";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(155, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 15);
            this.label11.TabIndex = 41;
            this.label11.Text = "Length (Word Count)";
            // 
            // buttonReadTagMemory
            // 
            this.buttonReadTagMemory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReadTagMemory.Location = new System.Drawing.Point(9, 144);
            this.buttonReadTagMemory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonReadTagMemory.Name = "buttonReadTagMemory";
            this.buttonReadTagMemory.Size = new System.Drawing.Size(156, 30);
            this.buttonReadTagMemory.TabIndex = 39;
            this.buttonReadTagMemory.Text = "Read tag memory";
            this.buttonReadTagMemory.UseVisualStyleBackColor = true;
            this.buttonReadTagMemory.Click += new System.EventHandler(this.buttonReadTagMemory_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(155, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 15);
            this.label10.TabIndex = 40;
            this.label10.Text = "Start Address (Word Ptr)";
            // 
            // textBoxRwStartAdd
            // 
            this.textBoxRwStartAdd.Font = new System.Drawing.Font("Arial", 10F);
            this.textBoxRwStartAdd.Location = new System.Drawing.Point(157, 26);
            this.textBoxRwStartAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxRwStartAdd.Name = "textBoxRwStartAdd";
            this.textBoxRwStartAdd.Size = new System.Drawing.Size(136, 23);
            this.textBoxRwStartAdd.TabIndex = 35;
            this.textBoxRwStartAdd.Text = "0";
            this.textBoxRwStartAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRwLength
            // 
            this.textBoxRwLength.Font = new System.Drawing.Font("Arial", 10F);
            this.textBoxRwLength.Location = new System.Drawing.Point(157, 73);
            this.textBoxRwLength.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxRwLength.Name = "textBoxRwLength";
            this.textBoxRwLength.Size = new System.Drawing.Size(136, 23);
            this.textBoxRwLength.TabIndex = 42;
            this.textBoxRwLength.Text = "6";
            this.textBoxRwLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRwAccessPw
            // 
            this.textBoxRwAccessPw.Font = new System.Drawing.Font("Arial", 9F);
            this.textBoxRwAccessPw.Location = new System.Drawing.Point(9, 25);
            this.textBoxRwAccessPw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxRwAccessPw.Name = "textBoxRwAccessPw";
            this.textBoxRwAccessPw.Size = new System.Drawing.Size(84, 21);
            this.textBoxRwAccessPw.TabIndex = 56;
            this.textBoxRwAccessPw.Text = "00 00 00 00";
            // 
            // textBoxRwData
            // 
            this.textBoxRwData.Font = new System.Drawing.Font("Arial", 9F);
            this.textBoxRwData.Location = new System.Drawing.Point(9, 118);
            this.textBoxRwData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxRwData.Name = "textBoxRwData";
            this.textBoxRwData.Size = new System.Drawing.Size(370, 21);
            this.textBoxRwData.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1061, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 83;
            this.label2.Text = "EPC：";
            // 
            // txtEPCCode
            // 
            this.txtEPCCode.Location = new System.Drawing.Point(1111, 104);
            this.txtEPCCode.Name = "txtEPCCode";
            this.txtEPCCode.ReadOnly = true;
            this.txtEPCCode.Size = new System.Drawing.Size(382, 21);
            this.txtEPCCode.TabIndex = 82;
            // 
            // progressCircle
            // 
            this.progressCircle.BackColor = System.Drawing.Color.Transparent;
            this.progressCircle.ForeColor = System.Drawing.Color.Transparent;
            this.progressCircle.Interval = 100;
            this.progressCircle.Location = new System.Drawing.Point(1280, 235);
            this.progressCircle.Name = "progressCircle";
            this.progressCircle.RingColor = System.Drawing.Color.Transparent;
            this.progressCircle.RingThickness = 8;
            this.progressCircle.Size = new System.Drawing.Size(18, 18);
            this.progressCircle.TabIndex = 49;
            this.progressCircle.Visible = false;
            // 
            // buttonReadMultiple
            // 
            this.buttonReadMultiple.Font = new System.Drawing.Font("Arial", 9F);
            this.buttonReadMultiple.Location = new System.Drawing.Point(1331, 172);
            this.buttonReadMultiple.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonReadMultiple.Name = "buttonReadMultiple";
            this.buttonReadMultiple.Size = new System.Drawing.Size(89, 27);
            this.buttonReadMultiple.TabIndex = 35;
            this.buttonReadMultiple.Text = " Start ";
            this.buttonReadMultiple.UseVisualStyleBackColor = true;
            this.buttonReadMultiple.Click += new System.EventHandler(this.buttonReadMultiple_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdRecordList);
            this.groupControl1.Location = new System.Drawing.Point(10, 298);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(873, 385);
            this.groupControl1.TabIndex = 2278;
            this.groupControl1.Text = "标签录入记录";
            // 
            // grdRecordList
            // 
            this.grdRecordList.ContextMenuStrip = this.contextMenuStrip2;
            this.grdRecordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRecordList.Location = new System.Drawing.Point(2, 21);
            this.grdRecordList.MainView = this.gvRecordList;
            this.grdRecordList.Name = "grdRecordList";
            this.grdRecordList.Size = new System.Drawing.Size(869, 362);
            this.grdRecordList.TabIndex = 0;
            this.grdRecordList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRecordList});
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "删除选中标签";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // gvRecordList
            // 
            this.gvRecordList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvRecordList.GridControl = this.grdRecordList;
            this.gvRecordList.Name = "gvRecordList";
            this.gvRecordList.OptionsView.ShowFooter = true;
            this.gvRecordList.OptionsView.ShowGroupPanel = false;
            this.gvRecordList.RowHeight = 30;
            this.gvRecordList.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvRecordList_CustomColumnDisplayText);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "标签ID";
            this.gridColumn1.FieldName = "tag_id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "tag_id", "当日记录数:{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 231;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ISBN号";
            this.gridColumn2.FieldName = "isbn";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 172;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "状态";
            this.gridColumn3.FieldName = "status";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 137;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "录入时间";
            this.gridColumn4.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "create_time";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 132;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "图书名称";
            this.gridColumn5.FieldName = "book_name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 179;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.radioBookType);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.chkAutoWiteEPC);
            this.groupControl2.Controls.Add(this.txtISBN);
            this.groupControl2.Controls.Add(this.txtTagID);
            this.groupControl2.Controls.Add(this.label30);
            this.groupControl2.Controls.Add(this.lueBookInfo);
            this.groupControl2.Controls.Add(this.label28);
            this.groupControl2.Controls.Add(this.btnClear);
            this.groupControl2.Controls.Add(this.btnReadTagID);
            this.groupControl2.Controls.Add(this.chkAutoSave);
            this.groupControl2.Controls.Add(this.btnSave);
            this.groupControl2.Controls.Add(this.label7);
            this.groupControl2.Controls.Add(this.lbTagCount);
            this.groupControl2.Controls.Add(this.labelSelectedTag);
            this.groupControl2.Controls.Add(this.textBox_RepeatCycle);
            this.groupControl2.Controls.Add(this.textBox_MTIME);
            this.groupControl2.Controls.Add(this.labelCycle);
            this.groupControl2.Controls.Add(this.labelReadfor);
            this.groupControl2.Controls.Add(this.labelSeconds);
            this.groupControl2.Location = new System.Drawing.Point(10, 58);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(873, 234);
            this.groupControl2.TabIndex = 2279;
            this.groupControl2.Text = "标签录入区";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 2298;
            this.label4.Text = "对应图书类型：";
            // 
            // radioBookType
            // 
            this.radioBookType.EditValue = ((short)(1));
            this.radioBookType.Location = new System.Drawing.Point(130, 106);
            this.radioBookType.Name = "radioBookType";
            this.radioBookType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioBookType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "单本图书"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "相同ISBN丛书")});
            this.radioBookType.Size = new System.Drawing.Size(724, 30);
            this.radioBookType.TabIndex = 2293;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 2294;
            this.label1.Text = "图书名称：";
            // 
            // chkAutoWiteEPC
            // 
            this.chkAutoWiteEPC.EditValue = true;
            this.chkAutoWiteEPC.Location = new System.Drawing.Point(440, 194);
            this.chkAutoWiteEPC.Name = "chkAutoWiteEPC";
            this.chkAutoWiteEPC.Properties.Caption = "自动写入标签ID到EPC区";
            this.chkAutoWiteEPC.Size = new System.Drawing.Size(160, 19);
            this.chkAutoWiteEPC.TabIndex = 2292;
            this.chkAutoWiteEPC.Visible = false;
            // 
            // txtISBN
            // 
            this.txtISBN.EditValue = "";
            this.txtISBN.Location = new System.Drawing.Point(130, 68);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtISBN.Properties.Appearance.Options.UseBackColor = true;
            this.txtISBN.Properties.AutoHeight = false;
            this.txtISBN.Properties.NullText = "在此区域扫描图书ISBN号码";
            this.txtISBN.Size = new System.Drawing.Size(724, 28);
            this.txtISBN.TabIndex = 2290;
            this.txtISBN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtISBN_KeyPress);
            this.txtISBN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtISBN_KeyUp);
            // 
            // txtTagID
            // 
            this.txtTagID.EditValue = "";
            this.txtTagID.Location = new System.Drawing.Point(130, 34);
            this.txtTagID.Name = "txtTagID";
            this.txtTagID.Properties.AutoHeight = false;
            this.txtTagID.Properties.NullText = "放入标签";
            this.txtTagID.Properties.ReadOnly = true;
            this.txtTagID.Size = new System.Drawing.Size(724, 28);
            this.txtTagID.TabIndex = 2289;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(57, 75);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(57, 14);
            this.label30.TabIndex = 2288;
            this.label30.Text = "ISBN号：";
            // 
            // lueBookInfo
            // 
            this.lueBookInfo.Location = new System.Drawing.Point(130, 144);
            this.lueBookInfo.Name = "lueBookInfo";
            this.lueBookInfo.Properties.AutoHeight = false;
            this.lueBookInfo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBookInfo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("isbn_no", 50, "ISBN"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("book_name", 150, "图书名称")});
            this.lueBookInfo.Properties.NullText = "";
            this.lueBookInfo.Size = new System.Drawing.Size(724, 28);
            this.lueBookInfo.TabIndex = 2297;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(35, 41);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 14);
            this.label28.TabIndex = 2287;
            this.label28.Text = "RFID标签ID：";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(699, 192);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2286;
            this.btnClear.Text = "清   空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReadTagID
            // 
            this.btnReadTagID.Location = new System.Drawing.Point(779, 192);
            this.btnReadTagID.Name = "btnReadTagID";
            this.btnReadTagID.Size = new System.Drawing.Size(75, 23);
            this.btnReadTagID.TabIndex = 92;
            this.btnReadTagID.Text = "读取";
            this.btnReadTagID.Visible = false;
            this.btnReadTagID.Click += new System.EventHandler(this.btnReadTagID_Click);
            // 
            // chkAutoSave
            // 
            this.chkAutoSave.EditValue = true;
            this.chkAutoSave.Location = new System.Drawing.Point(779, 235);
            this.chkAutoSave.Name = "chkAutoSave";
            this.chkAutoSave.Properties.Caption = "自动录入";
            this.chkAutoSave.Size = new System.Drawing.Size(75, 19);
            this.chkAutoSave.TabIndex = 91;
            this.chkAutoSave.Visible = false;
            this.chkAutoSave.CheckedChanged += new System.EventHandler(this.chkAutoSave_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(617, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 90;
            this.btnSave.Text = "录  入";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 76;
            this.label7.Text = "Read tags :";
            // 
            // lbTagCount
            // 
            this.lbTagCount.AutoSize = true;
            this.lbTagCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTagCount.Location = new System.Drawing.Point(111, 295);
            this.lbTagCount.Name = "lbTagCount";
            this.lbTagCount.Size = new System.Drawing.Size(14, 15);
            this.lbTagCount.TabIndex = 76;
            this.lbTagCount.Text = "0";
            // 
            // labelSelectedTag
            // 
            this.labelSelectedTag.AutoSize = true;
            this.labelSelectedTag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedTag.Location = new System.Drawing.Point(35, 295);
            this.labelSelectedTag.Name = "labelSelectedTag";
            this.labelSelectedTag.Size = new System.Drawing.Size(92, 15);
            this.labelSelectedTag.TabIndex = 79;
            this.labelSelectedTag.Text = "Selected EPC : ";
            this.labelSelectedTag.Visible = false;
            // 
            // textBox_RepeatCycle
            // 
            this.textBox_RepeatCycle.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_RepeatCycle.Location = new System.Drawing.Point(425, 292);
            this.textBox_RepeatCycle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_RepeatCycle.Name = "textBox_RepeatCycle";
            this.textBox_RepeatCycle.Size = new System.Drawing.Size(31, 21);
            this.textBox_RepeatCycle.TabIndex = 69;
            this.textBox_RepeatCycle.Text = "0";
            this.textBox_RepeatCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_RepeatCycle.Visible = false;
            this.textBox_RepeatCycle.TextChanged += new System.EventHandler(this.textBox_RepeatCycle_TextChanged);
            // 
            // textBox_MTIME
            // 
            this.textBox_MTIME.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_MTIME.Location = new System.Drawing.Point(425, 292);
            this.textBox_MTIME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_MTIME.Name = "textBox_MTIME";
            this.textBox_MTIME.Size = new System.Drawing.Size(31, 21);
            this.textBox_MTIME.TabIndex = 73;
            this.textBox_MTIME.Text = "0";
            this.textBox_MTIME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_MTIME.Visible = false;
            this.textBox_MTIME.TextChanged += new System.EventHandler(this.textBox_MTIME_TextChanged);
            // 
            // labelCycle
            // 
            this.labelCycle.AutoSize = true;
            this.labelCycle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCycle.Location = new System.Drawing.Point(462, 295);
            this.labelCycle.Name = "labelCycle";
            this.labelCycle.Size = new System.Drawing.Size(41, 15);
            this.labelCycle.TabIndex = 76;
            this.labelCycle.Text = "cycles";
            this.labelCycle.Visible = false;
            // 
            // labelReadfor
            // 
            this.labelReadfor.AutoSize = true;
            this.labelReadfor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReadfor.Location = new System.Drawing.Point(365, 295);
            this.labelReadfor.Name = "labelReadfor";
            this.labelReadfor.Size = new System.Drawing.Size(54, 15);
            this.labelReadfor.TabIndex = 72;
            this.labelReadfor.Text = "Read for";
            this.labelReadfor.Visible = false;
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeconds.Location = new System.Drawing.Point(462, 295);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(55, 15);
            this.labelSeconds.TabIndex = 78;
            this.labelSeconds.Text = "seconds";
            this.labelSeconds.Visible = false;
            // 
            // listViewEPC
            // 
            this.listViewEPC.AutoArrange = false;
            this.listViewEPC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cNumber,
            this.cPC,
            this.cEPC,
            this.cCnt,
            this.cRssi});
            this.listViewEPC.Font = new System.Drawing.Font("Arial", 9F);
            this.listViewEPC.FullRowSelect = true;
            this.listViewEPC.Location = new System.Drawing.Point(1327, 245);
            this.listViewEPC.MultiSelect = false;
            this.listViewEPC.Name = "listViewEPC";
            this.listViewEPC.Size = new System.Drawing.Size(433, 125);
            this.listViewEPC.TabIndex = 4;
            this.listViewEPC.UseCompatibleStateImageBehavior = false;
            this.listViewEPC.View = System.Windows.Forms.View.Details;
            this.listViewEPC.Click += new System.EventHandler(this.listViewEPC_Click);
            // 
            // cNumber
            // 
            this.cNumber.Text = "";
            this.cNumber.Width = 23;
            // 
            // cPC
            // 
            this.cPC.Text = "PC";
            this.cPC.Width = 50;
            // 
            // cEPC
            // 
            this.cEPC.Text = "EPC";
            this.cEPC.Width = 400;
            // 
            // cCnt
            // 
            this.cCnt.Text = "Count";
            this.cCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cCnt.Width = 50;
            // 
            // cRssi
            // 
            this.cRssi.Text = "Tag RSSI";
            this.cRssi.Width = 70;
            // 
            // FromTaginitialize
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(892, 711);
            this.Controls.Add(this.listViewEPC);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtEPCCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBoxRCPDecoder);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonReadMultiple);
            this.Controls.Add(this.progressCircle);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(667, 725);
            this.Name = "FromTaginitialize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超高频标签图书初始化程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSDK_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FromTaginitialize_FormClosed);
            this.Load += new System.EventHandler(this.FormSDK_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStripTagInfo.ResumeLayout(false);
            this.contextMenuStripMoreInfo.ResumeLayout(false);
            this.contextMenuStriprichTextBox.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStripReadButton.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabReadWriteErase.ResumeLayout(false);
            this.tabReadWriteErase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecordList)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioBookType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoWiteEPC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtISBN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTagID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBookInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoSave.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusPort;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusBr;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusPortOpen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemClear;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemCopyAll;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLog;
        private System.Windows.Forms.ToolStripMenuItem tsMenuAbout;
        private System.Windows.Forms.ToolStripStatusLabel tsFWVersion;
        private System.Windows.Forms.ToolStripStatusLabel tsPartNumber;
        private System.Windows.Forms.ToolStripMenuItem tsSubMenuAbout;
        private System.Windows.Forms.SaveFileDialog saveFileDialogReport;
        private System.Windows.Forms.ToolStripMenuItem functionKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offsetPowerTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analogTPEnableToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTagInfo;
        private System.Windows.Forms.ToolStripMenuItem viewTagMemoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTagIDToDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectThisTagToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMoreInfo;
        private System.Windows.Forms.ToolStripMenuItem moreInformationMemoryModificationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStriprichTextBox;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxRCPDecoder;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetModuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firmwareDownloaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rCPLoggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logEnableToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem moduleInforCreatorToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtnConnect;
        private System.Windows.Forms.ToolStripButton toolStripBtnDisconnect;
        private System.Windows.Forms.ToolStripButton toolStripBtnPort;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem leakageRSSIPlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readRangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripBtnStartread;
        private System.Windows.Forms.ToolStripButton toolStripBtnStopRead;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripReadButton;
        private System.Windows.Forms.ToolStripMenuItem withRSSIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contitionalReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cycleToolStripMenuItem;
        private System.Windows.Forms.Timer timerAutoConnect;
        private System.Windows.Forms.Timer ReadRateTimer;
        private System.Windows.Forms.ToolStripMenuItem withTIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTagListToolStripMenuItem;
        private System.Windows.Forms.Timer timerProgressCircle;
        private System.Windows.Forms.ToolStripMenuItem decodeSerialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleLeakInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sensorTagToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReadWriteErase;
        private System.Windows.Forms.Button buttonReadTagMemoryEx;
        private System.Windows.Forms.Button buttonBlockWriteDataToTag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonBlockEraseTagMemory;
        private System.Windows.Forms.ComboBox cbTagRwTarMem;
        private System.Windows.Forms.Button buttonWriteDataToTag;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonReadTagMemory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxRwStartAdd;
        private System.Windows.Forms.TextBox textBoxRwLength;
        private System.Windows.Forms.TextBox textBoxRwAccessPw;
        private System.Windows.Forms.TextBox textBoxRwData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEPCCode;
        private Utezduyar.Windows.Forms.ProgressCircle progressCircle;
        private System.Windows.Forms.Button buttonReadMultiple;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdRecordList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRecordList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.ListView listViewEPC;
        private System.Windows.Forms.ColumnHeader cNumber;
        private System.Windows.Forms.ColumnHeader cPC;
        private System.Windows.Forms.ColumnHeader cEPC;
        private System.Windows.Forms.ColumnHeader cCnt;
        private System.Windows.Forms.ColumnHeader cRssi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbTagCount;
        private System.Windows.Forms.Label labelSelectedTag;
        private System.Windows.Forms.TextBox textBox_RepeatCycle;
        private System.Windows.Forms.TextBox textBox_MTIME;
        private System.Windows.Forms.Label labelCycle;
        private System.Windows.Forms.Label labelReadfor;
        private System.Windows.Forms.Label labelSeconds;
        private DevExpress.XtraEditors.CheckEdit chkAutoSave;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraEditors.SimpleButton btnReadTagID;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label30;
        private DevExpress.XtraEditors.TextEdit txtTagID;
        private DevExpress.XtraEditors.TextEdit txtISBN;
        private DevExpress.XtraEditors.CheckEdit chkAutoWiteEPC;
        private DevExpress.XtraEditors.RadioGroup radioBookType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lueBookInfo;
        private System.Windows.Forms.Label label4;
    }
}