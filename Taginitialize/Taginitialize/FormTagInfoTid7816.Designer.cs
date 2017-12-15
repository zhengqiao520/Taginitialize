namespace Phychips.PR9200
{
    partial class FormTagInfoTid7816
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTagInfoTid7816));
            this.textBoxAc = new System.Windows.Forms.TextBox();
            this.textBoxSn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMfgCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMfgName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxAc
            // 
            this.textBoxAc.Location = new System.Drawing.Point(57, 28);
            this.textBoxAc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxAc.Name = "textBoxAc";
            this.textBoxAc.ReadOnly = true;
            this.textBoxAc.Size = new System.Drawing.Size(35, 21);
            this.textBoxAc.TabIndex = 0;
            // 
            // textBoxSn
            // 
            this.textBoxSn.Location = new System.Drawing.Point(57, 120);
            this.textBoxSn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSn.Name = "textBoxSn";
            this.textBoxSn.ReadOnly = true;
            this.textBoxSn.Size = new System.Drawing.Size(417, 21);
            this.textBoxSn.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Allocation-class identifier (AC)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "IC manufacturer serial number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "0000h";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "0010h";
            // 
            // textBoxMfgCode
            // 
            this.textBoxMfgCode.Location = new System.Drawing.Point(57, 76);
            this.textBoxMfgCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMfgCode.Name = "textBoxMfgCode";
            this.textBoxMfgCode.ReadOnly = true;
            this.textBoxMfgCode.Size = new System.Drawing.Size(35, 21);
            this.textBoxMfgCode.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "0008h";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "IC Mfg code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "E0 for ISO/IEC 7816-6, E2 for EPCglobal";
            // 
            // textBoxMfgName
            // 
            this.textBoxMfgName.Location = new System.Drawing.Point(101, 76);
            this.textBoxMfgName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMfgName.Name = "textBoxMfgName";
            this.textBoxMfgName.ReadOnly = true;
            this.textBoxMfgName.Size = new System.Drawing.Size(77, 21);
            this.textBoxMfgName.TabIndex = 14;
            // 
            // FormTagInfoTid7816
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 153);
            this.Controls.Add(this.textBoxMfgName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMfgCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSn);
            this.Controls.Add(this.textBoxAc);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTagInfoTid7816";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag Information - TID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAc;
        private System.Windows.Forms.TextBox textBoxMfgCode;
        private System.Windows.Forms.TextBox textBoxSn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMfgName;
    }
}