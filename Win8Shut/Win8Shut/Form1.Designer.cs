namespace Win8Shut
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnHide = new System.Windows.Forms.Button();
            this.lblRegStatus = new System.Windows.Forms.Label();
            this.chkHideOnStart = new System.Windows.Forms.CheckBox();
            this.lblShutTip = new System.Windows.Forms.Label();
            this.lblResetTip = new System.Windows.Forms.Label();
            this.cbxShutConfirm = new System.Windows.Forms.CheckBox();
            this.cbxResetConfirm = new System.Windows.Forms.CheckBox();
            this.lbx1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsTray
            // 
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShow,
            this.tsmiExit});
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.Size = new System.Drawing.Size(117, 48);
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(116, 22);
            this.tsmiShow.Text = "显示(&V)";
            this.tsmiShow.Click += new System.EventHandler(this.tsmiShow_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(116, 22);
            this.tsmiExit.Text = "退出(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsTray;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Win8 关机";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(440, 12);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(83, 23);
            this.btnHide.TabIndex = 1;
            this.btnHide.Text = "隐藏窗口(&D)";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // lblRegStatus
            // 
            this.lblRegStatus.AutoSize = true;
            this.lblRegStatus.Location = new System.Drawing.Point(12, 23);
            this.lblRegStatus.Name = "lblRegStatus";
            this.lblRegStatus.Size = new System.Drawing.Size(269, 12);
            this.lblRegStatus.TabIndex = 4;
            this.lblRegStatus.Text = "WIN+F12 音量+。WIN+F11 音量-。WIN+F10 静音。";
            // 
            // chkHideOnStart
            // 
            this.chkHideOnStart.AutoSize = true;
            this.chkHideOnStart.Location = new System.Drawing.Point(31, 193);
            this.chkHideOnStart.Name = "chkHideOnStart";
            this.chkHideOnStart.Size = new System.Drawing.Size(174, 16);
            this.chkHideOnStart.TabIndex = 5;
            this.chkHideOnStart.Text = "在程序启动后隐藏本窗口(&H)";
            this.chkHideOnStart.UseVisualStyleBackColor = true;
            this.chkHideOnStart.CheckedChanged += new System.EventHandler(this.cbxAll_CheckedChanged);
            // 
            // lblShutTip
            // 
            this.lblShutTip.AutoSize = true;
            this.lblShutTip.Location = new System.Drawing.Point(12, 93);
            this.lblShutTip.Name = "lblShutTip";
            this.lblShutTip.Size = new System.Drawing.Size(95, 12);
            this.lblShutTip.TabIndex = 6;
            this.lblShutTip.Text = "按WIN+ALT+Z关机";
            // 
            // lblResetTip
            // 
            this.lblResetTip.AutoSize = true;
            this.lblResetTip.Location = new System.Drawing.Point(12, 126);
            this.lblResetTip.Name = "lblResetTip";
            this.lblResetTip.Size = new System.Drawing.Size(95, 12);
            this.lblResetTip.TabIndex = 7;
            this.lblResetTip.Text = "按WIN+ALT+X重启";
            // 
            // cbxShutConfirm
            // 
            this.cbxShutConfirm.AutoSize = true;
            this.cbxShutConfirm.Location = new System.Drawing.Point(133, 92);
            this.cbxShutConfirm.Name = "cbxShutConfirm";
            this.cbxShutConfirm.Size = new System.Drawing.Size(114, 16);
            this.cbxShutConfirm.TabIndex = 8;
            this.cbxShutConfirm.Text = "在关机时确认(&A)";
            this.cbxShutConfirm.UseVisualStyleBackColor = true;
            this.cbxShutConfirm.CheckedChanged += new System.EventHandler(this.cbxAll_CheckedChanged);
            // 
            // cbxResetConfirm
            // 
            this.cbxResetConfirm.AutoSize = true;
            this.cbxResetConfirm.Location = new System.Drawing.Point(133, 125);
            this.cbxResetConfirm.Name = "cbxResetConfirm";
            this.cbxResetConfirm.Size = new System.Drawing.Size(114, 16);
            this.cbxResetConfirm.TabIndex = 9;
            this.cbxResetConfirm.Text = "在重启时确认(&S)";
            this.cbxResetConfirm.UseVisualStyleBackColor = true;
            this.cbxResetConfirm.CheckedChanged += new System.EventHandler(this.cbxAll_CheckedChanged);
            // 
            // lbx1
            // 
            this.lbx1.FormattingEnabled = true;
            this.lbx1.ItemHeight = 12;
            this.lbx1.Location = new System.Drawing.Point(281, 51);
            this.lbx1.Name = "lbx1";
            this.lbx1.Size = new System.Drawing.Size(261, 208);
            this.lbx1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "在WIN8以上的版本，按CTRL+空格 等于 WIN+空格";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 265);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbx1);
            this.Controls.Add(this.cbxResetConfirm);
            this.Controls.Add(this.cbxShutConfirm);
            this.Controls.Add(this.lblResetTip);
            this.Controls.Add(this.lblShutTip);
            this.Controls.Add(this.chkHideOnStart);
            this.Controls.Add(this.lblRegStatus);
            this.Controls.Add(this.btnHide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Win8 关机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsTray;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label lblRegStatus;
        private System.Windows.Forms.CheckBox chkHideOnStart;
        private System.Windows.Forms.Label lblShutTip;
        private System.Windows.Forms.Label lblResetTip;
        private System.Windows.Forms.CheckBox cbxShutConfirm;
        private System.Windows.Forms.CheckBox cbxResetConfirm;
        private System.Windows.Forms.ListBox lbx1;
        private System.Windows.Forms.Label label1;
    }
}

