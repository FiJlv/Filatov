using Homework_5_Filatov_Vladyslav_Serhiyovych;
using System.IO;
using static System.Net.WebRequestMethods;
class Program
{

    static void Main(string[] args)
    {
        Accounting accounting;
        using (StreamReader sr = new StreamReader(Settings.pathforRead))
        {
            accounting = new Accounting(FileHandler.FileReadToEnd(sr));
            FileHandler.ConsoleWrite(accounting.ToString());
        }

        accounting.BiggestDebtor();
        accounting.NoElectricityUsed();

        using (StreamWriter sw = new StreamWriter(Settings.pathforWrite))
        {
            accounting = new Accounting(FileHandler.FileWriter(sw, 4));
            FileHandler.ConsoleWrite(accounting.ToString());
            sw.WriteLine(accounting.ToString());
        }

        Console.WriteLine();


    }
}






