using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTE.Graphics;
using HTE.Document;
using HTE.Utils;

namespace HTE.Elements
{
    public class TextBoxElement : BoxElement
    {
        private string text;
        private Alignment alignment;

        /// <summary>
        /// The text of the textbox.
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; Draw(); }
        }

        /// <summary>
        /// The alignment of the Text within the TextBox
        /// </summary>
        public Alignment Alignment
        {
            get { return alignment; }
            set { alignment = value; Draw(); }
        }
        private ConsoleWindow window;
        
        public TextBoxElement(string id, ElementSettings settings, int width, int height, ConsoleWindow window, string text, Alignment alignment)
        : base(id, settings, width, height)
        {
            this.alignment = alignment;
            this.window = window;
            this.text = text;
        }

        /// <summary>
        /// Draws the TextBox, if the Text is too long, it will not be cut off.
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            if (Alignment == Alignment.Left)
                ConsoleHelper.WriteRelative(PadLeft(text), x + 1, y + 1);
            else if (Alignment == Alignment.Center)
                ConsoleHelper.WriteRelative(PadCenter(text), x + 1, y + 1);
            else if (Alignment == Alignment.Right)
                ConsoleHelper.WriteRelative(PadRight(text), x + 1, y + 1);
            

        }

        private string PadLeft(string text)
        {
            if (width - 2 < text.Length)
                return text[..(width - 2)] + "\n" + PadLeft(text[(width - 2)..]);
            return text;
        }

        private string PadCenter(string text)
        {
            if (width - 2 < text.Length)
                return text[..(width - 2)] + "\n" + PadCenter(text[(width - 2)..]);
            return new string(' ', (width - 2 - text.Length)/2) + text + new string(' ', (width - 2 - text.Length)/2);
        }

        private string PadRight(string text)
        {

            if (text.Length > width - 2)
                return text[..(width - 2)] + "\n" + PadRight(text[(width - 2)..]);
            return new string(' ', width - 2 - text.Length) + text;
        }
        public override void RecieveInput(ConsoleKeyInfo key)
        {

        }


    }
}
