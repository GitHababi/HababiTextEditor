using HababiTUI.Containers;
using HababiTUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Components;

public class ToggleButtonComponent : Component
{

    public bool Toggled { get; set; }
    public string Text { get; set; }

    public Action<bool> OnPressed { get; set; } = (state) => { };

    public ToggleButtonComponent(Rect position, Container parentContainer, string text) : base(position, parentContainer)
    {
        Text = text;
    }

    public ToggleButtonComponent(Rect position, Container parentContainer, ConsolePalette palette, string text) : base(position, parentContainer, palette)
    {
        Text = text;
    }

    public override void Draw()
    {
        if (Selected)
            ConsoleHelper.SetPalette(ConsolePalette.Invert(Palette));
        else
            ConsoleHelper.SetPalette(Palette);
        if (Toggled)
            ConsoleHelper.SmartWrite($"[■] {Text}", Position);
        else
            ConsoleHelper.SmartWrite($"[ ] {Text}", Position);
    }

    public override void HandleInput(ConsoleKeyInfo key)
    {
        if (ParentContainer.Navigate(key))
        {
            Toggled = !Toggled;
            Draw();
            OnPressed.Invoke(Toggled);
        }
    }

    public override bool Selectable() => true;

    protected override void OnSelectionChanged(bool state)
    {
        Draw();
    }
}
