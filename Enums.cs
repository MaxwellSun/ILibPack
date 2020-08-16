namespace ILibPack
{
    using System;

    internal class Enums
    {
        [Flags]
        public enum ExeType : int
        {
            None = 0,
            WinNT = 0x04000000,
            PE = 'P' | ('E' << 8),
            NE = 'N' | ('E' << 8),
            MZ = 'M' | ('Z' << 8),
        }
    }
}