namespace RFIDStation
{
    partial class NfcTools
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
            this.tabControlNfcTools = new System.Windows.Forms.TabControl();
            this.tabPageReadNfcInfo = new System.Windows.Forms.TabPage();
            this.tabPageDataInfo = new System.Windows.Forms.TabPage();
            this.tabPageWriteNfcInfo = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControlNfcTools.SuspendLayout();
            this.tabPageReadNfcInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlNfcTools
            // 
            this.tabControlNfcTools.Controls.Add(this.tabPageReadNfcInfo);
            this.tabControlNfcTools.Controls.Add(this.tabPageDataInfo);
            this.tabControlNfcTools.Controls.Add(this.tabPageWriteNfcInfo);
            this.tabControlNfcTools.Location = new System.Drawing.Point(1, 1);
            this.tabControlNfcTools.Name = "tabControlNfcTools";
            this.tabControlNfcTools.SelectedIndex = 0;
            this.tabControlNfcTools.Size = new System.Drawing.Size(297, 464);
            this.tabControlNfcTools.TabIndex = 0;
            // 
            // tabPageReadNfcInfo
            // 
            this.tabPageReadNfcInfo.Controls.Add(this.textBox1);
            this.tabPageReadNfcInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageReadNfcInfo.Name = "tabPageReadNfcInfo";
            this.tabPageReadNfcInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReadNfcInfo.Size = new System.Drawing.Size(289, 438);
            this.tabPageReadNfcInfo.TabIndex = 0;
            this.tabPageReadNfcInfo.Text = "读取";
            this.tabPageReadNfcInfo.UseVisualStyleBackColor = true;
            // 
            // tabPageDataInfo
            // 
            this.tabPageDataInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataInfo.Name = "tabPageDataInfo";
            this.tabPageDataInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataInfo.Size = new System.Drawing.Size(289, 438);
            this.tabPageDataInfo.TabIndex = 1;
            this.tabPageDataInfo.Text = "数据";
            this.tabPageDataInfo.UseVisualStyleBackColor = true;
            // 
            // tabPageWriteNfcInfo
            // 
            this.tabPageWriteNfcInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageWriteNfcInfo.Name = "tabPageWriteNfcInfo";
            this.tabPageWriteNfcInfo.Size = new System.Drawing.Size(289, 438);
            this.tabPageWriteNfcInfo.TabIndex = 2;
            this.tabPageWriteNfcInfo.Text = "写入";
            this.tabPageWriteNfcInfo.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(289, 438);
            this.textBox1.TabIndex = 0;
            // 
            // NfcTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 465);
            this.Controls.Add(this.tabControlNfcTools);
            this.MaximizeBox = false;
            this.Name = "NfcTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NfcTool";
            this.Load += new System.EventHandler(this.NfcTools_Load);
            this.tabControlNfcTools.ResumeLayout(false);
            this.tabPageReadNfcInfo.ResumeLayout(false);
            this.tabPageReadNfcInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlNfcTools;
        private System.Windows.Forms.TabPage tabPageReadNfcInfo;
        private System.Windows.Forms.TabPage tabPageDataInfo;
        private System.Windows.Forms.TabPage tabPageWriteNfcInfo;
        private System.Windows.Forms.TextBox textBox1;
    }
}