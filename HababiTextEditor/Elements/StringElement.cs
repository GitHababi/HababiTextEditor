using HTE.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTE.Elements
{
    public class StringElement : Element
    {
        protected readonly string text;
        
        public StringElement(string id, int x, int y, string text, ConsoleColor fg, ConsoleColor bg) : base(id, x, y, fg, bg)
        {
            this.text = text;
        }
        public override void Draw()
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.SetCursorPosition(x, y);
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
