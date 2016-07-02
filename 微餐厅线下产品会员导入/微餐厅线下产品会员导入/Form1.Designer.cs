namespace 微餐厅线下产品会员导入
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
            this.txtDbServer = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.gbxMain = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.lblImporting = new System.Windows.Forms.Label();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.bwImport = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnImprotToOnline = new System.Windows.Forms.Button();
            this.gbxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库";
            // 
            // txtDbServer
            // 
            this.txtDbServer.Location = new System.Drawing.Point(73, 40);
            this.txtDbServer.Name = "txtDbServer";
            this.txtDbServer.Size = new System.Drawing.Size(452, 21);
            this.txtDbServer.TabIndex = 1;
            this.txtDbServer.Text = "server=128.0.14.39;database=issfoodv6;uid=sa;pwd=somesay;";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(166, 118);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "导入到线下产品";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // gbxMain
            // 
            this.gbxMain.Controls.Add(this.btnImprotToOnline);
            this.gbxMain.Controls.Add(this.label3);
            this.gbxMain.Controls.Add(this.btnBrow);
            this.gbxMain.Controls.Add(this.label2);
            this.gbxMain.Controls.Add(this.txtExcel);
            this.gbxMain.Controls.Add(this.btnImport);
            this.gbxMain.Controls.Add(this.label1);
            this.gbxMain.Controls.Add(this.txtDbServer);
            this.gbxMain.Location = new System.Drawing.Point(12, 12);
            this.gbxMain.Name = "gbxMain";
            this.gbxMain.Size = new System.Drawing.Size(612, 153);
            this.gbxMain.TabIndex = 3;
            this.gbxMain.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "仅支持快餐王6";
            // 
            // btnBrow
            // 
            this.btnBrow.Location = new System.Drawing.Point(531, 79);
            this.btnBrow.Name = "btnBrow";
            this.btnBrow.Size = new System.Drawing.Size(75, 23);
            this.btnBrow.TabIndex = 5;
            this.btnBrow.Text = "浏览";
            this.btnBrow.UseVisualStyleBackColor = true;
            this.btnBrow.Click += new System.EventHandler(this.btnBrow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "excel";
            // 
            // txtExcel
            // 
            this.txtExcel.Location = new System.Drawing.Point(73, 81);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.Size = new System.Drawing.Size(452, 21);
            this.txtExcel.TabIndex = 4;
            this.txtExcel.Text = "d:\\Member.xls";
            // 
            // lblImporting
            // 
            this.lblImporting.AutoSize = true;
            this.lblImporting.Location = new System.Drawing.Point(22, 182);
            this.lblImporting.Name = "lblImporting";
            this.lblImporting.Size = new System.Drawing.Size(29, 12);
            this.lblImporting.TabIndex = 6;
            this.lblImporting.Text = "状态";
            // 
            // bwImport
            // 
            this.bwImport.WorkerReportsProgress = true;
            this.bwImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwImport_DoWork);
            this.bwImport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwImport_ProgressChanged);
            this.bwImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwImport_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(85, 182);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(511, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // btnImprotToOnline
            // 
            this.btnImprotToOnline.Location = new System.Drawing.Point(380, 118);
            this.btnImprotToOnline.Name = "btnImprotToOnline";
            this.btnImprotToOnline.Size = new System.Drawing.Size(100, 23);
            this.btnImprotToOnline.TabIndex = 8;
            this.btnImprotToOnline.Text = "导入到线上";
            this.btnImprotToOnline.UseVisualStyleBackColor = true;
            this.btnImprotToOnline.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 425);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblImporting);
            this.Controls.Add(this.gbxMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxMain.ResumeLayout(false);
            this.gbxMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDbServer;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox gbxMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExcel;
        private System.Windows.Forms.Button btnBrow;
        private System.Windows.Forms.Label lblImporting;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker bwImport;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnImprotToOnline;
    }
}

