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
        
        private readonly InputManager inputManager;
        private bool _listening;
        /// <summary>
        /// Toggle key press listening from <see cref="InputManager"/> source
        /// </summary>
        public void ToggleInputListen()
        {
            if (_listening)
                inputManager.OnKeyPressed -= this.RecieveInput;
            else
                inputManager.OnKeyPressed += this.RecieveInput;
            _listening = !_listening;
        }
        public virtual void Draw() { }
        public virtual void RecieveInput(ConsoleKeyInfo key) { }
        public Element(ElementSettings settings)
        {
            this.x = settings.X;
            this.y = settings.Y;
            foreground = settings.fg;
            background = settings.bg;
            inputManager = settings.Manager;
            _listening = false;

        }
    }
}
