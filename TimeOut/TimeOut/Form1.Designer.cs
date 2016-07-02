namespace TimeOut
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
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ninMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToTray = new System.Windows.Forms.Button();
            this.tmrToTip = new System.Windows.Forms.Timer(this.components);
            this.lblHad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblM = new System.Windows.Forms.Label();
            this.lblF = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkOnSysStart = new System.Windows.Forms.CheckBox();
            this.chkLeftShow = new System.Windows.Forms.CheckBox();
            this.chkMinToTray = new System.Windows.Forms.CheckBox();
            this.chkClosetToTray = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(183, 74);
            this.nudCount.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(120, 21);
            this.nudCount.TabIndex = 0;
            this.nudCount.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "定时提醒(分)";
            // 
            // ninMain
            // 
            this.ninMain.ContextMenuStrip = this.cmsTray;
            this.ninMain.Icon = ((System.Drawing.Icon)(resources.GetObject("ninMain.Icon")));
            this.ninMain.Text = "Time Out";
            this.ninMain.Visible = true;
            this.ninMain.DoubleClick += new System.EventHandler(this.ninMain_DoubleClick);
            // 
            // cmsTray
            // 
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.Size = new System.Drawing.Size(117, 26);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(116, 22);
            this.tsmiExit.Text = "退出(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // btnToTray
            // 
            this.btnToTray.Location = new System.Drawing.Point(213, 155);
            this.btnToTray.Name = "btnToTray";
            this.btnToTray.Size = new System.Drawing.Size(116, 23);
            this.btnToTray.TabIndex = 2;
            this.btnToTray.Text = "最小化到托盘(&S)";
            this.btnToTray.UseVisualStyleBackColor = true;
            this.btnToTray.Click += new System.EventHandler(this.btnToTray_Click);
            // 
            // tmrToTip
            // 
            this.tmrToTip.Interval = 1000;
            this.tmrToTip.Tick += new System.EventHandler(this.tmrToTip_Tick);
            // 
            // lblHad
            // 
            this.lblHad.AutoSize = true;
            this.lblHad.Location = new System.Drawing.Point(37, 24);
            this.lblHad.Name = "lblHad";
            this.lblHad.Size = new System.Drawing.Size(41, 12);
            this.lblHad.TabIndex = 3;
            this.lblHad.Text = "已进行";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "秒";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "分";
            // 
            // lblM
            // 
            this.lblM.AutoSize = true;
            this.lblM.Location = new System.Drawing.Point(114, 24);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(11, 12);
            this.lblM.TabIndex = 6;
            this.lblM.Text = "m";
            this.lblM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblF
            // 
            this.lblF.AutoSize = true;
            this.lblF.Location = new System.Drawing.Point(114, 47);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(11, 12);
            this.lblF.TabIndex = 7;
            this.lblF.Text = "f";
            this.lblF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(28, 155);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "重置计时(&R)";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chkOnSysStart
            // 
            this.chkOnSysStart.AutoSize = true;
            this.chkOnSysStart.Location = new System.Drawing.Point(4, 107);
            this.chkOnSysStart.Name = "chkOnSysStart";
            this.chkOnSysStart.Size = new System.Drawing.Size(102, 16);
            this.chkOnSysStart.TabIndex = 9;
            this.chkOnSysStart.Text = "开机时启动(&D)";
            this.chkOnSysStart.UseVisualStyleBackColor = true;
            this.chkOnSysStart.CheckedChanged += new System.EventHandler(this.chkOnSysStart_CheckedChanged);
            // 
            // chkLeftShow
            // 
            this.chkLeftShow.AutoSize = true;
            this.chkLeftShow.Location = new System.Drawing.Point(168, 107);
            this.chkLeftShow.Name = "chkLeftShow";
            this.chkLeftShow.Size = new System.Drawing.Size(126, 16);
            this.chkLeftShow.TabIndex = 10;
            this.chkLeftShow.Text = "左下角弹出窗口(&L)";
            this.chkLeftShow.UseVisualStyleBackColor = true;
            // 
            // chkMinToTray
            // 
            this.chkMinToTray.AutoSize = true;
            this.chkMinToTray.Location = new System.Drawing.Point(4, 133);
            this.chkMinToTray.Name = "chkMinToTray";
            this.chkMinToTray.Size = new System.Drawing.Size(150, 16);
            this.chkMinToTray.TabIndex = 11;
            this.chkMinToTray.Text = "启动后最小化到托盘(&M)";
            this.chkMinToTray.UseVisualStyleBackColor = true;
            // 
            // chkClosetToTray
            // 
            this.chkClosetToTray.AutoSize = true;
            this.chkClosetToTray.Location = new System.Drawing.Point(168, 133);
            this.chkClosetToTray.Name = "chkClosetToTray";
            this.chkClosetToTray.Size = new System.Drawing.Size(198, 16);
            this.chkClosetToTray.TabIndex = 12;
            this.chkClosetToTray.Text = "点击关闭按钮时最小化到托盘(&A)";
            this.chkClosetToTray.UseVisualStyleBackColor = true;
            this.chkClosetToTray.CheckedChanged += new System.EventHandler(this.chkClosetToTray_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 190);
            this.Controls.Add(this.chkClosetToTray);
            this.Controls.Add(this.chkMinToTray);
            this.Controls.Add(this.chkLeftShow);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblF);
            this.Controls.Add(this.lblM);
            this.Controls.Add(this.chkOnSysStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHad);
            this.Controls.Add(this.btnToTray);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudCount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超时";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon ninMain;
        private System.Windows.Forms.Button btnToTray;
        private System.Windows.Forms.Timer tmrToTip;
        private System.Windows.Forms.Label lblHad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkOnSysStart;
        private System.Windows.Forms.ContextMenuStrip cmsTray;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.CheckBox chkLeftShow;
        private System.Windows.Forms.CheckBox chkMinToTray;
        private System.Windows.Forms.CheckBox chkClosetToTray;
    }
}

