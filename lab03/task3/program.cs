using System;

class Program
{
    static void Main()
    {
        int N = 5;
        string[] buffer = new string[N];
        int writeIndex = 0;
        int totalEvents = 0;

        string[] incomingEvents = new string[]
        {
            "Подія 1", "Подія 2", "Подія 3", "Подія 4",
            "Подія 5", "Подія 6", "Подія 7", "Подія 8"
        };

        foreach (var ev in incomingEvents)
        {
            buffer[writeIndex] = ev;
            writeIndex = (writeIndex + 1) % N;
            totalEvents++;
        }

        Console.WriteLine("--- Останні N подій (від найстарішої до найновішої) ---");
        int count = Math.Min(totalEvents, N);
        int startIndex = (totalEvents < N) ? 0 : writeIndex;

        for (int i = 0; i < count; i++)
        {
            int index = (startIndex + i) % N;
            Console.WriteLine(buffer[index]);
        }
    }
}