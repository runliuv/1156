namespace WinRedis
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
            this.button1 = new System.Windows.Forms.Button();
            this.bwTestRedis = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.nudThreads = new System.Windows.Forms.NumericUpDown();
            this.nudTimes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.gbxButton = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtItem_no = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimes)).BeginInit();
            this.gbxButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "REDIS开始(&1)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bwTestRedis
            // 
            this.bwTestRedis.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwTestRedis_DoWork);
            this.bwTestRedis.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwTestRedis_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "线程数";
            // 
            // nudThreads
            // 
            this.nudThreads.Location = new System.Drawing.Point(98, 28);
            this.nudThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.Name = "nudThreads";
            this.nudThreads.Size = new System.Drawing.Size(120, 21);
            this.nudThreads.TabIndex = 2;
            this.nudThreads.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudTimes
            // 
            this.nudTimes.Location = new System.Drawing.Point(98, 66);
            this.nudTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimes.Name = "nudTimes";
            this.nudTimes.Size = new System.Drawing.Size(120, 21);
            this.nudTimes.TabIndex = 4;
            this.nudTimes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "次数";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "数据库直连开始(&2)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbxButton
            // 
            this.gbxButton.Controls.Add(this.label3);
            this.gbxButton.Controls.Add(this.txtItem_no);
            this.gbxButton.Controls.Add(this.button2);
            this.gbxButton.Controls.Add(this.nudTimes);
            this.gbxButton.Controls.Add(this.label2);
            this.gbxButton.Controls.Add(this.button1);
            this.gbxButton.Controls.Add(this.nudThreads);
            this.gbxButton.Controls.Add(this.label1);
            this.gbxButton.Location = new System.Drawing.Point(12, 12);
            this.gbxButton.Name = "gbxButton";
            this.gbxButton.Size = new System.Drawing.Size(283, 333);
            this.gbxButton.TabIndex = 6;
            this.gbxButton.TabStop = false;
            this.gbxButton.Text = "groupBox1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(317, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "停止(&6)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtItem_no
            // 
            this.txtItem_no.Location = new System.Drawing.Point(118, 103);
            this.txtItem_no.Name = "txtItem_no";
            this.txtItem_no.Size = new System.Drawing.Size(100, 21);
            this.txtItem_no.TabIndex = 6;
            this.txtItem_no.Text = "00010011";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "item_no";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 357);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.gbxButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimes)).EndInit();
            this.gbxButton.ResumeLayout(false);
            this.gbxButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bwTestRedis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudThreads;
        private System.Windows.Forms.NumericUpDown nudTimes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbxButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItem_no;
    }
}

