using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using ClassLibrary1.pab;

namespace WcfServer35
{
    public partial class Form1 : Form
    {
        WcfServer _svr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                UsualLib.RemForm.ReadRememberForm(this, null);


                DbOper.ConnStr = MakeCon();
            }
            catch { }

        }

        string MakeCon()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = txtDbIp.Text.Trim();
            scsb.InitialCatalog = txtDbName.Text.Trim();
            scsb.UserID = txtDbUname.Text.Trim();
            scsb.Password = txtDbPwd.Text.Trim();

            return scsb.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                UsualLib.RemForm.RememberForm(this, null);
            }
            catch { }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            string strSql = string.Empty;
            string wcfPort = "10086";

            #region 设置连接
            DbOper.ConnStr = MakeCon();
            #endregion

            try
            {
                _svr = new WcfServer(wcfPort);
                _svr.Start();
                lblStatus.Text = "WCF 服务已启动";

                btnStartServer.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStartServer.Enabled = true;
            if (_svr != null)
            {
                _svr.Close();

                lblStatus.Text = "WCF 服务已停止";

            }
        }

        private void btnSaveDbSet_Click(object sender, EventArgs e)
        {
            string strSql = string.Empty;
            string wcfPort = "10086";
            #region check
            if (string.IsNullOrEmpty(txtDbIp.Text.Trim()))
            {
                MessageBox.Show("数据库IP不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtDbName.Text.Trim()))
            {
                MessageBox.Show("数据库名称不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtDbUname.Text.Trim()))
            {
                MessageBox.Show("数据库用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtDbPwd.Text.Trim()))
            {
                MessageBox.Show("数据库密码不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtWCFPORT.Text.Trim()))
            {
                MessageBox.Show("端口不能为空！");
                return;
            }
            wcfPort = txtWCFPORT.Text.Trim();
            #endregion

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = txtDbIp.Text.Trim();
            scsb.InitialCatalog = txtDbName.Text.Trim();
            scsb.UserID = txtDbUname.Text.Trim();
            scsb.Password = txtDbPwd.Text.Trim();

            DbOper.ConnStr = scsb.ToString();

            try
            {
                using (SqlConnection sconn = new SqlConnection(DbOper.ConnStr))
                {
                    sconn.Open();
                    strSql = "select  count(1) from t_bd_item_info";
                    SqlCommand scmd = new SqlCommand(strSql, sconn);
                    scmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接数据库。" + ex.Message);
                return;
            }

            #region 保存配置
            string xmlCfg = MyCfgEtc.xmlCfgFullName;
            try
            {
                File.Delete(xmlCfg);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(string.Format(@"<item>
<DbIp>{0}</DbIp>
<DbName>{1}</DbName>
<DbUname>{2}</DbUname>
<DbPwd>{3}</DbPwd>
</item>", txtDbIp.Text.Trim(), txtDbName.Text.Trim(), txtDbUname.Text.Trim(), txtDbPwd.Text.Trim()));
                doc.PreserveWhitespace = true;
                doc.Save(xmlCfg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            MessageBox.Show("OK");

        }


    }
}
