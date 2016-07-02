using PosServer.DAL;
using PosServer.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace 微餐厅线下产品会员导入.Util
{
    public class issfoodv6Oper
    {

        public bool updateNowAccNum(string conStr, string Is_Distributed, MemberBindRequest rd)
        {
            /*
             if not exists (select 1 from t_hq_m_curamount where vch_memberno=@card_id)
				insert into t_hq_m_curamount (vch_memberno,vch_amount,num_point,vch_operID,dt_operdate,ch_branchno)
				select @card_id,@card_amount,0,'0000',getdate(),'0000'
             * 
             * 
             * t_m_curamount
             */

            string updateSql = "";
            if (Is_Distributed == "1")
                updateSql = string.Format("update t_hq_m_curamount set num_point='{0}' where vch_memberno='{1}'"
                    , rd.now_acc_num, rd.card_id);
            else
                updateSql = string.Format("update t_m_curamount set num_point='{0}' where vch_memberno='{1}'"
                    , rd.now_acc_num, rd.card_id);

            DbUtility db = new DbUtility(conStr);
            DbCommand cmd2 = db.GetSqlStringCommond(updateSql);
            int orst = db.ExecuteNonQuery(cmd2);
            if (orst <= 0)
                return false;

            return true;
        }
    }
}
