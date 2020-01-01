using System;
using System.Linq;

namespace RenamerForTimelapsePictures
{
    public static class Menu
    {
        private static readonly char[] NumOfOptions = {'0', '1', 'x'};

        private static readonly string[] Logo =
        {
            "  _____ ___    _____         _ ___          ",
            " |_   _/ __|__|_   _|__  ___| | _ ) _____ __",
            "   | || (_ (_-< | |/ _ \\/ _ \\ | _ \\/ _ \\ \\ /",
            "   |_| \\___/__/ |_|\\___/\\___/_|___/\\___/_\\_\\"
        };

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            foreach (var line in Logo) Console.WriteLine(line);
            Console.WriteLine("AsciiArt was made using this Website: http://www.patorjk.com/software/taag/");
            Console.WriteLine();
            Console.WriteLine("What do you wanna do?");
            Console.WriteLine("0: Get a string array for all the lines of a textfile?");
            Console.WriteLine("1: Rename all images of a timelapse folder to the correct sequence naming");
            Console.WriteLine("X: Exit");
            ConsoleKeyInfo option;
            do
            {
                option = Console.ReadKey();
            } while (!NumOfOptions.Contains(option.KeyChar));

            Console.WriteLine();
            switch (char.ToLower(option.KeyChar))
            {
                case '0':
                    TextChanger.MakeStringArray();
                    break;
                case '1':
                    Renamer.DoThatTimelapseThing();
                    break;
                case 'x':
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine("Press any key to close the window");
            Console.ReadKey();
        }

        public static void TryAgainMenu(int method)
        {
            Console.WriteLine("To you want to try again? (Y/N)");
            ConsoleKeyInfo option;
            do
            {
                option = Console.ReadKey();
            } while (char.ToLower(option.KeyChar) != 'n' && char.ToLower(option.KeyChar) != 'y');

            Console.WriteLine();

            switch (char.ToLower(option.KeyChar))
            {
                case 'n':
                    MainMenu();
                    break;
                case 'y':
                    switch (method)
                    {
                        case 0:
                            TextChanger.MakeStringArray();
                            break;
                        case 1:
                            Renamer.DoThatTimelapseThing();
                            break;
                        default:
                            MainMenu();
                            break;
                    }

                    break;
            }
        }
    }
}