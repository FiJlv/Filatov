using Homework_1_Filatov_Vladyslav_Serhiyovych;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class StorageComparer : IComparer
    {
        private SortBy sortBy;
        public StorageComparer(SortBy sortBy)
        {
            this.sortBy = sortBy;
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
    }
}
