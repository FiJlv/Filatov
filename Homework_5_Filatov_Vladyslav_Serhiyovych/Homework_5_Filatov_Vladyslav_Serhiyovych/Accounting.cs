using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5_Filatov_Vladyslav_Serhiyovych
{
    class Accounting
    { 
        List<Apartment> listOfApartaments;
        public Accounting()
        {
            listOfApartaments = new List<Apartment>();
        }
        public Accounting(List<string> strApartaments)
        {
            listOfApartaments = new List<Apartment>();
            for (int i = 0; i < strApartaments.Count; i++)
            {
                Apartment apartment;
                if (Apartment.TryParse(strApartaments[i], out apartment))
                    listOfApartaments.Add(apartment);
                else
                    throw new Exception("");
            }
        }

        public Accounting(List<Apartment> apartaments)
        {
            listOfApartaments = new List<Apartment>();
            foreach (Apartment apartament in apartaments)
            {
                listOfApartaments.Add(apartament);
            }
        }

        public List<uint> AmountOfExpensesForEveryApartment()
        {
            List<uint> amountOfExpensesForEveryApartment = new List<uint>();
            foreach (Apartment apartment in listOfApartaments)
            {
                uint amountOfExpenses = (uint)((apartment.OutputMeterReading - apartment.InputMeterReading) * KW.KWPrice);
                amountOfExpensesForEveryApartment.Add(amountOfExpenses);
            }
            return amountOfExpensesForEveryApartment;
        }

        public void BiggestDebtor()
        {
            SortedSet<Apartment> apartmentList = new SortedSet<Apartment>(new SortByAmountOfExpenses());
            foreach (Apartment olimpiad in listOfApartaments)
            {
                apartmentList.Add(olimpiad);
            }

            Console.WriteLine($"Найбiльша заборгованiсть у {apartmentList.First().LastName}.");
        }

        public void NoElectricityUsed()
        {
            foreach (Apartment apartament in listOfApartaments)
            {
                if (apartament.InputMeterReading == apartament.OutputMeterReading)
                {
                    Console.WriteLine($"Квартира в якiй не використовувалась електроенергiя {apartament.Number}");
                }
            }
        }

        public void Add(Apartment apartment)
        {
            listOfApartaments.Add(apartment);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var item in listOfApartaments)
            {
                str.Append(item + "\n");
            }
            return str.ToString();
        }

        //public void NumberOfDaysSinceLastMeterReading()
        //{

        //    Console.Write("Выберете год: ");

        //    DateTime startDate = new DateTime(int.Parse(Console.ReadLine()), 1, 1);

        //    Console.Write("Выберете квартал: ");

        //    int quarter = Convert.ToInt32(Console.ReadLine());

        //    int counter = 0;

        //    var quartersInfo = Enumerable.Range(0, 12)
        //        .Select(startDate.AddMonths).ToList()
        //        .GroupBy(_ => counter++ / 3)
        //        .Select(v => new
        //        {
        //            quarterDates = String.Join(", ", v.Select(s => s.ToShortDateString())),
        //            quarterNumber = v.Key + 1,
        //            countDaysInQuarter = v.Select(s => DateTime.DaysInMonth(s.Year, s.Month)).Sum()
        //        });

        //    Console.Write("Количество дней в квартале: ");

        //    foreach (var row in quartersInfo.Where(w => w.quarterNumber == quarter).Select(s => s.countDaysInQuarter))
        //    {
        //        Console.WriteLine(row);
        //    }
        //}
    }
}
