using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTE.Utils;
using HTE.Graphics;
namespace HTE.Elements
{
    internal class SelectableListElement : BoxElement
    {
        public event ListOptionHandler OnSelected;
        private readonly List<ListOption> _options;
        private int _renderIndex;
        private int _selectedIndex;
        public SelectableListElement(ElementSettings settings, int width, int height, List<ListOption> options) : base(settings, width, height)
        {
            _renderIndex = 0;
            _selectedIndex = 0;
            _options = options;
        }

        public override void Draw()
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            ConsoleHelper.DrawEmptyRect(x, y, width, height);
            Console.SetCursorPosition(x + 1, y + 1);
            for (int i = _renderIndex; i < _options.Count && i < height + _renderIndex - 2; i++)
            {
                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = background;
                    Console.BackgroundColor = foreground;
                    Console.Write(FitText(_options[i].Name));
                    Console.BackgroundColor = background;
                    Console.ForegroundColor = foreground;
                }
                else
                    Console.Write(FitText(_options[i].Name));
                Console.CursorTop += 1;
                Console.CursorLeft = x + 1;
            }
            base.Draw();
        }
        
        private string FitText(string text)
        {
            if (text.Length < width - 2)
                return text;
            else
                return text[..(width - 2)];
        }
        
        public override void RecieveInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    ToggleInputListen();
                    break;
                case ConsoleKey.UpArrow:
                    if (_selectedIndex > 0)
                        _selectedIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    if (_selectedIndex < _options.Count - 1)
                        _selectedIndex++;
                    break;
                case ConsoleKey.Enter:
                    OnSelected.Invoke(_options[_selectedIndex]);
                    break;
            }
            if (_selectedIndex < _renderIndex)
                _renderIndex = _selectedIndex;
            else if (_selectedIndex >= _renderIndex + height - 2)
                _renderIndex = _selectedIndex - height + 3;
            Draw();
        }
    }
}
