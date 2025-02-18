using System;
using System.Collections.Generic;
using System.Linq; // Для использования методов LINQ (например, Sum, Average, Max)

public static class FinanceManager // Класс объявлен как static
{
    // Этап 7: Основная программа
    public static void Main(string[] args)
    {
        // FinanceManager manager = new FinanceManager();  - Убрали создание экземпляра

        while (true)
        {
            Console.WriteLine("\nДобро пожаловать в систему управления финансами!");
            Console.WriteLine("1. Добавить доход/расход");
            Console.WriteLine("2. Показать отчет");
            Console.WriteLine("3. Рассчитать баланс");
            Console.WriteLine("4. Прогноз на следующий месяц");
            Console.WriteLine("5. Статистика");
            Console.WriteLine("6. Выход");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите категорию (Доход, Продукты, Транспорт, Развлечения): ");
                    string category = Console.ReadLine();
                    Console.Write("Введите сумму: ");
                    if (double.TryParse(Console.ReadLine(), out double amount))
                    {
                        AddTransaction(category, amount); // Вызываем статический метод напрямую через имя класса
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод суммы.");
                    }
                    break;
                case "2":
                    PrintFinanceReport(); // Вызываем статический метод напрямую через имя класса
                    break;
                case "3":
                    double balance = CalculateBalance(); // Вызываем статический метод напрямую через имя класса
                    double roundedBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero);
                    Console.WriteLine("Текущий баланс: " + roundedBalance.ToString() + " руб.");
                    break;
                case "4":
                    double prediction = PredictNextMonthExpenses(); // Вызываем статический метод напрямую через имя класса
                    double roundedPrediction = Math.Round(prediction, 2, MidpointRounding.AwayFromZero);
                    Console.WriteLine("Прогнозируемые расходы на следующий месяц: " + roundedPrediction.ToString() + " руб.");
                    break;
                case "5":
                    PrintStatistics(); // Вызываем статический метод напрямую через имя класса
                    break;
                case "6":
                    Console.WriteLine("Выход из программы.");
                    return; // Выход из цикла и завершение программы
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие от 1 до 6.");
                    break;
            }
        }
    }

    // Этап 1: Структура хранения данных
    private static Dictionary<string, List<double>> transactions = new Dictionary<string, List<double>>(); // Сделали static

    // Этап 2: Добавление записей
    public static void AddTransaction(string category, double amount) // Сделали static
    {
        if (!transactions.ContainsKey(category))
        {
            transactions.Add(category, new List<double>());
        }
        transactions[category].Add(amount);
        Console.WriteLine("Запись добавлена.");
    }

    // Этап 3: Вывод информации
    public static void PrintFinanceReport() // Сделали static
    {
        Console.WriteLine("Финансовый отчет:");
        foreach (var category in transactions)
        {
            double total = category.Value.Sum();
            double roundedTotal = Math.Round(total, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine(category.Key + ": " + roundedTotal.ToString() + " руб. - " + category.Value.Count + " операций");
        }
    }

    // Этап 4: Расчет баланса
    public static double CalculateBalance() // Сделали static
    {
        double income = 0;
        double expenses = 0;

        foreach (var category in transactions)
        {
            if (category.Key.ToLower() == "доход")  //  Считаем "Доход" как положительное значение (доход)
            {
                income = category.Value.Sum();
            }
            else // Остальные категории - расходы
            {
                expenses += category.Value.Sum();
            }
        }

        return income - expenses;
    }

    // Этап 5: Анализ и прогнозирование
    public static double GetAverageExpense(string category) // Сделали static
    {
        if (transactions.ContainsKey(category) && transactions[category].Count > 0)
        {
            return transactions[category].Average();
        }
        return 0; // Если категория не найдена или нет транзакций
    }

    public static double PredictNextMonthExpenses() // Сделали static
    {
        double predictedExpenses = 0;

        foreach (var category in transactions.Keys)
        {
            if (category.ToLower() != "доход") // Не учитываем "Доход" при прогнозировании расходов
            {
                predictedExpenses += GetAverageExpense(category) * 30; // Предполагаем, что в среднем в месяце 30 дней
            }
        }

        return predictedExpenses;
    }

    // Этап 6: Статистика
    public static void PrintStatistics() // Сделали static
    {
        double totalExpenses = 0;
        Dictionary<string, double> categoryExpenses = new Dictionary<string, double>();
        Dictionary<string, int> categoryFrequencies = new Dictionary<string, int>();

        // Вычисляем общую сумму расходов, расходы по категориям и частоту категорий
        foreach (var category in transactions)
        {
            if (category.Key.ToLower() != "доход") // Игнорируем "Доход"
            {
                double categoryTotal = category.Value.Sum();
                totalExpenses += categoryTotal;
                categoryExpenses[category.Key] = categoryTotal;
                categoryFrequencies[category.Key] = category.Value.Count;
            }
        }

        // Выводим общую сумму расходов
        double roundedTotalExpenses = Math.Round(totalExpenses, 2, MidpointRounding.AwayFromZero);
        Console.WriteLine("Общая сумма расходов: " + roundedTotalExpenses.ToString() + " руб.");

        // Определяем самую затратную категорию
        if (categoryExpenses.Count > 0)
        {
            string mostExpensiveCategory = categoryExpenses.OrderByDescending(x => x.Value).First().Key;
            double roundedMostExpensive = Math.Round(categoryExpenses[mostExpensiveCategory], 2, MidpointRounding.AwayFromZero);
            Console.WriteLine("Самая затратная категория: " + mostExpensiveCategory + " (" + roundedMostExpensive.ToString() + " руб.)");
        }
        else
        {
            Console.WriteLine("Нет данных о расходах.");
        }

        // Определяем самую частую категорию
        if (categoryFrequencies.Count > 0)
        {
            string mostFrequentCategory = categoryFrequencies.OrderByDescending(x => x.Value).First().Key;
            Console.WriteLine("Самая частая категория: " + mostFrequentCategory + " (" + categoryFrequencies[mostFrequentCategory] + " операций)");
        }
        else
        {
            Console.WriteLine("Нет данных о частоте расходов.");
        }

        // Расчёт процентного соотношения расходов
        Console.WriteLine("Процентное распределение расходов:");
        if (totalExpenses > 0)
        {
            foreach (var category in categoryExpenses)
            {
                double percentage = (category.Value / totalExpenses) * 100;
                double roundedPercentage = Math.Round(percentage, 2, MidpointRounding.AwayFromZero);
                double roundedCategoryValue = Math.Round(category.Value, 2, MidpointRounding.AwayFromZero);
                Console.WriteLine(category.Key + ": " + roundedCategoryValue.ToString() + " руб. (" + roundedPercentage.ToString() + "%)");
            }
        }
        else
        {
            Console.WriteLine("Нет данных для расчета процентного распределения.");
        }
    }
}