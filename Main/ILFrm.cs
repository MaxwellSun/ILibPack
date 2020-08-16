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
            this.MenuDll.Renderer = new ToolStripProfessionalRenderer(new MenuPalette());
            this.MenuLog.Renderer = new ToolStripProfessionalRenderer(new MenuPalette());

            this.LogoText.MouseDown += Controls_MouseDown;
            this.UPanel.MouseDown += Controls_MouseDown;

            DragEnter += new DragEventHandler(LibraryPathBox_DragEnter);
            DragDrop += new DragEventHandler(LibraryPathBox_DragDrop);
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            DeleteILPack();
            Application.Exit();
        }

        private void AddingExecutable_Click(object sender, EventArgs e)
        {
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
                    if (!FrameVerDllInfo.Contains("N/A"))
                    {
                        if (!this.LibraryPathBox.Items.Contains(multi))
                        {
                            if (FrameVerExeInfo.Equals(FrameVerDllInfo, StringComparison.OrdinalIgnoreCase)) // Если версии .dll совпадает с .exe
                            {
                                this.LibraryPathBox.Items.Add(multi);
                                this.TextPathLibrary.Text = $"Path to .dll file(s): {LibraryPathBox.Items.Count}";
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
            this.LibraryPathBox.AllowDrop = true;
        }

        private void SelectDelete_Click(object sender, EventArgs e)
        {
            NativeMethods.SetFocus(IntPtr.Zero);
            this.LogoText.Focus();

            if (this.LibraryPathBox.SelectedIndex != -1)
            {
                this.LibraryPathBox.Items.RemoveAt(this.LibraryPathBox.SelectedIndex);
                this.TextPathLibrary.Text = $"Path to .dll file(s): {LibraryPathBox.Items.Count}";
            }
            else
            {
                StatusMessage.Location = new Point(7, 273);
                ControlActive.CheckMessage(StatusMessage, "Select an item from the list to remove.", Color.LightBlue, 3000);
            }
        }

        private void AllClean_Click(object sender, EventArgs e)
        {
            NativeMethods.SetFocus(IntPtr.Zero);
            this.LogoText.Focus();
            if (this.LibraryPathBox.SelectedIndex != -1)
            {
                this.LibraryPathBox.Items.Clear();
                this.TextPathLibrary.Text = $"Path to .dll file(s): {LibraryPathBox.Items.Count}";
            }
            else
            {
                StatusMessage.Location = new Point(7, 273);
                ControlActive.CheckMessage(StatusMessage, "There is nothing on the list.", Color.LightBlue, 3000);
            }
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            NativeMethods.SetFocus(IntPtr.Zero);
            this.LogoText.Focus();
            if (!string.IsNullOrWhiteSpace(this.RepackLogBox.Text))
            {
                this.RepackLogBox.Clear();
            }
            else
            {
                StatusMessage.Location = new Point(7, 273);
                ControlActive.CheckMessage(StatusMessage, "There is nothing in the logger.", Color.LightBlue, 3000);
            }
        }

        private void LibraryPathBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.ExecutablePathBox.Text))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    if (files[0].EndsWith(".dll"))
                    {
                        string FrameVerDllInfo = CheckFramework.Version(files[0]); // Получаем версию NetFramework бибиотеки
                        string FrameVerExeInfo = CheckFramework.Version(this.ExecutablePathBox.Text); // Получаем версию NetFramework бинарника
                        if (!FrameVerDllInfo.Contains("N/A"))
                        {
                            if (!this.LibraryPathBox.Items.Contains(file))
                            {
                                if (FrameVerExeInfo.Equals(FrameVerDllInfo, StringComparison.OrdinalIgnoreCase)) // Если версии .dll совпадает с .exe
                                {
                                    this.LibraryPathBox.Items.Add(file);
                                    this.TextPathLibrary.Text = $"Path to .dll file(s): {LibraryPathBox.Items.Count}";
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
                e.Effect = DragDropEffects.Move;
            }
        }

        private async void CompileBuild_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.ExecutablePathBox.Text))
            {
                if (this.LibraryPathBox.Items.Count > 0)
                {
                    if (CheckLibrary())
                    {
                        this.RepackLogBox.Clear();
                        if (!File.Exists(GlobalPath.ILPath))
                        {
                            try
                            {
                                File.WriteAllBytes(GlobalPath.ILPath, Resources.ilrepack);
                            }
                            catch { }
                        }
                        var action = new Action<string>((s) => this.RepackLogBox.Text += $"{s}{Environment.NewLine}");
                        foreach (string item in await RepackRun.GetCMDOutputAsync(Script()).ConfigureAwait(false))
                        {
                            this.RepackLogBox.Invoke(action, item);
                        }
                        if (this.RepackLogBox.Text.Contains("Finished"))
                        {
                            MusicPlay.Inizialize(Resources.GoodBuild);
                            this.StatusMessage.Location = new Point(128, 244);
                            ControlActive.CheckMessage(this.StatusMessage, "Libraries have been successfully added to the assembly!", Color.LightBlue, 3000);
                            DeleteILPack();
                        }
                        else
                        {
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

        private string Script()
        {
            StringBuilder combine = null;
            try
            {
                string CurrFile = Path.GetFileName(this.ExecutablePathBox.Text);
                string NewFile = CurrFile.Replace(CurrFile, $"Repacked_{CurrFile}");
                combine = new StringBuilder();
                combine.Append($"{this.ExecutablePathBox.Text} ");
                if (CheckLinker.SubSystem(this.ExecutablePathBox.Text).Contains("Console"))
                {
                    combine.Append("/t:exe ");
                }
                else
                {
                    combine.Append("/t:winexe ");
                }
                combine.Append("/ndebug ");
                combine.Append($"/out:\"{Path.Combine(GlobalPath.CurrDir, NewFile)}\" ");
                foreach (var listdll in LibraryPathBox.Items)
                {
                    combine.Append($"{listdll} ");
                }
            }
            catch { }

            return combine?.ToString();
        }

        private void DeleteILPack()
        {
            try
            {
                if (File.Exists(GlobalPath.ILPath))
                {
                    File.Delete(GlobalPath.ILPath);
                }
            }
            catch { }
        }

        private bool CheckLibrary()
        {
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
            if (!(TextRenderer.MeasureText(RepackLogBox.Text, RepackLogBox.Font).Width < RepackLogBox.Width))
            {
                RepackLogBox.SelectionStart = RepackLogBox.Text.Length;
                RepackLogBox.ScrollToCaret();
                RepackLogBox.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                RepackLogBox.ScrollBars = ScrollBars.None;
            }
        }

        private void ExecutablePathBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.ExecutablePathBox.Text))
            {
                this.VersionNet.Text = $"NetFramework: {CheckFramework.Version(this.ExecutablePathBox.Text)}";
                if (this.VersionNet.Text.Contains("N/A"))
                {
                    MusicPlay.Inizialize(Resources.Error_Build);
                    this.ExecutablePathBox.Clear();
                    this.StatusMessage.Location = new Point(7, 273);
                    ControlActive.CheckMessage(StatusMessage, "Supports only .Net binary files", Color.LightBlue, 3000);
                    this.AddingLibrary.Enabled = false;
                }
                else
                {
                    this.AddingLibrary.Enabled = true;
                    this.CompileBuild.Enabled = true;
                }
            }
            else
            {
                this.VersionNet.Text = "";
                this.AddingLibrary.Enabled = false;
                this.CompileBuild.Enabled = false;
            }
        }
    }
}