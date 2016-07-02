using System;
using System.Collections.Generic;
using System.Text;

namespace ResetZMV9pwd
{
    public static class EncryptClass
    {
        #region 字符加密
        /// <summary>
        /// 字符串加密(从PB中复制以兼容).
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encrypt(string strSource)
        {
            if (strSource.Length == 0) return "";

            char[] arrayTemp = strSource.ToCharArray();
            for (int i = 0; i < arrayTemp.Length; i++)
            {
                if (i <= arrayTemp.Length / 2 - 1)
                {
                    char temp = arrayTemp[i];
                    arrayTemp[i] = arrayTemp[arrayTemp.Length - 1 - i];
                    arrayTemp[arrayTemp.Length - 1 - i] = temp;
                }
            }

            System.Text.StringBuilder strRtn = new System.Text.StringBuilder();
            for (int i = 0; i < arrayTemp.Length; i++)
            {
                char a = Convert.ToChar(Convert.ToInt16(arrayTemp[i]) + (arrayTemp.Length - (i + 1) - 2) * 2);
                strRtn.Append(a);
            }
            return strRtn.ToString();
        }

        /// <summary>
        /// 字符串解密(从PB中复制以兼容).
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Decrypt(string strSource)
        {
            if (strSource.Length == 0) return "";

            char[] arrayTemp = strSource.ToCharArray();
            int len = arrayTemp.Length;
            StringBuilder strRtn = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                char a = Convert.ToChar(Convert.ToInt16(arrayTemp[i]) - (len - (i + 1) - 2) * 2);
                strRtn.Append(a);
            }
            arrayTemp = strRtn.ToString().ToCharArray();

            for (int i = 0; i < arrayTemp.Length; i++)
            {
                if (i <= arrayTemp.Length / 2 - 1)
                {
                    char temp = arrayTemp[i];
                    arrayTemp[i] = arrayTemp[arrayTemp.Length - 1 - i];
                    arrayTemp[arrayTemp.Length - 1 - i] = temp;
                }
            }

            return new string(arrayTemp);
        }

        /// <summary>
        /// 字符串解密(从PB中复制以兼容).
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Decrypt(byte[] arrayTemp, int datalength)
        {
            int len = datalength;
            byte[] newByte = new byte[len];
            for (int i = 0; i < len; i++)
            {
                byte k = (byte)(arrayTemp[i] - (len - (i + 1) - 2) * 2);
                newByte[i] = k;
            }

            for (int i = 0; i < len; i++)
            {
                byte temp = newByte[len - 1 - i];
                if (temp >= 0xa0) //对双字节字符一次转两位
                {
                    arrayTemp[i] = newByte[len - 2 - i];
                    arrayTemp[i + 1] = newByte[len - 1 - i];
                    i++;
                }
                else
                {
                    arrayTemp[i] = newByte[len - 1 - i];
                }
            }

            return Encoding.GetEncoding("GB2312").GetString(arrayTemp);
        }


        /// <summary>
        /// 使用DES加密
        /// </summary>
        /// <param name="originalValue">待加密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <param name="IV">初始化向量(最大长度8)</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string originalValue, string key)
        {
            try
            {
                //将key和IV处理成8个字符
                key += "12345678";
                string IV = key + "12345678";
                key = key.Substring(0, 8);
                IV = IV.Substring(0, 8);

                System.Security.Cryptography.SymmetricAlgorithm sa;
                System.Security.Cryptography.ICryptoTransform ct;
                System.IO.MemoryStream ms;
                System.Security.Cryptography.CryptoStream cs;
                byte[] byt;

                sa = new System.Security.Cryptography.DESCryptoServiceProvider();
                sa.Key = System.Text.Encoding.UTF8.GetBytes(key);
                sa.IV = System.Text.Encoding.UTF8.GetBytes(IV);
                ct = sa.CreateEncryptor();

                byt = System.Text.Encoding.UTF8.GetBytes(originalValue);

                ms = new System.IO.MemoryStream();
                cs = new System.Security.Cryptography.CryptoStream(ms, ct, System.Security.Cryptography.CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();

                cs.Close();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
            }

            return "";
        }

        /// <summary>
        /// 使用DES解密
        /// </summary>
        /// <param name="encryptedValue">待解密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <param name="IV">m初始化向量(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string encryptedValue, string key)
        {
            if (string.IsNullOrEmpty(encryptedValue)) return "";
            try
            {
                //将key和IV处理成8个字符
                key += "12345678";
                string IV = key + "12345678";
                key = key.Substring(0, 8);
                IV = IV.Substring(0, 8);

                System.Security.Cryptography.SymmetricAlgorithm sa;
                System.Security.Cryptography.ICryptoTransform ct;
                System.IO.MemoryStream ms;
                System.Security.Cryptography.CryptoStream cs;
                byte[] byt;

                sa = new System.Security.Cryptography.DESCryptoServiceProvider();
                sa.Key = System.Text.Encoding.UTF8.GetBytes(key);
                sa.IV = System.Text.Encoding.UTF8.GetBytes(IV);
                ct = sa.CreateDecryptor();

                byt = Convert.FromBase64String(encryptedValue);

                ms = new System.IO.MemoryStream();
                cs = new System.Security.Cryptography.CryptoStream(ms, ct, System.Security.Cryptography.CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();

                cs.Close();

                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
            catch
            {
            }

            return "";
        }

        #endregion
    }
}
