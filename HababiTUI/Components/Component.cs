using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HababiTUI.Containers;
using HababiTUI.Utils;

namespace HababiTUI.Components;

/// <summary>
/// Class that represents all objects in a container
/// </summary>
public abstract class Component
{
    public ConsolePalette Palette { get; set; } = ConsolePalette.Default;
    public Rect Position { get; init; }
    public Container ParentContainer { get; init; } 
    
    private bool _selected;
    public bool Selected { get => _selected; set { ChangeSelection(value); _selected = value; } }


    public Component(Rect position, Container parentContainer)
    {
        Position = position;
        ParentContainer = parentContainer;
    }

    protected abstract void ChangeSelection(bool state);
    public abstract void HandleInput(ConsoleKeyInfo key);
    public abstract void Draw(Rect relativeTo);
    public abstract bool Selectable();

}
