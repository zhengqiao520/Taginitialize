namespace Phychips.PR9200
{
    partial class FormReadRangeCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReadRangeCalculator));
            this.groupBoxReaderParameter = new System.Windows.Forms.GroupBox();
            this.checkBoxReaderLimit = new System.Windows.Forms.CheckBox();
            this.radioButtonCircularAntenna = new System.Windows.Forms.RadioButton();
            this.radioButtonLinearAntenna = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxLambda = new System.Windows.Forms.TextBox();
            this.textBoxdeltaLeader = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxReaderAntennaGain = new System.Windows.Forms.TextBox();
            this.numericUpDownReaderSens = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxTagParameter = new System.Windows.Forms.GroupBox();
            this.checkBoxTagLimit = new System.Windows.Forms.CheckBox();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxPathLoss = new System.Windows.Forms.TextBox();
            this.textBoxdeltaLtag = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTagAntennaGain = new System.Windows.Forms.TextBox();
            this.numericUpDownTagSens = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.groupBoxParameter = new System.Windows.Forms.GroupBox();
            this.groupBoxReaderParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReaderSens)).BeginInit();
            this.groupBoxTagParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTagSens)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBoxParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxReaderParameter
            // 
            this.groupBoxReaderParameter.Controls.Add(this.checkBoxReaderLimit);
            this.groupBoxReaderParameter.Controls.Add(this.radioButtonCircularAntenna);
            this.groupBoxReaderParameter.Controls.Add(this.radioButtonLinearAntenna);
            this.groupBoxReaderParameter.Controls.Add(this.label12);
            this.groupBoxReaderParameter.Controls.Add(this.label11);
            this.groupBoxReaderParameter.Controls.Add(this.label10);
            this.groupBoxReaderParameter.Controls.Add(this.textBoxLambda);
            this.groupBoxReaderParameter.Controls.Add(this.textBoxdeltaLeader);
            this.groupBoxReaderParameter.Controls.Add(this.label7);
            this.groupBoxReaderParameter.Controls.Add(this.label6);
            this.groupBoxReaderParameter.Controls.Add(this.textBoxReaderAntennaGain);
            this.groupBoxReaderParameter.Controls.Add(this.numericUpDownReaderSens);
            this.groupBoxReaderParameter.Controls.Add(this.label2);
            this.groupBoxReaderParameter.Controls.Add(this.label1);
            this.groupBoxReaderParameter.Location = new System.Drawing.Point(6, 20);
            this.groupBoxReaderParameter.Name = "groupBoxReaderParameter";
            this.groupBoxReaderParameter.Size = new System.Drawing.Size(248, 97);
            this.groupBoxReaderParameter.TabIndex = 0;
            this.groupBoxReaderParameter.TabStop = false;
            this.groupBoxReaderParameter.Text = "Reader Parameter";
            // 
            // checkBoxReaderLimit
            // 
            this.checkBoxReaderLimit.AutoSize = true;
            this.checkBoxReaderLimit.Location = new System.Drawing.Point(9, 160);
            this.checkBoxReaderLimit.Name = "checkBoxReaderLimit";
            this.checkBoxReaderLimit.Size = new System.Drawing.Size(127, 16);
            this.checkBoxReaderLimit.TabIndex = 17;
            this.checkBoxReaderLimit.Text = "View Reader Limit";
            this.checkBoxReaderLimit.UseVisualStyleBackColor = true;
            this.checkBoxReaderLimit.CheckedChanged += new System.EventHandler(this.plotLocus);
            // 
            // radioButtonCircularAntenna
            // 
            this.radioButtonCircularAntenna.AutoSize = true;
            this.radioButtonCircularAntenna.Location = new System.Drawing.Point(124, 48);
            this.radioButtonCircularAntenna.Name = "radioButtonCircularAntenna";
            this.radioButtonCircularAntenna.Size = new System.Drawing.Size(117, 16);
            this.radioButtonCircularAntenna.TabIndex = 15;
            this.radioButtonCircularAntenna.TabStop = true;
            this.radioButtonCircularAntenna.Text = "Circular Antenna";
            this.radioButtonCircularAntenna.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinearAntenna
            // 
            this.radioButtonLinearAntenna.AutoSize = true;
            this.radioButtonLinearAntenna.Checked = true;
            this.radioButtonLinearAntenna.Location = new System.Drawing.Point(9, 48);
            this.radioButtonLinearAntenna.Name = "radioButtonLinearAntenna";
            this.radioButtonLinearAntenna.Size = new System.Drawing.Size(108, 16);
            this.radioButtonLinearAntenna.TabIndex = 14;
            this.radioButtonLinearAntenna.TabStop = true;
            this.radioButtonLinearAntenna.Text = "Linear Antenna";
            this.radioButtonLinearAntenna.UseVisualStyleBackColor = true;
            this.radioButtonLinearAntenna.CheckedChanged += new System.EventHandler(this.plotLocus);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(198, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "[dB]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(198, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "[dBi]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(198, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "[dBm]";
            // 
            // textBoxLambda
            // 
            this.textBoxLambda.Location = new System.Drawing.Point(149, 129);
            this.textBoxLambda.Name = "textBoxLambda";
            this.textBoxLambda.Size = new System.Drawing.Size(43, 21);
            this.textBoxLambda.TabIndex = 9;
            this.textBoxLambda.Text = "0.33";
            this.textBoxLambda.TextChanged += new System.EventHandler(this.plotLocus);
            // 
            // textBoxdeltaLeader
            // 
            this.textBoxdeltaLeader.Location = new System.Drawing.Point(149, 102);
            this.textBoxdeltaLeader.Name = "textBoxdeltaLeader";
            this.textBoxdeltaLeader.Size = new System.Drawing.Size(43, 21);
            this.textBoxdeltaLeader.TabIndex = 8;
            this.textBoxdeltaLeader.Text = "0";
            this.textBoxdeltaLeader.TextChanged += new System.EventHandler(this.plotLocus);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "λ : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "ΔLreader : ";
            // 
            // textBoxReaderAntennaGain
            // 
            this.textBoxReaderAntennaGain.Location = new System.Drawing.Point(149, 72);
            this.textBoxReaderAntennaGain.Name = "textBoxReaderAntennaGain";
            this.textBoxReaderAntennaGain.Size = new System.Drawing.Size(43, 21);
            this.textBoxReaderAntennaGain.TabIndex = 3;
            this.textBoxReaderAntennaGain.Text = "-0.5";
            this.textBoxReaderAntennaGain.TextChanged += new System.EventHandler(this.plotLocus);
            // 
            // numericUpDownReaderSens
            // 
            this.numericUpDownReaderSens.Location = new System.Drawing.Point(149, 20);
            this.numericUpDownReaderSens.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownReaderSens.Name = "numericUpDownReaderSens";
            this.numericUpDownReaderSens.Size = new System.Drawing.Size(43, 21);
            this.numericUpDownReaderSens.TabIndex = 2;
            this.numericUpDownReaderSens.Value = new decimal(new int[] {
            60,
            0,
            0,
            -2147483648});
            this.numericUpDownReaderSens.ValueChanged += new System.EventHandler(this.plotLocus);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reader Antenna Gain :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reader Sensitivity :";
            // 
            // groupBoxTagParameter
            // 
            this.groupBoxTagParameter.Controls.Add(this.checkBoxTagLimit);
            this.groupBoxTagParameter.Controls.Add(this.buttonDetails);
            this.groupBoxTagParameter.Controls.Add(this.label17);
            this.groupBoxTagParameter.Controls.Add(this.label16);
            this.groupBoxTagParameter.Controls.Add(this.label15);
            this.groupBoxTagParameter.Controls.Add(this.label14);
            this.groupBoxTagParameter.Controls.Add(this.textBoxPathLoss);
            this.groupBoxTagParameter.Controls.Add(this.textBoxdeltaLtag);
            this.groupBoxTagParameter.Controls.Add(this.label9);
            this.groupBoxTagParameter.Controls.Add(this.label8);
            this.groupBoxTagParameter.Controls.Add(this.textBoxTagAntennaGain);
            this.groupBoxTagParameter.Controls.Add(this.numericUpDownTagSens);
            this.groupBoxTagParameter.Controls.Add(this.label4);
            this.groupBoxTagParameter.Controls.Add(this.label3);
            this.groupBoxTagParameter.Location = new System.Drawing.Point(260, 20);
            this.groupBoxTagParameter.Name = "groupBoxTagParameter";
            this.groupBoxTagParameter.Size = new System.Drawing.Size(244, 97);
            this.groupBoxTagParameter.TabIndex = 1;
            this.groupBoxTagParameter.TabStop = false;
            this.groupBoxTagParameter.Text = "Tag Parameter";
            // 
            // checkBoxTagLimit
            // 
            this.checkBoxTagLimit.AutoSize = true;
            this.checkBoxTagLimit.Location = new System.Drawing.Point(8, 160);
            this.checkBoxTagLimit.Name = "checkBoxTagLimit";
            this.checkBoxTagLimit.Size = new System.Drawing.Size(109, 16);
            this.checkBoxTagLimit.TabIndex = 16;
            this.checkBoxTagLimit.Text = "View Tag Limit";
            this.checkBoxTagLimit.UseVisualStyleBackColor = true;
            this.checkBoxTagLimit.CheckedChanged += new System.EventHandler(this.plotLocus);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Location = new System.Drawing.Point(163, 73);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonDetails.TabIndex = 2;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.button1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(196, 108);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 12);
            this.label17.TabIndex = 15;
            this.label17.Text = "[dB]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(196, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "[dB]";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(196, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 14;
            this.label15.Text = "[dBi]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(198, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "[dBm]";
            // 
            // textBoxPathLoss
            // 
            this.textBoxPathLoss.Location = new System.Drawing.Point(134, 129);
            this.textBoxPathLoss.Name = "textBoxPathLoss";
            this.textBoxPathLoss.Size = new System.Drawing.Size(60, 21);
            this.textBoxPathLoss.TabIndex = 8;
            this.textBoxPathLoss.Text = "0";
            this.textBoxPathLoss.TextChanged += new System.EventHandler(this.plotLocus);
            // 
            // textBoxdeltaLtag
            // 
            this.textBoxdeltaLtag.Location = new System.Drawing.Point(134, 102);
            this.textBoxdeltaLtag.Name = "textBoxdeltaLtag";
            this.textBoxdeltaLtag.Size = new System.Drawing.Size(60, 21);
            this.textBoxdeltaLtag.TabIndex = 7;
            this.textBoxdeltaLtag.Text = "0";
            this.textBoxdeltaLtag.TextChanged += new System.EventHandler(this.plotLocus);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "Path Loss : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "ΔLtag : ";
            // 
            // textBoxTagAntennaGain
            // 
            this.textBoxTagAntennaGain.Location = new System.Drawing.Point(134, 47);
            this.textBoxTagAntennaGain.Name = "textBoxTagAntennaGain";
            this.textBoxTagAntennaGain.Size = new System.Drawing.Size(60, 21);
            this.textBoxTagAntennaGain.TabIndex = 4;
            this.textBoxTagAntennaGain.Text = "0";
            this.textBoxTagAntennaGain.TextChanged += new System.EventHandler(this.plotLocus);
            // 
            // numericUpDownTagSens
            // 
            this.numericUpDownTagSens.Location = new System.Drawing.Point(134, 20);
            this.numericUpDownTagSens.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTagSens.Name = "numericUpDownTagSens";
            this.numericUpDownTagSens.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownTagSens.TabIndex = 3;
            this.numericUpDownTagSens.Value = new decimal(new int[] {
            17,
            0,
            0,
            -2147483648});
            this.numericUpDownTagSens.ValueChanged += new System.EventHandler(this.plotLocus);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tag Anatenna Gain :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tag Sensitivity :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.zedGraphControl);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 374);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(6, 20);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(495, 348);
            this.zedGraphControl.TabIndex = 4;
            // 
            // groupBoxParameter
            // 
            this.groupBoxParameter.Controls.Add(this.groupBoxReaderParameter);
            this.groupBoxParameter.Controls.Add(this.groupBoxTagParameter);
            this.groupBoxParameter.Location = new System.Drawing.Point(12, 372);
            this.groupBoxParameter.Name = "groupBoxParameter";
            this.groupBoxParameter.Size = new System.Drawing.Size(510, 123);
            this.groupBoxParameter.TabIndex = 3;
            this.groupBoxParameter.TabStop = false;
            this.groupBoxParameter.Text = "Parameter";
            // 
            // FormReadRangeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 499);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxParameter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(548, 643);
            this.Name = "FormReadRangeCalculator";
            this.Text = "Read Range Calculator";
            this.groupBoxReaderParameter.ResumeLayout(false);
            this.groupBoxReaderParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReaderSens)).EndInit();
            this.groupBoxTagParameter.ResumeLayout(false);
            this.groupBoxTagParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTagSens)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBoxParameter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReaderParameter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxTagParameter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownReaderSens;
        private System.Windows.Forms.TextBox textBoxReaderAntennaGain;
        private System.Windows.Forms.TextBox textBoxTagAntennaGain;
        private System.Windows.Forms.NumericUpDown numericUpDownTagSens;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBoxParameter;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.TextBox textBoxLambda;
        private System.Windows.Forms.TextBox textBoxdeltaLeader;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPathLoss;
        private System.Windows.Forms.TextBox textBoxdeltaLtag;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton radioButtonCircularAntenna;
        private System.Windows.Forms.RadioButton radioButtonLinearAntenna;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.CheckBox checkBoxReaderLimit;
        private System.Windows.Forms.CheckBox checkBoxTagLimit;
    }
}