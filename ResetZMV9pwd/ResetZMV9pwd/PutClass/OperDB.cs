using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ResetZMV9pwd
{
    public class OperDB
    {
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public bool TestDBConn(string connStr)
        {
            bool bErr = false;
            using (SqlConnection scon = new SqlConnection(connStr))
            {
                try
                {
                    scon.Open();
                }
                catch (Exception exp)
                {
                    bErr = true;
                }
            }

            return bErr;
        }

        /// <summary>
        /// 查看密码
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="oper"></param>
        /// <param name="pwdFeildName"></param>
        /// <returns></returns>
        public string WatchPwd(string connStr, string oper, string pwdFeildName)
        {
            string bErr = string.Empty;
            using (SqlConnection scon = new SqlConnection(connStr))
            {
                SqlCommand scmd = new SqlCommand();
                scmd.Connection = scon;
                scmd.CommandText = string.Format(@"select {0} from t_sys_operator where oper_id=@oper_id", pwdFeildName);
                scmd.Parameters.Add(new SqlParameter("@oper_id", oper));
                scon.Open();
                object oo = scmd.ExecuteScalar();
                if (oo != null)
                {
                    //pwd 解密之前要trim();
                    bErr = oo.ToString().Trim();
                    bErr = EncryptClass.Decrypt(bErr);
                }
            }

            return bErr;
        }

        /// <summary>
        /// 检查用户存在
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="oper"></param>
        /// <returns></returns>
        public bool CheckUser(string connStr, string oper)
        {
            bool bErr = false;
            using (SqlConnection scon = new SqlConnection(connStr))
            {
                SqlCommand scmd = new SqlCommand();
                scmd.Connection = scon;
                scmd.CommandText = string.Format(@"select count(1) from t_sys_operator where oper_id=@oper_id");
                scmd.Parameters.Add(new SqlParameter("@oper_id", oper));
                scon.Open();
                object oo = scmd.ExecuteScalar();
                if (oo != null)
                {
                    if (oo.ToString() == "0")
                        bErr = false;
                    else
                        bErr = true;
                }
            }

            return bErr;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="oper"></param>
        /// <param name="pwdFeildName"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public bool EditUsrPwd(string connStr, string oper, string pwdFeildName, string newPwd)
        {
            bool bErr = false;

            using (SqlConnection scon = new SqlConnection(connStr))
            {
                SqlCommand scmd = new SqlCommand();
                scmd.Connection = scon;
                scmd.CommandText = string.Format(@"
update t_sys_operator set {0}=@newPwd where oper_id=@oper_id
 ", pwdFeildName);
                scmd.Parameters.Add(new SqlParameter("@oper_id", oper));
                scmd.Parameters.Add(new SqlParameter("@newPwd", newPwd));
                scon.Open();
                int oo = scmd.ExecuteNonQuery();
                if (oo>0)
                {
                     
                        bErr = true;
                }
            }

            return bErr;
        }
    }
}
