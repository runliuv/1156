using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Response<T> where T : class
    {
        /// <summary>
        /// 结果编号
        /// </summary>
        
        public int Code { get; set; }

        /// <summary>
        /// 结果消息
        /// </summary>
        
        public string Message { get; set; }


        
        public T Data { get; set; }
    }
}