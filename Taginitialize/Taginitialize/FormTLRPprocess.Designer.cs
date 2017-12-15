namespace Phychips.PR9200
{
    partial class FormTLRPprocess
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
            this.groupBoxProcess = new System.Windows.Forms.GroupBox();
            this.lbCurrent = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.progressBarCurrent = new System.Windows.Forms.ProgressBar();
            this.progressBarTotal = new System.Windows.Forms.ProgressBar();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.groupBoxProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProcess
            // 
            this.groupBoxProcess.Controls.Add(this.lbCurrent);
            this.groupBoxProcess.Controls.Add(this.lbTotal);
            this.groupBoxProcess.Controls.Add(this.progressBarCurrent);
            this.groupBoxProcess.Controls.Add(this.progressBarTotal);
            this.groupBoxProcess.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProcess.Name = "groupBoxProcess";
            this.groupBoxProcess.Size = new System.Drawing.Size(364, 80);
            this.groupBoxProcess.TabIndex = 0;
            this.groupBoxProcess.TabStop = false;
            this.groupBoxProcess.Text = "Process Status";
            // 
            // lbCurrent
            // 
            this.lbCurrent.AutoSize = true;
            this.lbCurrent.Location = new System.Drawing.Point(6, 53);
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(46, 12);
            this.lbCurrent.TabIndex = 3;
            this.lbCurrent.Text = "Current";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(19, 25);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(33, 12);
            this.lbTotal.TabIndex = 2;
            this.lbTotal.Text = "Total";
            // 
            // progressBarCurrent
            // 
            this.progressBarCurrent.Location = new System.Drawing.Point(66, 49);
            this.progressBarCurrent.Name = "progressBarCurrent";
            this.progressBarCurrent.Size = new System.Drawing.Size(287, 23);
            this.progressBarCurrent.TabIndex = 1;
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Location = new System.Drawing.Point(66, 20);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(287, 23);
            this.progressBarTotal.TabIndex = 0;
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(301, 98);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(75, 23);
            this.buttonAbort.TabIndex = 1;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // FormTLRPprocess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 129);
            this.ControlBox = false;
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.groupBoxProcess);
            this.MinimumSize = new System.Drawing.Size(399, 39);
            this.Name = "FormTLRPprocess";
            this.Text = "Processing";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTLRPprocess_FormClosing);
            this.groupBoxProcess.ResumeLayout(false);
            this.groupBoxProcess.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProcess;
        private System.Windows.Forms.Label lbCurrent;
        private System.Windows.Forms.Label lbTotal;
        public System.Windows.Forms.ProgressBar progressBarCurrent;
        public System.Windows.Forms.ProgressBar progressBarTotal;
        private System.Windows.Forms.Button buttonAbort;
    }
}