using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTE.Graphics;
using HTE.Document;

namespace HTE.Elements
{
    public class TextBoxElement : BoxElement
    {
        private ConsoleWindow window;
        private Document.Document document;
        public TextBoxElement(string id, int x, int y, int width, int height, ConsoleColor fg, ConsoleColor bg, ConsoleWindow window) : base(id, x, y, width, height, fg, bg)
        {
            document = new();
            this.window = window; 
        }
        
        public override void Draw()
        {
            base.Draw();
            Console.SetCursorPosition(x + 1, y + 1);
        }
        public override void RecieveInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Backspace:
                    break;
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Escape:
                    window.InputManager.SetFocus(null);
                    break;
                case ConsoleKey.LeftArrow:
                    break;
                case ConsoleKey.RightArrow:
                    break;
                case ConsoleKey.UpArrow:
                    break;
                case ConsoleKey.DownArrow:
                    break;
                case ConsoleKey.Tab:
                    break;
                default:
                    break;
            }
        }

        internal class Cursor
        {
            int x { get; set; }
            int y { get; set; }

            Cursor(int x, int y, )
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
