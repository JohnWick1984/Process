using System;
using System.Diagnostics;

class Program
{
    static int CountSvchostProcesses()
    {
        int svchostCount = 0;
        Process[] processes = Process.GetProcesses();

        foreach (Process process in processes)
        {
            if (process.ProcessName.ToLower().Contains("svchost"))
            {
                svchostCount++;
            }
        }

        return svchostCount;
    }

    static void Main()
    {
        int svchostCount = CountSvchostProcesses();
        Console.WriteLine($"Количество процессов с именем 'svchost': {svchostCount}");
        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}
