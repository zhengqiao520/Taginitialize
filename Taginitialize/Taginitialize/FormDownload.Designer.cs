namespace Phychips.PR9200
{
    partial class FormDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownload));
            this.ucDownloader1 = new Phychips.PR9200.ucDownloader();
            this.SuspendLayout();
            // 
            // ucDownloader1
            // 
            this.ucDownloader1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDownloader1.Location = new System.Drawing.Point(12, 13);
            this.ucDownloader1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucDownloader1.Name = "ucDownloader1";
            this.ucDownloader1.Size = new System.Drawing.Size(493, 154);
            this.ucDownloader1.TabIndex = 0;
            // 
            // FormDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 171);
            this.Controls.Add(this.ucDownloader1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(526, 209);
            this.Name = "FormDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDownload_FormClosing);
            this.Load += new System.EventHandler(this.FormDownload_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucDownloader ucDownloader1;
    }
}