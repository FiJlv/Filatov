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
        public Check()
        {

        }
        public Check(Product product, Buy buy)
        {
            Console.WriteLine($"Назва: {product.Name} \nЦiна: {product.Price} грн \nВага: {product.Weight} кг \nТовара куплено: {buy.Count} шт \nНа суму: {buy.TotalPrice} грн");
        }

    }
}
