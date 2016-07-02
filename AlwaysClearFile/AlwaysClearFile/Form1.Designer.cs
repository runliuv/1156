namespace AlwaysClearFile
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.Col_MainId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_IncludeSpecDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_SpecDirName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_FullPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxOp = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.gbxOp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 122);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 12);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "状态";
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
            this.Col_MainId,
            this.Col_IncludeSpecDir,
            this.Col_SpecDirName,
            this.Col_FullPath});
            this.dgvMain.Location = new System.Drawing.Point(1, 137);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(868, 373);
            this.dgvMain.TabIndex = 2;
            // 
            // Col_MainId
            // 
            this.Col_MainId.DataPropertyName = "MainId";
            this.Col_MainId.HeaderText = "MainId";
            this.Col_MainId.Name = "Col_MainId";
            this.Col_MainId.ReadOnly = true;
            this.Col_MainId.Visible = false;
            // 
            // Col_IncludeSpecDir
            // 
            this.Col_IncludeSpecDir.DataPropertyName = "IncludeSpecDir";
            this.Col_IncludeSpecDir.HeaderText = "IncludeSpecDir";
            this.Col_IncludeSpecDir.Name = "Col_IncludeSpecDir";
            this.Col_IncludeSpecDir.ReadOnly = true;
            // 
            // Col_SpecDirName
            // 
            this.Col_SpecDirName.DataPropertyName = "SpecDirName";
            this.Col_SpecDirName.HeaderText = "SpecDirName";
            this.Col_SpecDirName.Name = "Col_SpecDirName";
            this.Col_SpecDirName.ReadOnly = true;
            // 
            // Col_FullPath
            // 
            this.Col_FullPath.DataPropertyName = "FullPath";
            this.Col_FullPath.HeaderText = "FullPath";
            this.Col_FullPath.Name = "Col_FullPath";
            this.Col_FullPath.ReadOnly = true;
            this.Col_FullPath.Width = 600;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(162, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清理(&C)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Location = new System.Drawing.Point(15, 20);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(97, 23);
            this.btnDelRow.TabIndex = 3;
            this.btnDelRow.Text = "删除行(&R)";
            this.btnDelRow.UseVisualStyleBackColor = true;
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "直接把要经常清理的文件/文件夹往上面拖";
            // 
            // gbxOp
            // 
            this.gbxOp.Controls.Add(this.btnClear);
            this.gbxOp.Controls.Add(this.btnDelRow);
            this.gbxOp.Location = new System.Drawing.Point(32, 64);
            this.gbxOp.Name = "gbxOp";
            this.gbxOp.Size = new System.Drawing.Size(283, 55);
            this.gbxOp.TabIndex = 7;
            this.gbxOp.TabStop = false;
            this.gbxOp.Text = "操作";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "重要东西可别拖进来，删除不经过回收站。用来清理烦人的快捷方式比较不错。";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 513);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbxOp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件/目录 清理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.gbxOp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelRow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_MainId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_IncludeSpecDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_SpecDirName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_FullPath;
        private System.Windows.Forms.Label label2;
    }
}

