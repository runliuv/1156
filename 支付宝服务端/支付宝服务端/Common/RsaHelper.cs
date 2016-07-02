using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;

namespace 支付宝服务端.Common
{
    class RasKeyCache
    {
        public Hashtable CacheHashTable = Hashtable.Synchronized(new Hashtable());

        public RasKeyCache()
        {
            CacheHashTable["20141125"] = new RsaKeyInfo()
            {
                Modn = "C43FF1B295F4EF0843A413631EC530EAE28EABAB50D56077D4640EC10702091D76318801D767580F2F92257F81CA4E95C50AA67E950B5968FA417316CDD2A19C27C96CF94F421A9055D1940A09151A966372435E1C8E322B748522EC7AD0C8AA31E4978CE28C5D7A173BAED4F157A3A03455CEEF811399D586F46BE5F680F999",
                PrivateKey = "214DA1BE477D913B7702D4094BB81D630FF1C09AF172039CF43FA1AD49E449F9CC334AD3ECB059166A435662F1FA8D58A8BF9968DA4711119C3700DD5D329D9EFD9E83E5DEF16A46CA9CEF43D25B7BE978EA4833EF1BFADB0FAF8C6570D31B18D824ACD4CF7D79E2E97620B68F0476E53990C1331FBE1BA2C93AB7561622BFF3",
            };

            CacheHashTable["20141126"] = new RsaKeyInfo()
            {
                Modn = "",
                PrivateKey = "",
            };
        }
    }

    public class RsaHelper
    {
        [DllImport("LibAlipay.dll", CharSet = CharSet.Ansi)]
        public static extern bool RsaDecrypt(string lpszPriKey, string lpszModN,
                                         string lpszCipherText, ref byte lpbData, ref Int32 dwDataSize);

        private static RasKeyCache rkcKeysCache = new RasKeyCache();


        /// <summary>
        /// 密钥版本是否存在
        /// </summary>
        /// <param name="PKV"></param>
        /// <returns></returns>
        public static bool ExistsKey(string PKV)
        {
            try
            {
                return rkcKeysCache.CacheHashTable.ContainsKey(PKV);
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// RSA私钥解密
        /// </summary>
        /// <param name="PKV">密钥版本</param>
        /// <param name="lpszCipherText">密文</param>
        /// <returns></returns>
        public static string Decrypt(string PKV, string lpszCipherText)
        {
            RsaKeyInfo rsaKey = rkcKeysCache.CacheHashTable[PKV] as RsaKeyInfo;
            if (rsaKey == null) throw new ApplicationException("PKV已失效,请您升级更新程序!");

            return DecryptString(rsaKey.Modn, rsaKey.PrivateKey, lpszCipherText);

        }

        /// <summary>
        /// RSA解密字串
        /// </summary>
        /// <param name="Modn">模数</param>
        /// <param name="Key">私钥/公钥</param>
        /// <param name="lpszCipherText"></param>
        /// <returns></returns>
        public static string DecryptString(string Modn, string Key, string lpszCipherText)
        {
            if (string.IsNullOrEmpty(Modn) || string.IsNullOrEmpty(Key))
                return string.Empty;

            int dwDataSize = (lpszCipherText.Length + 256 - 1) / 256 * 128 + 1;
            byte[] byteData = new byte[dwDataSize];

            if (RsaDecrypt(Key, Modn, lpszCipherText, ref byteData[0], ref dwDataSize))
            {
                string data = Encoding.UTF8.GetString(byteData, 0, dwDataSize);
                return data.TrimEnd('\0');
            }

            return string.Empty;
        }



        ///// <summary>
        ///// 使用指定的KEY和模数加密字符串
        ///// </summary>
        //public static string EncryptString(string Modn, string Key, string data)
        //{
        //    byte[] lpbData = Encoding.UTF8.GetBytes(data);
        //    Int32 dwDataSize = (lpbData.Length / 60 + 1) * 128 + 1;
        //    StringBuilder sbText = new StringBuilder(dwDataSize);

        //    if (!RsaEncrypt(Key, Modn, ref lpbData[0], lpbData.Length, sbText, dwDataSize))
        //    {
        //        throw new ApplicationException("加密数据失败!");
        //    }

        //    return sbText.ToString();
        //}





    }
}
