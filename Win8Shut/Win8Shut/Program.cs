using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Win8Shut
{
    static class Program
    {
        static System.Threading.Mutex appMutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string exeName = "Win8Shut";
            string appName = "关机快捷键程序";

            bool createNew;
            appMutex = new System.Threading.Mutex(true, exeName, out createNew);
            if (!createNew)
            {
                appMutex.Close(); 
                appMutex = null;
                MessageBox.Show(appName + "已开启，进程为" + exeName + "！", "提示");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
