using System;
using System.Collections.Generic;
using System.Linq;

public static class Method2
{
    // --- Этап 1: Структура хранения данных ---
    private static Dictionary<string, List<double>> tranzakcii = new Dictionary<string, List<double>>(); // tranzakcii = "transactions" (список транзакций)

    // --- Этап 2: Добавление записей (вспомогательный метод для ввода данных) ---
    private static void DobavitTranzakciyuIzVvoda() // DobavitTranzakciyuIzVvoda = "AddTransactionFromInput" (добавить транзакцию из ввода)
    {
        Console.Write("Введите категорию (Доход, Продукты, Транспорт, Развлечения): ");
        string kategoriyaName = Console.ReadLine(); // kategoriyaName = "categoryName" (имя категории)
        Console.Write("Введите сумму: ");
        if (double.TryParse(Console.ReadLine(), out double tranzakciyaSumma)) // tranzakciyaSumma = "transactionSum" (сумма транзакции)
        {
            DobavitTranzakciyu(kategoriyaName, tranzakciyaSumma);
        }
        else
        {
            Console.WriteLine("Некорректный ввод суммы.");
        }
    }

    public static void DobavitTranzakciyu(string kategoriyaName, double tranzakciyaSumma) // DobavitTranzakciyu = "AddTransaction" (добавить транзакцию)
    {
        if (!tranzakcii.ContainsKey(kategoriyaName))
        {
            tranzakcii.Add(kategoriyaName, new List<double>());
        }
        tranzakcii[kategoriyaName].Add(tranzakciyaSumma);
        Console.WriteLine("Запись добавлена.");
    }

    // --- Этап 3: Вывод информации ---
    public static void VivestiFinansoviyOtchet() // VivestiFinansoviyOtchet = "PrintFinanceReport" (вывести финансовый отчет)
    {
        Console.WriteLine("Финансовый отчет:");
        foreach (var kategoriya in tranzakcii)
        {
            double obschayaSumma = kategoriya.Value.Sum(); // obschayaSumma = "totalSum" (общая сумма)
            double okruglyonniyItog = Math.Round(obschayaSumma, 2, MidpointRounding.AwayFromZero); // okruglyonniyItog = "roundedTotal" (округленный итог)
            Console.WriteLine(kategoriya.Key + ": " + okruglyonniyItog.ToString() + " руб. - " + kategoriya.Value.Count + " операций");
        }
    }

    // --- Этап 4: Расчет баланса (вспомогательный метод для отображения баланса) ---
    private static void RasschitatIPokazatBalans() // RasschitatIPokazatBalans = "CalculateAndDisplayBalance" (рассчитать и показать баланс)
    {
        double obschiyBalans = RasschitatBalans(); // obschiyBalans = "totalBalance" (общий баланс)
        double okruglyonniyBalans = Math.Round(obschiyBalans, 2, MidpointRounding.AwayFromZero); // okruglyonniyBalans = "roundedBalance" (округленный баланс)
        Console.WriteLine("Текущий баланс: " + okruglyonniyBalans.ToString() + " руб.");
    }

    public static double RasschitatBalans() // RasschitatBalans = "CalculateBalance" (рассчитать баланс)
    {
        double doxod = 0; // doxod = "income" (доход)
        double rashodi = 0; // rashodi = "expenses" (расходы)

        foreach (var kategoriya in tranzakcii)
        {
            if (kategoriya.Key.ToLower() == "доход")
            {
                doxod = kategoriya.Value.Sum();
            }
            else
            {
                rashodi += kategoriya.Value.Sum();
            }
        }

        return doxod - rashodi;
    }

    // --- Этап 5: Анализ и прогнозирование (вспомогательный метод для отображения прогноза) ---
    private static void SprognozirovatIPokazatRashodiNaSleduyuschiyMesyac() // SprognozirovatIPokazatRashodiNaSleduyuschiyMesyac = "PredictAndDisplayNextMonthExpenses" (спрогнозировать и показать расходы на след. месяц)
    {
        double prognoziruemoeZnachenie = SprognozirovatRashodiNaSleduyuschiyMesyac(); // prognoziruemoeZnachenie = "predictedValue" (прогнозируемое значение)
        double okruglyonniyPrognoz = Math.Round(prognoziruemoeZnachenie, 2, MidpointRounding.AwayFromZero); // okruglyonniyPrognoz = "roundedPrediction" (округленный прогноз)
        Console.WriteLine("Прогнозируемые расходы на следующий месяц: " + okruglyonniyPrognoz.ToString() + " руб.");
    }

    public static double PoluchitSrednieRashodi(string kategoriyaName) // PoluchitSrednieRashodi = "GetAverageExpense" (получить средние расходы)
    {
        if (tranzakcii.ContainsKey(kategoriyaName) && tranzakcii[kategoriyaName].Count > 0)
        {
            return tranzakcii[kategoriyaName].Average();
        }
        return 0;
    }

    public static double SprognozirovatRashodiNaSleduyuschiyMesyac() // SprognozirovatRashodiNaSleduyuschiyMesyac = "PredictNextMonthExpenses" (спрогнозировать расходы на след. месяц)
    {
        double obschiePrognoziruemieRashodi = 0; // obschiePrognoziruemieRashodi = "totalPredictedExpenses" (общие прогнозируемые расходы)

        foreach (var kategoriya in tranzakcii.Keys)
        {
            if (kategoriya.ToLower() != "доход")
            {
                obschiePrognoziruemieRashodi += PoluchitSrednieRashodi(kategoriya) * 30;
            }
        }

        return obschiePrognoziruemieRashodi;
    }

