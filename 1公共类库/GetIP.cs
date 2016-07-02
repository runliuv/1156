using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace UsualLib
{
    /// <summary>
    /// 2014年1月8日
    /// </summary>
    public class GetIP
    {
        public static string GetInternetIP_Way1()
        {
            string contentAll = string.Empty;
            string strUrl = "http://www.ip.cn";
            Uri uri = new Uri(strUrl);
            WebRequest webreq = WebRequest.Create(uri);
            using (Stream s = webreq.GetResponse().GetResponseStream())
            using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                contentAll = sr.ReadToEnd();
            //分析字符串得到IP   
            string strRex = "<code>(.*?)</code>";
            if (Regex.IsMatch(contentAll, strRex))
            {
                Match mRst = Regex.Match(contentAll, strRex);
                contentAll = mRst.Value;

                contentAll = contentAll.Replace("<code>", "ip.cn ").Replace("</code>", " end");
            }

            return contentAll;
        }
    }
}
