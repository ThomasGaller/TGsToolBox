using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TGsToolBox;

namespace TGsToolBox
{
    public static class TextChanger
    {
        public static void MakeStringArray()
        {
            MyWriter.WriteLine("Enter the path to the file");
            try
            {
                var filepath = Globals.FilePath ?? Console.ReadLine() ?? throw new ArgumentNullException("filename");
                if (filepath.Substring(filepath.Length - 4) != ".txt")
                    throw new InvalidDataException();
                var directory = filepath.Remove(filepath.Replace('\\', '/').LastIndexOf('/'));
                var filename = filepath.Substring(filepath.Replace('\\', '/').LastIndexOf('/') + 1);

                var lines = File.ReadLines($"{directory}/{filename}").ToList();
                for (var i = 0; i < lines.Count; i++)
                    if (i != lines.Count - 1)
                        lines[i] = $"    \"{lines[i].Replace("\"", "\\\"").Replace("\\", "\\\\")}\",";
                    else
                        lines[i] = $"    \"{lines[i].Replace("\"", "\\\"").Replace("\\", "\\\\")}\"";

                lines.InsertRange(0,
                    new[] {$"private static readonly string[] array_{filename.Replace('.', '_')} =", "{"});
                lines.Add("};");
                File.WriteAllLines($@"{Path.GetTempPath()}/Array_{filename}.cs", lines);
                MyWriter.WriteLine($"The Array can be found in the new file: Array_{filename}.cs");
                Process.Start(new ProcessStartInfo
                    {FileName = $"{Path.GetTempPath()}/Array_{filename}.cs", UseShellExecute = true});
                Environment.Exit(0);
            }
            catch (InvalidDataException)
            {
                MyWriter.WriteLine("Only .txt files work");
                Menu.TryAgainMenu(0);
            }
            catch (ArgumentNullException e)
            {
                MyWriter.WriteLine($"The {e.ParamName} can not be null");
                Menu.TryAgainMenu(0);
            }
            catch (Exception e) when (
                e is DirectoryNotFoundException ||
                e is FileNotFoundException
            )
            {
                MyWriter.WriteLine("File could not be found");
                Menu.TryAgainMenu(0);
            }
        }
    }
}