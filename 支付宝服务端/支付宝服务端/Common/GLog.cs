using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace 支付宝服务端.Common
{
    public class GLog
    {
        /// <summary>
        /// 写入ERR开头的TXT
        /// </summary>
        /// <param name="strLog"></param>
        public static void WriteErrLog(string strLog)
        {

            try
            {
                string apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
                string strPath = apppath + "\\log\\ERR" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                string directory;
                directory = strPath.Substring(0, strPath.LastIndexOf("\\"));
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + strLog);

                sw.Close();
                fs.Close();
            }
            catch //(Exception e)
            {
                //return 0; 暂不处理.
            }

        }
    }
}
