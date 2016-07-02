using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UsualLib
{
    /// <summary>
    /// 2014年1月8日
    /// </summary>
    public class GetIP
    {
        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string GetFromIp138()
        {
            string contentAll = string.Empty;
            string rst = string.Empty;
            try
            {
                string strUrl = "http://1212.ip138.com/ic.asp";

                Uri uri = new Uri(strUrl);
                WebRequest webreq =  WebRequest.Create(uri);
                 
                using (Stream s = webreq.GetResponse().GetResponseStream())
                using (StreamReader sr = new StreamReader(s, Encoding.Default))
                    rst = sr.ReadToEnd();
                //分析字符串得到IP   
                string strRex = "<center>(.*?)</center>";
                if (Regex.IsMatch(rst, strRex))
                {
                    Match mRst = Regex.Match(rst, strRex);
                    contentAll = mRst.Value;

                    contentAll = contentAll.Replace("<center>", "").Replace("</center>", "");
                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return contentAll;
        }

        public static string GetFromChinaZ()
        {
            string contentAll = string.Empty;
            string rst = string.Empty;
            try
            {
                string strUrl = "http://ip.chinaz.com/getip.aspx";

                Uri uri = new Uri(strUrl);
                WebRequest webreq = WebRequest.Create(uri);

                using (Stream s = webreq.GetResponse().GetResponseStream())
                using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                    rst = sr.ReadToEnd();
                //分析字符串得到IP   
                string strRex = "ip(.*?)address";
                if (Regex.IsMatch(rst, strRex))
                {
                    Match mRst = Regex.Match(rst, strRex);
                    contentAll = mRst.Value;

                    contentAll = contentAll.Replace("ip", "").Replace("address", "");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return contentAll;
        }

        public static string GetFromIpQQcom()
        {
            string contentAll = string.Empty;
            string rst = string.Empty;
            try
            {
                string strUrl = "http://ip.qq.com/";

                Uri uri = new Uri(strUrl);
                WebRequest webreq = WebRequest.Create(uri);

                using (Stream s = webreq.GetResponse().GetResponseStream())
                using (StreamReader sr = new StreamReader(s, Encoding.GetEncoding("gb2312")))
                    rst = sr.ReadToEnd();
                //分析字符串得到IP   
                string strRex = "value=(.*?)style=";
                if (Regex.IsMatch(rst, strRex))
                {
                    Match mRst = Regex.Match(rst, strRex);
                    contentAll = mRst.Value;

                    contentAll = contentAll.Replace("value=", "").Replace("style=", "");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return contentAll;
        }

        /// <summary>
        /// 计算机名
        /// </summary>
        /// <returns></returns>
        public static string GetComputerName()
        {
            string rst = "unKnown";
            try
            {
                rst = System.Environment.GetEnvironmentVariable("ComputerName");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rst;
        }
    }
}
