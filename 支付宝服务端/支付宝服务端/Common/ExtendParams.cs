using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 支付宝服务端.Common
{
    /// <summary>
    /// 业务扩展
    /// </summary>
    public class ExtendParams
    {
        /// <summary>
        /// 售货机机具号（传入SISS+产品版本）
        /// </summary>
        public string MACHINE_ID { get; set; }

        /// <summary>
        /// 代理人号
        /// </summary>
        public string AGENT_ID { get; set; }

        /// <summary>
        /// 门店类型
        /// </summary>
        public string STORE_TYPE { get; set; }

        /// <summary>
        /// 门店编号(传入加密狗号)
        /// </summary>
        public string STORE_ID { get; set; }

    }
}
