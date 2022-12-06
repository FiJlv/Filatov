using Homework_1_Filatov_Vladyslav_Serhiyovych;
using System;
using Task;
using Task.Enums;
using Task.Models;

Product cup = new Product("Чашка", 300, 3, Currency.UAH, WeightUnits.kg);
Product veal = new Meat("Телятина", 150, 2, Currency.UAH, WeightUnits.kg, MeatCategory.High, MeatType.Veal);
Product cheese = new DairyProducts("Сир", 220, 1, Currency.UAH, WeightUnits.kg, 3);
Product milk = new DairyProducts("Молоко", 39, 1, Currency.UAH, WeightUnits.kg, 4);

Storage storage = new Storage(cup, veal, milk, cheese);

FileHandler fileHandler = new FileHandler();

storage.SatisfiedOrder += DisplayMessage;
storage.UnsatisfiedOrder += DisplayMessage;

storage.OrderFulfillmentAnalysis(fileHandler);

void DisplayMessage(string message) => Console.WriteLine(message);

















