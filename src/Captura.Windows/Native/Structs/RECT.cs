﻿using System;
using System.Runtime.InteropServices;

namespace Captura.Native
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(int Dimension)
        {
            Left = Top = Right = Bottom = Dimension;
        }
    }
}
