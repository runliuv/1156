namespace FindMusic
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFindPath = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.ColumnFileFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtCopyTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbExt = new System.Windows.Forms.ListBox();
            this.btnAddExt = new System.Windows.Forms.Button();
            this.btnDelExt = new System.Windows.Forms.Button();
            this.txtExt = new System.Windows.Forms.TextBox();
            this.cbxBiggerThan = new System.Windows.Forms.CheckBox();
            this.txtBiggerThan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStopCopy = new System.Windows.Forms.Button();
            this.txtExclude = new System.Windows.Forms.TextBox();
            this.btnDelExclude = new System.Windows.Forms.Button();
            this.btnAddExclude = new System.Windows.Forms.Button();
            this.lbExclude = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbFindDir = new System.Windows.Forms.ListBox();
            this.btnAddDir = new System.Windows.Forms.Button();
            this.btnDelDir = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDelC2 = new System.Windows.Forms.Button();
            this.btnStopC2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFindC2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindSameInTwo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找指定位置的音乐文件，可以复制到指定的位置";
            // 
            // txtFindPath
            // 
            this.txtFindPath.Location = new System.Drawing.Point(6, 20);
            this.txtFindPath.Name = "txtFindPath";
            this.txtFindPath.Size = new System.Drawing.Size(261, 21);
            this.txtFindPath.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(344, 338);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "查找（&f）";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFileFullName});
            this.dgvMain.Location = new System.Drawing.Point(11, 404);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(984, 314);
            this.dgvMain.TabIndex = 4;
            // 
            // ColumnFileFullName
            // 
            this.ColumnFileFullName.HeaderText = "文件";
            this.ColumnFileFullName.Name = "ColumnFileFullName";
            this.ColumnFileFullName.ReadOnly = true;
            this.ColumnFileFullName.Width = 900;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(440, 338);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止（&s）";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtCopyTo
            // 
            this.txtCopyTo.Location = new System.Drawing.Point(132, 375);
            this.txtCopyTo.Name = "txtCopyTo";
            this.txtCopyTo.Size = new System.Drawing.Size(474, 21);
            this.txtCopyTo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "把选择的文件复制到";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(621, 375);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(119, 23);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "复制到指定位置（&c）";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(12, 35);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 12);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "状态";
            // 
            // lbExt
            // 
            this.lbExt.FormattingEnabled = true;
            this.lbExt.ItemHeight = 12;
            this.lbExt.Location = new System.Drawing.Point(6, 20);
            this.lbExt.Name = "lbExt";
            this.lbExt.Size = new System.Drawing.Size(120, 88);
            this.lbExt.TabIndex = 10;
            // 
            // btnAddExt
            // 
            this.btnAddExt.Location = new System.Drawing.Point(133, 53);
            this.btnAddExt.Name = "btnAddExt";
            this.btnAddExt.Size = new System.Drawing.Size(76, 23);
            this.btnAddExt.TabIndex = 11;
            this.btnAddExt.Text = "添加";
            this.btnAddExt.UseVisualStyleBackColor = true;
            this.btnAddExt.Click += new System.EventHandler(this.btnAddExt_Click);
            // 
            // btnDelExt
            // 
            this.btnDelExt.Location = new System.Drawing.Point(133, 82);
            this.btnDelExt.Name = "btnDelExt";
            this.btnDelExt.Size = new System.Drawing.Size(76, 23);
            this.btnDelExt.TabIndex = 12;
            this.btnDelExt.Text = "删除";
            this.btnDelExt.UseVisualStyleBackColor = true;
            this.btnDelExt.Click += new System.EventHandler(this.btnDelExt_Click);
            // 
            // txtExt
            // 
            this.txtExt.Location = new System.Drawing.Point(133, 20);
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(100, 21);
            this.txtExt.TabIndex = 13;
            // 
            // cbxBiggerThan
            // 
            this.cbxBiggerThan.AutoSize = true;
            this.cbxBiggerThan.Location = new System.Drawing.Point(6, 22);
            this.cbxBiggerThan.Name = "cbxBiggerThan";
            this.cbxBiggerThan.Size = new System.Drawing.Size(72, 16);
            this.cbxBiggerThan.TabIndex = 14;
            this.cbxBiggerThan.Text = "文件大于";
            this.cbxBiggerThan.UseVisualStyleBackColor = true;
            // 
            // txtBiggerThan
            // 
            this.txtBiggerThan.Location = new System.Drawing.Point(94, 20);
            this.txtBiggerThan.Name = "txtBiggerThan";
            this.txtBiggerThan.Size = new System.Drawing.Size(100, 21);
            this.txtBiggerThan.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "KB";
            // 
            // btnStopCopy
            // 
            this.btnStopCopy.Location = new System.Drawing.Point(781, 375);
            this.btnStopCopy.Name = "btnStopCopy";
            this.btnStopCopy.Size = new System.Drawing.Size(75, 23);
            this.btnStopCopy.TabIndex = 17;
            this.btnStopCopy.Text = "停止（&p）";
            this.btnStopCopy.UseVisualStyleBackColor = true;
            this.btnStopCopy.Click += new System.EventHandler(this.btnStopCopy_Click);
            // 
            // txtExclude
            // 
            this.txtExclude.Location = new System.Drawing.Point(6, 19);
            this.txtExclude.Name = "txtExclude";
            this.txtExclude.Size = new System.Drawing.Size(379, 21);
            this.txtExclude.TabIndex = 23;
            // 
            // btnDelExclude
            // 
            this.btnDelExclude.Location = new System.Drawing.Point(330, 80);
            this.btnDelExclude.Name = "btnDelExclude";
            this.btnDelExclude.Size = new System.Drawing.Size(75, 23);
            this.btnDelExclude.TabIndex = 22;
            this.btnDelExclude.Text = "删除";
            this.btnDelExclude.UseVisualStyleBackColor = true;
            this.btnDelExclude.Click += new System.EventHandler(this.btnDelExclude_Click);
            // 
            // btnAddExclude
            // 
            this.btnAddExclude.Location = new System.Drawing.Point(330, 46);
            this.btnAddExclude.Name = "btnAddExclude";
            this.btnAddExclude.Size = new System.Drawing.Size(75, 23);
            this.btnAddExclude.TabIndex = 21;
            this.btnAddExclude.Text = "添加";
            this.btnAddExclude.UseVisualStyleBackColor = true;
            this.btnAddExclude.Click += new System.EventHandler(this.btnAddExclude_Click);
            // 
            // lbExclude
            // 
            this.lbExclude.FormattingEnabled = true;
            this.lbExclude.ItemHeight = 12;
            this.lbExclude.Location = new System.Drawing.Point(6, 43);
            this.lbExclude.Name = "lbExclude";
            this.lbExclude.Size = new System.Drawing.Size(320, 64);
            this.lbExclude.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbExclude);
            this.groupBox1.Controls.Add(this.txtExclude);
            this.groupBox1.Controls.Add(this.btnAddExclude);
            this.groupBox1.Controls.Add(this.btnDelExclude);
            this.groupBox1.Location = new System.Drawing.Point(14, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 113);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "要排除的文件夹";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbExt);
            this.groupBox2.Controls.Add(this.btnAddExt);
            this.groupBox2.Controls.Add(this.btnDelExt);
            this.groupBox2.Controls.Add(this.txtExt);
            this.groupBox2.Location = new System.Drawing.Point(381, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 112);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查找类型";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbFindDir);
            this.groupBox3.Controls.Add(this.btnAddDir);
            this.groupBox3.Controls.Add(this.btnDelDir);
            this.groupBox3.Controls.Add(this.txtFindPath);
            this.groupBox3.Location = new System.Drawing.Point(14, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(349, 157);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查找位置";
            // 
            // lbFindDir
            // 
            this.lbFindDir.FormattingEnabled = true;
            this.lbFindDir.ItemHeight = 12;
            this.lbFindDir.Location = new System.Drawing.Point(6, 53);
            this.lbFindDir.Name = "lbFindDir";
            this.lbFindDir.Size = new System.Drawing.Size(261, 100);
            this.lbFindDir.TabIndex = 14;
            // 
            // btnAddDir
            // 
            this.btnAddDir.Location = new System.Drawing.Point(273, 53);
            this.btnAddDir.Name = "btnAddDir";
            this.btnAddDir.Size = new System.Drawing.Size(68, 23);
            this.btnAddDir.TabIndex = 14;
            this.btnAddDir.Text = "添加";
            this.btnAddDir.UseVisualStyleBackColor = true;
            this.btnAddDir.Click += new System.EventHandler(this.btnAddDir_Click);
            // 
            // btnDelDir
            // 
            this.btnDelDir.Location = new System.Drawing.Point(273, 94);
            this.btnDelDir.Name = "btnDelDir";
            this.btnDelDir.Size = new System.Drawing.Size(68, 23);
            this.btnDelDir.TabIndex = 15;
            this.btnDelDir.Text = "删除";
            this.btnDelDir.UseVisualStyleBackColor = true;
            this.btnDelDir.Click += new System.EventHandler(this.btnDelDir_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxBiggerThan);
            this.groupBox4.Controls.Add(this.txtBiggerThan);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(630, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(290, 46);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "文件大小";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDelC2);
            this.groupBox5.Controls.Add(this.btnStopC2);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.btnFindC2);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(489, 188);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(431, 100);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "找(1)、(2)…";
            // 
            // btnDelC2
            // 
            this.btnDelC2.Location = new System.Drawing.Point(222, 67);
            this.btnDelC2.Name = "btnDelC2";
            this.btnDelC2.Size = new System.Drawing.Size(75, 23);
            this.btnDelC2.TabIndex = 31;
            this.btnDelC2.Text = "删除选择";
            this.btnDelC2.UseVisualStyleBackColor = true;
            this.btnDelC2.Click += new System.EventHandler(this.btnDelC2_Click);
            // 
            // btnStopC2
            // 
            this.btnStopC2.Location = new System.Drawing.Point(119, 67);
            this.btnStopC2.Name = "btnStopC2";
            this.btnStopC2.Size = new System.Drawing.Size(75, 23);
            this.btnStopC2.TabIndex = 30;
            this.btnStopC2.Text = "停止";
            this.btnStopC2.UseVisualStyleBackColor = true;
            this.btnStopC2.Click += new System.EventHandler(this.btnStopC2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(407, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "KUGOU播放列表中没有，而实际文件夹中存在，再次下载，会出现这种文件名";
            // 
            // btnFindC2
            // 
            this.btnFindC2.Location = new System.Drawing.Point(19, 67);
            this.btnFindC2.Name = "btnFindC2";
            this.btnFindC2.Size = new System.Drawing.Size(75, 23);
            this.btnFindC2.TabIndex = 29;
            this.btnFindC2.Text = "查找";
            this.btnFindC2.UseVisualStyleBackColor = true;
            this.btnFindC2.Click += new System.EventHandler(this.btnFindC2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "查找文件名中带(1)、(2)类似的重复文件";
            // 
            // btnFindSameInTwo
            // 
            this.btnFindSameInTwo.Location = new System.Drawing.Point(729, 12);
            this.btnFindSameInTwo.Name = "btnFindSameInTwo";
            this.btnFindSameInTwo.Size = new System.Drawing.Size(237, 23);
            this.btnFindSameInTwo.TabIndex = 29;
            this.btnFindSameInTwo.Text = "查找两文件中相同的文件";
            this.btnFindSameInTwo.UseVisualStyleBackColor = true;
            this.btnFindSameInTwo.Click += new System.EventHandler(this.btnFindSameInTwo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btnFindSameInTwo);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStopCopy);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtCopyTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Music";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFindPath;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileFullName;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtCopyTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lbExt;
        private System.Windows.Forms.Button btnAddExt;
        private System.Windows.Forms.Button btnDelExt;
        private System.Windows.Forms.TextBox txtExt;
        private System.Windows.Forms.CheckBox cbxBiggerThan;
        private System.Windows.Forms.TextBox txtBiggerThan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStopCopy;
        private System.Windows.Forms.TextBox txtExclude;
        private System.Windows.Forms.Button btnDelExclude;
        private System.Windows.Forms.Button btnAddExclude;
        private System.Windows.Forms.ListBox lbExclude;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbFindDir;
        private System.Windows.Forms.Button btnAddDir;
        private System.Windows.Forms.Button btnDelDir;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelC2;
        private System.Windows.Forms.Button btnStopC2;
        private System.Windows.Forms.Button btnFindC2;
        private System.Windows.Forms.Button btnFindSameInTwo;
    }
}

