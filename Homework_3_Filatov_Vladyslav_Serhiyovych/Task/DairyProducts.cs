using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class DairyProducts : Product
    {
        private double expirationDate;

        public double ExpirationDate { 
            get { return expirationDate; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Expiration date can not be lower than 0");
                else
                    expirationDate = value;
            }
        }

        public DairyProducts(string name, double price, double weight, double expirationDate) : base(name, price, weight)
        {
            this.expirationDate = expirationDate;
        }

        public override void ChangePrice(double percentage)
        {
            base.ChangePrice(percentage);
            if (ExpirationDate < 7)
            {
                base.ChangePrice(-0.2);
            }
            else if (10 <= ExpirationDate && ExpirationDate < 30)
            {
                base.ChangePrice(-0.1);
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            DairyProducts diaryProducts = (DairyProducts)obj;
            return base.Equals((Product)obj) && this.ExpirationDate == diaryProducts.ExpirationDate;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append($"\nТермін придатності: {ExpirationDate} днiв");
            return result.ToString();
        }
    }
}
