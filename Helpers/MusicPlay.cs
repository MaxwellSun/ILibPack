namespace ILibPack.Helpers
{
    using System;
    using System.IO;
    using System.Media;

    public static class MusicPlay
    {
        /// <summary>
        /// Метод для проигрывания музыки в формате <b>.wav</b>
        /// </summary>
        /// <param name="stream">Звуковой файл формата <b>.wav</b> из ресурсов</param>
        public static void Inizialize(UnmanagedMemoryStream stream)
        {
            try
            {
                using var snd = new SoundPlayer(stream);
                snd?.Load(); // Загружаем звуковой файл
                if (snd.IsLoadCompleted) // Проверяем загрузку файла
                {
                    snd.Play(); // Проигрываем файл
                }
            }
            catch (Exception ex) { File.WriteAllText(GlobalPath.MusicError, ex.Message); }
        }
    }
}