using HTE.Elements;
using HTE.Utils;
using HTE.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTE.Elements
{
    public class StringElement : Element
    {
        private string text;
        private string _previousText;
        public string Text { get { return text; } set { _previousText = text;  text = value; } }
        
        public StringElement(ElementSettings settings, string text) : base(settings)
        {
            this._previousText = "";
            this.text = text;
        }
        public override void Draw()
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            ConsoleHelper.EraseText(x,y, _previousText);
            Console.SetCursorPosition(x, y);
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
