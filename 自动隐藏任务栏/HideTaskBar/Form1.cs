using System;
using System.Diagnostics;
using System.Windows.Forms;
using UsualLib;
using System.Data;

namespace HideTaskBar
{
    public partial class Form1 : Form
    {
        #region var
        /// <summary>
        /// 为TRUE则正在处理。
        /// </summary>
        private bool _handling = false;

        OpTaskBar _OpTB = new OpTaskBar();

        DataTable dtProcs = new DataTable();

        DataTable dtMain = new DataTable();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtProcs.Columns.Add("proc_name");
            FindProcs();
            dgvProcs.AutoGenerateColumns = false;
            dgvProcs.DataSource = dtProcs;

            dtMain.Columns.Add("colName");
            dtMain.Columns.Add("colMatch");
            DataRow dr = dtMain.NewRow();
            dr["colName"] = "dota";
            dr["colMatch"] = "m";
            dtMain.Rows.Add(dr);

            dr = dtMain.NewRow();
            dr["colName"] = "Torchlight2";
            dr["colMatch"] = "m";
            dtMain.Rows.Add(dr);

            dgvMain.AutoGenerateColumns = false;

            dgvMain.DataSource = dtMain;

            tmHideBar.Start();
        }

         

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
                return;

            dgvMain.Rows.RemoveAt(dgvMain.CurrentRow.Index);
        }

        private void tmHideBar_Tick(object sender, EventArgs e)
        {
            FindProcs();

            //勾选才处理
            if (!cbxWork.Checked)
                return;

            //若正在处理中，返回
            if (_handling)
                return;

            try
            {
                _handling = true;

                //是否找到符合的进程
                bool bFound = false;
                Process[] pps = System.Diagnostics.Process.GetProcesses();
                foreach (Process pc in pps)
                {
                    foreach (DataGridViewRow dgvr in dgvMain.Rows)
                    {
                        string strMatch = dgvr.Cells["colMatch"].Value.ToString().ToLower();
                        string strName = dgvr.Cells["colName"].Value.ToString().ToUpper();

                        if ((strMatch == "m" && pc.ProcessName.ToUpper() == strName)
                            || (strMatch == "c" && pc.ProcessName.ToUpper().Contains(strName)))
                        {
                            bFound = true;
                            break;
                        }
                    }
                    if (bFound)
                        break;
                }

                if (bFound)
                {
                    //找到就自动隐藏
                    UsualLib.OpTaskBar.AppBarStates abs = _OpTB.GetTaskbarState(); //当前状态
                    if (abs != UsualLib.OpTaskBar.AppBarStates.AutoHide)
                        _OpTB.SetTaskbarState(OpTaskBar.AppBarStates.AutoHide);
                }
                else
                {
                    //未找到，若是自动隐藏状态，设置为正常状态
                    UsualLib.OpTaskBar.AppBarStates abs = _OpTB.GetTaskbarState(); //当前状态
                    if (abs == UsualLib.OpTaskBar.AppBarStates.AutoHide)
                        _OpTB.SetTaskbarState(OpTaskBar.AppBarStates.AlwaysOnTop);
                }
            }
            catch (Exception exp)
            {
                tmHideBar.Stop();
                MessageBox.Show(exp.Message);
            }
            finally
            {
                _handling = false;
            }
        }

        void FindProcs()
        {
            Process[] pps = System.Diagnostics.Process.GetProcesses();
            foreach (Process pc in pps)
            {
                DataRow[] drsFind = dtProcs.Select(string.Format("proc_name='{0}'", pc.ProcessName));
                if (drsFind == null || drsFind.Length == 0)
                {
                    DataRow dr = dtProcs.NewRow();
                    dr["proc_name"] = pc.ProcessName;
                    dtProcs.Rows.Add(dr);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _OpTB.SetTaskbarState(OpTaskBar.AppBarStates.AlwaysOnTop);
            }
            catch (Exception exp)
            { }
        }

        private void cbxWork_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxWork.Checked)
                tmHideBar.Interval = (int)(nudInterval.Value * 1000);
            else
            {
                //若是自动隐藏状态，设置为正常状态
                UsualLib.OpTaskBar.AppBarStates abs = _OpTB.GetTaskbarState(); //当前状态
                if (abs == UsualLib.OpTaskBar.AppBarStates.AutoHide)
                    _OpTB.SetTaskbarState(OpTaskBar.AppBarStates.AlwaysOnTop);
            }
        }

        private void btnShowBar_Click(object sender, EventArgs e)
        {
            try
            {
                _OpTB.SetTaskbarState(OpTaskBar.AppBarStates.AlwaysOnTop);
            }
            catch (Exception exp)
            { }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                MessageBox.Show(Application.CompanyName);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvProcs_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string procName = dgvProcs.Rows[e.RowIndex].Cells["proc_name"].Value.ToString();
                DataRow dr = dtMain.NewRow();
                dr["colName"] = procName;
                dr["colMatch"] = "m";
                dtMain.Rows.Add(dr);
            }
        }

        private void dgvMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dtMain.DefaultView.Table.Rows.RemoveAt(e.RowIndex);
                dtMain.AcceptChanges();
            }
        }


    }
}
