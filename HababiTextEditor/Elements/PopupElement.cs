using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTE.Graphics;

namespace HTE.Elements
{
    public class PopupElement : Element
    {
        private readonly CenteredStringElement message;
        private readonly BoxElement box;
        private readonly ConsoleWindow window;
        public PopupElement(string id, int x, int y, string message, ConsoleColor fg, ConsoleColor bg, ConsoleWindow window) : base(id, x, y, fg, bg)
        {
            this.message = new("",x, y, message, fg, bg);
            this.window = window;
            this.box = new("",x - message.Length / 2 - 1, y - 1, message.Length + 2, 3, fg, bg);
        }

        public override void Draw()
        {
            box.Draw();
            message.Draw();
        }

        public override void RecieveInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Enter)
            {
                window.RemoveComponent(this)
                      .InputManager.SetFocus(window.InputManager);
                window.Clear()
                      .Refresh();
            }
        }
    }
}
