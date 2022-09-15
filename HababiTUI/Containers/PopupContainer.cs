using HababiTUI.Components;
using HababiTUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Containers;

public class PopupContainer : Container
{
    public LabelComponent Message { get; private set; }
    public PopupContainer(Rect position, Container parent, ConsolePalette palette, string message) : base(position, parent, palette)
    {
        var messagePos = new Rect((Position.width - message.Length) / 2, 2);
        Message = new(messagePos, this, palette, message);
        Components.Add(Message);
        Components.Add(new DefaultComponent(this));
        Palette = palette;
    }
    public PopupContainer(Rect position, Container parent, string message) : base(position, parent,parent.Palette)
    {
        var messagePos = new Rect((Position.width - message.Length) / 2, 2);
        Message = new(messagePos, this, parent.Palette, message);
        Components.Add(Message);
    }

    protected override void DrawThis()
    {
        ConsoleHelper.SetPalette(Palette);
        ConsoleHelper.DrawEmptyRect(Position);
        ConsoleHelper.DrawDoubleBox(Position);
    }
}
