using HababiTUI.Elements;
using HababiTUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Graphics
{
    public class ConsoleWindow
    {
        public int Width { get; private init; }
        public int Height { get; private init; }
        public InputManager InputManager { get; private set; }

        private readonly List<Element> components;

        public ConsoleWindow(int width, int height)
        {
            components = new();
            Width = width;
            Height = height;
            Console.CursorVisible = false;
            InputManager = new InputManager(this);
        }

        public ConsoleWindow Refresh()
        {
            foreach (var component in components) // WARNING: This is not thread safe
            {
                component.Draw();
            }
            return this;
        }
        public ConsoleWindow Clear()
        {
            Console.Clear();
            return this;
        }

        public ConsoleWindow AddComponent(Element component)
        {
            components.Add(component);
            return this;
        }
        public ConsoleWindow RemoveComponent(Element component)
        {
            components.Remove(component);
            return this;
        }
    }
}
