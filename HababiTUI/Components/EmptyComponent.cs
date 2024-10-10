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
public class EmptyComponent : Component
{ 
    public EmptyComponent(Container parentContainer) : base(new(), parentContainer)
    {
    }

    public override void Draw()
    {
    }

    public override void HandleInput(ConsoleKeyInfo key)
    {
        ParentContainer.Navigate(key);
    }

    protected override void OnSelectionChanged(bool state)
    {
    }

    public override bool Selectable() => true;
}
