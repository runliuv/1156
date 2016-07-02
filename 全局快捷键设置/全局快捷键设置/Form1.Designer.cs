namespace 全局快捷键设置
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
        /// <param name="disposing">如果应释放托管资源//为 true；否则为 false。</param>
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
            this.gbShutdown = new System.Windows.Forms.GroupBox();
            this.cbShutAlt = new System.Windows.Forms.CheckBox();
            this.cbShutCaps = new System.Windows.Forms.CheckBox();
            this.cbShutCtrl = new System.Windows.Forms.CheckBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsForNI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.gbReset = new System.Windows.Forms.GroupBox();
            this.cbResetCaps = new System.Windows.Forms.CheckBox();
            this.cbResetAlt = new System.Windows.Forms.CheckBox();
            this.cbResetCtrl = new System.Windows.Forms.CheckBox();
            this.lblHello = new System.Windows.Forms.Label();
            this.gbShutdown.SuspendLayout();
            this.cmsForNI.SuspendLayout();
            this.gbReset.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbShutdown
            // 
            this.gbShutdown.Controls.Add(this.cbShutAlt);
            this.gbShutdown.Controls.Add(this.cbShutCaps);
            this.gbShutdown.Controls.Add(this.cbShutCtrl);
            this.gbShutdown.Location = new System.Drawing.Point(34, 12);
            this.gbShutdown.Name = "gbShutdown";
            this.gbShutdown.Size = new System.Drawing.Size(291, 51);
            this.gbShutdown.TabIndex = 0;
            this.gbShutdown.TabStop = false;
            this.gbShutdown.Text = "关机 power off";
            // 
            // cbShutAlt
            // 
            this.cbShutAlt.AutoSize = true;
            this.cbShutAlt.Location = new System.Drawing.Point(102, 20);
            this.cbShutAlt.Name = "cbShutAlt";
            this.cbShutAlt.Size = new System.Drawing.Size(42, 16);
            this.cbShutAlt.TabIndex = 4;
            this.cbShutAlt.Text = "Alt";
            this.cbShutAlt.UseVisualStyleBackColor = true;
            // 
            // cbShutCaps
            // 
            this.cbShutCaps.AutoSize = true;
            this.cbShutCaps.Checked = true;
            this.cbShutCaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShutCaps.Enabled = false;
            this.cbShutCaps.Location = new System.Drawing.Point(172, 20);
            this.cbShutCaps.Name = "cbShutCaps";
            this.cbShutCaps.Size = new System.Drawing.Size(72, 16);
            this.cbShutCaps.TabIndex = 2;
            this.cbShutCaps.Text = "CapsLock";
            this.cbShutCaps.UseVisualStyleBackColor = true;
            // 
            // cbShutCtrl
            // 
            this.cbShutCtrl.AutoSize = true;
            this.cbShutCtrl.Checked = true;
            this.cbShutCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShutCtrl.Location = new System.Drawing.Point(24, 20);
            this.cbShutCtrl.Name = "cbShutCtrl";
            this.cbShutCtrl.Size = new System.Drawing.Size(48, 16);
            this.cbShutCtrl.TabIndex = 3;
            this.cbShutCtrl.Text = "Ctrl";
            this.cbShutCtrl.UseVisualStyleBackColor = true;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(250, 161);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 23);
            this.btnReg.TabIndex = 1;
            this.btnReg.Text = "注册键(&R)";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsForNI;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // cmsForNI
            // 
            this.cmsForNI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.cmsForNI.Name = "cmsForNI";
            this.cmsForNI.Size = new System.Drawing.Size(131, 26);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(130, 22);
            this.tsmiExit.Text = "退出 E&XIT";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // gbReset
            // 
            this.gbReset.Controls.Add(this.cbResetCaps);
            this.gbReset.Controls.Add(this.cbResetAlt);
            this.gbReset.Controls.Add(this.cbResetCtrl);
            this.gbReset.Location = new System.Drawing.Point(34, 69);
            this.gbReset.Name = "gbReset";
            this.gbReset.Size = new System.Drawing.Size(291, 51);
            this.gbReset.TabIndex = 3;
            this.gbReset.TabStop = false;
            this.gbReset.Text = "重启 reset";
            // 
            // cbResetCaps
            // 
            this.cbResetCaps.AutoSize = true;
            this.cbResetCaps.Checked = true;
            this.cbResetCaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbResetCaps.Enabled = false;
            this.cbResetCaps.Location = new System.Drawing.Point(172, 20);
            this.cbResetCaps.Name = "cbResetCaps";
            this.cbResetCaps.Size = new System.Drawing.Size(72, 16);
            this.cbResetCaps.TabIndex = 2;
            this.cbResetCaps.Text = "CapsLock";
            this.cbResetCaps.UseVisualStyleBackColor = true;
            // 
            // cbResetAlt
            // 
            this.cbResetAlt.AutoSize = true;
            this.cbResetAlt.Checked = true;
            this.cbResetAlt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbResetAlt.Location = new System.Drawing.Point(102, 20);
            this.cbResetAlt.Name = "cbResetAlt";
            this.cbResetAlt.Size = new System.Drawing.Size(42, 16);
            this.cbResetAlt.TabIndex = 1;
            this.cbResetAlt.Text = "Alt";
            this.cbResetAlt.UseVisualStyleBackColor = true;
            // 
            // cbResetCtrl
            // 
            this.cbResetCtrl.AutoSize = true;
            this.cbResetCtrl.Location = new System.Drawing.Point(24, 20);
            this.cbResetCtrl.Name = "cbResetCtrl";
            this.cbResetCtrl.Size = new System.Drawing.Size(48, 16);
            this.cbResetCtrl.TabIndex = 0;
            this.cbResetCtrl.Text = "Ctrl";
            this.cbResetCtrl.UseVisualStyleBackColor = true;
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Location = new System.Drawing.Point(52, 131);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(35, 12);
            this.lblHello.TabIndex = 6;
            this.lblHello.Text = "Hello";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 194);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.gbReset);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.gbShutdown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快捷关机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbShutdown.ResumeLayout(false);
            this.gbShutdown.PerformLayout();
            this.cmsForNI.ResumeLayout(false);
            this.gbReset.ResumeLayout(false);
            this.gbReset.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbShutdown;
        private System.Windows.Forms.CheckBox cbShutCaps;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox gbReset;
        private System.Windows.Forms.CheckBox cbResetCaps;
        private System.Windows.Forms.CheckBox cbResetAlt;
        private System.Windows.Forms.CheckBox cbResetCtrl;
        private System.Windows.Forms.ContextMenuStrip cmsForNI;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.CheckBox cbShutAlt;
        private System.Windows.Forms.CheckBox cbShutCtrl;
    }
}

