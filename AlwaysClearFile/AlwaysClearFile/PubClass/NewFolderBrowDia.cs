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

        /// <summary>
        /// 默认显示“"请选择一个文件夹”
        /// </summary>
        public string ShowMsg { get; set; }

        public NewFolderBrowDia()
        {
            ShowMsg = "请选择一个文件夹";
            fDialog.Style = FolderBrowserStyles.ShowTextBox;
        }

        /// <summary>
        /// 弹出选择
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog()
        {
            return ShowDialog(ShowMsg);
        }


        public DialogResult ShowDialog(string description)
        {
            fDialog.Description = description;
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
                    return true;
                else
                    return false;
            }

            set
            {
                if (value)
                    fDialog.Style = FolderBrowserStyles.ShowTextBox;
                else
                    fDialog.Style = FolderBrowserStyles.BrowseForEverything;
            }
        }

        /// <summary>
        /// 获取选择的路径
        /// </summary>
        public string SelectedPath
        {
            get
            {
                return fDialog.DirectoryPath;
            }
        }
    }
}
