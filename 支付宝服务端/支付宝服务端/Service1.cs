using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using 支付宝服务端.Common;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Xml;

namespace 支付宝服务端
{
    public class PayServer : IService
    {


        public static string Url = "https://mapi.alipay.com/gateway.do?";
        /// <summary>
        /// 加密用的私钥
        /// </summary>
        public static string key = "ai1ce2jkwkmd3bddy97z0xnz3lxqk731";

        public PayServer()
        {
            UserInfo.AGENT_ID = "8678736a1";
            ReadConfig.InitAlipayData();
        }



        public string Test(string str)
        {
            PayInfo payinfo = new PayInfo();
            payinfo = JsonConvert.DeserializeObject<PayInfo>(str);
            return JsonConvert.SerializeObject(payinfo);
        }

        public string Fetch(string tablename)
        {

            return "Fetch";

        }

        public string StrToHex(string str)
        {
            string strResult;
            byte[] buffer = Encoding.GetEncoding("utf-8").GetBytes(str);
            strResult = "";
            foreach (byte b in buffer)
            {
                strResult += b.ToString("X2");//X是16进制大写格式 
            }
            return strResult;
        }

        public string StrToUtf8(string str, string encodename)
        {
            if (encodename.ToLower() == "utf8" || encodename.ToLower() == "utf8")
            {
                return str;
            }
            else if (encodename.ToLower() == "ansi")
            {
                return HexToStr(str, "utf-8");
            }
            string strResult;
            System.Text.Encoding utf8, oldEncode;
            //utf8   
            utf8 = System.Text.Encoding.GetEncoding("utf-8");
            //old
            oldEncode = System.Text.Encoding.GetEncoding("encodename");
            byte[] buffer = Encoding.GetEncoding(encodename).GetBytes(str);
            buffer = System.Text.Encoding.Convert(oldEncode, utf8, buffer);
            strResult = utf8.GetString(buffer);

            return strResult;
        }


        public string HexToStr(string hex, string charset)
        {
            if (hex == null)
                throw new ArgumentNullException("hex");
            hex = hex.Replace(",", "");
            hex = hex.Replace("\n", "");
            hex = hex.Replace("\\", "");
            hex = hex.Replace(" ", "");
            if (hex.Length % 2 != 0)
            {
                hex += "20";//空格
            }
            // 需要将 hex 转换成 byte 数组。 
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。 
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message. 
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
        }

