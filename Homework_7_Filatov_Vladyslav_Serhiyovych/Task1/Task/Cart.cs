using Homework_1_Filatov_Vladyslav_Serhiyovych;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Cart
    {
        private List<Buy> productList;
        public List<Buy> ProductList { get { return productList; } set { productList = value; } }

        public Cart()
        {
            productList = new List<Buy>();
        }

        public Cart(params Buy[] products)
        {
            productList = new List<Buy>();

            for (int i = 0; i < products.Length; i++)
            {
                
                if (products[0].Product.Currency == products[i].Product.Currency 
                    && products[0].Product.WeightUnits == products[i].Product.WeightUnits)
                    productList.Add(products[i]);
                else
                    throw new ArgumentException("Must be one currency and weight units");
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < ProductList.Count; i++)
            {
                result.Append("\n" + ProductList[i].ToString());
            }

            return result.ToString();
        }
    }
}
