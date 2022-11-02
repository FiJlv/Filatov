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
        private List<Product> productList;
        private int count;
        private double totalPrice;
        private double totalWeight;

        public int Count
        {
            get { return count; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Count can not be lower than 0");

                count = value;
            }
        }
        public double TotalPrice { get { return totalPrice; } }
        public double TotalWeight { get { return totalWeight; } }
        public List<Product> ProductList { get { return productList; } }

        public Buy()
        {
            productList = new List<Product>();
            productList.Add(new Product("Null", 0, 0));
        }

        public Buy(Product product, int count)
        {
            productList = new List<Product>();
            productList.Add(product);
            this.count = count;
            totalPrice = product.Price * count;
            totalWeight = product.Weight * count;
        }

        public Buy(params Product[] products)
        {
            productList = new List<Product>();
            count = products.Length;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null)
                    throw new ArgumentNullException("Null");
                else
                    productList.Add(products[i]);
            }
            totalPrice = productList.Sum(product => product.Price);
            totalWeight = productList.Sum(product => product.Weight);
        }
        public override string ToString()
        {

            var result = new StringBuilder();

            for (int i = 0; i < ProductList.Count; ++i)
            {
                result.Append("\n" + ProductList[i].ToString());
            }

            result.Append($"\nТовару куплено: {count} шт");
            result.Append($"\nНа суму: { totalPrice} грн");
            result.Append($"\nЗагальна вага: {totalWeight} кг");

            return result.ToString();
        }
    }
}
