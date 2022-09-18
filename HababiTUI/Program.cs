using HababiTUI.Components;
using HababiTUI.Utils;
using System.Threading;
using System.IO;
using HababiTUI.Containers;
using System.Security.Principal;

namespace HababiTUI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var mainWindow = UI.Init(120, 30, "UI Testing!");

            TestForLists(mainWindow);
            SpawnPopup(mainWindow);
            UI.Close();
        }

        private static void TestForLists(Container mainWindow)
        {
            var selectionList = new SelectionListComponent(
                new(0, 0),
                mainWindow,
                ConsolePalette.Alert,
                new()
                {
                    new("option1",""),
                    new("option2",""),
                    new("option3","")
                },
                "Title of Options"
                );

            selectionList.OnSelected = (option) =>
                 {
                     var label = new LabelComponent(new(10, 10), mainWindow, option.Name);
                     var button = new ButtonComponent(new(20, 10), mainWindow, "ok press here to close");
                     button.OnPressed = () =>
                     {
                         mainWindow.ForceStop();
                     };

                     mainWindow.Components.Add(button);
                     mainWindow.Components.Add(label);

                     Component.SetTopBottomPair(selectionList, button);

                     button.Draw();
                     label.Draw();

                 };

            mainWindow.Components.Add(selectionList);
            mainWindow.Activate();
            mainWindow.Components.Clear();
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
                    popup.ForceStop();
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