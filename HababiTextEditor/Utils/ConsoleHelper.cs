using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTE.Utils
{
    public static class ConsoleHelper
    {
        
        public static void WriteRelative(object obj, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            var str = obj.ToString();
            foreach (char c in str)
            {
                if (c != '\n' && c != '\r')
                    Console.Write(c);
                else if (c == '\n')
                    Console.SetCursorPosition(x, y = y + 1);
                else
                    Console.SetCursorPosition(x, y);
            }    
        }
    }
}
