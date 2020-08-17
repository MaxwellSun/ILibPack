namespace ILibPack.Helpers
{
    using System.Reflection;

    public static class CheckNative
    {
        /// <summary>
        /// Метод для проверки файла на наличие Assembly
        /// </summary>
        /// <param name="filename">имя файла</param>
        /// <returns></returns>
        public static bool IsReflection(string filename)
        {
            try
            {
                AssemblyName.GetAssemblyName(filename);
                return true;
            }
            catch { return false; }
        }
    }
}