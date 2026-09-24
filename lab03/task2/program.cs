using System;

class Program
{
    struct Transaction
    {
        public int Month; // 1-12
        public decimal Amount;

        public Transaction(int month, decimal amount)
        {
            Month = month;
            Amount = amount;
        }
    }

    static void Main()
    {
        Transaction[] transactions = new Transaction[]
        {
            new Transaction(1, 1500.50m),
            new Transaction(3, 2000.00m),
            new Transaction(1, 500.00m),
            new Transaction(12, 3400.10m),
            new Transaction(5, 1200.00m),
            new Transaction(3, 300.00m)
        };

        decimal[] monthlyTotals = new decimal[12];

        foreach (var tx in transactions)
        {
            monthlyTotals[tx.Month - 1] += tx.Amount;
        }

        Console.WriteLine("--- Підсумки за місяцями ---");
        for (int i = 0; i < monthlyTotals.Length; i++)
        {
            Console.WriteLine($"Місяць {i + 1:D2}: {monthlyTotals[i]} грн");
        }
    }
}