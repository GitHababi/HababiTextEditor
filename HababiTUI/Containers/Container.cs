using HababiTUI.Components;
using HababiTUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Containers
{
    /// <summary>
    /// A window in which all  <see cref="Components"/> are rendered and interacted through.
    /// </summary>
    public abstract class Container
    {
        public ConsolePalette Palette { get; set; }
        public Rect Position { get; init; }
        
        public List<Component> Components { get; protected set; } = new();
        protected Component? Selected;
        public Container? ParentContainer { get; init; }

        public Container(Rect position, Container? parent, ConsolePalette palette)
        {
            Palette = palette;
            Position = position;
            ParentContainer = parent;
        }
        public Container(Rect position, Container? parent)
        {
            Palette = ConsolePalette.Default;
            Position = position;
            ParentContainer = parent;
        }

        public void SelectComponent(Component component)
        {
            if (component.Selectable() && component.ParentContainer == this)
            {
                if (Selected != null)
                {
                    Selected.Selected = false;
                }
                Selected = component;
                component.Selected = true;
            }
            
        }

        public void Unselect()
        {
            if (Selected != null)
            {
                Selected.Selected = false;
                Selected = null;
            }
        }

        /// <summary>
        /// To be called on HandleInput of a component for expected and normal menu behavior.
        /// </summary>
        /// <param name="key">The key that was pressed</param>
        /// <returns>If the 'Select' or 'Confirm' option was pressed.</returns>
        
        public bool Navigate(ConsoleKeyInfo key) 
        {
            if (Selected == null)
                return false;

            Component? destination = null;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    destination = Selected.Top;
                    break;
                case ConsoleKey.DownArrow:
                    destination = Selected.Bottom;
                    break;
                case ConsoleKey.LeftArrow:
                    destination = Selected.Left;
                    break;
                case ConsoleKey.RightArrow:
                    destination = Selected.Right;
                    break;
                case ConsoleKey.Enter:
                    return true;
            }
            if (destination != null)
                SelectComponent(destination);
            return false;
        }

        private bool _exit;
        public void ForceStop()
        {
            _exit = true;
        }

        public void DrawAll()
        {
            if (ParentContainer != null)
                ParentContainer.DrawAll();

            ConsoleHelper.SetPalette(Palette);
            ConsoleHelper.DrawEmptyRect(Position);

            DrawThis();

            foreach (var component in Components)
                component.Draw();
        }

        protected abstract void DrawThis();

        public void Activate()
        {
            _exit = false;
            DrawAll();
            SelectComponent(Components.FirstOrDefault(x => x.Selectable()) ?? new DefaultComponent(this));
            while (!_exit && !UI.Stopped)
            {
                if (Selected != null)
                {
                    Selected.HandleInput(Console.ReadKey(true));
                }
            }
            if (ParentContainer != null)
                ParentContainer.DrawAll();
        }
    }
}
