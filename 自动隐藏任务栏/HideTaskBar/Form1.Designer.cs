namespace HideTaskBar
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
            this.tmHideBar = new System.Windows.Forms.Timer(this.components);
            this.cbxWork = new System.Windows.Forms.CheckBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowBar = new System.Windows.Forms.Button();
            this.dgvProcs = new System.Windows.Forms.DataGridView();
            this.proc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcs)).BeginInit();
            this.SuspendLayout();
            // 
            // tmHideBar
            // 
            this.tmHideBar.Interval = 2000;
            this.tmHideBar.Tick += new System.EventHandler(this.tmHideBar_Tick);
            // 
            // cbxWork
            // 
            this.cbxWork.AutoSize = true;
            this.cbxWork.Location = new System.Drawing.Point(465, 53);
            this.cbxWork.Name = "cbxWork";
            this.cbxWork.Size = new System.Drawing.Size(210, 16);
            this.cbxWork.TabIndex = 6;
            this.cbxWork.Text = "(&F)当运行以下进程时隐藏任务栏：";
            this.cbxWork.UseVisualStyleBackColor = true;
            this.cbxWork.CheckedChanged += new System.EventHandler(this.cbxWork_CheckedChanged);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colMatch});
            this.dgvMain.Location = new System.Drawing.Point(483, 79);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(339, 457);
            this.dgvMain.TabIndex = 7;
            this.dgvMain.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMain_CellMouseDoubleClick);
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(221, 15);
            this.nudInterval.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(53, 21);
            this.nudInterval.TabIndex = 10;
            this.nudInterval.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "监测间隔（秒）：";
            // 
            // btnShowBar
            // 
            this.btnShowBar.Location = new System.Drawing.Point(297, 12);
            this.btnShowBar.Name = "btnShowBar";
            this.btnShowBar.Size = new System.Drawing.Size(95, 23);
            this.btnShowBar.TabIndex = 12;
            this.btnShowBar.Text = "显示任务栏(&S)";
            this.btnShowBar.UseVisualStyleBackColor = true;
            this.btnShowBar.Click += new System.EventHandler(this.btnShowBar_Click);
            // 
            // dgvProcs
            // 
            this.dgvProcs.AllowUserToAddRows = false;
            this.dgvProcs.AllowUserToDeleteRows = false;
            this.dgvProcs.AllowUserToResizeRows = false;
            this.dgvProcs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proc_name});
            this.dgvProcs.Location = new System.Drawing.Point(-1, 75);
            this.dgvProcs.Name = "dgvProcs";
            this.dgvProcs.ReadOnly = true;
            this.dgvProcs.RowTemplate.Height = 23;
            this.dgvProcs.Size = new System.Drawing.Size(337, 460);
            this.dgvProcs.TabIndex = 13;
            this.dgvProcs.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProcs_CellMouseDoubleClick);
            // 
            // proc_name
            // 
            this.proc_name.DataPropertyName = "proc_name";
            this.proc_name.HeaderText = "proc_name";
            this.proc_name.Name = "proc_name";
            this.proc_name.ReadOnly = true;
            this.proc_name.Width = 200;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "colName";
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colMatch
            // 
            this.colMatch.DataPropertyName = "colMatch";
            this.colMatch.HeaderText = "匹配/包含";
            this.colMatch.Name = "colMatch";
            this.colMatch.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "双击左边添加到右边";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "双击右边移除";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 548);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvProcs);
            this.Controls.Add(this.btnShowBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.cbxWork);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置自动隐藏任务栏";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmHideBar;
        private System.Windows.Forms.CheckBox cbxWork;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowBar;
        private System.Windows.Forms.DataGridView dgvProcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn proc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

