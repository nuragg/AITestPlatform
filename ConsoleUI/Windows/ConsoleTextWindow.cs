using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class ConsoleTextWindow : ConsoleWindowBase
    {
        public ConsoleTextWindow(WindowType type)
            : base (type)
        {
            this.FieldList = new List<ConsoleTextField>();
            _consoleTextWindowBuffer = new ConsoleTextWindowBuffer();
        }

        public List<ConsoleTextField> FieldList { get; set; }
        private ConsoleTextWindowBuffer _consoleTextWindowBuffer;


        public override void Draw()
        {
            Console.SetCursorPosition(this.Location.X, this.Location.Y);
            if (this.DrawBorder && this.BorderSymbol != null)
                Border();

            foreach (ConsoleTextField CTF in this.FieldList)
            {
                Console.SetCursorPosition(this.Location.X + CTF.Location.X, this.Location.Y + CTF.Location.Y);
                if (CTF.Color != null)
                    Console.ForegroundColor = CTF.Color.Value;
                Console.Write(CTF.Msg);
                ClearField(CTF);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public override void ProcessInput()
        {
            //Input.ProcessInput(WindowType);
        }

        public override void SetResponse(InputResponse response)
        {
            FieldList[0].PreviousMsg = FieldList[0].Msg;
            FieldList[0].Msg = response.Msg;
            NeedsRedrawing = true;
            DrawBorder = false;
        }

        private void ClearField(ConsoleTextField ctf)
        {
            if (!string.IsNullOrEmpty(FieldList[0].PreviousMsg))
            {
                int diff = FieldList[0].PreviousMsg.Length - FieldList[0].Msg.Length;
                if (diff > 0)
                {
                    for (int i = 0; i < diff; i++)
                        Console.Write(' ');
                }
            }
        }
    }
}
