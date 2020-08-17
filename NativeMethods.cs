namespace ILibPack
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        // Для удаления фокуса с элементов 
        [DllImport("user32.dll")]
        internal extern static IntPtr SetFocus(IntPtr hWnd);

        // https://docs.microsoft.com/ru-ru/windows/win32/api/shellapi/nf-shellapi-shgetfileinfoa?redirectedfrom=MSDN
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetFileInfo")]
        public static extern Enums.ExeType GetExeType(string pszPath, uint dwFileAttributes = 0, IntPtr psfi = default, uint cbFileInfo = 0, uint uFlags = 0x2000);
    }
}