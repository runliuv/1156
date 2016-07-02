using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 支付宝服务端.Common
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 请求数据
        /// </summary>
        RequestData,
        /// <summary>
        /// 操作完成
        /// </summary>
        OperSuccess
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperType
    {
        CreatAndPay,
        PayQuery,
        Refund,
        Cancel
    }
}
