using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1.Models
{
    public class GLog
    {
        static object oLock = new object();
        public static void WLog(string str)
        {
            lock (oLock)
            {
                try
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    string filePath = path + fileName;
                    FileStream fs = new FileStream(filePath, FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                    sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "----" + str);
                    sw.Close();
                    fs.Close();
                }
                catch { }
            }
        }
    }
}