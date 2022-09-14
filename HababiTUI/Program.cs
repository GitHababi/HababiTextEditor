using HababiTUI.Graphics;
using HababiTUI.Elements;
using HababiTUI.Utils;
using System.Threading;
using System.IO;
namespace HababiTUI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            
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