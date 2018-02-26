using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArenaBase;

namespace ConsoleUI
{
    //TODO: gdzieś w tej klasie dorobić mechanike szybkiego wyświetlania znaków jeśli będzie taka potrzeba
    public static class ConsoleWriter
    {
        public static void Write(Coordinates location, DisplayTile[][] Tiles)
        {
            string test = string.Empty;
            //TODO: obslużyć kolory
            Console.SetCursorPosition(location.X, location.Y);
            for(int i=0; i<Tiles.Count(); i++)
            {
                if (Tiles[i][0].SkipThisTile)
                {
                    Console.SetCursorPosition(location.X, location.Y + i + 1);
                    continue;
                }

                string line = string.Empty;
                for (int j = 0; j < Tiles[i].Count(); j++)
                {
                    line += Tiles[i][j].Icon;
                }
                Console.WriteLine(line);
                test +=i.ToString()+", ";
            
              
                Console.SetCursorPosition(location.X, location.Y + i + 1);
            }
              //Console.SetCursorPosition(0, 0);
              //Console.WriteLine("                                                                                                                                               ");
              //Console.SetCursorPosition(0, 0);
              //Console.WriteLine("wrote line no: " + test);
        }
    }
}
