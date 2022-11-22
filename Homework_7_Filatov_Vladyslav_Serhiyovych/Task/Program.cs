using Homework_1_Filatov_Vladyslav_Serhiyovych;
using System;
using Task;
using Task.Enums;
// не побачила 6 завдання!!!!
Product cup = new Product("Чашка", 300, 3, Currency.UAH, WeightUnits.kg);
Product veal = new Meat("Телятина", 150, 2, Currency.UAH, WeightUnits.kg, MeatCategory.High, MeatType.Veal);
Product cheese = new DairyProducts("Сир", 220, 1, Currency.UAH, WeightUnits.kg, 3);
Product milk = new DairyProducts("Молоко", 39, 1, Currency.UAH, WeightUnits.kg, 4);

Storage storage1 = new Storage(cup, veal, veal, milk, cheese);
Storage storage2 = new Storage(cup, veal);

StorageComparer storageComparer = new StorageComparer(storage1, storage2);
var commonProducts = storageComparer.CommonProducts();
var commonProductsWithoutRepeats = storageComparer.CommonProductsWithoutRepeats();
var productsOnlyInTheFirst = storageComparer.ProductsOnlyInTheFirst();

foreach (var p in commonProducts)
    Console.WriteLine(p);

Console.WriteLine();

foreach (var p in commonProductsWithoutRepeats)
    Console.WriteLine(p);

Console.WriteLine();

foreach (var p in productsOnlyInTheFirst)
    Console.WriteLine(p);

Console.WriteLine();

Console.WriteLine(CardValidator.CardValidate("378282246310005"));
















