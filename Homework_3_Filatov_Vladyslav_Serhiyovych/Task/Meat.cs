    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task;

namespace Homework_1_Filatov_Vladyslav_Serhiyovych
{
    class Meat : Product
    {
        private MeatCategory category;
        private MeatType type;

        public MeatCategory Category 
        {
            get { return category; }
            set 
            { 
                if(Enum.IsDefined(typeof(MeatCategory), value))
                {
                    category = value;
                }
            } 
        }
        public MeatType Type
        {
            get { return type; }
            set
            {
                if (Enum.IsDefined(typeof(MeatType), value))
                {
                    type = value;
                }
            }
        }

        public Meat(string name, double price, double weight, MeatCategory category, MeatType type) : base(name, price, weight) 
        {
            this.category = category;
            this.type = type;
        }

        public override void ChangePrice(double percentage)
        {
            base.ChangePrice(percentage);
            if(category == MeatCategory.High)
                base.ChangePrice(0.1);
            else if(category == MeatCategory.First)
                base.ChangePrice(-0.05);
            else if (category == MeatCategory.Second)
                base.ChangePrice(-0.1);
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            else
            {
                Meat meat = (Meat)obj;
                return base.Equals((Product)obj) && this.Category == meat.Category && this.Type == meat.Type;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append($"\nКатегорiя {category}");
            result.Append($"\nТип: {type}");
            return result.ToString();
        }
    }
}
