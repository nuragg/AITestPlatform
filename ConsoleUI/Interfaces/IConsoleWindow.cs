using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    public interface IConsoleWindow
    {
        void Draw();
        void ProcessInput();

        bool NeedsRedrawing { get; set; }
        bool Enabled { get; set; }
        bool Active { get; set; }
    }
}
