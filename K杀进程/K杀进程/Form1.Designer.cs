namespace K杀进程
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
            this.btnKill = new System.Windows.Forms.Button();
            this.dgvProcs = new System.Windows.Forms.DataGridView();
            this.colProcNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtProcName = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.tmrCheck = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbxKillOnLoad = new System.Windows.Forms.CheckBox();
            this.tmrExit = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(403, 98);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(98, 41);
            this.btnKill.TabIndex = 0;
            this.btnKill.Text = "&K杀进程";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // dgvProcs
            // 
            this.dgvProcs.AllowUserToAddRows = false;
            this.dgvProcs.AllowUserToResizeRows = false;
            this.dgvProcs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProcNames});
            this.dgvProcs.Location = new System.Drawing.Point(21, 73);
            this.dgvProcs.Name = "dgvProcs";
            this.dgvProcs.ReadOnly = true;
            this.dgvProcs.RowHeadersVisible = false;
            this.dgvProcs.RowTemplate.Height = 23;
            this.dgvProcs.Size = new System.Drawing.Size(376, 150);
            this.dgvProcs.TabIndex = 1;
            // 
            // colProcNames
            // 
            this.colProcNames.HeaderText = "进程名";
            this.colProcNames.Name = "colProcNames";
            this.colProcNames.ReadOnly = true;
            this.colProcNames.Width = 1000;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(403, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&A添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtProcName
            // 
            this.txtProcName.Location = new System.Drawing.Point(21, 15);
            this.txtProcName.Name = "txtProcName";
            this.txtProcName.Size = new System.Drawing.Size(376, 21);
            this.txtProcName.TabIndex = 3;
            this.txtProcName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcName_KeyDown);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(403, 47);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "&D删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lbxLog
            // 
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.ItemHeight = 12;
            this.lbxLog.Location = new System.Drawing.Point(21, 229);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(376, 100);
            this.lbxLog.TabIndex = 5;
            // 
            // tmrCheck
            // 
            this.tmrCheck.Interval = 2000;
            this.tmrCheck.Tick += new System.EventHandler(this.tmrCheck_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "如果在进程中，将显示蓝色";
            // 
            // cbxKillOnLoad
            // 
            this.cbxKillOnLoad.AutoSize = true;
            this.cbxKillOnLoad.Location = new System.Drawing.Point(410, 158);
            this.cbxKillOnLoad.Name = "cbxKillOnLoad";
            this.cbxKillOnLoad.Size = new System.Drawing.Size(120, 16);
            this.cbxKillOnLoad.TabIndex = 7;
            this.cbxKillOnLoad.Text = "程序启动时杀一次";
            this.cbxKillOnLoad.UseVisualStyleBackColor = true;
            // 
            // tmrExit
            // 
            this.tmrExit.Interval = 1000;
            this.tmrExit.Tick += new System.EventHandler(this.tmrExit_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 352);
            this.Controls.Add(this.cbxKillOnLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtProcName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvProcs);
            this.Controls.Add(this.btnKill);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "halo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.DataGridView dgvProcs;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtProcName;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcNames;
        private System.Windows.Forms.Timer tmrCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxKillOnLoad;
        private System.Windows.Forms.Timer tmrExit;
    }
}

