
using System.Data.SqlClient;
using Task;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
PersonData personData = new PersonData(connectionString);

personData.Insert("1", "Thomas", "Johnson");
personData.Insert("2", "Jhon", "Smith");
personData.Read();

Console.WriteLine();

personData.Update("2", "John", "Smith");
personData.Read();

Console.WriteLine();

personData.Delete("1");
personData.Delete("2");