        #region 下单并支付
        public ReturnPayInfo CreatAndPay(string strPayInfo)
        {
            ReturnPayInfo rpinfo = new ReturnPayInfo();

            try
            {
                //string temp = "";
                //temp = StrToHex(strPayInfo);
                //strPayInfo = HexToStr(temp, "utf-8");        

                //InitAlipayData();//构造函数里读取即可
                WriteSysLog(strPayInfo);
                //string tempstr = Encoding.UTF8.GetString(strPayInfo);
                string retpayInfo = string.Empty;
                PayInfo payinfo = new PayInfo();
                payinfo = JsonConvert.DeserializeObject<PayInfo>(strPayInfo);
                //WriteDbLog(LogType.RequestData,OperType.CreatAndPay,payinfo,null,null,null,null);


                #region 商户限制
                if (UserInfo.NoneSissMerchantCannotUse)
                {
                    SissAlipayMerchantDal samdal = new SissAlipayMerchantDal();
                    if (!samdal.CheckPartner(payinfo.partner))
                    {
                        rpinfo.is_success = "F";
                        rpinfo.error = UserInfo.NoneSissPrompt;
                        return rpinfo;
                    }
                }
                #endregion

                string strUrl = "";
                string selfAgentId = string.Empty;
                if (string.IsNullOrEmpty(payinfo.app_name) || string.IsNullOrEmpty(payinfo.app_name.Trim()))
                {
                    selfAgentId = UserInfo.AGENT_ID;
                }
                else if (UserInfo.siss_app_name1.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id1;
                }
                else if (UserInfo.siss_app_name2.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id2;
                }
                else if (UserInfo.siss_app_name3.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id3;
                }
                else if (UserInfo.siss_app_name4.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id4;
                }
                if (string.IsNullOrEmpty(selfAgentId) || string.IsNullOrEmpty(selfAgentId.Trim()))
                {
                    selfAgentId = UserInfo.AGENT_ID;
                }
                ExtendParams extend = new ExtendParams();
                extend.MACHINE_ID = "SISS" + payinfo.app_name;
                extend.STORE_TYPE = "1";
                extend.STORE_ID = payinfo.softdog_id;
                extend.AGENT_ID = selfAgentId;
                string extendstr = JsonConvert.SerializeObject(extend);
                #region 生成MD5加密后的sign

                string[] codeparameters ={
                "dynamic_id_type=bar_code",
                "subject="+payinfo.order_title,
                "extend_params="+extendstr,
                "out_trade_no="+payinfo.flow_no,
                "_input_charset=UTF-8",
                "dynamic_id="+payinfo.bar_code,
                "product_code=BARCODE_PAY_OFFLINE",
                "total_fee="+payinfo.pay_amt,
                "service=alipay.acquire.createandpay",
                "seller_id="+payinfo.partner,
                "partner="+payinfo.partner,
                "alipay_ca_request=2",
                                 };
                string MySign = MD5Helper.CreatUrl(codeparameters, "UTF-8", "MD5", payinfo.md5key);
                #endregion

                #region 生成URL


                string UrlParmes = "";

                string[] parameters ={
              "dynamic_id_type=bar_code",
                "subject="+payinfo.order_title,
                "extend_params="+extendstr,
                "sign_type=MD5",
                "out_trade_no="+payinfo.flow_no,
                "sign="+MySign,
                "_input_charset=UTF-8",
                "dynamic_id="+payinfo.bar_code,
                "product_code=BARCODE_PAY_OFFLINE",
                "total_fee="+payinfo.pay_amt,
                "service=alipay.acquire.createandpay",
                "seller_id="+payinfo.partner,
                "partner="+payinfo.partner,
                "alipay_ca_request=2",
                                 };
                foreach (string str in parameters)
                {
                    UrlParmes += str + "&";
                }
                UrlParmes = UrlParmes.Remove(UrlParmes.Length - 1);

                strUrl = Url + UrlParmes;

                #endregion

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strUrl);
                var res = req.GetResponse() as HttpWebResponse;
                string strreturn = string.Empty;
                using (Stream stream = res.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    strreturn = sr.ReadToEnd().ToString();
                }
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(strreturn);

                string isSuccess = doc.SelectSingleNode("alipay/is_success/text()").InnerText;

                XmlNode nodelist = doc.SelectSingleNode("alipay/response/alipay");


                rpinfo.is_success = isSuccess;
                if (rpinfo.is_success != "T")
                {
                    rpinfo.error = doc.SelectSingleNode("alipay/error/text()").InnerText;
                }
                else
                {
                    rpinfo.result_code = nodelist.SelectSingleNode("result_code").InnerText;
                    if (rpinfo.result_code == "ORDER_SUCCESS_PAY_INPROCESS")
                    {
                        rpinfo.out_trade_no = nodelist.SelectSingleNode("out_trade_no").InnerText;
                        rpinfo.trade_no = nodelist.SelectSingleNode("trade_no").InnerText;
                        rpinfo.buyer_user_id = nodelist.SelectSingleNode("buyer_user_id").InnerText;
                        rpinfo.buyer_logon_id = nodelist.SelectSingleNode("buyer_logon_id").InnerText;
                    }
                    else if (rpinfo.result_code != "ORDER_SUCCESS_PAY_SUCCESS")
                    {
                        rpinfo.detail_error_code = nodelist.SelectSingleNode("detail_error_code").InnerText;
                        rpinfo.detail_error_des = nodelist.SelectSingleNode("detail_error_des").InnerText;
                    }
                    else
                    {
                        rpinfo.out_trade_no = nodelist.SelectSingleNode("out_trade_no").InnerText;
                        rpinfo.trade_no = nodelist.SelectSingleNode("trade_no").InnerText;
                        rpinfo.buyer_user_id = nodelist.SelectSingleNode("buyer_user_id").InnerText;
                        rpinfo.buyer_logon_id = nodelist.SelectSingleNode("buyer_logon_id").InnerText;
                    }
                }
                //retpayInfo = JsonConvert.SerializeObject(rpinfo);
                if (rpinfo.result_code == "ORDER_SUCCESS_PAY_SUCCESS")
                {
                    string Paylog = "";
                    Paylog = "CreatAndPay-flowno:" + payinfo.flow_no + " PayAmt:" + payinfo.pay_amt + " SellWay:A AppName:" + payinfo.app_name + " AgentID:" + extend.AGENT_ID + " Partner:" + payinfo.partner
                        + " Trade_no:" + rpinfo.trade_no + " BuyerId:" + rpinfo.buyer_user_id + " BuyerName:" + rpinfo.buyer_logon_id + " SoftDog:" + payinfo.softdog_id;
                    WriteSysSuccesLog(Paylog);
                    WriteDbLog(LogType.OperSuccess, OperType.CreatAndPay, payinfo, rpinfo, null, null, extend);

                }

                return rpinfo;
            }
            catch (Exception ex)
            {
                rpinfo.is_success = "F";
                rpinfo.error = ex.Message;
                return rpinfo;
            }

        }

