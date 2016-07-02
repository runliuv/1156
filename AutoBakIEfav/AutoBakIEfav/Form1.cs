using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;

namespace AutoBakIEfav
{
    public partial class Form1 : Form
    {
        #region 声明变量

        /// <summary>
        /// 表示正在加载,在Form Load 尾设置为false;
        /// </summary>
        private bool bFormLoading = true;

        /// <summary>
        /// 当前程序所在目录
        /// </summary>
        string exePath = new DirectoryInfo(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName).Parent.FullName;
        /// <summary>
        /// 默认备份位置
        /// </summary>
        string defaultBakPath = @"D:\IE收藏夹备份\";

        /// <summary>
        /// 配置文件名
        /// </summary>
        string configXmlFileName = "Config.xml";
        /// <summary>
        /// 配置文件完整路径
        /// </summary>
        string configXmlFileFullName = string.Empty;

        List<string> lstDelFile = new List<string>();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bFormLoading = true;

            lblStatus.Text = "已停止";
            if (!exePath.EndsWith(@"\"))
            {
                exePath += @"\";
            }
            configXmlFileFullName = exePath + configXmlFileName;

            CheckConfigXml();
            ReadConfigXml();
            CheckStartWhenWinStart();

            //默认值
            txtBakPath.Text = defaultBakPath;
            txtCurIEfavPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);

            //启动后最小化
            if (chkMinWhenStart.Checked)
            {
                tmMinWhenStart = new Timer();
                tmMinWhenStart.Interval = 500;
                tmMinWhenStart.Tick += new EventHandler(tmMinWhenStart_Tick);
                tmMinWhenStart.Start();
            }

            bFormLoading = false;
        }

