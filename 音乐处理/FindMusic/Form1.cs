using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace FindMusic
{
    public partial class Form1 : Form
    {
        Thread thdFind;
        Thread thdCopy;
        Thread thdDel;

        /// <summary>
        /// 是否查找(1) (2)
        /// </summary>
        bool bFindC2 = false;
        //复制完成后提示消息和启用控件
        private delegate void DlgCopyFinishMsg();
        private DlgCopyFinishMsg InsCopyFinishMsg;

        //复制时的状态
        private delegate void DlgDisplayStatus(string strMsg);
        private DlgDisplayStatus InsDisplayStauts;

        /// <summary>
        /// 把查找内容显示在GRID
        /// </summary>
        private delegate void DlgToGrid(string fileFullName);
        /// <summary>
        /// 把查找内容显示在GRID
        /// </summary>
        private DlgToGrid InsToGrid;

        private delegate void DlgEnableControl();
        private DlgEnableControl InsEnableCtl;

        //从DataGridView 上删除行
        private delegate void DlgDelFromDg(DataGridViewRow dgvr);
        private DlgDelFromDg InsDelFromDg;

        private delegate void DlgEnableCtlWhenDelFinish();
        private DlgEnableCtlWhenDelFinish InsEnableCtlWhenDelFinish;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbExt.Items.Add(".mp3");
            lbFindDir.Items.Add(@"e:\");
            lbExclude.Items.Add(@"e:\Kugou\Temp\");

            cbxBiggerThan.Checked = true;
            txtBiggerThan.Text = "1500";
            //txtFindPath.Text = "e:";
            txtCopyTo.Text = @"d:\MusicAll\";
            dgvMain.AutoGenerateColumns = false;
            btnStop.Enabled = false;
            btnStopCopy.Enabled = false;
            btnStopC2.Enabled = false;

            InsToGrid = new DlgToGrid(ToGrid);
            InsEnableCtl = new DlgEnableControl(EnableControl);
            InsCopyFinishMsg = new DlgCopyFinishMsg(CopyFinishMsg);
            InsDisplayStauts = new DlgDisplayStatus(DisplayCopyStatus);
            InsDelFromDg = new DlgDelFromDg(DelFromDg);
            InsEnableCtlWhenDelFinish = new DlgEnableCtlWhenDelFinish(EnableCtlWhenDelFinish);
        }

        private void DelFromDg(DataGridViewRow dgvr)
        {
            dgvMain.Rows.Remove(dgvr);
        }

        private void DisplayCopyStatus(string strMsg)
        {
            lblStatus.Text = strMsg;
        }

        private void CopyFinishMsg()
        {
            btnStopCopy.Enabled = false;
            btnCopy.Enabled = true;
            lblStatus.Text = "复制完成！";
            MessageBox.Show("复制完成！");
        }

        private void EnableControl()
        {
            if (bFindC2)
            {
                btnStopC2.Enabled = false;
                btnFind.Enabled = true;
                btnFindC2.Enabled = true;
            }
            else
            {
                btnStop.Enabled = false;
                btnFind.Enabled = true;
                btnFindC2.Enabled = true;
            }
        }

        private void ToGrid(string fileFullName)
        {
            dgvMain.Rows.Add(fileFullName);
        }

        private bool CheckBeforeFind()
        {
            if (lbFindDir.Items.Count == 0)
            {
                MessageBox.Show("至少有一个查找位置！");
                return false;
            }

            if (lbExt.Items.Count == 0)
            {
                MessageBox.Show("至少有一项文件类型！");
                return false;
            }


            if (cbxBiggerThan.Checked)
            {
                if (string.IsNullOrEmpty(txtBiggerThan.Text.Trim()))
                {
                    MessageBox.Show("大小不能为空！");
                    return false;
                }
                int iOut = 0;
                if (!int.TryParse(txtBiggerThan.Text.Trim(), out iOut))
                {
                    MessageBox.Show("必须输入整数！");
                    return false;
                }
            }

            return true;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeFind())
            {
                return;
            }

            //查找前把GRID清空
            dgvMain.Rows.Clear();

            bFindC2 = false;
            ThreadStart tst = new ThreadStart(FindMusic);
            thdFind = new Thread(tst);
            thdFind.Start();

            btnStop.Enabled = true;
            btnFind.Enabled = false;
            btnFindC2.Enabled = false;
        }

        private void FindMusic()
        {
            int iOut = 0;
            int.TryParse(txtBiggerThan.Text.Trim(), out iOut);

            foreach (object obPath in lbFindDir.Items)
            {
                string strFindPath = obPath.ToString();
                //如果以盘符结尾，加上\，否则DirectoryInfo 实例后位置不正确。
                if (strFindPath.EndsWith(":"))
                {
                    strFindPath = strFindPath + @"\";
                }
                try
                {
                    DirectoryInfo diFind = new DirectoryInfo(strFindPath);

                    FindMusicLo(diFind.FullName, cbxBiggerThan.Checked, iOut);
                }
                catch (Exception ex)
                { }
            }

            this.BeginInvoke(InsEnableCtl);
        }

        private void FindMusicLo(string findPath, bool checkSize, int fileSize)
        {
            //系统目录，特殊名目录，懒得处理，直接TRY CATCH
            try
            {
                DirectoryInfo diTar = new DirectoryInfo(findPath);
                if (ExcludeDir(diTar.FullName))
                {
                    return;
                }
                FileInfo[] allFi = diTar.GetFiles();
                foreach (FileInfo fi in allFi)
                {
                    //检查后缀
                    if (lbExt.Items.Contains(fi.Extension.ToLower()))
                    {
                        //检查大小
                        if (checkSize)
                        {
                            long fSizeKB = fi.Length / 1024;
                            if (fSizeKB < fileSize)
                            {
                                continue;
                            }
                        }

                        //如果是查找(1) (2)
                        if (bFindC2)
                        {                            
                            if (!MatchC2(fi.Name))
                            {
                                continue;
                            }
                        }
                        this.BeginInvoke(InsToGrid, fi.FullName);
                    }
                }

                DirectoryInfo[] allDi = diTar.GetDirectories();
                foreach (DirectoryInfo di in allDi)
                {
                    FindMusicLo(di.FullName, checkSize, fileSize);
                }
            }
            catch (Exception exp)
            {
            }
        }

        /// <summary>
        /// 是否包含(1) (2)
        /// </summary>
        /// <param name="strFName"></param>
        /// <returns></returns>
        private bool MatchC2(string strFName)
        {
            Regex rgx = new Regex(@"\(\d+\)");
            if (rgx.IsMatch(strFName))
            {
                return true;
                
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// 排除的文件夹,返回TRUE 表示排除，FALSE不排除
        /// </summary>
        /// <param name="findDirFullName"></param>
        /// <returns></returns>
        private bool ExcludeDir(string findDirFullName)
        {
            if (!findDirFullName.EndsWith(@"\"))
            {
                findDirFullName += @"\";
            }
            foreach (object oItem in lbExclude.Items)
            {
                string oPath = oItem.ToString().ToLower();
                if (!oPath.EndsWith(@"\"))
                {
                    oPath += @"\";
                }
                if (findDirFullName.ToLower().Contains(oPath))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;

            btnFind.Enabled = true;
            btnFindC2.Enabled = true;

            thdFind.Abort();
        }

        private void btnAddExt_Click(object sender, EventArgs e)
        {
            string newItem = txtExt.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("不能为空！");
                return;
            }
            if (!lbExt.Items.Contains(newItem))
            {
                lbExt.Items.Add(newItem);
            }
        }

        private void btnDelExt_Click(object sender, EventArgs e)
        {
            if (lbExt.SelectedIndex > -1)
            {
                lbExt.Items.RemoveAt(lbExt.SelectedIndex);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                //检查是否有选择文件 
                if (dgvMain.SelectedRows.Count == 0)
                {
                    MessageBox.Show("没有选择任何文件！");
                    return;
                }

                //检查目标文件夹
                string targetDir = txtCopyTo.Text.Trim();

                DirectoryInfo di = new DirectoryInfo(targetDir);

                if (!di.Exists)
                {
                    Directory.CreateDirectory(di.FullName);
                }

                ThreadStart tst = new ThreadStart(CopyFile);
                thdCopy = new Thread(tst);
                thdCopy.Start();

                btnStopCopy.Enabled = true;
                btnCopy.Enabled = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void CopyFile()
        {
            try
            {
                string targetDir = txtCopyTo.Text.Trim();
                //用DirectoryInfo获取FullName比较好。 如果目标目录只输入了个名字，比如： aaa ，DirectoryInfo 也能获得 FULL NAME。
                DirectoryInfo di = new DirectoryInfo(targetDir);
                targetDir = di.FullName;
                if (!targetDir.EndsWith(@"\"))
                {
                    targetDir += @"\";
                }

                foreach (DataGridViewRow dgvr in dgvMain.SelectedRows)
                {
                    FileInfo fi = new FileInfo(dgvr.Cells["ColumnFileFullName"].Value.ToString());
                    if (fi != null && fi.Exists)
                    {
                        string tarFileFullName = targetDir + fi.Name;
                        File.Copy(fi.FullName, tarFileFullName, true);

                        string strMsg = "正在复制 " + fi.FullName + " 到 " + tarFileFullName;
                        this.BeginInvoke(InsDisplayStauts, strMsg);
                    }
                }
            }
            catch (Exception exp)
            { }
            finally
            {
                this.BeginInvoke(InsCopyFinishMsg);
            }
        }

        private void btnStopCopy_Click(object sender, EventArgs e)
        {
            btnStopCopy.Enabled = false;
            btnCopy.Enabled = true;

            if (thdCopy != null)
            {
                thdCopy.Abort();
            }
        }

        //添加排除文件夹
        private void btnAddExclude_Click(object sender, EventArgs e)
        {
            string newItem = txtExclude.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("不能为空！");
                return;
            }
            if (!lbExclude.Items.Contains(newItem))
            {
                lbExclude.Items.Add(newItem);
            }
        }

        //DEL排除文件夹
        private void btnDelExclude_Click(object sender, EventArgs e)
        {
            if (lbExclude.SelectedIndex > -1)
            {
                lbExclude.Items.RemoveAt(lbExclude.SelectedIndex);
            }
        }

        //添加查找文件夹
        private void btnAddDir_Click(object sender, EventArgs e)
        {
            string newItem = txtFindPath.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("不能为空！");
                return;
            }
            if (!lbFindDir.Items.Contains(newItem))
            {
                lbFindDir.Items.Add(newItem);
            }
        }

        //DEL查找文件夹
        private void btnDelDir_Click(object sender, EventArgs e)
        {
            if (lbFindDir.SelectedIndex > -1)
            {
                lbFindDir.Items.RemoveAt(lbFindDir.SelectedIndex);
            }
        }

        private void btnFindC2_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeFind())
            {
                return;
            }

            //查找前把GRID清空
            dgvMain.Rows.Clear();

            bFindC2 = true;
            ThreadStart tst = new ThreadStart(FindMusic);
            thdFind = new Thread(tst);
            thdFind.Start();

            btnStopC2.Enabled = true;
            btnFind.Enabled = false;
            btnFindC2.Enabled = false;
        }

        private void btnStopC2_Click(object sender, EventArgs e)
        {
            btnStopC2.Enabled = false;

            btnFind.Enabled = true;
            btnFindC2.Enabled = true;

            thdFind.Abort();
        }

        private void btnDelC2_Click(object sender, EventArgs e)
        {
            try
            {
                //检查是否有选择文件 
                if (dgvMain.SelectedRows.Count == 0)
                {
                    MessageBox.Show("没有选择任何文件！");
                    return;
                }

                if (MessageBox.Show("是否确定删除？", "", MessageBoxButtons.YesNo) ==
                    DialogResult.No)
                {
                    return;
                }
                //检查目标文件夹


                ThreadStart tst = new ThreadStart(DelFile);
                thdDel = new Thread(tst);
                thdDel.Start();
                 
                btnDelC2.Enabled = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void DelFile()
        {
            try
            {
                foreach (DataGridViewRow dgvr in dgvMain.SelectedRows)
                {
                    FileInfo fi = new FileInfo(dgvr.Cells["ColumnFileFullName"].Value.ToString());
                    if (fi != null && fi.Exists)
                    {
                        if (!MatchC2(fi.Name))
                        {
                            continue;
                        }
                        File.Delete(fi.FullName);

                        string strMsg = "正在删除 " + fi.FullName;
                        this.BeginInvoke(InsDisplayStauts, strMsg);

                        this.BeginInvoke(InsDelFromDg, dgvr);                        
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.BeginInvoke(InsEnableCtlWhenDelFinish);
            }
        }


        private void EnableCtlWhenDelFinish()
        {
            btnDelC2.Enabled = true;
            lblStatus.Text = "删除完成";
        }

        private void btnFindSameInTwo_Click(object sender, EventArgs e)
        {
            frmFindSameInTwo frm = new frmFindSameInTwo();
            frm.ShowDialog();
        }
    }
}
