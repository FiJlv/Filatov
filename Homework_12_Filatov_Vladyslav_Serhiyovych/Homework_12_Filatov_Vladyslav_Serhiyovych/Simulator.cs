using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12_Filatov_Vladyslav_Serhiyovych
{
    class Simulator
    {
        public List<CashRegister> CashRegisters;
        public Simulator(int count)
        {
            CashRegisters = new List<CashRegister>();
            for (int i = 0; i < count; i++)
                CashRegisters.Add(new CashRegister(i + 1, true));

            List<Person> persons = FileHandler.ReadPersons();

            foreach (Person person in persons)
                AddToQueue(person);
        }

        public void Run()
        {
            int count = CashRegisters.Where(cr => cr.IsOpen).Count();
            Task[] tasks = new Task[count];
            for (int i = 0; i < tasks.Length; i++)
            {
                CashRegister cashRegister = CashRegisters[i];
                
                    tasks[i] = Task.Factory.StartNew(() =>
                    {
                        while (!(cashRegister.Queue.Count == 0))
                        {
                            Person person = cashRegister.Dequeue();
                            FileHandler.Serviced(person, cashRegister);
                            Thread.Sleep(1000);
                        }
                    });       
            }

            Task.WaitAll(tasks);
        }   

        private void AddToQueue(Person person)
        {
            List<int> positionList = new List<int>(CashRegisters.Count);
            foreach (CashRegister cashRegister in CashRegisters.Where(cr => cr.IsOpen))
            {
                if (cashRegister.Queue.Count == CashRegisters.Min(x => x.Queue.Count))
                {
                    positionList.Add(cashRegister.Y);
                }
            }

            (int, int) nearest = CashRegister.NearestCashRegister(person.Coordinate, positionList);

            foreach (var cashRegiser in CashRegisters)
            {
                if (cashRegiser.Y.Equals(nearest.Item2))
                {
                    cashRegiser.Enqueue(person);
                    FileHandler.Add(person, cashRegiser);
                    Thread.Sleep(1000);
                }
            }
        }

        public void Close(int numberOfCashRegister)
        {
            foreach(CashRegister cashRegister in CashRegisters)
            {
                if (cashRegister.Y == numberOfCashRegister)
                {
                    cashRegister.Close();
                    foreach (Person person in cashRegister.GetPersons())
                    {
                        AddToQueue(person);
                    }
                }              
            }
        }
    }
}
