using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Graphics
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
                else if (c == '\r')
                    Console.SetCursorPosition(x, y);
            }
        }

        /// <summary>
        /// Erases the text as if it was printed relatively.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        public static void EraseText(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                    Console.SetCursorPosition(x, y++);
                else
                    Console.Write(' ');
            }
        }

        /// <summary>
        /// It's like an eraser!
        /// </summary>
        public static void DrawEmptyRect(int x, int y, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < width; j++)
                {
                    Console.Write(' ');
                }
            }
        }
    }
}
