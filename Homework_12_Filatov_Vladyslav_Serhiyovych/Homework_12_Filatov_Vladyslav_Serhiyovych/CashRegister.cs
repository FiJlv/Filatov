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
    class CashRegister
    {     
        private bool isOpen;
        private PriorityQueue<Person, Status> queue;
        private int y;
        public bool IsOpen { get { return isOpen; } private set { isOpen = value; } }
        public int Y{ get { return y; } private set { y = value; } }
        public PriorityQueue<Person, Status> Queue { get { return queue; } }
        public CashRegister(int y, bool isOpen)
        {
            Y = y;
            IsOpen = isOpen;
            queue = new PriorityQueue<Person, Status>();
        }

        public void Close()
        {
            isOpen = false;
        }
        public bool IsEmpty() => queue.Count == 0;
        public void Enqueue(Person person) => queue.Enqueue(person, person.Priority());
        public Person Dequeue() => queue.Dequeue();

        public List<Person> GetList() 
        {
            List<Person> list = new List<Person>();
            while (queue.Count > 0)
                list.Add(queue.Dequeue());

            return list;
        }

        public static (int, int) NearestCashRegister((int,int) coord, IEnumerable<int> positions)
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
    }
}
