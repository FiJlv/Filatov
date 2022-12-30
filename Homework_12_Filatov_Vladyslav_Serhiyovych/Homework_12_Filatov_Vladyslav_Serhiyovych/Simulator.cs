using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12_Filatov_Vladyslav_Serhiyovych
{
    class Simulator
    {
        private List<CashRegister> CashRegisters;
        private List<Person> persons;
        public Simulator(int count)
        {
            CashRegisters = new List<CashRegister>();
            for (int i = 0; i < count; i++)
                CashRegisters.Add(new CashRegister(i, true));

            persons = FileHandler.ReadPersons();

            foreach (Person person in persons)
            {
                EnqueuePerson(person);
                Console.WriteLine(person);
            }

            Start();
        }

        private void Start()
        {
            Task[] tasks = new Task[CashRegisters.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                var cashRegister = CashRegisters[i];
                tasks[i] = Task.Factory.StartNew(() => Process(cashRegister));
            }

            Task.WaitAll(tasks);

            DistributionAfterClosing(tasks);
        }

        private void Process(CashRegister cashRegister)
        {
            if (!cashRegister.IsOpen)
                return;

            Person person = cashRegister.Dequeue();

            FileHandler.Fill(person);
            Thread.Sleep(5000);
        }     

        private void EnqueuePerson(Person person)
        {
            int minLength = CashRegisters
                .Where(x => x.IsOpen)
                .Min(x => x.Queue.Count);

            IEnumerable<int> positionList = CashRegisters
                .Where(x => x.IsOpen && x.Queue.Count == minLength)
                .Select(x => x.Y);

            (int,int) nearest = CashRegister.NearestCashRegister(person.Coordinate, positionList);

            foreach (var cashRegiser in CashRegisters)
                if (cashRegiser.Y.Equals(nearest.Item2))
                {
                    cashRegiser.Enqueue(person);
                    FileHandler.Add(person, cashRegiser);
                } 
        }

        private void DistributionAfterClosing(Task[] tasks)
        {
            var usersFromClosedCashRegister = CloseTheCashRegister(CashRegisters[CashRegisters.Count - 1]);

            foreach (var person in usersFromClosedCashRegister)
                EnqueuePerson(person);

            tasks = new Task[CashRegisters.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                var cashRegister = CashRegisters[i];
                tasks[i] = Task.Factory.StartNew(() => ProcessAll(cashRegister));
            }
            Task.WaitAll(tasks);
        }
        private void ProcessAll(CashRegister cashRegister)
        {
            if (!cashRegister.IsOpen)
                return;

            while (!cashRegister.IsEmpty())
            {
                Person p = cashRegister.Dequeue();
                Thread.Sleep(5000);
            }
        }
        private List<Person> CloseTheCashRegister(CashRegister cashRegister)
        {
            cashRegister.Close();
            List<Person> list = cashRegister.GetList();

            return list;
        }
    }
}
