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
            var selectableList = new SelectableListElement(new(consoleWindow.InputManager), 15, 20, new());
            consoleWindow.AddComponent(selectableList).Refresh();
            consoleWindow.InputManager.OnNewLine += (line) =>
            {
                selectableList.ToggleInputListen();
            };
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