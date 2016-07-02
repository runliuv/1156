using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 支付宝客户端调用.Common;
using System.Net;
using Newtonsoft.Json;
 

namespace 支付宝客户端调用
{
    public partial class FrmWait : Form
    {
        private TradeStatus _trade_status = TradeStatus.NO_TRADE;//测试SVN

        public TradeStatus trade_status
        {
            get { return _trade_status; }
        }

        private string _retMemo = string.Empty;

        public string RetMemo
        {
            get { return _retMemo; }
        }
        private PayInfo payinfo = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmWait(PayInfo pay)
        {
            InitializeComponent();
            this.Text = AppInfo.AppName;
            this.Visible = false;
            payinfo = pay;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInitData_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }


        /// <summary>
        /// 线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                if (trade_status == TradeStatus.TRADE_CLOSED) { timer1.Enabled = false; this.Close(); return; }
                WebClient client = new WebClient();
                client.Headers["Content-Type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = JsonConvert.SerializeObject(payinfo);
                string WCFIP = GParam.WCFIP;
                string str = client.UploadString(@"http://" + WCFIP + ":18911/PayServer/PayQuery1", "POST", json);
                ReturnQueryInfo retinfo = JsonConvert.DeserializeObject<ReturnQueryInfo>(str);
                if (retinfo != null)
                {
                    if (retinfo.is_success == "T")
                    {
                        if (retinfo.result_code == "SUCCESS")
                        {
                            if (retinfo.trade_status == "TRADE_CLOSED")
                            {
                                timer1.Enabled = false;
                                _trade_status = TradeStatus.TRADE_CLOSED;
                                lblLoading.Text = "交易已关闭，支付失败！";
                                this.Close();
                                return;//修复死循环
                                //MessageBox.Show("交易已关闭，支付失败");
                            }
                            else if (retinfo.trade_status == "TRADE_SUCCESS" || retinfo.trade_status == "TRADE_FINISHED" || retinfo.trade_status == "TRADE_PENDING")
                            {
                                timer1.Enabled = false;
                                _retMemo = "支付宝单号：" + retinfo.trade_no;
                                _trade_status = TradeStatus.TRADE_SUCCESS;
                                lblLoading.Text = "支付成功！";
                                //SIIniFile.SetLocalSysParam("ZFBPay", "flow_sn", "0", GSys.InitFile);
                                this.Close();
                                return;//修复死循环
                                //MessageBox.Show("支付成功");
                            }
                        }
                    }
                }
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                lblLoading.Text = "检测到网络异常，请稍等...";
                DialogResult result1 = MessageBox.Show("检测到网络异常或者交易异常，是否重试？\r\n" + ex.Message,"",MessageBoxButtons.YesNo);
                if (result1 == DialogResult.No)
                {
                    timer1.Enabled = false;
                    this.Close();
                }
                else
                {
                    lblLoading.Text = "正在检测网络，请稍等...";
                    timer1.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnESC_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("是否撤销交易？","",MessageBoxButtons.YesNo);
            if (result1 == DialogResult.No) return;
            try
            {
                WebClient client = new WebClient();
                client.Headers["Content-Type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = JsonConvert.SerializeObject(payinfo);
                string WCFIP = GParam.WCFIP;
                string str = client.UploadString(@"http://" + WCFIP + ":18911/PayServer/Cancel1", "POST", json);
                ReturnCancelInfo retinfo = JsonConvert.DeserializeObject<ReturnCancelInfo>(str);
                if (retinfo != null)
                {
                    if (retinfo.is_success == "T")
                    {
                        if (retinfo.result_code == "SUCCESS")
                        {
                            timer1.Enabled = false;
                            _trade_status = TradeStatus.TRADE_CLOSED;
                            lblLoading.Text = "交易撤销成功";
                            //int sn = SIString.TryInt(SIIniFile.GetLocalSysParam("ZFBPay", "flow_sn", "0", GSys.InitFile));
                            //sn++;
                            //SIIniFile.SetLocalSysParam("ZFBPay","flow_sn",(sn).ToString(),GSys.InitFile);
                            //MessageBox.Show("交易撤销成功");
                            this.Close();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("交易撤销失败，失败原因:"+ex.Message);
            }
            DialogResult result = MessageBox.Show("交易撤销失败，是否退出交易？","",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) { timer1.Enabled = false; this.Close(); }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWait_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnESC_Click(null, null);
            }
        }

        private void FrmWait_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                timer1.Enabled = false;
            }
            catch (Exception)
            { }
        }

        private void FrmWait_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnESC_Click(null,null);
            }
        }


    }
}
