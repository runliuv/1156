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
    public class Response<T> where T : class
    {
        /// <summary>
        /// 结果编号
        /// </summary>
        [DataMember]
        public int Code { get; set; }

        /// <summary>
        /// 结果消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }


        [DataMember]
        public T Data { get; set; }
    }
}
