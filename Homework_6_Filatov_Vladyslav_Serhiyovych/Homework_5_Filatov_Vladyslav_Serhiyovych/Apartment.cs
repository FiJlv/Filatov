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
        public DateTime FirstMonth { get; set; }
        public uint FirstMonthReadings { get; set; }
        public DateTime SecondMonth { get; set; }
        public uint SecondMonthReadings { get; set; }
        public DateTime ThirdMonth { get; set; }
        public uint ThirdMonthReadings { get; set; }
        public uint AmountOfExpenses { get; set; }

        public Apartment()
        {
            Number = 0;
            Street = "";
            LastName = "";
            FirstMonth = DateTime.Now;
            FirstMonthReadings = 0;
            SecondMonth = DateTime.Now;
            SecondMonthReadings = 0;
            ThirdMonth = DateTime.Now;
            ThirdMonthReadings = 0;
            AmountOfExpenses = 0;
        }

        public Apartment(uint number, string street, string lastName,
            DateTime firstMonth, DateTime secondMonth, DateTime thirdMonth,
            uint firstMonthReadings, uint secondMonthReadings, uint thirdMonthReadings)
        {
            Number = number;
            Street = street;
            LastName = lastName;
            FirstMonth = firstMonth;
            FirstMonthReadings = firstMonthReadings;
            SecondMonth = secondMonth;
            SecondMonthReadings = secondMonthReadings;
            ThirdMonth = thirdMonth;
            ThirdMonthReadings = thirdMonthReadings;
            AmountOfExpenses = ((uint)((thirdMonthReadings - firstMonthReadings)*Settings.KWPrice));
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
                result.FirstMonth = Convert.ToDateTime(elements[3]);
                result.FirstMonthReadings = Convert.ToUInt32(elements[4]);
                result.SecondMonth = Convert.ToDateTime(elements[5]);
                result.SecondMonthReadings = Convert.ToUInt32(elements[6]);
                result.ThirdMonth = Convert.ToDateTime(elements[7]);
                result.ThirdMonthReadings = Convert.ToUInt32(elements[8]);
                result.AmountOfExpenses = (uint)(((Convert.ToUInt32(elements[8])) - Convert.ToUInt32(elements[4])) * Settings.KWPrice);

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
            str.Append($"\nПрiзвище: {LastName}");
            str.Append($"\nВхiдний показ - {FirstMonthReadings}, вихiдний показ - {ThirdMonthReadings}");
            str.Append($"\nПерший мiсяць: {FirstMonth.ToShortDateString()} - {FirstMonthReadings}");
            str.Append($"\nДругий мiсяць: {SecondMonth.ToShortDateString()} - {SecondMonthReadings}");
            str.Append($"\nТретiй мiсяць: {ThirdMonth.ToShortDateString()} - {ThirdMonthReadings}");
            str.Append($"\nКiлькicть витрат за квартал: {AmountOfExpenses}");
            str.Append($"\n");
            return str.ToString();
        }
    }
}
