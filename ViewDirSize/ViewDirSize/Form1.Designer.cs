namespace ViewDirSize
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtViewDir = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.pbDirPer = new System.Windows.Forms.ProgressBar();
            this.lblDirName = new System.Windows.Forms.Label();
            this.lblDirSize = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(546, 14);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "查看(&V)";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查看位置";
            // 
            // txtViewDir
            // 
            this.txtViewDir.Location = new System.Drawing.Point(159, 14);
            this.txtViewDir.Name = "txtViewDir";
            this.txtViewDir.Size = new System.Drawing.Size(367, 21);
            this.txtViewDir.TabIndex = 2;
            this.txtViewDir.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtViewDir_KeyUp);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(100, 51);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(29, 12);
            this.lblMsg.TabIndex = 4;
            this.lblMsg.Text = "查看";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(637, 14);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止(&S)";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pbDirPer
            // 
            this.pbDirPer.Location = new System.Drawing.Point(544, 14);
            this.pbDirPer.Name = "pbDirPer";
            this.pbDirPer.Size = new System.Drawing.Size(237, 18);
            this.pbDirPer.TabIndex = 6;
            // 
            // lblDirName
            // 
            this.lblDirName.AutoSize = true;
            this.lblDirName.Location = new System.Drawing.Point(3, 20);
            this.lblDirName.Name = "lblDirName";
            this.lblDirName.Size = new System.Drawing.Size(29, 12);
            this.lblDirName.TabIndex = 7;
            this.lblDirName.Text = "名称";
            // 
            // lblDirSize
            // 
            this.lblDirSize.AutoSize = true;
            this.lblDirSize.Location = new System.Drawing.Point(251, 20);
            this.lblDirSize.Name = "lblDirSize";
            this.lblDirSize.Size = new System.Drawing.Size(29, 12);
            this.lblDirSize.TabIndex = 8;
            this.lblDirSize.Text = "大小";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.lblDirName);
            this.pnlMain.Controls.Add(this.lblDirSize);
            this.pnlMain.Controls.Add(this.pbDirPer);
            this.pnlMain.Location = new System.Drawing.Point(2, 77);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(789, 532);
            this.pnlMain.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 613);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtViewDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看文件夹大小";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtViewDir;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar pbDirPer;
        private System.Windows.Forms.Label lblDirName;
        private System.Windows.Forms.Label lblDirSize;
        private System.Windows.Forms.Panel pnlMain;
    }
}

