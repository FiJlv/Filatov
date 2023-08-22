using Strategy.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Hero
    {
        private readonly string name;
        private IWeapon weapon; 

        public Hero(string name)
        {
            this.name = name;   
        }

        public void SetWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void Attack()
        {
            if(weapon is null)
            {
                Console.WriteLine("Set a weapon");
                return;
            }

            Console.WriteLine($"{name}");
            weapon.Shoot();
        }

    }
}
