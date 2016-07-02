namespace 重命名桌面快捷方式
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbxMsg = new System.Windows.Forms.ListBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.btnRename = new System.Windows.Forms.Button();
            this.colMainId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colisspec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colspecname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnewname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "如：“酷狗\"重命名为”K酷狗\"，便于快捷访问";
            // 
            // lbxMsg
            // 
            this.lbxMsg.FormattingEnabled = true;
            this.lbxMsg.ItemHeight = 12;
            this.lbxMsg.Location = new System.Drawing.Point(1, 387);
            this.lbxMsg.Name = "lbxMsg";
            this.lbxMsg.Size = new System.Drawing.Size(1004, 88);
            this.lbxMsg.TabIndex = 1;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMainId,
            this.colisspec,
            this.colspecname,
            this.colpath,
            this.colnewname});
            this.dgvMain.Location = new System.Drawing.Point(1, 69);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(1004, 312);
            this.dgvMain.TabIndex = 2;
            this.dgvMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMain_KeyDown);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(242, 40);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 3;
            this.btnRename.Text = "重命名(&R)";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // colMainId
            // 
            this.colMainId.DataPropertyName = "MainId";
            this.colMainId.HeaderText = "MainId";
            this.colMainId.Name = "colMainId";
            this.colMainId.ReadOnly = true;
            this.colMainId.Visible = false;
            // 
            // colisspec
            // 
            this.colisspec.DataPropertyName = "isspec";
            this.colisspec.HeaderText = "特殊目录";
            this.colisspec.Name = "colisspec";
            this.colisspec.ReadOnly = true;
            // 
            // colspecname
            // 
            this.colspecname.DataPropertyName = "specname";
            this.colspecname.HeaderText = "特殊目录名";
            this.colspecname.Name = "colspecname";
            this.colspecname.ReadOnly = true;
            // 
            // colpath
            // 
            this.colpath.DataPropertyName = "fullpath";
            this.colpath.HeaderText = "路径";
            this.colpath.Name = "colpath";
            this.colpath.ReadOnly = true;
            this.colpath.Width = 300;
            // 
            // colnewname
            // 
            this.colnewname.DataPropertyName = "newname";
            this.colnewname.HeaderText = "新名";
            this.colnewname.Name = "colnewname";
            this.colnewname.ReadOnly = true;
            this.colnewname.Width = 250;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 478);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.lbxMsg);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxMsg;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMainId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colisspec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colspecname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnewname;
    }
}

