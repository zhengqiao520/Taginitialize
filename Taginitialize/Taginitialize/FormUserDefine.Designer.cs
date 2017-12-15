namespace Phychips.PR9200
{
    partial class FormUserDefine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserDefine));
            this.labelButtonName = new System.Windows.Forms.Label();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDes = new System.Windows.Forms.TextBox();
            this.groupBoxRCP = new System.Windows.Forms.GroupBox();
            this.textBoxRCP = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxRCP.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelButtonName
            // 
            this.labelButtonName.AutoSize = true;
            this.labelButtonName.Location = new System.Drawing.Point(7, 21);
            this.labelButtonName.Name = "labelButtonName";
            this.labelButtonName.Size = new System.Drawing.Size(83, 12);
            this.labelButtonName.TabIndex = 0;
            this.labelButtonName.Text = "Button label : ";
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDescription.Controls.Add(this.buttonLoad);
            this.groupBoxDescription.Controls.Add(this.buttonRun);
            this.groupBoxDescription.Controls.Add(this.labelButtonName);
            this.groupBoxDescription.Controls.Add(this.ButtonSave);
            this.groupBoxDescription.Controls.Add(this.textBoxName);
            this.groupBoxDescription.Controls.Add(this.textBoxDes);
            this.groupBoxDescription.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(370, 225);
            this.groupBoxDescription.TabIndex = 7;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Description";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(319, 14);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(45, 23);
            this.buttonRun.TabIndex = 5;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(217, 14);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(45, 23);
            this.ButtonSave.TabIndex = 4;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(96, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(115, 21);
            this.textBoxName.TabIndex = 3;
            // 
            // textBoxDes
            // 
            this.textBoxDes.Location = new System.Drawing.Point(3, 43);
            this.textBoxDes.Multiline = true;
            this.textBoxDes.Name = "textBoxDes";
            this.textBoxDes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDes.Size = new System.Drawing.Size(361, 176);
            this.textBoxDes.TabIndex = 0;
            // 
            // groupBoxRCP
            // 
            this.groupBoxRCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRCP.Controls.Add(this.textBoxRCP);
            this.groupBoxRCP.Location = new System.Drawing.Point(12, 246);
            this.groupBoxRCP.Name = "groupBoxRCP";
            this.groupBoxRCP.Size = new System.Drawing.Size(367, 221);
            this.groupBoxRCP.TabIndex = 2;
            this.groupBoxRCP.TabStop = false;
            this.groupBoxRCP.Text = "RCP";
            // 
            // textBoxRCP
            // 
            this.textBoxRCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRCP.Location = new System.Drawing.Point(6, 20);
            this.textBoxRCP.Multiline = true;
            this.textBoxRCP.Name = "textBoxRCP";
            this.textBoxRCP.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRCP.Size = new System.Drawing.Size(355, 195);
            this.textBoxRCP.TabIndex = 0;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(268, 14);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(45, 23);
            this.buttonLoad.TabIndex = 6;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text files (*.txt)|*.txt";
            // 
            // FormUserDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 479);
            this.Controls.Add(this.groupBoxRCP);
            this.Controls.Add(this.groupBoxDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUserDefine";
            this.Text = "User Define Button Editor";
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.groupBoxRCP.ResumeLayout(false);
            this.groupBoxRCP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelButtonName;
        private System.Windows.Forms.GroupBox groupBoxRCP;
        private System.Windows.Forms.TextBox textBoxRCP;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.TextBox textBoxDes;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}