namespace Phychips.PR9200
{
    partial class FormPowerLevellTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPowerLevellTable));
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonUpdateTable = new System.Windows.Forms.Button();
            this.button_load_CalPwrSTP = new System.Windows.Forms.Button();
            this.listViewEx1 = new CustomListView.ListViewEx();
            this.Pwr_Step = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.curPWR_Val = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cal_PWR_Step = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Location = new System.Drawing.Point(168, 12);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(150, 36);
            this.buttonRemoveItem.TabIndex = 2;
            this.buttonRemoveItem.Text = "Remove PowrLevel";
            this.buttonRemoveItem.UseVisualStyleBackColor = true;
            this.buttonRemoveItem.Click += new System.EventHandler(this.buttonRemoveItem_Click);
            // 
            // buttonUpdateTable
            // 
            this.buttonUpdateTable.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonUpdateTable.Location = new System.Drawing.Point(324, 12);
            this.buttonUpdateTable.Name = "buttonUpdateTable";
            this.buttonUpdateTable.Size = new System.Drawing.Size(150, 36);
            this.buttonUpdateTable.TabIndex = 3;
            this.buttonUpdateTable.Text = "Update Table";
            this.buttonUpdateTable.UseVisualStyleBackColor = true;
            this.buttonUpdateTable.Click += new System.EventHandler(this.buttonUpdateTable_Click);
            // 
            // button_load_CalPwrSTP
            // 
            this.button_load_CalPwrSTP.Location = new System.Drawing.Point(212, 22);
            this.button_load_CalPwrSTP.Name = "button_load_CalPwrSTP";
            this.button_load_CalPwrSTP.Size = new System.Drawing.Size(60, 36);
            this.button_load_CalPwrSTP.TabIndex = 5;
            this.button_load_CalPwrSTP.Text = "Load Cal Value";
            this.button_load_CalPwrSTP.UseVisualStyleBackColor = true;
            this.button_load_CalPwrSTP.Visible = false;
            this.button_load_CalPwrSTP.Click += new System.EventHandler(this.button_load_CalPwrSTP_Click);
            // 
            // listViewEx1
            // 
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Pwr_Step,
            this.Value,
            this.curPWR_Val,
            this.Cal_PWR_Step});
            this.listViewEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewEx1.FullRowSelect = true;
            this.listViewEx1.GridLines = true;
            this.listViewEx1.Location = new System.Drawing.Point(0, 64);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(486, 482);
            this.listViewEx1.TabIndex = 0;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // Pwr_Step
            // 
            this.Pwr_Step.Text = "PWR Step";
            this.Pwr_Step.Width = 88;
            // 
            // Value
            // 
            this.Value.Text = "Set Value";
            this.Value.Width = 102;
            // 
            // curPWR_Val
            // 
            this.curPWR_Val.Text = "Current PWR Value";
            this.curPWR_Val.Width = 130;
            // 
            // Cal_PWR_Step
            // 
            this.Cal_PWR_Step.Text = "Calibration PWR Step";
            this.Cal_PWR_Step.Width = 152;
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(12, 12);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(150, 36);
            this.buttonAddItem.TabIndex = 6;
            this.buttonAddItem.Text = "Add PowrLevel";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // FormPowerLevellTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 546);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.button_load_CalPwrSTP);
            this.Controls.Add(this.buttonUpdateTable);
            this.Controls.Add(this.buttonRemoveItem);
            this.Controls.Add(this.listViewEx1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPowerLevellTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Power Table";
            this.Load += new System.EventHandler(this.FormPowerLevellTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomListView.ListViewEx listViewEx1;
        private System.Windows.Forms.ColumnHeader Pwr_Step;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Button buttonUpdateTable;
        private System.Windows.Forms.ColumnHeader curPWR_Val;
        private System.Windows.Forms.ColumnHeader Cal_PWR_Step;
        private System.Windows.Forms.Button button_load_CalPwrSTP;
        private System.Windows.Forms.Button buttonAddItem;

    }
}