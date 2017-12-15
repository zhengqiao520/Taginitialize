namespace Phychips.PR9200
{
    partial class UserControlSensorTag
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBoxTagList = new System.Windows.Forms.GroupBox();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.labelReadTagsVal = new System.Windows.Forms.Label();
            this.labelReadTags = new System.Windows.Forms.Label();
            this.listViewEPC = new System.Windows.Forms.ListView();
            this.cNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cEPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cRssi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cOnChipRSSI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSensorCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCalData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTemperature = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxMonitor = new System.Windows.Forms.GroupBox();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.textBoxSMaxVal = new System.Windows.Forms.TextBox();
            this.labelHorizontal = new System.Windows.Forms.Label();
            this.textBoxSMinVal = new System.Windows.Forms.TextBox();
            this.buttonHleft = new System.Windows.Forms.Button();
            this.labelSecondaryYMin = new System.Windows.Forms.Label();
            this.buttonHright = new System.Windows.Forms.Button();
            this.labelSecondaryYMax = new System.Windows.Forms.Label();
            this.labelPrimaryYMax = new System.Windows.Forms.Label();
            this.labelPrimaryYMin = new System.Windows.Forms.Label();
            this.textBoxVMinVal = new System.Windows.Forms.TextBox();
            this.textBoxVMaxVal = new System.Windows.Forms.TextBox();
            this.groupBoxOnchipRSSI = new System.Windows.Forms.GroupBox();
            this.labelValidVal = new System.Windows.Forms.Label();
            this.groupBoxCodeValue = new System.Windows.Forms.GroupBox();
            this.labelTempMonitorVal = new System.Windows.Forms.Label();
            this.groupBoxTagIC = new System.Windows.Forms.GroupBox();
            this.labelTagIC = new System.Windows.Forms.Label();
            this.labelPYaxisName = new System.Windows.Forms.Label();
            this.labelSYaxisName = new System.Windows.Forms.Label();
            this.ChartMonitor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStripChart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerUpdateTag = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStripTagInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxTagList.SuspendLayout();
            this.groupBoxMonitor.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.groupBoxOnchipRSSI.SuspendLayout();
            this.groupBoxCodeValue.SuspendLayout();
            this.groupBoxTagIC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMonitor)).BeginInit();
            this.contextMenuStripChart.SuspendLayout();
            this.contextMenuStripTagInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTagList
            // 
            this.groupBoxTagList.Controls.Add(this.buttonInventory);
            this.groupBoxTagList.Controls.Add(this.labelReadTagsVal);
            this.groupBoxTagList.Controls.Add(this.labelReadTags);
            this.groupBoxTagList.Controls.Add(this.listViewEPC);
            this.groupBoxTagList.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTagList.Name = "groupBoxTagList";
            this.groupBoxTagList.Size = new System.Drawing.Size(983, 240);
            this.groupBoxTagList.TabIndex = 3;
            this.groupBoxTagList.TabStop = false;
            this.groupBoxTagList.Text = "Tag List";
            // 
            // buttonInventory
            // 
            this.buttonInventory.Location = new System.Drawing.Point(902, 202);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(75, 23);
            this.buttonInventory.TabIndex = 0;
            this.buttonInventory.Text = "Start";
            this.buttonInventory.UseVisualStyleBackColor = true;
            this.buttonInventory.Click += new System.EventHandler(this.buttonInventory_Click);
            // 
            // labelReadTagsVal
            // 
            this.labelReadTagsVal.AutoSize = true;
            this.labelReadTagsVal.Location = new System.Drawing.Point(91, 213);
            this.labelReadTagsVal.Name = "labelReadTagsVal";
            this.labelReadTagsVal.Size = new System.Drawing.Size(11, 12);
            this.labelReadTagsVal.TabIndex = 7;
            this.labelReadTagsVal.Text = "0";
            // 
            // labelReadTags
            // 
            this.labelReadTags.AutoSize = true;
            this.labelReadTags.Location = new System.Drawing.Point(6, 213);
            this.labelReadTags.Name = "labelReadTags";
            this.labelReadTags.Size = new System.Drawing.Size(79, 12);
            this.labelReadTags.TabIndex = 6;
            this.labelReadTags.Text = "Read Tags : ";
            // 
            // listViewEPC
            // 
            this.listViewEPC.AutoArrange = false;
            this.listViewEPC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cNumber,
            this.cPC,
            this.cEPC,
            this.cCnt,
            this.cRssi,
            this.cOnChipRSSI,
            this.cSensorCode,
            this.cCalData,
            this.cTemperature});
            this.listViewEPC.Font = new System.Drawing.Font("Arial", 9F);
            this.listViewEPC.FullRowSelect = true;
            this.listViewEPC.Location = new System.Drawing.Point(6, 20);
            this.listViewEPC.MultiSelect = false;
            this.listViewEPC.Name = "listViewEPC";
            this.listViewEPC.Size = new System.Drawing.Size(971, 176);
            this.listViewEPC.TabIndex = 5;
            this.listViewEPC.UseCompatibleStateImageBehavior = false;
            this.listViewEPC.View = System.Windows.Forms.View.Details;
            // 
            // cNumber
            // 
            this.cNumber.Text = "";
            this.cNumber.Width = 30;
            // 
            // cPC
            // 
            this.cPC.Text = "PC";
            this.cPC.Width = 50;
            // 
            // cEPC
            // 
            this.cEPC.Text = "EPC";
            this.cEPC.Width = 237;
            // 
            // cCnt
            // 
            this.cCnt.Text = "Count";
            this.cCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cCnt.Width = 50;
            // 
            // cRssi
            // 
            this.cRssi.Text = "Code Type";
            this.cRssi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cRssi.Width = 103;
            // 
            // cOnChipRSSI
            // 
            this.cOnChipRSSI.Text = "On-Chip RSSI";
            this.cOnChipRSSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cOnChipRSSI.Width = 89;
            // 
            // cSensorCode
            // 
            this.cSensorCode.Text = "Sensor/Temp Code";
            this.cSensorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cSensorCode.Width = 120;
            // 
            // cCalData
            // 
            this.cCalData.Text = "Cal. Data";
            this.cCalData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cCalData.Width = 198;
            // 
            // cTemperature
            // 
            this.cTemperature.Text = "Temperature";
            this.cTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cTemperature.Width = 83;
            // 
            // groupBoxMonitor
            // 
            this.groupBoxMonitor.Controls.Add(this.groupBoxControl);
            this.groupBoxMonitor.Controls.Add(this.groupBoxOnchipRSSI);
            this.groupBoxMonitor.Controls.Add(this.groupBoxCodeValue);
            this.groupBoxMonitor.Controls.Add(this.groupBoxTagIC);
            this.groupBoxMonitor.Controls.Add(this.labelPYaxisName);
            this.groupBoxMonitor.Controls.Add(this.labelSYaxisName);
            this.groupBoxMonitor.Controls.Add(this.ChartMonitor);
            this.groupBoxMonitor.Location = new System.Drawing.Point(3, 249);
            this.groupBoxMonitor.Name = "groupBoxMonitor";
            this.groupBoxMonitor.Size = new System.Drawing.Size(856, 298);
            this.groupBoxMonitor.TabIndex = 2;
            this.groupBoxMonitor.TabStop = false;
            this.groupBoxMonitor.Text = "Monitor";
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.textBoxSMaxVal);
            this.groupBoxControl.Controls.Add(this.labelHorizontal);
            this.groupBoxControl.Controls.Add(this.textBoxSMinVal);
            this.groupBoxControl.Controls.Add(this.buttonHleft);
            this.groupBoxControl.Controls.Add(this.labelSecondaryYMin);
            this.groupBoxControl.Controls.Add(this.buttonHright);
            this.groupBoxControl.Controls.Add(this.labelSecondaryYMax);
            this.groupBoxControl.Controls.Add(this.labelPrimaryYMax);
            this.groupBoxControl.Controls.Add(this.labelPrimaryYMin);
            this.groupBoxControl.Controls.Add(this.textBoxVMinVal);
            this.groupBoxControl.Controls.Add(this.textBoxVMaxVal);
            this.groupBoxControl.Location = new System.Drawing.Point(642, 45);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(201, 225);
            this.groupBoxControl.TabIndex = 2;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Control";
            // 
            // textBoxSMaxVal
            // 
            this.textBoxSMaxVal.Location = new System.Drawing.Point(139, 112);
            this.textBoxSMaxVal.Name = "textBoxSMaxVal";
            this.textBoxSMaxVal.Size = new System.Drawing.Size(45, 21);
            this.textBoxSMaxVal.TabIndex = 18;
            this.textBoxSMaxVal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSMaxVal_KeyUp);
            // 
            // labelHorizontal
            // 
            this.labelHorizontal.AutoSize = true;
            this.labelHorizontal.Location = new System.Drawing.Point(59, 27);
            this.labelHorizontal.Name = "labelHorizontal";
            this.labelHorizontal.Size = new System.Drawing.Size(73, 12);
            this.labelHorizontal.TabIndex = 6;
            this.labelHorizontal.Text = "Horizontal : ";
            // 
            // textBoxSMinVal
            // 
            this.textBoxSMinVal.Location = new System.Drawing.Point(138, 139);
            this.textBoxSMinVal.Name = "textBoxSMinVal";
            this.textBoxSMinVal.Size = new System.Drawing.Size(45, 21);
            this.textBoxSMinVal.TabIndex = 17;
            this.textBoxSMinVal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSMinVal_KeyUp);
            // 
            // buttonHleft
            // 
            this.buttonHleft.Location = new System.Drawing.Point(138, 22);
            this.buttonHleft.Name = "buttonHleft";
            this.buttonHleft.Size = new System.Drawing.Size(20, 23);
            this.buttonHleft.TabIndex = 4;
            this.buttonHleft.Text = "<";
            this.buttonHleft.UseVisualStyleBackColor = true;
            this.buttonHleft.Click += new System.EventHandler(this.buttonHleft_Click);
            // 
            // labelSecondaryYMin
            // 
            this.labelSecondaryYMin.AutoSize = true;
            this.labelSecondaryYMin.Location = new System.Drawing.Point(15, 142);
            this.labelSecondaryYMin.Name = "labelSecondaryYMin";
            this.labelSecondaryYMin.Size = new System.Drawing.Size(111, 12);
            this.labelSecondaryYMin.TabIndex = 16;
            this.labelSecondaryYMin.Text = "Secondary Y Min :";
            // 
            // buttonHright
            // 
            this.buttonHright.Location = new System.Drawing.Point(164, 22);
            this.buttonHright.Name = "buttonHright";
            this.buttonHright.Size = new System.Drawing.Size(20, 23);
            this.buttonHright.TabIndex = 5;
            this.buttonHright.Text = ">";
            this.buttonHright.UseVisualStyleBackColor = true;
            this.buttonHright.Click += new System.EventHandler(this.buttonHright_Click);
            // 
            // labelSecondaryYMax
            // 
            this.labelSecondaryYMax.AutoSize = true;
            this.labelSecondaryYMax.Location = new System.Drawing.Point(11, 115);
            this.labelSecondaryYMax.Name = "labelSecondaryYMax";
            this.labelSecondaryYMax.Size = new System.Drawing.Size(119, 12);
            this.labelSecondaryYMax.TabIndex = 15;
            this.labelSecondaryYMax.Text = "Secondary Y Max : ";
            // 
            // labelPrimaryYMax
            // 
            this.labelPrimaryYMax.AutoSize = true;
            this.labelPrimaryYMax.Location = new System.Drawing.Point(28, 59);
            this.labelPrimaryYMax.Name = "labelPrimaryYMax";
            this.labelPrimaryYMax.Size = new System.Drawing.Size(102, 12);
            this.labelPrimaryYMax.TabIndex = 7;
            this.labelPrimaryYMax.Text = "Primary Y Max : ";
            // 
            // labelPrimaryYMin
            // 
            this.labelPrimaryYMin.AutoSize = true;
            this.labelPrimaryYMin.Location = new System.Drawing.Point(32, 88);
            this.labelPrimaryYMin.Name = "labelPrimaryYMin";
            this.labelPrimaryYMin.Size = new System.Drawing.Size(94, 12);
            this.labelPrimaryYMin.TabIndex = 8;
            this.labelPrimaryYMin.Text = "Primary Y Min :";
            // 
            // textBoxVMinVal
            // 
            this.textBoxVMinVal.Location = new System.Drawing.Point(139, 85);
            this.textBoxVMinVal.Name = "textBoxVMinVal";
            this.textBoxVMinVal.Size = new System.Drawing.Size(45, 21);
            this.textBoxVMinVal.TabIndex = 9;
            this.textBoxVMinVal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxVMinVal_KeyUp);
            // 
            // textBoxVMaxVal
            // 
            this.textBoxVMaxVal.Location = new System.Drawing.Point(139, 56);
            this.textBoxVMaxVal.Name = "textBoxVMaxVal";
            this.textBoxVMaxVal.Size = new System.Drawing.Size(45, 21);
            this.textBoxVMaxVal.TabIndex = 10;
            this.textBoxVMaxVal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxVMaxVal_KeyUp);
            // 
            // groupBoxOnchipRSSI
            // 
            this.groupBoxOnchipRSSI.Controls.Add(this.labelValidVal);
            this.groupBoxOnchipRSSI.Location = new System.Drawing.Point(499, 217);
            this.groupBoxOnchipRSSI.Name = "groupBoxOnchipRSSI";
            this.groupBoxOnchipRSSI.Size = new System.Drawing.Size(126, 53);
            this.groupBoxOnchipRSSI.TabIndex = 21;
            this.groupBoxOnchipRSSI.TabStop = false;
            this.groupBoxOnchipRSSI.Text = "On-Chip RSSI";
            // 
            // labelValidVal
            // 
            this.labelValidVal.AutoSize = true;
            this.labelValidVal.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelValidVal.Location = new System.Drawing.Point(36, 26);
            this.labelValidVal.Name = "labelValidVal";
            this.labelValidVal.Size = new System.Drawing.Size(38, 16);
            this.labelValidVal.TabIndex = 12;
            this.labelValidVal.Text = "     ";
            // 
            // groupBoxCodeValue
            // 
            this.groupBoxCodeValue.Controls.Add(this.labelTempMonitorVal);
            this.groupBoxCodeValue.Location = new System.Drawing.Point(499, 158);
            this.groupBoxCodeValue.Name = "groupBoxCodeValue";
            this.groupBoxCodeValue.Size = new System.Drawing.Size(126, 53);
            this.groupBoxCodeValue.TabIndex = 20;
            this.groupBoxCodeValue.TabStop = false;
            this.groupBoxCodeValue.Text = "Code Value";
            // 
            // labelTempMonitorVal
            // 
            this.labelTempMonitorVal.AutoSize = true;
            this.labelTempMonitorVal.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTempMonitorVal.Location = new System.Drawing.Point(35, 25);
            this.labelTempMonitorVal.Name = "labelTempMonitorVal";
            this.labelTempMonitorVal.Size = new System.Drawing.Size(56, 16);
            this.labelTempMonitorVal.TabIndex = 3;
            this.labelTempMonitorVal.Text = "        ";
            // 
            // groupBoxTagIC
            // 
            this.groupBoxTagIC.Controls.Add(this.labelTagIC);
            this.groupBoxTagIC.Location = new System.Drawing.Point(499, 96);
            this.groupBoxTagIC.Name = "groupBoxTagIC";
            this.groupBoxTagIC.Size = new System.Drawing.Size(126, 53);
            this.groupBoxTagIC.TabIndex = 19;
            this.groupBoxTagIC.TabStop = false;
            this.groupBoxTagIC.Text = "Tag IC";
            // 
            // labelTagIC
            // 
            this.labelTagIC.AutoSize = true;
            this.labelTagIC.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTagIC.Location = new System.Drawing.Point(6, 22);
            this.labelTagIC.Name = "labelTagIC";
            this.labelTagIC.Size = new System.Drawing.Size(44, 16);
            this.labelTagIC.TabIndex = 0;
            this.labelTagIC.Text = "      ";
            // 
            // labelPYaxisName
            // 
            this.labelPYaxisName.AutoSize = true;
            this.labelPYaxisName.Location = new System.Drawing.Point(30, 30);
            this.labelPYaxisName.Name = "labelPYaxisName";
            this.labelPYaxisName.Size = new System.Drawing.Size(35, 12);
            this.labelPYaxisName.TabIndex = 14;
            this.labelPYaxisName.Text = "Code";
            // 
            // labelSYaxisName
            // 
            this.labelSYaxisName.AutoSize = true;
            this.labelSYaxisName.Location = new System.Drawing.Point(419, 30);
            this.labelSYaxisName.Name = "labelSYaxisName";
            this.labelSYaxisName.Size = new System.Drawing.Size(84, 12);
            this.labelSYaxisName.TabIndex = 13;
            this.labelSYaxisName.Text = "On-Chip RSSI";
            // 
            // ChartMonitor
            // 
            this.ChartMonitor.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.Maximum = 10D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.ScrollBar.BackColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Gray;
            chartArea2.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea2.AxisX.Title = "Index";
            chartArea2.AxisY.Interval = 5D;
            chartArea2.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.Maximum = 50D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY2.Interval = 5D;
            chartArea2.AxisY2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.AxisY2.Maximum = 50D;
            chartArea2.AxisY2.Minimum = 0D;
            chartArea2.AxisY2.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea2.AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea2.Name = "ChartArea1";
            this.ChartMonitor.ChartAreas.Add(chartArea2);
            this.ChartMonitor.Dock = System.Windows.Forms.DockStyle.Left;
            legend2.BorderColor = System.Drawing.Color.Black;
            legend2.Name = "Legend1";
            this.ChartMonitor.Legends.Add(legend2);
            this.ChartMonitor.Location = new System.Drawing.Point(3, 17);
            this.ChartMonitor.Name = "ChartMonitor";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Red;
            series3.LabelBackColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Code Value";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Blue;
            series4.Legend = "Legend1";
            series4.Name = "On Chip RSSI";
            series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.ChartMonitor.Series.Add(series3);
            this.ChartMonitor.Series.Add(series4);
            this.ChartMonitor.Size = new System.Drawing.Size(641, 278);
            this.ChartMonitor.TabIndex = 0;
            this.ChartMonitor.Text = "Monitor";
            title2.Name = "Title1";
            this.ChartMonitor.Titles.Add(title2);
            // 
            // contextMenuStripChart
            // 
            this.contextMenuStripChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.contextMenuStripChart.Name = "contextMenuStripChart";
            this.contextMenuStripChart.Size = new System.Drawing.Size(102, 48);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // timerUpdateTag
            // 
            this.timerUpdateTag.Tick += new System.EventHandler(this.timerUpdateTag_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "txt Files.(*.txt)|*.txt";
            this.saveFileDialog.Title = "Save";
            // 
            // contextMenuStripTagInfo
            // 
            this.contextMenuStripTagInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem});
            this.contextMenuStripTagInfo.Name = "contextMenuStripTagInfo";
            this.contextMenuStripTagInfo.Size = new System.Drawing.Size(106, 26);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // UserControlSensorTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxTagList);
            this.Controls.Add(this.groupBoxMonitor);
            this.Name = "UserControlSensorTag";
            this.Size = new System.Drawing.Size(1001, 552);
            this.groupBoxTagList.ResumeLayout(false);
            this.groupBoxTagList.PerformLayout();
            this.groupBoxMonitor.ResumeLayout(false);
            this.groupBoxMonitor.PerformLayout();
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.groupBoxOnchipRSSI.ResumeLayout(false);
            this.groupBoxOnchipRSSI.PerformLayout();
            this.groupBoxCodeValue.ResumeLayout(false);
            this.groupBoxCodeValue.PerformLayout();
            this.groupBoxTagIC.ResumeLayout(false);
            this.groupBoxTagIC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMonitor)).EndInit();
            this.contextMenuStripChart.ResumeLayout(false);
            this.contextMenuStripTagInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTagList;
        private System.Windows.Forms.Button buttonInventory;
        private System.Windows.Forms.Label labelReadTagsVal;
        private System.Windows.Forms.Label labelReadTags;
        private System.Windows.Forms.ListView listViewEPC;
        private System.Windows.Forms.ColumnHeader cNumber;
        private System.Windows.Forms.ColumnHeader cPC;
        private System.Windows.Forms.ColumnHeader cEPC;
        private System.Windows.Forms.ColumnHeader cCnt;
        private System.Windows.Forms.ColumnHeader cRssi;
        private System.Windows.Forms.ColumnHeader cOnChipRSSI;
        private System.Windows.Forms.ColumnHeader cSensorCode;
        private System.Windows.Forms.ColumnHeader cCalData;
        private System.Windows.Forms.ColumnHeader cTemperature;
        private System.Windows.Forms.GroupBox groupBoxMonitor;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.TextBox textBoxSMaxVal;
        private System.Windows.Forms.Label labelHorizontal;
        private System.Windows.Forms.TextBox textBoxSMinVal;
        private System.Windows.Forms.Button buttonHleft;
        private System.Windows.Forms.Label labelSecondaryYMin;
        private System.Windows.Forms.Button buttonHright;
        private System.Windows.Forms.Label labelSecondaryYMax;
        private System.Windows.Forms.Label labelPrimaryYMax;
        private System.Windows.Forms.Label labelPrimaryYMin;
        private System.Windows.Forms.TextBox textBoxVMinVal;
        private System.Windows.Forms.TextBox textBoxVMaxVal;
        private System.Windows.Forms.GroupBox groupBoxOnchipRSSI;
        private System.Windows.Forms.Label labelValidVal;
        private System.Windows.Forms.GroupBox groupBoxCodeValue;
        private System.Windows.Forms.Label labelTempMonitorVal;
        private System.Windows.Forms.GroupBox groupBoxTagIC;
        private System.Windows.Forms.Label labelTagIC;
        private System.Windows.Forms.Label labelPYaxisName;
        private System.Windows.Forms.Label labelSYaxisName;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartMonitor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChart;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Timer timerUpdateTag;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTagInfo;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;


    }
}
