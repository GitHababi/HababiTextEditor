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
    private static bool _stopped = false;
    public static Container Init(int width, int height)
    {
        Console.CursorVisible = false;
        Console.Clear();
        ConsoleHelper.SetWindowSize(width, height);
        _windowW = width;
        _windowH = height;
        _resizeThread = new Thread(() =>
        {
            while (!_stopped)
                if (_windowH != Console.WindowHeight || _windowW != Console.WindowWidth)
                    ConsoleHelper.SetWindowSize(_windowW, _windowH);
        });
        _resizeThread.Start();
        return new FullWindowContainer(ConsolePalette.Default);

    }

    public static void Close()
    {
        _stopped = true;
    }

    private class FullWindowContainer : Container
    {
        public FullWindowContainer(ConsolePalette palette) : base(new(), null, palette)
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
