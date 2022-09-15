using HababiTUI.Containers;
using HababiTUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Components;

/// <summary>
/// A blank component that is selectable
/// </summary>
public class DefaultComponent : Component
{ 
    public DefaultComponent(Container parentContainer) : base(new(), parentContainer)
    {
    }

    public override void Draw(Rect relativeTo)
    {
    }

    public override void HandleInput(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.Escape)
            this.ParentContainer.ForceStop();
    }

    protected override void ChangeSelection(bool state)
    {
    }

    public override bool Selectable() => true;
}
