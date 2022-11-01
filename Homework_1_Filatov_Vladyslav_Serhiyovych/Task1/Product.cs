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
        private decimal price;
        private double weight;
        public string Name { get { return name; } }
        public decimal Price {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Price can not be lower than 0");

                price = value;
            }
        }   
        public double Weight { 
            get { return weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Weight can not be lower than 0");

                weight = value;
            }
        }
        public Product()
        {
            name = "Null";
            price = 0;
            weight = 0;
        }
        public Product(string name, decimal price, double weight)
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
