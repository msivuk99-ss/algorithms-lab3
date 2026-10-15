using System;
using System.Collections.Generic;

namespace Lab07
{
    public class Request
    {
        public string Name { get; set; }
        public int Minutes { get; set; }

        public Request(string name, int minutes)
        {
            Name = name;
            Minutes = minutes;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] lines = new string[]
            {
                "",
                "a + b",
                "{[a] + (b)}",
                "([)]",
                "a)",
                "(a[b]",
                "f(x[1]) * {y + (z)}"
            };

            List<Request> requests = new List<Request>
            {
                new Request("Довідка про навчання", 4),
                new Request("Академічна відпустка", 7),
                new Request("Копія наказу", 2),
                new Request("Виписка з оцінками", 6),
                new Request("Перескладання", 9),
                new Request("Студентський квиток", 3)
            };

            Console.WriteLine("=== Задача 1. Перевірка дужок ===");
            int balancedCount = 0;
            foreach (var line in lines)
            {
                bool balanced = IsBalanced(line);
                if (balanced) balancedCount++;
                string label = string.IsNullOrEmpty(line) ? "(порожній рядок)" : line;
                Console.WriteLine($"{label,-25} -> {(balanced ? "так" : "ні")}");
            }
            Console.WriteLine($"\nУсього збалансованих рядків: {balancedCount}\n");

            Console.WriteLine("=== Задача 2. Обробка заявок (Черга) ===");
            ProcessQueue(requests);

            Console.WriteLine("\n=== Демонстрація порожньої черги ===");
            ProcessQueue(new List<Request>());
        }

        public static bool IsBalanced(string line)
        {
            if (string.IsNullOrEmpty(line)) return true;

            Stack<char> stack = new Stack<char>();

            foreach (char ch in line)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();
                    if ((ch == ')' && top != '(') ||
                        (ch == ']' && top != '[') ||
                        (ch == '}' && top != '{'))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        public static void ProcessQueue(List<Request> requests)
        {
            if (requests == null || requests.Count == 0)
            {
                Console.WriteLine("Обробляти нічого — черга порожня.");
                return;
            }

            Queue<Request> queue = new Queue<Request>();
            foreach (var req in requests)
            {
                queue.Enqueue(req);
            }

            int currentTime = 0;
            int order = 1;
            int totalWaitTime = 0;

            while (queue.Count > 0)
            {
                Request current = queue.Dequeue();

                int startTime = currentTime;
                int endTime = startTime + current.Minutes;

                totalWaitTime += startTime;

                Console.WriteLine($"{order}. {current.Name,-25} з {startTime,2} до {endTime,2} хв");

                currentTime = endTime;
                order++;
            }

            double avgWaitTime = (double)totalWaitTime / requests.Count;
            Console.WriteLine($"\nОброблено заявок: {requests.Count}, загальний час: {currentTime} хв");
            Console.WriteLine($"Середній час очікування: {avgWaitTime:F2} хв");
        }
    }
}