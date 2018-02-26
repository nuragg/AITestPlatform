using System;
using Arena;
using ArenaBase;

namespace ConsoleUI
{
    public class ConsoleMapWindow : ConsoleWindowBase
    {
        MapsContainer ArenaContainer { get; set; }
        private ConsoleMapBuffer _buffer;

        public ConsoleMapWindow(WindowType type, MapsContainer container)
            : base(type)
        {
            ArenaContainer = container;
            _buffer = new ConsoleMapBuffer();
        }

        public override void Draw()
        {
            ConsoleWriter.Write(Location,_buffer.GetBufferedTiles(ArenaContainer.GetFinalTiles()));
        }

        public override void ProcessInput()
        {
            Response = SelectInput(Input.GetKey());
            NeedsRedrawing = Response != null? Response.Redraw : false;
        }

        public override Coordinates GetCurrentCursorLocation()
        {
            return ArenaContainer.GetPlayer().Location;
        }
        
        private InputResponse SelectInput(ConsoleKeyInfo keyInfo)
        {
            switch(keyInfo.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.S:
                case ConsoleKey.A:
                case ConsoleKey.D:
                    return ProcessActorInput(keyInfo.Key);
                case ConsoleKey.Escape:
                    return ProcessWindowInput(keyInfo.Key);
                default:
                    return null;
            }
        }

        private InputResponse ProcessActorInput(ConsoleKey Key)
        {
            var player = ArenaContainer.GetPlayer();
            return player.ProcessArenaInput(Key, ArenaContainer);
        }

        private InputResponse ProcessWindowInput(ConsoleKey key)
        {
            return null;
        }

        public override void SetResponse(InputResponse response)
        {
            
        }
    }
}
