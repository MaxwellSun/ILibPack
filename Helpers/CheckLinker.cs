namespace ILibPack.Helpers
{
    public static class CheckLinker
    {
        /// <summary>
        /// Метод для проверки типа выходных данных приложения по пути.
        /// </summary>
        /// <param name="pszPath">Путь к файлу</param>
        /// <returns></returns>
        public static string SubSystem(string pszPath) 
        {
            // Получаем тип .Exe файла
            Enums.ExeType type = NativeMethods.GetExeType(pszPath); 
            // Cогласно спецификации, если это только MZ или PE, 
            // он открывается в консоли, в противном случае (если указана версия) он открывается в окне.
            return type != Enums.ExeType.PE && type != Enums.ExeType.MZ ? "WinForms" : "Console";
        }
    }
}
