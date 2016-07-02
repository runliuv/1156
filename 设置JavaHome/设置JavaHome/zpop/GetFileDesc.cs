using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace 设置JavaHome
{
   public class GetFileDesc
    {
       /// <summary>
       /// 获取说明
       /// </summary>
       /// <returns></returns>
       public static string Get_FileDesc()
       {
           FileVersionInfo fvi =   FileVersionInfo.GetVersionInfo(Application.ExecutablePath);

           return fvi.Comments;
       }
    }
}
