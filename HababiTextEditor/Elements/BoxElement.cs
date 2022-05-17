using HTE.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTE.Elements
{
    public class BoxElement : Element
    {
        protected readonly int width;
        protected readonly int height;
        public BoxElement(string id, int x, int y, int width, int height, ConsoleColor fg, ConsoleColor bg) : base(id, x, y, fg, bg)
        {
            this.width = width;
            this.height = height;
        }


        /// <summary>
        /// Draws the box element aligned to the top left.
        /// </summary>
        public override void Draw()
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");

            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);
                Console.Write("║");
            }

            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(x + width - 1, y + 1 + i);
                Console.Write("║");
            }

            Console.SetCursorPosition(x, y + height - 1);
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
            Console.ResetColor();
        }
    }
}
