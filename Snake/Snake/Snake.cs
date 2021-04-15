using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        private struct pos {
            public int x, y;
        }

        private enum Direction {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        private Direction dir;

        private pos makePos(int x, int y) {
            pos tmp;
            tmp.x = x;
            tmp.y = y;
            return tmp;
        }

        List<pos> snake = new List<pos>();


        public Snake() {
            snake.Add(makePos(9, 3));
            snake.Add(makePos(8, 3));
            snake.Add(makePos(7, 3));
            snake.Add(makePos(6, 3));
            snake.Add(makePos(5, 3));
            snake.Add(makePos(4, 3));
            snake.Add(makePos(3, 3));
            dir = Direction.RIGHT;
        }

        public void draw() {
            Console.SetCursorPosition(snake[0].x, snake[0].y);
            Console.Write("@");

            for (int i = 1; i < snake.Count; i++) {
                Console.SetCursorPosition(snake[i].x, snake[i].y);
                Console.Write("O");
            }
        }

        public void input() {

            // Kitöröljük a régi kígyót
            // TODO: Külön függvénybe tenni
            for (int i = 0; i < snake.Count; i++)
            {
                Console.SetCursorPosition(snake[i].x, snake[i].y);
                Console.Write(" ");
            }

            if (Console.KeyAvailable) {
                var inputKey = Console.ReadKey(true).Key;
                switch (inputKey) {
                    case ConsoleKey.UpArrow:
                        dir = Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        dir = Direction.DOWN;
                        break;
                    case ConsoleKey.LeftArrow:
                        dir = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        dir = Direction.RIGHT;
                        break;
                }
            }

            pos prev = makePos(0,0);
            switch (dir) {
                case Direction.UP:
                    prev = makePos(snake[0].x, snake[0].y - 1);
                    break;
                case Direction.DOWN:
                    prev = makePos(snake[0].x, snake[0].y + 1);
                    break;
                case Direction.LEFT:
                    prev = makePos(snake[0].x - 1, snake[0].y);
                    break;
                case Direction.RIGHT:
                    prev = makePos(snake[0].x + 1, snake[0].y);
                    break;
            }
            
            for (int i = 0; i < snake.Count; i++)
            {
                // TODO: biztos van jobb megoldás, de amikor ezt írtam, akkor agyhalott voltam
                pos asd = snake[i];
                snake[i] = prev;
                prev = asd;
            }
        }
    }
}
