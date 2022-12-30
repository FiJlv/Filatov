using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12_Filatov_Vladyslav_Serhiyovych
{
    static class FileHandler
    {
        static string personsPath = "C:\\All\\Filatov\\Homework_12_Filatov_Vladyslav_Serhiyovych\\Homework_12_Filatov_Vladyslav_Serhiyovych\\Persons.txt";
        static string enteredPath = "C:\\All\\Filatov\\Homework_12_Filatov_Vladyslav_Serhiyovych\\Homework_12_Filatov_Vladyslav_Serhiyovych\\Entered.txt";
        static string servicedPath = "C:\\All\\Filatov\\Homework_12_Filatov_Vladyslav_Serhiyovych\\Homework_12_Filatov_Vladyslav_Serhiyovych\\Serviced.txt";
        private static readonly object _lock = new object();

        public static List<Person> ReadPersons()
        {
            using (StreamReader sr = new StreamReader(personsPath))
            {
                int countOfPersons = File.ReadAllLines(personsPath).Length;
                List<Person> persons = new List<Person>(countOfPersons);
                string[] personList = FileReadToEnd(sr, countOfPersons);

                for (int i = 0; i < countOfPersons; i++)                
                    if (Person.ParsePerson(personList[i], out Person person))            
                        persons.Add(person);

                return persons;
            }
        }

        public static void Add(Person person, CashRegister cashRegister)
        {
            lock (_lock)
            {
                using (StreamWriter sw = new StreamWriter(enteredPath, true))
                {
                    sw.WriteLine($"{person}Got in queue at the {cashRegister.Y + 1} cash register at {DateTime.Now}\n ");
                }
            }
        }

        public static void Fill(Person person)
        {
            lock (_lock)
            {
                using (StreamWriter sw = new StreamWriter(servicedPath, true))
                {
                    sw.WriteLine($"{person}Has been serviced at {DateTime.Now}\n ");
                }
            }
        }

        public static string[] FileReadToEnd(StreamReader sr, int count)
        {
            string[] result = new string[count];
            while (!sr.EndOfStream)
            {
                //Thread.Sleep(5000);  
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = sr.ReadLine() ?? "";
                }
            }
            return result;
        }
    }
}
