namespace Phychips.PR9200
{
    partial class UserControlLeakGuidance
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
            this.buttonLeakGuidance = new System.Windows.Forms.Button();
            this.groupBoxLeakGuidance = new System.Windows.Forms.GroupBox();
            this.radioButtonFast = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.buttonGetInfo = new System.Windows.Forms.Button();
            this.labelReadCnt = new System.Windows.Forms.Label();
            this.textBoxCnt = new System.Windows.Forms.TextBox();
            this.groupBoxFastLeakInfo = new System.Windows.Forms.GroupBox();
            this.listViewLeakInfo = new System.Windows.Forms.ListView();
            this.columnHeaderChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIDT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDTC1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDTC2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRSSI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxModeSelection = new System.Windows.Forms.GroupBox();
            this.checkBoxEnableRegion = new System.Windows.Forms.CheckBox();
            this.timerEnableStart = new System.Windows.Forms.Timer(this.components);
            this.groupBoxLeakGuidance.SuspendLayout();
            this.groupBoxFastLeakInfo.SuspendLayout();
            this.groupBoxModeSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLeakGuidance
            // 
            this.buttonLeakGuidance.Enabled = false;
            this.buttonLeakGuidance.Location = new System.Drawing.Point(293, 49);
            this.buttonLeakGuidance.Name = "buttonLeakGuidance";
            this.buttonLeakGuidance.Size = new System.Drawing.Size(72, 23);
            this.buttonLeakGuidance.TabIndex = 0;
            this.buttonLeakGuidance.Text = "Start";
            this.buttonLeakGuidance.UseVisualStyleBackColor = true;
            this.buttonLeakGuidance.Click += new System.EventHandler(this.buttonLeakGuidance_Click);
            // 
            // groupBoxLeakGuidance
            // 
            this.groupBoxLeakGuidance.Controls.Add(this.radioButtonFast);
            this.groupBoxLeakGuidance.Controls.Add(this.radioButtonNormal);
            this.groupBoxLeakGuidance.Controls.Add(this.buttonGetInfo);
            this.groupBoxLeakGuidance.Controls.Add(this.labelReadCnt);
            this.groupBoxLeakGuidance.Controls.Add(this.textBoxCnt);
            this.groupBoxLeakGuidance.Controls.Add(this.buttonLeakGuidance);
            this.groupBoxLeakGuidance.Enabled = false;
            this.groupBoxLeakGuidance.Location = new System.Drawing.Point(6, 42);
            this.groupBoxLeakGuidance.Name = "groupBoxLeakGuidance";
            this.groupBoxLeakGuidance.Size = new System.Drawing.Size(371, 80);
            this.groupBoxLeakGuidance.TabIndex = 2;
            this.groupBoxLeakGuidance.TabStop = false;
            this.groupBoxLeakGuidance.Text = "Leakage Cal Mode";
            // 
            // radioButtonFast
            // 
            this.radioButtonFast.AutoSize = true;
            this.radioButtonFast.Location = new System.Drawing.Point(6, 42);
            this.radioButtonFast.Name = "radioButtonFast";
            this.radioButtonFast.Size = new System.Drawing.Size(83, 16);
            this.radioButtonFast.TabIndex = 5;
            this.radioButtonFast.TabStop = true;
            this.radioButtonFast.Text = "Fast Mode";
            this.radioButtonFast.UseVisualStyleBackColor = true;
            this.radioButtonFast.CheckedChanged += new System.EventHandler(this.radioButtonFast_CheckedChanged);
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(6, 20);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(100, 16);
            this.radioButtonNormal.TabIndex = 4;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Normal Mode";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.radioButtonNormal_CheckedChanged);
            // 
            // buttonGetInfo
            // 
            this.buttonGetInfo.Location = new System.Drawing.Point(194, 20);
            this.buttonGetInfo.Name = "buttonGetInfo";
            this.buttonGetInfo.Size = new System.Drawing.Size(171, 23);
            this.buttonGetInfo.TabIndex = 1;
            this.buttonGetInfo.Text = "Ready for Fast Leakage Cal";
            this.buttonGetInfo.UseVisualStyleBackColor = true;
            this.buttonGetInfo.Click += new System.EventHandler(this.buttonGetInfo_Click);
            // 
            // labelReadCnt
            // 
            this.labelReadCnt.AutoSize = true;
            this.labelReadCnt.Location = new System.Drawing.Point(138, 54);
            this.labelReadCnt.Name = "labelReadCnt";
            this.labelReadCnt.Size = new System.Drawing.Size(50, 12);
            this.labelReadCnt.TabIndex = 3;
            this.labelReadCnt.Text = "Count : ";
            // 
            // textBoxCnt
            // 
            this.textBoxCnt.Location = new System.Drawing.Point(194, 51);
            this.textBoxCnt.Name = "textBoxCnt";
            this.textBoxCnt.Size = new System.Drawing.Size(93, 21);
            this.textBoxCnt.TabIndex = 2;
            this.textBoxCnt.Text = "10";
            this.textBoxCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBoxFastLeakInfo
            // 
            this.groupBoxFastLeakInfo.Controls.Add(this.listViewLeakInfo);
            this.groupBoxFastLeakInfo.Location = new System.Drawing.Point(3, 138);
            this.groupBoxFastLeakInfo.Name = "groupBoxFastLeakInfo";
            this.groupBoxFastLeakInfo.Size = new System.Drawing.Size(388, 127);
            this.groupBoxFastLeakInfo.TabIndex = 3;
            this.groupBoxFastLeakInfo.TabStop = false;
            this.groupBoxFastLeakInfo.Text = "Fast Leakage Cal Information";
            this.groupBoxFastLeakInfo.Visible = false;
            // 
            // listViewLeakInfo
            // 
            this.listViewLeakInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderChannel,
            this.columnHeaderIDT,
            this.columnHeaderDTC1,
            this.columnHeaderDTC2,
            this.columnHeaderRSSI});
            this.listViewLeakInfo.GridLines = true;
            this.listViewLeakInfo.Location = new System.Drawing.Point(6, 20);
            this.listViewLeakInfo.Name = "listViewLeakInfo";
            this.listViewLeakInfo.Size = new System.Drawing.Size(371, 101);
            this.listViewLeakInfo.TabIndex = 0;
            this.listViewLeakInfo.UseCompatibleStateImageBehavior = false;
            this.listViewLeakInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderChannel
            // 
            this.columnHeaderChannel.Text = "Channel";
            // 
            // columnHeaderIDT
            // 
            this.columnHeaderIDT.Text = "Inductor";
            // 
            // columnHeaderDTC1
            // 
            this.columnHeaderDTC1.Text = "DTC1";
            // 
            // columnHeaderDTC2
            // 
            this.columnHeaderDTC2.Text = "DTC2";
            // 
            // columnHeaderRSSI
            // 
            this.columnHeaderRSSI.Text = "Leakage RSSI";
            this.columnHeaderRSSI.Width = 107;
            // 
            // groupBoxModeSelection
            // 
            this.groupBoxModeSelection.Controls.Add(this.checkBoxEnableRegion);
            this.groupBoxModeSelection.Controls.Add(this.groupBoxLeakGuidance);
            this.groupBoxModeSelection.Location = new System.Drawing.Point(3, 3);
            this.groupBoxModeSelection.Name = "groupBoxModeSelection";
            this.groupBoxModeSelection.Size = new System.Drawing.Size(388, 129);
            this.groupBoxModeSelection.TabIndex = 4;
            this.groupBoxModeSelection.TabStop = false;
            this.groupBoxModeSelection.Text = "Leakage Cal Mode";
            // 
            // checkBoxEnableRegion
            // 
            this.checkBoxEnableRegion.AutoSize = true;
            this.checkBoxEnableRegion.Location = new System.Drawing.Point(6, 20);
            this.checkBoxEnableRegion.Name = "checkBoxEnableRegion";
            this.checkBoxEnableRegion.Size = new System.Drawing.Size(207, 16);
            this.checkBoxEnableRegion.TabIndex = 4;
            this.checkBoxEnableRegion.Text = "Enable Leakage Mode Selection";
            this.checkBoxEnableRegion.UseVisualStyleBackColor = true;
            this.checkBoxEnableRegion.CheckedChanged += new System.EventHandler(this.checkBoxEnableRegion_CheckedChanged);
            // 
            // timerEnableStart
            // 
            this.timerEnableStart.Interval = 3000;
            this.timerEnableStart.Tick += new System.EventHandler(this.timerEnableStart_Tick);
            // 
            // UserControlLeakGuidance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBoxModeSelection);
            this.Controls.Add(this.groupBoxFastLeakInfo);
            this.Name = "UserControlLeakGuidance";
            this.Size = new System.Drawing.Size(401, 271);
            this.groupBoxLeakGuidance.ResumeLayout(false);
            this.groupBoxLeakGuidance.PerformLayout();
            this.groupBoxFastLeakInfo.ResumeLayout(false);
            this.groupBoxModeSelection.ResumeLayout(false);
            this.groupBoxModeSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLeakGuidance;
        private System.Windows.Forms.GroupBox groupBoxLeakGuidance;
        private System.Windows.Forms.GroupBox groupBoxFastLeakInfo;
        private System.Windows.Forms.ListView listViewLeakInfo;
        private System.Windows.Forms.ColumnHeader columnHeaderChannel;
        private System.Windows.Forms.ColumnHeader columnHeaderIDT;
        private System.Windows.Forms.ColumnHeader columnHeaderDTC1;
        private System.Windows.Forms.ColumnHeader columnHeaderDTC2;
        private System.Windows.Forms.ColumnHeader columnHeaderRSSI;
        private System.Windows.Forms.Button buttonGetInfo;
        private System.Windows.Forms.Label labelReadCnt;
        private System.Windows.Forms.TextBox textBoxCnt;
        private System.Windows.Forms.GroupBox groupBoxModeSelection;
        private System.Windows.Forms.CheckBox checkBoxEnableRegion;
        private System.Windows.Forms.RadioButton radioButtonFast;
        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.Timer timerEnableStart;
    }
}
