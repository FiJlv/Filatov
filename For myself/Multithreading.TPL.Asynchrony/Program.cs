class Program
{
    public static object locker = new object();

    static void Main(string[] args)
    {
        #region Thread
        //Thread thread1 = new Thread(new ThreadStart(DoWork1));
        //thread1.Start();

        //Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork2));
        //thread2.Start(int.MaxValue);
        #endregion

        #region Async await 
        //Console.WriteLine("BeginMain");
        //DoWorkAsync();
        //Console.WriteLine("ContinueMain");

        //for (int i = 0; i < 10; i++)
        //{
        //    Console.WriteLine("Main");
        //}
        //Console.WriteLine("EndMain");
        #endregion

        var result = SaveFileAsync("D:\\test.txt");
        var input = Console.ReadLine();
        Console.WriteLine(result.Result);
    }

    static async Task<bool> SaveFileAsync(string path)
    {
        var result = await Task.Run(() => SaveFile(path));
        return result;
    }

    static bool SaveFile(string path)
    {
        lock (locker)
        {
            var rnd = new Random();
            var text = "";
            for (int i = 0; i < 50000; i++)
            {
                text += rnd.Next();
            }
        }

        using (var sw = new StreamWriter(path, false))
        {
            sw.WriteLine();
        }

        return true;
    }

    static async Task DoWorkAsync()
    {
        Console.WriteLine("BeginAsync");
        await Task.Run(() => DoWork1());
        Console.WriteLine("EndAsync");
    }

    static void DoWork1()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("DoWork1");
        }
    }

    static void DoWork2(object max)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("DoWork2");
        }
    }
}

/////////////////////////

//class Program
//{
//    //static void Main(string[] args)
//    //{
//    //    //Thread currentThread = Thread.CurrentThread;
//    //    //currentThread.Name = "Main";
//    //    //Console.WriteLine($"Имя потока: {currentThread.Name}");
//    //    //Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
//    //    //Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
//    //    //Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
//    //    //Console.WriteLine($"Статус потока: {currentThread.ThreadState}");

//    //    //MakeTea();
//    //}

//    static async Task Main()
//    {
//        await MakeTeaAsync();
//    }

//    public static async Task<string> MakeTeaAsync()
//    {
//        var boilingWater = BoilWaterAsync();
//        Console.WriteLine("Take the cups out");
//        Console.WriteLine("Put tea in cups");
//        var water = await boilingWater;
//        var tea = $"Pour {water} in cups";
//        Console.WriteLine(tea);
//        return tea;
//    }

//    public static async Task<string> BoilWaterAsync()
//    {
//        Console.WriteLine("Start the kettle");
//        Console.WriteLine("Waiting for the kettle");
//        await Task.Delay(2000);
//        Console.WriteLine("Kettle finished boiling");
//        return "water";
//    }

//    //public static string MakeTea()
//    //{
//    //    var water = BoilWater(); 
//    //    Console.WriteLine("Take the cups out");
//    //    Console.WriteLine("Put tea in cups");
//    //    var tea = $"Pour {water} in cups";
//    //    Console.WriteLine(tea);
//    //    return tea;
//    //}

//    //public static string BoilWater()
//    //{
//    //    Console.WriteLine("Start the kettle");
//    //    Console.WriteLine("Waiting for the kettle");
//    //    Task.Delay(2000).GetAwaiter().GetResult();
//    //    Console.WriteLine("Kettle finished boiling");
//    //    return "water";
//    //}
//}


