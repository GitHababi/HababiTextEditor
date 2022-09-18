using HababiTUI.Containers;
using HababiTUI.Utils;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HababiTUI;

public static class ConsoleHelper
{
    public static void SmartWrite(string text, Rect pos)
    {
        Console.SetCursorPosition(pos.x, pos.y);
        int y = pos.y;
        foreach (char c in text)
        {
            if (c != '\n' && c != '\r')
                Console.Write(c);
            else if (c == '\n')
                Console.SetCursorPosition(pos.x, y = y + 1);
            else if (c == '\r')
                Console.SetCursorPosition(pos.x, y);
        }
    }

    /// <summary>
    /// It's like an eraser!
    /// </summary>
    public static void DrawEmptyRect(Rect rect)
    {
        
        for (int i = 0; i < rect.height; i++)
        {
            Console.CursorLeft = rect.x;
            Console.CursorTop = rect.y + i;
            Console.Write("".PadRight(rect.width));
        }
    }

    /// <summary>
    /// Draws a singly lined box at the specified rect.
    /// </summary>
    /// <param name="rect"></param>
    public static void DrawSingleBox(Rect rect)
    {
        Console.SetCursorPosition(rect.x, rect.y);
        Console.Write("┌");
        for (int i = 0; i < rect.width - 2; i++)
        {
            Console.Write("─");
        }
        Console.Write("┐");

        for (int i = 0; i < rect.height - 2; i++)
        {
            Console.SetCursorPosition(rect.x, rect.y + 1 + i);
            Console.Write("│");
        }

        for (int i = 0; i < rect.height - 2; i++)
        {
            Console.SetCursorPosition(rect.x + rect.width - 1, rect.y + 1 + i);
            Console.Write("│");
        }

        Console.SetCursorPosition(rect.x, rect.y + rect.height - 1);
        Console.Write("└");
        for (int i = 0; i < rect.width - 2; i++)
        {
            Console.Write("─");
        }
        Console.Write("┘");
        Console.SetCursorPosition(rect.x + 1, rect.y);
    }

    /// <summary>
    /// Draws a doubly lined box at the specified rect.
    /// </summary>
    /// <param name="rect"></param>
    public static void DrawDoubleBox(Rect rect)
    {
        Console.SetCursorPosition(rect.x, rect.y);
        Console.Write("╔");
        for (int i = 0; i < rect.width - 2; i++)
        {
            Console.Write("═");
        }
        Console.Write("╗");

        for (int i = 0; i < rect.height - 2; i++)
        {
            Console.SetCursorPosition(rect.x, rect.y + 1 + i);
            Console.Write("║");
        }

        for (int i = 0; i < rect.height - 2; i++)
        {
            Console.SetCursorPosition(rect.x + rect.width - 1, rect.y + 1 + i);
            Console.Write("║");
        }

        Console.SetCursorPosition(rect.x, rect.y + rect.height - 1);
        Console.Write("╚");
        for (int i = 0; i < rect.width - 2; i++)
        {
            Console.Write("═");
        }
        Console.Write("╝");
        Console.SetCursorPosition(rect.x + 1, rect.y);
    }

    /// <summary>
    /// Sets the console to the specified palette
    /// </summary>
    public static void SetPalette(ConsolePalette palette)
    {
        Console.ForegroundColor = palette.fg;
        Console.BackgroundColor = palette.bg;
    }

    public static void SetWindowSize(int width, int height)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        if (width > Console.BufferWidth) //new Width is bigger then buffer
        {
            Console.BufferWidth = width;
            Console.WindowWidth = width;
        }
        else
        {
            Console.WindowWidth = width;
            Console.BufferWidth = width;
        }

        if (height > Console.BufferWidth) //new Height is bigger then buffer
        {
            Console.BufferHeight = height;
            Console.WindowHeight = height;
        }
        else
        {
            Console.WindowHeight = height;
            Console.BufferHeight = height;
        }
    }

}
