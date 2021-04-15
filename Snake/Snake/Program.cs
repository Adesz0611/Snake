using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        public enum State
        {
            MENU,
            GAME,
            RESULT,
            DEFAULT
        }

        public static int loadScore() {
            FileStream f = new FileStream("score.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f);

            int score = int.Parse(sr.ReadLine());

            sr.Close();
            f.Close();

            return score;
        }

        static void Main(string[] args)
        {
            // Engedélyezzük az UTF-8-as karakterek kiíratását a konzolban
            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;
            Menu menu = new Menu();
            Screen screen = new Screen();
            Snake snake = new Snake();
            Food food = new Food();
            Game game = new Game();

            State state = State.MENU;
            menu.DrawLogo();
            while(true) {
                while(state == State.MENU) {
                    menu.drawMenu();
                    switch (menu.input()) {
                        case State.GAME:
                            // Mielőtt még átlépnénk a játékra, elő kell készítenünk a konzolt
                            Console.Clear();
                            game.DrawBorders();
                            //snake.draw();
                            snake.reset();
                            state = State.GAME;
                            break;
                        case State.RESULT:
                            state = State.RESULT;
                            break;
                    }
                }
                while (state == State.GAME) {
                    food.draw();
                    snake.input();
                    snake.eatFood(food);
                    if (snake.checkWallCollide() || snake.checkSelfCollide()) {
                        Console.Clear();
                        menu.DrawLogo();
                        state = State.MENU;
                        break;
                    }
                    snake.draw();
                    
                    Thread.Sleep(100);
                }
                while (state == State.RESULT) {
                    Console.Clear();
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("A legnagyobb elért pontszám: " + loadScore());
                    Console.SetCursorPosition(2, 5);
                    Console.WriteLine("Nyomjon meg egy gombot a menübe való visszalépéshez...");
                    Console.ReadKey();
                    Console.Clear();
                    menu.DrawLogo();
                    state = State.MENU;
                    break;
                }
            }
        }
    }
}
