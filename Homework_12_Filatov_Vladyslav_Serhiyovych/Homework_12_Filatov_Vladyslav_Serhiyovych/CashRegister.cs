using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Homework_12_Filatov_Vladyslav_Serhiyovych
{
    public delegate void CashRegisterIsOverloaded(string message);
    class CashRegister
    {
        private bool isOpen;
        private PriorityQueue<Person, Status> queue;
        private int y;
        public bool IsOpen { get { return isOpen; } private set { isOpen = value; } }
        public int Y{ get { return y; } private set { y = value; } }
        public PriorityQueue<Person, Status> Queue {
            get { return queue; }
        }

        public event CashRegisterIsOverloaded? Overloaded;
        private const int maxCount = 10;

        public CashRegister(int y, bool isOpen)
        {
            Y = y;
            IsOpen = isOpen;
            queue = new PriorityQueue<Person, Status>();
        }

        public void Close() => isOpen = false;
        public void Enqueue(Person person) 
        {
            if (queue.Count <= maxCount)
                queue.Enqueue(person, person.Priority());
            else
                Overloaded?.Invoke("Cash register is overloaded");

        } 
        public Person Dequeue() => queue.Dequeue();

        public static (int, int) NearestCashRegister((int,int) coord, List<int> positions)
        {
            (int, int) nearestCashRegister = (0,0);
            double dist;    
            double min = double.MaxValue;

            foreach(int position in positions)
            {
                dist = (int)Math.Sqrt((Math.Pow(coord.Item1, 2)
                - Math.Pow(0, 2)) + (Math.Pow(coord.Item2, 2) - Math.Pow(position, 2)));
                if(dist < min)
                {
                    min = dist;
                    nearestCashRegister = (0, position);
                }
            }

            return nearestCashRegister!;
        }

        public List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < queue.Count; i++)
                persons.Add(queue.Dequeue());

            return persons;
        }
    }
}
