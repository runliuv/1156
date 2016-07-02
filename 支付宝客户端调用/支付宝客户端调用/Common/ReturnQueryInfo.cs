using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 支付宝客户端调用.Common
{
    public class ReturnQueryInfo : ReturnPayInfo
    {
        /// <summary>
        /// 交易状态
        /// </summary>
        public string trade_status { get; set; }

        /// <summary>
        /// 合作者身份ID
        /// </summary>
        public string partner { get; set; }
    }
}
