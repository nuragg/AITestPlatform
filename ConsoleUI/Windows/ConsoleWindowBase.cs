using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Arena;
using ArenaBase;

namespace ConsoleUI
{
    public class ConsoleWindowBase : IConsoleWindow
    {
        public WindowType WindowType {get; set;}
        public InputResponse Response { get; set; }

        public ConsoleWindowBase(WindowType type)
        {
            WindowType = type;
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public Coordinates Location { get; set; }

        public bool DrawBorder { get; set; }
        public char? BorderSymbol { get; set; }

        #region IConsoleWindow

        
        public bool NeedsRedrawing { get; set; }
        public bool Active { get; set; }
        public bool Enabled { get; set; }

        public virtual void Draw()
        {}

        public virtual void ProcessInput()
        {}

        public virtual Coordinates GetCurrentCursorLocation()
        {
            return null;
        }

        public virtual void SetResponse(InputResponse response)
        { }
        #endregion

        #region Methods
        public virtual void Border()
        {
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    if (i == 0 || i == this.Height - 1)
                    {
                        Console.SetCursorPosition(this.Location.X + j, this.Location.Y + i);
                        Console.Write(this.BorderSymbol);
                    }
                    else
                    {
                        if (j == 0 || j == this.Width - 1)
                        {
                            Console.SetCursorPosition(this.Location.X + j, this.Location.Y + i);
                            Console.Write(this.BorderSymbol);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
