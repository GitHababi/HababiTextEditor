using HTE.Graphics;
using HTE.Elements;
using HTE.Utils;
using System.Threading;
namespace HTE
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            string message = "HTE - Hababi Text Editor v0.1-alpha";
            var consoleWindow = new ConsoleWindow(Console.WindowWidth, Console.WindowHeight);
            TextBoxElement textBox = 
                new("textbox", 
                new() { X = consoleWindow.Width / 2 - (message.Length+2)/2}, 
                30, 5, consoleWindow, 
                message, 
                Alignment.Center);
            consoleWindow
                .AddComponent(textBox)
                .Refresh()
                .InputManager.SetFocus(textBox);
        }

    }
}