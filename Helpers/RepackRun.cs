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
            // Передаём параметры для старта процесса
            using Process result = Process.Start(Info);
            return result.StandardOutput; // Получаем выходные данные
        }
        public static async Task<IEnumerable<string>> GetCMDOutputAsync(string args)
        {
            // Создаём информацию о запуске процесса с передачей аргументов
            var Info = new ProcessStartInfo
            {
                FileName = GlobalPath.ILPath,
                Arguments = args,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                StandardOutputEncoding = Encoding.GetEncoding(866)
            };
            IEnumerable<string> result = GetCMDOutput(Info); // Возвращяем коллекцию
            return await Task.Run(() =>
            {
                return result; // Асинхронно получаем результат
            });
        }
        private static IEnumerable<string> GetCMDOutput(ProcessStartInfo Info)
        {
            using StreamReader streamReader = GetCMDStreamReader(Info);
            // Читаем поток до конца и выводим данные в виде строки.
            while (!streamReader.EndOfStream) 
            {
                yield return streamReader?.ReadLine();
            }
        }
    }
}