using System.Windows.Forms;
using Microsoft.Win32;

namespace UsualLib
{
    /// <summary>
    /// 开机启动.14.4.22
    /// </summary>
    public class StartOnSysStart
    {
        public static void RegAutoStart(string startOnSysStartRegKey)
        {
            RegistryKey reg;
            reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue(startOnSysStartRegKey, Application.ExecutablePath);
            reg.Close();
        }

        public static void UnRegAutoStart(string startOnSysStartRegKey)
        {
            RegistryKey reg;
            reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //如果存在则删除，不存在不处理，否则报错
            object obSt = reg.GetValue(startOnSysStartRegKey);
            if (obSt != null)
            {
                reg.DeleteValue(startOnSysStartRegKey);
            }
            reg.Close();
        }

        /// <summary>
        /// 检查开始启动，从注册表中查询。
        /// </summary>
        public static bool CheckStartWhenWinStart(string startOnSysStartRegKey)
        {
            bool rst = false;
            RegistryKey reg;
            reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            object obSt = reg.GetValue(startOnSysStartRegKey);
            if (obSt != null)
            {
                rst = true;
                //如果存在，检查路径是否正确。
                if (obSt.ToString().ToLower() != Application.ExecutablePath.ToLower())
                {
                    RegAutoStart(startOnSysStartRegKey);
                }
            }
            reg.Close();

            return rst;
        }
    }
}
