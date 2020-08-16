namespace ILibPack
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            using (new Mutex(true, string.Concat(@"Local\{", Helpers.MutEx.GetGUID(), "}"), out bool flag))
            {
                if (flag)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ILFrm());
                }
            }
        }
    }
}