        public Stream test(Stream strPayInfo)
        {
            //byte[] bytesa = strPayInfo.ReadBytes();

            //string jssson = Encoding.UTF8.GetString(strPayInfo);
            byte[] byIn = strPayInfo.ReadBytes();
            string json = Encoding.UTF8.GetString(byIn);
            string jssson = JsonConvert.SerializeObject(strPayInfo);
            WriteSysLog(jssson);
            ReturnPayInfo rpinfo = CreatAndPay(jssson);
            string jsonSend = JsonConvert.SerializeObject(rpinfo);
            byte[] bytesOut = Encoding.UTF8.GetBytes(jsonSend);
            MemoryStream streamRst = new MemoryStream(bytesOut);
            return streamRst;

        }

        //2015年1月9日
        public ReturnPayInfo CreatAndPay1(PayInfo payinfo)
        {
            string strPayInfo = string.Empty;
            ReturnPayInfo rpinfo = new ReturnPayInfo();
            try
            {
                if (string.IsNullOrEmpty(payinfo.version))
                {
                    rpinfo.is_success = "F";
                    rpinfo.error = "没有提供VERSION";
                    return rpinfo;
                }
                //InitAlipayData();//构造函数中读取即可
                #region app_name限制
                string selfAgentId = string.Empty;
                if (string.IsNullOrEmpty(payinfo.app_name) || string.IsNullOrEmpty(payinfo.app_name.Trim()))
                {
                    rpinfo.is_success = "F";
                    rpinfo.error = "app_name为空！";
                    return rpinfo;
                }
                else if (UserInfo.siss_app_name1.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id1;
                }
                else if (UserInfo.siss_app_name2.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id2;
                }
                else if (UserInfo.siss_app_name3.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id3;
                }
                else if (UserInfo.siss_app_name4.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id4;
                }
                if (string.IsNullOrEmpty(selfAgentId) || string.IsNullOrEmpty(selfAgentId.Trim()))
                {
                    //rpinfo.is_success = "F";
                    //rpinfo.error = string.Format("app_name[{0}]错误，后台没有配置！", payinfo.app_name);
                    //return rpinfo;
                }
                #endregion

                string PKV = payinfo.version;

                string requst_data = RsaHelper.Decrypt(PKV, payinfo.request_data);

                string[] datas = requst_data.Split('\n');

                //对几项解密
                decimal tmpAmount = 0M;
                payinfo.partner = datas[0];
                payinfo.md5key = datas[1];
                payinfo.flow_no = datas[2];
                if (!decimal.TryParse(datas[3], out tmpAmount))
                {
                    rpinfo.is_success = "F";
                    rpinfo.error = "不能转换为金额";
                    return rpinfo;
                }
                payinfo.pay_amt = tmpAmount;



                strPayInfo = JsonConvert.SerializeObject(payinfo);

                rpinfo = CreatAndPay(strPayInfo);
                return rpinfo;

            }
            catch (Exception ex)
            {
                rpinfo.is_success = "F";
                rpinfo.error = ex.Message;
                return rpinfo;
            }

        }

        #endregion

