using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (count < 1)
            {
                throw new ArgumentException("Count must be 1 or more");
            }

            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine("Введiть iм'я продукту: ");
                products[i].Name = Console.ReadLine();

                Console.WriteLine("Введiть цiну продукту: ");
                products[i].Price = Double.Parse(Console.ReadLine());

                Console.WriteLine("Введiть вагу продукту:");
                products[i].Weight = Double.Parse(Console.ReadLine());
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
                    Console.WriteLine($"{meatProducts.Name}, {meatProducts.Price}, {meatProducts.Weight}");
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
