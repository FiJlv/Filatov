using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Buy 
    {
        private Product product;
        private uint count;
        private double totalPrice;

        public Product Product { get { return product; } }
        public uint Count
        {
            get { return count; } set {count = value;}
        }
        public double TotalPrice { get { return totalPrice; } }

        public Buy(Product product, uint count)
        {
            this.product = product;
            this.count = count;
            totalPrice = product.Price * count;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(product);
            result.Append($"\nКiлькiсть: {count} шт");
            result.Append($"\nЗагальна сума: {totalPrice} {Product.Currency}\n");

            return result.ToString();
        }
    }
}
