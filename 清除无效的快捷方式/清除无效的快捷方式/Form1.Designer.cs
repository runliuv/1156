namespace 清除无效的快捷方式
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
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNot = new System.Windows.Forms.DataGridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.colFileFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRefFileOrDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(252, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(86, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始清除(&S)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "默认位置桌面";
            // 
            // dgvNot
            // 
            this.dgvNot.AllowUserToAddRows = false;
            this.dgvNot.AllowUserToDeleteRows = false;
            this.dgvNot.AllowUserToResizeRows = false;
            this.dgvNot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileFullName,
            this.colRefFileOrDir});
            this.dgvNot.Location = new System.Drawing.Point(5, 53);
            this.dgvNot.Name = "dgvNot";
            this.dgvNot.RowTemplate.Height = 23;
            this.dgvNot.Size = new System.Drawing.Size(714, 283);
            this.dgvNot.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(118, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(86, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "开始查找(&F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // colFileFullName
            // 
            this.colFileFullName.DataPropertyName = "FileFullName";
            this.colFileFullName.HeaderText = "无效的快捷方式";
            this.colFileFullName.Name = "colFileFullName";
            this.colFileFullName.ReadOnly = true;
            this.colFileFullName.Width = 300;
            // 
            // colRefFileOrDir
            // 
            this.colRefFileOrDir.DataPropertyName = "RefFileOrDir";
            this.colRefFileOrDir.HeaderText = "引用的位置或文件";
            this.colRefFileOrDir.Name = "colRefFileOrDir";
            this.colRefFileOrDir.ReadOnly = true;
            this.colRefFileOrDir.Width = 300;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 339);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.dgvNot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "清除无效的快捷方式";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNot;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRefFileOrDir;
    }
}

