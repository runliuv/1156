using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace 支付宝服务端.Common
{
    [Serializable]
    [DataContract]
    public class PayInfo
    {
        ///// <summary>
        ///// 代理商ID
        ///// </summary>
        //public string siss_agent_id { get; set; }

        /// <summary>
        /// 加密狗号
        /// </summary>
        [DataMember]
        public string softdog_id { get; set; }

        /// <summary>
        /// 订单标题(商品的标题/交易标题/订单标题/订单关键字等)
        /// </summary>
        [DataMember]
        public string order_title { get; set; }

        /// <summary>
        /// 扫描到的顾客条码
        /// </summary>
        [DataMember]
        public string bar_code { get; set; }

        ///// <summary>
        ///// 交易订单信息
        ///// </summary>
        //public string order_memo { get; set; }

        /// <summary>
        /// 产品版本号
        /// </summary>
        [DataMember]
        public string app_name { get; set; }

        /// <summary>
        /// 商户退款请求单号
        /// </summary>
        [DataMember]
        public string out_request_no { get; set; }

        /// <summary>
        /// 加密软件版本号
        /// </summary>
        [DataMember]
        public string version { get; set; }

        /// <summary>
        /// 加密请求信息:合作者身份ID,商户支付宝账号交易安全校验码,前台产生的单号,付款金额
        /// </summary>
        [DataMember]
        public string request_data { get; set; }


        #region 将过期的

        /// <summary>
        /// 合作者身份ID
        /// </summary>
        [DataMember]
        public string partner { get; set; }

        /// <summary>
        /// 商户支付宝账号交易安全校验码
        /// </summary>
        [DataMember]
        public string md5key { get; set; }

        /// <summary>
        /// 前台产生的单号
        /// </summary>
        [DataMember]
        public string flow_no { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        [DataMember]
        public decimal pay_amt { get; set; }

        #endregion
    }
}
