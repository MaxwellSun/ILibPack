namespace ILibPack.Helpers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public static class RepackRun
    {
        private static StreamReader GetCMDStreamReader(ProcessStartInfo Info)
        {
            using Process result = Process.Start(Info);
            return result.StandardOutput;
        }
        public static async Task<IEnumerable<string>> GetCMDOutputAsync(string args)
        {
            var Info = new ProcessStartInfo
            {
                FileName = GlobalPath.ILPath,
                Arguments = args,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                StandardOutputEncoding = Encoding.GetEncoding(866)
            };
            IEnumerable<string> result = GetCMDOutput(Info);
            return await Task.Run(() =>
            {
                return result;
            });
        }
        private static IEnumerable<string> GetCMDOutput(ProcessStartInfo Info)
        {
            using StreamReader streamReader = GetCMDStreamReader(Info);
            while (!streamReader.EndOfStream)
            {
                yield return streamReader?.ReadLine();
            }
        }
    }
}