namespace Phychips.PR9200
{
    partial class FormTagInfoEpc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTagInfoEpc));
            this.textBoxCrcRd = new System.Windows.Forms.TextBox();
            this.textBoxEpcRd = new System.Windows.Forms.TextBox();
            this.textBoxEpcWrt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonEpcWrite = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPcRd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxCrcRd
            // 
            this.textBoxCrcRd.Location = new System.Drawing.Point(57, 28);
            this.textBoxCrcRd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCrcRd.Name = "textBoxCrcRd";
            this.textBoxCrcRd.ReadOnly = true;
            this.textBoxCrcRd.Size = new System.Drawing.Size(196, 21);
            this.textBoxCrcRd.TabIndex = 0;
            // 
            // textBoxEpcRd
            // 
            this.textBoxEpcRd.Location = new System.Drawing.Point(57, 120);
            this.textBoxEpcRd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEpcRd.Name = "textBoxEpcRd";
            this.textBoxEpcRd.ReadOnly = true;
            this.textBoxEpcRd.Size = new System.Drawing.Size(417, 21);
            this.textBoxEpcRd.TabIndex = 1;
            // 
            // textBoxEpcWrt
            // 
            this.textBoxEpcWrt.Location = new System.Drawing.Point(57, 149);
            this.textBoxEpcWrt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEpcWrt.Name = "textBoxEpcWrt";
            this.textBoxEpcWrt.Size = new System.Drawing.Size(417, 21);
            this.textBoxEpcWrt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "CRC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "EPC";
            // 
            // buttonEpcWrite
            // 
            this.buttonEpcWrite.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonEpcWrite.Location = new System.Drawing.Point(480, 120);
            this.buttonEpcWrite.Name = "buttonEpcWrite";
            this.buttonEpcWrite.Size = new System.Drawing.Size(81, 50);
            this.buttonEpcWrite.TabIndex = 7;
            this.buttonEpcWrite.Text = "Write";
            this.buttonEpcWrite.UseVisualStyleBackColor = true;
            this.buttonEpcWrite.Click += new System.EventHandler(this.buttonEpcWrite_Click);
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
            this.label4.Text = "0020h";
            // 
            // textBoxPcRd
            // 
            this.textBoxPcRd.Location = new System.Drawing.Point(57, 76);
            this.textBoxPcRd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPcRd.Name = "textBoxPcRd";
            this.textBoxPcRd.ReadOnly = true;
            this.textBoxPcRd.Size = new System.Drawing.Size(196, 21);
            this.textBoxPcRd.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "0010h";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "PC";
            // 
            // FormTagInfoEpc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 183);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPcRd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonEpcWrite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEpcWrt);
            this.Controls.Add(this.textBoxEpcRd);
            this.Controls.Add(this.textBoxCrcRd);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTagInfoEpc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag Information - EPC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCrcRd;
        private System.Windows.Forms.TextBox textBoxEpcRd;
        private System.Windows.Forms.TextBox textBoxEpcWrt;
        private System.Windows.Forms.TextBox textBoxPcRd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonEpcWrite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}