using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Menu
    {
        private int highlighted = 0;
        private string[] options = { "Játék", "Eredmények", "Kilépés" };

        public void DrawLogo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(3, 0);
            Console.WriteLine("   _____             __      ");
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("  / ___/____  ____ _/ /_____ ");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("  \\__ \\/ __ \\/ __ `/ //_/ _ \\");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine(" ___/ / / / / /_/ / ,< /  __/");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("/____/_/ /_/\\__,_/_/|_|\\___/ ");
        }

        public void drawMenu()
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(3, i + 6);
                if (i == highlighted)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(options[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public void input()
        {
            var inputKey = Console.ReadKey(true).Key;
            switch (inputKey)
            {
                case ConsoleKey.UpArrow:
                    highlighted = Math.Max(0, --highlighted);
                    break;
                case ConsoleKey.DownArrow:
                    highlighted = Math.Min(2, ++highlighted);
                    break;
                case ConsoleKey.Enter:
                    switch (highlighted)
                    {
                        case 0: // "Játék"
                            break;
                        case 1: // "Eredmények"
                            break;
                        case 2: // "Kilépés"
                            Environment.Exit(0);
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
