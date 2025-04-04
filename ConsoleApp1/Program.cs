using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = "true";
            if (a == "true")
            {
                string b = a.GetType().Name;
                Console.WriteLine(b);
            }
        }
        static string[,] ArrangePlayerArray(string[,] array, Dictionary<string, int> playerShips, bool playerArrange, bool mode)
        {
            int coordinateI = 0;
            int coordinateJ = 0;
            int counter = 0;
            int maxCounter = 5;
            int counterShips = 0;
            bool value = false;
            bool value1 = true;
            string direction = "";
            string movement;

            Console.WriteLine("РАССТАВЬТЕ ВАШИ КОРАБЛИ: В ПОРЯДКЕ ОТ 4 ДО 1");

            while (counterShips != 20)
            {
                if (playerArrange)
                {
                    CheckPlayerArray(array, coordinateI, coordinateJ, playerShips, mode);
                    movement = Console.ReadLine();
                }
                else
                {
                    if (counter == 0 || counter == 1 || maxCounter == 2)
                    {
                        CheckPlayerArray(array, coordinateI, coordinateJ, playerShips, mode);
                        Random random = new Random();
                        int nextMovement = random.Next(1, 10);
                        if (nextMovement == 1 || nextMovement == 2)
                        {
                            movement = "w";
                        }
                        else if (nextMovement == 3 || nextMovement == 4)
                        {
                            movement = "a";
                        }
                        else if (nextMovement == 5 || nextMovement == 6)
                        {
                            movement = "s"; ;
                        }
                        else if (nextMovement == 7 || nextMovement == 8)
                        {
                            movement = "d";
                        }
                        else
                        {
                            movement = "";
                        }
                    }
                    else
                    {
                        movement = direction;
                    }
                }
                switch (movement.ToLower())
                {
                    case ("w"):
                        if (coordinateI > 0)
                        {
                            if (counter == 1)
                            {
                                value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                            }
                            if (value && value1 && (direction == "" || direction == "w") && counter + 1 <= maxCounter)
                            {
                                FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                                array[coordinateI, coordinateJ] = "-";
                                coordinateI--;
                                counter++;
                                counterShips++;
                                direction = "w";
                                if (counter + 1 == maxCounter)
                                {
                                    direction = "";
                                    value = false;
                                    array[coordinateI, coordinateJ] = "-";
                                    counterShips++;
                                }
                            }
                            else if (value1 == false && counter == 1)
                            {
                                array[coordinateI, coordinateJ] = "*";
                                value1 = true;
                            }
                            else if (direction != "" && direction != "w")
                            {
                            }
                            else
                            {
                                direction = "";
                                coordinateI--;
                            }
                        }
                        break;

                    case ("a"):
                        if (coordinateJ > 0)
                        {
                            if (counter == 1)
                            {
                                value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                            }
                            if (value && value1 && (direction == "" || direction == "a") && counter + 1 <= maxCounter)
                            {
                                FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                                array[coordinateI, coordinateJ] = "-";
                                coordinateJ--;
                                counter++;
                                counterShips++;
                                direction = "a";
                                if (counter + 1 == maxCounter)
                                {
                                    direction = "";
                                    value = false;
                                    array[coordinateI, coordinateJ] = "-";
                                    counterShips++;
                                }
                            }
                            else if (value1 == false && counter == 1)
                            {
                                array[coordinateI, coordinateJ] = "*";
                                value1 = true;
                            }
                            else if (direction != "" && direction != "a")
                            {
                            }
                            else
                            {
                                direction = "";
                                coordinateJ--;
                            }
                        }
                        break;

                    case ("s"):
                        if (coordinateI < 9)
                        {
                            if (counter == 1)
                            {
                                value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                            }
                            if (value && value1 && (direction == "" || direction == "s") && counter + 1 <= maxCounter)
                            {
                                FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                                array[coordinateI, coordinateJ] = "-";
                                coordinateI++;
                                counter++;
                                counterShips++;
                                direction = "s";
                                if (counter + 1 == maxCounter)
                                {
                                    direction = "";
                                    value = false;
                                    array[coordinateI, coordinateJ] = "-";
                                    counterShips++;
                                }
                            }
                            else if (value1 == false && counter == 1)
                            {
                                array[coordinateI, coordinateJ] = "*";
                                value1 = true;
                            }
                            else if (direction != "" && direction != "s")
                            {
                            }
                            else
                            {
                                direction = "";
                                coordinateI++;
                            }
                        }
                        break;

                    case ("d"):
                        if (coordinateJ < 9)
                        {
                            if (counter == 1)
                            {
                                value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                            }
                            if (value && value1 && (direction == "" || direction == "d") && counter + 1 <= maxCounter)
                            {
                                FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                                array[coordinateI, coordinateJ] = "-";
                                coordinateJ++;
                                counter++;
                                counterShips++;
                                direction = "d";
                                if (counter + 1 == maxCounter)
                                {
                                    direction = "";
                                    value = false;
                                    array[coordinateI, coordinateJ] = "-";
                                    counterShips++;
                                }
                            }
                            else if (value1 == false && counter == 1)
                            {
                                array[coordinateI, coordinateJ] = "*";
                                value1 = true;
                            }
                            else if (direction != "" && direction != "d")
                            {
                            }
                            else
                            {
                                direction = "";
                                coordinateJ++;
                            }
                        }
                        break;
                    case (""):
                        value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                        if (array[coordinateI, coordinateJ] == "*" && value1 && counter == 0)
                        {
                            array[coordinateI, coordinateJ] = "-";
                            counter++;
                            value = true;
                        }
                        break;
                }

                if (counter + 1 == maxCounter)
                {
                    if (maxCounter == 5)
                    {
                        playerShips["4-х палубный"]--;
                    }
                    else if (maxCounter == 4)
                    {
                        playerShips["3-х палубный"]--;
                    }
                    else if (maxCounter == 3)
                    {
                        playerShips["2-х палубный"]--;
                    }
                    else if (maxCounter == 2)
                    {
                        counterShips++;
                        playerShips["1 палубный"]--;
                    }
                    FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                    direction = "";
                    value = false;
                    counter = 0;
                }
                if (playerShips["4-х палубный"] > 0)
                {
                    maxCounter = 5;
                }
                else if (playerShips["3-х палубный"] > 0)
                {
                    maxCounter = 4;
                }
                else if (playerShips["2-х палубный"] > 0)
                {
                    maxCounter = 3;
                }
                else if (playerShips["1 палубный"] > 0)
                {
                    maxCounter = 2;
                }
                foreach (var item in playerShips)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            return array;
        }
    }
}
