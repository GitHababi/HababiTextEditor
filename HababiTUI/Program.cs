using HababiTUI.Components;
using HababiTUI.Utils;
using System.Threading;
using System.IO;
using HababiTUI.Containers;

namespace HababiTUI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var container = UI.Init(120,30);
            
            var popup = new PopupContainer(
                new(Console.WindowWidth / 2 - 10, 5,20,20), 
                container, 
                ConsolePalette.Alert, 
                "message"
            );
            popup.Activate();
            UI.Close();
        }

        
        
        private static IEnumerable<ListOption> GetFilesFromDirectory(string dir)
        {
            var fileInfos = new DirectoryInfo(dir).GetFiles();
            foreach (var file in fileInfos)
            {
                yield return new(file.Name,file.FullName);
            }
        }
        
    }
}