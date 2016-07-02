using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PosServer.BLL
{
    public class IssO2O
    {
        /// <summary>
        /// 初始化, 返回 0 成功, 1 失败 2 试用到期 3 超过最大用户数
        /// </summary>
        /// <param name="lpszProductcode">产品码:hbposev9,isszmv9,hbposv7</param>
        /// <returns></returns>
        [DllImport("IssO2O.dll", CharSet = CharSet.Ansi)]
        public static extern int InitPos(string lpszProductcode, string lpszTitle, string lpszServer, string lpszDbName, string lpszUid, string lpszPwd, int spid);
        //DLLS\\SXPOSV8\\
        [DllImport("IssO2O.dll", CharSet = CharSet.Ansi)]
        public static extern int of_amt_encrypt(double amt, StringBuilder sbBuffer, int size);

        [DllImport("IssO2O.dll", CharSet = CharSet.Ansi)]
        public static extern double of_amt_decrypt(string str);

        //加密锁号 + 锁序列号 + 授权用户 + 用户数 + 注册日期 + 销售区域 + 强制打印的小票标题(空串则不强制)
        [DllImport("IssO2O.dll", CharSet = CharSet.Ansi)]
        public static extern bool GetDongleInfo(StringBuilder sbInfo, Int32 size);

        /// <summary>
        /// order detail 要加密。flag ( 1 食通天6 。  2 快餐王6 。), 菜品编码,点单时间 yyyyMMddHHmmss. size 256
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="lpcstrDishNo"></param>
        /// <param name="lpcstrOrderTime"></param>
        /// <param name="sbBuffer"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport("IssO2O.dll", CharSet = CharSet.Ansi)]
        public static extern int of_cyorderstr(int flag, string lpcstrDishNo, string lpcstrOrderTime, string lpcstrDbName, StringBuilder sbBuffer, int size);

        /// <summary>
        /// IssO2O初始化成功则true
        /// </summary>
        public static bool InitSucess = false;

        public static int spdid = -1;

        public static string AmountEncrypt(decimal amt)
        {
            double dbl = (double)amt;
            int nBufferSize = 256;
            StringBuilder sb = new StringBuilder(nBufferSize);
            int rtn = of_amt_encrypt(dbl, sb, nBufferSize);
            if (rtn != 0) throw new ApplicationException("AmountEncrypt异常");
            return sb.ToString().TrimEnd('\0');
        }

        public static decimal AmountDecrypt(string str)
        {
            decimal dout = 0M;
            if (decimal.TryParse(str, out dout)) throw new ApplicationException("AmountDecrypt 输入异常");

            double amt = of_amt_decrypt(str);
            if (amt == -99999999.00) throw new ApplicationException("AmountDecrypt异常");
            //2016-6-1更新ROUND 2
            decimal rtn = Math.Round((decimal)amt, 2);
            return rtn;
        }
    }
}
