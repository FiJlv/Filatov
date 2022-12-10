using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    static class FileHandler
    {
        private static readonly string SetOfNumbersPath = "..\\Homework_9_Filatov_Vladyslav_Serhiyovych\\Task1\\Task1\\SetOfNumbers.txt";
        private static readonly string ResultPath = "..\\Homework_9_Filatov_Vladyslav_Serhiyovych\\Task1\\Task1\\Result.txt";

        public static int[] Read()
        {
            using (StreamReader sr = new StreamReader(SetOfNumbersPath))
            {
                int count = File.ReadAllLines(SetOfNumbersPath).Length;
                int[] nums = new int[count];

                while (!sr.EndOfStream)
                    for (int i = 0; i < count; i++)
                        nums[i] = Convert.ToInt32(sr.ReadLine() ?? "");

                return nums;
            }
        }

        public static void FillResult(int[] result)
        {
            using (StreamWriter sw = new StreamWriter(ResultPath, true))
            {
                foreach (int item in result)
                    sw.WriteLine(item);
            }
        }
    }
}
