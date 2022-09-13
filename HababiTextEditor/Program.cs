using HTE.Graphics;
using HTE.Elements;
using HTE.Utils;
using System.Threading;
using System.IO;
namespace HTE
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            var consoleWindow = new ConsoleWindow(Console.WindowWidth, Console.WindowHeight);
            var selectableList = new SelectableListElement(new(consoleWindow.InputManager), consoleWindow.Width /2 , consoleWindow.Height - 1, new());
            var textbox = new TextBoxElement(new(consoleWindow.InputManager) { X = consoleWindow.Width / 2, fg= ConsoleColor.White, bg=ConsoleColor.Blue}, consoleWindow.Width / 2, consoleWindow.Height - 1, "");
            consoleWindow.AddComponent(selectableList).AddComponent(textbox).Refresh();
            selectableList.OnSelected += (option) =>
            {
                textbox.Text = File.ReadAllText(option.Value);
                textbox.Draw();
            };
            consoleWindow.InputManager.OnNewLine += (line) =>
            {
                selectableList.Options = GetFilesFromDirectory(line);
                selectableList.ToggleInputListen();
                
            };

            while (consoleWindow.InputManager.Active)
            {
                consoleWindow.InputManager.PressKey(Console.ReadKey(true));
            }
        }

        
        
        private static List<ListOption> GetFilesFromDirectory(string dir)
        {
            var fileInfos = new DirectoryInfo(dir).GetFiles();
            var listOptions = new List<ListOption>();
            foreach (var file in fileInfos)
            {
                listOptions.Add(new(file.Name,file.FullName));
            }
            return listOptions;
        }
        
    }
}