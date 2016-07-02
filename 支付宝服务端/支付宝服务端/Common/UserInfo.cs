using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 支付宝服务端.Common
{
    public static class UserInfo
    {
        private static string _AGENT_ID = "";
        /// <summary>
        /// 代理人ID（默认石基）
        /// </summary>
        public static string AGENT_ID
        {
            get { return _AGENT_ID; }
            set { _AGENT_ID = value; }
        }

        private static string _siss_agent_id1 = "";
        /// <summary>
        /// 思讯软件代理商ID1
        /// </summary>
        public static string siss_agent_id1
        {
            get { return _siss_agent_id1; }
            set { _siss_agent_id1 = value; }
        }

        private static string _siss_agent_id2 = "";
        /// <summary>
        /// 思讯软件代理商ID2
        /// </summary>
        public static string siss_agent_id2
        {
            get { return _siss_agent_id2; }
            set { _siss_agent_id2 = value; }
        }

        private static string _siss_agent_id3 = "";
        /// <summary>
        /// 思讯软件代理商ID3
        /// </summary>
        public static string siss_agent_id3
        {
            get { return _siss_agent_id3; }
            set { _siss_agent_id3 = value; }
        }

        private static string _siss_agent_id4 = "";
        /// <summary>
        /// 思讯软件代理商ID4
        /// </summary>
        public static string siss_agent_id4
        {
            get { return _siss_agent_id4; }
            set { _siss_agent_id4 = value; }
        }

        private static string _siss_app_name1 = "";
        /// <summary>
        /// 代理商ID1对应产品名
        /// </summary>
        public static string siss_app_name1
        {
            get { return _siss_app_name1; }
            set { _siss_app_name1 = value; }
        }

        private static string _siss_app_name2 = "";
        /// <summary>
        /// 代理商ID2对应产品名
        /// </summary>
        public static string siss_app_name2
        {
            get { return _siss_app_name2; }
            set { _siss_app_name2 = value; }
        }

        private static string _siss_app_name3 = "";
        /// <summary>
        /// 代理商ID3对应产品名
        /// </summary>
        public static string siss_app_name3
        {
            get { return _siss_app_name3; }
            set { _siss_app_name3 = value; }
        }

        private static string _siss_app_name4 = "";
        /// <summary>
        /// 代理商ID4对应产品名
        /// </summary>
        public static string siss_app_name4
        {
            get { return _siss_app_name4; }
            set { _siss_app_name4 = value; }
        }

        private static bool _is_write_log = false;
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public static bool is_write_log
        {
            get { return _is_write_log; }
            set { _is_write_log = value; }
        }

        #region 数据库日志
        static bool _is_write_dblog = false;

        public static bool Is_write_dblog
        {
            get { return UserInfo._is_write_dblog; }
            set { UserInfo._is_write_dblog = value; }
        }

        static string _db_ip = string.Empty;

        public static string Db_ip
        {
            get { return UserInfo._db_ip; }
            set { UserInfo._db_ip = value; }
        }
        static string _db_name = string.Empty;
        /// <summary>
        /// 数据库名
        /// </summary>
        public static string Db_name
        {
            get { return UserInfo._db_name; }
            set { UserInfo._db_name = value; }
        }
        static string _db_Uname = string.Empty;
        /// <summary>
        /// 数据库用户名
        /// </summary>
        public static string Db_Uname
        {
            get { return UserInfo._db_Uname; }
            set { UserInfo._db_Uname = value; }
        }
        static string _db_pwd = string.Empty;

        public static string Db_pwd
        {
            get { return UserInfo._db_pwd; }
            set { UserInfo._db_pwd = value; }
        }
        #endregion


        public static string NoneSissDefaultPrompt = "此支付宝商户非思迅的签约商户，支付宝付款不能使用，请联系当地思迅代理商。";

        static bool _NoneSissMerchantCannotUse;
        /// <summary>
        /// 非思迅的签约商户不能使用。默认为FALSE，TRUE则限制。
        /// </summary>
        public static bool NoneSissMerchantCannotUse
        {
            get { return UserInfo._NoneSissMerchantCannotUse; }
            set { UserInfo._NoneSissMerchantCannotUse = value; }
        }

        static string _NoneSissPrompt = string.Empty;
        /// <summary>
        /// 非思迅的签约商户提示信息
        /// </summary>
        public static string NoneSissPrompt
        {
            get { return UserInfo._NoneSissPrompt; }
            set { UserInfo._NoneSissPrompt = value; }
        }

    }
}
