namespace RFIDStation
{
    partial class updateSystem
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件：";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(57, 2);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(506, 21);
            this.textBoxFilePath.TabIndex = 1;
            this.textBoxFilePath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFilePath_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "进度：";
            // 
            // progressBarUpdate
            // 
            this.progressBarUpdate.Location = new System.Drawing.Point(57, 26);
            this.progressBarUpdate.Name = "progressBarUpdate";
            this.progressBarUpdate.Size = new System.Drawing.Size(554, 23);
            this.progressBarUpdate.TabIndex = 3;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(565, 0);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(46, 23);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "下载";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // updateSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 53);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.progressBarUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "updateSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "updateSystem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.updateSystem_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBarUpdate;
        private System.Windows.Forms.Button buttonUpdate;

    }
}