using HababiTUI.Components;
using HababiTUI.Utils;
using System.Threading;
using System.IO;
using HababiTUI.Containers;
using System.Security.Principal;
using System.Diagnostics.SymbolStore;
using HababiTUI;
namespace TestApplication
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var mainWindow = UI.Init(120, 30, "UI Testing!");
            mainWindow.Palette = ConsolePalette.Default;
            TestForLists(mainWindow);
            SpawnPopup(mainWindow);
            UI.Close();
        }

        private static void TestForLists(Container mainWindow)
        {
            var selectionList = new SelectionListComponent(
                new(0, 0),
                mainWindow,
                ConsolePalette.LightMode,
                new()
                {
                    new("New",""),
                    new("Open",""),
                    new("Recent Files",""),
                    new("Find",""),
                    new("Replace","")
                },
                "File"
                );

            var label = new LabelComponent(new(10, 10), mainWindow, "");
            var button = new ButtonComponent(new(20, 10), mainWindow, "ok press here to close");
            
            mainWindow.Components.Add(label);
            mainWindow.Components.Add(button);
            button.OnPressed = () =>
            {
                SpawnPopup(mainWindow);
            };
            Component.SetTopBottomPair(selectionList, button);

            selectionList.OnSelected = (option) =>
            {
                label.Text = option.Name;
            };

            mainWindow.Components.Add(selectionList);
            mainWindow.SetDefaultNavItem(button);
            mainWindow.Activate();
        }

        private static void SpawnPopup(Container mainWindow)
        {
            var popup = new PopupContainer(
                new(Console.WindowWidth / 2 - 15, 5, 30, 10),
                mainWindow,
                ConsolePalette.Alert,
                "Clicked 0 times",
                "Click!"
            );
            int number = 0;
            popup.Button.OnPressed += () =>
            {
                number++;
                popup.Message.Text = $"Clicked {number} times";
                popup.Message.Draw();
                if (number == 10)
                    popup.Close();
            };
            popup.Activate();
        }

        private static IEnumerable<ListOption> GetFilesFromDirectory(string dir)
        {
            var fileInfos = new DirectoryInfo(dir).GetFiles();
            foreach (var file in fileInfos)
            {
                yield return new(file.Name, file.FullName);
            }
        }

    }
}