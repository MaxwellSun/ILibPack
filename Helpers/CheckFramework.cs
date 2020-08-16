namespace ILibPack.Helpers
{
    using System;
    using System.Reflection;

    public static class CheckFramework
    {
        public static string Version(string assemblyFile)
        {
            string result = string.Empty;
            try
            {
                var ass = Assembly.ReflectionOnlyLoadFrom(assemblyFile);
                string s = ass.ImageRuntimeVersion;

                if (s.Contains("v1.1"))
                {
                    result = "v1.1";
                }
                else if (s.Contains("v2.0"))
                {
                    result = "v2.0";
                }
                else if (s.Contains("v3.0"))
                {
                    result = "v3.0";
                }
                else if (s.Contains("v3.5"))
                {
                    result = "v3.5";
                }
                else if (s.Contains("v4.0"))
                {
                    result = "v4.0";
                }
                else if (s.Contains("v4.5"))
                {
                    result = "v4.5";
                }
                else if (s.Contains("v4.5.1"))
                {
                    result = "v4.5.1";
                }
                else if (s.Contains("v4.5.2"))
                {
                    result = "v4.5.2";
                }
                else if (s.Contains("v4.6"))
                {
                    result = "v4.6";
                }
                else if (s.Contains("v4.6.1"))
                {
                    result = "v4.6.1";
                }
                else if (s.Contains("v4.6.2"))
                {
                    result = "v4.6.2";
                }
                else if (s.Contains("v4.7"))
                {
                    result = "v4.7";
                }
                else if (s.Contains("v4.7.1"))
                {
                    result = "v4.7.1";
                }
                else if (s.Contains("v4.7.2"))
                {
                    result = "v4.7.2";
                }
                else if (s.Contains("v4.8"))
                {
                    result = "v4.8";
                }
            }
            catch (BadImageFormatException) { result = "N/A"; }
            return result;
        }
    }
}
