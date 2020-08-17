namespace ILibPack
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    using Helpers;
    using Properties;

    public partial class ILFrm : Form
    {
        protected void Controls_MouseDown(object sender, MouseEventArgs e)
        {
            // Если пользователь нажал левую кнопку мыши
            if (e.Button.Equals(MouseButtons.Left))
            {
                ((Control)sender).Capture = false; // захват элемента управления
                // Посылаем сообщение переместить элемент управления
                var m = Message.Create(this.Handle, 0xa1, new IntPtr(0x2), IntPtr.Zero);
                // Обработчик сообщения
                WndProc(ref m);
            }
        }

        public ILFrm()
        {
            InitializeComponent();
            // Палитра для кнопок в ContextMenu
            this.MenuDll.Renderer = new ToolStripProfessionalRenderer(new MenuPalette());
            this.MenuLog.Renderer = new ToolStripProfessionalRenderer(new MenuPalette());

            // Какие элементы можно передвигать кликом мышки
            this.LogoText.MouseDown += Controls_MouseDown;
            this.UPanel.MouseDown += Controls_MouseDown;

            // Обработка событий Drag and Drop
            DragEnter += new DragEventHandler(LibraryPathBox_DragEnter);
            DragDrop += new DragEventHandler(LibraryPathBox_DragDrop);
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            DeleteILPack(); // Удаляем ilpacker.exe
            Application.Exit(); // Выходим из программы
        }

        private void AddingExecutable_Click(object sender, EventArgs e)
        {
            // Убираем фокус с кнопки
            NativeMethods.SetFocus(IntPtr.Zero);
            this.LogoText.Focus();

            using var ofd = new OpenFileDialog
            {
                Title = "Select the file you want to add .dll libraries",
                Filter = "Executable file|*.exe",
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                Multiselect = false,
                RestoreDirectory = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.ExecutablePathBox.Text = ofd.FileName;
                this.RepackLogBox.Clear();
            }
            else
            {
                StatusMessage.Location = new Point(17, 273);
                ControlActive.CheckMessage(StatusMessage, "No file selected", Color.LightBlue, 3000);
                this.ExecutablePathBox.Clear();
            }
        }

        private void AddingLibrary_Click(object sender, EventArgs e)
        {
            // Убираем фокус с кнопки
            NativeMethods.SetFocus(IntPtr.Zero);
            this.LogoText.Focus();

            using var ofd = new OpenFileDialog
            {
                Title = "Select the .dll file(s) you want to add",
                Filter = "Library file|*.dll",
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                Multiselect = true,
                RestoreDirectory = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string multi in ofd.FileNames)
                {
                    string FrameVerDllInfo = CheckFramework.Version(multi); // Получаем версию NetFramework бибиотеки
                    string FrameVerExeInfo = CheckFramework.Version(this.ExecutablePathBox.Text); // Получаем версию NetFramework бинарника
                    if (!FrameVerDllInfo.Contains("N/A")) // Если нет совпадений с N/A
                    {
                        if (!this.LibraryPathBox.Items.Contains(multi)) // Если нет совпадающий файлов в списке
                        {
                            if (FrameVerExeInfo.Equals(FrameVerDllInfo, StringComparison.OrdinalIgnoreCase)) // Если версии .dll совпадает с .exe
                            {
                                this.LibraryPathBox.Items.Add(multi); // Добавляем файл в ListBox
                                this.TextPathLibrary.Text = $"Path to .dll file(s): {LibraryPathBox.Items.Count}"; // Добавляем счётчик
                            }
                            else
                            {
                                StatusMessage.Location = new Point(7, 273); 
                                ControlActive.CheckMessage(StatusMessage, ".NetFramework version does not match .exe file", Color.LightBlue, 3000);
                            }
                        }
                        else
                        {
                            StatusMessage.Location = new Point(7, 273);
                            ControlActive.CheckMessage(StatusMessage, "Such file is already in the list", Color.LightBlue, 3000);
                        }
                    }
                    else
                    {
                        this.StatusMessage.Location = new Point(7, 273);
                        ControlActive.CheckMessage(StatusMessage, "Supports only .Net library files", Color.LightBlue, 3000);
                    }
                }
            }
            else
            {
                StatusMessage.Location = new Point(7, 273);
                ControlActive.CheckMessage(StatusMessage, "No file selected", Color.LightBlue, 3000);
            }
        }

        private void ILFrm_Load(object sender, EventArgs e)
        {
            this.LibraryPathBox.AllowDrop = true; // Для перемещения файлов ставим true
        }

        private void SelectDelete_Click(object sender, EventArgs e)
        {
            // Убираем фокус с кнопки
            NativeMethods.SetFocus(IntPtr.Zero);
            this.LogoText.Focus();

            // Если если какой-то элемент в списке
            if (this.LibraryPathBox.SelectedIndex != -1)
            {
                this.LibraryPathBox.Items.RemoveAt(this.LibraryPathBox.SelectedIndex); // Удаляем выбранный элемент
                this.TextPathLibrary.Text = $"Path to .dll file(s): {LibraryPathBox.Items.Count}"; // Добавляем счётчик
            }
            else
            {
                StatusMessage.Location = new Point(7, 273);
                ControlActive.CheckMessage(StatusMessage, "Select an item from the list to remove.", Color.LightBlue, 3000);
            }
        }

        private void AllClean_Click(object sender, EventArgs e)
        {
           // Очищяем весь список
           this.LibraryPathBox.DataSource = null;
           this.LibraryPathBox.Items.Clear();
           this.TextPathLibrary.Text = $"Path to .dll file(s): {LibraryPathBox.Items.Count.ToString().Trim('0')}"; // Убираем счётчик
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            // Убираем фокус с кнопки
            NativeMethods.SetFocus(IntPtr.Zero);
            this.LogoText.Focus();
            
            // Если логированный список не пустой
            if (!string.IsNullOrWhiteSpace(this.RepackLogBox.Text))
            {
                this.RepackLogBox.Clear(); // Очищяем
            }
            else
            {
                StatusMessage.Location = new Point(7, 273);
                ControlActive.CheckMessage(StatusMessage, "There is nothing in the logger.", Color.LightBlue, 3000);
            }
        }

        private void LibraryPathBox_DragDrop(object sender, DragEventArgs e)
        {
            // Если путь к файлу .exe не пустой
            if (!string.IsNullOrWhiteSpace(this.ExecutablePathBox.Text))
            {
                // Принимаем файл(ы)
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                // Проходимся в цикле
                foreach (string file in files)
                {
                    // Проверяем расширения файла
                    if (files[0].EndsWith(".dll"))
                    {
                        // Получаем версию NetFramework бибиотеки
                        string FrameVerDllInfo = CheckFramework.Version(files[0]);
                        // Получаем версию NetFramework бинарника
                        string FrameVerExeInfo = CheckFramework.Version(this.ExecutablePathBox.Text);
                        // Если версия не совпадает с N/A
                        if (!FrameVerDllInfo.Contains("N/A"))
                        {
                            // Если нет совпадений файлов из ListBox'a
                            if (!this.LibraryPathBox.Items.Contains(file))
                            {
                                // Если версии .dll совпадает с .exe
                                if (FrameVerExeInfo.Equals(FrameVerDllInfo, StringComparison.OrdinalIgnoreCase)) 
                                {
                                    this.LibraryPathBox.Items.Add(file); // Добавляем файл в список ListBox 
                                    this.TextPathLibrary.Text = $"Path to .dll file(s): {LibraryPathBox.Items.Count}"; // Добавляем счётчик
                                }
                                else
                                {
                                    StatusMessage.Location = new Point(7, 273);
                                    ControlActive.CheckMessage(StatusMessage, ".NetFramework version does not match file", Color.LightBlue, 3000);
                                }
                            }
                            else
                            {
                                StatusMessage.Location = new Point(7, 273);
                                ControlActive.CheckMessage(StatusMessage, "Such file is already in the list", Color.LightBlue, 3000);
                            }
                        }
                        else
                        {
                            this.StatusMessage.Location = new Point(7, 273);
                            ControlActive.CheckMessage(StatusMessage, "Supports only .Net library files", Color.LightBlue, 3000);
                        }
                    }
                    else
                    {
                        StatusMessage.Location = new Point(7, 273);
                        ControlActive.CheckMessage(StatusMessage, "Supports only .dll files", Color.LightBlue, 3000);
                    }
                }
            }
            else
            {
                StatusMessage.Location = new Point(7, 273);
                ControlActive.CheckMessage(StatusMessage, "Fill in the first input field .exe path", Color.LightBlue, 3000);
            }
        }

        private void LibraryPathBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.Move; // Эффект перетаскивания
            }
        }

        private async void CompileBuild_Click(object sender, EventArgs e)
        {
            // Убираем фокус с кнопки
            NativeMethods.SetFocus(IntPtr.Zero);
            this.LogoText.Focus();

            // Если путь к файлу .exe не пустой
            if (!string.IsNullOrWhiteSpace(this.ExecutablePathBox.Text))
            {
                // Если в списке ListBox есть .dll файлы
                if (this.LibraryPathBox.Items.Count > 0)
                {
                    // Проверяем на корректность библиотек
                    if (CheckLibrary())
                    {
                        // Очищяем логгер
                        this.RepackLogBox.Clear();
                        // Проверяем файл ILRepacke'a в папке %AppData%
                        if (!File.Exists(GlobalPath.ILPath))
                        {
                            try
                            {
                                // Если файла нету, то сохраняем его в папку %AppData% из ресурсов.
                                File.WriteAllBytes(GlobalPath.ILPath, Resources.ilrepack);
                            }
                            catch { }
                        }
                        
                        // Выполняем слияние библиотек с файлом в асинхронном режиме
                        var action = new Action<string>((s) => this.RepackLogBox.Text += $"{s}{Environment.NewLine}");
                        foreach (string item in await RepackRun.GetCMDOutputAsync(Script()).ConfigureAwait(false))
                        {
                            this.RepackLogBox.Invoke(action, item);
                        }
                        // Если в логгере находим строку Finished - что значит "закончено"
                        if (this.RepackLogBox.Text.Contains("Finished"))
                        {
                            // Уведомляем пользователя что всё прошло успешно
                            MusicPlay.Inizialize(Resources.GoodBuild);
                            this.StatusMessage.Location = new Point(128, 244);
                            ControlActive.CheckMessage(this.StatusMessage, "Libraries have been successfully added to the assembly!", Color.LightBlue, 3000);
                            DeleteILPack();
                        }
                        else
                        {
                            // Иначе выводим ошибку 
                            MusicPlay.Inizialize(Resources.Error_Build);
                            this.StatusMessage.Location = new Point(128, 244);
                            ControlActive.CheckMessage(this.StatusMessage, "Error adding libraries!", Color.LightBlue, 3000);
                        }
                    }
                }
                else
                {
                    this.StatusMessage.Location = new Point(7, 273);
                    ControlActive.CheckMessage(StatusMessage, "Add the .dll file to the field", Color.LightBlue, 3000);
                }
            }
            else
            {
                this.StatusMessage.Location = new Point(7, 273);
                ControlActive.CheckMessage(StatusMessage, "Add the .exe file to the field", Color.LightBlue, 3000);
            }
        }

        /// <summary>
        /// Метод для создания скрипта для слияния библиотек.
        /// </summary>
        /// <returns>Сгенерированный скрипт для слияния</returns>
        private string Script()
        {
            StringBuilder combine = null; 
            try
            {
                // Получаем текушее имя файла .exe из TextBox'a. (this.ExecutablePathBox.Text)
                string CurrFile = Path.GetFileName(this.ExecutablePathBox.Text);
                // Меняем старое имя файла на новое.
                string NewFile = CurrFile.Replace(CurrFile, $"Repacked_{CurrFile}");
                combine = new StringBuilder();
                // Добавляем путь к файлу к которому нужно добавлять библиотеки.
                combine.Append($"{this.ExecutablePathBox.Text} "); 
                // Проверяем тип выходных данных приложения из TextBox'a.
                if (CheckLinker.SubSystem(this.ExecutablePathBox.Text).Contains("Console"))
                {
                    // Параметр -target:exe предписывает компилятору создать исполняемое (EXE) консольное приложение.
                    combine.Append("/t:exe "); 
                }
                else
                {
                    // Параметр -target:winexe предписывает компилятору создать исполняемый файл (EXE), программу Windows.
                    combine.Append("/t:winexe ");
                }
                // Отключает создание файла символов.
                combine.Append("/ndebug ");
                // Выходной путь нового файла.
                combine.Append($"/out:\"{Path.Combine(GlobalPath.CurrDir, NewFile)}\" ");
                // Проходимся по списку .dll файлов из ListBox'a.
                foreach (var listdll in LibraryPathBox.Items)
                {
                    combine.Append($"{listdll} "); // Добавляем их в параметр для слияния.
                }
            }
            catch { }

            return combine?.ToString(); // Возвращаем готовый скрипт.
        }

        /// <summary>
        /// Метод для удаления файла <b>ilrepack.exe</b> в папке <b>%AppData%</b>.
        /// </summary>
        private void DeleteILPack()
        {
            try
            {
                // Проверяем файл в папке
                if (File.Exists(GlobalPath.ILPath))
                {
                    // Удаляем файл из папки
                    File.Delete(GlobalPath.ILPath);
                }
            }
            catch { }
        }

        /// <summary>
        /// Метод для проверки библиотек на наличие .NetFramework'a
        /// </summary>
        /// <returns>true/false</returns>
        private bool CheckLibrary()
        {
            // Проходимся по списку .dll из ListBox'a
            foreach (var libs in this.LibraryPathBox.Items)
            {
                bool result = CheckNative.IsReflection((string)libs);
                if (result)
                {
                    return true;
                }
                else
                {
                    this.StatusMessage.Location = new Point(7, 273);
                    ControlActive.CheckMessage(StatusMessage, $"The library {this.LibraryPathBox.Items.IndexOf(result)} is not .Net", Color.LightBlue, 3000);
                    return false;
                }
            }
            return false;
        }
       
        private void RepackLogBox_TextChanged(object sender, EventArgs e)
        {
            // Проверяем если есть изменения в тексте
            if (!(TextRenderer.MeasureText(RepackLogBox.Text, RepackLogBox.Font).Width < RepackLogBox.Width))
            {
                RepackLogBox.SelectionStart = RepackLogBox.Text.Length; // Получаем начальный размер строки из Логгера
                RepackLogBox.ScrollToCaret(); // Прокручиваем текст до текущей позиции 
                RepackLogBox.ScrollBars = ScrollBars.Vertical; // Отображаем только вертикальную полосу прокрутки
            }
            else
            {
                RepackLogBox.ScrollBars = ScrollBars.None; // Убераем полосу прокрутки
            }
        }

        private void ExecutablePathBox_TextChanged(object sender, EventArgs e)
        {
            // Если путь к файлу .exe не пустой
            if (!string.IsNullOrWhiteSpace(this.ExecutablePathBox.Text))
            {
                // Выводим версию .Net файла 
                this.VersionNet.Text = $"NetFramework: {CheckFramework.Version(this.ExecutablePathBox.Text)}";
                // Если строка совпадает с N/A
                if (this.VersionNet.Text.Contains("N/A"))
                {
                    // Выводим ошибку пользователю
                    MusicPlay.Inizialize(Resources.Error_Build);
                    this.ExecutablePathBox.Clear();
                    this.StatusMessage.Location = new Point(7, 273);
                    ControlActive.CheckMessage(StatusMessage, "Supports only .Net binary files", Color.LightBlue, 3000);
                    this.AddingLibrary.Enabled = false; // Блокируем кнопку добавления библиотек .dll 
                }
                else
                {
                    // разблокируем элементы кнопок 
                    this.AddingLibrary.Enabled = true; // Добавление библиотек .dll
                    this.CompileBuild.Enabled = true; // Перепаковка ( слияние библиотек )
                }
            }
            else
            {
                // Очищяем версию .Net Framework 
                this.VersionNet.Text = "";
                // Блокируем элементы кнопко 
                this.AddingLibrary.Enabled = false; // Добавление библиотек .dll
                this.CompileBuild.Enabled = false; // Перепаковка ( слияние библиотек )
            }
        }
    }
}