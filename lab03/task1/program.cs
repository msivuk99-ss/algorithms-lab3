using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> logs = new List<string>();

        logs.Add("10:00 - Запуск системи");
        logs.Add("10:05 - Користувач увійшов");
        logs.Add("10:10 - Помилка підключення");
        logs.Add("10:15 - Повторна спроба");
        logs.Add("10:20 - Успішне з'єднання");

        Console.WriteLine("--- Журнал у зворотному порядку ---");
        for (int i = logs.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(logs[i]);
        }
    }
}