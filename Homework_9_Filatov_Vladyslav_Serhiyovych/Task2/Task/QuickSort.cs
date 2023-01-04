using Homework_1_Filatov_Vladyslav_Serhiyovych;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task
{

    static class QuickSort
    {
        private static Product[] products;
        private static string Type;

        public static void Start(Product[] products, string type)
        {
            QuickSort.products = new Product[products.Length];
            for (int i = 0; i < products.Length; i++)
                QuickSort.products[i] = products[i];

            Type = type;

            Qsort(0, products.Length - 1);
        }

        private static void Qsort(int left, int right)
        {
            if (left >= right)
                return;

            int pivot = 0;
            switch (Type)
            {
                case "First":
                    pivot = FirstPivot(left, right);
                    break;
                case "Last":
                    pivot = LastPivot(left, right);
                    break;
                case "Random":
                    pivot = RandomPivot(left, right);
                    break;  
            }
            
            Qsort(left, pivot - 1);
            Qsort(pivot + 1, right);
        }

        private static int FirstPivot(int left, int right)
        {
            int pivot = left;

            for (int i = left; i <= right; i++)
            {
                if ((products[i].Price) < (products[right].Price))
                {
                    Swap(pivot, i);
                    pivot++;
                }
            }

            Swap(pivot, right);
            return pivot;
        }

        private static int LastPivot(int left, int right)
        {
            int pivot = (int)products[right].Price;

            int j = (left - 1);

            for (int i = left; i <= right - 1; i++)
            {
                if ((products[i].Price) < pivot)
                {         
                    j++;
                    Swap(j, i);
                }
            }

            Swap(j + 1, right);
            return j + 1;
        }

        private static int RandomPivot(int left, int right)
        {
            Random r = new Random();
            int pivot = r.Next() % (right - left) + left;

            var temp = products[pivot].Price;
            products[pivot].Price = products[right].Price;
            products[right].Price = temp;

            return LastPivot(left, right);
        }

        private static void Swap(int a, int b)
        {
            if (a < products.Length && b < products.Length)
            {
                var temp = products[a];
                products[a] = products[b];
                products[b] = temp;
            }
        }
    }
}
