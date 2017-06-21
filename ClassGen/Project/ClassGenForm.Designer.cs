namespace ClassGen
{
    partial class ClassGenForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSTART = new System.Windows.Forms.Button();
            this.textBoxPreview = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSTART
            // 
            this.buttonSTART.Location = new System.Drawing.Point(264, 12);
            this.buttonSTART.Name = "buttonSTART";
            this.buttonSTART.Size = new System.Drawing.Size(101, 45);
            this.buttonSTART.TabIndex = 0;
            this.buttonSTART.Text = "START";
            this.buttonSTART.UseVisualStyleBackColor = true;
            this.buttonSTART.Click += new System.EventHandler(this.buttonSTART_Click);
            // 
            // textBoxPreview
            // 
            this.textBoxPreview.Location = new System.Drawing.Point(12, 12);
            this.textBoxPreview.Multiline = true;
            this.textBoxPreview.Name = "textBoxPreview";
            this.textBoxPreview.Size = new System.Drawing.Size(246, 349);
            this.textBoxPreview.TabIndex = 1;
            // 
            // ClassGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 373);
            this.Controls.Add(this.textBoxPreview);
            this.Controls.Add(this.buttonSTART);
            this.Name = "ClassGenForm";
            this.Text = "ClassGen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSTART;
        private System.Windows.Forms.TextBox textBoxPreview;
    }
}

