using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HababiTUI.Containers;
using HababiTUI.Graphics;
using HababiTUI.Utils;

namespace HababiTUI.Elements
{
    /// <summary>
    /// Class that represents all objects in a container
    /// </summary>
    public abstract class Component
    {
        public Rect Position { get; init; }
        public Container ParentContainer { get; init; } 
        
        private bool _selected;
        public bool Selected { get => _selected; set { SelectionChanged(value); _selected = value; } }

        public readonly bool Selectable;

        public Component(Rect position, Container parentContainer)
        {
            Position = position;
            ParentContainer = parentContainer;
        }

        protected abstract void SelectionChanged(bool state);
        public abstract void HandleInput(ConsoleKeyInfo key);
        public abstract void Draw();

    }
}
