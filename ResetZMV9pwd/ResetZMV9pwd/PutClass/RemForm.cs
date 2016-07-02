using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ResetZMV9pwd
{
    public class RemForm
    {
        /// <summary>
        /// 要记录的窗体.排除项的名字。
        /// </summary>
        /// <param name="myForm"></param>
        /// <param name="doNotRem"></param>
        public void RememberForm(Form myForm, List<string> doNotRem)
        {
            string nsp = myForm.GetType().Namespace;
            string xmlFullName = Application.StartupPath + @"\" + nsp + myForm.Name + ".xml";
            string d2Node = nsp + myForm.Name;
            try
            {
                File.Delete(xmlFullName);

                //先创建默认内容
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(string.Format("<item><{0}></{0}></item>", d2Node));

                XmlNode xn = doc.SelectSingleNode("item/" + d2Node);
                foreach (Control ctl in myForm.Controls)
                {
                    if (ctl is TextBox)
                    {
                        if (doNotRem != null && doNotRem.Contains(ctl.Name))
                            continue;

                        string element = ctl.Name;
                        string value = ctl.Text;
                        XmlElement xe = doc.CreateElement(element);
                        xe.InnerText = value;
                        xn.AppendChild(xe);
                    }
                }

                doc.PreserveWhitespace = true;
                doc.Save(xmlFullName);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="myForm"></param>
        /// <param name="doNotRem"></param>
        public void ReadRememberForm(Form myForm, List<string> doNotRem)
        {
            string nsp = myForm.GetType().Namespace;
            string xmlFullName = Application.StartupPath + @"\" + nsp + myForm.Name + ".xml";
            string d2Node = nsp + myForm.Name;
            try
            {
                if (!File.Exists(xmlFullName))
                    return;

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFullName);
                foreach (Control ctl in myForm.Controls)
                {
                    if (ctl is TextBox)
                    {
                        if (doNotRem != null && doNotRem.Contains(ctl.Name))
                            continue;

                        string element = ctl.Name;
                        string value = string.Empty;

                        string node = "item/" + d2Node + "/" + ctl.Name;
                        XmlNode xn = doc.SelectSingleNode(node);
                        if (xn == null)
                            continue;

                        ctl.Text = xn.InnerText;

                    }
                }



            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
