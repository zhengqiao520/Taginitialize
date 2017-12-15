namespace Phychips.PR9200
{
    partial class FormSensorTag
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageRFM = new System.Windows.Forms.TabPage();
            this.userControlSensorTagRFM = new Phychips.PR9200.UserControlSensorTag();
            this.tabPageEM = new System.Windows.Forms.TabPage();
            this.userControlSensorTagEM = new Phychips.PR9200.UserControlSensorTagEM();
            this.tabControl.SuspendLayout();
            this.tabPageRFM.SuspendLayout();
            this.tabPageEM.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageRFM);
            this.tabControl.Controls.Add(this.tabPageEM);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1003, 583);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageRFM
            // 
            this.tabPageRFM.Controls.Add(this.userControlSensorTagRFM);
            this.tabPageRFM.Location = new System.Drawing.Point(4, 22);
            this.tabPageRFM.Name = "tabPageRFM";
            this.tabPageRFM.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRFM.Size = new System.Drawing.Size(995, 557);
            this.tabPageRFM.TabIndex = 0;
            this.tabPageRFM.Text = "RF Micron";
            this.tabPageRFM.UseVisualStyleBackColor = true;
            // 
            // userControlSensorTagRFM
            // 
            this.userControlSensorTagRFM.Location = new System.Drawing.Point(6, 2);
            this.userControlSensorTagRFM.Name = "userControlSensorTagRFM";
            this.userControlSensorTagRFM.Size = new System.Drawing.Size(1001, 552);
            this.userControlSensorTagRFM.TabIndex = 0;
            // 
            // tabPageEM
            // 
            this.tabPageEM.Controls.Add(this.userControlSensorTagEM);
            this.tabPageEM.Location = new System.Drawing.Point(4, 22);
            this.tabPageEM.Name = "tabPageEM";
            this.tabPageEM.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEM.Size = new System.Drawing.Size(995, 557);
            this.tabPageEM.TabIndex = 1;
            this.tabPageEM.Text = "EM Micro";
            this.tabPageEM.UseVisualStyleBackColor = true;
            // 
            // userControlSensorTagEM
            // 
            this.userControlSensorTagEM.Location = new System.Drawing.Point(6, 3);
            this.userControlSensorTagEM.Name = "userControlSensorTagEM";
            this.userControlSensorTagEM.Size = new System.Drawing.Size(725, 557);
            this.userControlSensorTagEM.TabIndex = 0;
            // 
            // FormSensorTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 618);
            this.Controls.Add(this.tabControl);
            this.Name = "FormSensorTag";
            this.Text = "Sensor Tag";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSensorTag_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPageRFM.ResumeLayout(false);
            this.tabPageEM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageRFM;
        private UserControlSensorTag userControlSensorTagRFM;
        private System.Windows.Forms.TabPage tabPageEM;
        private UserControlSensorTagEM userControlSensorTagEM;
    }
}