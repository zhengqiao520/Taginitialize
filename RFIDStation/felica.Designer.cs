namespace RFIDStation
{
    partial class felica
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonOpFelicaErrTypeParam = new System.Windows.Forms.RadioButton();
            this.radioButtonOpFelicaErrTypeRsp = new System.Windows.Forms.RadioButton();
            this.radioButtonOpFelicaErrTypeTag = new System.Windows.Forms.RadioButton();
            this.radioButtonOpFelicaErrTypeOK = new System.Windows.Forms.RadioButton();
            this.radioButtonOpFelicaErrTypeCrc = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButtonOpFelicaTagRltOpFail = new System.Windows.Forms.RadioButton();
            this.radioButtonOpFelicaTagRltOpOK = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.buttonClearOpFelicaTag = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.textBoxOpFelicaTagRltDestAddr = new System.Windows.Forms.TextBox();
            this.textBoxOpFelicaTagRltSrcAddr = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClearFelicaInfo = new System.Windows.Forms.Button();
            this.textBoxFelicaInf = new System.Windows.Forms.TextBox();
            this.tabControlFelicaTagOp = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxGetUid = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.radioButtonRequestTagIdle = new System.Windows.Forms.RadioButton();
            this.radioButtonRequestTagAll = new System.Windows.Forms.RadioButton();
            this.textBoxRemainTagNum = new System.Windows.Forms.TextBox();
            this.textBoxReadTagNum = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonClearFelicaListBox = new System.Windows.Forms.Button();
            this.buttonReadFelicaTags = new System.Windows.Forms.Button();
            this.listBoxTagInfo = new System.Windows.Forms.ListBox();
            this.groupBoxTagIn = new System.Windows.Forms.GroupBox();
            this.textBoxFelicaTagInNum = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonClearFelicaInTag = new System.Windows.Forms.Button();
            this.listBoxTagInfoIn = new System.Windows.Forms.ListBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.textBoxDtuRxLen = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.textBoxDtuTime = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.buttonDtuRxClear = new System.Windows.Forms.Button();
            this.buttonDtuTxClear = new System.Windows.Forms.Button();
            this.textBoxDtuRx = new System.Windows.Forms.TextBox();
            this.textBoxDtuTx = new System.Windows.Forms.TextBox();
            this.buttonDtu = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.checkBoxUidEnable = new System.Windows.Forms.CheckBox();
            this.textBoxSelectedFelicaUid = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBoxFelicaDestAddr = new System.Windows.Forms.TextBox();
            this.textBoxFelicaSrcAddr = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControlFelicaTagOp.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxGetUid.SuspendLayout();
            this.panel13.SuspendLayout();
            this.groupBoxTagIn.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.buttonClearOpFelicaTag);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.textBoxOpFelicaTagRltDestAddr);
            this.groupBox3.Controls.Add(this.textBoxOpFelicaTagRltSrcAddr);
            this.groupBox3.Location = new System.Drawing.Point(0, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 62);
            this.groupBox3.TabIndex = 135;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "返回结果";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButtonOpFelicaErrTypeParam);
            this.panel3.Controls.Add(this.radioButtonOpFelicaErrTypeRsp);
            this.panel3.Controls.Add(this.radioButtonOpFelicaErrTypeTag);
            this.panel3.Controls.Add(this.radioButtonOpFelicaErrTypeOK);
            this.panel3.Controls.Add(this.radioButtonOpFelicaErrTypeCrc);
            this.panel3.Location = new System.Drawing.Point(73, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(420, 24);
            this.panel3.TabIndex = 121;
            // 
            // radioButtonOpFelicaErrTypeParam
            // 
            this.radioButtonOpFelicaErrTypeParam.AutoSize = true;
            this.radioButtonOpFelicaErrTypeParam.Location = new System.Drawing.Point(342, 5);
            this.radioButtonOpFelicaErrTypeParam.Name = "radioButtonOpFelicaErrTypeParam";
            this.radioButtonOpFelicaErrTypeParam.Size = new System.Drawing.Size(71, 16);
            this.radioButtonOpFelicaErrTypeParam.TabIndex = 18;
            this.radioButtonOpFelicaErrTypeParam.Text = "参数错误";
            this.radioButtonOpFelicaErrTypeParam.UseVisualStyleBackColor = true;
            // 
            // radioButtonOpFelicaErrTypeRsp
            // 
            this.radioButtonOpFelicaErrTypeRsp.AutoSize = true;
            this.radioButtonOpFelicaErrTypeRsp.Location = new System.Drawing.Point(158, 5);
            this.radioButtonOpFelicaErrTypeRsp.Name = "radioButtonOpFelicaErrTypeRsp";
            this.radioButtonOpFelicaErrTypeRsp.Size = new System.Drawing.Size(83, 16);
            this.radioButtonOpFelicaErrTypeRsp.TabIndex = 17;
            this.radioButtonOpFelicaErrTypeRsp.Text = "标签无响应";
            this.radioButtonOpFelicaErrTypeRsp.UseVisualStyleBackColor = true;
            // 
            // radioButtonOpFelicaErrTypeTag
            // 
            this.radioButtonOpFelicaErrTypeTag.AutoSize = true;
            this.radioButtonOpFelicaErrTypeTag.Location = new System.Drawing.Point(256, 5);
            this.radioButtonOpFelicaErrTypeTag.Name = "radioButtonOpFelicaErrTypeTag";
            this.radioButtonOpFelicaErrTypeTag.Size = new System.Drawing.Size(71, 16);
            this.radioButtonOpFelicaErrTypeTag.TabIndex = 16;
            this.radioButtonOpFelicaErrTypeTag.Text = "标签错误";
            this.radioButtonOpFelicaErrTypeTag.UseVisualStyleBackColor = true;
            // 
            // radioButtonOpFelicaErrTypeOK
            // 
            this.radioButtonOpFelicaErrTypeOK.AutoSize = true;
            this.radioButtonOpFelicaErrTypeOK.Location = new System.Drawing.Point(4, 5);
            this.radioButtonOpFelicaErrTypeOK.Name = "radioButtonOpFelicaErrTypeOK";
            this.radioButtonOpFelicaErrTypeOK.Size = new System.Drawing.Size(59, 16);
            this.radioButtonOpFelicaErrTypeOK.TabIndex = 14;
            this.radioButtonOpFelicaErrTypeOK.Text = "无错误";
            this.radioButtonOpFelicaErrTypeOK.UseVisualStyleBackColor = true;
            // 
            // radioButtonOpFelicaErrTypeCrc
            // 
            this.radioButtonOpFelicaErrTypeCrc.AutoSize = true;
            this.radioButtonOpFelicaErrTypeCrc.Location = new System.Drawing.Point(78, 5);
            this.radioButtonOpFelicaErrTypeCrc.Name = "radioButtonOpFelicaErrTypeCrc";
            this.radioButtonOpFelicaErrTypeCrc.Size = new System.Drawing.Size(65, 16);
            this.radioButtonOpFelicaErrTypeCrc.TabIndex = 15;
            this.radioButtonOpFelicaErrTypeCrc.Text = "CRC错误";
            this.radioButtonOpFelicaErrTypeCrc.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radioButtonOpFelicaTagRltOpFail);
            this.panel4.Controls.Add(this.radioButtonOpFelicaTagRltOpOK);
            this.panel4.Location = new System.Drawing.Point(322, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(108, 24);
            this.panel4.TabIndex = 121;
            // 
            // radioButtonOpFelicaTagRltOpFail
            // 
            this.radioButtonOpFelicaTagRltOpFail.AutoSize = true;
            this.radioButtonOpFelicaTagRltOpFail.Location = new System.Drawing.Point(57, 4);
            this.radioButtonOpFelicaTagRltOpFail.Name = "radioButtonOpFelicaTagRltOpFail";
            this.radioButtonOpFelicaTagRltOpFail.Size = new System.Drawing.Size(47, 16);
            this.radioButtonOpFelicaTagRltOpFail.TabIndex = 17;
            this.radioButtonOpFelicaTagRltOpFail.Text = "失败";
            this.radioButtonOpFelicaTagRltOpFail.UseVisualStyleBackColor = true;
            // 
            // radioButtonOpFelicaTagRltOpOK
            // 
            this.radioButtonOpFelicaTagRltOpOK.AutoSize = true;
            this.radioButtonOpFelicaTagRltOpOK.Location = new System.Drawing.Point(4, 4);
            this.radioButtonOpFelicaTagRltOpOK.Name = "radioButtonOpFelicaTagRltOpOK";
            this.radioButtonOpFelicaTagRltOpOK.Size = new System.Drawing.Size(47, 16);
            this.radioButtonOpFelicaTagRltOpOK.TabIndex = 16;
            this.radioButtonOpFelicaTagRltOpOK.Text = "成功";
            this.radioButtonOpFelicaTagRltOpOK.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 42);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 21;
            this.label27.Text = "错误类型：";
            // 
            // buttonClearOpFelicaTag
            // 
            this.buttonClearOpFelicaTag.Location = new System.Drawing.Point(442, 11);
            this.buttonClearOpFelicaTag.Name = "buttonClearOpFelicaTag";
            this.buttonClearOpFelicaTag.Size = new System.Drawing.Size(51, 23);
            this.buttonClearOpFelicaTag.TabIndex = 20;
            this.buttonClearOpFelicaTag.Text = "重置";
            this.buttonClearOpFelicaTag.UseVisualStyleBackColor = true;
            this.buttonClearOpFelicaTag.Click += new System.EventHandler(this.buttonClearOpFelicaTag_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(278, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 12);
            this.label28.TabIndex = 19;
            this.label28.Text = "标志：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 16);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 12);
            this.label29.TabIndex = 18;
            this.label29.Text = "地址：";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(151, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 12);
            this.label32.TabIndex = 9;
            this.label32.Text = "目标地址";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(49, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 12);
            this.label33.TabIndex = 8;
            this.label33.Text = "源地址";
            // 
            // textBoxOpFelicaTagRltDestAddr
            // 
            this.textBoxOpFelicaTagRltDestAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxOpFelicaTagRltDestAddr.Location = new System.Drawing.Point(204, 12);
            this.textBoxOpFelicaTagRltDestAddr.MaxLength = 4;
            this.textBoxOpFelicaTagRltDestAddr.Name = "textBoxOpFelicaTagRltDestAddr";
            this.textBoxOpFelicaTagRltDestAddr.Size = new System.Drawing.Size(41, 21);
            this.textBoxOpFelicaTagRltDestAddr.TabIndex = 11;
            // 
            // textBoxOpFelicaTagRltSrcAddr
            // 
            this.textBoxOpFelicaTagRltSrcAddr.AcceptsTab = true;
            this.textBoxOpFelicaTagRltSrcAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxOpFelicaTagRltSrcAddr.Location = new System.Drawing.Point(90, 12);
            this.textBoxOpFelicaTagRltSrcAddr.MaxLength = 4;
            this.textBoxOpFelicaTagRltSrcAddr.Name = "textBoxOpFelicaTagRltSrcAddr";
            this.textBoxOpFelicaTagRltSrcAddr.Size = new System.Drawing.Size(41, 21);
            this.textBoxOpFelicaTagRltSrcAddr.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonClearFelicaInfo);
            this.groupBox2.Controls.Add(this.textBoxFelicaInf);
            this.groupBox2.Location = new System.Drawing.Point(0, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 196);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出";
            // 
            // buttonClearFelicaInfo
            // 
            this.buttonClearFelicaInfo.Location = new System.Drawing.Point(418, 9);
            this.buttonClearFelicaInfo.Name = "buttonClearFelicaInfo";
            this.buttonClearFelicaInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonClearFelicaInfo.TabIndex = 9;
            this.buttonClearFelicaInfo.Text = "清空";
            this.buttonClearFelicaInfo.UseVisualStyleBackColor = true;
            this.buttonClearFelicaInfo.Click += new System.EventHandler(this.buttonClearFelicaInfo_Click);
            // 
            // textBoxFelicaInf
            // 
            this.textBoxFelicaInf.Location = new System.Drawing.Point(4, 33);
            this.textBoxFelicaInf.Multiline = true;
            this.textBoxFelicaInf.Name = "textBoxFelicaInf";
            this.textBoxFelicaInf.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFelicaInf.Size = new System.Drawing.Size(489, 157);
            this.textBoxFelicaInf.TabIndex = 7;
            // 
            // tabControlFelicaTagOp
            // 
            this.tabControlFelicaTagOp.Controls.Add(this.tabPage1);
            this.tabControlFelicaTagOp.Controls.Add(this.tabPage8);
            this.tabControlFelicaTagOp.Location = new System.Drawing.Point(5, 46);
            this.tabControlFelicaTagOp.Name = "tabControlFelicaTagOp";
            this.tabControlFelicaTagOp.SelectedIndex = 0;
            this.tabControlFelicaTagOp.Size = new System.Drawing.Size(499, 257);
            this.tabControlFelicaTagOp.TabIndex = 133;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxGetUid);
            this.tabPage1.Controls.Add(this.groupBoxTagIn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(491, 231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "信息输出";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxGetUid
            // 
            this.groupBoxGetUid.Controls.Add(this.label15);
            this.groupBoxGetUid.Controls.Add(this.panel13);
            this.groupBoxGetUid.Controls.Add(this.textBoxRemainTagNum);
            this.groupBoxGetUid.Controls.Add(this.textBoxReadTagNum);
            this.groupBoxGetUid.Controls.Add(this.label14);
            this.groupBoxGetUid.Controls.Add(this.label13);
            this.groupBoxGetUid.Controls.Add(this.buttonClearFelicaListBox);
            this.groupBoxGetUid.Controls.Add(this.buttonReadFelicaTags);
            this.groupBoxGetUid.Controls.Add(this.listBoxTagInfo);
            this.groupBoxGetUid.Location = new System.Drawing.Point(259, 3);
            this.groupBoxGetUid.Name = "groupBoxGetUid";
            this.groupBoxGetUid.Size = new System.Drawing.Size(214, 229);
            this.groupBoxGetUid.TabIndex = 117;
            this.groupBoxGetUid.TabStop = false;
            this.groupBoxGetUid.Text = "查询场内标签";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 114;
            this.label15.Text = "模式";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.radioButtonRequestTagIdle);
            this.panel13.Controls.Add(this.radioButtonRequestTagAll);
            this.panel13.Location = new System.Drawing.Point(37, 128);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(171, 26);
            this.panel13.TabIndex = 104;
            // 
            // panel14
            // 
            this.panel14.Location = new System.Drawing.Point(0, 25);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(225, 26);
            this.panel14.TabIndex = 103;
            // 
            // radioButtonRequestTagIdle
            // 
            this.radioButtonRequestTagIdle.AutoSize = true;
            this.radioButtonRequestTagIdle.Checked = true;
            this.radioButtonRequestTagIdle.Location = new System.Drawing.Point(3, 6);
            this.radioButtonRequestTagIdle.Name = "radioButtonRequestTagIdle";
            this.radioButtonRequestTagIdle.Size = new System.Drawing.Size(47, 16);
            this.radioButtonRequestTagIdle.TabIndex = 22;
            this.radioButtonRequestTagIdle.TabStop = true;
            this.radioButtonRequestTagIdle.Text = "正常";
            this.radioButtonRequestTagIdle.UseVisualStyleBackColor = true;
            // 
            // radioButtonRequestTagAll
            // 
            this.radioButtonRequestTagAll.AutoSize = true;
            this.radioButtonRequestTagAll.Location = new System.Drawing.Point(107, 6);
            this.radioButtonRequestTagAll.Name = "radioButtonRequestTagAll";
            this.radioButtonRequestTagAll.Size = new System.Drawing.Size(47, 16);
            this.radioButtonRequestTagAll.TabIndex = 23;
            this.radioButtonRequestTagAll.Text = "重复";
            this.radioButtonRequestTagAll.UseVisualStyleBackColor = true;
            // 
            // textBoxRemainTagNum
            // 
            this.textBoxRemainTagNum.Location = new System.Drawing.Point(56, 178);
            this.textBoxRemainTagNum.MaxLength = 2;
            this.textBoxRemainTagNum.Name = "textBoxRemainTagNum";
            this.textBoxRemainTagNum.Size = new System.Drawing.Size(152, 21);
            this.textBoxRemainTagNum.TabIndex = 113;
            // 
            // textBoxReadTagNum
            // 
            this.textBoxReadTagNum.Location = new System.Drawing.Point(56, 156);
            this.textBoxReadTagNum.MaxLength = 2;
            this.textBoxReadTagNum.Name = "textBoxReadTagNum";
            this.textBoxReadTagNum.Size = new System.Drawing.Size(152, 21);
            this.textBoxReadTagNum.TabIndex = 112;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 107;
            this.label14.Text = "剩余数目";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 106;
            this.label13.Text = "读取数目";
            // 
            // buttonClearFelicaListBox
            // 
            this.buttonClearFelicaListBox.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClearFelicaListBox.Location = new System.Drawing.Point(110, 201);
            this.buttonClearFelicaListBox.Name = "buttonClearFelicaListBox";
            this.buttonClearFelicaListBox.Size = new System.Drawing.Size(96, 23);
            this.buttonClearFelicaListBox.TabIndex = 3;
            this.buttonClearFelicaListBox.Text = "清空";
            this.buttonClearFelicaListBox.UseVisualStyleBackColor = true;
            this.buttonClearFelicaListBox.Click += new System.EventHandler(this.buttonClearFelicaListBox_Click);
            // 
            // buttonReadFelicaTags
            // 
            this.buttonReadFelicaTags.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonReadFelicaTags.Location = new System.Drawing.Point(8, 201);
            this.buttonReadFelicaTags.Name = "buttonReadFelicaTags";
            this.buttonReadFelicaTags.Size = new System.Drawing.Size(96, 23);
            this.buttonReadFelicaTags.TabIndex = 2;
            this.buttonReadFelicaTags.Text = "读取";
            this.buttonReadFelicaTags.UseVisualStyleBackColor = true;
            this.buttonReadFelicaTags.Click += new System.EventHandler(this.buttonReadFelicaTags_Click);
            // 
            // listBoxTagInfo
            // 
            this.listBoxTagInfo.FormattingEnabled = true;
            this.listBoxTagInfo.HorizontalScrollbar = true;
            this.listBoxTagInfo.ItemHeight = 12;
            this.listBoxTagInfo.Location = new System.Drawing.Point(6, 15);
            this.listBoxTagInfo.Name = "listBoxTagInfo";
            this.listBoxTagInfo.ScrollAlwaysVisible = true;
            this.listBoxTagInfo.Size = new System.Drawing.Size(202, 112);
            this.listBoxTagInfo.TabIndex = 1;
            this.listBoxTagInfo.SelectedIndexChanged += new System.EventHandler(this.listBoxTagInfo_SelectedIndexChanged);
            // 
            // groupBoxTagIn
            // 
            this.groupBoxTagIn.Controls.Add(this.textBoxFelicaTagInNum);
            this.groupBoxTagIn.Controls.Add(this.label16);
            this.groupBoxTagIn.Controls.Add(this.buttonClearFelicaInTag);
            this.groupBoxTagIn.Controls.Add(this.listBoxTagInfoIn);
            this.groupBoxTagIn.Location = new System.Drawing.Point(20, 3);
            this.groupBoxTagIn.Name = "groupBoxTagIn";
            this.groupBoxTagIn.Size = new System.Drawing.Size(214, 228);
            this.groupBoxTagIn.TabIndex = 116;
            this.groupBoxTagIn.TabStop = false;
            this.groupBoxTagIn.Text = "标签进入场";
            // 
            // textBoxFelicaTagInNum
            // 
            this.textBoxFelicaTagInNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxFelicaTagInNum.Location = new System.Drawing.Point(38, 202);
            this.textBoxFelicaTagInNum.MaxLength = 2;
            this.textBoxFelicaTagInNum.Name = "textBoxFelicaTagInNum";
            this.textBoxFelicaTagInNum.Size = new System.Drawing.Size(99, 21);
            this.textBoxFelicaTagInNum.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 207);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 119;
            this.label16.Text = "数目";
            // 
            // buttonClearFelicaInTag
            // 
            this.buttonClearFelicaInTag.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClearFelicaInTag.Location = new System.Drawing.Point(143, 201);
            this.buttonClearFelicaInTag.Name = "buttonClearFelicaInTag";
            this.buttonClearFelicaInTag.Size = new System.Drawing.Size(65, 23);
            this.buttonClearFelicaInTag.TabIndex = 115;
            this.buttonClearFelicaInTag.Text = "清空";
            this.buttonClearFelicaInTag.UseVisualStyleBackColor = true;
            this.buttonClearFelicaInTag.Click += new System.EventHandler(this.buttonClearFelicaInTag_Click);
            // 
            // listBoxTagInfoIn
            // 
            this.listBoxTagInfoIn.FormattingEnabled = true;
            this.listBoxTagInfoIn.ItemHeight = 12;
            this.listBoxTagInfoIn.Location = new System.Drawing.Point(6, 13);
            this.listBoxTagInfoIn.Name = "listBoxTagInfoIn";
            this.listBoxTagInfoIn.ScrollAlwaysVisible = true;
            this.listBoxTagInfoIn.Size = new System.Drawing.Size(202, 184);
            this.listBoxTagInfoIn.TabIndex = 1;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.textBoxDtuRxLen);
            this.tabPage8.Controls.Add(this.label56);
            this.tabPage8.Controls.Add(this.label57);
            this.tabPage8.Controls.Add(this.textBoxDtuTime);
            this.tabPage8.Controls.Add(this.label58);
            this.tabPage8.Controls.Add(this.label59);
            this.tabPage8.Controls.Add(this.label60);
            this.tabPage8.Controls.Add(this.buttonDtuRxClear);
            this.tabPage8.Controls.Add(this.buttonDtuTxClear);
            this.tabPage8.Controls.Add(this.textBoxDtuRx);
            this.tabPage8.Controls.Add(this.textBoxDtuTx);
            this.tabPage8.Controls.Add(this.buttonDtu);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(491, 231);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "透传";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // textBoxDtuRxLen
            // 
            this.textBoxDtuRxLen.Location = new System.Drawing.Point(353, 82);
            this.textBoxDtuRxLen.MaxLength = 2;
            this.textBoxDtuRxLen.Name = "textBoxDtuRxLen";
            this.textBoxDtuRxLen.Size = new System.Drawing.Size(88, 21);
            this.textBoxDtuRxLen.TabIndex = 1057;
            this.textBoxDtuRxLen.Text = "11";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(258, 86);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(89, 12);
            this.label56.TabIndex = 1058;
            this.label56.Text = "标签响应帧长度";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(158, 89);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(65, 12);
            this.label57.TabIndex = 1056;
            this.label57.Text = "us(十进制)";
            // 
            // textBoxDtuTime
            // 
            this.textBoxDtuTime.Location = new System.Drawing.Point(84, 82);
            this.textBoxDtuTime.MaxLength = 16;
            this.textBoxDtuTime.Name = "textBoxDtuTime";
            this.textBoxDtuTime.Size = new System.Drawing.Size(69, 21);
            this.textBoxDtuTime.TabIndex = 1048;
            this.textBoxDtuTime.Text = "10000";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(7, 86);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(77, 12);
            this.label58.TabIndex = 1055;
            this.label58.Text = "标签超时时间";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(11, 110);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(29, 12);
            this.label59.TabIndex = 1054;
            this.label59.Text = "接收";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(7, 6);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(29, 12);
            this.label60.TabIndex = 1047;
            this.label60.Text = "发送";
            // 
            // buttonDtuRxClear
            // 
            this.buttonDtuRxClear.Location = new System.Drawing.Point(447, 110);
            this.buttonDtuRxClear.Name = "buttonDtuRxClear";
            this.buttonDtuRxClear.Size = new System.Drawing.Size(39, 77);
            this.buttonDtuRxClear.TabIndex = 1053;
            this.buttonDtuRxClear.Text = "清空";
            this.buttonDtuRxClear.UseVisualStyleBackColor = true;
            this.buttonDtuRxClear.Click += new System.EventHandler(this.buttonDtuRxClear_Click);
            // 
            // buttonDtuTxClear
            // 
            this.buttonDtuTxClear.Location = new System.Drawing.Point(447, 6);
            this.buttonDtuTxClear.Name = "buttonDtuTxClear";
            this.buttonDtuTxClear.Size = new System.Drawing.Size(39, 70);
            this.buttonDtuTxClear.TabIndex = 1052;
            this.buttonDtuTxClear.Text = "清空";
            this.buttonDtuTxClear.UseVisualStyleBackColor = true;
            this.buttonDtuTxClear.Click += new System.EventHandler(this.buttonDtuTxClear_Click);
            // 
            // textBoxDtuRx
            // 
            this.textBoxDtuRx.Location = new System.Drawing.Point(40, 110);
            this.textBoxDtuRx.MaxLength = 1000;
            this.textBoxDtuRx.Multiline = true;
            this.textBoxDtuRx.Name = "textBoxDtuRx";
            this.textBoxDtuRx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDtuRx.Size = new System.Drawing.Size(401, 77);
            this.textBoxDtuRx.TabIndex = 1051;
            // 
            // textBoxDtuTx
            // 
            this.textBoxDtuTx.Location = new System.Drawing.Point(40, 6);
            this.textBoxDtuTx.MaxLength = 400;
            this.textBoxDtuTx.Multiline = true;
            this.textBoxDtuTx.Name = "textBoxDtuTx";
            this.textBoxDtuTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDtuTx.Size = new System.Drawing.Size(401, 70);
            this.textBoxDtuTx.TabIndex = 1050;
            this.textBoxDtuTx.Text = "00FFFF0000";
            // 
            // buttonDtu
            // 
            this.buttonDtu.Location = new System.Drawing.Point(7, 189);
            this.buttonDtu.Name = "buttonDtu";
            this.buttonDtu.Size = new System.Drawing.Size(478, 40);
            this.buttonDtu.TabIndex = 1049;
            this.buttonDtu.Text = "透传";
            this.buttonDtu.UseVisualStyleBackColor = true;
            this.buttonDtu.Click += new System.EventHandler(this.buttonDtu_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.checkBoxUidEnable);
            this.groupBox13.Controls.Add(this.textBoxSelectedFelicaUid);
            this.groupBox13.Location = new System.Drawing.Point(222, 0);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(277, 40);
            this.groupBox13.TabIndex = 132;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "UID";
            // 
            // checkBoxUidEnable
            // 
            this.checkBoxUidEnable.AutoSize = true;
            this.checkBoxUidEnable.Enabled = false;
            this.checkBoxUidEnable.Location = new System.Drawing.Point(225, 17);
            this.checkBoxUidEnable.Name = "checkBoxUidEnable";
            this.checkBoxUidEnable.Size = new System.Drawing.Size(48, 16);
            this.checkBoxUidEnable.TabIndex = 1001;
            this.checkBoxUidEnable.Text = "使能";
            this.checkBoxUidEnable.UseVisualStyleBackColor = true;
            // 
            // textBoxSelectedFelicaUid
            // 
            this.textBoxSelectedFelicaUid.Location = new System.Drawing.Point(5, 14);
            this.textBoxSelectedFelicaUid.MaxLength = 32;
            this.textBoxSelectedFelicaUid.Name = "textBoxSelectedFelicaUid";
            this.textBoxSelectedFelicaUid.Size = new System.Drawing.Size(218, 21);
            this.textBoxSelectedFelicaUid.TabIndex = 1000;
            this.textBoxSelectedFelicaUid.Text = "00000000000000000000000000000000";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label34);
            this.groupBox11.Controls.Add(this.textBoxFelicaDestAddr);
            this.groupBox11.Controls.Add(this.textBoxFelicaSrcAddr);
            this.groupBox11.Controls.Add(this.label35);
            this.groupBox11.Location = new System.Drawing.Point(0, 0);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(216, 40);
            this.groupBox11.TabIndex = 131;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "设备地址";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(3, 18);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 12);
            this.label34.TabIndex = 4;
            this.label34.Text = "源地址";
            // 
            // textBoxFelicaDestAddr
            // 
            this.textBoxFelicaDestAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxFelicaDestAddr.Location = new System.Drawing.Point(159, 14);
            this.textBoxFelicaDestAddr.MaxLength = 4;
            this.textBoxFelicaDestAddr.Name = "textBoxFelicaDestAddr";
            this.textBoxFelicaDestAddr.Size = new System.Drawing.Size(46, 21);
            this.textBoxFelicaDestAddr.TabIndex = 7;
            this.textBoxFelicaDestAddr.Text = "0001";
            // 
            // textBoxFelicaSrcAddr
            // 
            this.textBoxFelicaSrcAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxFelicaSrcAddr.Location = new System.Drawing.Point(44, 14);
            this.textBoxFelicaSrcAddr.MaxLength = 4;
            this.textBoxFelicaSrcAddr.Name = "textBoxFelicaSrcAddr";
            this.textBoxFelicaSrcAddr.Size = new System.Drawing.Size(46, 21);
            this.textBoxFelicaSrcAddr.TabIndex = 6;
            this.textBoxFelicaSrcAddr.Text = "0000";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(106, 18);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(53, 12);
            this.label35.TabIndex = 5;
            this.label35.Text = "目标地址";
            // 
            // felica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 573);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControlFelicaTagOp);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "felica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Felica";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControlFelicaTagOp.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxGetUid.ResumeLayout(false);
            this.groupBoxGetUid.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.groupBoxTagIn.ResumeLayout(false);
            this.groupBoxTagIn.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButtonOpFelicaErrTypeParam;
        private System.Windows.Forms.RadioButton radioButtonOpFelicaErrTypeRsp;
        private System.Windows.Forms.RadioButton radioButtonOpFelicaErrTypeTag;
        private System.Windows.Forms.RadioButton radioButtonOpFelicaErrTypeOK;
        private System.Windows.Forms.RadioButton radioButtonOpFelicaErrTypeCrc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioButtonOpFelicaTagRltOpFail;
        private System.Windows.Forms.RadioButton radioButtonOpFelicaTagRltOpOK;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button buttonClearOpFelicaTag;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox textBoxOpFelicaTagRltDestAddr;
        private System.Windows.Forms.TextBox textBoxOpFelicaTagRltSrcAddr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonClearFelicaInfo;
        private System.Windows.Forms.TextBox textBoxFelicaInf;
        private System.Windows.Forms.TabControl tabControlFelicaTagOp;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxGetUid;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.RadioButton radioButtonRequestTagIdle;
        private System.Windows.Forms.RadioButton radioButtonRequestTagAll;
        private System.Windows.Forms.TextBox textBoxRemainTagNum;
        private System.Windows.Forms.TextBox textBoxReadTagNum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonClearFelicaListBox;
        private System.Windows.Forms.Button buttonReadFelicaTags;
        private System.Windows.Forms.ListBox listBoxTagInfo;
        private System.Windows.Forms.GroupBox groupBoxTagIn;
        private System.Windows.Forms.TextBox textBoxFelicaTagInNum;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button buttonClearFelicaInTag;
        private System.Windows.Forms.ListBox listBoxTagInfoIn;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TextBox textBoxDtuRxLen;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox textBoxDtuTime;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Button buttonDtuRxClear;
        private System.Windows.Forms.Button buttonDtuTxClear;
        private System.Windows.Forms.TextBox textBoxDtuRx;
        private System.Windows.Forms.TextBox textBoxDtuTx;
        private System.Windows.Forms.Button buttonDtu;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.CheckBox checkBoxUidEnable;
        private System.Windows.Forms.TextBox textBoxSelectedFelicaUid;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBoxFelicaDestAddr;
        private System.Windows.Forms.TextBox textBoxFelicaSrcAddr;
        private System.Windows.Forms.Label label35;
    }
}