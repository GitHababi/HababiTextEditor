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
        private string _text;
        private readonly List<string> _renderableText;
        /// <summary>
        /// The text of the textbox.
        /// </summary>
        public string Text 
        {
            get { return _text; }
            set { _text = value; _renderableText.Clear(); _text.Split('\n').ToList().ForEach(str => FitText(str)); }
        }
        
        public TextBoxElement(ElementSettings settings, int width, int height, string text)
        : base(settings, width, height)
        {
            _renderableText = new();
            this.Text = text;
        }

        /// <summary>
        /// Draws the TextBox, if the Text is too long, it will not be cut off.
        /// </summary>
        public override void Draw()
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            ConsoleHelper.DrawEmptyRect(x, y, width, height);
            Console.CursorTop = y;
            for (int i = 0; i < _renderableText.Count && i < height - 2; i++)
            {
                ConsoleHelper.WriteRelative(_renderableText[i], x + 1, Console.CursorTop + 1);
            }
            base.Draw();
        }
        private void FitText(string text)
        {
            if (width - 2 < text.Length)
            {
                _renderableText.Add(text[..(width - 2)]);
                FitText(text[(width - 2)..]);
            }
            else
                _renderableText.Add(text);
        }
    }
}
