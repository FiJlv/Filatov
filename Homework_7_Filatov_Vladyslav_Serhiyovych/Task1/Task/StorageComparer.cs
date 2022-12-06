using Homework_1_Filatov_Vladyslav_Serhiyovych;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Enums;

namespace Task
{
    class StorageComparer : IComparer
    {
        private SortBy sortBy;
        private readonly Storage firstStorage;
        private readonly Storage secondStorage;
        public StorageComparer(SortBy sortBy)
        {
            this.sortBy = sortBy;
        }
        public StorageComparer(Storage firstStorage, Storage secondStorage)
        {
            if (firstStorage == null || secondStorage == null)
                throw new ArgumentNullException();

            this.firstStorage = firstStorage;
            this.secondStorage = secondStorage;
        }
        public int Compare(object? x, object? y)
        {
            if (x is Product p1 && y is Product p2)
            {
                if (sortBy == SortBy.Price)
                {
                    if (p1.Price == p2.Price)
                        return 0;
                    else if (p1.Price > p2.Price)
                        return 1;
                    else
                        return -1;
                }
                else if (sortBy == SortBy.Weight)
                {
                    if (p1.Weight == p2.Weight)
                        return 0;
                    else if (p1.Weight > p2.Weight)
                        return 1;
                    else
                        return -1;
                }
            }
            return 0;
        }

        public List<Product> ProductsOnlyInTheFirst()
        {// Чому не використовуємо методи множин
            List<Product> productsOnlyInTheFirstStorage = new List<Product>();

            foreach (var product in firstStorage.Products)
            {
                if (!secondStorage.Products.Contains(product))
                    productsOnlyInTheFirstStorage.Add(product);             
            }

            return productsOnlyInTheFirstStorage;
        }

        public List<Product> CommonProducts()
        {

            List<Product> commonProducts = new List<Product>();

            foreach (var product in firstStorage.Products)
            {
                if (secondStorage.Products.Contains(product))
                    commonProducts.Add(product);
            }

            return commonProducts;
        }

        public HashSet<Product> CommonProductsWithoutRepeats()
        {
            HashSet<Product> commonList = new HashSet<Product>();

            foreach (var product in firstStorage.Products)
            {
                if (secondStorage.Products.Contains(product))
                    commonList.Add(product);
            }

            return commonList;
        }
    }
}
