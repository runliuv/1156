using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using ClassLibrary1.pab;
using ClassLibrary1.mod;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary1
{
    public class Like : ILike
    {

        public Stream Some(Stream inputStream)
        {
            byte[] byIn = inputStream.ReadBytes();
            string json = Encoding.UTF8.GetString(byIn);
            PayInfo pi = (PayInfo)JsonConvert.DeserializeObject(json, typeof(PayInfo));

            PayInfo pnew = new PayInfo();
            pnew.aaa = "这里是服务端";
            pnew.aab = "这里是服务端";
            pnew.aac = "这里是服务端";
            pnew.aad = "这里是服务端";
            pnew.aae = "这里是服务端";
            pnew.aaf = "这里是服务端";
            pnew.aag = "这里是服务端";
            pnew.aah = "这里是服务端 这里是服务端 这里是服务端 这里是服务端 这里是服务端 这里是服务端 这里是服务端 这里是服务端 这里是服务端";

            string strRst = JsonConvert.SerializeObject(pnew);
            byte[] bytesOut = Encoding.UTF8.GetBytes(strRst);
            MemoryStream streamRst = new MemoryStream(bytesOut);
            return streamRst;
        }

        public Stream GetZM9JF(Stream inputStream)
        {
            MemoryStream streamRst;
            string rst = "";
            try
            {
                byte[] byIn = inputStream.ReadBytes();
                string carid = Encoding.UTF8.GetString(byIn);

                if (string.IsNullOrEmpty(carid))
                    rst = "卡号为空";
                else
                {
                    DbOper dop = new DbOper();
                    rst = dop.GetVipJf(carid).ToString();
                }
            }
            catch (Exception ex)
            {
                rst = ex.Message;
            }
            byte[] bytesOut = Encoding.UTF8.GetBytes(rst);
            streamRst = new MemoryStream(bytesOut);
            return streamRst;
        }

        public rzm9 Test(zm9 inp)
        {
            rzm9 r = new rzm9();
            r.msg = string.Empty;

            if (string.IsNullOrEmpty(inp.sql))
            {
                r.msg = "sql 为空";
                return r;
            }

            SqlTransaction strans = null;
            try
            {
                using (SqlConnection sconn = new SqlConnection(DbOper.ConnStr))
                {
                    sconn.Open();
                    strans = sconn.BeginTransaction();
                    using (SqlCommand scmd = new SqlCommand())
                    {
                        scmd.Connection = sconn;
                        scmd.Transaction = strans;
                        scmd.CommandType = CommandType.Text;
                        scmd.CommandText = inp.sql;
                        scmd.CommandTimeout = 100;//秒
                        scmd.ExecuteNonQuery();

                        strans.Commit();
                    }
                }

                r.code = 1;
                r.msg = "成功";
            }
            catch (Exception ex)
            {
                if (strans != null && strans.Connection != null)
                {
                    strans.Rollback();
                }
                r.msg = ex.Message;
            }

            return r;
        }
    }
}
