using Homework_5_Filatov_Vladyslav_Serhiyovych;
using System.IO;
using static System.Net.WebRequestMethods;
class Program
{

    static void Main(string[] args)
    {

        //HW5 ще в процесi, не доробив





        Accounting accounting;
        //using (StreamReader sr = new StreamReader("Text.txt"))
        //{
        //     accounting = new Accounting(FileHandler.FileReadToEnd(sr));
        //     FileHandler.ConsoleWrite(accounting.ToString());
        //     accounting.NoElectricityUsed();
        //}

        using (StreamWriter sw = new StreamWriter("Text.txt"))
        {
            accounting = new Accounting(FileHandler.FileWriteToEnd(sw,2));
            FileHandler.ConsoleWrite(accounting.ToString());
            sw.WriteLine(accounting.ToString());
        }

    }
}






