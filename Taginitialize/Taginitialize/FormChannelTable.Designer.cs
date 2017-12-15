namespace Phychips.PR9200
{
    partial class FormChannelTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChannelTable));
            this.buttonAddChannel = new System.Windows.Forms.Button();
            this.buttonRemoveChannel = new System.Windows.Forms.Button();
            this.buttonUpdateTable = new System.Windows.Forms.Button();
            this.listViewEx1 = new CustomListView.ListViewEx();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Channel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonScan = new System.Windows.Forms.Button();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.groupBoxAuto = new System.Windows.Forms.GroupBox();
            this.radioButtonNorm = new System.Windows.Forms.RadioButton();
            this.radioButtonOpt = new System.Windows.Forms.RadioButton();
            this.groupBoxChTable = new System.Windows.Forms.GroupBox();
            this.groupBoxTableMode = new System.Windows.Forms.GroupBox();
            this.groupBoxManual.SuspendLayout();
            this.groupBoxAuto.SuspendLayout();
            this.groupBoxChTable.SuspendLayout();
            this.groupBoxTableMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddChannel
            // 
            this.buttonAddChannel.Location = new System.Drawing.Point(6, 20);
            this.buttonAddChannel.Name = "buttonAddChannel";
            this.buttonAddChannel.Size = new System.Drawing.Size(68, 36);
            this.buttonAddChannel.TabIndex = 1;
            this.buttonAddChannel.Text = "Add";
            this.buttonAddChannel.UseVisualStyleBackColor = true;
            this.buttonAddChannel.Click += new System.EventHandler(this.buttonAddChannel_Click);
            // 
            // buttonRemoveChannel
            // 
            this.buttonRemoveChannel.Location = new System.Drawing.Point(80, 20);
            this.buttonRemoveChannel.Name = "buttonRemoveChannel";
            this.buttonRemoveChannel.Size = new System.Drawing.Size(68, 36);
            this.buttonRemoveChannel.TabIndex = 2;
            this.buttonRemoveChannel.Text = "Remove";
            this.buttonRemoveChannel.UseVisualStyleBackColor = true;
            this.buttonRemoveChannel.Click += new System.EventHandler(this.buttonRemoveChannel_Click);
            // 
            // buttonUpdateTable
            // 
            this.buttonUpdateTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateTable.Location = new System.Drawing.Point(275, 435);
            this.buttonUpdateTable.Name = "buttonUpdateTable";
            this.buttonUpdateTable.Size = new System.Drawing.Size(111, 36);
            this.buttonUpdateTable.TabIndex = 3;
            this.buttonUpdateTable.Text = "Update Table";
            this.buttonUpdateTable.UseVisualStyleBackColor = true;
            this.buttonUpdateTable.Click += new System.EventHandler(this.buttonUpdateTable_Click);
            // 
            // listViewEx1
            // 
            this.listViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.Channel});
            this.listViewEx1.FullRowSelect = true;
            this.listViewEx1.GridLines = true;
            this.listViewEx1.Location = new System.Drawing.Point(8, 20);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(362, 319);
            this.listViewEx1.TabIndex = 0;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // Number
            // 
            this.Number.Text = "Number";
            this.Number.Width = 100;
            // 
            // Channel
            // 
            this.Channel.Text = "Channel";
            this.Channel.Width = 100;
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(10, 20);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(68, 36);
            this.buttonScan.TabIndex = 4;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // groupBoxManual
            // 
            this.groupBoxManual.Controls.Add(this.buttonAddChannel);
            this.groupBoxManual.Controls.Add(this.buttonRemoveChannel);
            this.groupBoxManual.Location = new System.Drawing.Point(14, 12);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(158, 66);
            this.groupBoxManual.TabIndex = 5;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "Manual";
            // 
            // groupBoxAuto
            // 
            this.groupBoxAuto.Controls.Add(this.buttonScan);
            this.groupBoxAuto.Location = new System.Drawing.Point(178, 12);
            this.groupBoxAuto.Name = "groupBoxAuto";
            this.groupBoxAuto.Size = new System.Drawing.Size(86, 66);
            this.groupBoxAuto.TabIndex = 6;
            this.groupBoxAuto.TabStop = false;
            this.groupBoxAuto.Text = "Auto";
            // 
            // radioButtonNorm
            // 
            this.radioButtonNorm.AutoSize = true;
            this.radioButtonNorm.Location = new System.Drawing.Point(6, 41);
            this.radioButtonNorm.Name = "radioButtonNorm";
            this.radioButtonNorm.Size = new System.Drawing.Size(64, 19);
            this.radioButtonNorm.TabIndex = 6;
            this.radioButtonNorm.Text = "Default";
            this.radioButtonNorm.UseVisualStyleBackColor = true;
            // 
            // radioButtonOpt
            // 
            this.radioButtonOpt.AutoSize = true;
            this.radioButtonOpt.Checked = true;
            this.radioButtonOpt.Location = new System.Drawing.Point(6, 20);
            this.radioButtonOpt.Name = "radioButtonOpt";
            this.radioButtonOpt.Size = new System.Drawing.Size(71, 19);
            this.radioButtonOpt.TabIndex = 5;
            this.radioButtonOpt.TabStop = true;
            this.radioButtonOpt.Text = "Modified";
            this.radioButtonOpt.UseVisualStyleBackColor = true;
            this.radioButtonOpt.CheckedChanged += new System.EventHandler(this.radioButtonOpt_CheckedChanged);
            // 
            // groupBoxChTable
            // 
            this.groupBoxChTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxChTable.Controls.Add(this.listViewEx1);
            this.groupBoxChTable.Location = new System.Drawing.Point(14, 84);
            this.groupBoxChTable.Name = "groupBoxChTable";
            this.groupBoxChTable.Size = new System.Drawing.Size(376, 345);
            this.groupBoxChTable.TabIndex = 7;
            this.groupBoxChTable.TabStop = false;
            this.groupBoxChTable.Text = "Frequency Hopping Table";
            // 
            // groupBoxTableMode
            // 
            this.groupBoxTableMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTableMode.Controls.Add(this.radioButtonOpt);
            this.groupBoxTableMode.Controls.Add(this.radioButtonNorm);
            this.groupBoxTableMode.Location = new System.Drawing.Point(274, 12);
            this.groupBoxTableMode.Name = "groupBoxTableMode";
            this.groupBoxTableMode.Size = new System.Drawing.Size(116, 66);
            this.groupBoxTableMode.TabIndex = 8;
            this.groupBoxTableMode.TabStop = false;
            this.groupBoxTableMode.Text = "Channel Table";
            // 
            // FormChannelTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 481);
            this.Controls.Add(this.groupBoxTableMode);
            this.Controls.Add(this.groupBoxChTable);
            this.Controls.Add(this.groupBoxAuto);
            this.Controls.Add(this.groupBoxManual);
            this.Controls.Add(this.buttonUpdateTable);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormChannelTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frequency Hopping Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChannelTable_FormClosing);
            this.Load += new System.EventHandler(this.FormChannelTable_Load);
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxAuto.ResumeLayout(false);
            this.groupBoxChTable.ResumeLayout(false);
            this.groupBoxTableMode.ResumeLayout(false);
            this.groupBoxTableMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomListView.ListViewEx listViewEx1;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader Channel;
        private System.Windows.Forms.Button buttonAddChannel;
        private System.Windows.Forms.Button buttonRemoveChannel;
        private System.Windows.Forms.Button buttonUpdateTable;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.GroupBox groupBoxAuto;
        private System.Windows.Forms.RadioButton radioButtonNorm;
        private System.Windows.Forms.RadioButton radioButtonOpt;
        private System.Windows.Forms.GroupBox groupBoxChTable;
        private System.Windows.Forms.GroupBox groupBoxTableMode;

    }
}