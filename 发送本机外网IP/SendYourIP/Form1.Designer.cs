namespace SendYourIP
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
            this.btnGet = new System.Windows.Forms.Button();
            this.lblRst = new System.Windows.Forms.Label();
            this.tmAutoSend = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtMailTo = new System.Windows.Forms.TextBox();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxStartWhenWinStart = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSMTP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSenderPwd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSenderUName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSenderAddr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ninTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiExit2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.nudCheck = new System.Windows.Forms.NumericUpDown();
            this.chkMinWhenStart = new System.Windows.Forms.CheckBox();
            this.gbxLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.cmsTray.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheck)).BeginInit();
            this.gbxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(435, 74);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(116, 23);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "(&S)获取IP并发送";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // lblRst
            // 
            this.lblRst.AutoSize = true;
            this.lblRst.Location = new System.Drawing.Point(566, 79);
            this.lblRst.Name = "lblRst";
            this.lblRst.Size = new System.Drawing.Size(29, 12);
            this.lblRst.TabIndex = 1;
            this.lblRst.Text = "状态";
            // 
            // tmAutoSend
            // 
            this.tmAutoSend.Interval = 1000;
            this.tmAutoSend.Tick += new System.EventHandler(this.tmAutoSend_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "收件人";
            // 
            // txtMailTo
            // 
            this.txtMailTo.Location = new System.Drawing.Point(53, 68);
            this.txtMailTo.Multiline = true;
            this.txtMailTo.Name = "txtMailTo";
            this.txtMailTo.Size = new System.Drawing.Size(349, 37);
            this.txtMailTo.TabIndex = 3;
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(114, 33);
            this.nudInterval.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(74, 21);
            this.nudInterval.TabIndex = 7;
            this.nudInterval.Value = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "发送间隔（秒）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "标题";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(41, 24);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(315, 21);
            this.txtTitle.TabIndex = 10;
            this.txtTitle.Text = "我的外网IP：";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(41, 51);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(315, 61);
            this.txtContent.TabIndex = 13;
            this.txtContent.Text = "没有内容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "内容";
            // 
            // cbxStartWhenWinStart
            // 
            this.cbxStartWhenWinStart.AutoSize = true;
            this.cbxStartWhenWinStart.Location = new System.Drawing.Point(449, 35);
            this.cbxStartWhenWinStart.Name = "cbxStartWhenWinStart";
            this.cbxStartWhenWinStart.Size = new System.Drawing.Size(102, 16);
            this.cbxStartWhenWinStart.TabIndex = 14;
            this.cbxStartWhenWinStart.Text = "开机时启动(&1)";
            this.cbxStartWhenWinStart.UseVisualStyleBackColor = true;
            this.cbxStartWhenWinStart.CheckedChanged += new System.EventHandler(this.cbxStartWhenWinStart_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtTitle);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtContent);
            this.groupBox3.Location = new System.Drawing.Point(12, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 133);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "信附加内容";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSMTP);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtSenderPwd);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtSenderUName);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtSenderAddr);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(12, 265);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(364, 149);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发件人地址配置";
            // 
            // txtSMTP
            // 
            this.txtSMTP.Location = new System.Drawing.Point(86, 117);
            this.txtSMTP.Name = "txtSMTP";
            this.txtSMTP.Size = new System.Drawing.Size(270, 21);
            this.txtSMTP.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "smtp";
            // 
            // txtSenderPwd
            // 
            this.txtSenderPwd.Location = new System.Drawing.Point(86, 85);
            this.txtSenderPwd.Name = "txtSenderPwd";
            this.txtSenderPwd.PasswordChar = '*';
            this.txtSenderPwd.Size = new System.Drawing.Size(270, 21);
            this.txtSenderPwd.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "密码";
            // 
            // txtSenderUName
            // 
            this.txtSenderUName.Location = new System.Drawing.Point(86, 55);
            this.txtSenderUName.Name = "txtSenderUName";
            this.txtSenderUName.Size = new System.Drawing.Size(270, 21);
            this.txtSenderUName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "用户名";
            // 
            // txtSenderAddr
            // 
            this.txtSenderAddr.Location = new System.Drawing.Point(86, 23);
            this.txtSenderAddr.Name = "txtSenderAddr";
            this.txtSenderAddr.Size = new System.Drawing.Size(270, 21);
            this.txtSenderAddr.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "发件人地址";
            // 
            // ninTray
            // 
            this.ninTray.ContextMenuStrip = this.cmsTray;
            this.ninTray.Icon = ((System.Drawing.Icon)(resources.GetObject("ninTray.Icon")));
            this.ninTray.Text = "发送本机外网IP";
            this.ninTray.Visible = true;
            this.ninTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ninTray_MouseDoubleClick);
            // 
            // cmsTray
            // 
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShow,
            this.tsmiExit});
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.Size = new System.Drawing.Size(141, 48);
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(140, 22);
            this.tsmiShow.Text = "显示程序(&V)";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(140, 22);
            this.tsmiExit.Text = "退出程序(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit2,
            this.tsmiAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 25);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiExit2
            // 
            this.tsmiExit2.Name = "tsmiExit2";
            this.tsmiExit2.Size = new System.Drawing.Size(60, 21);
            this.tsmiExit2.Text = "退出(&X)";
            this.tsmiExit2.Click += new System.EventHandler(this.tsmiExit2_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(60, 21);
            this.tsmiAbout.Text = "关于(&A)";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "检查IP变更间隔（秒）";
            // 
            // nudCheck
            // 
            this.nudCheck.Location = new System.Drawing.Point(352, 33);
            this.nudCheck.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCheck.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCheck.Name = "nudCheck";
            this.nudCheck.Size = new System.Drawing.Size(74, 21);
            this.nudCheck.TabIndex = 24;
            this.nudCheck.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // chkMinWhenStart
            // 
            this.chkMinWhenStart.AutoSize = true;
            this.chkMinWhenStart.Location = new System.Drawing.Point(557, 35);
            this.chkMinWhenStart.Name = "chkMinWhenStart";
            this.chkMinWhenStart.Size = new System.Drawing.Size(114, 16);
            this.chkMinWhenStart.TabIndex = 26;
            this.chkMinWhenStart.Text = "启动后最小化(&2)";
            this.chkMinWhenStart.UseVisualStyleBackColor = true;
            // 
            // gbxLog
            // 
            this.gbxLog.Controls.Add(this.txtLog);
            this.gbxLog.Location = new System.Drawing.Point(423, 126);
            this.gbxLog.Name = "gbxLog";
            this.gbxLog.Size = new System.Drawing.Size(374, 335);
            this.gbxLog.TabIndex = 27;
            this.gbxLog.TabStop = false;
            this.gbxLog.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 20);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(362, 309);
            this.txtLog.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 473);
            this.Controls.Add(this.gbxLog);
            this.Controls.Add(this.chkMinWhenStart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtMailTo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxStartWhenWinStart);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lblRst);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "把外网IP发送到邮箱";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.cmsTray.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheck)).EndInit();
            this.gbxLog.ResumeLayout(false);
            this.gbxLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblRst;
        private System.Windows.Forms.Timer tmAutoSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMailTo;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxStartWhenWinStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSenderAddr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSenderPwd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSenderUName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NotifyIcon ninTray;
        private System.Windows.Forms.ContextMenuStrip cmsTray;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit2;
        private System.Windows.Forms.TextBox txtSMTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudCheck;
        private System.Windows.Forms.CheckBox chkMinWhenStart;
        private System.Windows.Forms.GroupBox gbxLog;
        private System.Windows.Forms.TextBox txtLog;
    }
}

