using Homework_1_Filatov_Vladyslav_Serhiyovych;
using System;
using Task;

Product cup = new Product("Чашка", 300, 3, Currency.UAH, WeightUnits.kg);
Product veal = new Meat("Телятина", 150, 2, Currency.UAH, WeightUnits.kg, MeatCategory.High, MeatType.Veal);
Product cheese = new DairyProducts("Сир", 220, 1, Currency.UAH, WeightUnits.kg, 3);

Storage storage = new Storage(cup, veal, cheese);
storage.Sort(SortBy.Price);









