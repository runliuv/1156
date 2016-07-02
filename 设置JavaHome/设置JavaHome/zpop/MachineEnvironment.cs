using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace UsualLib
{
    /// <summary>
    /// v 2013.12.24
    /// </summary>
    public class MachineEnvironment
    {
        //不要用 Environment.GetEnvironmentVariable方法去取值，它会把%java_home%转为绝对路径。
        //Environment.GetEnvironmentVariable("CLASSPATH", System.EnvironmentVariableTarget.Machine);

        /// <summary>
        /// 查找环境变量
        /// </summary>
        /// <param name="envName"></param>
        /// <returns></returns>
        public static string QueryEnvironment(string envName)
        {
            string rst = string.Empty;

            using (RegistryKey regLocalMachine = Registry.LocalMachine)
            using (RegistryKey rkFinal = regLocalMachine.OpenSubKey(@"System\ControlSet001\Control\Session Manager\Environment", true))
                try
                {
                    rst = rkFinal.GetValue(envName, string.Empty, RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();

                    //不要用RegistryValueOptions.None，它会把%java_home%之类的转成绝对路径
                    //rst = rkFinal.GetValue(envName, string.Empty, RegistryValueOptions.None).ToString();
                }
                catch { }

            return rst;
        }

        /// <summary>
        /// 设置环境变量
        /// </summary>
        /// <param name="envName"></param>
        /// <param name="envValue"></param>
        /// <returns></returns>
        public static bool SetEnvironment(string envName, string envValue)
        {
            if (string.IsNullOrEmpty(envValue))
                return false;

            bool rst = true;
            using (RegistryKey regLocalMachine = Registry.LocalMachine)
            using (RegistryKey rkFinal = regLocalMachine.OpenSubKey(@"System\ControlSet001\Control\Session Manager\Environment", true))
                try
                {
                    RegistryValueKind rvk = RegistryValueKind.String;
                    if (envValue.Contains("%"))
                        rvk = RegistryValueKind.ExpandString;
                    rkFinal.SetValue(envName, envValue, rvk);
                    
                    
                }
                catch
                {
                    rst = false;
                }

            NotifyOS.NotifyOS1();

            return rst;
        }

    }
}
