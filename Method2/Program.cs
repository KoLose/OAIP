using System;
using System.Collections.Generic;
using System.Linq;

public static class FinanceManager
{
    // --- Этап 1: Структура хранения данных ---
    private static Dictionary<string, List<double>> tranzakcii = new Dictionary<string, List<double>>(); // tranzakcii = "transactions"

    // --- Этап 2: Добавление записей (вспомогательный метод для ввода данных) ---
    private static void DobavitTranzakciyuIzVvoda() // DobavitTranzakciyuIzVvoda = "AddTransactionFromInput"
    {
        Console.Write("Введите категорию (Доход, Продукты, Транспорт, Развлечения): ");
        string kategoriyaName = Console.ReadLine(); // kategoriyaName = "categoryName"
        Console.Write("Введите сумму: ");
        if (double.TryParse(Console.ReadLine(), out double tranzakciyaSumma)) // tranzakciyaSumma = "transactionSum"
        {
            DobavitTranzakciyu(kategoriyaName, tranzakciyaSumma);
        }
        else
        {
            Console.WriteLine("Некорректный ввод суммы.");
        }
    }

    public static void DobavitTranzakciyu(string kategoriyaName, double tranzakciyaSumma) // DobavitTranzakciyu = "AddTransaction"
    {
        if (!tranzakcii.ContainsKey(kategoriyaName))
        {
            tranzakcii.Add(kategoriyaName, new List<double>());
        }
        tranzakcii[kategoriyaName].Add(tranzakciyaSumma);
        Console.WriteLine("Запись добавлена.");
    }

    // --- Этап 3: Вывод информации ---
    public static void VivestiFinansoviyOtchet() // VivestiFinansoviyOtchet = "PrintFinanceReport"
    {
        Console.WriteLine("Финансовый отчет:");
        foreach (var kategoriya in tranzakcii)
        {
            double obschayaSumma = kategoriya.Value.Sum(); // obschayaSumma = "totalSum"
            double okruglyonniyItog = Math.Round(obschayaSumma, 2, MidpointRounding.AwayFromZero); // okruglyonniyItog = "roundedTotal"
            Console.WriteLine(kategoriya.Key + ": " + okruglyonniyItog.ToString() + " руб. - " + kategoriya.Value.Count + " операций");
        }
    }

    // --- Этап 4: Расчет баланса (вспомогательный метод для отображения баланса) ---
    private static void RasschitatIPokazatBalans() // RasschitatIPokazatBalans = "CalculateAndDisplayBalance"
    {
        double obschiyBalans = RasschitatBalans(); // obschiyBalans = "totalBalance"
        double okruglyonniyBalans = Math.Round(obschiyBalans, 2, MidpointRounding.AwayFromZero); // okruglyonniyBalans = "roundedBalance"
        Console.WriteLine("Текущий баланс: " + okruglyonniyBalans.ToString() + " руб.");
    }

    public static double RasschitatBalans() // RasschitatBalans = "CalculateBalance"
    {
        double doxod = 0; // doxod = "income"
        double rashodi = 0; // rashodi = "expenses"

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
    private static void SprognozirovatIPokazatRashodiNaSleduyuschiyMesyac() // SprognozirovatIPokazatRashodiNaSleduyuschiyMesyac = "PredictAndDisplayNextMonthExpenses"
    {
        double prognoziruemoeZnachenie = SprognozirovatRashodiNaSleduyuschiyMesyac(); // prognoziruemoeZnachenie = "predictedValue"
        double okruglyonniyPrognoz = Math.Round(prognoziruemoeZnachenie, 2, MidpointRounding.AwayFromZero); // okruglyonniyPrognoz = "roundedPrediction"
        Console.WriteLine("Прогнозируемые расходы на следующий месяц: " + okruglyonniyPrognoz.ToString() + " руб.");
    }

    public static double PoluchitSrednieRashodi(string kategoriyaName) // PoluchitSrednieRashodi = "GetAverageExpense"
    {
        if (tranzakcii.ContainsKey(kategoriyaName) && tranzakcii[kategoriyaName].Count > 0)
        {
            return tranzakcii[kategoriyaName].Average();
        }
        return 0;
    }

    public static double SprognozirovatRashodiNaSleduyuschiyMesyac() // SprognozirovatRashodiNaSleduyuschiyMesyac = "PredictNextMonthExpenses"
    {
        double obschiePrognoziruemieRashodi = 0; // obschiePrognoziruemieRashodi = "totalPredictedExpenses"

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
    public static void VivestiStatistiku() // VivestiStatistiku = "PrintStatistics"
    {
        double summaVsehRashodov = 0; // summaVsehRashodov = "allExpensesSum"
        Dictionary<string, double> rashodiPoKategoriyam = new Dictionary<string, double>(); // rashodiPoKategoriyam = "categoryExpenses"
        Dictionary<string, int> chastotaKategoriy = new Dictionary<string, int>(); // chastotaKategoriy = "categoryFrequency"

        // Вычисляем общую сумму расходов, расходы по категориям и частоту категорий
        foreach (var kategoriya in tranzakcii)
        {
            if (kategoriya.Key.ToLower() != "доход")
            {
                double itogPoKategorii = kategoriya.Value.Sum(); // itogPoKategorii = "categoryTotal"
                summaVsehRashodov += itogPoKategorii;
                rashodiPoKategoriyam[kategoriya.Key] = itogPoKategorii;
                chastotaKategoriy[kategoriya.Key] = kategoriya.Value.Count;
            }
        }

        // Выводим общую сумму расходов
        double okruglyonnayaSummaRashodov = Math.Round(summaVsehRashodov, 2, MidpointRounding.AwayFromZero); // okruglyonnayaSummaRashodov = "roundedExpensesSum"
        Console.WriteLine("Общая сумма расходов: " + okruglyonnayaSummaRashodov.ToString() + " руб.");

        // Определяем самую затратную категорию
        if (rashodiPoKategoriyam.Count > 0)
        {
            string samayaZtratnayaKategoriya = rashodiPoKategoriyam.OrderByDescending(x => x.Value).First().Key; // samayaZtratnayaKategoriya = "mostExpensiveCategory"
            double okruglyonnayaSummaDlyaSamoyZtratnoy = Math.Round(rashodiPoKategoriyam[samayaZtratnayaKategoriya], 2, MidpointRounding.AwayFromZero); // okruglyonnayaSummaDlyaSamoyZtratnoy = "roundedSumForMostExpensive"
            Console.WriteLine("Самая затратная категория: " + samayaZtratnayaKategoriya + " (" + okruglyonnayaSummaDlyaSamoyZtratnoy.ToString() + " руб.)");
        }
        else
        {
            Console.WriteLine("Нет данных о расходах.");
        }

        // Определяем самую частую категорию
        if (chastotaKategoriy.Count > 0)
        {
            string samayaChastayaKategoriya = chastotaKategoriy.OrderByDescending(x => x.Value).First().Key; // samayaChastayaKategoriya = "mostFrequentCategory"
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
                double procentZnachenie = (kategoriya.Value / summaVsehRashodov) * 100; // procentZnachenie = "percentageValue"
                double okruglyonniyProcent = Math.Round(procentZnachenie, 2, MidpointRounding.AwayFromZero); // okruglyonniyProcent = "roundedPercentage"
                double okruglyonnayaSummaKategorii = Math.Round(kategoriya.Value, 2, MidpointRounding.AwayFromZero); // okruglyonnayaSummaKategorii = "roundedCategorySum"
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
            string viborPolzovatelya = Console.ReadLine(); // viborPolzovatelya = "userChoice"

            switch (viborPolzovatelya)
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