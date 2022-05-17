using HTE.Graphics;
using HTE.Elements;
using System.Threading;
namespace HTE
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            var consoleWindow = new ConsoleWindow(Console.WindowWidth, Console.WindowHeight);
            var popup = new PopupElement("popup", consoleWindow.Width / 2, 3, "HTE - Hababi Text Editor v0.1-alpha", ConsoleColor.White, ConsoleColor.Red, consoleWindow);
            var textBox = new TextBoxElement("textbox", 0, 0, consoleWindow.Width, consoleWindow.Height, ConsoleColor.White, ConsoleColor.Black, consoleWindow);
            consoleWindow
                .AddComponent(textBox)
                .AddComponent(popup)
                .Refresh()
                .InputManager.SetFocus(textBox);
            Thread.Sleep(1000);
        }

    }
}