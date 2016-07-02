using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 支付宝服务端.Common
{
    //PayLog
    [Serializable]
    public partial class PayLog : ICloneable
    {

        private string _log_type;

        private string _oper_type;

        private string _pay_way;

        private string _pay_type;

        private string _softdog_id;

        private string _partner;

        private string _md5key;

        private string _flow_no;

        private decimal? _pay_amt;

        private string _order_title;

        private string _bar_code;

        private string _app_name;

        private string _out_request_no;

        private string _version;

        private string _trade_no;

        private string _buyer_user_id;

        private string _buyer_logon_id;

        private string _self_agent_id;

        private string _agent_id;

        private DateTime? _logtime;
        public string log_type
        {
            get { return _log_type; }
            set { _log_type = value; }
        }
        public string oper_type
        {
            get { return _oper_type; }
            set { _oper_type = value; }
        }
        /// <summary>
        /// 支付方式:支付宝/微信
        /// </summary>
        public string pay_way
        {
            get { return _pay_way; }
            set { _pay_way = value; }
        }
        /// <summary>
        /// 支付类型:线上/线下
        /// </summary>
        public string pay_type
        {
            get { return _pay_type; }
            set { _pay_type = value; }
        }
        public string softdog_id
        {
            get { return _softdog_id; }
            set { _softdog_id = value; }
        }
        public string partner
        {
            get { return _partner; }
            set { _partner = value; }
        }
        public string md5key
        {
            get { return _md5key; }
            set { _md5key = value; }
        }
        public string flow_no
        {
            get { return _flow_no; }
            set { _flow_no = value; }
        }
        public decimal? pay_amt
        {
            get { return _pay_amt; }
            set { _pay_amt = value; }
        }
        public string order_title
        {
            get { return _order_title; }
            set { _order_title = value; }
        }
        public string bar_code
        {
            get { return _bar_code; }
            set { _bar_code = value; }
        }
        public string app_name
        {
            get { return _app_name; }
            set { _app_name = value; }
        }
        public string out_request_no
        {
            get { return _out_request_no; }
            set { _out_request_no = value; }
        }
        public string version
        {
            get { return _version; }
            set { _version = value; }
        }
        public string trade_no
        {
            get { return _trade_no; }
            set { _trade_no = value; }
        }
        public string buyer_user_id
        {
            get { return _buyer_user_id; }
            set { _buyer_user_id = value; }
        }
        public string buyer_logon_id
        {
            get { return _buyer_logon_id; }
            set { _buyer_logon_id = value; }
        }
        /// <summary>
        /// 支付宝分配给思迅的ID
        /// </summary>
        public string self_agent_id
        {
            get { return _self_agent_id; }
            set { _self_agent_id = value; }
        }
        /// <summary>
        /// 思迅的代理商 暂空
        /// </summary>
        public string agent_id
        {
            get { return _agent_id; }
            set { _agent_id = value; }
        }
        public DateTime? logtime
        {
            get { return _logtime; }
            set { _logtime = value; }
        }
        private bool _isNew = false;
        /// <summary>
        /// 是否新记录.
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        #region ICloneable 成员
        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion
    }
}
