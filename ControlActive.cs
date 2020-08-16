namespace ILibPack
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public static class ControlActive
    {
        private static void Active(Label l, int timer, bool visible = false)
        {
            try
            {
                Task.Run(() =>
                {
                    Thread.Sleep(timer);
                    l.Invoke((Action)(() => l.Visible = visible));
                });
            }
            catch { }
        }
        public static void CheckMessage(Label MessageShow, string Text, Color color, int timer, bool True = true)
        {
            MessageShow.Visible = True;
            Active(MessageShow, timer);
            MessageShow.ForeColor = color;
            MessageShow.Text = Text;
        }
    }
}
