using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PosServer.Model;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;
using PosServer.DAL;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using 微餐厅线下产品会员导入;
using WebApplication1.Models;

namespace PosServer.BLL
{
    [Serializable]
    [DataContract]
    public class Member
    {
        #region 绑定
        public string Bind<T>(T request, string conStr, string siss_prod_type)
        {
            Request<MemberBindRequest> req = request as Request<MemberBindRequest>;
            Response<MemberBindResponse> response = new Response<MemberBindResponse>();
            MemberBindResponse res = null;

             

            base_wxsf_vip_info vip = req.Data as base_wxsf_vip_info;

            if (string.IsNullOrEmpty(vip.flow_no))
            {
                response.Code = Codes.FAILED;
                response.Message = "flow_no为空";
                goto L_RST;
            }
            if (string.IsNullOrEmpty(vip.oper_type))
            {
                response.Code = Codes.FAILED;
                response.Message = "oper_type为空";
                goto L_RST;
            }
            if (string.IsNullOrEmpty(vip.mobile))
            {
                response.Code = Codes.FAILED;
                response.Message = "手机号为空";
                goto L_RST;
            }
            if (string.IsNullOrEmpty(vip.openid))
            {
                response.Code = Codes.FAILED;
                response.Message = "openid为空";
                goto L_RST;
            }

             

            #region 注册。查询是否有此会员，如果有，失败 提示已重复
            if (!string.IsNullOrEmpty(vip.oper_type) && vip.oper_type.Trim() == "1")
            {
                #region 有些产品得提前校验isso2o是否初始化
                if (!IssO2O.InitSucess && siss_prod_type.ToLower() == "isscyms3")
                {
                    response.Code = Codes.FAILED;
                    response.Message = "IssO2O初始化未成功";
                    goto L_RST;
                }
                #endregion

                DbUtility db1 = new DbUtility(conStr);
                DbCommand cmd1 = db1.GetStoredProcCommond("pr_wxsf_member_chk_ex");
                db1.AddInParameter(cmd1, "@oper_type", DbType.String, "0"); //0 仅检查card_id
                db1.AddInParameter(cmd1, "@card_id", DbType.String, req.Data.card_id == null ? "" : req.Data.card_id);
                db1.AddInParameter(cmd1, "@mobile", DbType.String, req.Data.mobile == null ? "" : req.Data.mobile);
                DataTable dtExists = db1.ExecuteDataTable(cmd1);
                if (dtExists != null && dtExists.Rows.Count > 0)
                {
                    response.Code = Codes.SUCCESS;  //重复的直接跳过
                    response.Message = "此会员ID重复！";
                    goto L_RST;
                }

                #region 检查手机号是否已使用
                DbUtility dbP = new DbUtility(conStr);
                DbCommand cmdP = dbP.GetStoredProcCommond("pr_wxsf_member_chk_ex");
                dbP.AddInParameter(cmdP, "@oper_type", DbType.String, "1");//1 仅检查手机号
                dbP.AddInParameter(cmdP, "@card_id", DbType.String, req.Data.card_id == null ? "" : req.Data.card_id);
                dbP.AddInParameter(cmdP, "@mobile", DbType.String, req.Data.mobile == null ? "" : req.Data.mobile);
                DataTable dtP = dbP.ExecuteDataTable(cmdP);
                if (dtP != null && dtP.Rows.Count > 0)
                {
                    response.Code = Codes.FAILED;
                    response.Message = "手机号已被使用！";
                    goto L_RST;
                }
                #endregion
            }
            #endregion

            #region 插入中间表
            ToMid(conStr, vip);
            #endregion

            #region 处理绑定
            //0元余额加密
            string ZeroStr = MemAmountEncrypt("0", siss_prod_type, conStr);

            DbUtility db = new DbUtility(conStr);
            DbCommand cmd2 = db.GetStoredProcCommond("pr_wxsf_member_bind_proc_mid");
            db.AddInParameter(cmd2, "@flow_no", DbType.String, req.Data.flow_no);
            db.AddInParameter(cmd2, "@card_id", DbType.String, req.Data.card_id);
            db.AddInParameter(cmd2, "@oper_type", DbType.String, vip.oper_type);//0 绑定
            db.AddInParameter(cmd2, "@card_amount", DbType.String, ZeroStr);//会员余额，已加密，给注册用。

            DataTable dt = db.ExecuteDataTable(cmd2);
            #endregion

            if (dt == null || dt.Rows.Count == 0)
            {
                response.Code = Codes.FAILED;
                response.Message = "绑定失败！";
                goto L_RST;
            }

            //res = DataRowToIEntity(dt.Rows[0]);

            response.Code = Codes.SUCCESS;

            response.Data = res;

        L_RST:
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(response.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, response);
                stream.Flush();
                return Encoding.UTF8.GetString(stream.ToArray(), 0, (int)stream.Length);
            }

        }
        #endregion

