using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace 支付宝服务端.Common
{
    public class PayLogDal
    {
        #region 增加
        public int Insert(PayLog modelInterface)
        {
            //PayLog model = (PayLog)modelInterface;
            //return DBHelper.ExecuteSql(GetInsertSql(), GetModelParamete(model));

            SqlParameter[] cmdParms = GetModelParamete(modelInterface);
            string connStr = string.Format("server={0};database={1};uid={2};pwd={3};", UserInfo.Db_ip, UserInfo.Db_name, UserInfo.Db_Uname, UserInfo.Db_pwd);
            string strSql = GetInsertSql();
            using (SqlConnection sconn = new SqlConnection(connStr))
            {
                sconn.Open();
                using (SqlCommand scmd = new SqlCommand(strSql, sconn))
                {
                    foreach (SqlParameter parameter in cmdParms)
                    {
                        if (parameter.Value != null)
                            scmd.Parameters.Add(parameter);
                    }

                    scmd.ExecuteNonQuery();
                }
            }
            return 0;
        }
        public string GetInsertSql()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PayLog(log_type,oper_type,pay_way,pay_type,softdog_id,partner,md5key,flow_no,pay_amt,order_title,bar_code,app_name,out_request_no,version,trade_no,buyer_user_id,buyer_logon_id,self_agent_id,agent_id,logtime");
            strSql.Append(") values (");
            strSql.Append("@log_type,@oper_type,@pay_way,@pay_type,@softdog_id,@partner,@md5key,@flow_no,@pay_amt,@order_title,@bar_code,@app_name,@out_request_no,@version,@trade_no,@buyer_user_id,@buyer_logon_id,@self_agent_id,@agent_id,@logtime");
            strSql.Append(") ");
            return strSql.ToString();
        }
        #endregion

        public SqlParameter[] GetModelParamete(PayLog entity)
        {
            PayLog model = entity as PayLog;
            SqlParameter[] parameters = {
			new SqlParameter("@log_type", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@oper_type", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@pay_way", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@pay_type", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@softdog_id", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@partner", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@md5key", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@flow_no", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@pay_amt", SqlDbType.Decimal,9) ,            
            new SqlParameter("@order_title", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@bar_code", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@app_name", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@out_request_no", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@version", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@trade_no", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@buyer_user_id", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@buyer_logon_id", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@self_agent_id", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@agent_id", SqlDbType.NVarChar,150) ,            
            new SqlParameter("@logtime", SqlDbType.DateTime)             
                        };

            if (model.log_type == null) { parameters[0].Value = DBNull.Value; } else { parameters[0].Value = model.log_type; }
            if (model.oper_type == null) { parameters[1].Value = DBNull.Value; } else { parameters[1].Value = model.oper_type; }
            if (model.pay_way == null) { parameters[2].Value = DBNull.Value; } else { parameters[2].Value = model.pay_way; }
            if (model.pay_type == null) { parameters[3].Value = DBNull.Value; } else { parameters[3].Value = model.pay_type; }
            if (model.softdog_id == null) { parameters[4].Value = DBNull.Value; } else { parameters[4].Value = model.softdog_id; }
            if (model.partner == null) { parameters[5].Value = DBNull.Value; } else { parameters[5].Value = model.partner; }
            if (model.md5key == null) { parameters[6].Value = DBNull.Value; } else { parameters[6].Value = model.md5key; }
            if (model.flow_no == null) { parameters[7].Value = DBNull.Value; } else { parameters[7].Value = model.flow_no; }
            if (model.pay_amt == null) { parameters[8].Value = DBNull.Value; } else { parameters[8].Value = model.pay_amt; }
            if (model.order_title == null) { parameters[9].Value = DBNull.Value; } else { parameters[9].Value = model.order_title; }
            if (model.bar_code == null) { parameters[10].Value = DBNull.Value; } else { parameters[10].Value = model.bar_code; }
            if (model.app_name == null) { parameters[11].Value = DBNull.Value; } else { parameters[11].Value = model.app_name; }
            if (model.out_request_no == null) { parameters[12].Value = DBNull.Value; } else { parameters[12].Value = model.out_request_no; }
            if (model.version == null) { parameters[13].Value = DBNull.Value; } else { parameters[13].Value = model.version; }
            if (model.trade_no == null) { parameters[14].Value = DBNull.Value; } else { parameters[14].Value = model.trade_no; }
            if (model.buyer_user_id == null) { parameters[15].Value = DBNull.Value; } else { parameters[15].Value = model.buyer_user_id; }
            if (model.buyer_logon_id == null) { parameters[16].Value = DBNull.Value; } else { parameters[16].Value = model.buyer_logon_id; }
            if (model.self_agent_id == null) { parameters[17].Value = DBNull.Value; } else { parameters[17].Value = model.self_agent_id; }
            if (model.agent_id == null) { parameters[18].Value = DBNull.Value; } else { parameters[18].Value = model.agent_id; }
            if (model.logtime == null) { parameters[19].Value = DBNull.Value; } else { parameters[19].Value = model.logtime; }
            return parameters;
        }
    }
}
