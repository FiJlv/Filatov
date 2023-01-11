using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    static class FileHandler
    {
        public static void Temp(int[] nums, int number, string name = "temp")
        {
            using StreamWriter sw = new StreamWriter(name + number + ".txt");
            foreach (int num in nums)
                sw.WriteLine(num);
        }

        public static int[] Read(int size, StreamReader sr)
        {
            int[] nums = new int[size];
            for (int i = 0; i < size; i++)
                nums[i] = Convert.ToInt32(sr.ReadLine() ?? "");

            return nums;
        }
    }
}
