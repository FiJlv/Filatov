using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Check
    {
        public static void Print(Product product)
        {
            Console.WriteLine(product);
        }

        public static void Print(Buy buy)
        {
            Console.WriteLine(buy);
        }

        public static void Print(Cart cart)
        {
            Console.WriteLine(cart);
        }
    }
}
