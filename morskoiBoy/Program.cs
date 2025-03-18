using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morskoiBoy
{
    internal class Program
    {

        //ЗАПОЛНЕНИЕ МАССИВА ИГРОКА
        static string[,] FillPlayerArray(string[,] playerArray)
        {

            for (int i = 0; i < playerArray.GetLength(0); i++) {
                for (int j = 0; j < playerArray.GetLength(1); j++){
                    playerArray[i, j] = "*";
                }
            }
            return playerArray;
        }
        
        //ЗАПОЛНЕНИЕ ЦВЕТНОГО МАССИВА ИГРОКА
        static string[,] FillColorPlayerArray(string[,] colorPlayerArray)
        {
            for(int i = 0;i < colorPlayerArray.GetLength(0); i++) {
                for (int j = 0; j < 10; j++) {
                    colorPlayerArray[i, j] = "*";
                }
            }
            return colorPlayerArray;
        }

        //ЗАПОЛНЕНИЕ МАССИВА ОТКРЫТОГО БОТА
        static string[,] FillBotArray(string[,] botArray)
        {
            for (int i = 0; i < botArray.GetLength(0); i++)
            {
                for (int j = 0; j < botArray.GetLength(1); j++)
                {
                    botArray[i, j] = "*";
                }
            }
            return botArray;
        }

        //ЗАПОЛНЕНИЕ ЗАКРЫТОГО МАССИВА БОТА
        static string[,] FillBotVoidArray(string[,] botVoidArray)
        {
            for (int i = 0; i < botVoidArray.GetLength(0); i++)
            {
                for (int j = 0; j < botVoidArray.GetLength(1); j++)
                {
                   botVoidArray[i, j] = "*";
                }
            }
            return botVoidArray;
        }

        //ЗАПОЛНЕНИЕ СЛОВАРЯ КОРАБЛЕЙ ИГРОКА
        static Dictionary<string, int> FillPlayerShips(Dictionary<string, int> shipsPlayer)
        {
            shipsPlayer.Add("4-х палубный", 1);
            shipsPlayer.Add("3-х палубный", 2);
            shipsPlayer.Add("2-х палубный", 3);
            shipsPlayer.Add("1 палубный", 4);
            
            return shipsPlayer;
        }
        //ЗАПОЛНЕНИЕ СЛОВАРЯ КОРАБЛЕЙ БОТА
        static Dictionary<string, int> FillBotShips(Dictionary<string, int> shipsBot)
        {
            shipsBot.Add("4-х палубный", 1);
            shipsBot.Add("3-х палубный", 2);
            shipsBot.Add("2-х палубный", 3);
            shipsBot.Add("1 палубный", 4);

            return shipsBot;
        }
        //РАССТАНОВКА КОРАБЛЕЙ ИГРОКА
        static string[,] ArrangePlayerArray(string[,] colorPlayerArray)
        {
            int coordinateI = 0;
            int coordinateJ = 0;
            int counter = 0;
            bool loop = true;

            Console.WriteLine("РАССТАВЬТЕ ВАШИ КОРАБЛИ");
            
            while (loop == true)
            {
                CheckPlayerArray(colorPlayerArray, coordinateI, coordinateJ);
                string movement = Console.ReadLine();
                switch (movement)
                {
                    case ("w"):
                        if (coordinateI > 0)
                            coordinateI--;
                        break;
                    case ("a"):
                        if (coordinateJ > 0)
                            coordinateJ--;
                        break;
                    case ("s"):
                        if (coordinateI < 9)
                            coordinateI++;
                        break;
                    case ("d"):
                        if (coordinateJ < 9)
                            coordinateJ++;
                        break;
                    case ("e"):
                        counter++;
                        break;
                    case ("f"):
                        loop = false;
                        break;
                }
            }
                return colorPlayerArray;
        }

        //ВЫВОДИМ ЦВЕТНОЙ МАССИВ ИГРОКА
        static void CheckPlayerArray(string[,] colorPlayerArray, int coordinateI, int coordinateJ)
        {
            Console.Clear();
            Console.WriteLine("    A B C D E F G H J K\n---------------------------");
         
            for (int i = 0; i < colorPlayerArray.GetLength(0); i++) {
                Console.ResetColor();
                if (i < 9)
                {
                    Console.Write(" " + (i + 1) + "  ");
                }
                else
                {
                    Console.Write((i + 1) + "  ");
                }

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                for (int j = 0; j < colorPlayerArray.GetLength(1); j++)
                {
                    if (i == coordinateI && j == coordinateJ)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(colorPlayerArray[i, j]);
                    }
                    //Console.ForegroundColor = ConsoleColor.White;
                    //Console.BackgroundColor = ConsoleColor.DarkBlue;
                    if (j < colorPlayerArray.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.ResetColor();
                Console.Write(" " + (i + 1));
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine("---------------------------");
        }
        static void Main(string[] args)
        {   
            //СОЗДАЁМ МАССИВЫ
            string[,] playerArray = new string[10, 11];
            string[,] colorPlayerArray = new string[10, 11];
            string[,] botArray = new string[10, 10];
            string[,] botVoidArray = new string[10, 11];

            //СОЗДАЁМ СЛОВАРИ
            Dictionary<string, int> playerShips = new Dictionary<string, int>();
            Dictionary<string, int> botShips = new Dictionary<string, int>();

            //ЗАПОЛНЯЕМ МАССИВЫ
            FillPlayerArray(playerArray);
            FillColorPlayerArray(colorPlayerArray);
            FillBotArray(botArray);
            FillBotVoidArray(botVoidArray);

            //ЗАПОЛНЯЕМ СЛОВАРИ
            FillPlayerShips(playerShips);
            FillBotShips(botShips);

            //ИНИЦИАЛИЗАЦИЯ ИГРЫ
            Console.WriteLine("Добро пожаловать в игру morskoiBoy");
            ArrangePlayerArray(colorPlayerArray);
            CheckPlayerArray(colorPlayerArray, 0, 0);

        }

    }
}