using System;

namespace ArenaBase
{
    public class BaseTile
    {
        public Coordinates Location { get; set; }
        public Char Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ConsoleColor? Color { get; set; }
    }
}
