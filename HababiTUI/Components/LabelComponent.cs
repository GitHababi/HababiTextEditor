using HababiTUI.Containers;
using HababiTUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Components;

public class LabelComponent : Component
{

    /// <summary>
    /// Note: This won't update the label's Text until Draw() has been called.
    /// </summary>
    public string Text { get; set; }

    public LabelComponent(Rect position, Container parentContainer, ConsolePalette palette, string text) : base(position, parentContainer, palette)
    {
        this.Text = text;
    }

    public LabelComponent(Rect position, Container parentContainer, string text) : base(position, parentContainer)
    {
        this.Text = text;
    }

    public override void Draw()
    {
        ConsoleHelper.SetPalette(Palette);
        ConsoleHelper.SmartWrite(Text,ParentContainer.Position + this.Position);
    }

    public override void HandleInput(ConsoleKeyInfo key)
    {
    }

    public override bool Selectable() => false;

    protected override void OnSelectionChanged(bool state)
    {
    }
}
