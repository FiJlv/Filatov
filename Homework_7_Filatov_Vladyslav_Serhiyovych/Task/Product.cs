using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task.Enums;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Product : IComparable<Product>
    {
        private string name;
        private double price;
        private double weight;
        private Currency currency;
        private WeightUnits weightUnits;
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
        public Currency Currency
        {
            get { return currency; }
            set
            {
                if (Enum.IsDefined(typeof(Currency), value))
                {
                    currency = value;
                }
                else
                    throw new ArgumentException("It is not a currency");
            }
        }
        public WeightUnits WeightUnits
        {
            get { return weightUnits; }
            set
            {
                if (Enum.IsDefined(typeof(WeightUnits), value))
                {
                    weightUnits = value;
                }
                else
                    throw new ArgumentException("It is not a weight units");
            }
        }
        public Product()
        {
            Name = "Null";
            Price = 0;
            Weight = 0;
            Currency = new Currency();
            WeightUnits = new WeightUnits();
        }
        public Product(string name, double price, double weight, Currency currency, WeightUnits weightUnits)
        {   
            Name = name;
            Price = price;
            Weight = weight;
            Currency = currency;   
            WeightUnits = weightUnits;
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
            result.Append($"\nЦiна: {price} {currency}");
            result.Append($"\nВага: {weight} {weightUnits}");
            return result.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 15;
            hash = hash * 20 + Name.GetHashCode();
            hash = hash * 20 + Price.GetHashCode();
            hash = hash * 20 + Weight.GetHashCode();
            hash = hash * 20 + Currency.GetHashCode();
            hash = hash * 20 + WeightUnits.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            else
            {
                Product product = (Product)obj;
                return this.Name == product.Name && 
                       this.Price == product.Price &&
                       this.Weight == product.Weight &&
                       this.Currency == product.Currency &&
                       this.WeightUnits == product.WeightUnits;
            }
        }

        public int CompareTo(Product? product)
        {
            if (product is null) 
                throw new ArgumentException("Incorrect value");
            return (int)(Price - product.Price);
        }
    }
}
