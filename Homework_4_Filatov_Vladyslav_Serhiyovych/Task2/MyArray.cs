using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MyArray
    {// Не знайшла 2 найдовших послідовностей.
        private int [] array;
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > array.Length)
                {
                    throw new ArgumentOutOfRangeException("Index was out of range");
                }
                return array[index];
            }
            set
            {
                if (index < 0 || index > array.Length)
                {
                    throw new ArgumentOutOfRangeException("Index was out of range");
                }
                array[index] = value;
            }
        }
        public MyArray(int length)
        {
            this.array = new int[length];
        }

        public MyArray(int[] array)
        {//треба робити глибоку копію!!!!
            this.array = array;
        }

        public void GenerateArray(int range)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(range);
                Console.Write(array[i] + " ");
            }      
        }

        public void Sort()
        {// слід було скористатись готовим методом Array.Sort
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int t = array[i];
                        array[i] = array[j];
                        array[j] = t;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
        }

        public void FrequencyTable()
        {// тут краще скористатись словником.Метод не повертає результат, а роздруковує.Це не добре.
            int[,] arr = new int[array.Length, 2]; 
            int count; 
            int nMin = 0; 
            int num = Nmax(nMin, out count);

            arr[0, 0] = num;
            arr[0, 1] = count;
            nMin += count; 
            int j = 1; 

            while (nMin < array.Length)
            {
                num = Nmax(nMin, out count);
                arr[j, 0] = num;
                arr[j, 1] = count;
                j++;
                nMin += count;
            }

            for (int i = 0; i < j; i++)
                Console.WriteLine($"Num={arr[i, 0]}, count={arr[i, 1]}");

            int nMax = 0;
            int lMax = arr[0, 1];
            for (int i = 1; i < j; i++)
                if (arr[i, 1] >= lMax)
                {
                    lMax = arr[i, 1];
                    nMax = i;
                }
            Console.WriteLine($"Longest subseqeunce: {arr[nMax, 0]}, in all {arr[nMax, 1]} times");

        }
        private int Nmax(int nMin, out int count)
        {
            int num = array[nMin];
            count = 0;
            int m = num;
            while (m == num)
            {
                count++;
                if ((nMin + count) < this.array.Length)
                    m = array[nMin + count];
                else
                    break;
            }
            return num;
        }     
    }
}
