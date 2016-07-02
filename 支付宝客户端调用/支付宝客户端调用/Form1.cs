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
using System.IO;

namespace 支付宝客户端调用
{
    public partial class Form1 : Form
    {

        
        string UserPID = "2088201565141845";
        string MD5Key = "sstyxmh3erotgsjpbgukdz2y5dde46o0";
        string BranchNo = "000002";
        //原单号
        string _flowNo = string.Empty;
        string Cus_Name = "OK";
        decimal _returnMoney = 0.01M;
        string _returnMemo = string.Empty;
        bool _isCancel;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {


            bool isSale = string.IsNullOrEmpty(_flowNo);
            string text = txtBarCode.Text.Trim();

            if (isSale && string.IsNullOrEmpty(text))
            {
                //MsgBox.Show("手机条码不能为空！");
                lblMessage.Text = "手机条码不能为空！";
                lblMessage.Visible = true;
                txtBarCode.Focus();
                txtBarCode.SelectAll();
                return;
            }

            try
            {
                #region 生成单号
                string dogNo = string.Empty ;
                if (string.IsNullOrEmpty(dogNo) || string.IsNullOrEmpty(dogNo.Trim())) dogNo = "00000000";
                string payFlowNo = GetFlowNo();
                //加密狗号+机构号+业务系统流水号+5位随机号                    
                Random rnd = new Random();
                string rndNo = string.Empty;
                for (int i = 1; i <= 5; i++)
                {
                    rndNo += rnd.Next(9);
                }
                string totFlowNo = dogNo + BranchNo + payFlowNo + rndNo;
                #endregion

                PayInfo payinfo = new PayInfo();
                payinfo.app_name = "专卖9";
                payinfo.bar_code = text;
                if (isSale)
                {
                    payinfo.flow_no = totFlowNo;
                }
                else payinfo.flow_no = _flowNo;
                payinfo.order_title = "条码支付-" + Cus_Name;
                payinfo.pay_amt = Math.Abs(_returnMoney);
                payinfo.partner = UserPID;
                payinfo.md5key = MD5Key;
                payinfo.softdog_id = dogNo;
                if (isSale) payinfo.out_request_no = string.Empty;
                else payinfo.out_request_no = totFlowNo;

                #region 2015年1月9日,加密部分
                PayInfo copyPay = new PayInfo();
                copyPay.softdog_id = payinfo.softdog_id;
                copyPay.order_title = payinfo.order_title;
                copyPay.bar_code = payinfo.bar_code;
                copyPay.app_name = payinfo.app_name;
                copyPay.out_request_no = payinfo.out_request_no;

                StringBuilder sbChiper = new StringBuilder(2048);
                RsaHelper.LibVersion(sbChiper, 2048);
                copyPay.version = sbChiper.ToString();

                string sp = "\n";
                string reqData = payinfo.partner + sp + payinfo.md5key + sp + payinfo.flow_no + sp + payinfo.pay_amt.ToString();

                RsaHelper.RsaEncrypt(reqData, sbChiper, 2048);
                copyPay.request_data = sbChiper.ToString();
                #endregion

                if (isSale) BarCodePay(payinfo, copyPay);
                else BarCodeReturn(payinfo, copyPay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GetFlowNo()
        {
            string tmp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return tmp;
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="payinfo"></param>
        /// <returns></returns>
        public void BarCodePay(PayInfo payinfo, PayInfo copyPay)
        {
            try
            {


                WebClient client = new WebClient();
                client.Headers["Content-Type"] = "application/json";//后面不要加charset=utf8
                client.Encoding = Encoding.UTF8;//指定编码
                string json = JsonConvert.SerializeObject(copyPay);//换为copyPay
                string WCFIP = GParam.WCFIP;
                string str = client.UploadString(@"http://" + WCFIP + ":18911/PayServer/CreatAndPay1", "POST", json);
                ReturnPayInfo retinfo = JsonConvert.DeserializeObject<ReturnPayInfo>(str);
                if (retinfo != null)
                {
                    if (retinfo.is_success == "T")
                    {
                        if (retinfo.result_code == "ORDER_SUCCESS_PAY_SUCCESS")
                        {
                            _returnMoney = payinfo.pay_amt;
                            _returnMemo = payinfo.flow_no;
                            //_payCardNo = payinfo.flow_no;
                            _isCancel = false;
                            //SIIniFile.SetLocalSysParam("ZFBPay", "flow_sn", "0", GSys.InitFile);

                            WriteFlowNo(_returnMemo);

                            //this.Close();
                            //MsgBox.Show("支付成功");
                        }
                        else if (retinfo.result_code == "ORDER_SUCCESS_PAY_INPROCESS")
                        {
                            FrmWait frm = new FrmWait(copyPay);
                            frm.ShowDialog();
                            if (frm.trade_status.Equals(TradeStatus.TRADE_SUCCESS))
                            {
                                _returnMoney = payinfo.pay_amt;
                                _returnMemo = payinfo.flow_no;
                                //_payCardNo = payinfo.flow_no;
                                _isCancel = false;

                                WriteFlowNo(_returnMemo);
                            }
                            else _isCancel = true;
                            //this.Close();
                        }
                        else
                        {
                            //MsgBox.Show("支付失败，失败原因:" + retinfo.detail_error_des);
                            lblMessage.Text = "支付失败，失败原因:" + retinfo.detail_error_des;
                            lblMessage.Visible = true;
                        }
                    }
                    else
                    {
                        //MsgBox.Show("支付失败，失败原因:" + retinfo.error);
                        lblMessage.Text = "支付失败，失败原因:" + retinfo.error;
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    //MsgBox.Show("支付失败，失败原因:未能连接到服务。");
                    lblMessage.Text = "支付失败，失败原因:未能连接到服务。";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //MsgBox.Show("支付失败"+ex.Message);
                lblMessage.Text = "支付失败" + ex.Message;
                lblMessage.Visible = true;
            }
        }


        public void BarCodeReturn(PayInfo payinfo, PayInfo copyPay)
        {
            try
            {

                WebClient client = new WebClient();
                client.Headers["Content-Type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = JsonConvert.SerializeObject(copyPay);
                string WCFIP = GParam.WCFIP;
                string str = client.UploadString(@"http://" + WCFIP + ":18911/PayServer/Refund1", "POST", json);
                ReturnPayInfo retinfo = JsonConvert.DeserializeObject<ReturnPayInfo>(str);
                if (retinfo != null)
                {
                    if (retinfo.is_success == "T")
                    {
                        if (retinfo.result_code == "SUCCESS")
                        {
                            _returnMoney = payinfo.pay_amt;
                            //退货时不需要MEMO
                            //_returnMemo = txtRemark.Text.Trim() + " 支付宝单号：" + retinfo.trade_no;
                            _isCancel = false;
                            //this.Close();
                            //MsgBox.Show("退款成功")
                        }
                        else
                        {
                            //MsgBox.Show("退款失败，失败原因:" + retinfo.detail_error_des);
                            lblMessage.Text = "退款失败，失败原因:" + retinfo.detail_error_des;
                            lblMessage.Visible = true;
                        }
                    }
                    else
                    {
                        //MsgBox.Show("退款失败，失败原因:" + retinfo.error);
                        lblMessage.Text = "退款失败，失败原因:" + retinfo.error;
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    //MsgBox.Show("退款失败，失败原因:未能连接到服务。");
                    lblMessage.Text = "退款失败，失败原因:未能连接到服务。";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 记录付款完成的商户号
        /// </summary>
        /// <param name="flowNo"></param>
        public void WriteFlowNo(string flowNo)
        {
            try
            {
                string pat = Path.Combine(Application.StartupPath, "AliPayFlowNo.txt");
                using (FileStream fs = new FileStream(pat, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(flowNo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("写单号失败："+ex.Message);
            }
        }
    }
}
