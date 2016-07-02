namespace WcfServer35
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDbIp = new System.Windows.Forms.TextBox();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDbUname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDbPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtWCFPORT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveDbSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(37, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 12);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "状态";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库IP";
            // 
            // txtDbIp
            // 
            this.txtDbIp.Location = new System.Drawing.Point(476, 25);
            this.txtDbIp.Name = "txtDbIp";
            this.txtDbIp.Size = new System.Drawing.Size(181, 21);
            this.txtDbIp.TabIndex = 2;
            this.txtDbIp.Text = "127.0.0.1";
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(476, 56);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(181, 21);
            this.txtDbName.TabIndex = 4;
            this.txtDbName.Text = "isszmv9";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "数据库名称";
            // 
            // txtDbUname
            // 
            this.txtDbUname.Location = new System.Drawing.Point(476, 88);
            this.txtDbUname.Name = "txtDbUname";
            this.txtDbUname.Size = new System.Drawing.Size(181, 21);
            this.txtDbUname.TabIndex = 6;
            this.txtDbUname.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "数据库用户名";
            // 
            // txtDbPwd
            // 
            this.txtDbPwd.Location = new System.Drawing.Point(476, 118);
            this.txtDbPwd.Name = "txtDbPwd";
            this.txtDbPwd.PasswordChar = '*';
            this.txtDbPwd.Size = new System.Drawing.Size(181, 21);
            this.txtDbPwd.TabIndex = 8;
            this.txtDbPwd.Text = "somesay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据库密码";
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(22, 110);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(87, 23);
            this.btnStartServer.TabIndex = 9;
            this.btnStartServer.Text = "&StartServer";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(139, 110);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 23);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "S&toptServer";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtWCFPORT
            // 
            this.txtWCFPORT.Location = new System.Drawing.Point(62, 56);
            this.txtWCFPORT.Name = "txtWCFPORT";
            this.txtWCFPORT.Size = new System.Drawing.Size(181, 21);
            this.txtWCFPORT.TabIndex = 12;
            this.txtWCFPORT.Text = "10086";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "端口";
            // 
            // btnSaveDbSet
            // 
            this.btnSaveDbSet.Location = new System.Drawing.Point(377, 158);
            this.btnSaveDbSet.Name = "btnSaveDbSet";
            this.btnSaveDbSet.Size = new System.Drawing.Size(87, 23);
            this.btnSaveDbSet.TabIndex = 13;
            this.btnSaveDbSet.Text = "保存数据库配置";
            this.btnSaveDbSet.UseVisualStyleBackColor = true;
            this.btnSaveDbSet.Click += new System.EventHandler(this.btnSaveDbSet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 326);
            this.Controls.Add(this.btnSaveDbSet);
            this.Controls.Add(this.txtWCFPORT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.txtDbPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDbUname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDbIp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDbIp;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDbUname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDbPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtWCFPORT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveDbSet;
    }
}

