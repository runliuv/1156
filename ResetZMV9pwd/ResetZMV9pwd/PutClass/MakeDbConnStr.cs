using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ResetZMV9pwd
{
    public static class MakeDbConnStr
    {
        /// <summary>
        /// serverIP 数据库IP，port 端口号，ins 实例名，uid 用户名，pwd 密码，dbName 数据库名。
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="port"></param>
        /// <param name="ins"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static string MakeSqlServerConnStr(string serverIP, int port, string ins, string uid, string pwd, string dbName)
        {
            if (string.IsNullOrEmpty(ins))
                ins = "MSSQLServer";
            string strTmp = string.Empty;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = serverIP + "," + port + @"\" + ins;
            builder.UserID = uid;
            if (!string.IsNullOrEmpty(pwd))
            {
                builder.Password = pwd;
            }
            builder.InitialCatalog = dbName;
            builder.ConnectTimeout = 15;
 
            strTmp = builder.ToString();
            return strTmp;
        }
    }
}
