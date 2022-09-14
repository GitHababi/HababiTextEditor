using HababiTUI.Elements;
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
        public Rect Position { get; init; }
        
        public List<Component> Components = new();
        protected Component Selected;
        public Container ParentContainer { get; init; }

        public Container(Rect position, Container parent)
        {
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
                component.Draw();

            // TODO: next line may not be necessary
            if (Selected != null)
                Selected.Selected = true;
        }

        protected abstract void DrawThis();

        public void Activate()
        {
            while (!_exit)
            {
                if (Selected != null)
                    Selected.HandleInput(Console.ReadKey(false));
            }
        }
    }
}
