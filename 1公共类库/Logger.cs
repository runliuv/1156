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
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")+" " + content);
            }
            catch { return; }
        }
    }
}
