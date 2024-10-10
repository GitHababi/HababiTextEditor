using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Utils
{
    public class ScreenBuffer
    {
        /// <summary>
        /// The full screen buffer (using rn because the acutal console buffer isnt working with windows
        /// </summary>
        static internal ScreenBuffer instance;
        public char[,] BufferPixels { get; private set; }
        public Rect Position { get; private set; }
        public ScreenBuffer(Rect rect)
        {
            BufferPixels = new char[rect.height, rect.width];
            Position = rect;
        }

        internal static void Write(char c)
        {
            Console.Write(c);
            instance.BufferPixels[Console.CursorTop, Console.CursorLeft] = c;
        }
        internal static void Write(string s)
        {
            Console.Write(s);
            instance.BufferPixels[Console.CursorTop, Console.CursorLeft] = s[0];
        }

        public static ScreenBuffer GetBufferAt(Rect position) 
        {
            ScreenBuffer output = new(position);
            for (int i = 0; i < position.width; i++)
                for (int j = 0; j < position.height; j++)
                {
                    output.BufferPixels[i,j] = instance.BufferPixels[position.x + i, position.y + j];

                }
            return output;
        } 

        /// <summary>
        /// Replaces swaps the pixels of the buffer
        /// </summary>
        /// <returns>A buffer of what was replaced</returns>
        public ScreenBuffer Swap()
        {
            ScreenBuffer output = new(Position);
            for (int i = 0; i < Position.width; i++)
            {
                for (int j = 0; j < Position.height; j++)
                {
                    output.BufferPixels[i,j] = BufferPixels[i,j];
                    Console.SetCursorPosition(Position.x + i, Position.y + j);
                    Console.Write(BufferPixels[i, j]);
                }
            }
            return output;
        }

        public void Replace()
        {
            for (int i = 0; i < Position.width; i++)
            {
                for (int j = 0; j < Position.height; j++)
                {
                    Console.SetCursorPosition(Position.x + i, Position.y + j);
                }
            }
        }
    }
}
