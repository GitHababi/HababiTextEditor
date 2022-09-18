using HababiTUI.Components;
using HababiTUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Containers;

public class PopupContainer : Container
{
    public LabelComponent Message { get; private set; }
    public ButtonComponent Button { get; private set; }
    public PopupContainer(Rect position, Container parent, ConsolePalette palette, string message, string buttonText) : base(position, parent, palette)
    {
        var messagePos = new Rect((Position.width - message.Length) / 2, 2);
        Message = new(messagePos, this, palette, message);
        Button = new(new Rect((Position.width - buttonText.Length) / 2, 4), this, palette, buttonText);
        Palette = palette;

        Components.Add(Button);
        Components.Add(Message);
    }
    public PopupContainer(Rect position, Container parent, string message, string buttonText) : base(position, parent,parent.Palette)
    {
        var messagePos = new Rect((Position.width - message.Length) / 2, 2);
        Message = new(messagePos, this, parent.Palette, message);
        Button = new(new Rect((Position.width - buttonText.Length) / 2,4), this, parent.Palette, buttonText);

        Components.Add(Button);
        Components.Add(Message);
    }

    protected override void DrawThis()
    {
        ConsoleHelper.DrawDoubleBox(Position);
    }
}
