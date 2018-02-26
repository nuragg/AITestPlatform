using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    class InputProcessor
    {
        public void ProcessInput(IEnumerable<ConsoleWindowBase> WindowList)
        {
            var active = WindowList.FirstOrDefault(x => x.Active);
            if (active != null)
            {
                active.ProcessInput();
                ProcessResponse(active.Response, WindowList);
            }

            else
                throw new Exception("No active window detected!");
        }

        private void ProcessResponse(InputResponse response, IEnumerable<ConsoleWindowBase> WindowList)
        {
           SetMsgs(response, WindowList);
        }

        private void SetMsgs(InputResponse response, IEnumerable<ConsoleWindowBase> WindowList)
        {
            var window = WindowList.FirstOrDefault(x => x.WindowType == response.MsgWindowType);            
            if (window == null)
                return;

            window.SetResponse(response);
        }
    }
}
