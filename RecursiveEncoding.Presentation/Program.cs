using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecursiveEncoding.Presentation
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string path = Console.ReadLine();
            IEnumerable<string> files = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                if (file.EndsWith(".cs") || file.EndsWith(".json"))
                {
                    File.WriteAllText(file, File.ReadAllText(file) + Environment.NewLine, new UTF8Encoding(true));
                    Console.WriteLine($"{file} was converted.");
                }
            }

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
