using System;
using System.IO;

namespace TGsToolbox
{
    // ReSharper disable once IdentifierTypo
    public static class Renamer
    {
        public static void DoThatTimelapseThing()
        {
            MyWriter.WriteLine("Enter the directory");
            var directory = Globals.Directory?? Console.ReadLine();
            var timestamp1 = DateTimeOffset.Now;
            var files = Directory.GetFiles($@"{directory}", "*",
                SearchOption.AllDirectories);
            

            MyWriter.WriteLine($"Are you sure you want to rename all {files.Length} files? (y/n)");
            if (!Globals.CalledByWindows)
            {
                ConsoleKey key;
                do
                {
                    key = Console.ReadKey().Key;
                } while (key is ConsoleKey.N or ConsoleKey.Y);
            }

            for (var i = 1; i <= files.Length; i++)
            {
                var file = files[i - 1];
                File.Move(file, $"{directory}/{i}{file.Substring(file.LastIndexOf('.'))}");
                MyWriter.WriteLine($"Renamed {file} to {i}{file.Substring(file.LastIndexOf('.'))} and moved to {directory}s",true);
            }

            var timestamp2 = DateTimeOffset.Now;
            MyWriter.WriteLine($"Renamed all {files.Length} in {(timestamp2 - timestamp1).TotalSeconds}",true);
        }
    }
}