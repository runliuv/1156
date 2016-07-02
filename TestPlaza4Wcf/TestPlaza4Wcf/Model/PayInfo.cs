using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPlaza4Wcf.Model
{
   public class PayInfo
    {
        /// <summary>
        /// 前台产生的单号
        /// </summary>
        public string flow_no { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal pay_amt { get; set; }

        /// <summary>
        /// 订单标题(商品的标题/交易标题/订单标题/订单关键字等)
        /// </summary>
        public string order_title { get; set; }

        /// <summary>
        /// 扫描到的顾客条码
        /// </summary>
        public string bar_code { get; set; }

        ///// <summary>
        ///// 交易订单信息
        ///// </summary>
        //public string order_memo { get; set; }

        /// <summary>
        /// 产品版本号
        /// </summary>
        public string app_name { get; set; }
    }
}
