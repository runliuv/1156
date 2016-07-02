using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using ClassLibrary1;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using ClassLibrary1.pab;
using ClassLibrary1.mod;
using System.Threading;
using WcfClientN20.mod;
using System.Diagnostics;

namespace WcfClientN20
{
    public partial class Form1 : Form
    {
        //public static string ConnStr = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                UsualLib.RemForm.ReadRememberForm(this, null);

                string msg = "";
                DbOper.SetConStr(out msg);
            }
            catch { }
        }

        DataTable GetItemInfos(string constr)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sconn = new SqlConnection(constr))
            {
                sconn.Open();
                string strSql = "select  * from t_bd_item_info";
                SqlCommand scmd = new SqlCommand(strSql, sconn);
                SqlDataAdapter sda = new SqlDataAdapter(scmd);
                sda.Fill(dt);
            }

            return dt;
        }


        DataTable dtAllItems = new DataTable();
        private void btnTest_Click(object sender, EventArgs e)
        {
            #region get datas
            string tmpCon = MakeCon();

            try
            {
                dtAllItems = GetItemInfos(tmpCon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接数据库。" + ex.Message);
                return;
            }
            DbOper.ConnStr = tmpCon;

            if (dtAllItems == null || dtAllItems.Rows.Count == 0)
            {
                MessageBox.Show("没有商品数据。");
                return;
            }
            #endregion

            int hreadCnt = 60;
            int.TryParse(nudThreadCnt.Value.ToString(), out hreadCnt);
            if (hreadCnt <= 0)
            {
                hreadCnt = 60;
            }

            //dt1 = DateTime.Now;
            m_comm_MessageEvent("开始于" + DateTime.Now.ToString("HH:mm:ss.fff"));
            for (int i = 0; i <= hreadCnt; i++)
            {
                Thread th = new Thread(WcfOne);
                th.Start(i);
            }
        }

        private void btnGetJf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(""))
            {
                MessageBox.Show("会员卡号不能为空！");
                return;
            }
            string murl = txtwcfip.Text.Trim() + "GetZM9JF";

            string rst = "";
            byte[] bytesRst;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("Content-Type", "application/json;charset=utf8");
                    byte[] oStr = Encoding.UTF8.GetBytes("");
                    bytesRst = wc.UploadData(murl, oStr);
                }
                rst = Encoding.UTF8.GetString(bytesRst);
                MessageBox.Show(rst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 组成连接字符串
        /// </summary>
        /// <returns></returns>
        string MakeCon()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = txtDbIp.Text.Trim();
            scsb.InitialCatalog = txtDbName.Text.Trim();
            scsb.UserID = txtDbUname.Text.Trim();
            scsb.Password = txtDbPwd.Text.Trim();

            return scsb.ToString();
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

            #endregion



            string tmpCon = MakeCon();

            try
            {
                using (SqlConnection sconn = new SqlConnection(tmpCon))
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

            DbOper.ConnStr = tmpCon;

            #region 保存配置
            try
            {
                UsualLib.RemForm.RememberForm(this, null);
            }
            catch { }
            #endregion

            MessageBox.Show("OK");
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            #region get datas
            string tmpCon = MakeCon();

            try
            {
                dtAllItems = GetItemInfos(tmpCon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接数据库。" + ex.Message);
                return;
            }
            DbOper.ConnStr = tmpCon;

            if (dtAllItems == null || dtAllItems.Rows.Count == 0)
            {
                MessageBox.Show("没有商品数据。");
                return;
            }
            #endregion

            m_comm_MessageEvent("开始于" + DateTime.Now.ToString("HH:mm:ss.fff"));

            WcfOne(-1);

        }

        void WcfOne(object isThread)
        {

            int bIsThread = -1;
            if (isThread != null)
            {
                bIsThread = (int)isThread;
            }

            DateTime dti1 = DateTime.Now;

            string flow_no = System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 18);

            try
            {

                string wcfurl = string.Format("http://{0}:{1}/svr/Test", txtwcfip.Text.Trim(), txtwcfport.Text.Trim());

                #region sql

                string oper_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                StringBuilder st = new StringBuilder();
                for (int i = 0; i < dtAllItems.Rows.Count; i++)
                {
                    DataRow dr = dtAllItems.Rows[i];
                    string sql = string.Format(@"
insert into t_rm_saleflow(flow_id,flow_no,branch_no,item_no,oper_id,sell_way,oper_date,sale_man,
source_price,sale_price,sale_qnty,sale_money)
	values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',
'{8}','{9}','{10}','{11}')
", i, flow_no, "000002", dtAllItems.Rows[i]["item_no"].ToString(), "1001", "A", oper_date, "9999",
 dr["sale_price"].ToString(), dr["sale_price"].ToString(), 1, dr["sale_price"].ToString());
                    st.Append(sql);
                }
                #endregion


                zm9 zz = new zm9();
                zz.sql = st.ToString();

                string json = JsonConvert.SerializeObject(zz);//换为copyPay

                byte[] data = Encoding.UTF8.GetBytes(json);

                string strUrl = wcfurl;
                #region http web request

                HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create(strUrl);
                wreq.Method = "POST";
                wreq.ContentType = "application/json;charset=utf-8";
                wreq.ContentLength = data.Length;
                using (Stream putStream = wreq.GetRequestStream())
                {
                    putStream.Write(data, 0, data.Length);
                }

                var res = wreq.GetResponse() as HttpWebResponse;

                long length = wreq.ContentLength;
                byte[] by = new byte[length];


                using (Stream stream = res.GetResponseStream())
                {
                    int size = 1024;
                    int read = 0;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[size];
                        do
                        {
                            read = stream.Read(buffer, 0, size);
                            ms.Write(buffer, 0, read);
                        } while (read > 0);

                        by = ms.ToArray();
                    }
                }

                #endregion

                string str2 = Encoding.UTF8.GetString(by);

                rzm9 r9 = JsonConvert.DeserializeObject<rzm9>(str2);//换为copyPay

                DateTime dti2 = DateTime.Now; ;

                TimeSpan tsTot = dti2.Subtract(dti1);

                if (r9.msg.Length > 20)
                {
                    r9.msg = r9.msg.Substring(0, 20);
                }
                 
                string msg = string.Format("wcfone:thread:{0}:flowno:{1} ,dt1:{2},dt2:{3}。耗时：{4}分{5}秒{6}毫秒,插入数据量:{7}是否成功：{8}，消息：{9}",
                    bIsThread, flow_no, dti1.ToString("HH:mm:ss.fff"), dti2.ToString("HH:mm:ss.fff"),
                    tsTot.Minutes, tsTot.Seconds, tsTot.Milliseconds,
                    dtAllItems.Rows.Count, r9.code, r9.msg);

                m_comm_MessageEvent(msg);
            }
            catch (Exception ex)
            {
                string msg = "flow_no:" + flow_no + "失败：" + ex.Message;
                m_comm_MessageEvent(msg);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                UsualLib.RemForm.RememberForm(this, null);
            }
            catch { }
        }

        private void btnViewTime_Click(object sender, EventArgs e)
        {
            //TimeSpan ts = dt2 - dt1;
            //MessageBox.Show("Milliseconds：" + ts.Milliseconds.ToString());
        }

        private delegate void InvokeCallback(string msg);


        void m_comm_MessageEvent(string msg)
        {
            if (lbxLog.InvokeRequired)
            {
                InvokeCallback e = new InvokeCallback(m_comm_MessageEvent);
                lbxLog.Invoke(e, new object[] { msg });
            }
            else
            {
                lbxLog.Items.Insert(0, msg);
            }

        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lbxLog.Items.Clear();
        }

        private void btnSqlOne_Click(object sender, EventArgs e)
        {
            #region get datas
            string tmpCon = MakeCon();

            try
            {
                dtAllItems = GetItemInfos(tmpCon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接数据库。" + ex.Message);
                return;
            }
            DbOper.ConnStr = tmpCon;

            if (dtAllItems == null || dtAllItems.Rows.Count == 0)
            {
                MessageBox.Show("没有商品数据。");
                return;
            }
            #endregion

            m_comm_MessageEvent("开始于" + DateTime.Now.ToString("HH:mm:ss.fff"));

            SqlOne(false);
        }

        private void btnSqlThread_Click(object sender, EventArgs e)
        {
            #region get datas
            string tmpCon = MakeCon();

            try
            {
                dtAllItems = GetItemInfos(tmpCon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接数据库。" + ex.Message);
                return;
            }
            DbOper.ConnStr = tmpCon;

            if (dtAllItems == null || dtAllItems.Rows.Count == 0)
            {
                MessageBox.Show("没有商品数据。");
                return;
            }
            #endregion

            int hreadCnt = 60;
            int.TryParse(nudThreadCnt.Value.ToString(), out hreadCnt);
            if (hreadCnt <= 0)
            {
                hreadCnt = 60;
            }

            //dt1 = DateTime.Now;
            m_comm_MessageEvent("开始于" + DateTime.Now.ToString("HH:mm:ss.fff"));
            for (int i = 0; i <= hreadCnt; i++)
            {
                Thread th = new Thread(SqlOne);
                th.Start(i);
            }
        }

        void SqlOne(object isThread)
        {
            int bIsThread = -1;
            if (isThread != null)
            {
                bIsThread = (int)isThread;
            }


            DateTime dti1 = DateTime.Now;

            
            TOOLS tl = new TOOLS();
            string flow_no = System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 18);

            SqlTransaction strans = null;
            try
            {

                string wcfurl = string.Format("http://{0}:{1}/svr/Test", txtwcfip.Text.Trim(), txtwcfport.Text.Trim());

                #region sql

                string oper_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                StringBuilder st = new StringBuilder();
                for (int i = 0; i < dtAllItems.Rows.Count; i++)
                {
                    DataRow dr = dtAllItems.Rows[i];
                    string sql = string.Format(@"
insert into t_rm_saleflow(flow_id,flow_no,branch_no,item_no,oper_id,sell_way,oper_date,sale_man,
source_price,sale_price,sale_qnty,sale_money)
	values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',
'{8}','{9}','{10}','{11}')
", i, flow_no, "000002", dtAllItems.Rows[i]["item_no"].ToString(), "1001", "A", oper_date, "9999",
 dr["sale_price"].ToString(), dr["sale_price"].ToString(), 1, dr["sale_price"].ToString());
                    st.Append(sql);
                }
                #endregion

                string fnlSql = st.ToString();

                string tmpCon = MakeCon();
                using (SqlConnection scon = new SqlConnection(tmpCon))
                {
                    scon.Open();

                    strans = scon.BeginTransaction();
                    using (SqlCommand scmd = new SqlCommand(fnlSql, scon))
                    {
                        scmd.CommandTimeout = 150;
                        scmd.Transaction = strans;
                        scmd.ExecuteNonQuery();
                        strans.Commit();
                    }
                }

                DateTime dti2 = DateTime.Now;

                TimeSpan tsTot = dti2.Subtract(dti1);

                string msg = string.Format("sqlone:thread{0}:flowno:{1} ,dt1:{2},dt2:{3}。插入数据量:{4},耗时:{5}分{6}秒{7}毫秒,是否成功：{8}",
                    bIsThread, flow_no, dti1.ToString("HH:mm:ss.fff"),
                       dti2.ToString("HH:mm:ss.fff"), dtAllItems.Rows.Count, tsTot.Minutes, tsTot.Seconds, tsTot.Milliseconds, "成功");

                m_comm_MessageEvent(msg);
            }
            catch (Exception ex)
            {
                if (strans != null && strans.Connection != null)
                {
                    strans.Rollback();
                }
                string tmpMsg = ex.Message;
                if (tmpMsg.Length > 20)
                {
                    tmpMsg = tmpMsg.Substring(0, 20);
                }
                string msg = "flow_no:" + flow_no + "失败：" + tmpMsg;
                m_comm_MessageEvent(msg);
            }
        }


    }
}
