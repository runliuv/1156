using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace 支付宝客户端调用.Common
{
    public class RsaHelper
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="lpszData"></param>
        /// <param name="lpszCipherText"></param>
        /// <param name="dwCipherTextSize"></param>
        /// <returns></returns>
        [DllImport("LibBarcodePay.dll", CharSet = CharSet.Ansi)]
        public static extern bool RsaEncrypt(string lpszData, StringBuilder lpszCipherText, Int32 dwCipherTextSize);

        //extern "C" VOID PASCAL EXPORT LibVersion( LPSTR lpszBuffer, DWORD32 dwTextSize);

        /// <summary>
        /// 版本
        /// </summary>
        /// <param name="lpszCipherText"></param>
        /// <param name="dwCipherTextSize"></param>
        /// <returns></returns>
        [DllImport("LibBarcodePay.dll", CharSet = CharSet.Ansi)]
        public static extern void LibVersion(StringBuilder lpszCipherText, Int32 dwCipherTextSize);
    }
}
