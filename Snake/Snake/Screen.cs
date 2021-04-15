using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Screen
    {
        public Screen() {
            Console.Title = "Snake by Adam Hunyadvari";
            Console.SetWindowSize(120, 35);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;
            Console.Clear();
        }
    }
}
