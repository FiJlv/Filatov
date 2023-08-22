using FactoryMethod.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Factories
{
    internal class GymPlusPoolMembershipFactory : MembershipFactory
    {
        public readonly decimal _price;
        public readonly string _description;

        public GymPlusPoolMembershipFactory(decimal price, string description)
        {
            _price = price;
            _description = description;
        }

        public override IMembership GetMembership()
        {
            GymPlusPoolMembership membership = new(_price)
            {
                Description = _description
            };

            return membership; 
        }
    }
}
