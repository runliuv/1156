using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UsualLib;

namespace AlwaysClearFile
{
    public partial class Form1 : Form
    {
        #region var

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
            dbFullName = exePath + "ClearItems.db";

            //检查数据库
            //检查数据库
            _SlOp = new SqliteOper(dbFullName);
            if (!_SlOp.CheckDb())
            {
                MessageBox.Show("创建数据库失败！");
                gbxOp.Enabled = false;
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



        /// <summary>
        /// 添加处理
        /// </summary>
        /// <param name="fodFullName"></param>
        private void Add(string fodFullName)
        {
            //检查是否包含在特殊目录中
            bool bContainSpec = false;
            string specDirName = string.Empty;
            string outputPath = string.Empty;

            _SpecOp.ContainSpecDir(fodFullName, out bContainSpec, out specDirName, out outputPath);

            try
            {
                if (_SlOp.ExistsItem(outputPath, bContainSpec, specDirName))
                    lblStatus.Text = "这个已在列表:" + fodFullName;
                else
                {
                    _SlOp.InsertGameDoc(Guid.NewGuid().ToString(), outputPath, bContainSpec, specDirName);
                    BindGrid();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }



        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
            {
                lblStatus.Text = "没有任何项";
                return;
            }

            string editId = dgvMain.CurrentRow.Cells["Col_MainId"].Value.ToString();
            try
            {
                _SlOp.DeleteGameDoc(editId);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            BindGrid();

            lblStatus.Text = DateTime.Now.ToString() + "；删除完成。";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
            {
                lblStatus.Text = "没有任何项";
                return;
            }

            if (MessageBox.Show("确定要清理吗？", "清理", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                string strBool = dgvr.Cells["Col_IncludeSpecDir"].Value.ToString();
                string fullPath = dgvr.Cells["Col_FullPath"].Value.ToString();
                string specDirName = dgvr.Cells["Col_SpecDirName"].Value.ToString();
                if (strBool.ToLower() == "true")
                {
                    fullPath = _SpecOp.GetSpecDirValue(specDirName) + fullPath;
                }

                if (File.Exists(fullPath))
                    File.Delete(fullPath);

                if (Directory.Exists(fullPath))
                    Directory.Delete(fullPath, true);


            }

            lblStatus.Text = DateTime.Now.ToString() + "；清理完。";
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

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            for (int i = 0; i < s.Length; i++)
            {
                Add(s[i]);
            }
        }

    }
}
