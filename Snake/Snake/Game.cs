using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        public void DrawBorders()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            // Először a felső és alsó sávot rajzoljuk ki
            for (int i = 1; i < 119; i++) {
                Console.SetCursorPosition(i, 0);
                Console.Write(" ");
                Console.SetCursorPosition(i, 31);
                Console.Write(" ");
            }

            // Utána a két oldasávot
            for (int i = 0; i < 32; i++) {
                Console.SetCursorPosition(1, i);
                Console.Write(" ");
                Console.SetCursorPosition(118, i);
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
