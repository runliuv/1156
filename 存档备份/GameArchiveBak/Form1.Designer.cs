namespace GameArchiveBak
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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.co_gdid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.co_DocDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.co_DocSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.co_DocTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.co_DocTargetFull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.co_IncludeSpecDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.co_SpecDirName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.cbxBeginBakWhenStart = new System.Windows.Forms.CheckBox();
            this.cbxStartWhenWinStart = new System.Windows.Forms.CheckBox();
            this.btnMinToTray = new System.Windows.Forms.Button();
            this.lblAutoBakStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAutoTime = new System.Windows.Forms.NumericUpDown();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBak = new System.Windows.Forms.Button();
            this.tmToAutoBak = new System.Windows.Forms.Timer(this.components);
            this.ninAB = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.gbOp = new System.Windows.Forms.GroupBox();
            this.txtBakFullPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBakMainDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestoreAll = new System.Windows.Forms.Button();
            this.btnBakAll = new System.Windows.Forms.Button();
            this.lblOpStatus = new System.Windows.Forms.Label();
            this.fbdBakMainDir = new System.Windows.Forms.FolderBrowserDialog();
            this.lbxMsg = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoTime)).BeginInit();
            this.cmsTrayMenu.SuspendLayout();
            this.gbOp.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.co_gdid,
            this.co_DocDescr,
            this.co_DocSource,
            this.co_DocTarget,
            this.co_DocTargetFull,
            this.co_IncludeSpecDir,
            this.co_SpecDirName});
            this.dgvMain.Location = new System.Drawing.Point(1, 2);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(989, 224);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.SelectionChanged += new System.EventHandler(this.dgvMain_SelectionChanged);
            // 
            // co_gdid
            // 
            this.co_gdid.DataPropertyName = "gdid";
            this.co_gdid.HeaderText = "gdid";
            this.co_gdid.Name = "co_gdid";
            this.co_gdid.ReadOnly = true;
            this.co_gdid.Visible = false;
            // 
            // co_DocDescr
            // 
            this.co_DocDescr.DataPropertyName = "DocDescr";
            this.co_DocDescr.HeaderText = "描述";
            this.co_DocDescr.Name = "co_DocDescr";
            this.co_DocDescr.ReadOnly = true;
            this.co_DocDescr.Width = 200;
            // 
            // co_DocSource
            // 
            this.co_DocSource.DataPropertyName = "DocSource";
            this.co_DocSource.HeaderText = "源目录";
            this.co_DocSource.Name = "co_DocSource";
            this.co_DocSource.ReadOnly = true;
            this.co_DocSource.Width = 200;
            // 
            // co_DocTarget
            // 
            this.co_DocTarget.DataPropertyName = "DocTarget";
            this.co_DocTarget.HeaderText = "当时备份主目录";
            this.co_DocTarget.Name = "co_DocTarget";
            this.co_DocTarget.ReadOnly = true;
            this.co_DocTarget.Width = 200;
            // 
            // co_DocTargetFull
            // 
            this.co_DocTargetFull.DataPropertyName = "DocTargetFull";
            this.co_DocTargetFull.HeaderText = "备份后的相对位置";
            this.co_DocTargetFull.Name = "co_DocTargetFull";
            this.co_DocTargetFull.ReadOnly = true;
            this.co_DocTargetFull.Width = 300;
            // 
            // co_IncludeSpecDir
            // 
            this.co_IncludeSpecDir.DataPropertyName = "IncludeSpecDir";
            this.co_IncludeSpecDir.HeaderText = "源目录是否包含特殊目录";
            this.co_IncludeSpecDir.Name = "co_IncludeSpecDir";
            this.co_IncludeSpecDir.ReadOnly = true;
            // 
            // co_SpecDirName
            // 
            this.co_SpecDirName.DataPropertyName = "SpecDirName";
            this.co_SpecDirName.HeaderText = "特殊目录名称";
            this.co_SpecDirName.Name = "co_SpecDirName";
            this.co_SpecDirName.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(23, 84);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(125, 84);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "编辑(&E)";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(223, 84);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "删除(&D)";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // cbxBeginBakWhenStart
            // 
            this.cbxBeginBakWhenStart.AutoSize = true;
            this.cbxBeginBakWhenStart.Location = new System.Drawing.Point(125, 188);
            this.cbxBeginBakWhenStart.Name = "cbxBeginBakWhenStart";
            this.cbxBeginBakWhenStart.Size = new System.Drawing.Size(132, 16);
            this.cbxBeginBakWhenStart.TabIndex = 21;
            this.cbxBeginBakWhenStart.Text = "启动后开始自动备份";
            this.cbxBeginBakWhenStart.UseVisualStyleBackColor = true;
            this.cbxBeginBakWhenStart.CheckedChanged += new System.EventHandler(this.cbxBeginBakWhenStart_CheckedChanged);
            // 
            // cbxStartWhenWinStart
            // 
            this.cbxStartWhenWinStart.AutoSize = true;
            this.cbxStartWhenWinStart.Location = new System.Drawing.Point(19, 188);
            this.cbxStartWhenWinStart.Name = "cbxStartWhenWinStart";
            this.cbxStartWhenWinStart.Size = new System.Drawing.Size(84, 16);
            this.cbxStartWhenWinStart.TabIndex = 20;
            this.cbxStartWhenWinStart.Text = "开机时启动";
            this.cbxStartWhenWinStart.UseVisualStyleBackColor = true;
            this.cbxStartWhenWinStart.CheckedChanged += new System.EventHandler(this.cbxStartWhenWinStart_CheckedChanged);
            // 
            // btnMinToTray
            // 
            this.btnMinToTray.Location = new System.Drawing.Point(201, 153);
            this.btnMinToTray.Name = "btnMinToTray";
            this.btnMinToTray.Size = new System.Drawing.Size(116, 23);
            this.btnMinToTray.TabIndex = 19;
            this.btnMinToTray.Text = "最小化到托盘(&M)";
            this.btnMinToTray.UseVisualStyleBackColor = true;
            this.btnMinToTray.Click += new System.EventHandler(this.btnMinToTray_Click);
            // 
            // lblAutoBakStatus
            // 
            this.lblAutoBakStatus.AutoSize = true;
            this.lblAutoBakStatus.Location = new System.Drawing.Point(123, 158);
            this.lblAutoBakStatus.Name = "lblAutoBakStatus";
            this.lblAutoBakStatus.Size = new System.Drawing.Size(47, 12);
            this.lblAutoBakStatus.TabIndex = 24;
            this.lblAutoBakStatus.Text = "AutoMsg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "自动备份状态：";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(323, 117);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(116, 23);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "停止自动备份(&P)";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(201, 117);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(116, 23);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "开始自动备份(&S)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "多少分钟自动备份";
            // 
            // nudAutoTime
            // 
            this.nudAutoTime.Location = new System.Drawing.Point(125, 121);
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
            this.nudAutoTime.Size = new System.Drawing.Size(68, 21);
            this.nudAutoTime.TabIndex = 15;
            this.nudAutoTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(576, 84);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 14;
            this.btnRestore.Text = "还原(&R)";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBak
            // 
            this.btnBak.Location = new System.Drawing.Point(340, 84);
            this.btnBak.Name = "btnBak";
            this.btnBak.Size = new System.Drawing.Size(75, 23);
            this.btnBak.TabIndex = 13;
            this.btnBak.Text = "备份(&B)";
            this.btnBak.UseVisualStyleBackColor = true;
            this.btnBak.Click += new System.EventHandler(this.btnBak_Click);
            // 
            // tmToAutoBak
            // 
            this.tmToAutoBak.Interval = 1000;
            // 
            // ninAB
            // 
            this.ninAB.ContextMenuStrip = this.cmsTrayMenu;
            this.ninAB.Icon = ((System.Drawing.Icon)(resources.GetObject("ninAB.Icon")));
            this.ninAB.Text = "IE BAK";
            this.ninAB.Visible = true;
            this.ninAB.DoubleClick += new System.EventHandler(this.ninAB_DoubleClick);
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
            // gbOp
            // 
            this.gbOp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOp.Controls.Add(this.lbxMsg);
            this.gbOp.Controls.Add(this.txtBakFullPath);
            this.gbOp.Controls.Add(this.label2);
            this.gbOp.Controls.Add(this.btnBrowse);
            this.gbOp.Controls.Add(this.txtBakMainDir);
            this.gbOp.Controls.Add(this.label1);
            this.gbOp.Controls.Add(this.btnRestoreAll);
            this.gbOp.Controls.Add(this.btnBakAll);
            this.gbOp.Controls.Add(this.lblOpStatus);
            this.gbOp.Controls.Add(this.btnStop);
            this.gbOp.Controls.Add(this.btnStart);
            this.gbOp.Controls.Add(this.btnMinToTray);
            this.gbOp.Controls.Add(this.label3);
            this.gbOp.Controls.Add(this.cbxBeginBakWhenStart);
            this.gbOp.Controls.Add(this.btnBak);
            this.gbOp.Controls.Add(this.cbxStartWhenWinStart);
            this.gbOp.Controls.Add(this.btnEdit);
            this.gbOp.Controls.Add(this.lblAutoBakStatus);
            this.gbOp.Controls.Add(this.btnDel);
            this.gbOp.Controls.Add(this.label4);
            this.gbOp.Controls.Add(this.btnAdd);
            this.gbOp.Controls.Add(this.nudAutoTime);
            this.gbOp.Controls.Add(this.btnRestore);
            this.gbOp.Location = new System.Drawing.Point(1, 232);
            this.gbOp.Name = "gbOp";
            this.gbOp.Size = new System.Drawing.Size(989, 241);
            this.gbOp.TabIndex = 25;
            this.gbOp.TabStop = false;
            this.gbOp.Text = "<>";
            // 
            // txtBakFullPath
            // 
            this.txtBakFullPath.Location = new System.Drawing.Point(104, 14);
            this.txtBakFullPath.Name = "txtBakFullPath";
            this.txtBakFullPath.ReadOnly = true;
            this.txtBakFullPath.Size = new System.Drawing.Size(666, 21);
            this.txtBakFullPath.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "完整路径：";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(695, 44);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 30;
            this.btnBrowse.Text = "浏览(&O)";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBakMainDir
            // 
            this.txtBakMainDir.Location = new System.Drawing.Point(104, 46);
            this.txtBakMainDir.Name = "txtBakMainDir";
            this.txtBakMainDir.Size = new System.Drawing.Size(585, 21);
            this.txtBakMainDir.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "备份主目录：";
            // 
            // btnRestoreAll
            // 
            this.btnRestoreAll.Location = new System.Drawing.Point(675, 84);
            this.btnRestoreAll.Name = "btnRestoreAll";
            this.btnRestoreAll.Size = new System.Drawing.Size(95, 23);
            this.btnRestoreAll.TabIndex = 27;
            this.btnRestoreAll.Text = "还原所有(&T)";
            this.btnRestoreAll.UseVisualStyleBackColor = true;
            this.btnRestoreAll.Click += new System.EventHandler(this.btnRestoreAll_Click);
            // 
            // btnBakAll
            // 
            this.btnBakAll.Location = new System.Drawing.Point(450, 84);
            this.btnBakAll.Name = "btnBakAll";
            this.btnBakAll.Size = new System.Drawing.Size(96, 23);
            this.btnBakAll.TabIndex = 26;
            this.btnBakAll.Text = "全部备份(&L)";
            this.btnBakAll.UseVisualStyleBackColor = true;
            this.btnBakAll.Click += new System.EventHandler(this.btnBakAll_Click);
            // 
            // lblOpStatus
            // 
            this.lblOpStatus.AutoSize = true;
            this.lblOpStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOpStatus.Location = new System.Drawing.Point(20, 217);
            this.lblOpStatus.Name = "lblOpStatus";
            this.lblOpStatus.Size = new System.Drawing.Size(56, 16);
            this.lblOpStatus.TabIndex = 25;
            this.lblOpStatus.Text = "Status";
            // 
            // lbxMsg
            // 
            this.lbxMsg.FormattingEnabled = true;
            this.lbxMsg.ItemHeight = 12;
            this.lbxMsg.Location = new System.Drawing.Point(450, 110);
            this.lbxMsg.Name = "lbxMsg";
            this.lbxMsg.Size = new System.Drawing.Size(533, 124);
            this.lbxMsg.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 474);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.gbOp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "存档备份(archives backup)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoTime)).EndInit();
            this.cmsTrayMenu.ResumeLayout(false);
            this.gbOp.ResumeLayout(false);
            this.gbOp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.CheckBox cbxBeginBakWhenStart;
        private System.Windows.Forms.CheckBox cbxStartWhenWinStart;
        private System.Windows.Forms.Button btnMinToTray;
        private System.Windows.Forms.Label lblAutoBakStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAutoTime;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBak;
        private System.Windows.Forms.Timer tmToAutoBak;
        private System.Windows.Forms.NotifyIcon ninAB;
        private System.Windows.Forms.ContextMenuStrip cmsTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.GroupBox gbOp;
        private System.Windows.Forms.Label lblOpStatus;
        private System.Windows.Forms.Button btnBakAll;
        private System.Windows.Forms.Button btnRestoreAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBakMainDir;
        private System.Windows.Forms.FolderBrowserDialog fbdBakMainDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn co_gdid;
        private System.Windows.Forms.DataGridViewTextBoxColumn co_DocDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn co_DocSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn co_DocTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn co_DocTargetFull;
        private System.Windows.Forms.DataGridViewTextBoxColumn co_IncludeSpecDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn co_SpecDirName;
        private System.Windows.Forms.TextBox txtBakFullPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxMsg;
    }
}

