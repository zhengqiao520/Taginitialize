namespace Phychips.PR9200
{
    partial class ucProtocol
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSel = new System.Windows.Forms.GroupBox();
            this.buttonGetSelectParam = new System.Windows.Forms.Button();
            this.tbSelLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSetSelectParam = new System.Windows.Forms.Button();
            this.comboBoxSelTruncate = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbSelMask = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.comboBoxSelMemBank = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbSelPointer = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBoxSelAction = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBoxSelTarget = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBoxQry = new System.Windows.Forms.GroupBox();
            this.buttonGetQueryParam = new System.Windows.Forms.Button();
            this.buttonSetQueryParam = new System.Windows.Forms.Button();
            this.comboBoxQryQ = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxQryTarget = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxQrySession = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxQrySel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxQryTRext = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxQryM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxQryDr = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonGetAntiCol = new System.Windows.Forms.Button();
            this.buttonSetAntiCol = new System.Windows.Forms.Button();
            this.comboBoxAntiCol = new System.Windows.Forms.ComboBox();
            this.groupBoxSession = new System.Windows.Forms.GroupBox();
            this.radioButtonSession3 = new System.Windows.Forms.RadioButton();
            this.radioButtonSession2 = new System.Windows.Forms.RadioButton();
            this.radioButtonSession1 = new System.Windows.Forms.RadioButton();
            this.radioButtonSession0 = new System.Windows.Forms.RadioButton();
            this.radioButtonSessionDev = new System.Windows.Forms.RadioButton();
            this.buttonGetSession = new System.Windows.Forms.Button();
            this.buttonSetSession = new System.Windows.Forms.Button();
            this.groupBoxSel.SuspendLayout();
            this.groupBoxQry.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxSession.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSel
            // 
            this.groupBoxSel.Controls.Add(this.buttonGetSelectParam);
            this.groupBoxSel.Controls.Add(this.tbSelLength);
            this.groupBoxSel.Controls.Add(this.label1);
            this.groupBoxSel.Controls.Add(this.buttonSetSelectParam);
            this.groupBoxSel.Controls.Add(this.comboBoxSelTruncate);
            this.groupBoxSel.Controls.Add(this.label27);
            this.groupBoxSel.Controls.Add(this.tbSelMask);
            this.groupBoxSel.Controls.Add(this.label25);
            this.groupBoxSel.Controls.Add(this.comboBoxSelMemBank);
            this.groupBoxSel.Controls.Add(this.label21);
            this.groupBoxSel.Controls.Add(this.tbSelPointer);
            this.groupBoxSel.Controls.Add(this.label20);
            this.groupBoxSel.Controls.Add(this.comboBoxSelAction);
            this.groupBoxSel.Controls.Add(this.label19);
            this.groupBoxSel.Controls.Add(this.comboBoxSelTarget);
            this.groupBoxSel.Controls.Add(this.label16);
            this.groupBoxSel.Location = new System.Drawing.Point(3, 91);
            this.groupBoxSel.Name = "groupBoxSel";
            this.groupBoxSel.Size = new System.Drawing.Size(391, 118);
            this.groupBoxSel.TabIndex = 3;
            this.groupBoxSel.TabStop = false;
            this.groupBoxSel.Text = "Select Parameters";
            // 
            // buttonGetSelectParam
            // 
            this.buttonGetSelectParam.Location = new System.Drawing.Point(245, 78);
            this.buttonGetSelectParam.Name = "buttonGetSelectParam";
            this.buttonGetSelectParam.Size = new System.Drawing.Size(63, 30);
            this.buttonGetSelectParam.TabIndex = 52;
            this.buttonGetSelectParam.Text = "Get";
            this.buttonGetSelectParam.UseVisualStyleBackColor = true;
            this.buttonGetSelectParam.Click += new System.EventHandler(this.buttonGetParam_Click);
            // 
            // tbSelLength
            // 
            this.tbSelLength.Location = new System.Drawing.Point(292, 41);
            this.tbSelLength.Name = "tbSelLength";
            this.tbSelLength.Size = new System.Drawing.Size(72, 21);
            this.tbSelLength.TabIndex = 27;
            this.tbSelLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mask(HEX)";
            // 
            // buttonSetSelectParam
            // 
            this.buttonSetSelectParam.Enabled = false;
            this.buttonSetSelectParam.Location = new System.Drawing.Point(314, 78);
            this.buttonSetSelectParam.Name = "buttonSetSelectParam";
            this.buttonSetSelectParam.Size = new System.Drawing.Size(63, 30);
            this.buttonSetSelectParam.TabIndex = 6;
            this.buttonSetSelectParam.Text = "Set";
            this.buttonSetSelectParam.UseVisualStyleBackColor = true;
            this.buttonSetSelectParam.Click += new System.EventHandler(this.buttonSetParam_Click);
            // 
            // comboBoxSelTruncate
            // 
            this.comboBoxSelTruncate.Enabled = false;
            this.comboBoxSelTruncate.FormattingEnabled = true;
            this.comboBoxSelTruncate.Location = new System.Drawing.Point(138, 83);
            this.comboBoxSelTruncate.Name = "comboBoxSelTruncate";
            this.comboBoxSelTruncate.Size = new System.Drawing.Size(78, 23);
            this.comboBoxSelTruncate.TabIndex = 25;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(135, 65);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 15);
            this.label27.TabIndex = 21;
            this.label27.Text = "Truncate";
            // 
            // tbSelMask
            // 
            this.tbSelMask.Location = new System.Drawing.Point(6, 83);
            this.tbSelMask.Name = "tbSelMask";
            this.tbSelMask.Size = new System.Drawing.Size(110, 21);
            this.tbSelMask.TabIndex = 19;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(289, 21);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 15);
            this.label25.TabIndex = 17;
            this.label25.Text = "Length(DEC)";
            // 
            // comboBoxSelMemBank
            // 
            this.comboBoxSelMemBank.FormattingEnabled = true;
            this.comboBoxSelMemBank.Location = new System.Drawing.Point(138, 39);
            this.comboBoxSelMemBank.Name = "comboBoxSelMemBank";
            this.comboBoxSelMemBank.Size = new System.Drawing.Size(58, 23);
            this.comboBoxSelMemBank.TabIndex = 11;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(199, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 15);
            this.label21.TabIndex = 10;
            this.label21.Text = "Pointer(HEX)";
            // 
            // tbSelPointer
            // 
            this.tbSelPointer.Location = new System.Drawing.Point(202, 41);
            this.tbSelPointer.Name = "tbSelPointer";
            this.tbSelPointer.Size = new System.Drawing.Size(84, 21);
            this.tbSelPointer.TabIndex = 9;
            this.tbSelPointer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(135, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 15);
            this.label20.TabIndex = 8;
            this.label20.Text = "MemBank";
            // 
            // comboBoxSelAction
            // 
            this.comboBoxSelAction.FormattingEnabled = true;
            this.comboBoxSelAction.Location = new System.Drawing.Point(74, 39);
            this.comboBoxSelAction.Name = "comboBoxSelAction";
            this.comboBoxSelAction.Size = new System.Drawing.Size(58, 23);
            this.comboBoxSelAction.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(71, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 15);
            this.label19.TabIndex = 5;
            this.label19.Text = "Action";
            // 
            // comboBoxSelTarget
            // 
            this.comboBoxSelTarget.FormattingEnabled = true;
            this.comboBoxSelTarget.Location = new System.Drawing.Point(10, 39);
            this.comboBoxSelTarget.Name = "comboBoxSelTarget";
            this.comboBoxSelTarget.Size = new System.Drawing.Size(58, 23);
            this.comboBoxSelTarget.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Target";
            // 
            // groupBoxQry
            // 
            this.groupBoxQry.Controls.Add(this.buttonGetQueryParam);
            this.groupBoxQry.Controls.Add(this.buttonSetQueryParam);
            this.groupBoxQry.Controls.Add(this.comboBoxQryQ);
            this.groupBoxQry.Controls.Add(this.label11);
            this.groupBoxQry.Controls.Add(this.comboBoxQryTarget);
            this.groupBoxQry.Controls.Add(this.label10);
            this.groupBoxQry.Controls.Add(this.comboBoxQrySession);
            this.groupBoxQry.Controls.Add(this.label9);
            this.groupBoxQry.Controls.Add(this.comboBoxQrySel);
            this.groupBoxQry.Controls.Add(this.label8);
            this.groupBoxQry.Controls.Add(this.comboBoxQryTRext);
            this.groupBoxQry.Controls.Add(this.label7);
            this.groupBoxQry.Controls.Add(this.comboBoxQryM);
            this.groupBoxQry.Controls.Add(this.label5);
            this.groupBoxQry.Controls.Add(this.comboBoxQryDr);
            this.groupBoxQry.Controls.Add(this.label3);
            this.groupBoxQry.Location = new System.Drawing.Point(3, 215);
            this.groupBoxQry.Name = "groupBoxQry";
            this.groupBoxQry.Size = new System.Drawing.Size(391, 116);
            this.groupBoxQry.TabIndex = 5;
            this.groupBoxQry.TabStop = false;
            this.groupBoxQry.Text = "Query Parameters";
            // 
            // buttonGetQueryParam
            // 
            this.buttonGetQueryParam.Location = new System.Drawing.Point(245, 76);
            this.buttonGetQueryParam.Name = "buttonGetQueryParam";
            this.buttonGetQueryParam.Size = new System.Drawing.Size(63, 30);
            this.buttonGetQueryParam.TabIndex = 53;
            this.buttonGetQueryParam.Text = "Get";
            this.buttonGetQueryParam.UseVisualStyleBackColor = true;
            this.buttonGetQueryParam.Click += new System.EventHandler(this.buttonGetQueryParam_Click);
            // 
            // buttonSetQueryParam
            // 
            this.buttonSetQueryParam.Enabled = false;
            this.buttonSetQueryParam.Location = new System.Drawing.Point(314, 76);
            this.buttonSetQueryParam.Name = "buttonSetQueryParam";
            this.buttonSetQueryParam.Size = new System.Drawing.Size(63, 30);
            this.buttonSetQueryParam.TabIndex = 53;
            this.buttonSetQueryParam.Text = "Set";
            this.buttonSetQueryParam.UseVisualStyleBackColor = true;
            this.buttonSetQueryParam.Click += new System.EventHandler(this.buttonSetQueryParam_Click);
            // 
            // comboBoxQryQ
            // 
            this.comboBoxQryQ.FormattingEnabled = true;
            this.comboBoxQryQ.Location = new System.Drawing.Point(77, 83);
            this.comboBoxQryQ.Name = "comboBoxQryQ";
            this.comboBoxQryQ.Size = new System.Drawing.Size(58, 23);
            this.comboBoxQryQ.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(74, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 15);
            this.label11.TabIndex = 40;
            this.label11.Text = "Q";
            // 
            // comboBoxQryTarget
            // 
            this.comboBoxQryTarget.FormattingEnabled = true;
            this.comboBoxQryTarget.Location = new System.Drawing.Point(10, 83);
            this.comboBoxQryTarget.Name = "comboBoxQryTarget";
            this.comboBoxQryTarget.Size = new System.Drawing.Size(58, 23);
            this.comboBoxQryTarget.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 38;
            this.label10.Text = "Target";
            // 
            // comboBoxQrySession
            // 
            this.comboBoxQrySession.FormattingEnabled = true;
            this.comboBoxQrySession.Location = new System.Drawing.Point(319, 39);
            this.comboBoxQrySession.Name = "comboBoxQrySession";
            this.comboBoxQrySession.Size = new System.Drawing.Size(58, 23);
            this.comboBoxQrySession.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 15);
            this.label9.TabIndex = 36;
            this.label9.Text = "Session";
            // 
            // comboBoxQrySel
            // 
            this.comboBoxQrySel.FormattingEnabled = true;
            this.comboBoxQrySel.Location = new System.Drawing.Point(255, 39);
            this.comboBoxQrySel.Name = "comboBoxQrySel";
            this.comboBoxQrySel.Size = new System.Drawing.Size(58, 23);
            this.comboBoxQrySel.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Sel";
            // 
            // comboBoxQryTRext
            // 
            this.comboBoxQryTRext.Enabled = false;
            this.comboBoxQryTRext.FormattingEnabled = true;
            this.comboBoxQryTRext.Location = new System.Drawing.Point(138, 39);
            this.comboBoxQryTRext.Name = "comboBoxQryTRext";
            this.comboBoxQryTRext.Size = new System.Drawing.Size(111, 23);
            this.comboBoxQryTRext.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 32;
            this.label7.Text = "TRext";
            // 
            // comboBoxQryM
            // 
            this.comboBoxQryM.Enabled = false;
            this.comboBoxQryM.FormattingEnabled = true;
            this.comboBoxQryM.Location = new System.Drawing.Point(74, 39);
            this.comboBoxQryM.Name = "comboBoxQryM";
            this.comboBoxQryM.Size = new System.Drawing.Size(58, 23);
            this.comboBoxQryM.TabIndex = 30;
            this.comboBoxQryM.SelectedIndexChanged += new System.EventHandler(this.comboBoxQryM_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "M";
            // 
            // comboBoxQryDr
            // 
            this.comboBoxQryDr.Enabled = false;
            this.comboBoxQryDr.FormattingEnabled = true;
            this.comboBoxQryDr.Location = new System.Drawing.Point(10, 39);
            this.comboBoxQryDr.Name = "comboBoxQryDr";
            this.comboBoxQryDr.Size = new System.Drawing.Size(58, 23);
            this.comboBoxQryDr.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "DR";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonGetAntiCol);
            this.groupBox2.Controls.Add(this.buttonSetAntiCol);
            this.groupBox2.Controls.Add(this.comboBoxAntiCol);
            this.groupBox2.Location = new System.Drawing.Point(3, 337);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 59);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Anti-collision";
            // 
            // buttonGetAntiCol
            // 
            this.buttonGetAntiCol.Location = new System.Drawing.Point(245, 18);
            this.buttonGetAntiCol.Name = "buttonGetAntiCol";
            this.buttonGetAntiCol.Size = new System.Drawing.Size(63, 30);
            this.buttonGetAntiCol.TabIndex = 53;
            this.buttonGetAntiCol.Text = "Get";
            this.buttonGetAntiCol.UseVisualStyleBackColor = true;
            this.buttonGetAntiCol.Click += new System.EventHandler(this.buttonGetAntiCol_Click);
            // 
            // buttonSetAntiCol
            // 
            this.buttonSetAntiCol.Enabled = false;
            this.buttonSetAntiCol.Location = new System.Drawing.Point(314, 18);
            this.buttonSetAntiCol.Name = "buttonSetAntiCol";
            this.buttonSetAntiCol.Size = new System.Drawing.Size(63, 30);
            this.buttonSetAntiCol.TabIndex = 53;
            this.buttonSetAntiCol.Text = "Set";
            this.buttonSetAntiCol.UseVisualStyleBackColor = true;
            this.buttonSetAntiCol.Click += new System.EventHandler(this.buttonSetAntiCol_Click);
            // 
            // comboBoxAntiCol
            // 
            this.comboBoxAntiCol.FormattingEnabled = true;
            this.comboBoxAntiCol.Location = new System.Drawing.Point(10, 25);
            this.comboBoxAntiCol.Name = "comboBoxAntiCol";
            this.comboBoxAntiCol.Size = new System.Drawing.Size(186, 23);
            this.comboBoxAntiCol.TabIndex = 54;
            // 
            // groupBoxSession
            // 
            this.groupBoxSession.Controls.Add(this.radioButtonSession3);
            this.groupBoxSession.Controls.Add(this.radioButtonSession2);
            this.groupBoxSession.Controls.Add(this.radioButtonSession1);
            this.groupBoxSession.Controls.Add(this.radioButtonSession0);
            this.groupBoxSession.Controls.Add(this.radioButtonSessionDev);
            this.groupBoxSession.Controls.Add(this.buttonGetSession);
            this.groupBoxSession.Controls.Add(this.buttonSetSession);
            this.groupBoxSession.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSession.Name = "groupBoxSession";
            this.groupBoxSession.Size = new System.Drawing.Size(391, 82);
            this.groupBoxSession.TabIndex = 58;
            this.groupBoxSession.TabStop = false;
            this.groupBoxSession.Text = "Session";
            // 
            // radioButtonSession3
            // 
            this.radioButtonSession3.AutoSize = true;
            this.radioButtonSession3.Location = new System.Drawing.Point(171, 45);
            this.radioButtonSession3.Name = "radioButtonSession3";
            this.radioButtonSession3.Size = new System.Drawing.Size(37, 16);
            this.radioButtonSession3.TabIndex = 53;
            this.radioButtonSession3.TabStop = true;
            this.radioButtonSession3.Text = "S3";
            this.radioButtonSession3.UseVisualStyleBackColor = true;
            this.radioButtonSession3.CheckedChanged += new System.EventHandler(this.radioButtonSession_CheckedChanged);
            // 
            // radioButtonSession2
            // 
            this.radioButtonSession2.AutoSize = true;
            this.radioButtonSession2.Location = new System.Drawing.Point(123, 45);
            this.radioButtonSession2.Name = "radioButtonSession2";
            this.radioButtonSession2.Size = new System.Drawing.Size(37, 16);
            this.radioButtonSession2.TabIndex = 53;
            this.radioButtonSession2.TabStop = true;
            this.radioButtonSession2.Text = "S2";
            this.radioButtonSession2.UseVisualStyleBackColor = true;
            this.radioButtonSession2.CheckedChanged += new System.EventHandler(this.radioButtonSession_CheckedChanged);
            // 
            // radioButtonSession1
            // 
            this.radioButtonSession1.AutoSize = true;
            this.radioButtonSession1.Location = new System.Drawing.Point(75, 45);
            this.radioButtonSession1.Name = "radioButtonSession1";
            this.radioButtonSession1.Size = new System.Drawing.Size(37, 16);
            this.radioButtonSession1.TabIndex = 53;
            this.radioButtonSession1.TabStop = true;
            this.radioButtonSession1.Text = "S1";
            this.radioButtonSession1.UseVisualStyleBackColor = true;
            this.radioButtonSession1.CheckedChanged += new System.EventHandler(this.radioButtonSession_CheckedChanged);
            // 
            // radioButtonSession0
            // 
            this.radioButtonSession0.AutoSize = true;
            this.radioButtonSession0.Location = new System.Drawing.Point(27, 45);
            this.radioButtonSession0.Name = "radioButtonSession0";
            this.radioButtonSession0.Size = new System.Drawing.Size(37, 16);
            this.radioButtonSession0.TabIndex = 53;
            this.radioButtonSession0.TabStop = true;
            this.radioButtonSession0.Text = "S0";
            this.radioButtonSession0.UseVisualStyleBackColor = true;
            this.radioButtonSession0.CheckedChanged += new System.EventHandler(this.radioButtonSession_CheckedChanged);
            // 
            // radioButtonSessionDev
            // 
            this.radioButtonSessionDev.AutoSize = true;
            this.radioButtonSessionDev.Location = new System.Drawing.Point(27, 20);
            this.radioButtonSessionDev.Name = "radioButtonSessionDev";
            this.radioButtonSessionDev.Size = new System.Drawing.Size(84, 16);
            this.radioButtonSessionDev.TabIndex = 53;
            this.radioButtonSessionDev.TabStop = true;
            this.radioButtonSessionDev.Text = "Dev. mode";
            this.radioButtonSessionDev.UseVisualStyleBackColor = true;
            this.radioButtonSessionDev.CheckedChanged += new System.EventHandler(this.radioButtonSession_CheckedChanged);
            // 
            // buttonGetSession
            // 
            this.buttonGetSession.Location = new System.Drawing.Point(245, 39);
            this.buttonGetSession.Name = "buttonGetSession";
            this.buttonGetSession.Size = new System.Drawing.Size(63, 30);
            this.buttonGetSession.TabIndex = 52;
            this.buttonGetSession.Text = "Get";
            this.buttonGetSession.UseVisualStyleBackColor = true;
            this.buttonGetSession.Click += new System.EventHandler(this.buttonGetSession_Click);
            // 
            // buttonSetSession
            // 
            this.buttonSetSession.Enabled = false;
            this.buttonSetSession.Location = new System.Drawing.Point(314, 39);
            this.buttonSetSession.Name = "buttonSetSession";
            this.buttonSetSession.Size = new System.Drawing.Size(63, 30);
            this.buttonSetSession.TabIndex = 6;
            this.buttonSetSession.Text = "Set";
            this.buttonSetSession.UseVisualStyleBackColor = true;
            this.buttonSetSession.Click += new System.EventHandler(this.buttonSetSession_Click);
            // 
            // ucProtocol
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxSession);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxQry);
            this.Controls.Add(this.groupBoxSel);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucProtocol";
            this.Size = new System.Drawing.Size(404, 406);
            this.Load += new System.EventHandler(this.UcTabAirInterface_Load);
            this.groupBoxSel.ResumeLayout(false);
            this.groupBoxSel.PerformLayout();
            this.groupBoxQry.ResumeLayout(false);
            this.groupBoxQry.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxSession.ResumeLayout(false);
            this.groupBoxSession.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSel;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbSelMask;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox comboBoxSelMemBank;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbSelPointer;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBoxSelAction;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBoxSelTarget;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSelLength;
        private System.Windows.Forms.GroupBox groupBoxQry;
        private System.Windows.Forms.ComboBox comboBoxQryM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxQryDr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxQrySel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxQryTRext;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxQryQ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxQryTarget;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxQrySession;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonSetSelectParam;
        private System.Windows.Forms.Button buttonGetSelectParam;
        private System.Windows.Forms.Button buttonSetQueryParam;
        private System.Windows.Forms.Button buttonGetQueryParam;
        private System.Windows.Forms.ComboBox comboBoxSelTruncate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonGetAntiCol;
        private System.Windows.Forms.Button buttonSetAntiCol;
        private System.Windows.Forms.ComboBox comboBoxAntiCol;
        private System.Windows.Forms.GroupBox groupBoxSession;
        private System.Windows.Forms.RadioButton radioButtonSession3;
        private System.Windows.Forms.RadioButton radioButtonSession2;
        private System.Windows.Forms.RadioButton radioButtonSession1;
        private System.Windows.Forms.RadioButton radioButtonSession0;
        private System.Windows.Forms.RadioButton radioButtonSessionDev;
        private System.Windows.Forms.Button buttonGetSession;
        private System.Windows.Forms.Button buttonSetSession;

    }
}
