using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    public static class UIMain
    {        


        //public static void Draw(ConsoleWindowBase CWB)
        //{
        //    if (CWB.DrawBorder && CWB.BorderSymbol !=null )            
        //        UIMain.DrawBorder(CWB);
           
        //    foreach (ConsoleTextField CTF in CWB.FieldList)
        //    {
        //        Console.SetCursorPosition(CTF.Location.X, CTF.Location.Y);
        //      //  if (CTF.Color != null)
        //        //    Console.ForegroundColor = CTF.Color;
        //        Console.WriteLine(CTF.Msg);
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //}
        
        //public static void DrawBorder(ConsoleWindowBase CWB)
        //{
        //    for (int i=0; i<CWB.Height;i++)
        //    {
        //        for (int j=0; j<CWB.Width; j++)
        //        {
        //            if (i==0 || i ==CWB.Height-1 )
        //            {
        //               Console.SetCursorPosition(CWB.Location.X+j,CWB.Location.Y+i);
        //               Console.Write(CWB.BorderSymbol);
        //            }
        //            else
        //            {
        //                if (j==0 || j==CWB.Width-1 )
        //                { 
        //                    Console.SetCursorPosition(CWB.Location.X+j,CWB.Location.Y+i);
        //                    Console.Write(CWB.BorderSymbol);
        //                }
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Splits text across ConsoleWindowBase lines
        /// </summary>
        private static void SplitMsg()
        {

        }


    }
}
