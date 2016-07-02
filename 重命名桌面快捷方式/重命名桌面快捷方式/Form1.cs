using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UsualLib;
using System.Reflection;

namespace 重命名桌面快捷方式
{
    public partial class Form1 : Form
    {
        #region 变量
        string dbFullName = string.Empty;

        SqliteOper _SlOp;

        SpecDirOp _SpecOp = new SpecDirOp();

        /// <summary>
        /// 当前程序所在目录
        /// </summary>
        string exePath = new DirectoryInfo(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName).Parent.FullName;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvMain.AutoGenerateColumns = false;

            if (!exePath.EndsWith(@"\"))
            {
                exePath += @"\";
            }
            dbFullName = exePath + "RenameSC.db";

            //检查数据库
            //检查数据库
            _SlOp = new SqliteOper(dbFullName);
            if (!_SlOp.CheckDb())
            {
                MessageBox.Show("创建数据库失败！");
                return;
            }

            BindGrid();
        }

        /// <summary>
        /// 绑定到DataGridView
        /// </summary>
        private void BindGrid()
        {
            dgvMain.DataSource = _SlOp.GetGameDocList();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                FrmRename frm = new FrmRename(file);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(frm.NewFileName))
                    {
                        lbxMsg.Items.Insert(0, DateTime.Now + " " + "新名称为空！");
                        continue;
                    }
                    FileInfo fi = new FileInfo(file);
                    if (fi.Name.Trim().ToUpper() == frm.NewFileName.Trim().ToUpper())
                    {
                        lbxMsg.Items.Insert(0, DateTime.Now + " " + "新名称与旧名称相同！");
                        continue;
                    }
                    //添加到数据库
                    Add(file, frm.NewFileName);
                    //重命名                     
                    File.Move(file, fi.FullName.Replace(fi.Name, "") + frm.NewFileName);
                    lbxMsg.Items.Insert(0, DateTime.Now + " " + string.Format("重命名完成！{0} >> {1}", fi.Name, frm.NewFileName));
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 添加处理
        /// </summary>
        /// <param name="fodFullName"></param>
        private void Add(string fodFullName, string newName)
        {
            //检查是否包含在特殊目录中
            bool bContainSpec = false;
            string specDirName = string.Empty;
            string outputPath = string.Empty;

            _SpecOp.ContainSpecDir(fodFullName, out bContainSpec, out specDirName, out outputPath);

            try
            {
                if (_SlOp.ExistsItem(outputPath, bContainSpec, specDirName))
                {
                    lbxMsg.Items.Insert(0, DateTime.Now + " " + "这个已在列表！" + fodFullName);
                }
                else
                {
                    _SlOp.InsertGameDoc(Guid.NewGuid().ToString(), outputPath, bContainSpec, specDirName, newName);
                    BindGrid();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void dgvMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvMain.Rows.Count == 0) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("确定删除当前行？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string mainId = dgvMain.CurrentRow.Cells["colMainId"].Value.ToString();
                    _SlOp.DeleteGameDoc(mainId);
                    dgvMain.Rows.Remove(dgvMain.CurrentRow);
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                string strBool = dgvr.Cells["colisspec"].Value.ToString();
                string fullPath = dgvr.Cells["colpath"].Value.ToString();
                string specDirName = dgvr.Cells["colspecname"].Value.ToString();
                string newName = dgvr.Cells["colnewname"].Value.ToString();
                if (strBool.ToLower() == "true")
                {
                    fullPath = _SpecOp.GetSpecDirValue(specDirName) + fullPath;
                }
                
                if (File.Exists(fullPath))
                {
                    FileInfo fi = new FileInfo(fullPath);
                    //重命名                     
                    File.Move(fullPath, fi.FullName.Replace(fi.Name, "") + newName);
                    lbxMsg.Items.Insert(0, DateTime.Now + " " + string.Format("重命名完成！{0} >> {1}", fi.Name, newName));
                }
                else
                {
                    lbxMsg.Items.Insert(0, DateTime.Now + " " + string.Format("文件不存在！{0} ", fullPath));
                }
            }
        }
    }
}
