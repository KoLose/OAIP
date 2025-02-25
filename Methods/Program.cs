using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Определение четности числа
        Console.WriteLine("Задание 1: Определение четности числа");
        Console.Write("Введите целое число: ");
        string input1 = Console.ReadLine();
        int number1 = Convert.ToInt32(input1);
        if (number1 % 2 == 0)
        {
            Console.WriteLine("Число четное.");
        }
        else
        {
            Console.WriteLine("Число нечетное.");
        }
        Console.WriteLine();

        // 2. Определение времени суток
        Console.WriteLine("Задание 2: Определение времени суток");
        Console.Write("Введите час (0-23): ");
        string input2 = Console.ReadLine();
        int hour = Convert.ToInt32(input2);
        if (hour >= 6 && hour <= 11)
        {
            Console.WriteLine("Утро");
        }
        else if (hour >= 12 && hour <= 17)
        {
            Console.WriteLine("День");
        }
        else if (hour >= 18 && hour <= 22)
        {
            Console.WriteLine("Вечер");
        }
        else if ((hour >= 23 && hour <= 23) || (hour >= 0 && hour <= 5))
        {
            Console.WriteLine("Ночь");
        }
        else
        {
            Console.WriteLine("Некорректный час.");
        }
        Console.WriteLine();

        // 3. Калькулятор скидок (только целые числа)
        Console.WriteLine("Задание 3: Калькулятор скидок (только целые числа)");
        Console.Write("Введите сумму покупки: ");
        string input3 = Console.ReadLine();
        int purchaseAmount = Convert.ToInt32(input3); // Изменено на int
        double discount; // Изменено на double для расчетов
        if (purchaseAmount > 5000)
        {
            discount = 0.10; // Скидка 10%
        }
        else
        {
            discount = 0.05; // Скидка 5%
        }
        double finalAmount = purchaseAmount * (1 - discount); // Результат теперь double
        Console.WriteLine("Итоговая сумма к оплате: " + finalAmount); // Выводим double
        Console.WriteLine();

        // 4. Определение дня недели
        Console.WriteLine("Задание 4: Определение дня недели");
        Console.Write("Введите номер дня недели (1-7): ");
        string input4 = Console.ReadLine();
        int dayNumber = Convert.ToInt32(input4);
        string dayName;
        switch (dayNumber)
        {
            case 1: dayName = "Понедельник"; break;
            case 2: dayName = "Вторник"; break;
            case 3: dayName = "Среда"; break;
            case 4: dayName = "Четверг"; break;
            case 5: dayName = "Пятница"; break;
            case 6: dayName = "Суббота"; break;
            case 7: dayName = "Воскресенье"; break;
            default: dayName = "Некорректный номер дня недели"; break;
        }
        Console.WriteLine("День недели: " + dayName);
        Console.WriteLine();

        // 5. Поиск максимального из двух чисел
        Console.WriteLine("Задание 5: Поиск максимального из двух чисел");
        Console.Write("Введите первое число: ");
        string input5a = Console.ReadLine();
        Console.Write("Введите второе число: ");
        string input5b = Console.ReadLine();
        int numA = Convert.ToInt32(input5a);
        int numB = Convert.ToInt32(input5b);
        int maxNumber = numA > numB ? numA : numB;
        Console.WriteLine("Большее число: " + maxNumber);
        Console.WriteLine();

        // 6. Вывод чисел от 1 до 100
        Console.WriteLine("Задание 6: Вывод чисел от 1 до 100");
        for (int i = 1; i <= 100; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        // 7. Сумма чисел от 1 до N
        Console.WriteLine("Задание 7: Сумма чисел от 1 до N");
        Console.Write("Введите число N: ");
        string input7 = Console.ReadLine();
        int n = Convert.ToInt32(input7);
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }
        Console.WriteLine("Сумма чисел от 1 до " + n + ": " + sum);
        Console.WriteLine();

        // 8. Вывод четных чисел
        Console.WriteLine("Задание 8: Вывод четных чисел");
        Console.Write("Четные числа от 2 до 50: ");
        for (int i = 2; i <= 50; i += 2)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        // 9. Перебор массива
        Console.WriteLine("Задание 9: Перебор массива");
        int[] myArray = { 10, 20, 30, 40, 50 };
        Console.Write("Массив: ");
        foreach (int element in myArray)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine("\n");

        // 10. Таблица умножения
        Console.WriteLine("Задание 10: Таблица умножения");
        Console.WriteLine("Таблица умножения от 1 до 10:");
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                Console.Write(i * j + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // 11. Пользователь вводит числа, пока не введет 0
        Console.WriteLine("Задание 11: Пользователь вводит числа, пока не введет 0");
        int sum11 = 0;
        int number11;
        do
        {
            Console.Write("Введите число (0 для завершения): ");
            string input11 = Console.ReadLine();
            number11 = Convert.ToInt32(input11);
            sum11 += number11;
        } while (number11 != 0);
        Console.WriteLine("Сумма всех введенных чисел: " + sum11);
        Console.WriteLine();

        // 12. Угадай число
        Console.WriteLine("Задание 12: Угадай число");
        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int guess;
        Console.WriteLine("Я загадал число от 1 до 100. Попробуйте угадать.");
        do
        {
            Console.Write("Введите ваше предположение: ");
            string input12 = Console.ReadLine();
            guess = Convert.ToInt32(input12);
            if (guess < secretNumber)
            {
                Console.WriteLine("Больше.");
            }
            else if (guess > secretNumber)
            {
                Console.WriteLine("Меньше.");
            }
            else
            {
                Console.WriteLine("Поздравляем, вы угадали число " + secretNumber + "!");
            }
        } while (guess != secretNumber);
        Console.WriteLine();

        // 13. Факториал числа
        Console.WriteLine("Задание 13: Факториал числа");
        Console.Write("Введите число для вычисления факториала: ");
        string input13 = Console.ReadLine();
        int number13 = Convert.ToInt32(input13);
        long factorial = 1;
        int i = 1;
        while (i <= number13)
        {
            factorial *= i;
            i++;
        }
        Console.WriteLine("Факториал числа " + number13 + " равен " + factorial);
        Console.WriteLine();

        // 14. Счетчик символов
        Console.WriteLine("Задание 14: Счетчик символов");
        Console.Write("Введите строку: ");
        string input14 = Console.ReadLine();
        int countA = 0;
        int index = 0;
        while (index < input14.Length)
        {
            if (input14[index] == 'a' || input14[index] == 'A') // Учитываем и строчные, и прописные буквы "a"
            {
                countA++;
            }
            index++;
        }
        Console.WriteLine("Количество букв 'a' в строке: " + countA);
        Console.WriteLine();

        // 15. Заполнение массива
        Console.WriteLine("Задание 15: Заполнение массива");
        int[] array15 = new int[5];
        Console.WriteLine("Введите 5 чисел:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Число " + (i + 1) + ": ");
            string input15 = Console.ReadLine();
            array15[i] = Convert.ToInt32(input15);
        }
        Console.Write("Вы ввели: ");
        foreach (int num in array15)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine("\n");

        // 16. Среднее арифметическое
        Console.WriteLine("Задание 16: Среднее арифметическое");
        Random random16 = new Random();
        int[] array16 = new int[10];
        int sum16 = 0;
        for (int i = 0; i < array16.Length; i++)
        {
            array16[i] = random16.Next(1, 101);
            sum16 += array16[i];
        }
        double average = (double)sum16 / array16.Length;
        Console.WriteLine("Среднее арифметическое: " + average);
        Console.WriteLine();

        // 18. Заполнение матрицы 3х3
        Console.WriteLine("Задание 18: Заполнение матрицы 3x3");
        int[,] matrix18 = new int[3, 3];
        Console.WriteLine("Введите 9 чисел для заполнения матрицы 3x3:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("Элемент [" + (i + 1) + "," + (j + 1) + "]: ");
                string input18 = Console.ReadLine();
                matrix18[i, j] = Convert.ToInt32(input18);
            }
        }

        Console.WriteLine("Матрица 3x3:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix18[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // 19. Сумма элементов по диагонали
        Console.WriteLine("Задание 19: Сумма элементов по диагонали");
        Random random19 = new Random();
        int[,] matrix19 = new int[3, 3];

        Console.WriteLine("Сгенерированная матрица:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matrix19[i, j] = random19.Next(1, 10);
                Console.Write(matrix19[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int diagonalSum = 0;
        for (int i = 0; i < 3; i++)
        {
            diagonalSum += matrix19[i, i];
        }

        Console.WriteLine("Сумма элементов главной диагонали: " + diagonalSum);
        Console.WriteLine();

        // 20. Добавление элементов в список
        Console.WriteLine("Задание 20: Добавление элементов в список");
        List<int> numbers20 = new List<int>();
        int inputNumber20;

        Console.WriteLine("Введите числа для добавления в список (введите -1 для завершения):");
        do
        {
            Console.Write("Введите число: ");
            string input20 = Console.ReadLine();
            inputNumber20 = Convert.ToInt32(input20);
            if (inputNumber20 != -1)
            {
                numbers20.Add(inputNumber20);
            }
        } while (inputNumber20 != -1);

        Console.Write("Список чисел: ");
        foreach (int number in numbers20)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine("\n");

        // 21. Удаление четных чисел
        Console.WriteLine("Задание 21: Удаление четных чисел");
        Random random21 = new Random();
        List<int> numbers21 = new List<int>();

        Console.Write("Исходный список: ");
        for (int i = 0; i < 10; i++)
        {
            numbers21.Add(random21.Next(1, 101));
            Console.Write(numbers21[i] + " ");
        }
        Console.WriteLine();

        // Удаление четных чисел
        for (int i = numbers21.Count - 1; i >= 0; i--)
        {
            if (numbers21[i] % 2 == 0)
            {
                numbers21.RemoveAt(i);
            }
        }

        Console.Write("Список после удаления четных чисел: ");
        foreach (int number in numbers21)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine("\n");

        // 22. Телефонная книга
        Console.WriteLine("Задание 22: Телефонная книга");
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        phoneBook.Add("Иван Иванов", "123-456-7890");
        phoneBook.Add("Петр Петров", "987-654-3210");
        phoneBook.Add("Анна Сидорова", "555-123-4567");

        Console.Write("Введите имя для поиска номера телефона: ");
        string name22 = Console.ReadLine();

        if (phoneBook.ContainsKey(name22))
        {
            Console.WriteLine("Номер телефона для " + name22 + ": " + phoneBook[name22]);
        }
        else
        {
            Console.WriteLine("Номер телефона для " + name22 + " не найден.");
        }
        Console.WriteLine();

        // 23. Подсчет слов в тексте
        Console.WriteLine("Задание 23: Подсчет слов в тексте");
        Console.Write("Введите строку текста: ");
        string text23 = Console.ReadLine();

        string[] words23 = text23.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        foreach (string word in words23)
        {
            string lowercaseWord = word.ToLower();
            if (wordCounts.ContainsKey(lowercaseWord))
            {
                wordCounts[lowercaseWord]++;
            }
            else
            {
                wordCounts[lowercaseWord] = 1;
            }
        }

        Console.WriteLine("Статистика по словам:");
        foreach (var pair in wordCounts)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
        Console.WriteLine();

        // 24. Деление чисел с обработкой ошибок (хотя у нас их нет)
        Console.WriteLine("Задание 24: Деление чисел с обработкой ошибок");

        Console.Write("Введите делимое: ");
        string inputDividend = Console.ReadLine();
        Console.Write("Введите делитель: ");
        string inputDivisor = Console.ReadLine();

        double dividend = Convert.ToDouble(inputDividend);
        double divisor = Convert.ToDouble(inputDivisor);

        if (divisor == 0)
        {
            Console.WriteLine("Ошибка: Деление на ноль невозможно.");
        }
        else
        {
            double result = dividend / divisor;
            Console.WriteLine("Результат деления: " + result);
        }
        Console.WriteLine();

        // 25. Парсинг числа (без обработки FormatException - ОПАСНО!)
        Console.WriteLine("Задание 25: Парсинг числа");
        Console.Write("Введите строку, которую нужно преобразовать в целое число: ");
        string input25 = Console.ReadLine();
        int number25 = Convert.ToInt32(input25);
        Console.WriteLine("Число: " + number25);
        Console.WriteLine();

        // 26. Сумма двух чисел (метод)
        Console.WriteLine("Задание 26: Сумма двух чисел (метод)");
        Console.Write("Введите первое число: ");
        string input26a = Console.ReadLine();
        int a = Convert.ToInt32(input26a);
        Console.Write("Введите второе число: ");
        string input26b = Console.ReadLine();
        int b = Convert.ToInt32(input26b);
        int sum26 = Sum(a, b);
        Console.WriteLine("Сумма двух чисел: " + sum26);
        Console.WriteLine();

        // 27. Максимальное число (метод)
        Console.WriteLine("Задание 27: Максимальное число (метод)");
        Console.Write("Введите первое число: ");
        string input27a = Console.ReadLine();
        int num27a = Convert.ToInt32(input27a);
        Console.Write("Введите второе число: ");
        string input27b = Console.ReadLine();
        int num27b = Convert.ToInt32(input27b);
        int max27;
        if (num27a > num27b)
        {
            max27 = num27a;
        }
        else
        {
            max27 = num27b;
        }

        Console.WriteLine("Максимальное число: " + max27);
        Console.WriteLine();

        // 28. Подсчет суммы цифр числа (метод)
        Console.WriteLine("Задание 28: Подсчет суммы цифр числа (метод)");
        Console.Write("Введите число для подсчета суммы цифр: ");
        string input28 = Console.ReadLine();
        int number28 = Convert.ToInt32(input28);
        int sum28 = SumOfDigits(number28);
        Console.WriteLine("Сумма цифр числа: " + sum28);
        Console.WriteLine();
    }

    public static int Sum(int a, int b)
    {
        return a + b;
    }

    public static int Max(int a, int b)
    {
        return a > b ? a : b; // В 5м задании разрешен тернарный оператор,
    }

    public static int SumOfDigits(int number)
    {
        int sum = 0;
        number = Math.Abs(number);
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }
}