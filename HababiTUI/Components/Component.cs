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

    public Component Left { get; set; }
    public Component Right { get; set; }
    public Component Top { get; set; }
    public Component Bottom { get; set; }

    public static void SetTopBottomPair(Component top, Component bottom)
    {
        top.Bottom = bottom;
        bottom.Top = top;
    }
    
    public static void SetLeftRightPair(Component left, Component right)
    {
        left.Right = right;
        right.Left = left;
    }

    private bool _selected;
    public bool Selected 
    { 
        get => _selected; 
        set 
        { 
            _selected = value; 
            OnSelectionChanged(value);  
        } 
    }

    public Component(Rect position, Container parentContainer)
    {
        Position = position;
        ParentContainer = parentContainer;
        Palette = parentContainer.Palette;
    }

    public Component(Rect poisiton, Container parentContainer, ConsolePalette palette)
    {
        Position = poisiton;
        ParentContainer = parentContainer;
        Palette = palette;
    }

    protected abstract void OnSelectionChanged(bool state);
    public abstract void HandleInput(ConsoleKeyInfo key);
    public abstract void Draw();
    public abstract bool Selectable();

}
