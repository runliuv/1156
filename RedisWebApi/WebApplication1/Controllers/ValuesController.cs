﻿using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApplication1.Models;
using WebRedis.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public Response<t_bd_item_info> Get(string id)
        {
            StringBuilder sc = new StringBuilder();
            Response<t_bd_item_info> rsp = new Response<t_bd_item_info>();
            t_bd_item_info dd = null;

            rsp.Code = 1;
            try
            {
                string item_no = id.ToString();

                RedisClient _redClient = null;
                try
                {

                    _redClient = new RedisClient(MU._redIp, int.Parse(MU._redPort));
                    if (_redClient != null)
                    {
                        sc.AppendLine("_redClient 不为空");
                        dd = _redClient.Get<t_bd_item_info>(item_no);
                    }
                }
                catch (Exception exRed)
                {
                    sc.AppendLine("连接redis或Get时异常:" + exRed.Message);
                }
                if (dd == null)
                {
                    sc.AppendLine("缓存中不存在");
                    rsp.Message = "缓存中不存在";
                    string conn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    using (SqlConnection sconn = new SqlConnection(conn))
                    {
                        sconn.Open();
                        string sql = string.Format("select * from t_bd_item_info where rtrim(item_no)='{0}'", item_no);

                        SqlDataAdapter sda = new SqlDataAdapter(sql, sconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            sc.AppendLine("数据库中存在");
                            rsp.Message = "数据库中存在";
                            dd = RowToModel.DataRowTot_bd_item_info(dt.Rows[0]);

                            if (_redClient != null)
                            {
                                try
                                {
                                    _redClient.Set<t_bd_item_info>(item_no, dd, DateTime.Now.AddMinutes(1));
                                }
                                catch (Exception exRedSet)
                                {
                                    sc.AppendLine(" redis Get时异常:" + exRedSet.Message);
                                }
                            }
                        }
                        else
                        {
                            sc.AppendLine("数据库中不存在");
                            rsp.Message = "数据库中不存在";
                        }
                    }
                }
                else
                {
                    sc.AppendLine("缓存中存在");
                    rsp.Message = "缓存中存在";
                }
            }
            catch (Exception ex)
            {
                rsp.Code = 0;
                rsp.Message = ex.Message;
                sc.AppendLine("ex:" + ex.Message);

            }
            finally
            {
                GLog.WLog(sc.ToString());
            }
            rsp.Data = dd;

            return rsp;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
