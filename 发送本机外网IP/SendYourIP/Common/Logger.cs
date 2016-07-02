using System;
using System.IO;
using System.Windows.Forms;

namespace UsualLib
{
    /// <summary>
    /// 二○一四年一月八日
    /// </summary>
    public class Logger
    {
        #region VAR
        static string lastIPFullName = Application.StartupPath + "\\LastIP.txt";
        #endregion

        public static void Log(string content)
        {
            string errDir = "ErrLog";
            string errDirFullName = Application.StartupPath + "\\" + errDir + "\\";

            try
            {
                if (!Directory.Exists(errDirFullName))
                    Directory.CreateDirectory(errDirFullName);
            }
            catch { return; }

            string fileName = DateTime.Now.ToString("yyyy-MM-dd HH") + ".txt";
            string logFullName = errDirFullName + fileName;

            try
            {
                using (FileStream fs = new FileStream(logFullName, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + content);
            }
            catch { return; }
        }

        /// <summary>
        /// 写入最后IP
        /// </summary>
        /// <param name="content"></param>
        public static void WriteLastIP(string content)
        {
            try
            {
                using (FileStream fs = new FileStream(lastIPFullName, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                    sw.Write(content);
            }
            catch { return; }
        }

        /// <summary>
        /// 读取最后IP
        /// </summary>
        /// <returns></returns>
        public static string ReadLastIP()
        {
            string rst = string.Empty;
            try
            {
                using (FileStream fs = new FileStream(lastIPFullName, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                    rst = sr.ReadToEnd();
            }
            catch { }

            return rst;
        }
    }
}
