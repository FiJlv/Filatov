using Homework_1_Filatov_Vladyslav_Serhiyovych;
// Вітаю. Все доступно.

Product meat = new Product("Veal", 150, 2);
Product vegetables = new Product("Potatoes", 10, 4);

Buy buy = new Buy(meat, vegetables);

Console.WriteLine(Check.InfoBuy(buy));



<<<<<<< HEAD
Console.WriteLine();
// Не логічно передавати і продукт і покупку, яка містить інформацію про продукт. 
// Крім того покупка можу містити кілька продуктів.
Check chek = new Check(product, buy);
=======

>>>>>>> c6b80bd (commit)


