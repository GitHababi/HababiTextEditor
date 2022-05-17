using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTE.Graphics;
namespace HTE.Elements
{
    /// <summary>
    /// Class that represents all objects in the console window
    /// </summary>
    public abstract class Element
    {
        protected readonly int x;
        protected readonly int y;
        protected readonly ConsoleColor foreground;
        protected readonly ConsoleColor background;
        public readonly string Id;
        public virtual void Draw() { }
        public virtual void RecieveInput(ConsoleKeyInfo key) { }
        public Element(string id, int x, int y, ConsoleColor fg, ConsoleColor bg)
        {
            this.Id = id;
            this.x = x;
            this.y = y;
            foreground = fg;
            background = bg;
        }

    }
}
