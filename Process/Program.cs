using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int svchostCount = CountSvchostProcesses();
        Console.WriteLine($"Количество процессов с именем 'svchost': {svchostCount}");
    }

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
}
