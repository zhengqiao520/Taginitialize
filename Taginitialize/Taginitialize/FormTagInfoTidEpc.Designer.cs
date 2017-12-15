namespace Phychips.PR9200
{
    partial class FormTagInfoTidEpc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTagInfoTidEpc));
            this.textBoxAc = new System.Windows.Forms.TextBox();
            this.textBoxMdidCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxXtid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxModelNumberCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxXtidHeader = new System.Windows.Forms.TextBox();
            this.textBoxSn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxOptionalCmd = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxBlockWrtErase = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxBlockPermalock = new System.Windows.Forms.TextBox();
            this.textBoxMdidName = new System.Windows.Forms.TextBox();
            this.textBoxModelNumberName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxAc
            // 
            this.textBoxAc.Location = new System.Drawing.Point(57, 28);
            this.textBoxAc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxAc.Name = "textBoxAc";
            this.textBoxAc.ReadOnly = true;
            this.textBoxAc.Size = new System.Drawing.Size(35, 21);
            this.textBoxAc.TabIndex = 0;
            // 
            // textBoxMdidCode
            // 
            this.textBoxMdidCode.Location = new System.Drawing.Point(57, 116);
            this.textBoxMdidCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMdidCode.Name = "textBoxMdidCode";
            this.textBoxMdidCode.ReadOnly = true;
            this.textBoxMdidCode.Size = new System.Drawing.Size(36, 21);
            this.textBoxMdidCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Allocation-class identifier (AC)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tag Mask Designer ID (MDID)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "0000h";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "0009h";
            // 
            // textBoxXtid
            // 
            this.textBoxXtid.Location = new System.Drawing.Point(57, 72);
            this.textBoxXtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxXtid.Name = "textBoxXtid";
            this.textBoxXtid.ReadOnly = true;
            this.textBoxXtid.Size = new System.Drawing.Size(35, 21);
            this.textBoxXtid.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "0008h";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "XTID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "E0 for ISO/IEC 7816-6, E2 for EPCglobal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "0014h";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Tag Model Number";
            // 
            // textBoxModelNumberCode
            // 
            this.textBoxModelNumberCode.Location = new System.Drawing.Point(57, 164);
            this.textBoxModelNumberCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxModelNumberCode.Name = "textBoxModelNumberCode";
            this.textBoxModelNumberCode.ReadOnly = true;
            this.textBoxModelNumberCode.Size = new System.Drawing.Size(36, 21);
            this.textBoxModelNumberCode.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "0020h";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "XTID Header Segment";
            // 
            // textBoxXtidHeader
            // 
            this.textBoxXtidHeader.Location = new System.Drawing.Point(57, 248);
            this.textBoxXtidHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxXtidHeader.Name = "textBoxXtidHeader";
            this.textBoxXtidHeader.ReadOnly = true;
            this.textBoxXtidHeader.Size = new System.Drawing.Size(36, 21);
            this.textBoxXtidHeader.TabIndex = 17;
            // 
            // textBoxSn
            // 
            this.textBoxSn.Location = new System.Drawing.Point(57, 292);
            this.textBoxSn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSn.Name = "textBoxSn";
            this.textBoxSn.ReadOnly = true;
            this.textBoxSn.Size = new System.Drawing.Size(189, 21);
            this.textBoxSn.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "Serial Number Segment";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 295);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "0030h";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(60, 317);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(214, 15);
            this.label14.TabIndex = 23;
            this.label14.Text = "Optional Command Support Segment";
            // 
            // textBoxOptionalCmd
            // 
            this.textBoxOptionalCmd.Location = new System.Drawing.Point(57, 336);
            this.textBoxOptionalCmd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxOptionalCmd.Name = "textBoxOptionalCmd";
            this.textBoxOptionalCmd.ReadOnly = true;
            this.textBoxOptionalCmd.Size = new System.Drawing.Size(189, 21);
            this.textBoxOptionalCmd.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 339);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 15);
            this.label15.TabIndex = 25;
            this.label15.Text = "0060h";
            // 
            // textBoxBlockWrtErase
            // 
            this.textBoxBlockWrtErase.Location = new System.Drawing.Point(57, 380);
            this.textBoxBlockWrtErase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxBlockWrtErase.Name = "textBoxBlockWrtErase";
            this.textBoxBlockWrtErase.ReadOnly = true;
            this.textBoxBlockWrtErase.Size = new System.Drawing.Size(189, 21);
            this.textBoxBlockWrtErase.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(60, 361);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(208, 15);
            this.label16.TabIndex = 27;
            this.label16.Text = "BlockWrite and BlockErase Segment";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 383);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 15);
            this.label17.TabIndex = 28;
            this.label17.Text = "0070h";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 427);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 15);
            this.label18.TabIndex = 31;
            this.label18.Text = "00B0h";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(60, 405);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(253, 15);
            this.label19.TabIndex = 30;
            this.label19.Text = "User Memory and BlockPermaLock Segment";
            // 
            // textBoxBlockPermalock
            // 
            this.textBoxBlockPermalock.Location = new System.Drawing.Point(57, 424);
            this.textBoxBlockPermalock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxBlockPermalock.Name = "textBoxBlockPermalock";
            this.textBoxBlockPermalock.ReadOnly = true;
            this.textBoxBlockPermalock.Size = new System.Drawing.Size(189, 21);
            this.textBoxBlockPermalock.TabIndex = 29;
            // 
            // textBoxMdidName
            // 
            this.textBoxMdidName.Location = new System.Drawing.Point(99, 116);
            this.textBoxMdidName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMdidName.Name = "textBoxMdidName";
            this.textBoxMdidName.ReadOnly = true;
            this.textBoxMdidName.Size = new System.Drawing.Size(284, 21);
            this.textBoxMdidName.TabIndex = 32;
            // 
            // textBoxModelNumberName
            // 
            this.textBoxModelNumberName.Location = new System.Drawing.Point(99, 164);
            this.textBoxModelNumberName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxModelNumberName.Name = "textBoxModelNumberName";
            this.textBoxModelNumberName.ReadOnly = true;
            this.textBoxModelNumberName.Size = new System.Drawing.Size(284, 21);
            this.textBoxModelNumberName.TabIndex = 33;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 198);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(367, 15);
            this.label20.TabIndex = 34;
            this.label20.Text = "______ XTID = 1 ______________________________________";
            // 
            // FormTagInfoTidEpc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 463);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxModelNumberName);
            this.Controls.Add(this.textBoxMdidName);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBoxBlockPermalock);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxBlockWrtErase);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxOptionalCmd);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxSn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxXtidHeader);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxModelNumberCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxXtid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMdidCode);
            this.Controls.Add(this.textBoxAc);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTagInfoTidEpc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag Information - TID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAc;
        private System.Windows.Forms.TextBox textBoxXtid;
        private System.Windows.Forms.TextBox textBoxMdidCode;
        private System.Windows.Forms.TextBox textBoxModelNumberCode;
        private System.Windows.Forms.TextBox textBoxXtidHeader;
        private System.Windows.Forms.TextBox textBoxSn;        
        private System.Windows.Forms.TextBox textBoxOptionalCmd;        
        private System.Windows.Forms.TextBox textBoxBlockWrtErase;        
        private System.Windows.Forms.TextBox textBoxBlockPermalock;
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        
        private System.Windows.Forms.Label label15;
        
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxMdidName;
        private System.Windows.Forms.TextBox textBoxModelNumberName;
        private System.Windows.Forms.Label label20;
        
    }
}