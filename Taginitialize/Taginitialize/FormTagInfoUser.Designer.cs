namespace Phychips.PR9200
{
    partial class FormTagInfoUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTagInfoUser));
            this.textBoxUserRd = new System.Windows.Forms.TextBox();
            this.textBoxUserWrt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKillPwWrite = new System.Windows.Forms.Button();
            this.labelAddress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUserRd
            // 
            this.textBoxUserRd.Location = new System.Drawing.Point(60, 28);
            this.textBoxUserRd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxUserRd.Name = "textBoxUserRd";
            this.textBoxUserRd.ReadOnly = true;
            this.textBoxUserRd.Size = new System.Drawing.Size(394, 21);
            this.textBoxUserRd.TabIndex = 0;
            // 
            // textBoxUserWrt
            // 
            this.textBoxUserWrt.Location = new System.Drawing.Point(60, 57);
            this.textBoxUserWrt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxUserWrt.Name = "textBoxUserWrt";
            this.textBoxUserWrt.Size = new System.Drawing.Size(394, 21);
            this.textBoxUserWrt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "User Memory";
            // 
            // buttonKillPwWrite
            // 
            this.buttonKillPwWrite.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonKillPwWrite.Location = new System.Drawing.Point(460, 28);
            this.buttonKillPwWrite.Name = "buttonKillPwWrite";
            this.buttonKillPwWrite.Size = new System.Drawing.Size(81, 50);
            this.buttonKillPwWrite.TabIndex = 6;
            this.buttonKillPwWrite.Text = "Write";
            this.buttonKillPwWrite.UseVisualStyleBackColor = true;
            this.buttonKillPwWrite.Click += new System.EventHandler(this.buttonKillPwWrite_Click);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(10, 31);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(35, 15);
            this.labelAddress.TabIndex = 8;
            this.labelAddress.Text = "0000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "h";
            // 
            // FormTagInfoUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 92);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.buttonKillPwWrite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUserWrt);
            this.Controls.Add(this.textBoxUserRd);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTagInfoUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag Information - User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserRd;        
        private System.Windows.Forms.TextBox textBoxUserWrt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKillPwWrite;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label label2;

    }
}