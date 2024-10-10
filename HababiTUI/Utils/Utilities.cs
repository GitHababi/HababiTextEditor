using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HababiTUI.Utils;
public class Rect
{
    public readonly int x, y, width, height;

    public Rect() { }
    public Rect(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.width = 0;
        this.height = 0;
    }
    public Rect(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
    public static Rect operator +(Rect left, Rect right)
    {
        return new(right.x + left.x, left.y + right.y, left.width + right.width, left.height + right.height);
    }

    public bool PointInside(Rect other)
    {
        return 
            this.x <= other.x && 
            other.x <= this.x + this.width &&
            this.y <= other.y &&
            other.y <= this.y + this.height;
    }
}


public class ConsolePalette
{
    public ConsoleColor fg, bg;
    public static readonly ConsolePalette Default = new() { bg = ConsoleColor.Black, fg = ConsoleColor.White };
    public static readonly ConsolePalette Alert = new() { bg = ConsoleColor.Red, fg = ConsoleColor.White };
    public static readonly ConsolePalette Warning = new() { bg = ConsoleColor.DarkRed, fg = ConsoleColor.Red };
    public static readonly ConsolePalette LightMode = new() { bg = ConsoleColor.DarkGray, fg = ConsoleColor.White };
    public static ConsolePalette Current { get; internal set; }
    public static ConsolePalette WithBlackBg(ConsoleColor color)
    {
        return new() { bg = ConsoleColor.Black, fg = color };
    }
    public static ConsolePalette Invert(ConsolePalette palette)
    {
        return new() { bg = palette.fg, fg = palette.bg };
    }
}