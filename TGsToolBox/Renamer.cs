using System;
using System.IO;

namespace TGsToolBox
{
    public static class Renamer
    {
        public static void DoThatTimelapseThing()
        {
            MyWriter.WriteLine("Enter the directory");
            var directory = Globals.Directory?? System.Console.ReadLine();
            var timestamp1 = DateTimeOffset.Now;
            var files = Directory.GetFiles($@"{directory}", "*",
                SearchOption.AllDirectories);
            

            MyWriter.WriteLine($"Are you sure you want to rename all {files.Length} files? (y/n)");
            ConsoleKey key;
            if (!Globals.CalledByWindows)
            {
                do
                {
                    key = System.Console.ReadKey().Key;
                } while (key == ConsoleKey.N || key == ConsoleKey.Y);

                if (key == ConsoleKey.N) return;
            }

            for (var i = 1; i <= files.Length; i++)
            {
                var file = files[i - 1];
                File.Move(file, $"{directory}\\{i}{file.Substring(file.LastIndexOf('.'))}");
                MyWriter.WriteLine($"Renamed {file} to {i}{file.Substring(file.LastIndexOf('.'))} and moved to {directory}s",true);
            }

            var timestamp2 = DateTimeOffset.Now;
            MyWriter.WriteLine($"Renamed all {files.Length} in {(timestamp2 - timestamp1).TotalSeconds}",true);
        }
    }
}