    // --- Этап 6: Статистика ---
    public static void VivestiStatistiku() // VivestiStatistiku = "PrintStatistics" (вывести статистику)
    {
        double summaVsehRashodov = 0; // summaVsehRashodov = "allExpensesSum" (сумма всех расходов)
        Dictionary<string, double> rashodiPoKategoriyam = new Dictionary<string, double>(); // rashodiPoKategoriyam = "categoryExpenses" (расходы по категориям)
        Dictionary<string, int> chastotaKategoriy = new Dictionary<string, int>(); // chastotaKategoriy = "categoryFrequency" (частота категорий)

        // Вычисляем общую сумму расходов, расходы по категориям и частоту категорий
        foreach (var kategoriya in tranzakcii)
        {
            if (kategoriya.Key.ToLower() != "доход")
            {
                double itogPoKategorii = kategoriya.Value.Sum(); // itogPoKategorii = "categoryTotal" (итог по категории)
                summaVsehRashodov += itogPoKategorii;
                rashodiPoKategoriyam[kategoriya.Key] = itogPoKategorii;
                chastotaKategoriy[kategoriya.Key] = kategoriya.Value.Count;
            }
        }

        // Выводим общую сумму расходов
        double okruglyonnayaSummaRashodov = Math.Round(summaVsehRashodov, 2, MidpointRounding.AwayFromZero); // okruglyonnayaSummaRashodov = "roundedExpensesSum" (округленная сумма расходов)
        Console.WriteLine("Общая сумма расходов: " + okruglyonnayaSummaRashodov.ToString() + " руб.");

        // Определяем самую затратную категорию
        if (rashodiPoKategoriyam.Count > 0)
        {
            string samayaZtratnayaKategoriya = rashodiPoKategoriyam.OrderByDescending(x => x.Value).First().Key; // samayaZtratnayaKategoriya = "mostExpensiveCategory" (самая затратная категория)
            double okruglyonnayaSummaDlyaSamoyZtratnoy = Math.Round(rashodiPoKategoriyam[samayaZtratnayaKategoriya], 2, MidpointRounding.AwayFromZero); // okruglyonnayaSummaDlyaSamoyZtratnoy = "roundedSumForMostExpensive" (округленная сумма для самой затратной)
            Console.WriteLine("Самая затратная категория: " + samayaZtratnayaKategoriya + " (" + okruglyonnayaSummaDlyaSamoyZtratnoy.ToString() + " руб.)");
        }
        else
        {
            Console.WriteLine("Нет данных о расходах.");
        }

        // Определяем самую частую категорию
        if (chastotaKategoriy.Count > 0)
        {
            string samayaChastayaKategoriya = chastotaKategoriy.OrderByDescending(x => x.Value).First().Key; // samayaChastayaKategoriya = "mostFrequentCategory" (самая частая категория)
            Console.WriteLine("Самая частая категория: " + samayaChastayaKategoriya + " (" + chastotaKategoriy[samayaChastayaKategoriya] + " операций)");
        }
        else
        {
            Console.WriteLine("Нет данных о частоте расходов.");
        }

        // Расчёт процентного соотношения расходов
        Console.WriteLine("Процентное распределение расходов:");
        if (summaVsehRashodov > 0)
        {
            foreach (var kategoriya in rashodiPoKategoriyam)
            {
                double procentZnachenie = (kategoriya.Value / summaVsehRashodov) * 100; // procentZnachenie = "percentageValue" (процентное значение)
                double okruglyonniyProcent = Math.Round(procentZnachenie, 2, MidpointRounding.AwayFromZero); // okruglyonniyProcent = "roundedPercentage" (округленный процент)
                double okruglyonnayaSummaKategorii = Math.Round(kategoriya.Value, 2, MidpointRounding.AwayFromZero); // okruglyonnayaSummaKategorii = "roundedCategorySum" (округленная сумма категории)
                Console.WriteLine(kategoriya.Key + ": " + okruglyonnayaSummaKategorii.ToString() + " руб. (" + okruglyonniyProcent.ToString() + "%)");
            }
        }
        else
        {
            Console.WriteLine("Нет данных для расчета процентного распределения.");
        }
    }

    // --- Этап 7: Основная программа (Main) ---
    public static void Main(string[] args)
    {
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
            string viborPolzovatelya = Console.ReadLine(); // viborPolzovatelya = "userChoice" (выбор пользователя)

            switch (viborPolzovatelya) // viborPolzovatelya = "userChoice" (выбор пользователя)
            {
                case "1":
                    DobavitTranzakciyuIzVvoda();
                    break;
                case "2":
                    VivestiFinansoviyOtchet();
                    break;
                case "3":
                    RasschitatIPokazatBalans();
                    break;
                case "4":
                    SprognozirovatIPokazatRashodiNaSleduyuschiyMesyac();
                    break;
                case "5":
                    VivestiStatistiku();
                    break;
                case "6":
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие от 1 до 6.");
                    break;
            }
        }
    }
}