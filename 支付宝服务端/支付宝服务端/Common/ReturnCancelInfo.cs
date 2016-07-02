using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 支付宝服务端.Common
{
    public class ReturnCancelInfo : ReturnPayInfo
    {
        /// <summary>
        /// 是否可重试标志
        /// </summary>
        public string retry_flag { get; set; }
    }
}
