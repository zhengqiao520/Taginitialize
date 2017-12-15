namespace Phychips.PR9200
{
    partial class RegistryUpdate
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_UpdateNow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure you want to change registry?";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(189, 59);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 25);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_UpdateNow
            // 
            this.button_UpdateNow.Location = new System.Drawing.Point(66, 59);
            this.button_UpdateNow.Name = "button_UpdateNow";
            this.button_UpdateNow.Size = new System.Drawing.Size(100, 25);
            this.button_UpdateNow.TabIndex = 2;
            this.button_UpdateNow.Text = "OK";
            this.button_UpdateNow.UseVisualStyleBackColor = true;
            this.button_UpdateNow.Click += new System.EventHandler(this.button_UpdateNow_Click);
            // 
            // RegistryUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 96);
            this.Controls.Add(this.button_UpdateNow);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistryUpdate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registry Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_UpdateNow;
    }
}