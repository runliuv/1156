using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using UsualLib;
using Microsoft.Win32;

namespace GameArchiveBak
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
        /// 配置文件名
        /// </summary>
        string configXmlFileName = "ABConfig.xml";
        /// <summary>
        /// 配置文件完整路径
        /// </summary>
        string configXmlFileFullName = string.Empty;
        /// <summary>
        /// 数据库文件名
        /// </summary>
        string dbName = "GameDoc.db";
        /// <summary>
        /// 数据库完整路径
        /// </summary>
        string dbFullName = string.Empty;

        /// <summary>
        /// 数据库的操作。
        /// </summary>
        SqliteOper _SqliteOp;

        /// <summary>
        /// 开机启动在注册表中的名字
        /// </summary>
        private string startOnSysStartRegKey = "archives_backup";

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 初始
            dgvMain.AutoGenerateColumns = false;
            lblOpStatus.Text = string.Empty;
            lblAutoBakStatus.Text = string.Empty;

            if (!exePath.EndsWith(@"\"))
            {
                exePath += @"\";
            }
            dbFullName = exePath + dbName;
            txtBakMainDir.Text = @"d:\存档备份";
            #endregion

            CheckStartWhenWinStart();

            //从XML加载textbox内容
            RemForm.ReadRememberForm(this, null);

            //检查数据库
            _SqliteOp = new SqliteOper(dbFullName);
            if (!_SqliteOp.CheckDb())
            {
                MessageBox.Show("创建数据库失败！");
                gbOp.Enabled = false;
                return;
            }
            BindGrid();

            bFormLoading = false;
        }

        private void BindGrid()
        {
            dgvMain.DataSource = _SqliteOp.GetGameDocList();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckBakMain())
                return;

            DirectoryInfo diBakMain = new DirectoryInfo(txtBakMainDir.Text.Trim());

            FrmAdd frm = new FrmAdd();
            frm.FormAcessMode = EnumClass.FormAcessMode.Add;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                //检查是否包含在特殊目录中
                bool bIsSpec = false;
                string specDirName = string.Empty;
                string outputPath = string.Empty;
                IsSpecDir(frm.SourcePath, out bIsSpec, out specDirName, out outputPath);

                string myID = Guid.NewGuid().ToString();
                string rst = _SqliteOp.InsertGameDoc(myID, frm.DocDescr, outputPath, diBakMain.FullName, "", bIsSpec, specDirName);
                if ("1" != rst)
                {
                    MessageBox.Show(rst);
                    return;
                }

                BindGrid();
            }
        }

        /// <summary>
        /// 检查备份主目录。不存在则创建。
        /// </summary>
        /// <returns></returns>
        private bool CheckBakMain()
        {
            DirectoryInfo diBakMain;
            if (string.IsNullOrEmpty(txtBakMainDir.Text.Trim()))
            {
                MessageBox.Show("没有设置备份主目录。");
                return false;
            }
            else
            {
                try
                {
                    diBakMain = new DirectoryInfo(txtBakMainDir.Text.Trim());
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                    return false;
                }

                if (!diBakMain.Exists)
                {
                    diBakMain.Create();
                }
            }

            return true;
        }

        /// <summary>
        /// 判断是否包含特殊目录。inputPath 要判断的目录。bIsSpec 是否包含特殊目录。specDirName 特殊目录名称。outputPath 去除特殊目录的部分。
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="bIsSpec"></param>
        /// <param name="specDirName"></param>
        /// <param name="outputPath"></param>
        public void IsSpecDir(string inputPath, out bool bIsSpec, out string specDirName, out string outputPath)
        {

            bIsSpec = false;
            specDirName = string.Empty;
            outputPath = inputPath;
            IList<string> lstsf = Enum.GetNames(typeof(Environment.SpecialFolder));
            foreach (string sf in lstsf)
            {
                Environment.SpecialFolder sfType = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), sf);
                string specDir = Environment.GetFolderPath(sfType);
                if (string.IsNullOrEmpty(specDir))
                {
                    continue;
                }
                if (inputPath.ToLower().Contains(specDir.ToLower()))
                {
                    bIsSpec = true;
                    specDirName = sf;
                    outputPath = inputPath.ToLower().Replace(specDir.ToLower(), "");
                    break;
                }
            }
        }

        /// <summary>
        /// 按名字获取特殊目录的路径。
        /// </summary>
        /// <param name="specDirName"></param>
        /// <returns></returns>
        private string GetSpecDirValue(string specDirName)
        {
            string tmp = "";

            Environment.SpecialFolder sfType = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), specDirName);
            tmp = Environment.GetFolderPath(sfType);

            return tmp;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count > 0)
            {
                string sourcePath = dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells["co_DocSource"].Value.ToString();
                string sourcePathFull = sourcePath;
                bool bIsSpec = false;
                string specDirName = string.Empty;
                string outputPath = string.Empty;

                string editId = dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells["co_gdid"].Value.ToString();
                string targetFull = dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells["co_DocTargetFull"].Value.ToString();
                if (dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells["co_IncludeSpecDir"].Value.ToString().ToLower() == "true")
                {
                    specDirName = dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells["co_SpecDirName"].Value.ToString();
                    string tmpSource = GetSpecDirValue(specDirName);
                    sourcePathFull = tmpSource + sourcePath;
                }

                FrmAdd frm = new FrmAdd();
                frm.FormAcessMode = EnumClass.FormAcessMode.Edit;
                frm.DocDescr = dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells["co_DocDescr"].Value.ToString();
                frm.SourcePath = sourcePathFull;
                frm.TargetPath = dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells["co_DocTarget"].Value.ToString();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    //检查是否包含在特殊目录中

                    IsSpecDir(frm.SourcePath, out bIsSpec, out specDirName, out outputPath);

                    _SqliteOp.UpdateGameDoc(editId, frm.DocDescr, outputPath, frm.TargetPath, targetFull, bIsSpec, specDirName);

                    BindGrid();
                }
            }
        }

        /// <summary>
        /// 根据源目录是否包含特殊目录产生源目录完整路径。
        /// </summary>
        /// <param name="dgvr"></param>
        /// <returns></returns>
        private string GenSourcePathFull(DataGridViewRow dgvr)
        {
            string sourcePath = dgvr.Cells["co_DocSource"].Value.ToString();
            string sourcePathFull = sourcePath;
            if (dgvr.Cells["co_IncludeSpecDir"].Value.ToString().ToLower() == "true")
            {
                string specDirName = dgvr.Cells["co_SpecDirName"].Value.ToString();
                string tmpSource = GetSpecDirValue(specDirName);
                sourcePathFull = tmpSource + sourcePath;
            }
            return sourcePathFull;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count > 0)
            {
                if (MessageBox.Show("确定删除？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string editId = dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells["co_gdid"].Value.ToString();
                    if (_SqliteOp.DeleteGameDoc(editId))
                    {
                        lblOpStatus.Text = "删除成功！";
                        dgvMain.Rows.RemoveAt(dgvMain.CurrentCell.RowIndex);
                    }
                    else
                    {
                        lblOpStatus.Text = "删除失败！";
                    }
                }
            }
        }

        /// <summary>
        /// 备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBak_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
                return;

            if (!CheckBakMain())
                return;

            if (MessageBox.Show("确定备份？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BakMethod(dgvMain.Rows[dgvMain.CurrentCell.RowIndex]);

                lblOpStatus.Text = "备份完成！" + DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// 全部备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBakAll_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
                return;

            if (!CheckBakMain())
                return;

            if (MessageBox.Show("确定备份？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow dgvr in dgvMain.Rows)
                {
                    BakMethod(dgvr);
                }
                lblOpStatus.Text = "备份完成！" + DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// 备份
        /// </summary>
        /// <param name="dgvr"></param>
        private void BakMethod(DataGridViewRow dgvr)
        {
            string editId = dgvr.Cells["co_gdid"].Value.ToString();
            string strDocDesc = dgvr.Cells["co_DocDescr"].Value.ToString();
            //检查源目录
            string sourcePath = GenSourcePathFull(dgvr);
            if (!Directory.Exists(sourcePath))
            {
                lbxMsg.Items.Insert(0, "源目录不存在！" + sourcePath);
                return;
            }

            #region 如果目标目录不存在，创建
            DirectoryInfo diBakMain = new DirectoryInfo(txtBakMainDir.Text.Trim());
            string targetPath = diBakMain.FullName;
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);
            if (!targetPath.EndsWith(@"\"))
                targetPath += @"\";

            //相对位置
            string oppoPath = strDocDesc + "_" + editId;
            string targetFullPath = targetPath + oppoPath;
            if (!Directory.Exists(targetFullPath))
                Directory.CreateDirectory(targetFullPath);
            #endregion

            //复制
            UDirCopy.DirCopy(sourcePath, targetFullPath, true);

            _SqliteOp.UpdateTargetPathFull(editId, diBakMain.FullName, oppoPath);

            //更新界面
            dgvr.Cells["co_DocTarget"].Value = diBakMain.FullName; //当时备份主目录
            dgvr.Cells["co_DocTargetFull"].Value = oppoPath;//相对位置
        }

        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="dgvr"></param>
        private void Restore(DataGridViewRow dgvr)
        {
            string editId = dgvr.Cells["co_gdid"].Value.ToString();
            //检查源目录
            string sourcePath = GenSourcePathFull(dgvr);
            if (!Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(sourcePath);
                lblOpStatus.Text = string.Format("源目录 {0} 不存在！ 现已创建!", sourcePath) + DateTime.Now.ToString();

            }
            //如果目标目录不存在
            DirectoryInfo di = new DirectoryInfo(txtBakMainDir.Text.Trim());
            string myPath=di.FullName;
            if(!myPath.EndsWith(@"\"))
                myPath+=@"\";
            string oppoPath=dgvr.Cells["co_DocTargetFull"].Value.ToString();
            string targetFullPath = myPath + oppoPath;
            if (!Directory.Exists(targetFullPath))
            {
                MessageBox.Show("目标目录不存在！：" + targetFullPath);
                return;
            }

            UDirCopy.DirCopy(targetFullPath, sourcePath, true);

            lblOpStatus.Text = "还原完成！" + DateTime.Now.ToString();
        }


        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
                return;

            if (string.IsNullOrEmpty(txtBakMainDir.Text.Trim()) || !Directory.Exists(txtBakMainDir.Text.Trim()))
            {
                MessageBox.Show("备份主目录不存在。");
                return;
            }

            if (MessageBox.Show("确定还原当前选择？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Restore(dgvMain.CurrentRow);
            }
        }

        /// <summary>
        /// 还原所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestoreAll_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
                return;

            if (string.IsNullOrEmpty(txtBakMainDir.Text.Trim()) || !Directory.Exists(txtBakMainDir.Text.Trim()))
            {
                MessageBox.Show("备份主目录不存在。");
                return;
            }

            if (MessageBox.Show("确定还原所有？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow dgvr in dgvMain.Rows)
                {
                    Restore(dgvr);
                }
            }
        }



        private void btnMinToTray_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        #region 开机启动

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

        private void RegAutoStart()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue(startOnSysStartRegKey, Application.ExecutablePath);
            reg.Close();
        }

        private void UnRegAutoStart()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.DeleteValue(startOnSysStartRegKey);
            reg.Close();
        }

        /// <summary>
        /// 检查开始启动，从注册表中查询。
        /// </summary>
        private void CheckStartWhenWinStart()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            object obSt = reg.GetValue(startOnSysStartRegKey);
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

        #endregion

        private void cbxBeginBakWhenStart_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tsmiView_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ninAB_DoubleClick(object sender, EventArgs e)
        {
            if (!this.Visible)
                this.Show();
        }

        //选择主目录
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fbdBakMainDir.ShowDialog() == DialogResult.OK)
                txtBakMainDir.Text = fbdBakMainDir.SelectedPath;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemForm.RememberForm(this, null);
        }

        /// <summary>
        /// 显示完整路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0
                || string.IsNullOrEmpty(txtBakMainDir.Text.Trim())
                || !Directory.Exists(txtBakMainDir.Text.Trim()))
                return;

            string oppoPath = dgvMain.CurrentRow.Cells["co_DocTargetFull"].Value.ToString();

            if (string.IsNullOrEmpty(oppoPath))
            {
                txtBakFullPath.Text = string.Empty;
                return;
            }

            DirectoryInfo di = new DirectoryInfo(txtBakMainDir.Text.Trim());
            string myPath = di.FullName;
            if (!myPath.EndsWith(@"\"))
                myPath += @"\";

            txtBakFullPath.Text = myPath + oppoPath;
        }

        #region 按ESC 提示是否要退出
        //按ESC 提示是否要退出  
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData) //激活回车键  
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        if (MessageBox.Show("确定要退出么？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            this.Close();//csc关闭窗体  
                        }
                        break;
                    //case Keys.Enter:
                    //    btnOK_Click(null, null);
                    //    break;
                }

            }
            return false;
        }
        #endregion

    }
}
