using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace 支付宝服务端.Common
{
    public class SissAlipayMerchantDal
    {
        public bool CheckPartner(string partner)
        {
            string connStr = string.Format("server={0};database={1};uid={2};pwd={3};", UserInfo.Db_ip, UserInfo.Db_name, UserInfo.Db_Uname, UserInfo.Db_pwd);
            string strSql = "select COUNT(1) AS ABC from SissAlipayMerchant where [partner]=@partner";
            object abc = null;
            using (SqlConnection sconn = new SqlConnection(connStr))
            {
                sconn.Open();
                using (SqlCommand scmd = new SqlCommand(strSql, sconn))
                {
                    scmd.Parameters.Add("@partner", partner);

                    abc = scmd.ExecuteScalar();
                }
            }
            if (abc != null)
            {
                int iou = 0;
                int.TryParse(abc.ToString(), out iou);
                if (iou >= 1)
                    return true;
            }
            return false;
        }
    }
}
