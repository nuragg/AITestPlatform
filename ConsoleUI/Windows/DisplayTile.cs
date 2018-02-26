using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArenaBase
{
    public class DisplayTile
    {
        public char Icon { get; set; }
        public ConsoleColor? Color { get; set; }
        public bool SkipThisTile { get; set;  }
    }
}
