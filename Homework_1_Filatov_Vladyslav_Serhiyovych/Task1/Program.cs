using Homework_1_Filatov_Vladyslav_Serhiyovych;

Product product = new Product("М'ясо", 150, 2);
Console.WriteLine(product);

Buy buy = new Buy(product, 3);
Console.WriteLine(buy);

Console.WriteLine();

Check chek = new Check(product, buy);


