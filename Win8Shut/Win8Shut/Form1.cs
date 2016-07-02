using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using UsualLib;
using System.Diagnostics;
using System.IO;

namespace Win8Shut
{
    public partial class Form1 : Form
    {
        #region user32
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, // handle to window    
         int id,            // hot key identifier    
         KeyModifiers fsModifiers,  // key-modifier options    
         Keys vk            // virtual-key code    
         );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd,  // handle to window    
         int id      // hot key identifier    
         );

        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        /// <summary>
        /// 控制音量
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 关机HOT KEY ID
        /// </summary>
        const int hotKeyId_Shut = 339;

        /// <summary>
        /// 重启
        /// </summary>
        const int hotKeyId_Reset = 202;

        private string regKey = "Win8ShutForm";
        /// <summary>
        /// 正在加载
        /// </summary>
        bool formLoading = false;
        /// <summary>
        /// 音量 +
        /// </summary>
        const int hotKeyId_VolUp = 340;
        /// <summary>
        /// 音量 -
        /// </summary>
        const int hotKeyId_VolDown = 341;
        const int hotKeyId_VolMute = 342;
        /// <summary>
        /// 切换输入法
        /// </summary>
        const int hotKeyId_SwitchIME = 343;



        //private Process p;
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0x0a0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x090000;
        private const int WM_APPCOMMAND = 0x319;

        /// <summary>
        /// 发送WIN+空格
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            formLoading = true;
            try
            {
                //lblRegStatus.Text = string.Empty;
                //程序启动时注册全局快捷键
                bool bSucc = RegisterHotKey(Handle, hotKeyId_Shut, KeyModifiers.Windows | KeyModifiers.Alt, Keys.Z);
                if (bSucc)
                    ToListBox("关机 快捷键注册成功。");
                else
                    ToListBox("关机 快捷键注册失败。");
                bSucc = RegisterHotKey(Handle, hotKeyId_Reset, KeyModifiers.Windows | KeyModifiers.Alt, Keys.X);
                if (bSucc)
                    ToListBox("重启 快捷键注册成功。");
                else
                    ToListBox("重启 快捷键注册失败。");

                bSucc = RegisterHotKey(Handle, hotKeyId_VolUp, KeyModifiers.Windows, Keys.F12);
                if (bSucc)
                    ToListBox("音量+ 快捷键注册成功。");
                else
                    ToListBox("音量+ 快捷键注册失败。");

                bSucc = RegisterHotKey(Handle, hotKeyId_VolDown, KeyModifiers.Windows, Keys.F11);
                if (bSucc)
                    ToListBox("音量- 快捷键注册成功。");
                else
                    ToListBox("音量- 快捷键注册失败。");

                bSucc = RegisterHotKey(Handle, hotKeyId_VolMute, KeyModifiers.Windows, Keys.F10);
                if (bSucc)
                    ToListBox("音量静音 快捷键注册成功。");
                else
                    ToListBox("音量静音 快捷键注册失败。");

                //只在WIN8以上版本注册此功能
                Version win7ver = new Version("6.1.9999.9999");
                if (Environment.OSVersion.Version.CompareTo(win7ver) > 0)
                {
                    //ctrl+空格切换输入法
                    bSucc = RegisterHotKey(Handle, hotKeyId_SwitchIME, KeyModifiers.Control, Keys.Space);
                    if (bSucc)
                        ToListBox("ctrl+空格切换输入法 快捷键注册成功。");
                    else
                        ToListBox("ctrl+空格切换输入法 快捷键注册失败。");
                }

                RemForm.ReadRememberForm(this, null);

                //每次启动时加入开机启动
                StartOnSysStart.RegAutoStart(regKey);
                //SetToStartDir("WIN8快捷关机");

                if (chkHideOnStart.Checked)
                {
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formLoading = false;
            }
        }

        void ToListBox(string msg)
        {
            string fmsg = DateTime.Now.ToString("HH:mm:ss.fff") + " " + msg;
            lbx1.Items.Insert(0, fmsg);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭时解除注册
            UnregisterHotKey(Handle, hotKeyId_Shut);
            UnregisterHotKey(Handle, hotKeyId_Reset);

            UnregisterHotKey(Handle, hotKeyId_VolUp);
            UnregisterHotKey(Handle, hotKeyId_VolDown);
            UnregisterHotKey(Handle, hotKeyId_VolUp);

            UnregisterHotKey(Handle, hotKeyId_SwitchIME);
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                //固定的热键消息 0x0312
                const int WM_HOTKEY = 0x0312;
                switch (m.Msg)
                {
                    case WM_HOTKEY:
                        #region 判断哪个功能

                        switch (m.WParam.ToInt32())
                        {
                            case hotKeyId_Shut:
                                if (cbxShutConfirm.Checked)
                                {
                                    if (MessageBox.Show("确定关机？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        Process.Start("shutdown", " /s /f /t 0");
                                    }
                                }
                                else
                                {
                                    Process.Start("shutdown", " /s /f /t 0");
                                }
                                break;
                            case hotKeyId_Reset:
                                if (cbxShutConfirm.Checked)
                                {
                                    if (MessageBox.Show("确定重启？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        Process.Start("shutdown", " /r /f /t 0");
                                    }
                                }
                                else
                                {
                                    Process.Start("shutdown", " /r /f /t 0");
                                }
                                break;
                            case hotKeyId_VolUp:
                                //p = Process.GetCurrentProcess();
                                //SendMessageW(p.Handle, WM_APPCOMMAND, p.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
                                SendMessageW(Handle, WM_APPCOMMAND, Handle, (IntPtr)APPCOMMAND_VOLUME_UP);

                                break;
                            case hotKeyId_VolDown:
                                //p = Process.GetCurrentProcess();
                                //SendMessageW(p.Handle, WM_APPCOMMAND, p.Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
                                SendMessageW(Handle, WM_APPCOMMAND, Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
                                break;
                            case hotKeyId_VolMute:
                                //p = Process.GetCurrentProcess();
                                //SendMessageW(p.Handle, WM_APPCOMMAND, p.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
                                SendMessageW(Handle, WM_APPCOMMAND, Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
                                break;
                            case hotKeyId_SwitchIME:
                                const byte VK_LWIN = 0x5B;
                                const byte VK_space = 0x20;
                                const byte KEYEVENTF_KEYUP = 0x2; //弹起
                                const byte KEYEVENTF_EXTENDEDKEY = 0x1; //按下
                                keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, 0);
                                keybd_event(VK_space, 0, KEYEVENTF_EXTENDEDKEY, 0);
                                keybd_event(VK_space, 0, KEYEVENTF_KEYUP, 0);
                                keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);
                                break;
                        }

                        #endregion
                        break;
                }
                base.WndProc(ref m);
            }
            catch { }
        }



        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void tsmiShow_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //版本
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("VER:15.9.20");
            }
        }



        private void cbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!formLoading)
            {
                RemForm.RememberForm(this, null);
            }
        }

        void SetToStartDir(string lnkName)
        {
            //C: \Users\jk\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
            // userprofile 只到 jk

            try
            {
                string abc = System.Environment.GetEnvironmentVariable("userprofile");
                string fulPath = Path.Combine(abc, @"AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup");
                string lnkN = lnkName + ".lnk";
                string fFullName = Path.Combine(fulPath, lnkN);
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
    }
}
