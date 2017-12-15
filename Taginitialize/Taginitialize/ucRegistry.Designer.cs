namespace Phychips.PR9200
{
    partial class ucRegistry
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
            this.lvRegItem = new System.Windows.Forms.ListView();
            this.cAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cItems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSubItems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cValueDec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cValueHex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRegistry = new System.Windows.Forms.Button();
            this.buttonEepErase = new System.Windows.Forms.Button();
            this.buttonEepUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvRegItem
            // 
            this.lvRegItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cAddress,
            this.cItems,
            this.cActive,
            this.cSubItems,
            this.cType,
            this.cValueDec,
            this.cValueHex});
            this.lvRegItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRegItem.FullRowSelect = true;
            this.lvRegItem.Location = new System.Drawing.Point(3, 4);
            this.lvRegItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvRegItem.MultiSelect = false;
            this.lvRegItem.Name = "lvRegItem";
            this.lvRegItem.Size = new System.Drawing.Size(616, 253);
            this.lvRegItem.TabIndex = 0;
            this.lvRegItem.UseCompatibleStateImageBehavior = false;
            this.lvRegItem.View = System.Windows.Forms.View.Details;
            // 
            // cAddress
            // 
            this.cAddress.Text = "Address";
            // 
            // cItems
            // 
            this.cItems.Text = "Items";
            this.cItems.Width = 73;
            // 
            // cActive
            // 
            this.cActive.Text = "Active";
            this.cActive.Width = 66;
            // 
            // cSubItems
            // 
            this.cSubItems.Text = "Sub Items";
            this.cSubItems.Width = 110;
            // 
            // cType
            // 
            this.cType.Text = "Type";
            // 
            // cValueDec
            // 
            this.cValueDec.Text = "Value (DEC)";
            this.cValueDec.Width = 160;
            // 
            // cValueHex
            // 
            this.cValueHex.Text = "Value (HEX)";
            this.cValueHex.Width = 160;
            // 
            // buttonRegistry
            // 
            this.buttonRegistry.Location = new System.Drawing.Point(3, 266);
            this.buttonRegistry.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonRegistry.Name = "buttonRegistry";
            this.buttonRegistry.Size = new System.Drawing.Size(87, 30);
            this.buttonRegistry.TabIndex = 10;
            this.buttonRegistry.Text = "Get Registry";
            this.buttonRegistry.UseVisualStyleBackColor = true;
            this.buttonRegistry.Click += new System.EventHandler(this.buttonRegistry_Click);
            // 
            // buttonEepErase
            // 
            this.buttonEepErase.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEepErase.Location = new System.Drawing.Point(511, 266);
            this.buttonEepErase.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonEepErase.Name = "buttonEepErase";
            this.buttonEepErase.Size = new System.Drawing.Size(48, 30);
            this.buttonEepErase.TabIndex = 2273;
            this.buttonEepErase.Text = "Erase";
            this.buttonEepErase.UseVisualStyleBackColor = true;
            this.buttonEepErase.Visible = false;
            this.buttonEepErase.Click += new System.EventHandler(this.buttonEepErase_Click);
            // 
            // buttonEepUpdate
            // 
            this.buttonEepUpdate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEepUpdate.Location = new System.Drawing.Point(564, 266);
            this.buttonEepUpdate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonEepUpdate.Name = "buttonEepUpdate";
            this.buttonEepUpdate.Size = new System.Drawing.Size(55, 30);
            this.buttonEepUpdate.TabIndex = 2272;
            this.buttonEepUpdate.Text = "Update";
            this.buttonEepUpdate.UseVisualStyleBackColor = true;
            this.buttonEepUpdate.Click += new System.EventHandler(this.buttonEepUpdate_Click);
            // 
            // ucRegistry
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.buttonEepErase);
            this.Controls.Add(this.buttonEepUpdate);
            this.Controls.Add(this.lvRegItem);
            this.Controls.Add(this.buttonRegistry);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucRegistry";
            this.Size = new System.Drawing.Size(629, 302);
            this.Load += new System.EventHandler(this.ucRegistry_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRegItem;
        private System.Windows.Forms.Button buttonRegistry;
        private System.Windows.Forms.ColumnHeader cItems;
        private System.Windows.Forms.ColumnHeader cValueDec;
        private System.Windows.Forms.ColumnHeader cType;
        private System.Windows.Forms.ColumnHeader cValueHex;
        private System.Windows.Forms.ColumnHeader cAddress;
        private System.Windows.Forms.ColumnHeader cActive;
        private System.Windows.Forms.ColumnHeader cSubItems;
        private System.Windows.Forms.Button buttonEepErase;
        private System.Windows.Forms.Button buttonEepUpdate;
    }
}
