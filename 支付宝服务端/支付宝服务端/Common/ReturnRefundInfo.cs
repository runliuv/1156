using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 支付宝服务端.Common
{
    public class ReturnRefundInfo : ReturnPayInfo
    {
        /// <summary>
        /// 本次退款请求是否发生资金变动
        /// </summary>
        public string fund_change { get; set; }
    }
}
