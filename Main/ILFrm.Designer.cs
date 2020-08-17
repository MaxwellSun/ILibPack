namespace ILibPack
{
    partial class ILFrm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ILFrm));
            this.UPanel = new System.Windows.Forms.Panel();
            this.ExitApp = new System.Windows.Forms.Button();
            this.LogoText = new System.Windows.Forms.Label();
            this.AddingExecutable = new System.Windows.Forms.Button();
            this.CompileBuild = new System.Windows.Forms.Button();
            this.TextPathBinary = new System.Windows.Forms.Label();
            this.ExecutablePathBox = new System.Windows.Forms.TextBox();
            this.TextPathLibrary = new System.Windows.Forms.Label();
            this.AddingLibrary = new System.Windows.Forms.Button();
            this.StatusMessage = new System.Windows.Forms.Label();
            this.DragDropHelper = new System.Windows.Forms.Label();
            this.RussianMessage = new System.Windows.Forms.ToolTip(this.components);
            this.RepackLogBox = new System.Windows.Forms.TextBox();
            this.MenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.LibraryPathBox = new System.Windows.Forms.ListBox();
            this.MenuDll = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SelectDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.AllClean = new System.Windows.Forms.ToolStripMenuItem();
            this.RepackLogText = new System.Windows.Forms.Label();
            this.VersionNet = new System.Windows.Forms.Label();
            this.UPanel.SuspendLayout();
            this.MenuLog.SuspendLayout();
            this.MenuDll.SuspendLayout();
            this.SuspendLayout();
            // 
            // UPanel
            // 
            this.UPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(110)))), ((int)(((byte)(166)))));
            this.UPanel.Controls.Add(this.ExitApp);
            this.UPanel.Controls.Add(this.LogoText);
            this.UPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UPanel.Location = new System.Drawing.Point(0, 0);
            this.UPanel.Name = "UPanel";
            this.UPanel.Size = new System.Drawing.Size(537, 34);
            this.UPanel.TabIndex = 0;
            // 
            // ExitApp
            // 
            this.ExitApp.FlatAppearance.BorderSize = 0;
            this.ExitApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.ExitApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ExitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitApp.ForeColor = System.Drawing.Color.White;
            this.ExitApp.Location = new System.Drawing.Point(503, 2);
            this.ExitApp.Name = "ExitApp";
            this.ExitApp.Size = new System.Drawing.Size(32, 31);
            this.ExitApp.TabIndex = 1;
            this.ExitApp.TabStop = false;
            this.ExitApp.Text = "Х";
            this.ExitApp.UseVisualStyleBackColor = true;
            this.ExitApp.Click += new System.EventHandler(this.ExitApp_Click);
            // 
            // LogoText
            // 
            this.LogoText.AutoSize = true;
            this.LogoText.ForeColor = System.Drawing.Color.White;
            this.LogoText.Location = new System.Drawing.Point(12, 10);
            this.LogoText.Name = "LogoText";
            this.LogoText.Size = new System.Drawing.Size(101, 13);
            this.LogoText.TabIndex = 0;
            this.LogoText.Text = "ILibPacker by r3xq1";
            // 
            // AddingExecutable
            // 
            this.AddingExecutable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(110)))), ((int)(((byte)(166)))));
            this.AddingExecutable.FlatAppearance.BorderSize = 0;
            this.AddingExecutable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddingExecutable.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.AddingExecutable.Location = new System.Drawing.Point(484, 65);
            this.AddingExecutable.Name = "AddingExecutable";
            this.AddingExecutable.Size = new System.Drawing.Size(43, 20);
            this.AddingExecutable.TabIndex = 1;
            this.AddingExecutable.TabStop = false;
            this.AddingExecutable.Text = "...";
            this.AddingExecutable.UseVisualStyleBackColor = false;
            this.AddingExecutable.Click += new System.EventHandler(this.AddingExecutable_Click);
            // 
            // CompileBuild
            // 
            this.CompileBuild.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CompileBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(110)))), ((int)(((byte)(166)))));
            this.CompileBuild.Enabled = false;
            this.CompileBuild.FlatAppearance.BorderSize = 0;
            this.CompileBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompileBuild.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.CompileBuild.Location = new System.Drawing.Point(9, 235);
            this.CompileBuild.Name = "CompileBuild";
            this.CompileBuild.Size = new System.Drawing.Size(102, 31);
            this.CompileBuild.TabIndex = 2;
            this.CompileBuild.TabStop = false;
            this.CompileBuild.Text = "Repack";
            this.CompileBuild.UseVisualStyleBackColor = false;
            this.CompileBuild.Click += new System.EventHandler(this.CompileBuild_Click);
            // 
            // TextPathBinary
            // 
            this.TextPathBinary.AutoSize = true;
            this.TextPathBinary.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextPathBinary.Location = new System.Drawing.Point(6, 46);
            this.TextPathBinary.Name = "TextPathBinary";
            this.TextPathBinary.Size = new System.Drawing.Size(83, 13);
            this.TextPathBinary.TabIndex = 3;
            this.TextPathBinary.Text = "Path to .exe file:";
            // 
            // ExecutablePathBox
            // 
            this.ExecutablePathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ExecutablePathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExecutablePathBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ExecutablePathBox.Location = new System.Drawing.Point(9, 65);
            this.ExecutablePathBox.MaxLength = 9999999;
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.ReadOnly = true;
            this.ExecutablePathBox.ShortcutsEnabled = false;
            this.ExecutablePathBox.Size = new System.Drawing.Size(469, 20);
            this.ExecutablePathBox.TabIndex = 4;
            this.ExecutablePathBox.TabStop = false;
            this.RussianMessage.SetToolTip(this.ExecutablePathBox, "Полный путь до файла .exe");
            this.ExecutablePathBox.TextChanged += new System.EventHandler(this.ExecutablePathBox_TextChanged);
            // 
            // TextPathLibrary
            // 
            this.TextPathLibrary.AutoSize = true;
            this.TextPathLibrary.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextPathLibrary.Location = new System.Drawing.Point(6, 91);
            this.TextPathLibrary.Name = "TextPathLibrary";
            this.TextPathLibrary.Size = new System.Drawing.Size(87, 13);
            this.TextPathLibrary.TabIndex = 5;
            this.TextPathLibrary.Text = "Path to .dll file(s):";
            // 
            // AddingLibrary
            // 
            this.AddingLibrary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(110)))), ((int)(((byte)(166)))));
            this.AddingLibrary.Enabled = false;
            this.AddingLibrary.FlatAppearance.BorderSize = 0;
            this.AddingLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddingLibrary.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.AddingLibrary.Location = new System.Drawing.Point(437, 235);
            this.AddingLibrary.Name = "AddingLibrary";
            this.AddingLibrary.Size = new System.Drawing.Size(90, 31);
            this.AddingLibrary.TabIndex = 7;
            this.AddingLibrary.TabStop = false;
            this.AddingLibrary.Text = "Add Dlls";
            this.AddingLibrary.UseVisualStyleBackColor = false;
            this.AddingLibrary.Click += new System.EventHandler(this.AddingLibrary_Click);
            // 
            // StatusMessage
            // 
            this.StatusMessage.AutoSize = true;
            this.StatusMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.StatusMessage.Location = new System.Drawing.Point(7, 273);
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.Size = new System.Drawing.Size(0, 13);
            this.StatusMessage.TabIndex = 8;
            // 
            // DragDropHelper
            // 
            this.DragDropHelper.AutoSize = true;
            this.DragDropHelper.ForeColor = System.Drawing.Color.DimGray;
            this.DragDropHelper.Location = new System.Drawing.Point(419, 94);
            this.DragDropHelper.Name = "DragDropHelper";
            this.DragDropHelper.Size = new System.Drawing.Size(110, 13);
            this.DragDropHelper.TabIndex = 9;
            this.DragDropHelper.Text = "[Drag and Drop file(s)]";
            // 
            // RussianMessage
            // 
            this.RussianMessage.AutoPopDelay = 5000;
            this.RussianMessage.InitialDelay = 200;
            this.RussianMessage.ReshowDelay = 100;
            // 
            // RepackLogBox
            // 
            this.RepackLogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.RepackLogBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RepackLogBox.ContextMenuStrip = this.MenuLog;
            this.RepackLogBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.RepackLogBox.Location = new System.Drawing.Point(9, 293);
            this.RepackLogBox.MaxLength = 99999999;
            this.RepackLogBox.Multiline = true;
            this.RepackLogBox.Name = "RepackLogBox";
            this.RepackLogBox.ReadOnly = true;
            this.RepackLogBox.Size = new System.Drawing.Size(518, 119);
            this.RepackLogBox.TabIndex = 10;
            this.RepackLogBox.TabStop = false;
            this.RussianMessage.SetToolTip(this.RepackLogBox, "Вывод операций по перепаковки сборки");
            this.RepackLogBox.TextChanged += new System.EventHandler(this.RepackLogBox_TextChanged);
            // 
            // MenuLog
            // 
            this.MenuLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.MenuLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearLog});
            this.MenuLog.Name = "MenuDll";
            this.MenuLog.ShowImageMargin = false;
            this.MenuLog.ShowItemToolTips = false;
            this.MenuLog.Size = new System.Drawing.Size(94, 26);
            // 
            // ClearLog
            // 
            this.ClearLog.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.ClearLog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClearLog.Name = "ClearLog";
            this.ClearLog.Size = new System.Drawing.Size(93, 22);
            this.ClearLog.Text = "Clear log";
            this.ClearLog.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // LibraryPathBox
            // 
            this.LibraryPathBox.AllowDrop = true;
            this.LibraryPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.LibraryPathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LibraryPathBox.ContextMenuStrip = this.MenuDll;
            this.LibraryPathBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LibraryPathBox.FormattingEnabled = true;
            this.LibraryPathBox.Location = new System.Drawing.Point(9, 110);
            this.LibraryPathBox.Name = "LibraryPathBox";
            this.LibraryPathBox.Size = new System.Drawing.Size(518, 119);
            this.LibraryPathBox.TabIndex = 13;
            this.LibraryPathBox.TabStop = false;
            this.RussianMessage.SetToolTip(this.LibraryPathBox, "Список .dll файлов которые требуется добавить в сборку.\r\nПереместите в это поле ф" +
        "айл .dll для добавления");
            this.LibraryPathBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.LibraryPathBox_DragDrop);
            this.LibraryPathBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.LibraryPathBox_DragEnter);
            // 
            // MenuDll
            // 
            this.MenuDll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.MenuDll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectDelete,
            this.AllClean});
            this.MenuDll.Name = "MenuDll";
            this.MenuDll.ShowImageMargin = false;
            this.MenuDll.ShowItemToolTips = false;
            this.MenuDll.Size = new System.Drawing.Size(159, 48);
            // 
            // SelectDelete
            // 
            this.SelectDelete.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.SelectDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelectDelete.Name = "SelectDelete";
            this.SelectDelete.Size = new System.Drawing.Size(158, 22);
            this.SelectDelete.Text = "Delete selected .dll file";
            this.SelectDelete.Click += new System.EventHandler(this.SelectDelete_Click);
            // 
            // AllClean
            // 
            this.AllClean.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.AllClean.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AllClean.Name = "AllClean";
            this.AllClean.Size = new System.Drawing.Size(158, 22);
            this.AllClean.Text = "Clear all";
            this.AllClean.Click += new System.EventHandler(this.AllClean_Click);
            // 
            // RepackLogText
            // 
            this.RepackLogText.AutoSize = true;
            this.RepackLogText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RepackLogText.Location = new System.Drawing.Point(449, 277);
            this.RepackLogText.Name = "RepackLogText";
            this.RepackLogText.Size = new System.Drawing.Size(76, 13);
            this.RepackLogText.TabIndex = 11;
            this.RepackLogText.Text = "Repacking log";
            // 
            // VersionNet
            // 
            this.VersionNet.AutoSize = true;
            this.VersionNet.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.VersionNet.Location = new System.Drawing.Point(399, 46);
            this.VersionNet.Name = "VersionNet";
            this.VersionNet.Size = new System.Drawing.Size(0, 13);
            this.VersionNet.TabIndex = 14;
            // 
            // ILFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(537, 424);
            this.Controls.Add(this.VersionNet);
            this.Controls.Add(this.LibraryPathBox);
            this.Controls.Add(this.RepackLogText);
            this.Controls.Add(this.RepackLogBox);
            this.Controls.Add(this.DragDropHelper);
            this.Controls.Add(this.StatusMessage);
            this.Controls.Add(this.AddingLibrary);
            this.Controls.Add(this.TextPathLibrary);
            this.Controls.Add(this.ExecutablePathBox);
            this.Controls.Add(this.TextPathBinary);
            this.Controls.Add(this.CompileBuild);
            this.Controls.Add(this.AddingExecutable);
            this.Controls.Add(this.UPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ILFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ILibPacker by r3xq1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ILFrm_Load);
            this.UPanel.ResumeLayout(false);
            this.UPanel.PerformLayout();
            this.MenuLog.ResumeLayout(false);
            this.MenuDll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel UPanel;
        private System.Windows.Forms.Label LogoText;
        private System.Windows.Forms.Button ExitApp;
        private System.Windows.Forms.Button AddingExecutable;
        private System.Windows.Forms.Button CompileBuild;
        private System.Windows.Forms.Label TextPathBinary;
        private System.Windows.Forms.TextBox ExecutablePathBox;
        private System.Windows.Forms.Label TextPathLibrary;
        private System.Windows.Forms.Button AddingLibrary;
        private System.Windows.Forms.Label StatusMessage;
        private System.Windows.Forms.Label DragDropHelper;
        private System.Windows.Forms.ToolTip RussianMessage;
        private System.Windows.Forms.TextBox RepackLogBox;
        private System.Windows.Forms.Label RepackLogText;
        private System.Windows.Forms.ContextMenuStrip MenuDll;
        private System.Windows.Forms.ToolStripMenuItem SelectDelete;
        private System.Windows.Forms.ToolStripMenuItem AllClean;
        private System.Windows.Forms.ListBox LibraryPathBox;
        private System.Windows.Forms.ContextMenuStrip MenuLog;
        private System.Windows.Forms.ToolStripMenuItem ClearLog;
        private System.Windows.Forms.Label VersionNet;
    }
}

