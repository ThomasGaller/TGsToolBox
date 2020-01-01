using System;
using System.IO;
using Newtonsoft.Json.Linq;
using TGsToolBox;

namespace TGsToolBox
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length>0 && args[0] != null)
                {
                    Globals.CalledByWindows = bool.Parse(args[0]);
                    Globals.Action = int.Parse(args[2]);
                    switch (Globals.Action)
                    {
                        case 0:
                            Globals.FilePath = args[1];
                            if (!File.Exists(Globals.FilePath))
                                throw new ArgumentException("File does not exist");
                            break;
                        case 1:
                            Globals.Directory = args[1];
                            if (!Directory.Exists(Globals.Directory))
                                throw new ArgumentException("Directory does not exist");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                Environment.Exit(500);
            }

            if (Globals.CalledByWindows)
            {
                switch (Globals.Action)
                {
                    case 0:
                        TextChanger.MakeStringArray();
                        break;
                    case 1:
                        Renamer.DoThatTimelapseThing();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                MyWriter.WriteLine("Press any key to exit the console...",true);
                Console.ReadKey();
                Environment.Exit(1);
            }

            Menu.MainMenu();
        }
    }
}