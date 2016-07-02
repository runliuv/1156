using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace 全局快捷键设置
{
    public partial class Form1 : Form
    {
        #region 变量

        /// <summary>
        /// 关机快捷键ID
        /// </summary>
        private UInt32 hotKeyId_Shut = 0x3400;

        /// <summary>
        /// 关机快捷键ID
        /// </summary>
        private UInt32 hotKeyId_Reset = 0x3401;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegKeys();
        }

        private bool ValidateReg()
        {
            UInt32 uShutMF = 0;
            if (cbShutCtrl.Checked && cbShutAlt.Checked)
            {
                uShutMF = (UInt32)KeyModifiers.Control | (UInt32)KeyModifiers.Alt;
            }
            else if (cbShutCtrl.Checked)
            {
                uShutMF = (UInt32)KeyModifiers.Control;
            }
            else if (cbShutAlt.Checked)
            {
                uShutMF = (UInt32)KeyModifiers.Alt;
            }
            else
            {
                lblHello.Text = "没有指定关机快捷键 ！" + DateTime.Now.ToString();
                return false;
            }

            UInt32 uResetKM = 0;
            if (cbResetCtrl.Checked && cbResetAlt.Checked)
            {
                uResetKM = (UInt32)KeyModifiers.Control | (UInt32)KeyModifiers.Alt;
            }
            else if (cbResetCtrl.Checked)
            {
                uResetKM = (UInt32)KeyModifiers.Control;
            }
            else if (cbResetAlt.Checked)
            {
                uResetKM = (UInt32)KeyModifiers.Alt;
            }
            else
            {
                lblHello.Text = "没有指定重启快捷键 ！" + DateTime.Now.ToString();
                return false;
            }

            if (uShutMF == uResetKM)
            {
                lblHello.Text = "两个功能的快捷键相同，不能注册！" + DateTime.Now.ToString();
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 注册快捷键
        /// </summary>
        private void RegKeys()
        {
            #region 关机
            UInt32 uShutMF = 0;
            if (cbShutCtrl.Checked && cbShutAlt.Checked)
            {
                uShutMF = (UInt32)KeyModifiers.Control | (UInt32)KeyModifiers.Alt;
            }
            else if (cbShutCtrl.Checked)
            {
                uShutMF = (UInt32)KeyModifiers.Control;
            }
            else if (cbShutAlt.Checked)
            {
                uShutMF = (UInt32)KeyModifiers.Alt;
            }
            //注册热键   
            WA.RegisterHotKey(this.Handle, hotKeyId_Shut, uShutMF, (UInt32)Keys.CapsLock);
            #endregion

            #region 重启
            UInt32 uResetKM = 0;
            if (cbResetCtrl.Checked && cbResetAlt.Checked)
            {
                uResetKM = (UInt32)KeyModifiers.Control | (UInt32)KeyModifiers.Alt;
            }
            else if (cbResetCtrl.Checked)
            {
                uResetKM = (UInt32)KeyModifiers.Control;
            }
            else if (cbResetAlt.Checked)
            {
                uResetKM = (UInt32)KeyModifiers.Alt;
            }
            //注册热键   
            WA.RegisterHotKey(this.Handle, hotKeyId_Reset, uResetKM, (UInt32)Keys.CapsLock);
            #endregion
        }

        /// <summary>
        /// 取消注册快捷键
        /// </summary>
        private void UnRegKeys()
        {
            WA.UnregisterHotKey(this.Handle, hotKeyId_Shut);
        }

        /// <summary>
        /// 处理消息事件
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref   Message m)
        {
            const int WM_HOTKEY = 0x0312;

            switch (m.Msg)
            {
                case WM_HOTKEY:
                    if (m.WParam.ToInt32() == hotKeyId_Shut)
                    {
                        //热键事件
                        HotKeyToShut();
                    }
                    if (m.WParam.ToInt32() == hotKeyId_Reset)
                    {
                        //热键事件
                        HotKeyToReset();
                    }
                    base.WndProc(ref   m);
                    break;
                default:
                    base.WndProc(ref   m);
                    break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnRegKeys();
        }

        /// <summary>
        /// 关机
        /// </summary>
        private void HotKeyToShut()
        {
            if (DialogResult.Yes == MessageBox.Show("确定关机？", "power off computer", MessageBoxButtons.YesNo))
            {
                Process.Start("shutdown.exe"," -s -f -t 0");
            }
        }

        /// <summary>
        /// 重启
        /// </summary>
        private void HotKeyToReset()
        {
            if (DialogResult.Yes == MessageBox.Show("确定重启？", "reset computer", MessageBoxButtons.YesNo))
            {
                Process.Start("shutdown.exe", " -r -f -t 0");
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            if (!ValidateReg())
            {
                

                return;
            }

            UnRegKeys();
            RegKeys();

            lblHello.Text = "注册完成。" + DateTime.Now.ToString() ;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
             
             
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
             
             
        }
    }
}
