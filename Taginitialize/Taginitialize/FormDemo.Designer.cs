namespace Phychips.PR9200
{
    partial class FormDemo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDemo));
            this.progressCircle1 = new Utezduyar.Windows.Forms.ProgressCircle();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbSelectedTag = new System.Windows.Forms.Label();
            this.lvTagInfo = new System.Windows.Forms.ListView();
            this.cNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cEPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cRssi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBoxTotal = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStripTagAccess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStripTagAccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressCircle1
            // 
            this.progressCircle1.ForeColor = System.Drawing.Color.Transparent;
            this.progressCircle1.Location = new System.Drawing.Point(432, 20);
            this.progressCircle1.Name = "progressCircle1";
            this.progressCircle1.RingColor = System.Drawing.Color.White;
            this.progressCircle1.RingThickness = 10;
            this.progressCircle1.Size = new System.Drawing.Size(133, 127);
            this.progressCircle1.TabIndex = 1;
            this.progressCircle1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(554, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbSelectedTag);
            this.groupBox1.Controls.Add(this.lvTagInfo);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 252);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tag Information";
            // 
            // lbSelectedTag
            // 
            this.lbSelectedTag.AutoSize = true;
            this.lbSelectedTag.Location = new System.Drawing.Point(6, 229);
            this.lbSelectedTag.Name = "lbSelectedTag";
            this.lbSelectedTag.Size = new System.Drawing.Size(92, 12);
            this.lbSelectedTag.TabIndex = 4;
            this.lbSelectedTag.Text = "Selected Tag : ";
            // 
            // lvTagInfo
            // 
            this.lvTagInfo.AutoArrange = false;
            this.lvTagInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cNumber,
            this.cPC,
            this.cEPC,
            this.cCnt,
            this.cRssi});
            this.lvTagInfo.Font = new System.Drawing.Font("Arial", 9F);
            this.lvTagInfo.FullRowSelect = true;
            this.lvTagInfo.Location = new System.Drawing.Point(6, 16);
            this.lvTagInfo.MultiSelect = false;
            this.lvTagInfo.Name = "lvTagInfo";
            this.lvTagInfo.Size = new System.Drawing.Size(623, 202);
            this.lvTagInfo.TabIndex = 5;
            this.lvTagInfo.UseCompatibleStateImageBehavior = false;
            this.lvTagInfo.View = System.Windows.Forms.View.Details;
            // 
            // cNumber
            // 
            this.cNumber.Text = "";
            this.cNumber.Width = 30;
            // 
            // cPC
            // 
            this.cPC.Text = "PC";
            this.cPC.Width = 50;
            // 
            // cEPC
            // 
            this.cEPC.Text = "EPC";
            this.cEPC.Width = 350;
            // 
            // cCnt
            // 
            this.cCnt.Text = "Count";
            this.cCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cCnt.Width = 70;
            // 
            // cRssi
            // 
            this.cRssi.Text = "Tag RSSI";
            this.cRssi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cRssi.Width = 70;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.progressCircle1);
            this.groupBox2.Controls.Add(this.txtBoxTotal);
            this.groupBox2.Location = new System.Drawing.Point(12, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 158);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control Panel";
            // 
            // txtBoxTotal
            // 
            this.txtBoxTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxTotal.Font = new System.Drawing.Font("굴림", 80F);
            this.txtBoxTotal.Location = new System.Drawing.Point(6, 20);
            this.txtBoxTotal.Name = "txtBoxTotal";
            this.txtBoxTotal.ReadOnly = true;
            this.txtBoxTotal.Size = new System.Drawing.Size(453, 123);
            this.txtBoxTotal.TabIndex = 4;
            this.txtBoxTotal.Text = "0";
            this.txtBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(475, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 51);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStripTagAccess
            // 
            this.contextMenuStripTagAccess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem});
            this.contextMenuStripTagAccess.Name = "contextMenuStripTagAccess";
            this.contextMenuStripTagAccess.Size = new System.Drawing.Size(107, 26);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 453);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(673, 492);
            this.MinimumSize = new System.Drawing.Size(673, 492);
            this.Name = "FormDemo";
            this.Text = "Demo";
            this.Deactivate += new System.EventHandler(this.FormDemo_Deactivate);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStripTagAccess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader cNumber;
        private System.Windows.Forms.ColumnHeader cPC;
        private System.Windows.Forms.ColumnHeader cEPC;
        private System.Windows.Forms.ColumnHeader cCnt;
        private System.Windows.Forms.ColumnHeader cRssi;
        public System.Windows.Forms.ListView lvTagInfo;
        public Utezduyar.Windows.Forms.ProgressCircle progressCircle1;
        private System.Windows.Forms.Label lbSelectedTag;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTagAccess;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        public System.Windows.Forms.TextBox txtBoxTotal;
    }
}