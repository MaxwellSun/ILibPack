namespace ILibPack.Helpers
{
    using System.Reflection;

    public static class CheckNative
    {
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