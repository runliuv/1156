using System;
using System.Runtime.InteropServices;

namespace UsualLib
{
    /// <summary>
    /// 设置分辨率.VER 2013.12.17
    /// </summary>
    public class SetResolution
    {
        #region 设置分辨率

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public short dmOrientation;
            public short dmPaperSize;
            public short dmPaperLength;
            public short dmPaperWidth;
            public short dmScale;
            public short dmCopies;
            public short dmDefaultSource;
            public short dmPrintQuality;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int ChangeDisplaySettings([In]ref DEVMODE lpDevMode, int dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool EnumDisplaySettings(string lpszDeviceName, Int32 iModeNum, ref DEVMODE lpDevMode);

        /// <summary>
        /// 设置分辨率.宽、高、刷新率、颜色。
        /// </summary>
        /// <param name="PelsWidth"></param>
        /// <param name="PelsHeight"></param>
        /// <param name="DisplayFrequency"></param>
        /// <param name="BitsPerPel"></param>
        public static void ChangeRes(int PelsWidth, int PelsHeight, int DisplayFrequency, int BitsPerPel)
        {
            DEVMODE devM = new DEVMODE();
            devM.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            bool mybool;
            mybool = EnumDisplaySettings(null, 0, ref devM);

            devM.dmPelsWidth = PelsWidth;
            devM.dmPelsHeight = PelsHeight;

            devM.dmDisplayFrequency = DisplayFrequency;
            devM.dmBitsPerPel = BitsPerPel;
            long result = ChangeDisplaySettings(ref devM, 0);
        }
        #endregion

    }
}
