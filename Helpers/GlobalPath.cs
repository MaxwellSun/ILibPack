namespace ILibPack.Helpers
{
    using System;
    using System.ComponentModel;
    using System.IO;

    [Description("Класс для вывода всех путей")]
    public static class GlobalPath
    {
        public static string CurrDir = Environment.CurrentDirectory;
        public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string ILPath = Path.Combine(AppData, "ilrepack.exe");
        public static string MusicError = Path.Combine(CurrDir, "ErrorPlay.txt");
    }
}