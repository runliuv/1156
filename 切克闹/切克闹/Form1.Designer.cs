namespace 切克闹
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
            this.nfiNO = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtSound = new System.Windows.Forms.TextBox();
            this.btnBrow = new System.Windows.Forms.Button();
            this.tmrNO = new System.Windows.Forms.Timer(this.components);
            this.nudSec = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.btnMin = new System.Windows.Forms.Button();
            this.cmsNI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nudSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.cmsNI.SuspendLayout();
            this.SuspendLayout();
            // 
            // nfiNO
            // 
            this.nfiNO.ContextMenuStrip = this.cmsNI;
            this.nfiNO.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiNO.Icon")));
            this.nfiNO.Text = "切克闹";
            this.nfiNO.Visible = true;
            this.nfiNO.DoubleClick += new System.EventHandler(this.nfiNO_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(302, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnNO1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 54);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "播放";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "内容：";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(77, 15);
            this.txtContent.MaxLength = 200;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(219, 21);
            this.txtContent.TabIndex = 1;
            // 
            // txtSound
            // 
            this.txtSound.Location = new System.Drawing.Point(77, 52);
            this.txtSound.Name = "txtSound";
            this.txtSound.Size = new System.Drawing.Size(219, 21);
            this.txtSound.TabIndex = 3;
            // 
            // btnBrow
            // 
            this.btnBrow.Location = new System.Drawing.Point(302, 50);
            this.btnBrow.Name = "btnBrow";
            this.btnBrow.Size = new System.Drawing.Size(75, 23);
            this.btnBrow.TabIndex = 4;
            this.btnBrow.Text = "浏览(&B)";
            this.btnBrow.UseVisualStyleBackColor = true;
            // 
            // nudSec
            // 
            this.nudSec.Location = new System.Drawing.Point(12, 94);
            this.nudSec.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudSec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSec.Name = "nudSec";
            this.nudSec.Size = new System.Drawing.Size(105, 21);
            this.nudSec.TabIndex = 5;
            this.nudSec.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "后提醒";
            // 
            // dgvTask
            // 
            this.dgvTask.AllowUserToAddRows = false;
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvTask.Location = new System.Drawing.Point(1, 137);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.ReadOnly = true;
            this.dgvTask.RowHeadersVisible = false;
            this.dgvTask.RowTemplate.Height = 23;
            this.dgvTask.Size = new System.Drawing.Size(393, 200);
            this.dgvTask.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "time";
            this.Column1.HeaderText = "时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 140;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "content";
            this.Column2.HeaderText = "内容";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "sound";
            this.Column3.HeaderText = "声音";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // cbxUnit
            // 
            this.cbxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.Items.AddRange(new object[] {
            "分钟",
            "小时",
            "秒"});
            this.cbxUnit.Location = new System.Drawing.Point(136, 93);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(101, 20);
            this.cbxUnit.TabIndex = 8;
            // 
            // btnMin
            // 
            this.btnMin.Location = new System.Drawing.Point(302, 13);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(75, 23);
            this.btnMin.TabIndex = 9;
            this.btnMin.Text = "托盘(&M)";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // cmsNI
            // 
            this.cmsNI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShow,
            this.tsmiExit});
            this.cmsNI.Name = "cmsNI";
            this.cmsNI.Size = new System.Drawing.Size(117, 48);
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(116, 22);
            this.tsmiShow.Text = "显示(&V)";
            this.tsmiShow.Click += new System.EventHandler(this.tsmiShow_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(116, 22);
            this.tsmiExit.Text = "退出(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 339);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.cbxUnit);
            this.Controls.Add(this.dgvTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudSec);
            this.Controls.Add(this.btnBrow);
            this.Controls.Add(this.txtSound);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "切克闹";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.cmsNI.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nfiNO;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtSound;
        private System.Windows.Forms.Button btnBrow;
        private System.Windows.Forms.Timer tmrNO;
        private System.Windows.Forms.NumericUpDown nudSec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox cbxUnit;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.ContextMenuStrip cmsNI;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
    }
}

