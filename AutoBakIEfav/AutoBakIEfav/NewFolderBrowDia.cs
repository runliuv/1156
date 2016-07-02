using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AutoBakIEfav
{
    //项目要引用 System.Design.dll

    /// <summary>
    /// Winform 类似于WINDOWS的选择文件夹对话框
    /// </summary>
    class NewFolderBrowDia : FolderNameEditor
    {
        FolderNameEditor.FolderBrowser fDialog = new FolderBrowser();

        public NewFolderBrowDia()
        { }

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


        public string Path
        {
            get
            {
                return fDialog.DirectoryPath;
            }
        }
    }
}
