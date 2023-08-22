using ExtensionMethods;
using ExtensionMethods.Models;

class Program
{
    static void Main(string[] args)
    {
        DateTime currentDateTime = DateTime.Now;
        currentDateTime.Print();
        Console.WriteLine(currentDateTime.IsDayOfWeek(DayOfWeek.Friday));
        Student student = new Student() { FirstName = "Alex", LastName = "Brown" };
        Console.WriteLine(student.GetFullName());
    }
}