        #region 收单查询
        public ReturnQueryInfo PayQuery(string strPayInfo)
        {
            WriteSysLog(strPayInfo);
            string retQueInfo = string.Empty;
            PayInfo payinfo = new PayInfo();
            payinfo = JsonConvert.DeserializeObject<PayInfo>(strPayInfo);
            //WriteDbLog(LogType.RequestData, OperType.PayQuery, payinfo, null, null, null, null);

            string StrUrl = "";
            string[] parameters ={
                       "_input_charset=UTF-8",
                       "out_trade_no="+payinfo.flow_no,
                        "partner="+payinfo.partner,
                        "alipay_ca_request=2",
                        "service=alipay.acquire.query",
                                 };
            //生成MD5加密后的sign
            string MySign = MD5Helper.CreatUrl(parameters, "UTF-8", "MD5", payinfo.md5key);

            StringBuilder prestr = new StringBuilder();

            for (int i = 0; i < parameters.Length; i++)
            {
                if (i == parameters.Length - 1)
                {
                    prestr.Append(parameters[i]);

                }
                else
                {
                    prestr.Append(parameters[i] + "&");
                }

            }


            StrUrl = Url + prestr + "&sign_type=MD5&sign=" + MySign;


            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(StrUrl);
            var res = req.GetResponse() as HttpWebResponse;
            Stream stream = res.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string strreturn = sr.ReadToEnd().ToString();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(strreturn);

            string isSuccess = doc.SelectSingleNode("alipay/is_success/text()").InnerText;

            XmlNode nodelist = doc.SelectSingleNode("alipay/response/alipay");

            ReturnQueryInfo rpinfo = new ReturnQueryInfo();
            rpinfo.is_success = isSuccess;
            if (rpinfo.is_success != "T")
            {
                rpinfo.error = doc.SelectSingleNode("alipay/error/text()").InnerText;
            }
            else
            {
                rpinfo.result_code = nodelist.SelectSingleNode("result_code").InnerText;
                if (rpinfo.result_code != "SUCCESS")
                {
                    rpinfo.detail_error_code = nodelist.SelectSingleNode("detail_error_code").InnerText;
                    rpinfo.detail_error_des = nodelist.SelectSingleNode("detail_error_des").InnerText;
                }
                else
                {
                    rpinfo.out_trade_no = nodelist.SelectSingleNode("out_trade_no").InnerText;
                    rpinfo.trade_no = nodelist.SelectSingleNode("trade_no").InnerText;
                    rpinfo.buyer_user_id = nodelist.SelectSingleNode("buyer_user_id").InnerText;
                    rpinfo.buyer_logon_id = nodelist.SelectSingleNode("buyer_logon_id").InnerText;
                    rpinfo.trade_status = nodelist.SelectSingleNode("trade_status").InnerText;
                    rpinfo.partner = nodelist.SelectSingleNode("partner").InnerText;
                }
            }
            //retQueInfo = JsonConvert.SerializeObject(rpinfo);
            //首先创建请求，然后等待手机确认，确认完后rpinfo.trade_status为"TRADE_SUCCESS"。
            if (rpinfo.result_code == "ORDER_SUCCESS_PAY_SUCCESS" || (!string.IsNullOrEmpty(rpinfo.trade_status) && rpinfo.trade_status.Trim().ToUpper() == "TRADE_SUCCESS"))
            {
                string Paylog = "";
                Paylog = "PayQuery-flowno:" + payinfo.flow_no + " PayAmt:" + payinfo.pay_amt + " SellWay:A AppName:" + payinfo.app_name + " Partner:" + payinfo.partner
                    + " Trade_no:" + rpinfo.trade_no + " BuyerId:" + rpinfo.buyer_user_id + " BuyerName:" + rpinfo.buyer_logon_id;
                WriteSysSuccesLog(Paylog);

                #region 支付宝分配给思迅的ID
                string selfAgentId = string.Empty;
                if (string.IsNullOrEmpty(payinfo.app_name) || string.IsNullOrEmpty(payinfo.app_name.Trim()))
                {
                    selfAgentId = UserInfo.AGENT_ID;
                }
                else if (UserInfo.siss_app_name1.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id1;
                }
                else if (UserInfo.siss_app_name2.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id2;
                }
                else if (UserInfo.siss_app_name3.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id3;
                }
                else if (UserInfo.siss_app_name4.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id4;
                }
                if (string.IsNullOrEmpty(selfAgentId) || string.IsNullOrEmpty(selfAgentId.Trim()))
                {
                    selfAgentId = UserInfo.AGENT_ID;
                }
                ExtendParams eParams = new ExtendParams();
                eParams.AGENT_ID = selfAgentId;
                #endregion
                WriteDbLog(LogType.OperSuccess, OperType.PayQuery, payinfo, null, rpinfo, null, eParams);

            }
            return rpinfo;

        }

