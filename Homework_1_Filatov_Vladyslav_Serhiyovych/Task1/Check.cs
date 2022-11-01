using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Check
    {
        public static string InfoProduct(Product product)
        {
            var result = new StringBuilder();

            result.Append($"\nНазва: {product.Name}");
            result.Append($"\nЦiна: {product.Price.ToString()} грн");
            result.Append($"\nВага: {product.Weight.ToString()} кг");

            return result.ToString();
        }

        public static string InfoBuy(Buy buy)
        {
            var result = new StringBuilder();

            for (int i = 0; i < buy.ProductList.Count; ++i)
            {
                result.Append("\n" + InfoProduct(buy.ProductList[i]));
            }

            result.Append($"\n\nКiлькiсть: {buy.Count.ToString()} шт");
            result.Append($"\nЗагальна сума: {buy.TotalPrice.ToString()} грн");
            result.Append($"\nЗагальна сума: {buy.TotalWeight.ToString()} грн");

            return result.ToString();
        }
    }
}
