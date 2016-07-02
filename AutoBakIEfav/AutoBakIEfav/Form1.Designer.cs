namespace AutoBakIEfav
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBakPath = new System.Windows.Forms.TextBox();
            this.btnChooseBak = new System.Windows.Forms.Button();
            this.btnBak = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurIEfavPath = new System.Windows.Forms.TextBox();
            this.nudAutoTime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmToAutoBak = new System.Windows.Forms.Timer(this.components);
            this.btnMinToTray = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxStartWhenWinStart = new System.Windows.Forms.CheckBox();
            this.cbxBeginBakWhenStart = new System.Windows.Forms.CheckBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.chkMinWhenStart = new System.Windows.Forms.CheckBox();
            this.chkSyncAfterBak = new System.Windows.Forms.CheckBox();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnOpenBak = new System.Windows.Forms.Button();
            this.btnOpenIEFav = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoTime)).BeginInit();
            this.cmsTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "备份位置";
            // 
            // txtBakPath
            // 
            this.txtBakPath.Location = new System.Drawing.Point(73, 54);
            this.txtBakPath.Name = "txtBakPath";
            this.txtBakPath.Size = new System.Drawing.Size(387, 21);
            this.txtBakPath.TabIndex = 2;
            // 
            // btnChooseBak
            // 
            this.btnChooseBak.Location = new System.Drawing.Point(466, 52);
            this.btnChooseBak.Name = "btnChooseBak";
            this.btnChooseBak.Size = new System.Drawing.Size(65, 23);
            this.btnChooseBak.TabIndex = 3;
            this.btnChooseBak.Text = "浏览(&B)";
            this.btnChooseBak.UseVisualStyleBackColor = true;
            this.btnChooseBak.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnBak
            // 
            this.btnBak.Location = new System.Drawing.Point(109, 94);
            this.btnBak.Name = "btnBak";
            this.btnBak.Size = new System.Drawing.Size(75, 23);
            this.btnBak.TabIndex = 4;
            this.btnBak.Text = "备份（&z）";
            this.btnBak.UseVisualStyleBackColor = true;
            this.btnBak.Click += new System.EventHandler(this.btnBak_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(224, 94);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 5;
            this.btnRestore.Text = "还原（&x）";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "IE收藏夹";
            // 
            // txtCurIEfavPath
            // 
            this.txtCurIEfavPath.Location = new System.Drawing.Point(73, 20);
            this.txtCurIEfavPath.Name = "txtCurIEfavPath";
            this.txtCurIEfavPath.ReadOnly = true;
            this.txtCurIEfavPath.Size = new System.Drawing.Size(458, 21);
            this.txtCurIEfavPath.TabIndex = 1;
            // 
            // nudAutoTime
            // 
            this.nudAutoTime.Location = new System.Drawing.Point(131, 137);
            this.nudAutoTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudAutoTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAutoTime.Name = "nudAutoTime";
            this.nudAutoTime.Size = new System.Drawing.Size(108, 21);
            this.nudAutoTime.TabIndex = 6;
            this.nudAutoTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "自动备份间隔(分钟)";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(268, 134);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(116, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始自动备份（&c）";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(390, 134);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(116, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "停止自动备份（&v）";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "自动备份状态";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(222, 178);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 12);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "label5";
            // 
            // tmToAutoBak
            // 
            this.tmToAutoBak.Interval = 1000;
            this.tmToAutoBak.Tick += new System.EventHandler(this.tmToAutoBak_Tick);
            // 
            // btnMinToTray
            // 
            this.btnMinToTray.Location = new System.Drawing.Point(390, 167);
            this.btnMinToTray.Name = "btnMinToTray";
            this.btnMinToTray.Size = new System.Drawing.Size(116, 23);
            this.btnMinToTray.TabIndex = 9;
            this.btnMinToTray.Text = "最小化到托盘（&m）";
            this.btnMinToTray.UseVisualStyleBackColor = true;
            this.btnMinToTray.Click += new System.EventHandler(this.btnMinToTray_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsTrayMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "IE BAK";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmsTrayMenu
            // 
            this.cmsTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiExit});
            this.cmsTrayMenu.Name = "cmsTrayMenu";
            this.cmsTrayMenu.Size = new System.Drawing.Size(113, 48);
            // 
            // tsmiView
            // 
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(112, 22);
            this.tsmiView.Text = "显示(&V)";
            this.tsmiView.Click += new System.EventHandler(this.tsmiView_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(112, 22);
            this.tsmiExit.Text = "退出(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // cbxStartWhenWinStart
            // 
            this.cbxStartWhenWinStart.AutoSize = true;
            this.cbxStartWhenWinStart.Location = new System.Drawing.Point(14, 221);
            this.cbxStartWhenWinStart.Name = "cbxStartWhenWinStart";
            this.cbxStartWhenWinStart.Size = new System.Drawing.Size(84, 16);
            this.cbxStartWhenWinStart.TabIndex = 10;
            this.cbxStartWhenWinStart.Text = "开机时启动";
            this.cbxStartWhenWinStart.UseVisualStyleBackColor = true;
            this.cbxStartWhenWinStart.CheckedChanged += new System.EventHandler(this.cbxStartWhenWinStart_CheckedChanged);
            // 
            // cbxBeginBakWhenStart
            // 
            this.cbxBeginBakWhenStart.AutoSize = true;
            this.cbxBeginBakWhenStart.Location = new System.Drawing.Point(143, 221);
            this.cbxBeginBakWhenStart.Name = "cbxBeginBakWhenStart";
            this.cbxBeginBakWhenStart.Size = new System.Drawing.Size(132, 16);
            this.cbxBeginBakWhenStart.TabIndex = 11;
            this.cbxBeginBakWhenStart.Text = "启动后开始自动备份";
            this.cbxBeginBakWhenStart.UseVisualStyleBackColor = true;
            this.cbxBeginBakWhenStart.CheckedChanged += new System.EventHandler(this.cbxBeginBakWhenStart_CheckedChanged);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(390, 201);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(116, 23);
            this.btnSaveConfig.TabIndex = 12;
            this.btnSaveConfig.Text = "保存配置（&s）";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // chkMinWhenStart
            // 
            this.chkMinWhenStart.AutoSize = true;
            this.chkMinWhenStart.Location = new System.Drawing.Point(14, 243);
            this.chkMinWhenStart.Name = "chkMinWhenStart";
            this.chkMinWhenStart.Size = new System.Drawing.Size(96, 16);
            this.chkMinWhenStart.TabIndex = 11;
            this.chkMinWhenStart.Text = "启动后最小化";
            this.chkMinWhenStart.UseVisualStyleBackColor = true;
            this.chkMinWhenStart.CheckedChanged += new System.EventHandler(this.chkMinWhenStart_CheckedChanged);
            // 
            // chkSyncAfterBak
            // 
            this.chkSyncAfterBak.AutoSize = true;
            this.chkSyncAfterBak.Location = new System.Drawing.Point(143, 243);
            this.chkSyncAfterBak.Name = "chkSyncAfterBak";
            this.chkSyncAfterBak.Size = new System.Drawing.Size(84, 16);
            this.chkSyncAfterBak.TabIndex = 13;
            this.chkSyncAfterBak.Text = "备份后同步";
            this.chkSyncAfterBak.UseVisualStyleBackColor = true;
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(345, 94);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 14;
            this.btnSync.Text = "同步（&s）";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnOpenBak
            // 
            this.btnOpenBak.Location = new System.Drawing.Point(546, 52);
            this.btnOpenBak.Name = "btnOpenBak";
            this.btnOpenBak.Size = new System.Drawing.Size(65, 23);
            this.btnOpenBak.TabIndex = 15;
            this.btnOpenBak.Text = "打开(&O)";
            this.btnOpenBak.UseVisualStyleBackColor = true;
            this.btnOpenBak.Click += new System.EventHandler(this.btnOpenBak_Click);
            // 
            // btnOpenIEFav
            // 
            this.btnOpenIEFav.Location = new System.Drawing.Point(546, 18);
            this.btnOpenIEFav.Name = "btnOpenIEFav";
            this.btnOpenIEFav.Size = new System.Drawing.Size(65, 23);
            this.btnOpenIEFav.TabIndex = 16;
            this.btnOpenIEFav.Text = "打开(&I)";
            this.btnOpenIEFav.UseVisualStyleBackColor = true;
            this.btnOpenIEFav.Click += new System.EventHandler(this.btnOpenIEFav_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 283);
            this.Controls.Add(this.btnOpenIEFav);
            this.Controls.Add(this.btnOpenBak);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.chkSyncAfterBak);
            this.Controls.Add(this.chkMinWhenStart);
            this.Controls.Add(this.cbxStartWhenWinStart);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.cbxBeginBakWhenStart);
            this.Controls.Add(this.btnMinToTray);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudAutoTime);
            this.Controls.Add(this.txtCurIEfavPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBak);
            this.Controls.Add(this.btnChooseBak);
            this.Controls.Add(this.txtBakPath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "备份IE收藏夹";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoTime)).EndInit();
            this.cmsTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBakPath;
        private System.Windows.Forms.Button btnChooseBak;
        private System.Windows.Forms.Button btnBak;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurIEfavPath;
        private System.Windows.Forms.NumericUpDown nudAutoTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmToAutoBak;
        private System.Windows.Forms.Button btnMinToTray;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmsTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.CheckBox cbxStartWhenWinStart;
        private System.Windows.Forms.CheckBox cbxBeginBakWhenStart;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.CheckBox chkMinWhenStart;
        private System.Windows.Forms.CheckBox chkSyncAfterBak;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnOpenBak;
        private System.Windows.Forms.Button btnOpenIEFav;
    }
}