        void ToMid(string conStr, base_wxsf_vip_info vip)
        {
            //插入中间表      
            DbUtility db = new DbUtility(conStr);
            DbCommand cmd = db.GetStoredProcCommond("pr_wxsf_member_bind_write_mid");
            db.AddInParameter(cmd, "@flow_no", DbType.String, vip.flow_no == null ? "" : vip.flow_no);
            db.AddInParameter(cmd, "@shopid", DbType.String, vip.shopid == null ? "" : vip.shopid);
            db.AddInParameter(cmd, "@openid", DbType.String, vip.openid == null ? "" : vip.openid);
            db.AddInParameter(cmd, "@branch_no", DbType.String, vip.branch_no == null ? "" : vip.branch_no);
            db.AddInParameter(cmd, "@card_id", DbType.String, vip.card_id == null ? "" : vip.card_id);
            db.AddInParameter(cmd, "@vip_name", DbType.String, vip.vip_name == null ? "" : vip.vip_name);
            db.AddInParameter(cmd, "@birthday", DbType.String, vip.birthday == null ? "" : vip.birthday);
            db.AddInParameter(cmd, "@vip_sex", DbType.String, vip.vip_sex == null ? "" : vip.vip_sex);
            db.AddInParameter(cmd, "@card_type", DbType.String, vip.card_type == null ? "" : vip.card_type);
            db.AddInParameter(cmd, "@type_no", DbType.String, vip.type_no == null ? "" : vip.type_no);

            string oper_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dtiOut = DateTime.Now;
            if (!string.IsNullOrEmpty(vip.oper_date))
                if (DateTime.TryParse(vip.oper_date, out dtiOut))
                { oper_date = dtiOut.ToString("yyyy-MM-dd HH:mm:ss"); }

            db.AddInParameter(cmd, "@oper_date", DbType.String, oper_date);

            db.AddInParameter(cmd, "@card_status", DbType.String, vip.card_status == null ? "" : vip.card_status);
            db.AddInParameter(cmd, "@acc_num", DbType.String, vip.acc_num);
            db.AddInParameter(cmd, "@dec_num", DbType.String, vip.dec_num);
            db.AddInParameter(cmd, "@now_acc_num", DbType.String, vip.now_acc_num);
            db.AddInParameter(cmd, "@vip_pass", DbType.String, vip.vip_pass == null ? "" : vip.vip_pass);
            db.AddInParameter(cmd, "@vip_start_date", DbType.String, vip.vip_start_date == null ? "" : vip.vip_start_date);
            db.AddInParameter(cmd, "@vip_end_date", DbType.String, vip.vip_end_date == null ? "" : vip.vip_end_date);
            db.AddInParameter(cmd, "@mobile", DbType.String, vip.mobile == null ? "" : vip.mobile);
            db.AddInParameter(cmd, "@email", DbType.String, vip.email == null ? "" : vip.email);
            db.AddInParameter(cmd, "@favourableinfo", DbType.String, vip.favourableinfo == null ? "" : vip.favourableinfo);

            db.AddInParameter(cmd, "@vippic", DbType.String, vip.vippic == null ? "" : vip.vippic);
            db.AddInParameter(cmd, "@subscribe", DbType.String, vip.subscribe == null ? "" : vip.subscribe);
            db.AddInParameter(cmd, "@oper_type", DbType.String, vip.oper_type);//0 绑定 1 注册
            db.AddInParameter(cmd, "@is_proc", DbType.String, "0");

            db.ExecuteNonQuery(cmd);
        }



        /// <summary>
        /// 会员余额加密
        /// </summary>
        /// <param name="inputAmt"></param>
        /// <returns></returns>
        public static string MemAmountEncrypt(string inputAmt, string prodCode, string conStr)
        {
            if (prodCode.ToLower() == "issrestv6")
            {
                int size = 200;
                StringBuilder su = new StringBuilder(size);
                TON6AppContext.StringEncrypt(inputAmt, su, size);
                string retStr = su.ToString();
                return retStr;
            }
            else if (prodCode.ToLower() == "issfoodv6" || prodCode.ToLower() == "isskyv6"
                || prodCode.ToLower() == "issplazav5")
            {
                DbUtility db = new DbUtility(conStr);
                string sql = string.Format("select dbo.f_m_encrypt('{0}')", inputAmt);
                DbCommand cmd = db.GetSqlStringCommond(sql);
                object obj = db.ExecuteScalar(cmd);
                string rst = obj.ToString();
                return rst;
            }
            else if (prodCode.ToLower() == "isscyms3")
            {
                decimal damt = decimal.Parse(inputAmt);
                string retStr = IssO2O.AmountEncrypt(damt);
                return retStr;
            }
            else
            {
                throw new Exception("未支持的产品类型");
            }
        }

        /// <summary>
        /// 会员余额解密
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string MemAmountDecrypt(string inputStr, string prodCode, string conStr)
        {
            //if (AppContext.IsDebug)
            //{
            //    GLog.WriteLog("MemAmountDecrypt inputStr:" + inputStr + " prodCode:" + prodCode);
            //}

            if (prodCode.ToLower() == "issrestv6")
            {
                int size = 200;
                StringBuilder su = new StringBuilder(size);
                TON6AppContext.StringDecrypt(inputStr, su, size);
                string retStr = su.ToString();
                return retStr;
            }
            else if (prodCode.ToLower() == "issfoodv6" || prodCode.ToLower() == "isskyv6"
                || prodCode.ToLower() == "issplazav5")
            {
                DbUtility db = new DbUtility(conStr);
                string sql = string.Format("select dbo.f_m_dencrypt('{0}')", inputStr);
                DbCommand cmd = db.GetSqlStringCommond(sql);
                object obj = db.ExecuteScalar(cmd);
                string rst = obj.ToString();
                return rst;
            }
            else if (prodCode.ToLower() == "isscyms3")
            {
                decimal dout = 0M;
                if (decimal.TryParse(inputStr, out dout))
                {
                    if (dout == 0M) return "0";
                }
                decimal retStr = IssO2O.AmountDecrypt(inputStr);
                return retStr.ToString();
            }
            else
            {
                throw new Exception("未支持的产品类型");
            }
        }
 

    }
}
