using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5_Filatov_Vladyslav_Serhiyovych
{
    class FileHandler
    {
        public static string FileReader(StreamReader sr)
        {
            string result = sr.ReadLine() ?? "";
            return result;
        }

        public static List<string> FileReadToEnd(StreamReader sr)
        {
            List<string> result = new List<string>();
            while (!sr.EndOfStream)
            {
                result.Add(sr.ReadLine()??"");
            }
            return result;
        }


        public static List<Apartment> FileWriteToEnd(StreamWriter sw, int count)
        {
            List<Apartment> result = new List<Apartment>();

            for (int i = 0; i < count; i++)
            {
                Apartment newApartament = new Apartment();

                Console.WriteLine("Введiть номер квартири ");
                newApartament.Number = Convert.ToUInt32(Console.ReadLine());

                Console.WriteLine("Введiть назву вулицi");
                newApartament.Street = Console.ReadLine();

                Console.WriteLine("Введiть прiзвище");
                newApartament.LastName = Console.ReadLine();

                Console.WriteLine("Введiть вхiдний показ");
                newApartament.InputMeterReading = Convert.ToUInt32(Console.ReadLine());

                Console.WriteLine("Введiть вихiдний показ");
                newApartament.OutputMeterReading = Convert.ToUInt32(Console.ReadLine());

                newApartament.AmountOfExpenses = ((newApartament.OutputMeterReading - newApartament.InputMeterReading) * 2);

                Console.WriteLine("Введiть дату 1 мiсяця кварталу");
                newApartament.FirstMonth = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Введiть дату 2 мiсяця кварталу");
                newApartament.SecondMonth = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Введiть дату 3 мiсяця кварталу");
                newApartament.ThirdMonth = Convert.ToDateTime(Console.ReadLine());

                result.Add(newApartament);
            }

            return result;
        }

        public static void ConsoleWrite(string info)
        {                       
             Console.WriteLine(info);
        }
    }
}
