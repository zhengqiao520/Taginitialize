namespace Phychips.PR9200
{
    partial class FormScanRssi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScanRssi));
            this.hbcRssi = new BarChart.HBarChart();
            this.SuspendLayout();
            // 
            // hbcRssi
            // 
            this.hbcRssi.Background.GradientColor1 = System.Drawing.Color.White;
            this.hbcRssi.Background.GradientColor2 = System.Drawing.Color.White;
            this.hbcRssi.Background.PaintingMode = BarChart.CBackgroundProperty.PaintingModes.SolidColor;
            this.hbcRssi.Background.SolidColor = System.Drawing.Color.White;
            this.hbcRssi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hbcRssi.BarsGap = 0;
            this.hbcRssi.BarWidth = 11;
            this.hbcRssi.Border.BoundRect = ((System.Drawing.RectangleF)(resources.GetObject("resource.BoundRect")));
            this.hbcRssi.Border.Color = System.Drawing.Color.White;
            this.hbcRssi.Border.Visible = true;
            this.hbcRssi.Border.Width = 1;
            this.hbcRssi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hbcRssi.Cursor = System.Windows.Forms.Cursors.Default;
            this.hbcRssi.Description.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hbcRssi.Description.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.hbcRssi.Description.FontDefaultSize = 14F;
            this.hbcRssi.Description.Text = "";
            this.hbcRssi.Description.Visible = false;
            this.hbcRssi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hbcRssi.Font = new System.Drawing.Font("Arial", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hbcRssi.Items.DefaultWidth = 0;
            this.hbcRssi.Items.DrawingMode = BarChart.HBarItems.DrawingModes.Solid;
            this.hbcRssi.Items.Maximum = 0D;
            this.hbcRssi.Items.Minimum = 0D;
            this.hbcRssi.Items.ShouldReCalculate = false;
            this.hbcRssi.Label.Color = System.Drawing.Color.Black;
            this.hbcRssi.Label.Font = new System.Drawing.Font("Arial", 3.75F, System.Drawing.FontStyle.Bold);
            this.hbcRssi.Label.FontDefaultSize = 3.75F;
            this.hbcRssi.Label.Visible = true;
            this.hbcRssi.Location = new System.Drawing.Point(0, 0);
            this.hbcRssi.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.hbcRssi.Name = "hbcRssi";
            this.hbcRssi.Shadow.ColorInner = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hbcRssi.Shadow.ColorOuter = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hbcRssi.Shadow.Mode = BarChart.CShadowProperty.Modes.None;
            this.hbcRssi.Shadow.WidthInner = 5;
            this.hbcRssi.Shadow.WidthOuter = 5;
            this.hbcRssi.Size = new System.Drawing.Size(534, 262);
            this.hbcRssi.SizingMode = BarChart.HBarChart.BarSizingMode.Normal;
            this.hbcRssi.TabIndex = 54;
            this.hbcRssi.Values.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hbcRssi.Values.Font = new System.Drawing.Font("Tahoma", 7F);
            this.hbcRssi.Values.FontDefaultSize = 7F;
            this.hbcRssi.Values.Mode = BarChart.CValueProperty.ValueMode.Digit;
            this.hbcRssi.Values.Visible = false;
            // 
            // FormScanRssi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(534, 262);
            this.Controls.Add(this.hbcRssi);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormScanRssi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormScanRssi";
            this.ResumeLayout(false);

        }

        #endregion

        private BarChart.HBarChart hbcRssi;


    }
}