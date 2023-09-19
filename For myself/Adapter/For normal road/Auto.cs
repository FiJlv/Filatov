using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("The car is driving on the road");
        }
    }
}
