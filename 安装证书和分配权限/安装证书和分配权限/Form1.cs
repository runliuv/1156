using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace 安装证书和分配权限
{
    public partial class Form1 : Form
    {

        [DllImport("crypt32", CharSet = CharSet.Unicode, SetLastError = true)]
        public extern static bool CryptAcquireCertificatePrivateKey(IntPtr pCert, uint dwFlags, IntPtr pvReserved, ref IntPtr phCryptProv, ref int pdwKeySpec, ref bool pfCallerFreeProv);

        [DllImport("advapi32", CharSet = CharSet.Unicode, SetLastError = true)]
        public extern static bool CryptGetProvParam(IntPtr hCryptProv, CryptGetProvParamType dwParam, IntPtr pvData, ref int pcbData, uint dwFlags);

        [DllImport("advapi32", SetLastError = true)]
        public extern static bool CryptReleaseContext(IntPtr hProv, uint dwFlags);

        public enum CryptGetProvParamType
        {
            PP_ENUMALGS = 1,
            PP_ENUMCONTAINERS = 2,
            PP_IMPTYPE = 3,
            PP_NAME = 4,
            PP_VERSION = 5,
            PP_CONTAINER = 6,
            PP_CHANGE_PASSWORD = 7,
            PP_KEYSET_SEC_DESCR = 8,       // get/set security descriptor of keyset
            PP_CERTCHAIN = 9,      // for retrieving certificates from tokens
            PP_KEY_TYPE_SUBTYPE = 10,
            PP_PROVTYPE = 16,
            PP_KEYSTORAGE = 17,
            PP_APPLI_CERT = 18,
            PP_SYM_KEYSIZE = 19,
            PP_SESSION_KEYSIZE = 20,
            PP_UI_PROMPT = 21,
            PP_ENUMALGS_EX = 22,
            PP_ENUMMANDROOTS = 25,
            PP_ENUMELECTROOTS = 26,
            PP_KEYSET_TYPE = 27,
            PP_ADMIN_PIN = 31,
            PP_KEYEXCHANGE_PIN = 32,
            PP_SIGNATURE_PIN = 33,
            PP_SIG_KEYSIZE_INC = 34,
            PP_KEYX_KEYSIZE_INC = 35,
            PP_UNIQUE_CONTAINER = 36,
            PP_SGC_INFO = 37,
            PP_USE_HARDWARE_RNG = 38,
            PP_KEYSPEC = 39,
            PP_ENUMEX_SIGNING_PROT = 40,
            PP_CRYPT_COUNT_KEY_USE = 41,
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string cerpwd = "10010450";
            //string acount = "zm";
            try
            {
                //导入证书文件到类
                X509Certificate2 x509 = new X509Certificate2();
                byte[] rawData = ReadFile(txtPath.Text);
                x509.Import(rawData, txtCertPwd.Text, X509KeyStorageFlags.MachineKeySet);//X509KeyStorageFlags 安装后文件实际存储位置

                //安装证书,证书（本地计算机）-个人
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.MaxAllowed);
                store.Add(x509);
                store.Close();

                //得到证书实际存储文件名
                string fileName = GetKeyFileName(x509);
                //所在文件夹
                string fileDir = GetKeyFileDirectory(fileName);

                string fileFullName = Path.Combine(fileDir, fileName);

                //MessageBox.Show("证书名："+fileName+" 证书路径："+fileDir);
                MessageBox.Show("全路径：" + fileFullName);

                DialogResult dr = MessageBox.Show("是否分配权限？", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    //设置指定计算机用户的完全控制权限
                    AddFileSecurity(fileFullName, txtAccount.Text, FileSystemRights.FullControl, AccessControlType.Allow);

                MessageBox.Show("完成");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Adds an ACL entry on the specified file for the specified account.
        public static void AddFileSecurity(string fileName, string account,
            FileSystemRights rights, AccessControlType controlType)
        {


            // Get a FileSecurity object that represents the
            // current security settings.
            FileSecurity fSecurity = File.GetAccessControl(fileName);

            // Add the FileSystemAccessRule to the security settings.
            fSecurity.AddAccessRule(new FileSystemAccessRule(account,
                rights, controlType));

            // Set the new access settings.
            File.SetAccessControl(fileName, fSecurity);

        }


        private byte[] ReadFile(string fileName)
        {
            FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int size = (int)f.Length;
            byte[] data = new byte[size];
            size = f.Read(data, 0, size);
            f.Close();
            return data;
        }


        static string GetKeyFileName(X509Certificate2 cert)
        {
            IntPtr hProvider = IntPtr.Zero; // CSP handle
            bool freeProvider = false;       // Do we need to free the CSP ?
            uint acquireFlags = 0;
            int _keyNumber = 0;
            string keyFileName = null;
            byte[] keyFileBytes = null;

            //
            // Determine whether there is private key information available for this certificate in the key store
            //
            if (CryptAcquireCertificatePrivateKey(cert.Handle,
                acquireFlags,
                IntPtr.Zero,
                ref hProvider,
                ref _keyNumber,
                ref freeProvider))
            {
                IntPtr pBytes = IntPtr.Zero; // Native Memory for the CRYPT_KEY_PROV_INFO structure
                int cbBytes = 0;           // Native Memory size

                try
                {
                    if (CryptGetProvParam(hProvider, CryptGetProvParamType.PP_UNIQUE_CONTAINER, IntPtr.Zero, ref cbBytes, 0))
                    {
                        pBytes = Marshal.AllocHGlobal(cbBytes);

                        if (CryptGetProvParam(hProvider, CryptGetProvParamType.PP_UNIQUE_CONTAINER, pBytes, ref cbBytes, 0))
                        {
                            keyFileBytes = new byte[cbBytes];

                            Marshal.Copy(pBytes, keyFileBytes, 0, cbBytes);

                            // Copy eveything except tailing null byte
                            keyFileName = System.Text.Encoding.ASCII.GetString(keyFileBytes, 0, keyFileBytes.Length - 1);
                        }
                    }
                }
                finally
                {
                    if (freeProvider)
                        CryptReleaseContext(hProvider, 0);

                    //
                    // Free our native memory
                    //
                    if (pBytes != IntPtr.Zero)
                        Marshal.FreeHGlobal(pBytes);

                }
            }

            if (keyFileName == null)
                throw new InvalidOperationException("Unable to obtain private key file name");

            return keyFileName;
        }

        static string GetKeyFileDirectory(string keyFileName)
        {
            // Look up All User profile from environment variable
            string allUserProfile = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            // set up searching directory
            string machineKeyDir = allUserProfile + "\\Microsoft\\Crypto\\RSA\\MachineKeys";

            // Seach the key file
            string[] fs = System.IO.Directory.GetFiles(machineKeyDir, keyFileName);

            // If found
            if (fs.Length > 0)
                return machineKeyDir;

            // Next try current user profile
            string currentUserProfile = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // seach all sub directory
            string userKeyDir = currentUserProfile + "\\Microsoft\\Crypto\\RSA\\";

            fs = System.IO.Directory.GetDirectories(userKeyDir);
            if (fs.Length > 0)
            {
                // for each sub directory
                foreach (string keyDir in fs)
                {
                    fs = System.IO.Directory.GetFiles(keyDir, keyFileName);
                    if (fs.Length == 0)
                        continue;
                    else
                        // found
                        return keyDir;
                }
            }

            throw new InvalidOperationException("Unable to locate private key file directory");
        }

        private void btnBrow_Click(object sender, EventArgs e)
        {
            if (ofdCert.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdCert.FileName;
            }
        }

    }
}
