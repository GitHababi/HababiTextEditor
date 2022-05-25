using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTE.Elements;
using HTE.Graphics;
namespace HTE.Utils
{
    public class InputManager
    {
        private readonly ConsoleWindow window;
        private readonly StringElement text;
        private readonly Thread inputLoop;
        private string inputbuffer;

        public event KeyPressHandler OnKeyPressed;
        public event NewLineHandler OnNewLine;
        public InputManager(ConsoleWindow window)
        {
            inputbuffer = "";
            this.window = window;
            text = new(new(this,1, window.Height - 1, ConsoleColor.Black, ConsoleColor.White), "");
            ThreadStart threadStart = new(InputListen);
            inputLoop = new(threadStart); // mfw no events for taking console input
            inputLoop.Start();
            OnKeyPressed += RecieveInput;
        }

        ~InputManager()
        {
            inputLoop.Join(); // kill input taking on exit
        }

        public void RecieveInput(ConsoleKeyInfo key)
        {
            if (OnKeyPressed.GetInvocationList().Length > 1)
                return;
            switch (key.Key)
            {
                case ConsoleKey.F4:
                    Environment.Exit(-1); // -1 indicates abortion!
                    OnKeyPressed -= RecieveInput;
                    break;
                case ConsoleKey.Backspace:
                    if (inputbuffer.Length > 0)
                        inputbuffer = inputbuffer[..^1];
                    break;
                case ConsoleKey.Enter:
                    OnNewLine.Invoke(inputbuffer);
                    inputbuffer = "";
                    break;
                default:
                    if (!char.IsControl(key.KeyChar))
                        inputbuffer += key.KeyChar;
                    break;
            }
            ConsoleHelper.DrawEmptyRect(0, window.Height - 1, window.Width, 1);
            text.Text = $"INPUT: {inputbuffer}";
            text.Draw();
        }

        private void InputListen()
        {
            while (OnKeyPressed != null)
            {
                OnKeyPressed.Invoke(Console.ReadKey(true));
            }
        }
    }
}
