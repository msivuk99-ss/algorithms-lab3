using System;

class Program
{
    static int comparisons = 0;

    static int[] data = new int[] { 42, 8, 60, 19, 3, 55, 12, 31, 68, 24, 49, 37, 71, 5, 27 };
    static int[] sortedData = new int[] { 3, 5, 8, 12, 19, 24, 27, 31, 37, 42, 49, 55, 60, 68, 71 };

    static int LinearSearch(int[] items, int target)
    {
        for (int i = 0; i < items.Length; i++)
        {
            comparisons++;
            if (items[i] == target)
            {
                return i;
            }
        }
        return -1;
    }

    static int BinarySearch(int[] items, int target)
    {
        int low = 0;
        int high = items.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            comparisons++;

            if (items[mid] == target)
            {
                return mid;
            }
            else if (items[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return -1;
    }

    static void Report(string name, int[] items, int target)
    {
        comparisons = 0;
        int index = (name == "linear") ? LinearSearch(items, target) : BinarySearch(items, target);
        Console.WriteLine($"{name,-7} | Target: {target,-2} | Index: {index,-2} | Comparisons: {comparisons}");
    }

    static void Main()
    {
        Console.WriteLine("=== ЧАСТИНА 2: ТЕСТУВАННЯ ВИПАДКІВ ===");

        int[] singleElementArray = new int[] { 42 };
        int[] emptyArray = new int[] { };

        Console.WriteLine("1. Перший (3):");
        Report("linear", sortedData, 3);
        Report("binary", sortedData, 3);

        Console.WriteLine("\n2. Останній (71):");
        Report("linear", sortedData, 71);
        Report("binary", sortedData, 71);

        Console.WriteLine("\n3. Посередині (31):");
        Report("linear", sortedData, 31);
        Report("binary", sortedData, 31);

        Console.WriteLine("\n4. Відсутнє, менше за всі (1):");
        Report("linear", sortedData, 1);
        Report("binary", sortedData, 1);

        Console.WriteLine("\n5. Відсутнє, більше за всі (99):");
        Report("linear", sortedData, 99);
        Report("binary", sortedData, 99);

        Console.WriteLine("\n6. Відсутнє, між сусідніми (50):");
        Report("linear", sortedData, 50);
        Report("binary", sortedData, 50);

        Console.WriteLine("\n7. Масив з одного елемента [42] (target 42):");
        Report("linear", singleElementArray, 42);
        Report("binary", singleElementArray, 42);

        Console.WriteLine("\n8. Порожній масив [] (target 42):");
        Report("linear", emptyArray, 42);
        Report("binary", emptyArray, 42);

        Console.WriteLine("\n=== ЧАСТИНА 3: ЕКСПЕРИМЕНТ (Невідсортований масив data) ===");
        comparisons = 0;
        int badIndex = BinarySearch(data, 55);
        Console.WriteLine($"BinarySearch(data, 55) -> Індекс: {badIndex}, Порівнянь: {comparisons}");
    }
}