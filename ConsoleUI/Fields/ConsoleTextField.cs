using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arena;
using ArenaBase;

namespace ConsoleUI
{
    public class ConsoleTextField
    {
        public string PreviousMsg { get; set; }
        public string Msg { get; set; }
        public System.ConsoleColor? Color { get; set; }
        public Coordinates Location { get; set; }
    }
}