        Timer tmMinWhenStart;
        void tmMinWhenStart_Tick(object sender, EventArgs e)
        {
            this.Hide();
            tmMinWhenStart.Stop();
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        private void SaveConfig()
        {
            string strTmp = string.Empty;
            if (cbxBeginBakWhenStart.Checked)
            {
                strTmp = "1";
            }
            else
            {
                strTmp = "0";
            }
            XmlHelper.Update(configXmlFileFullName, "/Root/BeginBakWhenStart", "", strTmp);
            if (chkMinWhenStart.Checked) strTmp = "1"; else strTmp = "0";
            XmlHelper.Update(configXmlFileFullName, "/Root/MinWhenStart", "", strTmp);
            XmlHelper.Update(configXmlFileFullName, "/Root/AutoBakInt", "", nudAutoTime.Value.ToString());
            XmlHelper.Update(configXmlFileFullName, "/Root/BakPath", "", txtBakPath.Text.Trim());
            //备份后同步
            if (chkSyncAfterBak.Checked) strTmp = "1"; else strTmp = "0";
            XmlHelper.Update(configXmlFileFullName, "/Root/SyncAfterBak", "", strTmp);
        }

        /// <summary>
        /// 读取配置文件到UI
        /// </summary>
        private void ReadConfigXml()
        {
            string strTmp = XmlHelper.Read(configXmlFileFullName, "/Root/BeginBakWhenStart", "");
            if (!string.IsNullOrEmpty(strTmp.Trim()) && strTmp.Trim() == "1")
            {
                cbxBeginBakWhenStart.Checked = true;
            }

            //启动后最小化
            strTmp = XmlHelper.Read(configXmlFileFullName, "/Root/MinWhenStart", "");
            if (!string.IsNullOrEmpty(strTmp.Trim()) && strTmp.Trim() == "1")
            {
                chkMinWhenStart.Checked = true;
            }

            strTmp = XmlHelper.Read(configXmlFileFullName, "/Root/AutoBakInt", "");
            decimal dOut = 1;
            if (!string.IsNullOrEmpty(strTmp.Trim()) && decimal.TryParse(strTmp.Trim(), out dOut))
            {
                if (dOut >= 1 && dOut <= 10)
                {
                    nudAutoTime.Value = dOut;
                }

            }

            strTmp = XmlHelper.Read(configXmlFileFullName, "/Root/BakPath", "");
            if (!string.IsNullOrEmpty(strTmp.Trim()))
            {
                defaultBakPath = strTmp;
            }
            //备份后同步  SyncAfterBak
            strTmp = XmlHelper.Read(configXmlFileFullName, "/Root/SyncAfterBak", "");
            if (strTmp.ToString() == "1")
            {
                chkSyncAfterBak.Checked = true;
            }

            //勾选了 启动时开始自动备份
            if (cbxBeginBakWhenStart.Checked)
            {
                btnStart_Click(null, null);
            }
        }

        /// <summary>
        /// 检查XML配置文件，不存在则创建。
        /// </summary>
        private void CheckConfigXml()
        {
            if (!File.Exists(configXmlFileFullName))
            {
                try
                {
                    XDocument doc = new XDocument(
                        new XElement("Root",
                            new XElement("BeginBakWhenStart", "0"),
                            new XElement("MinWhenStart", "0"),
                            new XElement("AutoBakInt", "1"),
                            new XElement("BakPath", defaultBakPath),
                            new XElement("SyncAfterBak", "0")
                            )
                        );
                    doc.Save(configXmlFileFullName);

                }
                catch (Exception exp)
                { MessageBox.Show(exp.Message); }
            }
            else
            {
                //检查每个节点是否存在。                 
                XmlDocument doc = new XmlDocument();
                doc.Load(configXmlFileFullName);
                //开机时启动
                XmlNode xn = doc.SelectSingleNode("/Root/BeginBakWhenStart");
                if (xn == null)
                {
                    XmlHelper.Insert(configXmlFileFullName, "/Root", "BeginBakWhenStart", "", "0");
                }

                //启动后最小化
                xn = doc.SelectSingleNode("/Root/MinWhenStart");
                if (xn == null)
                {
                    XmlHelper.Insert(configXmlFileFullName, "/Root", "MinWhenStart", "", "0");
                }
                //自动备份时间
                xn = doc.SelectSingleNode("/Root/AutoBakInt");
                if (xn == null)
                {
                    XmlHelper.Insert(configXmlFileFullName, "/Root", "AutoBakInt", "", "1");
                }
                //备份目录
                xn = doc.SelectSingleNode("/Root/BakPath");
                if (xn == null)
                {
                    XmlHelper.Insert(configXmlFileFullName, "/Root", "BakPath", "", defaultBakPath);
                }
                //备份后同步
                xn = doc.SelectSingleNode("/Root/SyncAfterBak");
                if (xn == null)
                {
                    XmlHelper.Insert(configXmlFileFullName, "/Root", "SyncAfterBak", "", "0");
                }
            }
        }

        /// <summary>
        /// 选择备份位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoose_Click(object sender, EventArgs e)
        {
            NewFolderBrowDia fdSource = new NewFolderBrowDia();
            if (fdSource.DisplayDialog() == DialogResult.OK)
            {
                txtBakPath.Text = fdSource.Path;
            }
        }

        /// <summary>
        /// 备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBak_Click(object sender, EventArgs e)
        {
            string bakPath = txtBakPath.Text.Trim();
            if (!Directory.Exists(bakPath))
            {
                //是否要创建
                if (MessageBox.Show("备份文件夹不存在，是否要创建？", "是否要创建？", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(bakPath);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("创建失败！" + exp.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("请选择有效文件夹！");
                    return;
                }
            }

            if (MessageBox.Show("确定要备份？", "确定要备份？", MessageBoxButtons.YesNo) ==
                    DialogResult.No)
            {
                return;
            }
            //备份
            DirCopy(txtCurIEfavPath.Text.Trim(), bakPath, true);

            SaveConfig();
            MessageBox.Show("备份完成！");
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sFrom"></param>
        /// <param name="sTo"></param>
        private void DirCopy(string sFrom, string sTo, bool showMsg)
        {
            DirectoryInfo diTar;
            try
            {
                diTar = new DirectoryInfo(sTo);
            }
            catch (Exception exp)
            {
                if (showMsg)
                    MessageBox.Show("备份位置不正确！" + exp.Message);
                return;
            }

            DirectoryInfo diSou = new DirectoryInfo(sFrom);
            FileSystemInfo[] fsisSou = diSou.GetFileSystemInfos();
            foreach (FileSystemInfo fsi in fsisSou)
            {
                if (fsi is DirectoryInfo)
                {
                    string tarDirFullName = diTar.FullName + @"\" + fsi.Name;
                    if (!Directory.Exists(tarDirFullName))
                    {
                        try
                        {
                            Directory.CreateDirectory(tarDirFullName);
                        }
                        catch (Exception exp)
                        {
                            if (showMsg)
                                MessageBox.Show("创建文件夹失败！" + exp.Message);
                            return;
                        }
                    }

                    if (Directory.Exists(tarDirFullName))
                    {
                        DirCopy(fsi.FullName, tarDirFullName, showMsg);
                    }
                }
                else if (fsi is FileInfo)
                {
                    string tarFileFullName = diTar.FullName + @"\" + fsi.Name;
                    try
                    {
                        File.Copy(fsi.FullName, tarFileFullName, true);
                    }
                    catch (Exception exp)
                    {
                        if (showMsg)
                            MessageBox.Show("复制文件失败！" + exp.Message);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            string bakPath = txtBakPath.Text.Trim();
            if (string.IsNullOrEmpty(bakPath))
            {
                MessageBox.Show("备份位置不存在！");
                return;
            }
            if (!Directory.Exists(bakPath))
            {
                MessageBox.Show("备份位置不存在！");
                return;
            }

            if (MessageBox.Show("确定要还原？", "确定要还原？", MessageBoxButtons.YesNo) ==
                    DialogResult.No)
            {
                return;
            }

            DirCopy(bakPath, txtCurIEfavPath.Text.Trim(), true);

            SaveConfig();
            MessageBox.Show("还原成功！");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "已开始";
            tmToAutoBak.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "已停止";
            tmToAutoBak.Stop();
        }

        /// <summary>
        /// 计秒，TIMER的间隔是秒
        /// </summary>
        private int bakCount = 0;

        private void tmToAutoBak_Tick(object sender, EventArgs e)
        {
            bakCount += 1;
            if (bakCount / 60 >= nudAutoTime.Value)
            {
                bakCount = 0;

                DirCopy(txtCurIEfavPath.Text.Trim(), txtBakPath.Text.Trim(), false);

                SaveConfig();
            }
        }

        private void btnMinToTray_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiView_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.Visible && e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        private void cbxStartWhenWinStart_CheckedChanged(object sender, EventArgs e)
        {
            if (!bFormLoading)
            {
                if (cbxStartWhenWinStart.Checked)
                {
                    RegAutoStart();
                }
                else
                {
                    UnRegAutoStart();
                }
            }
        }

        /// <summary>
        /// 检查开始启动，从注册表中查询。
        /// </summary>
        private void CheckStartWhenWinStart()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            object obSt = reg.GetValue("AutoBakIEfav");
            if (obSt != null)
            {
                //如果存在，检查路径是否正确。
                if (obSt.ToString().ToLower() != Application.ExecutablePath.ToLower())
                {
                    RegAutoStart();
                }

                cbxStartWhenWinStart.Checked = true;
            }

            reg.Close();
        }

        private void RegAutoStart()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("AutoBakIEfav", Application.ExecutablePath);
            reg.Close();
        }

        private void UnRegAutoStart()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.DeleteValue("AutoBakIEfav");
            reg.Close();
        }

        private void cbxBeginBakWhenStart_CheckedChanged(object sender, EventArgs e)
        {
            if (!bFormLoading)
            {
                SaveConfig();
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveConfig();

            MessageBox.Show("保存完成！");
        }

        private void chkMinWhenStart_CheckedChanged(object sender, EventArgs e)
        {
            if (!bFormLoading)
            {
                SaveConfig();
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            DoSync();
        }

        public void DoSync()
        {
            string tarDir = txtBakPath.Text.Trim();
            if (string.IsNullOrEmpty(tarDir))
            {
                MessageBox.Show("备份目录为空。");
                return;
            }
            try
            {
                DirectoryInfo di = new DirectoryInfo(tarDir);
            }
            catch (Exception exp)
            {
                MessageBox.Show("备份目录有问题。");
                return;
            }

            lstDelFile.Clear();
            CollectDelFile(txtCurIEfavPath.Text, tarDir);

            if (lstDelFile != null && lstDelFile.Count > 0)
            {
                frmShowDelFileForSync frm = new frmShowDelFileForSync();
                frm.LstDataSource = lstDelFile;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        //先删除文件
                        foreach (string delFileFullName in lstDelFile)
                        {
                            if (File.Exists(delFileFullName))
                                File.Delete(delFileFullName);
                        }
                        //再删除目录
                        foreach (string delFileFullName in lstDelFile)
                        {
                            if (Directory.Exists(delFileFullName))
                                Directory.Delete(delFileFullName,true);
                        }
                    }
                    catch (Exception exp)
                    { }
                }
            }

        }

        /// <summary>
        /// baseDir 以IE收藏夹目录为准。tarDir 待同步的文件夹。
        /// </summary>
        /// <param name="baseDir"></param>
        /// <param name="tarDir"></param>
        public void CollectDelFile(string baseDir, string tarDir)
        {
            DirectoryInfo diBase;
            DirectoryInfo diTar;
            try
            {
                diBase = new DirectoryInfo(baseDir);
                diTar = new DirectoryInfo(tarDir);
            }
            catch (Exception exp)
            {
                return;
            }

            FileSystemInfo[] fsisSou = diTar.GetFileSystemInfos();
            foreach (FileSystemInfo fsi in fsisSou)
            {
                if (fsi is DirectoryInfo)
                {
                    //检查IE收藏夹有没有这个目录
                    string tarDirFullName = diBase.FullName + @"\" + fsi.Name;
                    //没有则放到待删除中
                    if (!Directory.Exists(tarDirFullName))
                    {
                        lstDelFile.Add(fsi.FullName);
                    }
                    //有则继续
                    if (Directory.Exists(tarDirFullName))
                    {
                        CollectDelFile(tarDirFullName, fsi.FullName);
                    }
                }
                else if (fsi is FileInfo)
                {
                    //检查IE收藏夹有没有这个文件
                    string tarFileFullName = diBase.FullName + @"\" + fsi.Name;
                    //没有则放到待删除中
                    if (!File.Exists(tarFileFullName))
                    {
                        lstDelFile.Add(fsi.FullName);
                    }
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) Application.Exit();
        }

        private void btnOpenIEFav_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", txtCurIEfavPath.Text);
        }

        private void btnOpenBak_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", txtBakPath.Text);
        }
    }
}
