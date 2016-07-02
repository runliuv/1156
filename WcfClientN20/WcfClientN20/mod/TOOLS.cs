using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfClientN20.mod
{
    public   class TOOLS
    {
        public   string CheckRandomCode(int len)
        {


            Random rom = new Random();
            char[] allcheckRandom ={'0','1','2','3','4','5','6','7','8','9',
                                       'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W',
                                       'X','Y','Z'};
            string Randomcode = "";
            for (int i = 0; i < len; i++)
            {
                Randomcode += allcheckRandom[rom.Next(allcheckRandom.Length)];

            }

            return Randomcode;
        }
    }
}
