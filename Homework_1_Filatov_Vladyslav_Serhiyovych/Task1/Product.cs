using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Product
    {
        private string name;
        private int price;
        private double weight;
        public int Price { get { return price; } }
        public string Name { get { return name; } }
        public double Weight { get { return weight; } }
        public Product()
        {
            name = "Null";
            price = 0;
            weight = 0;
        }
        public Product(string name, int price, double weight)
        {   
            this.name = name;
            this.price = price;
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"Назва: {name} \nЦiна: {price} грн \nВага: {weight} кг.";
        }
    }
}
