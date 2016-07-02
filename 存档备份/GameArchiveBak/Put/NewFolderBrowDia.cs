using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace UsualLib
{
    //项目要引用 System.Design.dll

    /// <summary>
    /// Winform 类似于WINDOWS的选择文件夹对话框
    /// </summary>
    public class NewFolderBrowDia : FolderNameEditor
    {
        FolderNameEditor.FolderBrowser fDialog = new FolderBrowser();

        public NewFolderBrowDia()
        { }

        /// <summary>
        /// 弹出选择
        /// </summary>
        /// <returns></returns>
        public DialogResult DisplayDialog()
        {
            return DisplayDialog("请选择一个文件夹");
        }


        public DialogResult DisplayDialog(string description)
        {
            fDialog.Description = description;
            fDialog.Style = FolderBrowserStyles.ShowTextBox;
            return fDialog.ShowDialog();
        }

        /// <summary>
        /// 是否显示可输入地址文本框
        /// </summary>
        public bool ShowTextBox
        {
            get
            {
                if (fDialog.Style == FolderBrowserStyles.ShowTextBox)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    fDialog.Style = FolderBrowserStyles.ShowTextBox;
                }
            }
        }

        /// <summary>
        /// 获取选择的路径
        /// </summary>
        public string Path
        {
            get
            {
                return fDialog.DirectoryPath;
            }
        }
    }
}
