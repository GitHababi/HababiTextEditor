using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTE.Elements;
using HTE.Graphics;
namespace HTE.Elements
{
    public class InputManagerElement : Element
    {
        private readonly ConsoleWindow window;
        private Element focus;
        private StringElement text;
        private Thread inputLoop;
        private bool takeInput;
        public InputManagerElement(string id, ConsoleWindow window) : base(id, 0, 0, ConsoleColor.Black, ConsoleColor.Black)
        {
            this.window = window;
            this.takeInput = true;
            this.text = new(id + "text", 1, window.Height - 1, "", ConsoleColor.Black, ConsoleColor.White);
            this.focus = this;
            ThreadStart threadStart = new(this.InputListen);
            inputLoop = new(threadStart); // mfw no events for taking console input
            inputLoop.Start();
        }

        ~InputManagerElement()
        {
            inputLoop.Join(); // kill input taking on exit
        }

        public void SetFocus(Element element)
        {
            this.focus = element;
        }

        public override void RecieveInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Escape)
                takeInput = false;
            window.RemoveComponent(text)
                  .AddComponent(text = new(Id + "text", 0, window.Height - 1, $"INPUT: {key.KeyChar}", ConsoleColor.Black, ConsoleColor.White))
                  .Refresh();
        }

        private void InputListen()
        {
            while (takeInput)
            {
                if (focus != null)
                    focus.RecieveInput(Console.ReadKey(true));
                else
                    focus = this;
            }
        }
    }
}
