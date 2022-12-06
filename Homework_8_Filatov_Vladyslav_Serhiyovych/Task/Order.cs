using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Order
    {
        public string CompanyName { get; set; }
        public string ProductName { get; set; } 
        public uint Count { get; set; }

        public Order(string companyName, string productName, uint count)
        {
            CompanyName = companyName;
            ProductName = productName;
            Count = count;  
        }

        public static bool TryParseOrder(string input, out Order result)
        {
            string[] elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool ifParsed;

            string companyName = "";
            string productName = "";
            uint count = 0;

            try
            {
                companyName = elements[0];
                productName = elements[1];
                count = Convert.ToUInt32(elements[2]);

                ifParsed = true;

            }
            catch (FormatException)
            {
                ifParsed = false;
            }
            catch (NullReferenceException)
            {
                ifParsed = false;
            }
            catch (IndexOutOfRangeException)
            {
                ifParsed = false;
            }
            result = new Order(companyName, productName, count);


            return ifParsed;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"Компанiя: {CompanyName}");
            str.Append($"\nТовар: {ProductName}");
            str.Append($"\nKiлькiсть: {Count}");
            str.Append($"\n");
            return str.ToString();
        }
    }
}
