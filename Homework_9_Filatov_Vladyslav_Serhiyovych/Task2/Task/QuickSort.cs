using Homework_1_Filatov_Vladyslav_Serhiyovych;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task
{
    //Коли опорний елемент визначаємо першим або останнім
    //складність алгоритму буде О(n^2).
    //Краще всього вибирати випадковий елемент,
    //бо це з найбільшою вірогідністю гарантує
    //що складність алгоритма буде О(n log n)

    static class QuickSort
    {
        private static Product[] products;

        public static void Start(Product[] products)
        {
            QuickSort.products = new Product[products.Length];
            for (int i = 0; i < products.Length; i++)
                QuickSort.products[i] = products[i];

            Qsort(0, products.Length - 1);
        }

        private static void Qsort(int left, int right)
        {
            if (left >= right)
                return;

            int pivot = Sorting(left, right);
            Qsort(left, pivot - 1);
            Qsort(pivot + 1, right);
        }

        private static int Sorting(int left, int right)
        {
            int pointer = left;

            for (int i = left; i <= right; i++)
            {
                if ((products[i].Price).CompareTo(products[right].Price) == -1)
                {
                    Swap(pointer, i);
                    pointer++;
                }
            }

            Swap(pointer, right);
            return pointer;
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
