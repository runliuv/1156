using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsualLib;

namespace TimeOut
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 每秒
        /// </summary>
        int timerCount = 0;

        private string regKey = "TimeOutForm";

        /// <summary>
        /// 点击关闭按钮时最小化到托盘
        /// </summary>
        private bool CloseToTray = false;
        /// <summary>
        /// 程序退出标识。
        /// </summary>
        private bool AppExit = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {  

            RemForm.ReadRememberForm(this, null);
            StartOnSysStart.CheckStartWhenWinStart(regKey);

            if (chkMinToTray.Checked)
            {
                this.Hide();
            }

            this.ShowInTaskbar = false;
            tmrToTip.Start();
        }

        private void btnToTray_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ninMain_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
        }

        private void tmrToTip_Tick(object sender, EventArgs e)
        {
            timerCount += 1;//秒

            //已进行
            lblM.Text = timerCount.ToString();
            lblF.Text = (timerCount / 60).ToString();

            decimal target =  nudCount.Value; //分钟
            if (target <  1)
            {
                target = 1;
                nudCount.Value = 1;
            }
            if (timerCount / 60m >= target)
            {
                timerCount = 0;
                string msg = "Time Out" + DateTime.Now.ToString();
                ninMain.ShowBalloonTip(12, "Time Out", msg, ToolTipIcon.Info);

                if (chkLeftShow.Checked)
                {
                    FrmShowTip frm = new FrmShowTip();
                    frm.Show();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemForm.RememberForm(this, null);
            if (CloseToTray && !AppExit)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timerCount = 0;
        }

        private void chkOnSysStart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnSysStart.Checked)
            {
                StartOnSysStart.RegAutoStart(regKey);
            }
            else
            {
                StartOnSysStart.UnRegAutoStart(regKey);
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            AppExit = true;
            Application.Exit();
        }

        private void chkClosetToTray_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClosetToTray.Checked)
                CloseToTray = true;
            else
                CloseToTray = false;
        }
    }
}
