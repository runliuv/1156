using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ViewDirSize
{
    public partial class Form1 : Form
    {
        #region 变量

        DataTable DtView = null;

        Thread ThdView = null;

        delegate void DLG_ToGrid();
        DLG_ToGrid INS_ToGrid;

        delegate void DLG_ShowMsg(string strMsg);
        DLG_ShowMsg INS_ShowMsg;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            DtView = new DataTable("DirView");
            DtView.Columns.Add("DirName");
            DtView.Columns.Add("DirSize", typeof(decimal));
            DtView.Columns.Add("DirPer", typeof(decimal));

            INS_ToGrid = new DLG_ToGrid(ToGrid);
            INS_ShowMsg = new DLG_ShowMsg(ShowMsg);

            txtViewDir.Text = @"D:\Projects";

            pbDirPer.Value = 100;
        }

        private void ShowMsg(string strMsg)
        {
            lblMsg.Text = "正在检索：" + strMsg;
        }

        private void txtViewDir_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnView_Click(null, null);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtViewDir.Text))
            {
                MessageBox.Show("路径不存在。");
                return;
            }

            if (txtViewDir.Text.Trim().EndsWith(@":"))
                txtViewDir.Text = txtViewDir.Text + @"\";

            pnlMain.Controls.Clear();
            DtView.Rows.Clear();
            DtView.AcceptChanges();

            ThdView = new Thread(new ThreadStart(GetIt));
            ThdView.Start();

        }

        private void GetIt()
        {
            DirectoryInfo diTar = new DirectoryInfo(txtViewDir.Text);
            DirectoryInfo[] dis = diTar.GetDirectories();
            //目录大小
            foreach (DirectoryInfo di in dis)
            {
                long lDirSize = 0;

                BeginInvoke(INS_ShowMsg, di.FullName);
                lDirSize = GetDirectoryLength(di.FullName);

                DataRow drNew = DtView.NewRow();
                drNew["DirName"] = di.Name;
                // MB
                drNew["DirSize"] = (decimal)lDirSize / 1024 / 1024;

                DtView.Rows.Add(drNew);
            }



            //文件大小
            FileInfo[] fis = diTar.GetFiles();
            DataRow drSp = null;
            if (fis.Length > 0)
            {
                //分割
                drSp = DtView.NewRow();
                drSp["DirName"] = "-----------------------------";
                drSp["DirSize"] = 0;
                DtView.Rows.Add(drSp);
            }
            foreach (FileInfo fi in fis)
            {
                try
                {
                    long lDirSize = fi.Length;
                    BeginInvoke(INS_ShowMsg, fi.FullName);

                    DataRow drNew = DtView.NewRow();
                    drNew["DirName"] = fi.Name;
                    // MB
                    drNew["DirSize"] = (decimal)lDirSize / 1024 / 1024;

                    DtView.Rows.Add(drNew);
                }
                catch { }
            }

            //分割 
            if (fis.Length > 0)
            {
                drSp = DtView.NewRow();
                drSp["DirName"] = "-----------------------------";
                drSp["DirSize"] = 0;
                DtView.Rows.Add(drSp);
            }

            decimal dMax = DtView.AsEnumerable().Max(p => p.Field<decimal>("DirSize"));
            foreach (DataRow dr in DtView.Rows)
            {
                decimal dCurr = decimal.Parse(dr["DirSize"].ToString());
                dr["DirPer"] = decimal.Parse(((dCurr / dMax) * 100).ToString("N0"));

            }

            BeginInvoke(INS_ToGrid);
        }



        private void ToGrid()
        {
            lblMsg.Text = string.Empty;

            //控件 Y轴 递增量
            int cy = 14;
            //控件1，2，3 的x,y
            int c1x = lblDirName.Location.X, c1y = lblDirName.Location.Y;
            int c2x = lblDirSize.Location.X, c2y = lblDirSize.Location.Y;
            int c3x = pbDirPer.Location.X, c3y = pbDirPer.Location.Y;

            foreach (DataRow dr in DtView.Rows)
            {
                c1y += cy;
                c2y += cy;
                c3y += cy;

                Label lblName = new Label();
                lblName.Size = new Size(260, 12);
                lblName.Location = new Point(c1x, c1y);
                lblName.Text = dr["DirName"].ToString();

                Label lblSize = new Label();
                lblSize.Size = new Size(260, 12);
                lblSize.Location = new Point(c2x, c2y);
                lblSize.TextAlign = ContentAlignment.TopRight;
                decimal dMB = decimal.Parse(dr["DirSize"].ToString());
                decimal dGB = dMB / 1024M;
                lblSize.Text = dMB.ToString("N2") + " MB (" + dGB.ToString("N2") + " GB)";

                ProgressBar pbPer = new ProgressBar();
                pbPer.Size = new Size(pbDirPer.Size.Width, pbDirPer.Size.Height);
                pbPer.Location = new Point(c3x, c3y);
                pbPer.Value = int.Parse(dr["DirPer"].ToString());

                pnlMain.Controls.Add(lblName);
                pnlMain.Controls.Add(lblSize);
                pnlMain.Controls.Add(pbPer);
            }

        }

        public long GetDirectoryLength(string dirPath)
        {
            //判断给定的路径是否存在,如果不存在则退出
            if (!Directory.Exists(dirPath))
                return 0;

            long len = 0;

            //定义一个DirectoryInfo对象

            DirectoryInfo di = new DirectoryInfo(dirPath);

            //通过GetFiles方法,获取di目录中的所有文件的大小 　
            try
            {
                FileInfo[] fis = di.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    len += fi.Length;
                }


                //获取di中所有的文件夹,并存到一个新的对象数组中,以进行递归
                DirectoryInfo[] dis = di.GetDirectories();
                if (dis.Length > 0)
                {
                    for (int i = 0; i < dis.Length; i++)
                    {
                        len += GetDirectoryLength(dis[i].FullName);
                    }
                }

            }
            catch (Exception exp) { }

            return len;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (ThdView != null)
                ThdView.Abort();
        }
    }
}
