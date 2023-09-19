class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[] { 1, 3, 76, 34, 321, 45, 78, 4, 5, 79 };

        Console.WriteLine("BubbleSort");
        BubbleSort(array);
        Print(array);

        Console.WriteLine();

        Console.WriteLine("QuickSort");
        QuickSort(array, 0, array.Length - 1);
        Print(array);

        Console.WriteLine();

        Console.WriteLine("InsertionSort");
        InsertionSort(array);
        Print(array);

        Console.WriteLine();

        Console.WriteLine("MergeSort");
        MergeSort(array);
        Print(array);

    }

    public static int[] QuickSort(int[] array, int minIndex, int maxIndex)
    {

        if (minIndex >= maxIndex)
        {
            return array;
        }

        int pivotInex = GetPivotIndex(array, minIndex, maxIndex);

        QuickSort(array, minIndex, pivotInex - 1);
        QuickSort(array, pivotInex + 1, maxIndex);

        return array;
    }

    private static int GetPivotIndex(int[] array, int minIndex, int maxIndex)
    {
        int pivot = minIndex - 1;
        for (int i = minIndex; i <= maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                Swap(ref array[pivot], ref array[i]);
            }
        }

        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);
        return pivot;
    }

    public static int[] BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    Swap(ref array[i], ref array[j]);
                };
            }
        }
        return array;
    }

    public static int[] InsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var key = array[i];
            var j = i;
            while ((j > 1) && (array[j - 1] > key))
            {
                Swap(ref array[j - 1], ref array[j]);
                j--;
            }

            array[j] = key;
        }

        return array;
    }

    static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new int[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (array[left] < array[right])
            {
                tempArray[index] = array[left];
                left++;
            }
            else
            {
                tempArray[index] = array[right];
                right++;
            }

            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            array[lowIndex + i] = tempArray[i];
        }
    }

    static int[] MergeSort(int[] array, int lowIndex, int highIndex)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            MergeSort(array, lowIndex, middleIndex);
            MergeSort(array, middleIndex + 1, highIndex);
            Merge(array, lowIndex, middleIndex, highIndex);
        }

        return array;
    }

    static int[] MergeSort(int[] array)
    {
        return MergeSort(array, 0, array.Length - 1);
    }


    private static void Swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }

    public static void Print(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}