using Homework_1_Filatov_Vladyslav_Serhiyovych;
using Task;

Product cup = new Product("Чашка", 300, 2, Currency.UAH, WeightUnits.kg);
Product veal = new Meat("Телятина", 150, 2, Currency.UAH, WeightUnits.kg, MeatCategory.High, MeatType.Veal);
Product сheese = new DairyProducts("Сир", 220, 1, Currency.UAH, WeightUnits.kg, 3);

Buy buy1 = new Buy(cup, 3);
Buy buy2 = new Buy(veal, 2);
Buy buy3 = new Buy(сheese, 2);

Cart cart = new Cart(buy1, buy2, buy3);
Console.WriteLine(cart);




