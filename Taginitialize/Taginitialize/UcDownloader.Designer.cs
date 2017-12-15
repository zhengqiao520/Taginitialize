namespace Phychips.PR9200
{
    partial class ucDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDownloader));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonFileOpen = new System.Windows.Forms.Button();
            this.buttonFileNew = new System.Windows.Forms.Button();
            this.textBoxCodeList = new System.Windows.Forms.TextBox();
            this.openFileDialogHex = new System.Windows.Forms.OpenFileDialog();
            this.progressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.buttonDump = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxImageInfo = new System.Windows.Forms.GroupBox();
            this.textBoxCrc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textImageBoxBootloader = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxImageFid = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxReaderBootLoader = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxBand = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxInfoREGVER = new System.Windows.Forms.TextBox();
            this.textBoxInfoFWVER = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxInfoModel = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBoxImageInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxFilename);
            this.groupBox2.Controls.Add(this.buttonUpdate);
            this.groupBox2.Controls.Add(this.buttonFileOpen);
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(479, 105);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File";
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(18, 70);
            this.textBoxFilename.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(443, 21);
            this.textBoxFilename.TabIndex = 5;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(153, 23);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(120, 30);
            this.buttonUpdate.TabIndex = 9;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonFileOpen
            // 
            this.buttonFileOpen.Location = new System.Drawing.Point(18, 23);
            this.buttonFileOpen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonFileOpen.Name = "buttonFileOpen";
            this.buttonFileOpen.Size = new System.Drawing.Size(120, 30);
            this.buttonFileOpen.TabIndex = 6;
            this.buttonFileOpen.Text = "Open";
            this.buttonFileOpen.UseVisualStyleBackColor = true;
            this.buttonFileOpen.Click += new System.EventHandler(this.buttonFileOpen_Click);
            // 
            // buttonFileNew
            // 
            this.buttonFileNew.Location = new System.Drawing.Point(700, 456);
            this.buttonFileNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonFileNew.Name = "buttonFileNew";
            this.buttonFileNew.Size = new System.Drawing.Size(120, 30);
            this.buttonFileNew.TabIndex = 7;
            this.buttonFileNew.Text = "New";
            this.buttonFileNew.UseVisualStyleBackColor = true;
            this.buttonFileNew.Click += new System.EventHandler(this.buttonFileNew_Click);
            // 
            // textBoxCodeList
            // 
            this.textBoxCodeList.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCodeList.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodeList.Location = new System.Drawing.Point(197, 635);
            this.textBoxCodeList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCodeList.Multiline = true;
            this.textBoxCodeList.Name = "textBoxCodeList";
            this.textBoxCodeList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxCodeList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCodeList.Size = new System.Drawing.Size(479, 333);
            this.textBoxCodeList.TabIndex = 11;
            this.textBoxCodeList.WordWrap = false;
            // 
            // openFileDialogHex
            // 
            this.openFileDialogHex.DefaultExt = "hex";
            this.openFileDialogHex.FileName = "*.hex";
            this.openFileDialogHex.Filter = "Hex files (*.hex)|*.hex";
            this.openFileDialogHex.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogHex_FileOk);
            // 
            // progressBarUpdate
            // 
            this.progressBarUpdate.Location = new System.Drawing.Point(3, 125);
            this.progressBarUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBarUpdate.Name = "progressBarUpdate";
            this.progressBarUpdate.Size = new System.Drawing.Size(479, 21);
            this.progressBarUpdate.TabIndex = 12;
            // 
            // buttonDump
            // 
            this.buttonDump.Location = new System.Drawing.Point(197, 411);
            this.buttonDump.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonDump.Name = "buttonDump";
            this.buttonDump.Size = new System.Drawing.Size(120, 30);
            this.buttonDump.TabIndex = 13;
            this.buttonDump.Text = "Dump";
            this.buttonDump.UseVisualStyleBackColor = true;
            this.buttonDump.Click += new System.EventHandler(this.buttonDump_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(556, 411);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 30);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 165);
            this.label1.TabIndex = 24;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // groupBoxImageInfo
            // 
            this.groupBoxImageInfo.Controls.Add(this.textBoxCrc);
            this.groupBoxImageInfo.Controls.Add(this.label2);
            this.groupBoxImageInfo.Controls.Add(this.textImageBoxBootloader);
            this.groupBoxImageInfo.Controls.Add(this.label5);
            this.groupBoxImageInfo.Controls.Add(this.label6);
            this.groupBoxImageInfo.Controls.Add(this.textBoxImageFid);
            this.groupBoxImageInfo.Location = new System.Drawing.Point(197, 153);
            this.groupBoxImageInfo.Name = "groupBoxImageInfo";
            this.groupBoxImageInfo.Size = new System.Drawing.Size(188, 121);
            this.groupBoxImageInfo.TabIndex = 2270;
            this.groupBoxImageInfo.TabStop = false;
            this.groupBoxImageInfo.Text = "Image Info.";
            this.groupBoxImageInfo.Visible = false;
            // 
            // textBoxCrc
            // 
            this.textBoxCrc.Location = new System.Drawing.Point(87, 73);
            this.textBoxCrc.Name = "textBoxCrc";
            this.textBoxCrc.Size = new System.Drawing.Size(95, 21);
            this.textBoxCrc.TabIndex = 2290;
            this.textBoxCrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCrc.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2289;
            this.label2.Text = "CRC:";
            this.label2.Visible = false;
            // 
            // textImageBoxBootloader
            // 
            this.textImageBoxBootloader.Location = new System.Drawing.Point(87, 46);
            this.textImageBoxBootloader.Name = "textImageBoxBootloader";
            this.textImageBoxBootloader.Size = new System.Drawing.Size(95, 21);
            this.textImageBoxBootloader.TabIndex = 2288;
            this.textImageBoxBootloader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 2287;
            this.label5.Text = "Bootloader:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 2286;
            this.label6.Text = "FID:";
            // 
            // textBoxImageFid
            // 
            this.textBoxImageFid.Location = new System.Drawing.Point(87, 19);
            this.textBoxImageFid.Name = "textBoxImageFid";
            this.textBoxImageFid.Size = new System.Drawing.Size(95, 21);
            this.textBoxImageFid.TabIndex = 2277;
            this.textBoxImageFid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxReaderBootLoader);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBoxBand);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBoxInfoREGVER);
            this.groupBox3.Controls.Add(this.textBoxInfoFWVER);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBoxInfoModel);
            this.groupBox3.Location = new System.Drawing.Point(3, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 170);
            this.groupBox3.TabIndex = 2269;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Reader Info.";
            this.groupBox3.Visible = false;
            // 
            // textBoxReaderBootLoader
            // 
            this.textBoxReaderBootLoader.Location = new System.Drawing.Point(87, 137);
            this.textBoxReaderBootLoader.Name = "textBoxReaderBootLoader";
            this.textBoxReaderBootLoader.Size = new System.Drawing.Size(95, 21);
            this.textBoxReaderBootLoader.TabIndex = 2290;
            this.textBoxReaderBootLoader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 2289;
            this.label7.Text = "Bootloader:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 2286;
            this.label8.Text = "REG VER";
            // 
            // textBoxBand
            // 
            this.textBoxBand.Location = new System.Drawing.Point(87, 56);
            this.textBoxBand.Name = "textBoxBand";
            this.textBoxBand.Size = new System.Drawing.Size(95, 21);
            this.textBoxBand.TabIndex = 2285;
            this.textBoxBand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 15);
            this.label13.TabIndex = 2284;
            this.label13.Text = "REGION:";
            // 
            // textBoxInfoREGVER
            // 
            this.textBoxInfoREGVER.Location = new System.Drawing.Point(87, 110);
            this.textBoxInfoREGVER.Name = "textBoxInfoREGVER";
            this.textBoxInfoREGVER.Size = new System.Drawing.Size(95, 21);
            this.textBoxInfoREGVER.TabIndex = 2277;
            this.textBoxInfoREGVER.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxInfoFWVER
            // 
            this.textBoxInfoFWVER.Location = new System.Drawing.Point(87, 83);
            this.textBoxInfoFWVER.Name = "textBoxInfoFWVER";
            this.textBoxInfoFWVER.Size = new System.Drawing.Size(95, 21);
            this.textBoxInfoFWVER.TabIndex = 2275;
            this.textBoxInfoFWVER.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 2274;
            this.label10.Text = "F/W VER";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 2273;
            this.label9.Text = "MODEL:";
            // 
            // textBoxInfoModel
            // 
            this.textBoxInfoModel.Location = new System.Drawing.Point(87, 29);
            this.textBoxInfoModel.Name = "textBoxInfoModel";
            this.textBoxInfoModel.Size = new System.Drawing.Size(95, 21);
            this.textBoxInfoModel.TabIndex = 2266;
            this.textBoxInfoModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ucDownloader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBoxImageInfo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonDump);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonFileNew);
            this.Controls.Add(this.textBoxCodeList);
            this.Controls.Add(this.progressBarUpdate);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucDownloader";
            this.Size = new System.Drawing.Size(486, 154);
            this.Load += new System.EventHandler(this.FormDownloader_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxImageInfo.ResumeLayout(false);
            this.groupBoxImageInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.Button buttonFileOpen;
        private System.Windows.Forms.TextBox textBoxCodeList;
        private System.Windows.Forms.OpenFileDialog openFileDialogHex;
        public System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ProgressBar progressBarUpdate;
        private System.Windows.Forms.Button buttonFileNew;
        private System.Windows.Forms.Button buttonDump;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxImageInfo;
        private System.Windows.Forms.TextBox textBoxCrc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textImageBoxBootloader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxImageFid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxReaderBootLoader;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxBand;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxInfoREGVER;
        private System.Windows.Forms.TextBox textBoxInfoFWVER;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxInfoModel;
    }
}
