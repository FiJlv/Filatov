using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Buy 
    {
        private int count;
        private int totalPrice;

        public int Count { get { return count; } }
        public int TotalPrice { get { return totalPrice; } }
        public Buy()
        {
            count = 0;
        }

        public Buy(Product product, int count)
        {
            this.count = count;
            totalPrice = product.Price * count;
        }
        public override string ToString()
        {
            return $"\nТовару куплено: {count} шт \nНа суму: {totalPrice} грн";
        }

    }
}
