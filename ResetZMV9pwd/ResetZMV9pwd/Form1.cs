using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ResetZMV9pwd
{
    public partial class Form1 : Form
    {
        #region 变量
        OperDB _operDB = new OperDB();
        /// <summary>
        /// 密码字段名称。
        /// </summary>
        string _pwdFeildName = "oper_pw";
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTestStatus.Text = "";

            cbxProduct.Items.Add("专卖9");
            cbxProduct.Items.Add("服装通3");
            cbxProduct.SelectedIndex = 0;

            RemForm rf = new RemForm();
            rf.ReadRememberForm(this, new List<string>());
        }

        /// <summary>
        /// 查看当前密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeeCurPwd_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = MakeConnStr();
                if (!_operDB.CheckUser(connStr, txtZMUser.Text))
                {
                    MessageBox.Show("用户不存在");
                    return;
                }
                txtZMpwd.Text = _operDB.WatchPwd(connStr, txtZMUser.Text, _pwdFeildName);
                //第二密码
                txt2ndPwd.Text = _operDB.WatchPwd(connStr, txtZMUser.Text, "confirm_pw");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtZMUser.Text.Trim()))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(txtZMpwd.Text.Trim()))
            {
                MessageBox.Show("密码不能为空");
                return;
            }

            try
            {
                //检查用户是否存在
                string connStr = MakeConnStr();
                if (!_operDB.CheckUser(connStr, txtZMUser.Text))
                {
                    MessageBox.Show("用户不存在");
                    return;
                }
                string newPwd = EncryptClass.Encrypt(txtZMpwd.Text.Trim());
                _operDB.EditUsrPwd(connStr, txtZMUser.Text.Trim(), _pwdFeildName, newPwd);

                //第二密码
                if (!string.IsNullOrEmpty(txt2ndPwd.Text.Trim()) && txt2ndPwd.Visible)
                {
                    string new2ndPwd = EncryptClass.Encrypt(txt2ndPwd.Text.Trim());
                    _operDB.EditUsrPwd(connStr, txtZMUser.Text.Trim(), "confirm_pw", new2ndPwd);
                }

                MessageBox.Show("修改完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            lblTestStatus.Text = string.Empty;
            string connStr = MakeConnStr();
            bool bErr = _operDB.TestDBConn(connStr);

            if (bErr)
                lblTestStatus.Text = "测试连接失败!" + System.Environment.NewLine + DateTime.Now.ToLongTimeString();
            else
                lblTestStatus.Text = "测试连接成功!" + System.Environment.NewLine + DateTime.Now.ToLongTimeString();
        }

        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <returns></returns>
        private string MakeConnStr()
        {
            string strTmp = string.Empty;
            strTmp = MakeDbConnStr.MakeSqlServerConnStr(txtServer.Text, int.Parse(txtPort.Text), txtIns.Text,
                txtUser.Text, txtPwd.Text, txtDBName.Text);
            return strTmp;
        }

        private void cbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl2ndPwd.Visible = false;
            txt2ndPwd.Visible = false;

            if (cbxProduct.Text == "专卖9")
            {
                _pwdFeildName = "oper_pw";

                lbl2ndPwd.Visible = true;
                txt2ndPwd.Visible = true;
            }
            if (cbxProduct.Text == "服装通3")
            {
                _pwdFeildName = "oper_pwd";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemForm rf = new RemForm();
            rf.RememberForm(this, new List<string>());
        }
    }
}
