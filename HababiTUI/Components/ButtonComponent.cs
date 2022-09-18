using HababiTUI.Containers;
using HababiTUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Components
{
    public class ButtonComponent : Component
    {
        public Action OnPressed { get; set; }
        public string Text { get; set; }
        public ButtonComponent(Rect position, Container parentContainer, ConsolePalette palette, string text) : base(position, parentContainer, palette)
        {
            Text = text;
        }
        public ButtonComponent(Rect position, Container parentContainer, string text) : base(position, parentContainer)
        {
            Text = text;
        }

        public override void Draw()
        {
            if (Selected)
                ConsoleHelper.SetPalette(ConsolePalette.Invert(Palette));
            else
                ConsoleHelper.SetPalette(Palette);
            var position = new Rect(ParentContainer.Position.x + Position.x - 1, ParentContainer.Position.y + Position.y, Text.Length + 2, 1);
            ConsoleHelper.DrawEmptyRect(position);
            ConsoleHelper.SmartWrite($"[{Text}]", position);
        }

        public override void HandleInput(ConsoleKeyInfo key)
        {
            if (ParentContainer.Navigate(key))
                OnPressed.Invoke();
        }

        public override bool Selectable() => true;

        protected override void OnSelectionChanged(bool state)
        {
            Draw();
        }
    }
}
