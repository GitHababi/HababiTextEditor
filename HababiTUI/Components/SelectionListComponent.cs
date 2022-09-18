using HababiTUI.Containers;
using HababiTUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HababiTUI.Components;

internal class SelectionListComponent : Component
{
    private int _width;

    private List<ListOption> _options;
    public List<ListOption> Options { get => _options; set { _options = value; UpdateWidth(); } }

    private string _title;
    public string Title { get => _title; set { _title = value; UpdateWidth(); } }
    public Action<ListOption> OnSelected { get; set; }
    public SelectionListComponent(Rect position, Container parentContainer, List<ListOption> options, string title) : base(position, parentContainer)
    {
        _options = options;
        _title = title;
        UpdateWidth();
    }

    public SelectionListComponent(Rect position, Container parentContainer, ConsolePalette palette, List<ListOption> options, string title) : base(position, parentContainer, palette)
    {
        _options = options;
        _title = title;
        UpdateWidth();
    }

    private void UpdateWidth()
    {
        _width = Math.Max(_options.Max(item => item.Name.Length), _title.Length + 3);
    }

    public override void Draw()
    {
        if (Selected)
            ConsoleHelper.SetPalette(ConsolePalette.Invert(Palette));
        else
            ConsoleHelper.SetPalette(Palette);
        ConsoleHelper.SmartWrite($"≡  {_title}", Position);
    }

    public override void HandleInput(ConsoleKeyInfo key)
    {
        if (ParentContainer.Navigate(key))
        {
            var container = new SelectionListContainer(Position, ParentContainer, Palette, _options, _width);
            container.Activate();
            if (container.ListOptionChosen)
                OnSelected.Invoke(container.Result);
        }

    }

    public override bool Selectable() => true;
    protected override void OnSelectionChanged(bool state)
    {
        Draw();
    }

    /// <summary>
    /// The internal representation of the selectionlist menu.
    /// </summary>
    private class SelectionListContainer : Container
    {
        public bool ListOptionChosen => _chosenIndex != -1;
        public ListOption Result;
        private List<ListOption> _options;
        private int _chosenIndex;
        private int _width;
        internal SelectionListContainer(Rect position, Container? parent, ConsolePalette palette, List<ListOption> options, int width) : base(position, parent, palette)
        {
            _options = options;
            _width = width;
            Result = _options.First();
            _chosenIndex = -1;

            Components.Add(new SelectionListKeyListenerComponent(position, this));
        }

        protected override void DrawThis()
        {
            ConsoleHelper.SetPalette(Palette);
            ConsoleHelper.DrawEmptyRect(Position + new Rect(0,1,_width,_options.Count));
        }

        /// <summary>
        /// Listens for key inputs from the selection list, and draws all the options.
        /// </summary>
        private class SelectionListKeyListenerComponent : Component
        {
            private SelectionListContainer _container;
            public SelectionListKeyListenerComponent(Rect position, SelectionListContainer parentContainer) : base(position, parentContainer)
            {
                this._container = parentContainer;
            }

            public override void Draw() 
            {
                var rowOffset = new Rect(0, 0 + 1);
                for (int i = 0; i < _container._options.Count; i++)
                {
                    if (i == _container._chosenIndex)
                        ConsoleHelper.SetPalette(ConsolePalette.Invert(Palette));
                    else
                        ConsoleHelper.SetPalette(Palette);
                    ConsoleHelper.SmartWrite(_container._options[i].Name, Position + rowOffset);
                    rowOffset += new Rect(0, 1);
                }
            }

            public override void HandleInput(ConsoleKeyInfo key)
            {
                switch (key.Key)
                {
                    default:
                        break;
                    case ConsoleKey.Escape:
                        _container._chosenIndex = -1;
                        _container.ForceStop();
                        return;
                    case ConsoleKey.UpArrow:
                        _container._chosenIndex = Math.Max(_container._chosenIndex - 1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        _container._chosenIndex = Math.Min(_container._chosenIndex + 1, _container._options.Count - 1);
                        break;
                    case ConsoleKey.Enter:
                        if (_container._chosenIndex != -1)
                            _container.Result = _container._options[_container._chosenIndex];
                        _container.ForceStop();
                        return;
                }
                this.Draw();
            }

            public override bool Selectable() => true;

            protected override void OnSelectionChanged(bool state) { }
        }
    }
}
