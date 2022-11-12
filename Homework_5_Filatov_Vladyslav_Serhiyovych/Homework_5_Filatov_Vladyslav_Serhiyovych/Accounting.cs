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


        public void BiggestDebtor()
        {
            SortedSet<Apartment> apartmentList = new SortedSet<Apartment>(new SortByAmountOfExpenses());
            foreach (Apartment olimpiad in listOfApartaments)
            {
                apartmentList.Add(olimpiad);
            }

            Console.WriteLine($"Найбiльша заборгованiсть у {apartmentList.Last().LastName}.");
        }

        public List<uint> AmountOfExpensesForEveryApartment()
        {
            List<uint> amountOfExpensesForEveryApartment = new List<uint>();
            foreach (Apartment apartment in listOfApartaments)
            {
                uint amountOfExpenses = (uint)((apartment.ThirdMonthReadings - apartment.FirstMonthReadings) * Settings.KWPrice);
                amountOfExpensesForEveryApartment.Add(amountOfExpenses);
            }

            return amountOfExpensesForEveryApartment;
        }

        public void NoElectricityUsed()
        {
            foreach (Apartment apartament in listOfApartaments)
            {
                if (apartament.FirstMonthReadings == apartament.ThirdMonthReadings)
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
    }
}
