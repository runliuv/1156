using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 支付宝客户端调用.Common
{
    public class ReturnCancelInfo : ReturnPayInfo
    {
        /// <summary>
        /// 是否可重试标志
        /// </summary>
        public string retry_flag { get; set; }
    }
}
