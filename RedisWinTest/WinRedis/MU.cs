using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinRedis
{
    public class MU
    {
        public static string HttpReq(string url, string postStr)
        {
            int httpTimeOut = 30;

            #region http web request
            byte[] data = Encoding.UTF8.GetBytes(postStr);
            HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create(url);
            wreq.Timeout = httpTimeOut * 1000;
            wreq.ReadWriteTimeout = httpTimeOut * 1000;
            wreq.Method = "POST";
            wreq.ContentType = "application/json;charset=utf-8";
            wreq.ContentLength = data.Length;
            using (Stream putStream = wreq.GetRequestStream())
            {
                putStream.Write(data, 0, data.Length);
            }

            var res = wreq.GetResponse() as HttpWebResponse;
            byte[] by = new byte[800];
            using (Stream stream = res.GetResponseStream())
            {
                int size = 1024;
                int read = 0;
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[size];
                    do
                    {
                        read = stream.Read(buffer, 0, size);
                        ms.Write(buffer, 0, read);
                    } while (read > 0);

                    by = ms.ToArray();
                }
            }

            string strRst = Encoding.UTF8.GetString(by);
            #endregion

            return strRst;
        }

        public static string HttpReqG(string url, string postStr)
        {
            int httpTimeOut = 30;

            #region http web request
            //byte[] data = Encoding.UTF8.GetBytes(postStr);
            HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create(url);
            wreq.Timeout = httpTimeOut * 1000;
            wreq.ReadWriteTimeout = httpTimeOut * 1000;
            wreq.Method = "GET";
            wreq.ContentType = "application/json;charset=utf-8";
            //wreq.ContentLength = data.Length;
            //using (Stream putStream = wreq.GetRequestStream())
            //{
            //    putStream.Write(data, 0, data.Length);
            //}

            var res = wreq.GetResponse() as HttpWebResponse;
            byte[] by = new byte[800];
            using (Stream stream = res.GetResponseStream())
            {
                int size = 1024;
                int read = 0;
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[size];
                    do
                    {
                        read = stream.Read(buffer, 0, size);
                        ms.Write(buffer, 0, read);
                    } while (read > 0);

                    by = ms.ToArray();
                }
            }

            string strRst = Encoding.UTF8.GetString(by);
            #endregion

            return strRst;
        }

    }
}
