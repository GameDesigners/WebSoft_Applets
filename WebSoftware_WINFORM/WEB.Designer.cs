namespace WebSoftware_WINFORM
{
    partial class WEB
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.GoBackBtn = new System.Windows.Forms.Button();
            this.WebPage = new System.Windows.Forms.WebBrowser();
            this.QuitAppBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoBackBtn.BackColor = System.Drawing.Color.Transparent;
            this.GoBackBtn.BackgroundImage = global::WebSoftware_WINFORM.Properties.Resources.return1;
            this.GoBackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GoBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.GoBackBtn.FlatAppearance.BorderSize = 2;
            this.GoBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GoBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GoBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoBackBtn.Location = new System.Drawing.Point(796, 9);
            this.GoBackBtn.Margin = new System.Windows.Forms.Padding(0);
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Padding = new System.Windows.Forms.Padding(1);
            this.GoBackBtn.Size = new System.Drawing.Size(80, 28);
            this.GoBackBtn.TabIndex = 1;
            this.GoBackBtn.UseVisualStyleBackColor = false;
            this.GoBackBtn.Click += new System.EventHandler(this.GoBackBtn_Click);
            // 
            // WebPage
            // 
            this.WebPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebPage.Location = new System.Drawing.Point(0, 0);
            this.WebPage.Margin = new System.Windows.Forms.Padding(0);
            this.WebPage.MinimumSize = new System.Drawing.Size(10, 10);
            this.WebPage.Name = "WebPage";
            this.WebPage.Size = new System.Drawing.Size(944, 501);
            this.WebPage.TabIndex = 0;
            this.WebPage.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrownswer_DocumentCompleted);
            // 
            // QuitAppBtn
            // 
            this.QuitAppBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitAppBtn.BackgroundImage = global::WebSoftware_WINFORM.Properties.Resources.Close;
            this.QuitAppBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.QuitAppBtn.FlatAppearance.BorderSize = 2;
            this.QuitAppBtn.Location = new System.Drawing.Point(886, 9);
            this.QuitAppBtn.Name = "QuitAppBtn";
            this.QuitAppBtn.Size = new System.Drawing.Size(28, 28);
            this.QuitAppBtn.TabIndex = 2;
            this.QuitAppBtn.UseVisualStyleBackColor = true;
            this.QuitAppBtn.Click += new System.EventHandler(this.QuitAppBtn_Click);
            // 
            // WEB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.ControlBox = false;
            this.Controls.Add(this.QuitAppBtn);
            this.Controls.Add(this.GoBackBtn);
            this.Controls.Add(this.WebPage);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WEB";
            this.Text = "WEB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WEB_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button GoBackBtn;
        private System.Windows.Forms.WebBrowser WebPage;
        private System.Windows.Forms.Button QuitAppBtn;
    }
}

