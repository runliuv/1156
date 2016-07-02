namespace WcfClientN20
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
            this.btnTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtwcfip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtwcfport = new System.Windows.Forms.TextBox();
            this.btnSaveDbSet = new System.Windows.Forms.Button();
            this.txtDbPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDbUname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDbIp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudThreadCnt = new System.Windows.Forms.NumericUpDown();
            this.xg = new System.Windows.Forms.Label();
            this.btnOne = new System.Windows.Forms.Button();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnSqlThread = new System.Windows.Forms.Button();
            this.btnSqlOne = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(37, 123);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "wcf线程测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "wcfip";
            // 
            // txtwcfip
            // 
            this.txtwcfip.Location = new System.Drawing.Point(103, 14);
            this.txtwcfip.Name = "txtwcfip";
            this.txtwcfip.Size = new System.Drawing.Size(256, 21);
            this.txtwcfip.TabIndex = 5;
            this.txtwcfip.Text = "localhost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "wcfport";
            // 
            // txtwcfport
            // 
            this.txtwcfport.Location = new System.Drawing.Point(103, 44);
            this.txtwcfport.Name = "txtwcfport";
            this.txtwcfport.Size = new System.Drawing.Size(256, 21);
            this.txtwcfport.TabIndex = 7;
            this.txtwcfport.Text = "10086";
            // 
            // btnSaveDbSet
            // 
            this.btnSaveDbSet.Location = new System.Drawing.Point(405, 123);
            this.btnSaveDbSet.Name = "btnSaveDbSet";
            this.btnSaveDbSet.Size = new System.Drawing.Size(87, 23);
            this.btnSaveDbSet.TabIndex = 22;
            this.btnSaveDbSet.Text = "保存数据库配置";
            this.btnSaveDbSet.UseVisualStyleBackColor = true;
            this.btnSaveDbSet.Click += new System.EventHandler(this.btnSaveDbSet_Click);
            // 
            // txtDbPwd
            // 
            this.txtDbPwd.Location = new System.Drawing.Point(516, 99);
            this.txtDbPwd.Name = "txtDbPwd";
            this.txtDbPwd.PasswordChar = '*';
            this.txtDbPwd.Size = new System.Drawing.Size(181, 21);
            this.txtDbPwd.TabIndex = 21;
            this.txtDbPwd.Text = "somesay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "数据库密码";
            // 
            // txtDbUname
            // 
            this.txtDbUname.Location = new System.Drawing.Point(516, 69);
            this.txtDbUname.Name = "txtDbUname";
            this.txtDbUname.Size = new System.Drawing.Size(181, 21);
            this.txtDbUname.TabIndex = 19;
            this.txtDbUname.Text = "sa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "数据库用户名";
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(516, 37);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(181, 21);
            this.txtDbName.TabIndex = 17;
            this.txtDbName.Text = "isszmv9";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "数据库名称";
            // 
            // txtDbIp
            // 
            this.txtDbIp.Location = new System.Drawing.Point(516, 6);
            this.txtDbIp.Name = "txtDbIp";
            this.txtDbIp.Size = new System.Drawing.Size(181, 21);
            this.txtDbIp.TabIndex = 15;
            this.txtDbIp.Text = "127.0.0.1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(415, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "数据库IP";
            // 
            // nudThreadCnt
            // 
            this.nudThreadCnt.Location = new System.Drawing.Point(90, 93);
            this.nudThreadCnt.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudThreadCnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreadCnt.Name = "nudThreadCnt";
            this.nudThreadCnt.Size = new System.Drawing.Size(120, 21);
            this.nudThreadCnt.TabIndex = 23;
            this.nudThreadCnt.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // xg
            // 
            this.xg.AutoSize = true;
            this.xg.Location = new System.Drawing.Point(29, 95);
            this.xg.Name = "xg";
            this.xg.Size = new System.Drawing.Size(41, 12);
            this.xg.TabIndex = 24;
            this.xg.Text = "线程数";
            // 
            // btnOne
            // 
            this.btnOne.Location = new System.Drawing.Point(216, 123);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(75, 23);
            this.btnOne.TabIndex = 25;
            this.btnOne.Text = "wcf单个测试";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // lbxLog
            // 
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.ItemHeight = 12;
            this.lbxLog.Location = new System.Drawing.Point(3, 180);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(906, 244);
            this.lbxLog.TabIndex = 26;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(824, 152);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 27;
            this.btnClearLog.Text = "清空日志";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnSqlThread
            // 
            this.btnSqlThread.Location = new System.Drawing.Point(37, 152);
            this.btnSqlThread.Name = "btnSqlThread";
            this.btnSqlThread.Size = new System.Drawing.Size(75, 23);
            this.btnSqlThread.TabIndex = 28;
            this.btnSqlThread.Text = "sql线程测试";
            this.btnSqlThread.UseVisualStyleBackColor = true;
            this.btnSqlThread.Click += new System.EventHandler(this.btnSqlThread_Click);
            // 
            // btnSqlOne
            // 
            this.btnSqlOne.Location = new System.Drawing.Point(216, 152);
            this.btnSqlOne.Name = "btnSqlOne";
            this.btnSqlOne.Size = new System.Drawing.Size(75, 23);
            this.btnSqlOne.TabIndex = 29;
            this.btnSqlOne.Text = "sql单个测试";
            this.btnSqlOne.UseVisualStyleBackColor = true;
            this.btnSqlOne.Click += new System.EventHandler(this.btnSqlOne_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 434);
            this.Controls.Add(this.btnSqlOne);
            this.Controls.Add(this.btnSqlThread);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.btnOne);
            this.Controls.Add(this.xg);
            this.Controls.Add(this.nudThreadCnt);
            this.Controls.Add(this.btnSaveDbSet);
            this.Controls.Add(this.txtDbPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDbUname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDbIp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtwcfport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtwcfip);
            this.Controls.Add(this.btnTest);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtwcfip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtwcfport;
        private System.Windows.Forms.Button btnSaveDbSet;
        private System.Windows.Forms.TextBox txtDbPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDbUname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDbIp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudThreadCnt;
        private System.Windows.Forms.Label xg;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnSqlThread;
        private System.Windows.Forms.Button btnSqlOne;
    }
}

