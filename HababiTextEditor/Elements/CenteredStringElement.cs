using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTE.Elements
{
    public class CenteredStringElement : StringElement
    {
        public CenteredStringElement(string id, int x, int y, string text, ConsoleColor fg, ConsoleColor bg) : base(id, x, y, text, fg, bg)
        {
        }

        public override void Draw()
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.SetCursorPosition(x - text.Length / 2, y);
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
