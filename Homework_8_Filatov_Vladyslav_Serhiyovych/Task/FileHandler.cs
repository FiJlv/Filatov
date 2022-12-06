using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class FileHandler
    {
        string orderListPath = "OrderList.txt";
        string similarProductPath = "SimilarProductList.txt";
        string resultPath = "Result.txt";
        public Order[] ReadOrders()
        {
            using (StreamReader sr = new StreamReader(orderListPath))
            {
                int countOfOrders = File.ReadAllLines(orderListPath).Length;
                Order[] orders = new Order[countOfOrders];
                string[] orderList = FileHandler.FileReadToEnd(sr, countOfOrders);

                for (int i = 0; i < countOfOrders; i++)
                {
                    if (Order.TryParseOrder(orderList[i], out Order order))
                    {
                        orders[i] = order;
                    }
                }

                foreach (var item in orders)
                {
                    Console.WriteLine(item);
                }

                return orders;
            }            
        }        

        public string [] SimilarProducts(string unsatisfiedOrder)
        {
            using (StreamReader sr = new StreamReader(similarProductPath))
            {
                int countOfSimilarProducts = File.ReadAllLines(similarProductPath).Length;

                string[] similarProducts = FileReadToEnd(sr, countOfSimilarProducts);
               
                List<string> result = new List<string>();
                for (int i = 0; i < countOfSimilarProducts; i++)
                {
                    SimilarProductList.TryParseSimilarProducts(similarProducts[i], out SimilarProductList similarProduct);
                    if(similarProduct.NameOfUnsatisfiedOrder == unsatisfiedOrder)
                    {
                       foreach(string product in similarProduct.ListOfSimilarProducts)
                       {
                            result.Add(product);
                       }
                    }
                }

                FillResultFile(result, unsatisfiedOrder);

                return similarProducts;
            }
        }

       public void FillResultFile(List<string> result, string unsatisfiedOrder)
       {
            using(StreamWriter sw = new StreamWriter(resultPath, true))
            {
                sw.WriteLine($"Товару '{unsatisfiedOrder}' немає в наявностi, пропонуємо схожi товари: ");
                foreach(var item in result)
                {
                    sw.WriteLine(item);
                }              
            }
       }

       public static string[] FileReadToEnd(StreamReader sr, int count)
       {
            string[] result = new string[count];
            while (!sr.EndOfStream)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = sr.ReadLine() ?? "";
                }
            }
            return result;
       }

    }
}
