using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace UsualLib
{
    //ver 2013.12.25

    /// <summary>
    /// 记录窗体上TEXTBOX的名称、值到XML中
    /// </summary>
    public class RemForm
    {
        /// <summary>
        /// 要记录的窗体.排除项的名字。
        /// </summary>
        /// <param name="myForm"></param>
        /// <param name="doNotRem"></param>
        public static void RememberForm(Form myForm, List<string> doNotRem)
        {
            string nsp = myForm.GetType().Namespace;
            string xmlFullName = Application.ExecutablePath + nsp + myForm.Name + ".xml";
            string d2Node = nsp + myForm.Name;
            try
            {
                File.Delete(xmlFullName);

                //先创建默认内容
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(string.Format("<item><{0}></{0}></item>", d2Node));

                XmlNode xn = doc.SelectSingleNode("item/" + d2Node);

                RemBox(myForm, doc, xn, doNotRem);

                doc.PreserveWhitespace = true;
                doc.Save(xmlFullName);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        /// <summary>
        /// 每个容器的TEXTBOX
        /// </summary>
        /// <param name="myBox"></param>
        /// <param name="xmDoc"></param>
        /// <param name="xmNode"></param>
        /// <param name="doNotRem"></param>
        private static void RemBox(Control myBox, XmlDocument xmDoc, XmlNode xmNode, List<string> doNotRem)
        {
            foreach (Control ctl in myBox.Controls)
            {
                if (doNotRem != null && doNotRem.Contains(ctl.Name))
                    continue;

                string element = ctl.Name;
                string value = string.Empty;

                if (ctl is TextBox || ctl is NumericUpDown)
                {
                    value = ctl.Text;
                    XmlElement xe = xmDoc.CreateElement(element);
                    xe.InnerText = value;
                    xmNode.AppendChild(xe);
                }
                else if (ctl is CheckBox)
                {
                    value = "false";
                    if (((CheckBox)ctl).Checked)
                        value = "true";
                    XmlElement xe = xmDoc.CreateElement(element);
                    xe.InnerText = value;
                    xmNode.AppendChild(xe);
                }
                else if (ctl.Controls.Count > 0)
                {
                    RemBox(ctl, xmDoc, xmNode, doNotRem);
                }
            }
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="myForm"></param>
        /// <param name="doNotRem"></param>
        public static void ReadRememberForm(Form myForm, List<string> doNotRem)
        {
            string nsp = myForm.GetType().Namespace;
            string xmlFullName = Application.ExecutablePath + nsp + myForm.Name + ".xml";
            string d2Node = nsp + myForm.Name;

            try
            {
                if (!File.Exists(xmlFullName))
                    return;

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFullName);
                 
                ReadBox(myForm, doc, d2Node, doNotRem);                 
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        /// <summary>
        /// 每个容器的TEXTBOX
        /// </summary>
        /// <param name="myBox"></param>
        /// <param name="xmDoc"></param>
        /// <param name="d2Node"></param>
        /// <param name="doNotRem"></param>
        private static void ReadBox(Control myBox, XmlDocument xmDoc, string d2Node, List<string> doNotRem)
        {
            foreach (Control ctl in myBox.Controls)
            {
                if (doNotRem != null && doNotRem.Contains(ctl.Name))
                    continue;

                string node = "item/" + d2Node + "/" + ctl.Name;

                if (ctl is TextBox)
                {
                    XmlNode xn = xmDoc.SelectSingleNode(node);
                    if (xn == null)
                        continue;

                    ctl.Text = xn.InnerText;
                }
                else if (ctl is NumericUpDown)
                {
                    XmlNode xn = xmDoc.SelectSingleNode(node);
                    if (xn == null)
                        continue;

                    (ctl as NumericUpDown).Value = decimal.Parse(xn.InnerText);
                }
                else if (ctl is CheckBox)
                {
                    XmlNode xn = xmDoc.SelectSingleNode(node);
                    if (xn == null)
                        continue;

                    (ctl as CheckBox).Checked = xn.InnerText.ToLower() == "true" ? true : false;
                }
                else if (ctl.Controls.Count > 0)
                {
                    ReadBox(ctl, xmDoc, d2Node, doNotRem);
                }
            }
        }
    }
}
