using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UsualLib;

namespace 设置JavaHome
{
    public partial class Form1 : Form
    {

        #region 变量
        /// <summary>
        /// Android_SDK_HOME 名称
        /// </summary>
        string androidSdkHomeName = "AndroidSDK";

        string javaHomeName = "JAVA_HOME";

        List<string> lstNotRem = new List<string>();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UsualLib.RemForm.ReadRememberForm(this, lstNotRem);

            LoadValue();
        }

        /// <summary>
        /// 加载JAVA相关环境变量
        /// </summary>
        private void LoadValue()
        {
            //清除
            dgvKey.Rows.Clear();
            dgvValue.Rows.Clear();
            //添加
            dgvKey.Rows.Add(javaHomeName);
            dgvKey.Rows.Add("Path");
            dgvKey.Rows.Add("CLASSPATH");
            dgvKey.Rows.Add(androidSdkHomeName);
        }

        private void dgvKey_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKey.Rows.Count > 0)
            {
                string key = dgvKey.CurrentRow.Cells["ColKey"].Value.ToString();

                string valu = UsualLib.MachineEnvironment.QueryEnvironment(key);

                txtValue.Text = valu;

                dgvValue.Rows.Clear();

                string[] values = valu.Split(';');
                foreach (string value in values)
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                        dgvValue.Rows.Add(value);
                }
            }
        }

        private void btnBro_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                txtJdk.Text = folderBrowserDialog1.SelectedPath;
        }

        /// <summary>
        /// JDK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtJdk.Text.Trim()))
            {
                //末尾\
                if (txtJdk.Text.Trim().EndsWith("\\"))
                    txtJdk.Text = txtJdk.Text.Trim().Substring(0, txtJdk.Text.Trim().Length - 1);

                #region javahome
                UsualLib.MachineEnvironment.SetEnvironment(javaHomeName, txtJdk.Text.Trim());
                #endregion

                #region CLASSPATH
                string defClassPathValue = string.Format(".;%{0}%\\lib\\dt.jar;%{0}%\\lib\\tools.jar", javaHomeName);
                //直接设置
                UsualLib.MachineEnvironment.SetEnvironment("CLASSPATH", defClassPathValue);

                #endregion

                #region Path

                //检查并附加
                string javaBin = string.Format("%{0}%\\bin", javaHomeName);

                //没有jre\bin ,eclipse 启动时会报找不到javaw.exe
                string jreBin = string.Format("%{0}%\\jre\\bin", javaHomeName);

                string oldPathValue = UsualLib.MachineEnvironment.QueryEnvironment("Path");

                if (!string.IsNullOrEmpty(oldPathValue))
                {
                    bool bInclude = false;
                    bool bJreBin = false;

                    string[] oldPathValues = oldPathValue.Split(';');
                    foreach (string opv in oldPathValues)
                    {
                        if (opv.ToUpper().Trim() == javaBin.ToUpper().Trim())
                        {
                            bInclude = true;
                        }

                        if (opv.ToUpper().Trim() == jreBin.ToUpper().Trim())
                        {
                            bJreBin = true;
                        }
                    }
                    if (!bInclude)
                    {
                        oldPathValue = javaBin + ";" + oldPathValue;
                    }

                    if (!bJreBin)
                    {
                        oldPathValue = jreBin + ";" + oldPathValue;
                    }
                    if (!bInclude || !bJreBin)
                    {
                        UsualLib.MachineEnvironment.SetEnvironment("Path", oldPathValue);
                    }
                }
                #endregion

                

                LoadValue();

                lblMsg.Text = DateTime.Now.ToString() + "设置JAVA相关环境变量完成。";

            }
            else
            {
                lblMsg.Text = DateTime.Now.ToString() + "目录不存在。";
            }
        }

        private void btnBroASDK_Click(object sender, EventArgs e)
        {
            if (fbdASDK.ShowDialog() == DialogResult.OK)
            {
                txtASDK.Text = fbdASDK.SelectedPath;
                SetASDKtoolsPath();
            }
        }


        private void SetASDKtoolsPath()
        {
            if (txtASDK.Text.Trim().EndsWith("\\"))
                txtASDK.Text = txtASDK.Text.Trim().Substring(0, txtASDK.Text.Trim().Length - 1);
        }

        /// <summary>
        /// 设置ANDROID SDK目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetASDK_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtASDK.Text.Trim()))
            {
                string tools = "%" + androidSdkHomeName + "%\\tools";
                string ptools = "%" + androidSdkHomeName + "%\\platform-tools";

                //设置 %Android_SDK_HOME%
                UsualLib.MachineEnvironment.SetEnvironment(androidSdkHomeName, txtASDK.Text.Trim());

                //修改Path
                string oldPathValue = UsualLib.MachineEnvironment.QueryEnvironment("Path");

                if (!string.IsNullOrEmpty(oldPathValue))
                {
                    bool bTools = false;
                    bool bPTools = false;
                    string[] oldPathValues = oldPathValue.Split(';');
                    foreach (string opv in oldPathValues)
                    {
                        if (opv.ToUpper().Trim() == tools.ToUpper().Trim())
                        {
                            bTools = true;
                        }
                        if (opv.ToUpper().Trim() == ptools.ToUpper().Trim())
                        {
                            bPTools = true;
                        }
                    }
                    if (!bTools)
                    {
                        oldPathValue = tools + ";" + oldPathValue;
                    }
                    if (!bPTools)
                    {
                        oldPathValue = ptools + ";" + oldPathValue;
                    }
                    if (!bTools || !bPTools)
                    {
                        UsualLib.MachineEnvironment.SetEnvironment("Path", oldPathValue);
                    }
                }


                LoadValue();

                lblMsg.Text = DateTime.Now.ToString() + "设置ANDROID SDK相关环境变量完成。";

            }
            else
            {
                lblMsg.Text = DateTime.Now.ToString() + "目录不存在。";
            }
        }

        private void txtASDK_Leave(object sender, EventArgs e)
        {
            if (Directory.Exists(txtASDK.Text.Trim()))
            {
                SetASDKtoolsPath();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UsualLib.RemForm.RememberForm(this, lstNotRem);
        }


        private void dgvValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvValue.Rows.Count > 1
                && dgvKey.Rows.Count >= 1)
            {
                if (DialogResult.Yes == MessageBox.Show("确定删除？", "", MessageBoxButtons.YesNo))
                {
                    string key = dgvKey.CurrentRow.Cells["ColKey"].Value.ToString();

                    foreach (DataGridViewRow dgvr in dgvValue.SelectedRows)
                    {
                        dgvValue.Rows.Remove(dgvr);
                    }

                    string valu = string.Empty;

                    foreach (DataGridViewRow dgvr in dgvValue.Rows)
                    {
                        valu += dgvr.Cells["ColValue"].Value.ToString() + ";";
                    }

                    if (valu.EndsWith(";"))
                        valu = valu.Substring(0, valu.Length - 1);

                    //直接设置
                    UsualLib.MachineEnvironment.SetEnvironment(key, valu);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
                MessageBox.Show(GetFileDesc.Get_FileDesc());
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
