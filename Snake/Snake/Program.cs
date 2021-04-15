using System;
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


        static void Main(string[] args)
        {
            // Engedélyezzük az UTF-8-as karakterek kiíratását a konzolban
            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;
            Menu menu = new Menu();
            Screen screen = new Screen();
            Snake snake = new Snake();
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
                            snake.draw();
                            state = State.GAME;
                            break;
                    }
                }
                while (state == State.GAME) {
                    
                    snake.input();
                    snake.draw();
                    Thread.Sleep(100);
                }
            }
        }
    }
}
