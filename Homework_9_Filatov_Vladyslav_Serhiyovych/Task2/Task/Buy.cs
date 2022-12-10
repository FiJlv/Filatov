using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task;
using Task.Models;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Buy : IComparable<Buy>
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

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            else
            {
                Buy buy = (Buy)obj;
                return this.Product.Name == buy.Product.Name &&
                       this.Product.Price == buy.Product.Price &&
                       this.Product.Weight == buy.Product.Weight &&
                       this.Product.WeightUnits == buy.Product.WeightUnits &&
                       this.Product.Currency == buy.Product.Currency &&
                       this.Count == buy.Count &&   
                       this.TotalPrice == buy.TotalPrice;
            }
        }

        public int CompareTo(Buy? buy)
        {
            if (buy is null)
                throw new ArgumentException("Incorrect value");
            return (int)(Count - buy.Count);
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
