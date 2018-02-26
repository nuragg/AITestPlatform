using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArenaBase;

namespace ConsoleUI
{
    public class InputResponse
    {
        public ConsoleWindowBase ResponseWindow { get; set; }
        public bool Redraw { get; set; }
        public string Msg { get; set; }
        public BaseActor Actor { get; set; }
        public BaseTile DestinationTile { get; set; }
        public BaseActor DestinationActor { get; set; }
        public WindowType MsgWindowType  {get; set; }
    }
}
