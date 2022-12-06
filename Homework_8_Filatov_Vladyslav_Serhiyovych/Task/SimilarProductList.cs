using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class SimilarProductList
    {
        public string NameOfUnsatisfiedOrder { get; set; }
        public List<string> ListOfSimilarProducts { get; set; }

        public SimilarProductList(string nameOfUnsatisfiedOrder, List<string> listOfSimilarProducts)
        {
            NameOfUnsatisfiedOrder = nameOfUnsatisfiedOrder;
            ListOfSimilarProducts = listOfSimilarProducts;  
        }

        public static bool TryParseSimilarProducts(string input, out SimilarProductList result)
        {
            string[] elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool ifParsed;

            string nameOfUnsatisfiedOrder = "";
            List<string> similarProducts = new List<string>();

            try
            {
                nameOfUnsatisfiedOrder = elements[0];

                for (int i = 2; i < elements.Length; i++)
                {
                    similarProducts.Add(elements[i]);
                }

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
            result = new SimilarProductList(nameOfUnsatisfiedOrder, similarProducts);


            return ifParsed;
        }
    }
}
