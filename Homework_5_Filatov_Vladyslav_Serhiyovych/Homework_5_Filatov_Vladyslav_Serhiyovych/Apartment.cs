using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5_Filatov_Vladyslav_Serhiyovych
{
    class Apartment
    {
        public uint Number { get; set; }
        public string Street { get; set; }
        public string LastName { get; set; }
        public uint InputMeterReading { get; set; }
        public uint OutputMeterReading { get; set; }
        public double AmountOfExpenses { get; set; }
        public DateTime FirstMonth { get; set; }
        public DateTime SecondMonth { get; set; }
        public DateTime ThirdMonth { get; set; }

        public Apartment()
        {
            Number = 0;
            Street = "";
            LastName = "";
            InputMeterReading = 0;
            OutputMeterReading = 0;
            AmountOfExpenses = 0;
            FirstMonth = DateTime.Now;
            SecondMonth = DateTime.Now;
            ThirdMonth = DateTime.Now;
        }

        public Apartment(uint number, string street, string lastName, uint inputMeterReading, uint outputMeterReading, DateTime firstMonth, DateTime secondMonth, DateTime thirdMonth)
        {
            Number = number;
            Street = street;
            LastName = lastName;
            InputMeterReading = inputMeterReading;
            OutputMeterReading = outputMeterReading;
            AmountOfExpenses = outputMeterReading - inputMeterReading;
            FirstMonth = firstMonth;
            SecondMonth = secondMonth;
            ThirdMonth = thirdMonth;
        }

        public static bool TryParse(string input, out Apartment result)
        {
            result = new Apartment();
            string[] elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool ifParsed;
            try
            {
                result.Number = Convert.ToUInt32(elements[0]);
                result.Street = elements[1];
                result.LastName = elements[2];
                result.InputMeterReading = Convert.ToUInt32(elements[3]);
                result.OutputMeterReading = Convert.ToUInt32(elements[4]);
                result.AmountOfExpenses = ((Convert.ToUInt32(elements[4])) - Convert.ToUInt32(elements[3]))*KW.KWPrice;
                result.FirstMonth = Convert.ToDateTime(elements[5]);
                result.SecondMonth = Convert.ToDateTime(elements[6]);
                result.ThirdMonth = Convert.ToDateTime(elements[7]);

                ifParsed = true;
            }
            catch (FormatException)
            {
                ifParsed = false;
            }
            catch (NullReferenceException)
            {
                ifParsed = false;
            }
            catch (IndexOutOfRangeException)
            {
                ifParsed = false;
            }

            return ifParsed;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"Номер квартири: {Number}");
            str.Append($"\nВулиця: {Street}");
            str.Append($"\nПрiзвище: {LastName}");
            str.Append($"\nВхiдний показ - {InputMeterReading}, вихiдний показ - {OutputMeterReading}");
            str.Append($"\nДати зняття показiв: {FirstMonth.ToShortDateString()}, {SecondMonth.ToShortDateString()}, {ThirdMonth.ToShortDateString()}");
            str.Append($"\nСума витрат за квартал: {AmountOfExpenses}");
            str.Append($"\n");
            return str.ToString();
        }
    }
}
