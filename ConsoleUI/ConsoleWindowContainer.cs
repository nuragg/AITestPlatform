namespace ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArenaBase;
    using Interfaces;

    public class ConsoleWindowContainer : IConsoleWindowContainer
    {
        public IEnumerable<ConsoleWindowBase> WindowList { get; set; }
        private InputProcessor _inputProcessor;
       

        public ConsoleWindowContainer()
        {
            _inputProcessor = new InputProcessor();
       
        }
    
        public void DrawAll()
        {
            Clear();
            if (WindowList != null && WindowList.ToList().Count > 0)
            {
                WindowList.ToList().ForEach(x => x.Draw());
                var active = WindowList.FirstOrDefault(x => x.Active);
                if (active != null)
                    SetPromptLocation(active);
            }
            else
                throw new Exception("Windows container is empty!");
        }

        public void DisplayOutput()
        {
            var needsRedrawing = WindowList.Where(x => x.NeedsRedrawing && x.Enabled).ToList();
            if (needsRedrawing != null && needsRedrawing.Count() > 0)
            { 
                needsRedrawing.ToList().ForEach(x => x.Draw());
            } 

            var active = WindowList.FirstOrDefault(x => x.Active);
            if (active != null)
            SetPromptLocation(active);
        }

        public void ProcessInput()
        {
            _inputProcessor.ProcessInput(WindowList);
            DisplayOutput();
        }

        private void Clear()
        {
            Console.Clear();
        }

        private void SetPromptLocation(ConsoleWindowBase ActiveWindow)
        {
            var cursorLocation =  ActiveWindow.GetCurrentCursorLocation();
            var windoLocation = ActiveWindow.Location;
            var relativeLocation = Coordinates.NewCoord(windoLocation.X + cursorLocation.X, windoLocation.Y + cursorLocation.Y);

            Console.SetCursorPosition(relativeLocation.X, relativeLocation.Y);
        }

       // private void ProcessResponse(
    }
}
