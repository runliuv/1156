namespace 设置JavaHome
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
            this.btnBro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJdk = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.dgvKey = new System.Windows.Forms.DataGridView();
            this.ColKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvValue = new System.Windows.Forms.DataGridView();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.lblMsg = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSetASDK = new System.Windows.Forms.Button();
            this.txtASDK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBroASDK = new System.Windows.Forms.Button();
            this.fbdASDK = new System.Windows.Forms.FolderBrowserDialog();
            this.txtValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValue)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBro
            // 
            this.btnBro.Location = new System.Drawing.Point(502, 14);
            this.btnBro.Name = "btnBro";
            this.btnBro.Size = new System.Drawing.Size(75, 23);
            this.btnBro.TabIndex = 0;
            this.btnBro.Text = "浏览(&B)";
            this.btnBro.UseVisualStyleBackColor = true;
            this.btnBro.Click += new System.EventHandler(this.btnBro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择JDK目录";
            // 
            // txtJdk
            // 
            this.txtJdk.Location = new System.Drawing.Point(162, 17);
            this.txtJdk.Name = "txtJdk";
            this.txtJdk.Size = new System.Drawing.Size(334, 21);
            this.txtJdk.TabIndex = 2;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(583, 15);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 3;
            this.btnSet.Text = "设置(&S)";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // dgvKey
            // 
            this.dgvKey.AllowUserToAddRows = false;
            this.dgvKey.AllowUserToDeleteRows = false;
            this.dgvKey.AllowUserToResizeRows = false;
            this.dgvKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColKey});
            this.dgvKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKey.Location = new System.Drawing.Point(0, 0);
            this.dgvKey.MultiSelect = false;
            this.dgvKey.Name = "dgvKey";
            this.dgvKey.RowHeadersVisible = false;
            this.dgvKey.RowTemplate.Height = 23;
            this.dgvKey.Size = new System.Drawing.Size(153, 434);
            this.dgvKey.TabIndex = 4;
            this.dgvKey.SelectionChanged += new System.EventHandler(this.dgvKey_SelectionChanged);
            // 
            // ColKey
            // 
            this.ColKey.HeaderText = "变量名";
            this.ColKey.Name = "ColKey";
            this.ColKey.ReadOnly = true;
            this.ColKey.Width = 200;
            // 
            // dgvValue
            // 
            this.dgvValue.AllowUserToAddRows = false;
            this.dgvValue.AllowUserToDeleteRows = false;
            this.dgvValue.AllowUserToResizeRows = false;
            this.dgvValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColValue});
            this.dgvValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValue.Location = new System.Drawing.Point(0, 0);
            this.dgvValue.Name = "dgvValue";
            this.dgvValue.RowHeadersVisible = false;
            this.dgvValue.RowTemplate.Height = 23;
            this.dgvValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValue.Size = new System.Drawing.Size(622, 434);
            this.dgvValue.TabIndex = 5;
            this.dgvValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvValue_KeyUp);
            // 
            // ColValue
            // 
            this.ColValue.HeaderText = "值";
            this.ColValue.Name = "ColValue";
            this.ColValue.ReadOnly = true;
            this.ColValue.Width = 700;
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.Location = new System.Drawing.Point(3, 126);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.dgvKey);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.dgvValue);
            this.spcMain.Size = new System.Drawing.Size(779, 434);
            this.spcMain.SplitterDistance = 153;
            this.spcMain.TabIndex = 6;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(160, 80);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(29, 12);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "消息";
            // 
            // btnSetASDK
            // 
            this.btnSetASDK.Location = new System.Drawing.Point(583, 42);
            this.btnSetASDK.Name = "btnSetASDK";
            this.btnSetASDK.Size = new System.Drawing.Size(75, 23);
            this.btnSetASDK.TabIndex = 11;
            this.btnSetASDK.Text = "设置(&2)";
            this.btnSetASDK.UseVisualStyleBackColor = true;
            this.btnSetASDK.Click += new System.EventHandler(this.btnSetASDK_Click);
            // 
            // txtASDK
            // 
            this.txtASDK.Location = new System.Drawing.Point(162, 44);
            this.txtASDK.Name = "txtASDK";
            this.txtASDK.Size = new System.Drawing.Size(334, 21);
            this.txtASDK.TabIndex = 10;
            this.txtASDK.Leave += new System.EventHandler(this.txtASDK_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "选择ANDROID SDK主目录";
            // 
            // btnBroASDK
            // 
            this.btnBroASDK.Location = new System.Drawing.Point(502, 41);
            this.btnBroASDK.Name = "btnBroASDK";
            this.btnBroASDK.Size = new System.Drawing.Size(75, 23);
            this.btnBroASDK.TabIndex = 8;
            this.btnBroASDK.Text = "浏览(&1)";
            this.btnBroASDK.UseVisualStyleBackColor = true;
            this.btnBroASDK.Click += new System.EventHandler(this.btnBroASDK_Click);
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(3, 99);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(779, 21);
            this.txtValue.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnSetASDK);
            this.Controls.Add(this.txtASDK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBroASDK);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.txtJdk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置JAVA_HOME";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
             
            ((System.ComponentModel.ISupportInitialize)(this.dgvKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValue)).EndInit();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJdk;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.DataGridView dgvKey;
        private System.Windows.Forms.DataGridView dgvValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSetASDK;
        private System.Windows.Forms.TextBox txtASDK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBroASDK;
        private System.Windows.Forms.FolderBrowserDialog fbdASDK;
        private System.Windows.Forms.TextBox txtValue;
    }
}

