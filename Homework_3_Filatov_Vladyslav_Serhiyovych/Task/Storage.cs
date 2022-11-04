using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Storage
    {
        private Product[] products;
        public Product this[int index]
        {
            get
            {
                if (index < 0 || index > products.Length)
                {
                    throw new ArgumentOutOfRangeException("Index was out of range");
                }
                return products[index];
            }
            set
            {
                if (index < 0 || index > products.Length)
                {
                    throw new ArgumentOutOfRangeException("Index was out of range");
                }
                products[index] = value;
            }
        }

        public Storage(params Product[] products)
        {
            this.products = new Product[products.Length];
            for (int i = 0; i < this.products.Length; ++i)
            {
                this.products[i] = products[i];
            }
        }

        public void Dialoge(int count)
        {
            this.products = new Product[count];

            if (count < 1)
            {
                throw new ArgumentException("Count must be 1 or more");
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Виберiть тип продукту:\n1 - Product\n2 - Meat\n3 - Dairy Product");
                int type = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Введiть iм'я продукту: ");
                string? name = Console.ReadLine();

                Console.WriteLine("Введiть цiну продукту: ");
                double price = Double.Parse(Console.ReadLine());

                Console.WriteLine("Введiть валюту: ");
                Currency currency = (Currency)Enum.Parse(typeof(Currency), Console.ReadLine());

                Console.WriteLine("Введiть вагу продукту:");
                double weight = Double.Parse(Console.ReadLine());

                Console.WriteLine("Введiть одиницi вимiру: ");
                WeightUnits weightUnits = (WeightUnits)Enum.Parse(typeof(WeightUnits), Console.ReadLine());                

                if(type == 1)
                {
                    products[i] = new Product(name, price, weight, currency, weightUnits);
                }
                else if (type == 2)
                {
                    Console.WriteLine("Введiть категорiю: ");
                    MeatCategory mCategory = (MeatCategory)Enum.Parse(typeof(MeatCategory), Console.ReadLine());

                    Console.WriteLine("Введiть тип: ");
                    MeatType mType = (MeatType)Enum.Parse(typeof(MeatType), Console.ReadLine());

                    products[i] = new Meat(name, price, weight, currency, weightUnits, mCategory, mType);
                }
                else if(type == 3)
                {
                    Console.WriteLine("Введiть термiн придатностi");
                    int expirationDate = Int32.Parse(Console.ReadLine());

                    products[i] = new DairyProducts(name, price, weight, currency, weightUnits, expirationDate);
                }           
            }               
        }

        public void Info()
        {
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine(products[i].ToString() + "\n");
            }
        }

        public void FindMeatProducts()
        {
            int count = 0;

            Console.WriteLine("М'яснi продукти");
            foreach(var meatProducts in products)
            {
                if(meatProducts.GetType() == typeof(Meat))
                {
                    count++;
                    Console.WriteLine($"{meatProducts.Name}, {meatProducts.Price} {meatProducts.Currency}, {meatProducts.Weight} {meatProducts.WeightUnits}");
                }
            }
            Console.WriteLine($"Загальна кiлькiсть м'ясних продуктiв: {count}");
        }

        public void AllProductsChangePrice(double percentage)
        {
            if (percentage >= -1 || percentage <= 1)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    products[i].ChangePrice(percentage);
                }
            }
            else
                throw new ArgumentException("Wrong! Сhoose a value from -1 to 1");         
        }
    }
}
