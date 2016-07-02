using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1.Models
{
    public static class SIString
    {

        /// <summary>
        /// 转换成bool
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool TryBool(object obj)
        {
            return TryBool(obj, false);
        }

        /// <summary>
        /// 转换成bool
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool TryBool(object obj, bool decDef)
        {
            bool decRet = false;
            if (Object.Equals(obj, DBNull.Value) || obj == null || Object.Equals(obj, string.Empty))
                return decDef;

            if (bool.TryParse(obj.ToString(), out decRet))
                return decRet;
            else
                return decDef;
        }

        /// <summary>
        /// 字符串转换为Int
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <returns></returns> 
        public static int TryInt(object obj)
        {
            return TryInt(obj, 0);
        }

        /// <summary>
        /// 字符串转换为Int
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <param name="defInt">默认值</param>
        /// <returns></returns>
        public static int TryInt(object obj, int defInt)
        {
            int inttemp = 0;
            if (obj == null || obj == DBNull.Value || obj.Equals(string.Empty))
                return defInt;
            obj = obj.ToString().Replace("￥", "").Replace("$", "");
            if (obj.ToString().Contains("."))
            {
                obj = float.Parse(obj.ToString());
            }
            if (Int32.TryParse(obj.ToString(), out inttemp))
                return inttemp;
            else
                return defInt;
        }

        /// <summary>
        /// 字符串转换为Long
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <returns></returns>
        public static long TryLong(object obj)
        {
            return TryLong(obj, 0);
        }

        /// <summary>
        /// 字符串转换为Long
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <param name="defInt">默认值</param>
        /// <returns></returns>
        public static long TryLong(object obj, int defLong)
        {
            long inttemp = 0;
            if (obj == null || obj == DBNull.Value || obj.Equals(string.Empty))
                return defLong;
            obj = obj.ToString().Replace("￥", "").Replace("$", "");
            if (obj.ToString().Contains("."))
            {
                obj = float.Parse(obj.ToString());
            }

            if (Int64.TryParse(obj.ToString(), out inttemp))
                return inttemp;
            else
                return defLong;
        }

        /// <summary>
        /// 字符串转换为float
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <returns></returns>
        public static float TryFloat(object obj)
        {
            return TryFloat(obj, 0);
        }

        /// <summary>
        /// 字符串转换为float
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <param name="defInt">默认值</param>
        /// <returns></returns>
        public static float TryFloat(object obj, long defLong)
        {
            float inttemp = 0;
            if (obj == null || obj == DBNull.Value || obj.Equals(string.Empty))
                return defLong;

            obj = obj.ToString().Replace("￥", "").Replace("$", "");
            if (obj.ToString().Contains("."))
            {
                obj = float.Parse(obj.ToString());
            }

            if (float.TryParse(obj.ToString(), out inttemp))
                return inttemp;
            else
                return defLong;
        }

        /// <summary>
        /// 字符串转换为short
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <returns></returns> 
        public static short TryShort(object obj)
        {
            return TryShort(obj, 0);
        }

        /// <summary>
        /// 字符串转换为short
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <param name="defInt">默认值</param>
        /// <returns></returns>
        public static short TryShort(object obj, short defInt)
        {
            short inttemp = 0;
            if (obj == null || obj == DBNull.Value || obj.Equals(string.Empty))
                return defInt;

            obj = obj.ToString().Replace("￥", "").Replace("$", "");
            if (obj.ToString().Contains("."))
            {
                obj = Int16.Parse(obj.ToString());
            }

            if (Int16.TryParse(obj.ToString(), out inttemp))
                return inttemp;
            else
                return defInt;
        }

        /// <summary>
        /// 字符串转换为decimal 
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <returns></returns>
        public static decimal TryDec(object obj)
        {
            return TryDec(obj, 0M);
        }

        /// <summary>
        /// 字符串转换为decimal 
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <param name="defInt">默认值</param>
        /// <returns></returns>
        public static decimal TryDec(object obj, decimal defDec)
        {
            decimal dectemp = 0M;
            if (obj == null || obj == DBNull.Value || obj.Equals(string.Empty))
                return defDec;
            obj = obj.ToString().Replace("￥", "").Replace("$", "");
            if (decimal.TryParse(obj.ToString(), out dectemp))
                return dectemp;
            else
                return defDec;
        }

        /// <summary>
        /// 字符串转换为double 
        /// </summary>
        /// <param name="obj">输入字符串</param>
        /// <param name="defInt">默认值</param>
        /// <returns></returns>
        public static double TryDou(object obj, double defDou)
        {
            double doutemp = 0;
            if (obj == null || obj == DBNull.Value || obj.Equals(string.Empty))
                return defDou;
            obj = obj.ToString().Replace("￥", "").Replace("$", "");
            if (double.TryParse(obj.ToString(), out doutemp))
                return doutemp;
            else
                return defDou;
        }

        /// <summary>
        /// 转换成string
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defInt">默认值</param>
        /// <returns></returns>
        public static char TryChar(object obj, char defstr)
        {
            if (Object.Equals(obj, DBNull.Value) || obj == null)
                return defstr;

            char doutemp = '0';

            if (char.TryParse(TryStr(obj, defstr.ToString()), out doutemp))
                return doutemp;
            else
                return defstr;
        }


        /// <summary>
        /// 转换成string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string TryStr(object obj)
        {
            return TryStr(obj, string.Empty);
        }

        /// <summary>
        /// 转换成string
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defInt">默认值</param>
        /// <returns></returns>
        public static string TryStr(object obj, string defstr)
        {
            if (Object.Equals(obj, DBNull.Value) || obj == null)
                return defstr;
            else
                return obj.ToString().Trim();
        }

        /// <summary>
        /// 转换成DataTiem?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? TryDateTime(object obj)
        {
            if (Object.Equals(obj, DBNull.Value) || obj == null || Object.Equals(obj, string.Empty))
                return null;
            else
                return Convert.ToDateTime(obj);
        }

        /// <summary>
        /// 转换成DataTiem
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime TryDateTime(object obj, DateTime defDt)
        {
            try
            {
                if (Object.Equals(obj, DBNull.Value) || obj == null || Object.Equals(obj, string.Empty))
                    return defDt;
                else
                    return Convert.ToDateTime(obj);
            }
            catch
            {
                return defDt;
            }
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static char ToDBCChar(char input)
        {
            if (input == 12288)
            {
                input = (char)32;
            }
            if (input > 65280 && input < 65375)
                input = (char)(input - 65248);
            return input;
        }
        /// <summary>
        /// 获取指定字节长度的字符串[按字节]
        /// </summary>
        public static string GetString(string str, int len)
        {
            if (string.IsNullOrEmpty(str) || len <= 0)
                return string.Empty;

            string[] strArray = toStringArray(str);

            return GetString(strArray, len);
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="strArray"></param>
        /// <param name="interceptCount"></param>
        public static string GetString(string[] strArray, int len)
        {
            int count = 0;
            StringBuilder sBuffer = new StringBuilder();
            int byteLen = 1;

            for (int i = 0; i < strArray.Length; i++)
            {
                byteLen = Encoding.Default.GetByteCount(strArray[i].ToString());
                count = count + byteLen;

                if (count <= len)
                {
                    sBuffer.Append(strArray[i]);
                }
                else
                {
                    break;
                }
            }

            if (sBuffer.Length > 0)
            {
                return sBuffer.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取固定长度字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="count">需要的长度</param>
        /// <param name="isRight">填充空格符的位置 左/右</param>
        /// <param name="isDel">超出部分是否删除</param>
        /// <returns></returns>
        public static string GetString(string str, int count, bool isRight, bool isDel)
        {
            str = TryStr(str).Trim();

            string strRet = string.Empty;

            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度

            if (byteLen > count)
            {
                if (isDel)
                    strRet = GetString(str, count);
                else
                    strRet = str;
            }
            else if (byteLen == count)
            {
                strRet = str;
            }
            else
            {
                strRet = str;

                if (isRight)
                {
                    for (int i = 0; i < count - byteLen; i++)
                    {
                        strRet = strRet + " ";
                    }
                }
                else
                {
                    for (int i = 0; i < count - byteLen; i++)
                    {
                        strRet = " " + strRet;
                    }
                }
            }

            return strRet;
        }

        /// <summary>
        /// 在原有字节长度上，替换最后的字符串
        /// </summary>
        /// <param name="str">截取原字符串</param>
        /// <param name="str">替换字符</param>
        public static string ReplaceEndChar(string str, string strReplace)
        {
            try
            {
                if (str == null) return string.Empty;

                if (string.IsNullOrEmpty(strReplace)) return str;

                int interceptCount = Encoding.Default.GetByteCount(strReplace);
                if (interceptCount <= 0) return str;

                string[] strArray = toStringArray(str);

                if (strArray.Length == 0) return string.Empty;

                if (Encoding.Default.GetByteCount(str) > interceptCount)
                    return GetString(strArray, Encoding.Default.GetByteCount(str) - interceptCount) + strReplace;
            }
            catch
            {

            }

            return str;
        }

        /// <summary>
        /// 转成字符数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] toStringArray(string str)
        {
            string[] strArray = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                strArray[i] = str.Substring(i, 1);
            }
            return strArray;
        }

        /// <summary>
        /// 字符串对比，去除空白字符和屏蔽大小写
        /// </summary>
        /// <param name="strFirst"></param>
        /// <param name="strSend"></param>
        /// <returns></returns>
        public static bool IsEqual(object strFirst, object strSend)
        {
            if (SIString.TryStr(strFirst).Trim().ToUpper() == SIString.TryStr(strSend).Trim().ToUpper())
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取整除数
        /// </summary>
        /// <returns></returns>
        public static int DivRem(int a, int b)
        {
            int intRet = 0;
            int intRem = 0;
            intRet = Math.DivRem(a, b, out intRem);

            if (intRem > 0)
                intRet++;

            return intRet;
        }

    }
}