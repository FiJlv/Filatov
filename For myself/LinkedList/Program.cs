var list = new LinkedList.Model.LinkedList<int>
{
    1,
    2,
    3,
    4
};

foreach (var item in list)
{
    Console.WriteLine(item + " ");
}

Console.WriteLine();
list.Remove(3); 

foreach (var item in list)
{
    Console.WriteLine(item + " ");
}

Console.ReadLine();