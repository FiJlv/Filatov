using Homework_1_Filatov_Vladyslav_Serhiyovych;
// Вітаю. Все доступно.

Product product = new Product("М'ясо", 150, 2);
Console.WriteLine(product);

Buy buy = new Buy(product, 3);
Console.WriteLine(buy);

Console.WriteLine();
// Не логічно передавати і продукт і покупку, яка містить інформацію про продукт. 
// Крім того покупка можу містити кілька продуктів.
Check chek = new Check(product, buy);


