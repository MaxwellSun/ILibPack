namespace ILibPack.Helpers
{
    using System;
    using System.IO;

    public static class GlobalPath
    {
        public static string CurrDir = Environment.CurrentDirectory;
        public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string ILPath = Path.Combine(AppData, "ilrepack.exe");
    }
}