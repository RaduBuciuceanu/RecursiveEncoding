using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecursiveEncoding.Presentation
{
    public static class Program
    {
        private static string path;
        private static string searchPattern;

        public static void Main(string[] args)
        {
            path = ReadDirectoryPath();
            searchPattern = ReadSearchPattern();

            IEnumerable<string> files = Directory.GetFiles(path, $"*{searchPattern}", SearchOption.AllDirectories);
            ChangeEncoding(files);

            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        private static string ReadDirectoryPath()
        {
            Console.Write("Directory path: ");
            return Console.ReadLine();
        }

        private static string ReadSearchPattern()
        {
            Console.WriteLine("Search pattern like .cs or .txt (only a single one is supported):");
            return Console.ReadLine();
        }

        private static void ChangeEncoding(IEnumerable<string> files)
        {
            foreach (string file in files)
            {
                if (file.EndsWith(searchPattern))
                {
                    File.WriteAllText(file, File.ReadAllText(file) + Environment.NewLine, new UTF8Encoding(true));
                    Console.WriteLine($"{file} was converted.");
                }
            }
        }
    }
}
