using Newtonsoft.Json;
using PosServer.BLL;
using PosServer.DAL;
using PosServer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WebApplication1.Models;
using 微餐厅线下产品会员导入.Util;

namespace 微餐厅线下产品会员导入
{
    public partial class Form1 : Form
    {
        string _Is_Distributed = "-1";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBrow_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdExcel.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtExcel.Text = ofdExcel.FileName;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDbServer.Text.Trim()))
            {
                MessageBox.Show("数据库连接不能为空");
                return;
            }
            if (!File.Exists(txtExcel.Text.Trim()))
            {
                MessageBox.Show("Excel文件不存在");
                return;
            }
            if (txtExcel.Text.Trim().ToLower().EndsWith(".xlsx"))
            {
                MessageBox.Show("只支持.XLS，请在EXCEL中另存为");
                return;
            }
            try
            {
                DbUtility db = new DbUtility(txtDbServer.Text.Trim());
                DbCommand cmdP = db.GetSqlStringCommond("select ISNULL(sys_var_value,'1')  from t_sys_system where sys_var_id = 'Is_Distributed'");
                object obrst = db.ExecuteScalar(cmdP);
                _Is_Distributed = obrst.ToString();
                if (obrst.ToString() != "1" && obrst.ToString() != "0")
                {
                    MessageBox.Show("非总部或单店数据库！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库出错：" + ex.Message);
                return;
            }

            DataTable dt = null;
            try
            {
                Stream sm = File.OpenRead(txtExcel.Text.Trim());
                dt = ExcelRender.RenderFromExcel(sm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取EXCEL时出错：" + ex.Message);
                return;
            }

            if (dt != null)
            {
                gbxMain.Enabled = false;
                progressBar1.Maximum = dt.Rows.Count;
                bwImport.RunWorkerAsync(dt);
            }
            else
            {
                MessageBox.Show("未正确读取");
                return;
            }
        }



        private void bwImport_DoWork(object sender, DoWorkEventArgs e)
        {

            string siss_prod_type = "issfoodv6";

            DataTable _dt = e.Argument as DataTable;

            Member mbll = new Member();
            issfoodv6Oper foodv6 = new issfoodv6Oper();

            int i = 0;
            foreach (DataRow dr in _dt.Rows)
            {
                i += 1;
                bwImport.ReportProgress(i);

                //有会员ID的才处理
                if (dr["MemberId"] == null || string.IsNullOrWhiteSpace(SIString.TryStr(dr["MemberId"])))
                    continue;

                MemberBindRequest rd = new MemberBindRequest();
                rd.flow_no = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                System.Threading.Thread.Sleep(1);//保证单号正常
                rd.oper_type = "1";
                rd.vip_name = SIString.TryStr(dr["FamilyName"]) + SIString.TryStr(dr["GivenName"]);
                rd.openid = SIString.TryStr(dr["OpenId"]);
                rd.card_id = SIString.TryStr(dr["MemberId"]);
                string mybirth = SIString.TryStr(dr["DOB"]);

                DateTime dtbith = new DateTime(2000, 1, 1);

                if (!string.IsNullOrWhiteSpace(mybirth))
                {
                    Log.WLog("原始生日值：" + mybirth);
                    //10/26/76
                    //月/日/年
                    string[] birs = mybirth.Split('/');
                    int month = int.Parse(birs[0]);
                    int day = int.Parse(birs[1]);
                    int iyear = int.Parse(birs[2]);
                    string syear = "";
                    if (iyear >= 50)
                        syear = "19" + iyear;
                    else
                        syear = "20" + iyear.ToString().PadRight(2, '0');

                    dtbith = new DateTime(int.Parse(syear), month, day);
                }
                rd.birthday = dtbith.ToString("yyyy-MM-dd HH:mm:ss");
                Log.WLog("处理后的生日：" + rd.birthday);

                rd.email = SIString.TryStr(dr["Email"]);
                rd.mobile = SIString.TryStr(dr["Phones"]);
                rd.now_acc_num = SIString.TryDec(dr["Points"]);
                Request<MemberBindRequest> req = new Request<MemberBindRequest>();
                req.Data = rd;

                string procData = JsonConvert.SerializeObject(rd);

                Log.WLog("注册会员:" + procData);
                //注册会员
                string rst = mbll.Bind(req, txtDbServer.Text, siss_prod_type);
                Response<MemberBindResponse> resp = JsonConvert.DeserializeObject<Response<MemberBindResponse>>(rst);
                if (resp.Code == Codes.FAILED)
                    throw new Exception("注册会员时失败：" + resp.Message);

                Log.WLog("修正积分");
                //修正积分
                if (siss_prod_type == "issfoodv6")
                {
                    bool bRst = foodv6.updateNowAccNum(txtDbServer.Text, _Is_Distributed, rd);
                    if (bRst == false)
                        throw new Exception("更新积分时失败");
                }
            }

        }

        private void bwImport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void bwImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("处理过程中出现异常:" + e.Error.Message);
                Log.WLog(e.Error.Message);
            }
            gbxMain.Enabled = true;
        }


    }
}
