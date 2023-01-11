using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    static class SplitMerge
    {
        public static void Sort(StreamReader source, StreamWriter result, int size)
        {
            for (int i = 1; !source.EndOfStream; i++) 
            {
                var nums = FileHandler.Read(size, source);
                nums = Sort(nums, 0, nums.Length - 1);
                FileHandler.Temp(nums, i); 
            }
            MergeTheChunks(result, size); 
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

        public static void MergeTheChunks(StreamWriter sw, int size)
        {
            string[] paths = Directory.GetFiles(".", "buffer" + "*.txt");

            int chunks = paths.Length;
            int bufferlen = size / chunks;

            StreamReader[] readers = new StreamReader[chunks];
            for (int i = 0; i < chunks; i++)
                readers[i] = new StreamReader(paths[i]);

            Queue<string>[] queues = new Queue<string>[chunks];
            for (int i = 0; i < chunks; i++)
                queues[i] = new Queue<string>(bufferlen);

            for (int i = 0; i < chunks; i++)
                LoadQueue(queues[i], readers[i], bufferlen);

            bool done = false;
            int lowest_index, j;
            string lowest_value;
            while (!done)
            {

                lowest_index = -1;
                lowest_value = "";
                for (j = 0; j < chunks; j++)
                {
                    if (queues[j] != null)
                    {
                        if (lowest_index < 0 ||
                          String.CompareOrdinal(
                            queues[j].Peek(), lowest_value) < 0)
                        {
                            lowest_index = j;
                            lowest_value = queues[j].Peek();
                        }
                    }
                }

                if (lowest_index == -1) { done = true; break; }

                sw.WriteLine(lowest_value);

                queues[lowest_index].Dequeue();

                if (queues[lowest_index].Count == 0)
                {
                    LoadQueue(queues[lowest_index],
                      readers[lowest_index], bufferlen);
                    if (queues[lowest_index].Count == 0)
                    {
                        queues[lowest_index] = null;
                    }
                }
            }
            sw.Close();

            for (int i = 0; i < chunks; i++)
            {
                readers[i].Close();
                File.Delete(paths[i]);
            }
        }

        public static void LoadQueue(Queue<string> queue,
          StreamReader file, int records)
        {
            for (int i = 0; i < records; i++)
            {
                if (file.Peek() < 0) break;
                queue.Enqueue(file.ReadLine());
            }
        }
    }
}
