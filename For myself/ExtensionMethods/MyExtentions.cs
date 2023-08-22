using ExtensionMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    static class MyExtentions
    {
        public static void Print(this DateTime dateTime) => Console.WriteLine(dateTime);

        public static bool IsDayOfWeek(this DateTime dateTime, DayOfWeek dayOfWeek) => dateTime.DayOfWeek == dayOfWeek;       

        public static string GetFullName(this Student student) => student.FirstName + " " + student.LastName;
    }
}
