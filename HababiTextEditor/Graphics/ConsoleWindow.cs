using HTE.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTE.Graphics
{
    public class ConsoleWindow
    {
        public int Width { get; private init; }
        public int Height { get; private init; }
        public InputManagerElement InputManager { get; private set; }

        private Dictionary<string,Element> components;

        public ConsoleWindow(int width, int height)
        {
            components = new();
            InputManager = new InputManagerElement("inputmanager", this);
            Width = width;
            Height = height;
            Console.CursorVisible = false;
        }

        public ConsoleWindow Refresh()
        {
            foreach (var component in components) // WARNING: This is not thread safe
            {
                component.Value.Draw();
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
            components.Add(component.Id, component);
            return this;
        }
        public ConsoleWindow RemoveComponent(Element component)
        {
            components.Remove(component.Id);
            return this;
        }
    }
}
