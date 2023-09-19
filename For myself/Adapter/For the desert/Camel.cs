using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.For_the_desert
{
    internal class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Camel walking on the sands of the desert");
        }
    }
}
