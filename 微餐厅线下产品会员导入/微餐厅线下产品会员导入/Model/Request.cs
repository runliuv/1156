using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Linq;

namespace PosServer.Model
{
    [Serializable]
    [DataContract]
    public class Request<T>
    {
        /// <summary>
        /// ShopID
        /// </summary>
        [DataMember]
        public string ShopID { get; set; }

        [DataMember]
        public string request_data { get; set; }
        /// <summary>
        /// 授权码
        /// </summary>
        [DataMember]
        public string AuthCode { get; set; }

        [DataMember]
        public string TimeOut { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [DataMember]
        public string Version { get; set; }

        /// <summary>
        /// 会话值
        /// </summary>
        [DataMember]
        public string Session { get; set; }

        ///// <summary>
        ///// 数据验证值
        ///// </summary>
        //[DataMember]
        //public string CheckMd5 { get; set; }

        /// <summary>
        /// 请求数据
        /// </summary>
        [DataMember]
        public T Data { get; set; }

    }
}
