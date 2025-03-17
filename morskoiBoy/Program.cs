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

        //РАССТАНОВКА КОРАБЛЕЙ ИГРОКА
        static string[,] ArrangePlayerArray(string[,] playerArray)
        {
            
            return playerArray;
        }

        //ВЫВОДИМ МАССИВ ИГРОКА
        static void CheckPlayerArray(string[,] playerArray)
        {
            Console.WriteLine("    A B C D E F G H J K\n--------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < playerArray.GetLength(0); i++) {
                Console.ResetColor();
                if (i < 9)
                {
                    Console.Write(" " + (i + 1) + "  ");
                }
                else
                {
                    Console.Write((i + 1) + "  ");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                for (int j = 0; j < playerArray.GetLength(1); j++)
                {
                    Console.Write(playerArray[i, j]);
                    if (j < playerArray.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.ResetColor();
                Console.Write(" " + (i + 1));
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            string[,] playerArray = new string[10, 10];
            string[,] botArray = new string[10, 10];
            string[,] botVoidArray = new string[10, 10];
            FillPlayerArray(playerArray);
            FillBotArray(botArray);
            FillBotVoidArray(botVoidArray);
            Console.WriteLine("Добро пожаловать в игру morskoiBoy");
            Console.WriteLine("Заполните ваши корабли!");
            CheckPlayerArray(playerArray);
            ArrangePlayerArray(playerArray);
            
        }

    }
}