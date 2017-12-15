namespace Phychips.PR9200
{
    partial class ucHwControl
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
            this.groupBox_BasicSettings = new System.Windows.Forms.GroupBox();
            this.buttonGetCh = new System.Windows.Forms.Button();
            this.buttonGetRegion = new System.Windows.Forms.Button();
            this.cbCh = new System.Windows.Forms.ComboBox();
            this.cbChExt = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbFreqency = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.buttonRegionSet = new System.Windows.Forms.Button();
            this.buttonSetCh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTxPwr = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonSetTxPwr = new System.Windows.Forms.Button();
            this.buttonFhLbt = new System.Windows.Forms.Button();
            this.tbCwSenseTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLbtRfLevel = new System.Windows.Forms.TextBox();
            this.cbFH = new System.Windows.Forms.CheckBox();
            this.cbLBT = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbIdleTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbReadTime = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbLBTwithFH = new System.Windows.Forms.CheckBox();
            this.cbFHwithLBT = new System.Windows.Forms.CheckBox();
            this.buttonGetFrequencyTable = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonRssi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonGetFhLbt = new System.Windows.Forms.Button();
            this.groupBoxTestFunction = new System.Windows.Forms.GroupBox();
            this.buttonCwDisable = new System.Windows.Forms.Button();
            this.buttonCwEnable = new System.Windows.Forms.Button();
            this.buttonTpEnable = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGetTxPower = new System.Windows.Forms.Button();
            this.lb_showPwrTbl = new System.Windows.Forms.Label();
            this.groupBox_Modulation = new System.Windows.Forms.GroupBox();
            this.buttonGetModulationType = new System.Windows.Forms.Button();
            this.comboBoxModulationType = new System.Windows.Forms.ComboBox();
            this.buttonSetModulationType = new System.Windows.Forms.Button();
            this.groupBox_BasicSettings.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBoxTestFunction.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_Modulation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_BasicSettings
            // 
            this.groupBox_BasicSettings.Controls.Add(this.buttonGetCh);
            this.groupBox_BasicSettings.Controls.Add(this.buttonGetRegion);
            this.groupBox_BasicSettings.Controls.Add(this.cbCh);
            this.groupBox_BasicSettings.Controls.Add(this.cbChExt);
            this.groupBox_BasicSettings.Controls.Add(this.label18);
            this.groupBox_BasicSettings.Controls.Add(this.label13);
            this.groupBox_BasicSettings.Controls.Add(this.label14);
            this.groupBox_BasicSettings.Controls.Add(this.lbFreqency);
            this.groupBox_BasicSettings.Controls.Add(this.label3);
            this.groupBox_BasicSettings.Controls.Add(this.cbRegion);
            this.groupBox_BasicSettings.Controls.Add(this.buttonRegionSet);
            this.groupBox_BasicSettings.Controls.Add(this.buttonSetCh);
            this.groupBox_BasicSettings.Controls.Add(this.label1);
            this.groupBox_BasicSettings.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_BasicSettings.Location = new System.Drawing.Point(6, 5);
            this.groupBox_BasicSettings.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox_BasicSettings.Name = "groupBox_BasicSettings";
            this.groupBox_BasicSettings.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox_BasicSettings.Size = new System.Drawing.Size(400, 139);
            this.groupBox_BasicSettings.TabIndex = 39;
            this.groupBox_BasicSettings.TabStop = false;
            this.groupBox_BasicSettings.Text = "Frequency Control";
            // 
            // buttonGetCh
            // 
            this.buttonGetCh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetCh.Location = new System.Drawing.Point(201, 64);
            this.buttonGetCh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonGetCh.Name = "buttonGetCh";
            this.buttonGetCh.Size = new System.Drawing.Size(90, 30);
            this.buttonGetCh.TabIndex = 2257;
            this.buttonGetCh.Text = "Get";
            this.buttonGetCh.UseVisualStyleBackColor = true;
            this.buttonGetCh.Click += new System.EventHandler(this.buttonGetCh_Click);
            // 
            // buttonGetRegion
            // 
            this.buttonGetRegion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetRegion.Location = new System.Drawing.Point(201, 24);
            this.buttonGetRegion.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonGetRegion.Name = "buttonGetRegion";
            this.buttonGetRegion.Size = new System.Drawing.Size(90, 30);
            this.buttonGetRegion.TabIndex = 2256;
            this.buttonGetRegion.Text = "Get";
            this.buttonGetRegion.UseVisualStyleBackColor = true;
            this.buttonGetRegion.Click += new System.EventHandler(this.buttonRegionGet_Click);
            // 
            // cbCh
            // 
            this.cbCh.DropDownWidth = 100;
            this.cbCh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCh.FormattingEnabled = true;
            this.cbCh.Items.AddRange(new object[] {
            "00",
            "50"});
            this.cbCh.Location = new System.Drawing.Point(77, 68);
            this.cbCh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCh.Name = "cbCh";
            this.cbCh.Size = new System.Drawing.Size(60, 24);
            this.cbCh.TabIndex = 2255;
            this.cbCh.SelectedIndexChanged += new System.EventHandler(this.cbCH_SelectedIndexChanged);
            // 
            // cbChExt
            // 
            this.cbChExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChExt.DropDownWidth = 100;
            this.cbChExt.Enabled = false;
            this.cbChExt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChExt.Location = new System.Drawing.Point(130, 68);
            this.cbChExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbChExt.Name = "cbChExt";
            this.cbChExt.Size = new System.Drawing.Size(42, 24);
            this.cbChExt.TabIndex = 2254;
            this.cbChExt.Visible = false;
            this.cbChExt.SelectedIndexChanged += new System.EventHandler(this.cbChExt_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(117, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 28);
            this.label18.TabIndex = 64;
            this.label18.Text = ".";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label18.Visible = false;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(148, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 20);
            this.label13.TabIndex = 57;
            this.label13.Text = "MHz";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 20);
            this.label14.TabIndex = 56;
            this.label14.Text = "Frequency:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFreqency
            // 
            this.lbFreqency.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFreqency.Location = new System.Drawing.Point(80, 106);
            this.lbFreqency.Name = "lbFreqency";
            this.lbFreqency.Size = new System.Drawing.Size(66, 20);
            this.lbFreqency.TabIndex = 55;
            this.lbFreqency.Text = "000.00";
            this.lbFreqency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 28);
            this.label3.TabIndex = 30;
            this.label3.Text = "Region:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbRegion
            // 
            this.cbRegion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(77, 28);
            this.cbRegion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(95, 24);
            this.cbRegion.TabIndex = 29;
            this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.cbRegion_SelectedIndexChanged);
            // 
            // buttonRegionSet
            // 
            this.buttonRegionSet.Enabled = false;
            this.buttonRegionSet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegionSet.Location = new System.Drawing.Point(297, 24);
            this.buttonRegionSet.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonRegionSet.Name = "buttonRegionSet";
            this.buttonRegionSet.Size = new System.Drawing.Size(90, 30);
            this.buttonRegionSet.TabIndex = 28;
            this.buttonRegionSet.Text = "Set";
            this.buttonRegionSet.UseVisualStyleBackColor = true;
            this.buttonRegionSet.Click += new System.EventHandler(this.buttonRegionSet_Click);
            // 
            // buttonSetCh
            // 
            this.buttonSetCh.Enabled = false;
            this.buttonSetCh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetCh.Location = new System.Drawing.Point(297, 64);
            this.buttonSetCh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonSetCh.Name = "buttonSetCh";
            this.buttonSetCh.Size = new System.Drawing.Size(90, 30);
            this.buttonSetCh.TabIndex = 24;
            this.buttonSetCh.Text = "Set";
            this.buttonSetCh.UseVisualStyleBackColor = true;
            this.buttonSetCh.Click += new System.EventHandler(this.buttonSetCh_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 28);
            this.label1.TabIndex = 17;
            this.label1.Text = "Channel:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTxPwr
            // 
            this.cbTxPwr.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTxPwr.FormattingEnabled = true;
            this.cbTxPwr.Location = new System.Drawing.Point(100, 26);
            this.cbTxPwr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTxPwr.Name = "cbTxPwr";
            this.cbTxPwr.Size = new System.Drawing.Size(60, 24);
            this.cbTxPwr.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(166, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 28);
            this.label12.TabIndex = 54;
            this.label12.Text = "dBm";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSetTxPwr
            // 
            this.buttonSetTxPwr.Enabled = false;
            this.buttonSetTxPwr.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetTxPwr.Location = new System.Drawing.Point(297, 22);
            this.buttonSetTxPwr.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonSetTxPwr.Name = "buttonSetTxPwr";
            this.buttonSetTxPwr.Size = new System.Drawing.Size(90, 30);
            this.buttonSetTxPwr.TabIndex = 27;
            this.buttonSetTxPwr.Text = "Set";
            this.buttonSetTxPwr.UseVisualStyleBackColor = true;
            this.buttonSetTxPwr.Click += new System.EventHandler(this.buttonSetTxPwr_Click);
            // 
            // buttonFhLbt
            // 
            this.buttonFhLbt.Enabled = false;
            this.buttonFhLbt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFhLbt.Location = new System.Drawing.Point(293, 189);
            this.buttonFhLbt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonFhLbt.Name = "buttonFhLbt";
            this.buttonFhLbt.Size = new System.Drawing.Size(90, 30);
            this.buttonFhLbt.TabIndex = 28;
            this.buttonFhLbt.Text = "Set";
            this.buttonFhLbt.UseVisualStyleBackColor = true;
            this.buttonFhLbt.Click += new System.EventHandler(this.buttonFhssLbt_Click);
            // 
            // tbCwSenseTime
            // 
            this.tbCwSenseTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCwSenseTime.Location = new System.Drawing.Point(299, 81);
            this.tbCwSenseTime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbCwSenseTime.Name = "tbCwSenseTime";
            this.tbCwSenseTime.Size = new System.Drawing.Size(45, 22);
            this.tbCwSenseTime.TabIndex = 51;
            this.tbCwSenseTime.Text = "10";
            this.tbCwSenseTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(193, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 24);
            this.label11.TabIndex = 50;
            this.label11.Text = "CW Sense Time:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLbtRfLevel
            // 
            this.tbLbtRfLevel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLbtRfLevel.Location = new System.Drawing.Point(299, 115);
            this.tbLbtRfLevel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbLbtRfLevel.Name = "tbLbtRfLevel";
            this.tbLbtRfLevel.Size = new System.Drawing.Size(45, 22);
            this.tbLbtRfLevel.TabIndex = 49;
            this.tbLbtRfLevel.Text = "-63.0";
            this.tbLbtRfLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbFH
            // 
            this.cbFH.AutoSize = true;
            this.cbFH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFH.Location = new System.Drawing.Point(14, 24);
            this.cbFH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFH.Name = "cbFH";
            this.cbFH.Size = new System.Drawing.Size(139, 19);
            this.cbFH.TabIndex = 44;
            this.cbFH.Text = "Freq. Hopping (Only)";
            this.cbFH.UseVisualStyleBackColor = true;
            this.cbFH.CheckedChanged += new System.EventHandler(this.cbFH_CheckedChanged);
            // 
            // cbLBT
            // 
            this.cbLBT.AutoSize = true;
            this.cbLBT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLBT.Location = new System.Drawing.Point(196, 23);
            this.cbLBT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLBT.Name = "cbLBT";
            this.cbLBT.Size = new System.Drawing.Size(159, 19);
            this.cbLBT.TabIndex = 45;
            this.cbLBT.Text = "Listen Before Talk (Only)";
            this.cbLBT.UseVisualStyleBackColor = true;
            this.cbLBT.CheckedChanged += new System.EventHandler(this.cbLBT_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(193, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 24);
            this.label8.TabIndex = 48;
            this.label8.Text = "LBT RF Level:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbIdleTime
            // 
            this.tbIdleTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdleTime.Location = new System.Drawing.Point(97, 116);
            this.tbIdleTime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbIdleTime.Name = "tbIdleTime";
            this.tbIdleTime.Size = new System.Drawing.Size(45, 22);
            this.tbIdleTime.TabIndex = 47;
            this.tbIdleTime.Text = "100";
            this.tbIdleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 24);
            this.label7.TabIndex = 46;
            this.label7.Text = "Idle Time:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 24);
            this.label6.TabIndex = 31;
            this.label6.Text = "Read Time:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbReadTime
            // 
            this.tbReadTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReadTime.Location = new System.Drawing.Point(97, 82);
            this.tbReadTime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbReadTime.Name = "tbReadTime";
            this.tbReadTime.Size = new System.Drawing.Size(45, 22);
            this.tbReadTime.TabIndex = 31;
            this.tbReadTime.Text = "400";
            this.tbReadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbLBTwithFH);
            this.groupBox4.Controls.Add(this.cbFHwithLBT);
            this.groupBox4.Controls.Add(this.buttonGetFrequencyTable);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.buttonRssi);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.buttonGetFhLbt);
            this.groupBox4.Controls.Add(this.tbCwSenseTime);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.buttonFhLbt);
            this.groupBox4.Controls.Add(this.tbLbtRfLevel);
            this.groupBox4.Controls.Add(this.cbFH);
            this.groupBox4.Controls.Add(this.cbLBT);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.tbIdleTime);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tbReadTime);
            this.groupBox4.Location = new System.Drawing.Point(6, 294);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(400, 225);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FH && LBT Settings";
            // 
            // cbLBTwithFH
            // 
            this.cbLBTwithFH.AutoSize = true;
            this.cbLBTwithFH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLBTwithFH.Location = new System.Drawing.Point(196, 50);
            this.cbLBTwithFH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLBTwithFH.Name = "cbLBTwithFH";
            this.cbLBTwithFH.Size = new System.Drawing.Size(176, 19);
            this.cbLBTwithFH.TabIndex = 2265;
            this.cbLBTwithFH.Text = "Listen Before Talk (with FH)";
            this.cbLBTwithFH.UseVisualStyleBackColor = true;
            this.cbLBTwithFH.CheckedChanged += new System.EventHandler(this.cbLBTwithFH_CheckedChanged);
            // 
            // cbFHwithLBT
            // 
            this.cbFHwithLBT.AutoSize = true;
            this.cbFHwithLBT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFHwithLBT.Location = new System.Drawing.Point(14, 51);
            this.cbFHwithLBT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFHwithLBT.Name = "cbFHwithLBT";
            this.cbFHwithLBT.Size = new System.Drawing.Size(162, 19);
            this.cbFHwithLBT.TabIndex = 2264;
            this.cbFHwithLBT.Text = "Freq. Hopping (with LBT)";
            this.cbFHwithLBT.UseVisualStyleBackColor = true;
            this.cbFHwithLBT.CheckedChanged += new System.EventHandler(this.cbFHwithLBT_CheckedChanged);
            // 
            // buttonGetFrequencyTable
            // 
            this.buttonGetFrequencyTable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetFrequencyTable.Location = new System.Drawing.Point(13, 149);
            this.buttonGetFrequencyTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonGetFrequencyTable.Name = "buttonGetFrequencyTable";
            this.buttonGetFrequencyTable.Size = new System.Drawing.Size(161, 30);
            this.buttonGetFrequencyTable.TabIndex = 2263;
            this.buttonGetFrequencyTable.Text = "FHSS Channel Table";
            this.buttonGetFrequencyTable.UseVisualStyleBackColor = true;
            this.buttonGetFrequencyTable.Click += new System.EventHandler(this.buttonGetFrequencyTable_Click);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(350, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 20);
            this.label19.TabIndex = 2262;
            this.label19.Text = "dBm";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(350, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 20);
            this.label9.TabIndex = 2261;
            this.label9.Text = "ms";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(148, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 20);
            this.label5.TabIndex = 2260;
            this.label5.Text = "ms";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonRssi
            // 
            this.buttonRssi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRssi.Location = new System.Drawing.Point(195, 149);
            this.buttonRssi.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonRssi.Name = "buttonRssi";
            this.buttonRssi.Size = new System.Drawing.Size(188, 30);
            this.buttonRssi.TabIndex = 50;
            this.buttonRssi.Text = "Current Channel RSSI";
            this.buttonRssi.UseVisualStyleBackColor = true;
            this.buttonRssi.Click += new System.EventHandler(this.buttonRssi_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(148, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 20);
            this.label4.TabIndex = 2259;
            this.label4.Text = "ms";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonGetFhLbt
            // 
            this.buttonGetFhLbt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetFhLbt.Location = new System.Drawing.Point(196, 189);
            this.buttonGetFhLbt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonGetFhLbt.Name = "buttonGetFhLbt";
            this.buttonGetFhLbt.Size = new System.Drawing.Size(90, 30);
            this.buttonGetFhLbt.TabIndex = 63;
            this.buttonGetFhLbt.Text = "Get";
            this.buttonGetFhLbt.UseVisualStyleBackColor = true;
            this.buttonGetFhLbt.Click += new System.EventHandler(this.buttonGetFhLbt_Click);
            // 
            // groupBoxTestFunction
            // 
            this.groupBoxTestFunction.Controls.Add(this.buttonCwDisable);
            this.groupBoxTestFunction.Controls.Add(this.buttonCwEnable);
            this.groupBoxTestFunction.Controls.Add(this.buttonTpEnable);
            this.groupBoxTestFunction.Location = new System.Drawing.Point(6, 223);
            this.groupBoxTestFunction.Name = "groupBoxTestFunction";
            this.groupBoxTestFunction.Size = new System.Drawing.Size(400, 65);
            this.groupBoxTestFunction.TabIndex = 2255;
            this.groupBoxTestFunction.TabStop = false;
            this.groupBoxTestFunction.Text = "Test functions";
            // 
            // buttonCwDisable
            // 
            this.buttonCwDisable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCwDisable.Location = new System.Drawing.Point(141, 20);
            this.buttonCwDisable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonCwDisable.Name = "buttonCwDisable";
            this.buttonCwDisable.Size = new System.Drawing.Size(120, 30);
            this.buttonCwDisable.TabIndex = 22;
            this.buttonCwDisable.Text = "Turn Tx CW off";
            this.buttonCwDisable.UseVisualStyleBackColor = true;
            this.buttonCwDisable.Click += new System.EventHandler(this.buttonTxOff_Click);
            // 
            // buttonCwEnable
            // 
            this.buttonCwEnable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCwEnable.Location = new System.Drawing.Point(15, 20);
            this.buttonCwEnable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonCwEnable.Name = "buttonCwEnable";
            this.buttonCwEnable.Size = new System.Drawing.Size(120, 30);
            this.buttonCwEnable.TabIndex = 21;
            this.buttonCwEnable.Text = "Turn Tx CW on";
            this.buttonCwEnable.UseVisualStyleBackColor = true;
            this.buttonCwEnable.Click += new System.EventHandler(this.buttonTxOn_Click);
            // 
            // buttonTpEnable
            // 
            this.buttonTpEnable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTpEnable.Location = new System.Drawing.Point(267, 20);
            this.buttonTpEnable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonTpEnable.Name = "buttonTpEnable";
            this.buttonTpEnable.Size = new System.Drawing.Size(120, 30);
            this.buttonTpEnable.TabIndex = 41;
            this.buttonTpEnable.Text = "Test Port Enable";
            this.buttonTpEnable.UseVisualStyleBackColor = true;
            this.buttonTpEnable.Visible = false;
            this.buttonTpEnable.Click += new System.EventHandler(this.buttonTpEnable_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonGetTxPower);
            this.groupBox1.Controls.Add(this.cbTxPwr);
            this.groupBox1.Controls.Add(this.buttonSetTxPwr);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lb_showPwrTbl);
            this.groupBox1.Location = new System.Drawing.Point(6, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 65);
            this.groupBox1.TabIndex = 2256;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RF Transmitter  Control";
            // 
            // buttonGetTxPower
            // 
            this.buttonGetTxPower.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetTxPower.Location = new System.Drawing.Point(201, 22);
            this.buttonGetTxPower.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonGetTxPower.Name = "buttonGetTxPower";
            this.buttonGetTxPower.Size = new System.Drawing.Size(90, 30);
            this.buttonGetTxPower.TabIndex = 2258;
            this.buttonGetTxPower.Text = "Get";
            this.buttonGetTxPower.UseVisualStyleBackColor = true;
            this.buttonGetTxPower.Click += new System.EventHandler(this.buttonGetTxPower_Click);
            // 
            // lb_showPwrTbl
            // 
            this.lb_showPwrTbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_showPwrTbl.Location = new System.Drawing.Point(11, 27);
            this.lb_showPwrTbl.Name = "lb_showPwrTbl";
            this.lb_showPwrTbl.Size = new System.Drawing.Size(90, 20);
            this.lb_showPwrTbl.TabIndex = 2258;
            this.lb_showPwrTbl.Text = "Output Power:";
            this.lb_showPwrTbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox_Modulation
            // 
            this.groupBox_Modulation.Controls.Add(this.buttonGetModulationType);
            this.groupBox_Modulation.Controls.Add(this.comboBoxModulationType);
            this.groupBox_Modulation.Controls.Add(this.buttonSetModulationType);
            this.groupBox_Modulation.Location = new System.Drawing.Point(6, 525);
            this.groupBox_Modulation.Name = "groupBox_Modulation";
            this.groupBox_Modulation.Size = new System.Drawing.Size(400, 67);
            this.groupBox_Modulation.TabIndex = 2271;
            this.groupBox_Modulation.TabStop = false;
            this.groupBox_Modulation.Text = "Modulation";
            // 
            // buttonGetModulationType
            // 
            this.buttonGetModulationType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetModulationType.Location = new System.Drawing.Point(201, 22);
            this.buttonGetModulationType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonGetModulationType.Name = "buttonGetModulationType";
            this.buttonGetModulationType.Size = new System.Drawing.Size(90, 30);
            this.buttonGetModulationType.TabIndex = 2258;
            this.buttonGetModulationType.Text = "Get";
            this.buttonGetModulationType.UseVisualStyleBackColor = true;
            this.buttonGetModulationType.Click += new System.EventHandler(this.buttonGetModulationType_Click);
            // 
            // comboBoxModulationType
            // 
            this.comboBoxModulationType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxModulationType.FormattingEnabled = true;
            this.comboBoxModulationType.Items.AddRange(new object[] {
            "High Speed",
            "Multi-tag",
            "High Sensitivity"});
            this.comboBoxModulationType.Location = new System.Drawing.Point(14, 26);
            this.comboBoxModulationType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxModulationType.Name = "comboBoxModulationType";
            this.comboBoxModulationType.Size = new System.Drawing.Size(169, 24);
            this.comboBoxModulationType.TabIndex = 31;
            // 
            // buttonSetModulationType
            // 
            this.buttonSetModulationType.Enabled = false;
            this.buttonSetModulationType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetModulationType.Location = new System.Drawing.Point(297, 22);
            this.buttonSetModulationType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonSetModulationType.Name = "buttonSetModulationType";
            this.buttonSetModulationType.Size = new System.Drawing.Size(90, 30);
            this.buttonSetModulationType.TabIndex = 27;
            this.buttonSetModulationType.Text = "Set";
            this.buttonSetModulationType.UseVisualStyleBackColor = true;
            this.buttonSetModulationType.Click += new System.EventHandler(this.buttonSetModulationType_Click);
            // 
            // ucHwControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Modulation);
            this.Controls.Add(this.groupBoxTestFunction);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox_BasicSettings);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucHwControl";
            this.Size = new System.Drawing.Size(413, 599);
            this.Load += new System.EventHandler(this.ucHwControl_Load);
            this.groupBox_BasicSettings.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBoxTestFunction.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox_Modulation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_BasicSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbLBT;
        private System.Windows.Forms.CheckBox cbFH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbReadTime;
        private System.Windows.Forms.TextBox tbLbtRfLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbIdleTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonRssi;
        private System.Windows.Forms.TextBox tbCwSenseTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbTxPwr;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbFreqency;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbChExt;
        private System.Windows.Forms.Button buttonGetRegion;
        private System.Windows.Forms.Button buttonGetCh;
        private System.Windows.Forms.GroupBox groupBoxTestFunction;
        private System.Windows.Forms.Button buttonCwDisable;
        private System.Windows.Forms.Button buttonCwEnable;
        private System.Windows.Forms.Button buttonTpEnable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGetTxPower;
        private System.Windows.Forms.Button buttonGetFhLbt;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGetFrequencyTable;
        private System.Windows.Forms.Label lb_showPwrTbl;
        private System.Windows.Forms.GroupBox groupBox_Modulation;
        private System.Windows.Forms.Button buttonGetModulationType;
        private System.Windows.Forms.ComboBox comboBoxModulationType;
        private System.Windows.Forms.CheckBox cbLBTwithFH;
        private System.Windows.Forms.CheckBox cbFHwithLBT;
        public System.Windows.Forms.ComboBox cbCh;
        public System.Windows.Forms.Button buttonSetCh;
        public System.Windows.Forms.Button buttonSetTxPwr;
        public System.Windows.Forms.Button buttonFhLbt;
        public System.Windows.Forms.Button buttonRegionSet;
        public System.Windows.Forms.Button buttonSetModulationType;
    }
}
