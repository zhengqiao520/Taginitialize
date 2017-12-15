namespace RFIDStation
{
    partial class uartDebug
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
            this.Hex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EnableTx = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxTimerout = new System.Windows.Forms.TextBox();
            this.checkBoxEmptyFrame = new System.Windows.Forms.CheckBox();
            this.Frame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxClcSend = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxInf = new System.Windows.Forms.TextBox();
            this.buttonClearInf = new System.Windows.Forms.Button();
            this.Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Send = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewFrames = new System.Windows.Forms.DataGridView();
            this.textBoxParm = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxCrc = new System.Windows.Forms.TextBox();
            this.textBoxRfu = new System.Windows.Forms.TextBox();
            this.textBoxCmd = new System.Windows.Forms.TextBox();
            this.comboBoxCtrlCode = new System.Windows.Forms.ComboBox();
            this.textBoxDestAddr = new System.Windows.Forms.TextBox();
            this.textBoxSrcAddr = new System.Windows.Forms.TextBox();
            this.textBoxLen = new System.Windows.Forms.TextBox();
            this.textBoxHeader = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // Hex
            // 
            this.Hex.HeaderText = "Hex";
            this.Hex.Name = "Hex";
            // 
            // EnableTx
            // 
            this.EnableTx.HeaderText = "使能";
            this.EnableTx.Name = "EnableTx";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(606, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 167;
            this.label10.Text = "间隔时间";
            // 
            // textBoxTimerout
            // 
            this.textBoxTimerout.Location = new System.Drawing.Point(662, 287);
            this.textBoxTimerout.Name = "textBoxTimerout";
            this.textBoxTimerout.Size = new System.Drawing.Size(56, 21);
            this.textBoxTimerout.TabIndex = 166;
            this.textBoxTimerout.Text = "1000";
            // 
            // checkBoxEmptyFrame
            // 
            this.checkBoxEmptyFrame.AutoSize = true;
            this.checkBoxEmptyFrame.Location = new System.Drawing.Point(726, 25);
            this.checkBoxEmptyFrame.Name = "checkBoxEmptyFrame";
            this.checkBoxEmptyFrame.Size = new System.Drawing.Size(48, 16);
            this.checkBoxEmptyFrame.TabIndex = 165;
            this.checkBoxEmptyFrame.Text = "空帧";
            this.checkBoxEmptyFrame.UseVisualStyleBackColor = true;
            // 
            // Frame
            // 
            this.Frame.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Frame.HeaderText = "Frame";
            this.Frame.Name = "Frame";
            this.Frame.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // checkBoxClcSend
            // 
            this.checkBoxClcSend.AutoSize = true;
            this.checkBoxClcSend.Location = new System.Drawing.Point(525, 291);
            this.checkBoxClcSend.Name = "checkBoxClcSend";
            this.checkBoxClcSend.Size = new System.Drawing.Size(72, 16);
            this.checkBoxClcSend.TabIndex = 164;
            this.checkBoxClcSend.Text = "循环发送";
            this.checkBoxClcSend.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxInf);
            this.groupBox3.Location = new System.Drawing.Point(7, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(816, 227);
            this.groupBox3.TabIndex = 163;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输出";
            // 
            // textBoxInf
            // 
            this.textBoxInf.Location = new System.Drawing.Point(8, 15);
            this.textBoxInf.Multiline = true;
            this.textBoxInf.Name = "textBoxInf";
            this.textBoxInf.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInf.Size = new System.Drawing.Size(802, 206);
            this.textBoxInf.TabIndex = 5;
            // 
            // buttonClearInf
            // 
            this.buttonClearInf.Location = new System.Drawing.Point(734, 285);
            this.buttonClearInf.Name = "buttonClearInf";
            this.buttonClearInf.Size = new System.Drawing.Size(89, 23);
            this.buttonClearInf.TabIndex = 162;
            this.buttonClearInf.Text = "清空信息输出";
            this.buttonClearInf.UseVisualStyleBackColor = true;
            // 
            // Delay
            // 
            this.Delay.HeaderText = "延时";
            this.Delay.Name = "Delay";
            this.Delay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Send
            // 
            this.Send.HeaderText = "发送";
            this.Send.Name = "Send";
            // 
            // dataGridViewFrames
            // 
            this.dataGridViewFrames.AllowUserToAddRows = false;
            this.dataGridViewFrames.AllowUserToResizeColumns = false;
            this.dataGridViewFrames.AllowUserToResizeRows = false;
            this.dataGridViewFrames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewFrames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnableTx,
            this.Hex,
            this.Frame,
            this.Delay,
            this.Send});
            this.dataGridViewFrames.Location = new System.Drawing.Point(7, 51);
            this.dataGridViewFrames.MultiSelect = false;
            this.dataGridViewFrames.Name = "dataGridViewFrames";
            this.dataGridViewFrames.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewFrames.RowTemplate.Height = 23;
            this.dataGridViewFrames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewFrames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFrames.Size = new System.Drawing.Size(816, 228);
            this.dataGridViewFrames.TabIndex = 160;
            // 
            // textBoxParm
            // 
            this.textBoxParm.Location = new System.Drawing.Point(295, 23);
            this.textBoxParm.Name = "textBoxParm";
            this.textBoxParm.Size = new System.Drawing.Size(380, 21);
            this.textBoxParm.TabIndex = 159;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(773, 21);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(50, 23);
            this.buttonOk.TabIndex = 161;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxCrc
            // 
            this.textBoxCrc.Location = new System.Drawing.Point(681, 23);
            this.textBoxCrc.Name = "textBoxCrc";
            this.textBoxCrc.ReadOnly = true;
            this.textBoxCrc.Size = new System.Drawing.Size(37, 21);
            this.textBoxCrc.TabIndex = 158;
            this.textBoxCrc.Text = "FF FF";
            // 
            // textBoxRfu
            // 
            this.textBoxRfu.Location = new System.Drawing.Point(266, 23);
            this.textBoxRfu.Name = "textBoxRfu";
            this.textBoxRfu.ReadOnly = true;
            this.textBoxRfu.Size = new System.Drawing.Size(23, 21);
            this.textBoxRfu.TabIndex = 157;
            this.textBoxRfu.Text = "00";
            // 
            // textBoxCmd
            // 
            this.textBoxCmd.Location = new System.Drawing.Point(237, 23);
            this.textBoxCmd.MaxLength = 2;
            this.textBoxCmd.Name = "textBoxCmd";
            this.textBoxCmd.Size = new System.Drawing.Size(23, 21);
            this.textBoxCmd.TabIndex = 156;
            this.textBoxCmd.Text = "00";
            // 
            // comboBoxCtrlCode
            // 
            this.comboBoxCtrlCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCtrlCode.FormattingEnabled = true;
            this.comboBoxCtrlCode.Items.AddRange(new object[] {
            "请求帧",
            "响应帧"});
            this.comboBoxCtrlCode.Location = new System.Drawing.Point(175, 24);
            this.comboBoxCtrlCode.Name = "comboBoxCtrlCode";
            this.comboBoxCtrlCode.Size = new System.Drawing.Size(56, 20);
            this.comboBoxCtrlCode.TabIndex = 155;
            // 
            // textBoxDestAddr
            // 
            this.textBoxDestAddr.Location = new System.Drawing.Point(121, 23);
            this.textBoxDestAddr.MaxLength = 5;
            this.textBoxDestAddr.Name = "textBoxDestAddr";
            this.textBoxDestAddr.Size = new System.Drawing.Size(48, 21);
            this.textBoxDestAddr.TabIndex = 154;
            this.textBoxDestAddr.Text = "01 00";
            // 
            // textBoxSrcAddr
            // 
            this.textBoxSrcAddr.Location = new System.Drawing.Point(78, 23);
            this.textBoxSrcAddr.MaxLength = 5;
            this.textBoxSrcAddr.Name = "textBoxSrcAddr";
            this.textBoxSrcAddr.Size = new System.Drawing.Size(37, 21);
            this.textBoxSrcAddr.TabIndex = 153;
            this.textBoxSrcAddr.Text = "00 00";
            // 
            // textBoxLen
            // 
            this.textBoxLen.Location = new System.Drawing.Point(49, 23);
            this.textBoxLen.Name = "textBoxLen";
            this.textBoxLen.ReadOnly = true;
            this.textBoxLen.Size = new System.Drawing.Size(23, 21);
            this.textBoxLen.TabIndex = 152;
            this.textBoxLen.Text = "08";
            // 
            // textBoxHeader
            // 
            this.textBoxHeader.Location = new System.Drawing.Point(7, 23);
            this.textBoxHeader.Name = "textBoxHeader";
            this.textBoxHeader.ReadOnly = true;
            this.textBoxHeader.Size = new System.Drawing.Size(36, 21);
            this.textBoxHeader.TabIndex = 151;
            this.textBoxHeader.Text = "7E 55";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(292, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 150;
            this.label9.Text = "参数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(678, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 149;
            this.label8.Text = "CRC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(263, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 148;
            this.label7.Text = "保留";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(234, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 147;
            this.label6.Text = "命令";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(172, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 146;
            this.label5.Text = "控制码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(117, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 145;
            this.label4.Text = "目标地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(75, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 144;
            this.label3.Text = "源地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(45, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 143;
            this.label2.Text = "长度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 142;
            this.label1.Text = "帧头";
            // 
            // uartDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 544);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxTimerout);
            this.Controls.Add(this.checkBoxEmptyFrame);
            this.Controls.Add(this.checkBoxClcSend);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonClearInf);
            this.Controls.Add(this.dataGridViewFrames);
            this.Controls.Add(this.textBoxParm);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxCrc);
            this.Controls.Add(this.textBoxRfu);
            this.Controls.Add(this.textBoxCmd);
            this.Controls.Add(this.comboBoxCtrlCode);
            this.Controls.Add(this.textBoxDestAddr);
            this.Controls.Add(this.textBoxSrcAddr);
            this.Controls.Add(this.textBoxLen);
            this.Controls.Add(this.textBoxHeader);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "uartDebug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uartDebug";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.uartDebug_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFrames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewCheckBoxColumn Hex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnableTx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxTimerout;
        private System.Windows.Forms.CheckBox checkBoxEmptyFrame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frame;
        private System.Windows.Forms.CheckBox checkBoxClcSend;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxInf;
        private System.Windows.Forms.Button buttonClearInf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
        private System.Windows.Forms.DataGridViewButtonColumn Send;
        private System.Windows.Forms.DataGridView dataGridViewFrames;
        private System.Windows.Forms.TextBox textBoxParm;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxCrc;
        private System.Windows.Forms.TextBox textBoxRfu;
        private System.Windows.Forms.TextBox textBoxCmd;
        private System.Windows.Forms.ComboBox comboBoxCtrlCode;
        private System.Windows.Forms.TextBox textBoxDestAddr;
        private System.Windows.Forms.TextBox textBoxSrcAddr;
        private System.Windows.Forms.TextBox textBoxLen;
        private System.Windows.Forms.TextBox textBoxHeader;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}