


using System;
using System.Runtime.Serialization;

namespace PosServer.Model
{
    /// <summary>
    /// 会员
    /// </summary>
    [Serializable]
    [DataContract]
    public class base_wxsf_vip_info
    {
        /// <summary>
        /// 这个字段线上表没有
        /// </summary>
        [DataMember]
        public string flow_no { get; set; }

        [DataMember]
        public string shopid { get; set; }
        [DataMember]
        public string openid { get; set; }
        [DataMember]
        public string branch_no { get; set; }
        [DataMember]
        public string card_id { get; set; }
        [DataMember]
        public string vip_name { get; set; }
        [DataMember]
        public string birthday { get; set; }
        [DataMember]
        public string vip_sex { get; set; }
        [DataMember]
        public string card_type { get; set; }
        [DataMember]
        public string type_no { get; set; }
        [DataMember]
        public string oper_date { get; set; }
        [DataMember]
        public string card_status { get; set; }

        [DataMember]
        public decimal acc_num { get; set; }
        [DataMember]
        public decimal dec_num { get; set; }
        /// <summary>
        /// 剩余积分
        /// </summary>
        [DataMember]
        public decimal now_acc_num { get; set; }

        [DataMember]
        public string vip_pass { get; set; }
        [DataMember]
        public string vip_start_date { get; set; }
        [DataMember]
        public string vip_end_date { get; set; }
        [DataMember]
        public string mobile { get; set; }
        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string favourableinfo { get; set; }
        [DataMember]
        public string vippic { get; set; }
        [DataMember]
        public string subscribe { get; set; }
        /// <summary>
        /// 0 绑定，1 注册
        /// </summary>
        [DataMember]
        public string oper_type { get; set; }


    }
}

