namespace Phychips.PR9200
{
    partial class ucAdvanced
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
            this.textBoxTemperature = new System.Windows.Forms.TextBox();
            this.buttonGetTemperature = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBoxSleep = new System.Windows.Forms.ComboBox();
            this.buttonDeepSleep = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonResetSystem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxADC = new System.Windows.Forms.TextBox();
            this.buttonGetADC = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTemperature
            // 
            this.textBoxTemperature.Location = new System.Drawing.Point(15, 24);
            this.textBoxTemperature.Name = "textBoxTemperature";
            this.textBoxTemperature.Size = new System.Drawing.Size(80, 21);
            this.textBoxTemperature.TabIndex = 2257;
            this.textBoxTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonGetTemperature
            // 
            this.buttonGetTemperature.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetTemperature.Location = new System.Drawing.Point(283, 22);
            this.buttonGetTemperature.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonGetTemperature.Name = "buttonGetTemperature";
            this.buttonGetTemperature.Size = new System.Drawing.Size(90, 30);
            this.buttonGetTemperature.TabIndex = 2258;
            this.buttonGetTemperature.Text = "Get";
            this.buttonGetTemperature.UseVisualStyleBackColor = true;
            this.buttonGetTemperature.Click += new System.EventHandler(this.buttonGetTemperature_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxTemperature);
            this.groupBox1.Controls.Add(this.buttonGetTemperature);
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 67);
            this.groupBox1.TabIndex = 2259;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(101, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 2260;
            this.label3.Text = "°C";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Location = new System.Drawing.Point(3, 189);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(401, 209);
            this.groupBox5.TabIndex = 2261;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "System Status";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(401, 180);
            this.groupBox6.TabIndex = 2262;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "System Management";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBoxSleep);
            this.groupBox8.Controls.Add(this.buttonDeepSleep);
            this.groupBox8.Location = new System.Drawing.Point(6, 93);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(389, 67);
            this.groupBox8.TabIndex = 2262;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Power Management";
            // 
            // comboBoxSleep
            // 
            this.comboBoxSleep.FormattingEnabled = true;
            this.comboBoxSleep.Location = new System.Drawing.Point(15, 24);
            this.comboBoxSleep.Name = "comboBoxSleep";
            this.comboBoxSleep.Size = new System.Drawing.Size(121, 23);
            this.comboBoxSleep.TabIndex = 2263;
            // 
            // buttonDeepSleep
            // 
            this.buttonDeepSleep.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeepSleep.Location = new System.Drawing.Point(283, 22);
            this.buttonDeepSleep.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonDeepSleep.Name = "buttonDeepSleep";
            this.buttonDeepSleep.Size = new System.Drawing.Size(90, 30);
            this.buttonDeepSleep.TabIndex = 2258;
            this.buttonDeepSleep.Text = "Set";
            this.buttonDeepSleep.UseVisualStyleBackColor = true;
            this.buttonDeepSleep.Click += new System.EventHandler(this.buttonDeepSleep_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttonResetSystem);
            this.groupBox7.Location = new System.Drawing.Point(6, 20);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(389, 67);
            this.groupBox7.TabIndex = 2261;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Reset System";
            // 
            // buttonResetSystem
            // 
            this.buttonResetSystem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetSystem.Location = new System.Drawing.Point(283, 22);
            this.buttonResetSystem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonResetSystem.Name = "buttonResetSystem";
            this.buttonResetSystem.Size = new System.Drawing.Size(90, 30);
            this.buttonResetSystem.TabIndex = 2258;
            this.buttonResetSystem.Text = "Set";
            this.buttonResetSystem.UseVisualStyleBackColor = true;
            this.buttonResetSystem.Click += new System.EventHandler(this.buttonResetSystem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxADC);
            this.groupBox2.Controls.Add(this.buttonGetADC);
            this.groupBox2.Location = new System.Drawing.Point(6, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 67);
            this.groupBox2.TabIndex = 2260;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADC";
            // 
            // textBoxADC
            // 
            this.textBoxADC.Location = new System.Drawing.Point(15, 24);
            this.textBoxADC.Name = "textBoxADC";
            this.textBoxADC.Size = new System.Drawing.Size(80, 21);
            this.textBoxADC.TabIndex = 2257;
            this.textBoxADC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonGetADC
            // 
            this.buttonGetADC.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetADC.Location = new System.Drawing.Point(283, 22);
            this.buttonGetADC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonGetADC.Name = "buttonGetADC";
            this.buttonGetADC.Size = new System.Drawing.Size(90, 30);
            this.buttonGetADC.TabIndex = 2258;
            this.buttonGetADC.Text = "Get";
            this.buttonGetADC.UseVisualStyleBackColor = true;
            this.buttonGetADC.Click += new System.EventHandler(this.buttonGetADC_Click);
            // 
            // ucAdvanced
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucAdvanced";
            this.Size = new System.Drawing.Size(820, 500);
            this.Load += new System.EventHandler(this.ucAdvanced_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTemperature;
        private System.Windows.Forms.Button buttonGetTemperature;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button buttonDeepSleep;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button buttonResetSystem;
        private System.Windows.Forms.ComboBox comboBoxSleep;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxADC;
        private System.Windows.Forms.Button buttonGetADC;
    }
}
