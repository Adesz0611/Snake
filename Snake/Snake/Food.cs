using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Snake.Snake;

namespace Snake
{
    class Food
    {
        public pos food;
        Random r = new Random();

        public Food() {
            generateFoodPos();
        }

        public void generateFoodPos() {
            food = makePos(r.Next(2, 118), r.Next(1, 31));
        }

        public void draw() {
            Console.SetCursorPosition(food.x, food.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
