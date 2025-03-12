using System;
using System.Security.Cryptography.X509Certificates;
using TikTakEngine;

public class Program
{
    private static GameEngine game;

    public static void PlayGame()
    {
        while(true)
        {
            game.PrintBoard();
            Console.WriteLine($"Ход игрока {game.CurrentPlayer}");

            int row;
            int col;

            while(true)
            {
                Console.WriteLine("Введите номер строки (0 - 9): ");
                if(!int.TryParse( Console.ReadLine(), out row) || row < 0  || row >= 10)
                {
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    continue;
                }

                Console.WriteLine("Введите номер столбца (0 - 9): ");
                if(!int.TryParse(Console.ReadLine(), out col) || col < 0 || col >= 10)
                {
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    continue;
                }

                if(game.MakeMove(row, col))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Эта клетка уже занята, попробуйте снова.");
                }
            }

            if(game.CheckWin())
            {
                game.PrintBoard();
                game.SwitchPlayer();
                Console.WriteLine($"Игрок {game.CurrentPlayer} победил!");
                break;
            }
            if(game.IsDraw())
            {
                game.PrintBoard();
                Console.WriteLine("Ничья, все клетки заполнены");
                break;
            }
        }
    }

    public static void Main(string[] args)
    {
        bool playAgain = true;

        while(playAgain)
        {
            game = new GameEngine();
            PlayGame();

            Console.WriteLine("Начать заново?");
            string responce = Console.ReadLine().Trim().ToLower();
            playAgain = responce == "да" || responce == "д" || responce == "y" || responce == "yes";
        }
    }
}
