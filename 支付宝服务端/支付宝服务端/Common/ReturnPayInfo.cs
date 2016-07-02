using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 支付宝服务端.Common
{
    /// <summary>
    /// 调用creatandpay成功后支付宝方返回的参数
    /// </summary>
    public class ReturnPayInfo
    {
        /// <summary>
        /// 请求是否成功(T 或 F)
        /// </summary>
        public string is_success { get; set; }

        /// <summary>
        /// 签名方式
        /// </summary>
        public string sign_type { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// 响应码
        /// </summary>
        public string result_code { get; set; }

        /// <summary>
        /// 该交易在支付宝系统中的交易流水号
        /// </summary>
        public string trade_no { get; set; }

        /// <summary>
        /// 商户网站唯一订单号
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 详细错误码
        /// </summary>
        public string detail_error_code { get; set; }

        /// <summary>
        /// 详细错误描述
        /// </summary>
        public string detail_error_des { get; set; }

        /// <summary>
        /// 买家支付宝账号
        /// </summary>
        public string buyer_logon_id { get; set; }

        /// <summary>
        /// 买家支付宝用户号
        /// </summary>
        public string buyer_user_id { get; set; }
    }
}
