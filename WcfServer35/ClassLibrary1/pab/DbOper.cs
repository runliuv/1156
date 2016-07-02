using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary1.pab
{
    public class DbOper
    {
        /// <summary>
        /// 数据库连接，在FORM_LOAD时，或更换参数时，设置值。
        /// </summary>
        public static string ConnStr { get; set; }

         

        #region 具体的数据库操作
        public string GetVipJf(string cardid)
        {
            string dAccNum ="0";
            try
            {
                using (SqlConnection sconn = new SqlConnection(ConnStr))
                {
                    sconn.Open();
                    string strSql = string.Format("select acc_num from t_rm_vip_info where card_id like '%{0}%' or card_no like '%{0}%'",
                        cardid.Replace("'", "''"));
                    SqlCommand scmd = new SqlCommand(strSql, sconn);
                     
                    SqlDataAdapter sda = new SqlDataAdapter(scmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                            dAccNum = dt.Rows[0][0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dAccNum;
        }
        #endregion
    }
}
