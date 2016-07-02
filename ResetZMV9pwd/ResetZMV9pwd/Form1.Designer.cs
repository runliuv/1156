namespace ResetZMV9pwd
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
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIns = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtZMpwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZMUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSeeCurPwd = new System.Windows.Forms.Button();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxProduct = new System.Windows.Forms.ComboBox();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.lbl2ndPwd = new System.Windows.Forms.Label();
            this.txt2ndPwd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库IP:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(143, 15);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(211, 21);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = "128.0.14.32";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(143, 41);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(211, 21);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "1433";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库端口号:";
            // 
            // txtIns
            // 
            this.txtIns.Location = new System.Drawing.Point(143, 67);
            this.txtIns.Name = "txtIns";
            this.txtIns.Size = new System.Drawing.Size(211, 21);
            this.txtIns.TabIndex = 5;
            this.txtIns.Text = "MSSQLSERVER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据库实例名:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(143, 93);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(211, 21);
            this.txtUser.TabIndex = 7;
            this.txtUser.Text = "sa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据库用户登录名:";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(143, 119);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(211, 21);
            this.txtPwd.TabIndex = 9;
            this.txtPwd.Text = "somesay";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "数据库密码:";
            // 
            // txtZMpwd
            // 
            this.txtZMpwd.Location = new System.Drawing.Point(143, 249);
            this.txtZMpwd.Name = "txtZMpwd";
            this.txtZMpwd.Size = new System.Drawing.Size(211, 21);
            this.txtZMpwd.TabIndex = 13;
            this.txtZMpwd.Text = "1001";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "密码:";
            // 
            // txtZMUser
            // 
            this.txtZMUser.Location = new System.Drawing.Point(143, 215);
            this.txtZMUser.Name = "txtZMUser";
            this.txtZMUser.Size = new System.Drawing.Size(211, 21);
            this.txtZMUser.TabIndex = 11;
            this.txtZMUser.Text = "1001";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "要修改密码的用户:";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(143, 323);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(143, 185);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(211, 21);
            this.txtDBName.TabIndex = 16;
            this.txtDBName.Text = "isszmv9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "数据库名:";
            // 
            // btnSeeCurPwd
            // 
            this.btnSeeCurPwd.Location = new System.Drawing.Point(379, 213);
            this.btnSeeCurPwd.Name = "btnSeeCurPwd";
            this.btnSeeCurPwd.Size = new System.Drawing.Size(102, 23);
            this.btnSeeCurPwd.TabIndex = 17;
            this.btnSeeCurPwd.Text = "查看当前(&S)";
            this.btnSeeCurPwd.UseVisualStyleBackColor = true;
            this.btnSeeCurPwd.Click += new System.EventHandler(this.btnSeeCurPwd_Click);
            // 
            // btnTestConn
            // 
            this.btnTestConn.Location = new System.Drawing.Point(379, 185);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(102, 23);
            this.btnTestConn.TabIndex = 18;
            this.btnTestConn.Text = "测试连接(&T)";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "产品:";
            // 
            // cbxProduct
            // 
            this.cbxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProduct.FormattingEnabled = true;
            this.cbxProduct.Location = new System.Drawing.Point(143, 151);
            this.cbxProduct.Name = "cbxProduct";
            this.cbxProduct.Size = new System.Drawing.Size(211, 20);
            this.cbxProduct.TabIndex = 20;
            this.cbxProduct.SelectedIndexChanged += new System.EventHandler(this.cbxProduct_SelectedIndexChanged);
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Location = new System.Drawing.Point(377, 154);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(29, 12);
            this.lblTestStatus.TabIndex = 21;
            this.lblTestStatus.Text = "状态";
            // 
            // lbl2ndPwd
            // 
            this.lbl2ndPwd.AutoSize = true;
            this.lbl2ndPwd.Location = new System.Drawing.Point(21, 284);
            this.lbl2ndPwd.Name = "lbl2ndPwd";
            this.lbl2ndPwd.Size = new System.Drawing.Size(59, 12);
            this.lbl2ndPwd.TabIndex = 22;
            this.lbl2ndPwd.Text = "第二密码:";
            this.lbl2ndPwd.Visible = false;
            // 
            // txt2ndPwd
            // 
            this.txt2ndPwd.Location = new System.Drawing.Point(143, 281);
            this.txt2ndPwd.Name = "txt2ndPwd";
            this.txt2ndPwd.Size = new System.Drawing.Size(211, 21);
            this.txt2ndPwd.TabIndex = 23;
            this.txt2ndPwd.Text = "10086";
            this.txt2ndPwd.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(422, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "150518";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 368);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt2ndPwd);
            this.Controls.Add(this.lbl2ndPwd);
            this.Controls.Add(this.lblTestStatus);
            this.Controls.Add(this.cbxProduct);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnTestConn);
            this.Controls.Add(this.btnSeeCurPwd);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtZMpwd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtZMUser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改专卖密码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtZMpwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZMUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSeeCurPwd;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxProduct;
        private System.Windows.Forms.Label lblTestStatus;
        private System.Windows.Forms.Label lbl2ndPwd;
        private System.Windows.Forms.TextBox txt2ndPwd;
        private System.Windows.Forms.Label label10;
    }
}

