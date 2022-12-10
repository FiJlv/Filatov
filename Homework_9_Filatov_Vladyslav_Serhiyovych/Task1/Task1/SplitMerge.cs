using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    static class SplitMerge
    {
        public static void Start()
        {
            FileHandler.FillResult(Sort(FileHandler.Read(), 0, FileHandler.Read().Length - 1));
        }

        private static int[] Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (right + left) / 2;
                int[] leftNums = Sort(array, left, middle);
                int[] rightNums = Sort(array, middle + 1, right);
                int[] mergedNums = Merge(leftNums, rightNums);
                return mergedNums;
            }
            return new int[] { array[left] };
        }

        private static int[] Merge(int[] leftNums, int[] rightNums)
        {
            int[] mergedNums = new int[leftNums.Length + rightNums.Length];

            int left = 0;
            int right = 0;
            int merged = 0;
          
            while (left < leftNums.Length && right < rightNums.Length)
                if (leftNums[left] < rightNums[right])
                    mergedNums[merged++] = leftNums[left++];
                else
                    mergedNums[merged++] = rightNums[right++];

            while (left < leftNums.Length)
                mergedNums[merged++] = leftNums[left++];

            while (right < rightNums.Length)
                mergedNums[merged++] = rightNums[right++];

            return mergedNums;
        }
    }
}