        public ReturnQueryInfo PayQuery1(PayInfo payinfo)
        {
            string strPayInfo = string.Empty;
            ReturnQueryInfo rpinfo = new ReturnQueryInfo();
            try
            {
                if (string.IsNullOrEmpty(payinfo.version))
                {
                    rpinfo.is_success = "F";
                    rpinfo.error = "没有提供VERSION";
                    return rpinfo;
                }

                #region app_name限制
                string selfAgentId = string.Empty;
                if (string.IsNullOrEmpty(payinfo.app_name) || string.IsNullOrEmpty(payinfo.app_name.Trim()))
                {
                    rpinfo.is_success = "F";
                    rpinfo.error = "app_name为空！";
                    return rpinfo;
                }
                else if (UserInfo.siss_app_name1.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id1;
                }
                else if (UserInfo.siss_app_name2.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id2;
                }
                else if (UserInfo.siss_app_name3.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id3;
                }
                else if (UserInfo.siss_app_name4.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id4;
                }
                if (string.IsNullOrEmpty(selfAgentId) || string.IsNullOrEmpty(selfAgentId.Trim()))
                {
                    //rpinfo.is_success = "F";
                    //rpinfo.error = string.Format("app_name[{0}]错误，后台没有配置！", payinfo.app_name);
                    //return rpinfo;
                }
                #endregion

                string PKV = payinfo.version;

                string requst_data = RsaHelper.Decrypt(PKV, payinfo.request_data);

                string[] datas = requst_data.Split('\n');

                //对几项解密
                decimal tmpAmount = 0M;
                payinfo.partner = datas[0];
                payinfo.md5key = datas[1];
                payinfo.flow_no = datas[2];
                if (!decimal.TryParse(datas[3], out tmpAmount))
                {
                    rpinfo.is_success = "F";
                    rpinfo.error = "不能转换为金额";
                    return rpinfo;
                }
                payinfo.pay_amt = tmpAmount;

                strPayInfo = JsonConvert.SerializeObject(payinfo);

                rpinfo = PayQuery(strPayInfo);
                return rpinfo;
            }
            catch (Exception ex)
            {
                rpinfo.is_success = "F";
                rpinfo.error = ex.Message;
                return rpinfo;
            }


        }

        #endregion

        #region 收单撤销
        public ReturnCancelInfo Cancel(string strPayInfo)
        {
            WriteSysLog(strPayInfo);
            string retCanInfo = string.Empty;
            PayInfo payinfo = new PayInfo();
            payinfo = JsonConvert.DeserializeObject<PayInfo>(strPayInfo);
            //WriteDbLog(LogType.RequestData, OperType.Cancel, payinfo, null, null, null, null);

            string StrUrl = "";
            string[] parameters ={
                       "_input_charset=UTF-8",
                       "out_trade_no="+payinfo.flow_no,
                         "seller_id="+payinfo.partner,
                        "partner="+payinfo.partner,
                        "alipay_ca_request=2",
                        "service=alipay.acquire.cancel",
                                 };
            string MySign = MD5Helper.CreatUrl(parameters, "UTF-8", "MD5", payinfo.md5key);

            StringBuilder prestr = new StringBuilder();

            for (int i = 0; i < parameters.Length; i++)
            {
                if (i == parameters.Length - 1)
                {
                    prestr.Append(parameters[i]);
                }
                else
                {
                    prestr.Append(parameters[i] + "&");
                }

            }
            StrUrl = Url + prestr + "&sign_type=MD5&sign=" + MySign;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(StrUrl);
            var res = req.GetResponse() as HttpWebResponse;
            Stream stream = res.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string strreturn = sr.ReadToEnd().ToString();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(strreturn);

            string isSuccess = doc.SelectSingleNode("alipay/is_success/text()").InnerText;

            XmlNode nodelist = doc.SelectSingleNode("alipay/response/alipay");

            ReturnCancelInfo rpinfo = new ReturnCancelInfo();
            rpinfo.is_success = isSuccess;
            if (rpinfo.is_success != "T")
            {
                rpinfo.error = doc.SelectSingleNode("alipay/error/text()").InnerText;
            }
            else
            {
                rpinfo.result_code = nodelist.SelectSingleNode("result_code").InnerText;
                if (rpinfo.result_code != "SUCCESS")
                {
                    rpinfo.detail_error_code = nodelist.SelectSingleNode("detail_error_code").InnerText;
                    rpinfo.detail_error_des = nodelist.SelectSingleNode("detail_error_des").InnerText;
                }
                else
                {
                    rpinfo.out_trade_no = nodelist.SelectSingleNode("out_trade_no").InnerText;
                    rpinfo.trade_no = nodelist.SelectSingleNode("trade_no").InnerText;
                    //rpinfo.buyer_user_id = nodelist.SelectSingleNode("buyer_user_id").InnerText;
                    //rpinfo.buyer_logon_id = nodelist.SelectSingleNode("buyer_logon_id").InnerText;
                    rpinfo.retry_flag = nodelist.SelectSingleNode("retry_flag").InnerText;
                }
            }
            //retCanInfo = JsonConvert.SerializeObject(rpinfo);
            return rpinfo;
        }

