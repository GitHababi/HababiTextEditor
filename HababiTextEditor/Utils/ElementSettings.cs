using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTE.Utils
{
    public record ElementSettings(InputManager Manager, int X = 0, int Y = 0 , ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black);
    
}
