using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace K杀进程
{
    public partial class Form1 : Form
    {

        private string dataFileFullPath = Path.Combine(Application.StartupPath, "ListData.txt");

        string KillOnLoadFull = "KillOnLoad.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            #region 加入启动文件夹
            SetToStartDir();

            #endregion

            tmrCheck.Enabled = true;
            tmrExit.Enabled = true;

            #region read data
            if (File.Exists(dataFileFullPath))
            {

                StreamReader sr = new StreamReader(dataFileFullPath);
                try
                {
                    while (sr.Peek() >= 0)
                    {
                        string procName = sr.ReadLine();
                        if (string.IsNullOrEmpty(procName) || string.IsNullOrEmpty(procName.Trim())) continue;
                        dgvProcs.Rows.Add(procName);
                    }


                    if (File.Exists(KillOnLoadFull))
                    {
                        cbxKillOnLoad.Checked = true;
                        Kill();
                    }
                }
                catch (Exception ex)
                {
                    lbxLog.Items.Insert(0, ex.Message);
                }
                finally
                {
                    sr.Close();
                }
            }
            #endregion
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string procName = txtProcName.Text.Trim();
            if (string.IsNullOrEmpty(procName))
            {
                MessageBox.Show("名称不能为空！");
                return;
            }
            dgvProcs.Rows.Add(procName);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvProcs.Rows.Count == 0) return;
            dgvProcs.Rows.RemoveAt(dgvProcs.CurrentRow.Index);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region save data

            StreamWriter sw = new StreamWriter(dataFileFullPath);
            try
            {
                foreach (DataGridViewRow dgvr in dgvProcs.Rows)
                {
                    string procName = dgvr.Cells["colProcNames"].Value.ToString();
                    if (string.IsNullOrEmpty(procName) || string.IsNullOrEmpty(procName.Trim())) continue;

                    sw.WriteLine(procName);
                }

                if (cbxKillOnLoad.Checked)
                    File.CreateText(KillOnLoadFull);
                else
                    File.Delete(KillOnLoadFull);

            }
            catch (Exception ex)
            {
                lbxLog.Items.Insert(0, ex.Message);
            }
            finally
            {
                sw.Close();
            }
            #endregion
        }

        void Kill()
        {
            try
            {
                foreach (DataGridViewRow dgvr in dgvProcs.Rows)
                {
                    string procName = dgvr.Cells["colProcNames"].Value.ToString();
                    if (string.IsNullOrEmpty(procName) || string.IsNullOrEmpty(procName.Trim())) continue;

                    Process[] prcs = Process.GetProcesses();
                    foreach (Process p in prcs)
                    {
                        try
                        {
                            if (procName.ToUpper() == p.ProcessName.ToUpper())
                            {
                                lbxLog.Items.Insert(0, DateTime.Now.ToString() + "准备结束：" + p.ProcessName);
                                p.Kill();
                                lbxLog.Items.Insert(0, DateTime.Now.ToString() + "结束：" + p.ProcessName);
                            }
                        }
                        catch (Exception exp)
                        {
                            lbxLog.Items.Insert(0, exp.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbxLog.Items.Insert(0, ex.Message);
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            Kill();
        }

        bool checking = false;
        //如果DG的项在进程中
        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            if (!checking)
            {
                try
                {
                    checking = true;

                    foreach (DataGridViewRow dgvr in dgvProcs.Rows)
                    {
                        string procName = dgvr.Cells["colProcNames"].Value.ToString();
                        if (string.IsNullOrEmpty(procName) || string.IsNullOrEmpty(procName.Trim())) continue;

                        Process[] prcs = Process.GetProcesses();
                        bool inProc = false;
                        foreach (Process p in prcs)
                        {
                            if (procName.ToUpper() == p.ProcessName.ToUpper())
                            {
                                inProc = true;
                                break;
                            }
                        }
                        if (inProc)
                            dgvr.Cells["colProcNames"].Style.ForeColor = Color.Blue;
                        else
                            dgvr.Cells["colProcNames"].Style.ForeColor = Color.Black;

                    }
                }
                catch (Exception ex)
                {
                    lbxLog.Items.Insert(0, ex.Message);
                }
                finally
                {
                    checking = false;
                }
            }
        }

        private void txtProcName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd_Click(sender, e);
        }


        void SetToStartDir()
        {
            //C: \Users\jk\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
            // userprofile 只到 jk

            try
            {
                string abc = System.Environment.GetEnvironmentVariable("userprofile");
                string fulPath = Path.Combine(abc, @"AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup");
                string fFullName = Path.Combine(fulPath, "杀死进程.lnk");
                //MessageBox.Show(fFullName);


                 
                    IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                    IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(fFullName);
                    shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    shortcut.WorkingDirectory = System.Environment.CurrentDirectory;
                    //shortcut.Arguments = "参数";
                    //shortcut.Description = "我是快捷方式名字哦！";
                    //shortcut.Hotkey = "CTRL+SHIFT+N";
                    //shortcut.IconLocation = "notepad.exe, 0";
                    shortcut.Save();
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建快捷方式时出错");
            }
        }

        #region 程序启动几秒后退出
        int exitCnt = 0;
        int exitTrg = 6;
        bool cancelExitOnStart = false;
        private void tmrExit_Tick(object sender, EventArgs e)
        {
            if (cancelExitOnStart)
            {
                tmrExit.Enabled = false;
                return;
            }

            exitCnt += 1;
            string msg = DateTime.Now.ToString() + string.Format("程序将在{0}秒后退出，按ESC键取消", exitTrg- exitCnt);
            lbxLog.Items.Insert(0, msg);
            if (exitCnt >= exitTrg)
            {
                Application.Exit();
            }
        }
        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cancelExitOnStart = true;
                string msg = DateTime.Now.ToString() + string.Format(" 已取消退出" );
                lbxLog.Items.Insert(0, msg);
            }
        }
    }
}
