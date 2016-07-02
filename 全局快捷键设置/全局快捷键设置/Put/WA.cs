using System;
using System.Runtime.InteropServices;

namespace 全局快捷键设置
{


    /// <summary>
    /// Windows API
    /// </summary>
    public class WA
    {
        /// <summary>
        /// 注册快捷键
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);

        /// <summary>
        /// 取消注册
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, UInt32 id);
    }
}
