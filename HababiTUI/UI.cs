using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HababiTUI.Components;
using HababiTUI.Containers;
using HababiTUI.Utils;
namespace HababiTUI;

static class UI
{
    private static Thread _resizeThread;
    private static int _windowW;
    private static int _windowH;
    public static bool Stopped { get; private set; } = false;
    private static Container _instance;
    private static string _title;
    public static Container Init(int width, int height, string title)
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.Title = _title = title;

        ConsoleHelper.SetPalette(ConsolePalette.Default);
        ConsoleHelper.SetWindowSize(width, height);
        _windowW = width;
        _windowH = height;
        _resizeThread = new Thread(() =>
        {
            try
            {
                while (!Stopped)
                    if (_windowH != Console.WindowHeight || _windowW != Console.WindowWidth)
                    {
                        ConsoleHelper.SetPalette(ConsolePalette.Default);
                        ConsoleHelper.SetWindowSize(_windowW, _windowH);
                        _instance.DrawAll();
                    }
            }
            catch { }
        });
        _resizeThread.Start();
        return _instance = new FullWindowContainer(ConsolePalette.Default);

    }

    public static void Close()
    {
        Stopped = true;
    }

    private class FullWindowContainer : Container
    {
        public FullWindowContainer(ConsolePalette palette) : base(new(0,0,_windowW,_windowH), null, palette)
        {
        }

        public FullWindowContainer() : base(new(), null)
        {
        }
        protected override void DrawThis()
        {

        }
    }
}
