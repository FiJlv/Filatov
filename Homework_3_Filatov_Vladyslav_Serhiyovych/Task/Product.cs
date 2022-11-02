using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Product
    {
        private string name;
        private double price;
        private double weight;
        public string Name
        {  
            get { return name; }
            set 
            { 
                if(String.Compare(value, "") != 0)
                    name = value; 
                else
                    throw new ArgumentException("Name must be filled");

            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Price can not be lower than 0");
                else
                    price = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Weight can not be lower than 0");
                else
                    weight = value;
            }
        }
        public Product()
        {
            name = "Null";
            price = 0;
            weight = 0;
        }
        public Product(string name, double price, double weight)
        {   
            this.name = name;
            this.price = price;
            this.weight = weight;
        }

        public virtual void ChangePrice(double percentage)
        {
            if(percentage >=-1 || percentage <= 1)
                Price += Price * percentage;
            else
                throw new ArgumentException("Wrong! Сhoose a value from -1 to 1");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"Назва: {name}");
            result.Append($"\nЦiна: {price} грн");
            result.Append($"\nВага: {weight} кг");
            return result.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            else
            {
                Product product = (Product)obj;
                return this.Name == product.Name && this.Price == product.Price && this.Weight == product.Weight;
            }
        }
    }
}
