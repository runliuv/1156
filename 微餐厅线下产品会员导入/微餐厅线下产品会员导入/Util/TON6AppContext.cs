
using System.Runtime.InteropServices;
using System.Text;

public class TON6AppContext
{



    [DllImport("issWCT.dll", CharSet = CharSet.Ansi)]
    public static extern bool StringEncrypt(string source, StringBuilder sbBuffer, int size);


    [DllImport("issWCT.dll", CharSet = CharSet.Ansi)]
    public static extern bool StringDecrypt(string source, StringBuilder sbBuffer, int size);

}