namespace Phychips.PR9200
{
    partial class FormTagInfoReserved
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTagInfoReserved));
            this.textBoxKillPwRd = new System.Windows.Forms.TextBox();
            this.textBoxAccessPwRd = new System.Windows.Forms.TextBox();
            this.textBoxAccessPwWrt = new System.Windows.Forms.TextBox();
            this.textBoxKillPwWrt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKillPwWrite = new System.Windows.Forms.Button();
            this.buttonAccessPwWrite = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxKillPwRd
            // 
            this.textBoxKillPwRd.Location = new System.Drawing.Point(60, 28);
            this.textBoxKillPwRd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxKillPwRd.Name = "textBoxKillPwRd";
            this.textBoxKillPwRd.ReadOnly = true;
            this.textBoxKillPwRd.Size = new System.Drawing.Size(196, 21);
            this.textBoxKillPwRd.TabIndex = 0;
            // 
            // textBoxAccessPwRd
            // 
            this.textBoxAccessPwRd.Location = new System.Drawing.Point(60, 112);
            this.textBoxAccessPwRd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxAccessPwRd.Name = "textBoxAccessPwRd";
            this.textBoxAccessPwRd.ReadOnly = true;
            this.textBoxAccessPwRd.Size = new System.Drawing.Size(196, 21);
            this.textBoxAccessPwRd.TabIndex = 1;
            // 
            // textBoxAccessPwWrt
            // 
            this.textBoxAccessPwWrt.Location = new System.Drawing.Point(60, 141);
            this.textBoxAccessPwWrt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxAccessPwWrt.Name = "textBoxAccessPwWrt";
            this.textBoxAccessPwWrt.Size = new System.Drawing.Size(196, 21);
            this.textBoxAccessPwWrt.TabIndex = 3;
            // 
            // textBoxKillPwWrt
            // 
            this.textBoxKillPwWrt.Location = new System.Drawing.Point(60, 57);
            this.textBoxKillPwWrt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxKillPwWrt.Name = "textBoxKillPwWrt";
            this.textBoxKillPwWrt.Size = new System.Drawing.Size(196, 21);
            this.textBoxKillPwWrt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kill Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Access Password";
            // 
            // buttonKillPwWrite
            // 
            this.buttonKillPwWrite.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonKillPwWrite.Location = new System.Drawing.Point(262, 28);
            this.buttonKillPwWrite.Name = "buttonKillPwWrite";
            this.buttonKillPwWrite.Size = new System.Drawing.Size(81, 50);
            this.buttonKillPwWrite.TabIndex = 6;
            this.buttonKillPwWrite.Text = "Write";
            this.buttonKillPwWrite.UseVisualStyleBackColor = true;
            this.buttonKillPwWrite.Click += new System.EventHandler(this.buttonKillPwWrite_Click);
            // 
            // buttonAccessPwWrite
            // 
            this.buttonAccessPwWrite.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAccessPwWrite.Location = new System.Drawing.Point(262, 112);
            this.buttonAccessPwWrite.Name = "buttonAccessPwWrite";
            this.buttonAccessPwWrite.Size = new System.Drawing.Size(81, 50);
            this.buttonAccessPwWrite.TabIndex = 7;
            this.buttonAccessPwWrite.Text = "Write";
            this.buttonAccessPwWrite.UseVisualStyleBackColor = true;
            this.buttonAccessPwWrite.Click += new System.EventHandler(this.buttonAccessPwWrite_Click);
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
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "0020h";
            // 
            // FormTagInfoReserved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 181);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAccessPwWrite);
            this.Controls.Add(this.buttonKillPwWrite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAccessPwWrt);
            this.Controls.Add(this.textBoxKillPwWrt);
            this.Controls.Add(this.textBoxAccessPwRd);
            this.Controls.Add(this.textBoxKillPwRd);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTagInfoReserved";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag Information - Reserved";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKillPwRd;
        private System.Windows.Forms.TextBox textBoxAccessPwRd;
        private System.Windows.Forms.TextBox textBoxAccessPwWrt;        
        private System.Windows.Forms.TextBox textBoxKillPwWrt;        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKillPwWrite;
        private System.Windows.Forms.Button buttonAccessPwWrite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}