namespace ILibPack.Helpers
{
    public static class CheckLinker
    {
        public static string SubSystem(string pszPath) 
        {
            Enums.ExeType type = NativeMethods.GetExeType(pszPath);
            return type != Enums.ExeType.PE && type != Enums.ExeType.MZ ? "WinForms" : "Console";
        }
    }
}
