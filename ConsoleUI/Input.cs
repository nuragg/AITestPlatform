using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    public static class Input
    {
        public static ConsoleKeyInfo GetKey()
        {
            return Console.ReadKey(true); 
        }

        public static string GetInput()
        {
            return Console.ReadLine();
        }   

        //public static void ProcessInput(WindowType type)
        //{
        //    switch(type)
        //    {
        //        case WindowType.Arena:
        //            ProcessArenaInput();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //private static void ProcessArenaInput()
        //{
        //    var key = Input.GetKey();
        //    switch (key.Key)
        //    {
        //        case ConsoleKey.W:
        //        case ConsoleKey.S:
        //        case ConsoleKey.A:
        //        case ConsoleKey.D:
        //            MoveRight(Actor);
        //            break;
        //        case ConsoleKey.Escape:
        //        default:
        //            break;
        //    }
        //}


       

    }
}