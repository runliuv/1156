using System;

using System.IO;
using System.Windows.Forms;

namespace UsualLib
{
    public class UDirCopy
    {
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sFrom"></param>
        /// <param name="sTo"></param>
        public static void DirCopy(string sFrom, string sTo, bool showMsg)
        {
            DirectoryInfo diSou;
            DirectoryInfo diTar;
            try
            {
                diSou = new DirectoryInfo(sFrom);
                diTar = new DirectoryInfo(sTo);
            }
            catch (Exception exp)
            {
                if (showMsg)
                    MessageBox.Show("源目录 或 目标目录 不正确！" + exp.Message);
                return;
            }

            FileSystemInfo[] fsisSou;
            try
            {
                fsisSou = diSou.GetFileSystemInfos();
            }
            catch (Exception exp)
            {
                if (showMsg)
                    MessageBox.Show("获取文件和文件夹信息时出错！" + exp.Message);
                return;
            }

            foreach (FileSystemInfo fsi in fsisSou)
            {
                if (fsi is DirectoryInfo)
                {
                    string tarDirFullName = diTar.FullName + @"\" + fsi.Name;
                    if (!Directory.Exists(tarDirFullName))
                    {
                        try
                        {
                            Directory.CreateDirectory(tarDirFullName);
                        }
                        catch (Exception exp)
                        {
                            if (showMsg)
                                MessageBox.Show("创建文件夹失败！" + exp.Message);
                            return;
                        }
                    }

                    if (Directory.Exists(tarDirFullName))
                    {
                        DirCopy(fsi.FullName, tarDirFullName, showMsg);
                    }
                }
                else if (fsi is FileInfo)
                {
                    string tarFileFullName = diTar.FullName + @"\" + fsi.Name;
                    try
                    {
                        File.Copy(fsi.FullName, tarFileFullName, true);
                    }
                    catch (Exception exp)
                    {
                        if (showMsg)
                            MessageBox.Show("复制文件失败！" + exp.Message);
                        return;
                    }
                }
            }
        }
    }
}