        public ReturnCancelInfo Cancel1(PayInfo payinfo)
        {
            string strPayInfo = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(payinfo.version))
                {
                    ReturnCancelInfo tmp = new ReturnCancelInfo();
                    tmp.is_success = "F";
                    tmp.error = "没有提供VERSION";
                    return tmp;
                }

                string PKV = payinfo.version;

                string requst_data = RsaHelper.Decrypt(PKV, payinfo.request_data);

                string[] datas = requst_data.Split('\n');

                //对几项解密
                decimal tmpAmount = 0M;
                payinfo.partner = datas[0];
                payinfo.md5key = datas[1];
                payinfo.flow_no = datas[2];
                if (!decimal.TryParse(datas[3], out tmpAmount))
                {
                    ReturnCancelInfo tmp = new ReturnCancelInfo();
                    tmp.is_success = "F";
                    tmp.error = "不能转换为金额";
                    return tmp;
                }
                payinfo.pay_amt = tmpAmount;

                strPayInfo = JsonConvert.SerializeObject(payinfo);
            }
            catch (Exception ex)
            {
                ReturnCancelInfo tmp = new ReturnCancelInfo();
                tmp.is_success = "F";
                tmp.error = ex.Message;
                return tmp;
            }

            ReturnCancelInfo rpinfo = Cancel(strPayInfo);
            return rpinfo;
        }
        #endregion

        #region 收单退款
        public ReturnRefundInfo Refund(string strRefInfo)
        {
            WriteSysLog(strRefInfo);
            string retRfundInfo = string.Empty;
            PayInfo payinfo = new PayInfo();
            payinfo = JsonConvert.DeserializeObject<PayInfo>(strRefInfo);
            //WriteDbLog(LogType.RequestData, OperType.Refund, payinfo, null, null, null, null);

            string StrUrl = "";
            string[] parameters ={
                        "_input_charset=UTF-8",
                       "out_trade_no="+payinfo.flow_no,
                         "seller_id="+payinfo.partner,
                        "partner="+payinfo.partner,
                        "alipay_ca_request=2",
                       "service=alipay.acquire.refund",
                       "refund_amount="+payinfo.pay_amt, 
                       "out_request_no="+payinfo.out_request_no
                                 };
            string MySign = MD5Helper.CreatUrl(parameters, "UTF-8", "MD5", payinfo.md5key);

            StringBuilder prestr = new StringBuilder();

            for (int i = 0; i < parameters.Length; i++)
            {
                if (i == parameters.Length - 1)
                {
                    prestr.Append(parameters[i]);

                }
                else
                {
                    prestr.Append(parameters[i] + "&");
                }

            }

            StrUrl = Url + prestr + "&sign_type=MD5&sign=" + MySign;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(StrUrl);
            var res = req.GetResponse() as HttpWebResponse;
            Stream stream = res.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string strreturn = sr.ReadToEnd().ToString();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(strreturn);

            string isSuccess = doc.SelectSingleNode("alipay/is_success/text()").InnerText;

            XmlNode nodelist = doc.SelectSingleNode("alipay/response/alipay");

            ReturnRefundInfo rpinfo = new ReturnRefundInfo();
            rpinfo.is_success = isSuccess;
            if (rpinfo.is_success != "T")
            {
                rpinfo.error = doc.SelectSingleNode("alipay/error/text()").InnerText;
            }
            else
            {
                rpinfo.result_code = nodelist.SelectSingleNode("result_code").InnerText;
                if (rpinfo.result_code != "SUCCESS")
                {
                    rpinfo.detail_error_code = nodelist.SelectSingleNode("detail_error_code").InnerText;
                    rpinfo.detail_error_des = nodelist.SelectSingleNode("detail_error_des").InnerText;
                }
                else
                {
                    rpinfo.out_trade_no = nodelist.SelectSingleNode("out_trade_no").InnerText;
                    rpinfo.trade_no = nodelist.SelectSingleNode("trade_no").InnerText;
                    rpinfo.buyer_user_id = nodelist.SelectSingleNode("buyer_user_id").InnerText;
                    rpinfo.buyer_logon_id = nodelist.SelectSingleNode("buyer_logon_id").InnerText;
                    rpinfo.fund_change = nodelist.SelectSingleNode("fund_change").InnerText;
                }
            }
            //retRfundInfo = JsonConvert.SerializeObject(rpinfo);
            if (rpinfo.result_code == "SUCCESS")
            {
                string Paylog = "";
                //如果是退货,flow_no和out_request_no 对调
                Paylog = "Refund-flowno:" + payinfo.out_request_no + " out_request_no:" + payinfo.flow_no + " refund_amount:" + payinfo.pay_amt + " fund_change:" + rpinfo.fund_change + " SellWay:B AppName:" + payinfo.app_name + " Partner:" + payinfo.partner
                    + " Trade_no:" + rpinfo.trade_no + " BuyerId:" + rpinfo.buyer_user_id + " BuyerName:" + rpinfo.buyer_logon_id;
                WriteSysSuccesLog(Paylog);

                #region 支付宝分配给思迅的ID
                string selfAgentId = string.Empty;
                if (string.IsNullOrEmpty(payinfo.app_name) || string.IsNullOrEmpty(payinfo.app_name.Trim()))
                {
                    selfAgentId = UserInfo.AGENT_ID;
                }
                else if (UserInfo.siss_app_name1.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id1;
                }
                else if (UserInfo.siss_app_name2.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id2;
                }
                else if (UserInfo.siss_app_name3.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id3;
                }
                else if (UserInfo.siss_app_name4.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id4;
                }
                if (string.IsNullOrEmpty(selfAgentId) || string.IsNullOrEmpty(selfAgentId.Trim()))
                {
                    selfAgentId = UserInfo.AGENT_ID;
                }
                ExtendParams eParams = new ExtendParams();
                eParams.AGENT_ID = selfAgentId;
                #endregion

                WriteDbLog(LogType.OperSuccess, OperType.Refund, payinfo, null, null, rpinfo, eParams);

            }
            return rpinfo;

        }

        //2015年1月9日
        public ReturnRefundInfo Refund1(PayInfo payinfo)
        {
            string strPayInfo = string.Empty;
            ReturnRefundInfo rpinfo = new ReturnRefundInfo();
            try
            {
                if (string.IsNullOrEmpty(payinfo.version))
                {
                    rpinfo.is_success = "F";
                    rpinfo.error = "没有提供VERSION";
                    return rpinfo;
                }

                #region app_name限制
                string selfAgentId = string.Empty;
                if (string.IsNullOrEmpty(payinfo.app_name) || string.IsNullOrEmpty(payinfo.app_name.Trim()))
                {
                    rpinfo.is_success = "F";
                    rpinfo.error = "app_name为空！";
                    return rpinfo;
                }
                else if (UserInfo.siss_app_name1.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id1;
                }
                else if (UserInfo.siss_app_name2.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id2;
                }
                else if (UserInfo.siss_app_name3.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id3;
                }
                else if (UserInfo.siss_app_name4.IndexOf(payinfo.app_name) >= 0)
                {
                    selfAgentId = UserInfo.siss_agent_id4;
                }
                if (string.IsNullOrEmpty(selfAgentId) || string.IsNullOrEmpty(selfAgentId.Trim()))
                {
                    //rpinfo.is_success = "F";
                    //rpinfo.error = string.Format("app_name[{0}]错误，后台没有配置！", payinfo.app_name);
                    //return rpinfo;
                }
                #endregion

                string PKV = payinfo.version;

                string requst_data = RsaHelper.Decrypt(PKV, payinfo.request_data);

                string[] datas = requst_data.Split('\n');

                //对几项解密
                decimal tmpAmount = 0M;
                payinfo.partner = datas[0];
                payinfo.md5key = datas[1];
                payinfo.flow_no = datas[2];
                if (!decimal.TryParse(datas[3], out tmpAmount))
                {
                    rpinfo.is_success = "F";
                    rpinfo.error = "不能转换为金额";
                    return rpinfo;
                }
                payinfo.pay_amt = tmpAmount;

                strPayInfo = JsonConvert.SerializeObject(payinfo);

                rpinfo = Refund(strPayInfo);
                return rpinfo;
            }
            catch (Exception ex)
            {
                rpinfo.is_success = "F";
                rpinfo.error = ex.Message;
                return rpinfo;
            }

        }

        #endregion

        #region 记录日志
        /// <summary>
        /// 请求数据日志,写入ZFB开头的TXT
        /// </summary>
        /// <param name="strLog"></param>
        public void WriteSysLog(string strLog)
        {
            if (UserInfo.is_write_log)
            {
                try
                {
                    string apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
                    string strPath = apppath + "\\log\\ZFB" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                    string directory;
                    directory = strPath.Substring(0, strPath.LastIndexOf("\\"));
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + strLog);

                    sw.Close();
                    fs.Close();
                }
                catch //(Exception e)
                {
                    //return 0; 暂不处理.
                }
            }
        }

        /// <summary>
        /// 支付成功日志
        /// </summary>
        /// <param name="strLog"></param>
        public void WriteSysSuccesLog(string strLog)
        {
            if (UserInfo.is_write_log)
            {
                try
                {
                    string apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
                    string strPath = apppath + "\\PayLog\\PayLog" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                    string directory;
                    directory = strPath.Substring(0, strPath.LastIndexOf("\\"));
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + strLog);

                    sw.Close();
                    fs.Close();
                }
                catch //(Exception e)
                {
                    //return 0; 暂不处理.
                }
            }
        }

        public void WriteDbLog(LogType logType, OperType operType, PayInfo payi,
            ReturnPayInfo rPayI, ReturnQueryInfo rQueryI, ReturnRefundInfo rRefundI,
            ExtendParams eParams)
        {
            try
            {
                if (UserInfo.Is_write_dblog)
                {
                    PayLog pLog = new PayLog();
                    pLog.logtime = DateTime.Now;
                    pLog.log_type = logType.ToString();
                    pLog.oper_type = operType.ToString();
                    //pay
                    pLog.pay_way = "支付宝";
                    pLog.pay_type = "线下";

                    if (payi != null)
                    {
                        pLog.softdog_id = payi.softdog_id;
                        pLog.partner = payi.partner;
                        //pLog.md5key = payi.md5key;
                        pLog.flow_no = payi.flow_no;
                        pLog.pay_amt = payi.pay_amt;
                        pLog.order_title = payi.order_title;
                        pLog.bar_code = payi.bar_code;
                        pLog.app_name = payi.app_name;
                        pLog.out_request_no = payi.out_request_no;
                        pLog.version = payi.version;

                        //如果是退货flow_no和out_request_no写入数据库是对调
                        if (operType == OperType.Refund)
                        {
                            pLog.flow_no = payi.out_request_no;
                            pLog.out_request_no = payi.flow_no;
                        }
                    }

                    if (eParams != null)
                        pLog.self_agent_id = eParams.AGENT_ID;

                    if (rPayI != null)//createandpay
                    {
                        pLog.trade_no = rPayI.trade_no;
                        pLog.buyer_user_id = rPayI.buyer_user_id;
                        pLog.buyer_logon_id = rPayI.buyer_logon_id;
                    }

                    if (rQueryI != null)//payquery
                    {
                        pLog.trade_no = rQueryI.trade_no;
                        pLog.buyer_user_id = rQueryI.buyer_user_id;
                        pLog.buyer_logon_id = rQueryI.buyer_logon_id;
                    }

                    if (rRefundI != null)//Refund
                    {
                        pLog.trade_no = rRefundI.trade_no;
                        pLog.buyer_user_id = rRefundI.buyer_user_id;
                        pLog.buyer_logon_id = rRefundI.buyer_logon_id;
                    }

                    PayLogDal dal = new PayLogDal();
                    dal.Insert(pLog);
                }
            }
            catch (Exception ex)
            {
                WriteErrLog("WriteDbLog:" + ex.Message);
            }
        }

        /// <summary>
        /// 写入ERR开头的TXT
        /// </summary>
        /// <param name="strLog"></param>
        public void WriteErrLog(string strLog)
        {

            try
            {
                string apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
                string strPath = apppath + "\\log\\ERR" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                string directory;
                directory = strPath.Substring(0, strPath.LastIndexOf("\\"));
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + strLog);

                sw.Close();
                fs.Close();
            }
            catch //(Exception e)
            {
                //return 0; 暂不处理.
            }

        }

        #endregion

        public Stream SomeOne(Stream inputStream)
        {
            byte[] byIn = inputStream.ReadBytes();
            string json = Encoding.UTF8.GetString(byIn);
            PayInfo pi = (PayInfo)JsonConvert.DeserializeObject(json, typeof(PayInfo));



            string strRst = "123456";
            byte[] bytesOut = Encoding.UTF8.GetBytes(strRst);
            MemoryStream streamRst = new MemoryStream(bytesOut);
            return streamRst;
        }

        public Stream SomeOnes(byte[] inputStream)
        {

            string json = Encoding.UTF8.GetString(inputStream);
            PayInfo pi = (PayInfo)JsonConvert.DeserializeObject(json, typeof(PayInfo));



            string strRst = "123456";
            byte[] bytesOut = Encoding.UTF8.GetBytes(strRst);
            MemoryStream streamRst = new MemoryStream(bytesOut);
            return streamRst;
        }
    }
}
