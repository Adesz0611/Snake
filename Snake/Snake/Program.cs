using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        // ---------- MENÜ ----------
        public struct Menu {
            public int highlighted;
            public string[] options;
        }

        static void constructMenu(ref Menu p_menu) {
            p_menu.highlighted = 0;
            p_menu.options = new string[] { "Játék", "Eredmények", "Kilépés" };
        }

        static void drawMenuTitle() {
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

        static void drawMenuElements(Menu p_menu) {
            for (int i = 0; i < p_menu.options.Length; i++) {
                Console.SetCursorPosition(3, i + 6);
                if (i == p_menu.highlighted) {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(p_menu.options[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        static void inputMenu(ref Menu p_menu) {
            var inputKey = Console.ReadKey(true).Key;
            switch (inputKey)
            {
                case ConsoleKey.UpArrow:
                    p_menu.highlighted = Math.Max(0, --p_menu.highlighted);
                    break;
                case ConsoleKey.DownArrow:
                    p_menu.highlighted = Math.Min(2, ++p_menu.highlighted);
                    break;
                case ConsoleKey.Enter:
                    switch (p_menu.highlighted)
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

        static Menu menu;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            constructMenu(ref menu);
            drawMenuTitle();
            while(true) {
                drawMenuElements(menu);
                inputMenu(ref menu);
            }
        }
    }
}
