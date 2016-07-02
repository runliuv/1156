using System;
using System.Runtime.InteropServices;

namespace UsualLib
{
    public class NotifyOS
    {
        // SendMessageTimeout tools
        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }
        const int WM_SETTINGCHANGE = 0x001A;
        const int HWND_BROADCAST = 0xffff;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(
           IntPtr windowHandle,
           uint Msg,
           IntPtr wParam,
           string lParam,
           SendMessageTimeoutFlags flags,
           uint timeout,
           out IntPtr result
           );

        public static void NotifyOS1()
        {
            IntPtr result1;
            //修改后发送一个消息给系统 
            //调用
            SendMessageTimeout(
                                 new IntPtr(HWND_BROADCAST),
                                 WM_SETTINGCHANGE,
                                 IntPtr.Zero,
                                 "Environment",
                                 SendMessageTimeoutFlags.SMTO_ABORTIFHUNG,
                                 100,
                                 out result1);
        }
    }
}
