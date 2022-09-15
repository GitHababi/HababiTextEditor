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
        
        protected List<Component> Components = new();
        protected Component Selected;
        public Container? ParentContainer { get; init; }

        public Container(Rect position, Container parent, ConsolePalette palette)
        {
            Palette = palette;
            Position = position;
            ParentContainer = parent;
        }
        public Container(Rect position, Container parent)
        {
            Palette = ConsolePalette.Default;
            Position = position;
            ParentContainer = parent;
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

            DrawThis();

            foreach (var component in Components)
                component.Draw(this.Position);

            // TODO: next line may not be necessary
            if (Selected != null)
                Selected.Selected = true;
        }

        protected abstract void DrawThis();

        public void Activate()
        {
            DrawAll();
            Selected = Components.FirstOrDefault(x => x.Selectable()) ?? new DefaultComponent(this);
            while (!_exit)
            {
                if (Selected != null)
                    Selected.HandleInput(Console.ReadKey(true));
            }
        }
    }
}
