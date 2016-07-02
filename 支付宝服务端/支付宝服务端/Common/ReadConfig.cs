using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace 支付宝服务端.Common
{
    public class ReadConfig
    {
        /// <summary>
        /// 读取配置文件到静态字段中
        /// </summary>
        public static void InitAlipayData()
        {
            try
            {
                XmlDocument objXmlDoc = new XmlDocument();
                string apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
                objXmlDoc.Load(apppath + "\\AlipayData.xml");
                XmlNamespaceManager xmlNsm = new XmlNamespaceManager(objXmlDoc.NameTable);
                XmlNode Node;

                ////思讯代理商ID.
                Node = objXmlDoc.SelectSingleNode("applicationConfig/AgentId1", xmlNsm);
                UserInfo.siss_agent_id1 = Node.InnerText;
                Node = objXmlDoc.SelectSingleNode("applicationConfig/AgentId2", xmlNsm);
                UserInfo.siss_agent_id2 = Node.InnerText;
                Node = objXmlDoc.SelectSingleNode("applicationConfig/AgentId3", xmlNsm);
                UserInfo.siss_agent_id3 = Node.InnerText;
                Node = objXmlDoc.SelectSingleNode("applicationConfig/AgentId4", xmlNsm);
                UserInfo.siss_agent_id4 = Node.InnerText;

                //ID对应产品名
                Node = objXmlDoc.SelectSingleNode("applicationConfig/AppName1", xmlNsm);
                UserInfo.siss_app_name1 = Node.InnerText;
                Node = objXmlDoc.SelectSingleNode("applicationConfig/AppName2", xmlNsm);
                UserInfo.siss_app_name2 = Node.InnerText;
                Node = objXmlDoc.SelectSingleNode("applicationConfig/AppName3", xmlNsm);
                UserInfo.siss_app_name3 = Node.InnerText;
                Node = objXmlDoc.SelectSingleNode("applicationConfig/AppName4", xmlNsm);
                UserInfo.siss_app_name4 = Node.InnerText;

                Node = objXmlDoc.SelectSingleNode("applicationConfig/IsWriteLog", xmlNsm);
                UserInfo.is_write_log = (Node.InnerText == "1");

                #region 数据库日志
                Node = objXmlDoc.SelectSingleNode("applicationConfig/IsWriteDbLog", xmlNsm);
                if (Node != null) UserInfo.Is_write_dblog = (Node.InnerText == "1");

                Node = objXmlDoc.SelectSingleNode("applicationConfig/DbIp", xmlNsm);
                if (Node != null) UserInfo.Db_ip = Node.InnerText;
                Node = objXmlDoc.SelectSingleNode("applicationConfig/DbName", xmlNsm);
                if (Node != null) UserInfo.Db_name = Node.InnerText;
                Node = objXmlDoc.SelectSingleNode("applicationConfig/DbUname", xmlNsm);
                if (Node != null) UserInfo.Db_Uname = Node.InnerText;
                Node = objXmlDoc.SelectSingleNode("applicationConfig/DbPwd", xmlNsm);
                if (Node != null) UserInfo.Db_pwd = Node.InnerText;
                #endregion

                //非思迅的签约商户不能使用
                Node = objXmlDoc.SelectSingleNode("applicationConfig/NoneSissMerchantCannotUse", xmlNsm);
                if (Node != null) UserInfo.NoneSissMerchantCannotUse = (Node.InnerText == "1");
                //非思迅的签约商户提示信息
                Node = objXmlDoc.SelectSingleNode("applicationConfig/NoneSissPrompt", xmlNsm);
                if (Node == null)
                    UserInfo.NoneSissPrompt = UserInfo.NoneSissDefaultPrompt;
                else
                {
                    UserInfo.NoneSissPrompt = Node.InnerText;
                    if (string.IsNullOrEmpty(UserInfo.NoneSissPrompt) || string.IsNullOrEmpty(UserInfo.NoneSissPrompt.Trim()))
                        UserInfo.NoneSissPrompt = UserInfo.NoneSissDefaultPrompt;
                }
            }
            catch (Exception ex)
            {
                GLog.WriteErrLog("ReadConfig-InitAlipayData ERR:" + ex.Message);
            }

        }
    }
}
