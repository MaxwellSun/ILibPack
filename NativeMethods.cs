namespace ILibPack
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        [DllImport("user32.dll")]
        internal extern static IntPtr SetFocus(IntPtr hWnd);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetFileInfo")]
        public static extern Enums.ExeType GetExeType(string pszPath, uint dwFileAttributes = 0, IntPtr psfi = default, uint cbFileInfo = 0, uint uFlags = 0x2000);
    }
}