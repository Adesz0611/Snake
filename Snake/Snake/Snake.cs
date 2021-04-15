using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Snake.Program;

namespace Snake
{
    class Snake
    {
        public struct pos {
            public int x, y;
        }
        private pos last;
        private int score;

        private enum Direction {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        private Direction dir;

        public static pos makePos(int x, int y) {
            pos tmp;
            tmp.x = x;
            tmp.y = y;
            return tmp;
        }

        List<pos> snake = new List<pos>();


        public Snake() {
            reset();
        }

        public void reset() {
            snake.Clear();
            snake.Add(makePos(9, 3));
            snake.Add(makePos(8, 3));
            /*snake.Add(makePos(7, 3));
            snake.Add(makePos(6, 3));
            snake.Add(makePos(5, 3));
            snake.Add(makePos(4, 3));
            snake.Add(makePos(3, 3));*/
            dir = Direction.RIGHT;
            score = 0;
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
            deleteOldSnake();

            last = snake[snake.Count - 1];

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

            pos prev = makePos(0, 0);
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
            last = snake[snake.Count - 1];
        }

        private void deleteOldSnake() {
            // Kitöröljük a régi kígyót
            for (int i = 0; i < snake.Count; i++)
            {
                Console.SetCursorPosition(snake[i].x, snake[i].y);
                Console.Write(" ");
            }
        }

        public bool checkSelfCollide() {
            for (int i = 1; i < snake.Count; i++) {
                if (snake[i].x == snake[0].x && snake[i].y == snake[0].y) {
                    saveScore();
                    return true;
                }
            }
            return false;
        }

        public bool checkWallCollide() {
            if (snake[0].x > 117 || snake[0].x < 2 || snake[0].y < 1 || snake[0].y > 33) {
                saveScore();
                return true;
            }
            return false;
        }

        public void saveScore() {
            int currentMax = loadScore();
            FileStream f = new FileStream("score.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f);

            sw.Write(Math.Max(score, currentMax));

            sw.Close();
            f.Close();
        }

        public void eatFood(Food p_f) {
            if (snake[0].x == p_f.food.x && snake[0].y == p_f.food.y) {
                score += 10;
                snake.Add(last);
                p_f.generateFoodPos();
            }
        }
    }
}
