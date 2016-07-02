using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 切克闹
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string mutexName = System.Environment.UserName + "nono";
            bool runone;
            System.Threading.Mutex run = new System.Threading.Mutex(true, mutexName, out runone);
            if (runone)
            {
                run.ReleaseMutex();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("已经运行了一个实例了。");
            }
        }
    }
}
