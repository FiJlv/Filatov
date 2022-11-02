using Homework_1_Filatov_Vladyslav_Serhiyovych;
using Task;

Product product = new Product("Some product", 50, 5);
Meat meat = new Meat("Veal", 140, 2, MeatCategory.High, MeatType.Veal);
DairyProducts milk= new DairyProducts("Milk", 30, 1, 4);

Storage storage = new Storage(product, meat, milk);
