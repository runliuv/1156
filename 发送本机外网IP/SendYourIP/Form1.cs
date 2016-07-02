using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using UsualLib;
using System.Threading;

namespace SendYourIP
{
    public partial class Form1 : Form
    {
        #region 变量

        /// <summary>
        /// 正文
        /// </summary>
        private string MailBody = string.Empty;
        /// <summary>
        /// 发送计数
        /// </summary>
        private int SendCount = 0;
        /// <summary>
        /// 检查IP更变计数
        /// </summary>
        int CheckIPChangeCount = 0;
        /// <summary>
        /// 表示正在加载,在Form Load 尾设置为true;
        /// </summary>
        private bool bFormLoading = true;

        private string startOnSysStartRegKey = "SendYourIP";
        /// <summary>
        /// 程序退出
        /// </summary>
        bool AppExit = false;

        /// <summary>
        /// 标题前缀
        /// </summary>
        string PreSubject = "我的外网IP：";

        /// <summary>
        /// IP变更
        /// </summary>
        bool IsIpChange = false;

        List<string> _notRem;

        System.Timers.Timer tmsTimer = new System.Timers.Timer();
        #endregion

        public Form1()
        {
            InitializeComponent();

            tmsTimer.Interval = 60 * 1000;
            tmsTimer.Elapsed += tmsTimer_Elapsed;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            _notRem = new List<string>();
            _notRem.Add(txtLog.Name);

            tmsTimer.Start();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            #region 初始值
            txtSenderAddr.Text = "runliuv@yeah.net";
            txtSenderUName.Text = "runliuv";
            txtSenderPwd.Text = "netboy2002";
            txtSMTP.Text = "smtp.yeah.net";
            txtMailTo.Text = "349255033@qq.com";
            #endregion

            RemForm.ReadRememberForm(this, _notRem);

            tmAutoSend.Start();

            //放在ReadRememberForm()之后
            if (UsualLib.StartOnSysStart.CheckStartWhenWinStart(startOnSysStartRegKey))
                cbxStartWhenWinStart.Checked = true;

            UsualLib.StartOnSysStart.UnRegAutoStart(startOnSysStartRegKey,false);//删除CURRENT USER中的启动项

            if (chkMinWhenStart.Checked)
                this.Hide();

            bFormLoading = false;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            GetAndSend();
        }

        /// <summary>
        /// 获取并发送IP
        /// </summary>
        private void GetAndSend()
        {
            try
            {
                MailBody = GetMyIP();

                if (string.IsNullOrEmpty(MailBody))
                {
                    WriteUIlog("没有获取到IP");
                    Logger.Log("没有获取到IP");
                }

                MailBody += "<br/>计算机名:" + GetIP.GetComputerName();

                if (!string.IsNullOrEmpty(txtContent.Text.Trim()))
                    MailBody += "<br/>" + txtContent.Text;

                string[] receivers = txtMailTo.Text.Split(';');

                foreach (string oj in receivers)
                {
                    if (string.IsNullOrEmpty(oj)) continue;

                    SendEmail(oj);

                    WriteUIlog("发送给：" + oj + " 完成。");
                }

                lblRst.Text = DateTime.Now.ToString() + "完成";

            }
            catch (Exception ex)
            {
                WriteUIlog(ex.Message);
                Logger.Log(ex.Message);
            }
        }

        /// <summary>
        /// 获取IP信息
        /// </summary>
        /// <returns></returns>
        private string GetMyIP()
        {
            string strAll = string.Empty;
            try
            {
                strAll += " Ip138 IP :" + GetIP.GetFromIp138();

                strAll += "  ChinaZ IP :" + GetIP.GetFromChinaZ();

                strAll += "  IpQQcom IP:" + GetIP.GetFromIpQQcom();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return strAll;
        }

        private void SendEmail(string mailToAddr)
        {
            try
            {
                using (MailMessage myMail = new MailMessage())
                {
                    string strSubj = string.Empty;
                    if (string.IsNullOrEmpty(txtTitle.Text))
                    {
                        strSubj += PreSubject;
                    }
                    else
                    {
                        strSubj += txtTitle.Text;
                    }
                    strSubj += " " + DateTime.Now.ToString("yyMMdd HH:mm");

                    if (IsIpChange)
                    {
                        IsIpChange = false;
                        strSubj += " IP变更";
                    }
                    myMail.From = new MailAddress(txtSenderAddr.Text);
                    myMail.To.Add(new MailAddress(mailToAddr));
                    myMail.Subject = strSubj;
                    myMail.SubjectEncoding = Encoding.UTF8;
                    myMail.Body = MailBody;
                    myMail.BodyEncoding = Encoding.UTF8;
                    myMail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = txtSMTP.Text;

                    smtp.Credentials = new NetworkCredential(txtSenderUName.Text, txtSenderPwd.Text);
                    smtp.Send(myMail);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void tmAutoSend_Tick(object sender, EventArgs e)
        {
            #region 定时发送
            //时间保护
            int protectInterval = 10;
            if (nudInterval.Value > protectInterval)
                protectInterval = (int)nudInterval.Value;

            SendCount += 1;
            if (SendCount >= protectInterval)
            {
                SendCount = 0;
                GetAndSend();
            }
            #endregion

            #region IP变更发送
            //若IP变更，立即发送。10秒检测
            CheckIPChangeCount += 1;
            if (CheckIPChangeCount >= nudCheck.Value)
            {
                CheckIPChangeCount = 0;
                string newestIP = string.Empty;
                try
                {
                    newestIP = GetMyIP();
                }
                catch (Exception expGetIp)
                {
                    WriteUIlog("检测变更时：" + expGetIp.Message);
                    Logger.Log("检测变更时：" + expGetIp.Message);
                }
                string lastIP = Logger.ReadLastIP();
                //新旧IP不能为空。
                if (!string.IsNullOrEmpty(lastIP) &&
                    !string.IsNullOrEmpty(newestIP) &&
                    newestIP != lastIP)
                {
                    IsIpChange = true;
                    GetAndSend();
                }
                //记录最后IP
                if (!string.IsNullOrEmpty(newestIP))
                    Logger.WriteLastIP(newestIP);
            }
            #endregion
        }

        public static bool IsEmail(string source)
        {
            return Regex.IsMatch(source, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", RegexOptions.IgnoreCase);
        }

        private void cbxStartWhenWinStart_CheckedChanged(object sender, EventArgs e)
        {
            if (!bFormLoading)
            {
                if (cbxStartWhenWinStart.Checked)
                {
                    UsualLib.StartOnSysStart.RegAutoStart(startOnSysStartRegKey);
                }
                else
                {
                    UsualLib.StartOnSysStart.UnRegAutoStart(startOnSysStartRegKey);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AppExit)
            {
                this.Hide();
                e.Cancel = true;
            }

            RemForm.RememberForm(this, _notRem);
        }

        void tmsTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RemForm.RememberForm(this, _notRem);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            AppExit = true;
            Application.Exit();
        }

        private void ninTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void tsmiExit2_Click(object sender, EventArgs e)
        {
            AppExit = true;
            Application.Exit();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2014.12.16");
        }

        #region 写界面日志
        private void WriteUIlog(string msg)
        {
            string newMsg = DateTime.Now.ToString("HH:mm:ss") + " " + msg;
            txtLog.Text = txtLog.Text + System.Environment.NewLine + newMsg;
        }
        #endregion
    }
}
