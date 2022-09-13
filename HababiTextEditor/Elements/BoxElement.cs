using HTE.Elements;
using HTE.Utils;
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

        private string croppedTitle;
        public string Title
        {
            get 
            { 
                return croppedTitle; 
            }
            set
            {
                if (value.Length > width - 2)
                {
                    croppedTitle = value[..(width - 2)];
                }
                else
                {
                    croppedTitle = value;
                }
            }
        }
        public BoxElement(ElementSettings settings, int width, int height) : this(settings, width, height, "") {}

        public BoxElement(ElementSettings settings, int width, int height, string title) : base(settings)
        {
            this.width = width;
            this.height = height;
            Title = title;
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
            Console.SetCursorPosition(x + 1, y);
            Console.Write(croppedTitle);
            Console.ResetColor();
        }
    }
}
