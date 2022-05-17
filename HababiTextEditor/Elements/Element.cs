using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTE.Graphics;
using HTE.Utils;

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
        public Element(string id, ElementSettings settings)
        {
            this.Id = id;
            this.x = settings.X;
            this.y = settings.Y;
            foreground = settings.fg;
            background = settings.bg;
        }

    }
}
