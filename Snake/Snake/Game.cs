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
            // Először a felső és alsó sávot rajzoljuk ki
            for (int i = 2; i < 118; i++) {
                Console.SetCursorPosition(i, 0);
                Console.Write("━");
                Console.SetCursorPosition(i, 34);
                Console.Write("━");
            }

            // Utána a két oldasávot
            for (int i = 1; i < 34; i++) {
                Console.SetCursorPosition(1, i);
                Console.Write("┃");
                Console.SetCursorPosition(118, i);
                Console.Write("┃");
            }

            // Majd a sarkokat
            Console.SetCursorPosition(1, 0);
            Console.Write("┏");
            Console.SetCursorPosition(118, 0);
            Console.Write("┓");
            Console.SetCursorPosition(1, 34);
            Console.Write("┗");
            Console.SetCursorPosition(118, 34);
            Console.Write("┛");
        }
    }
}
