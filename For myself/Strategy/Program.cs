using Strategy;
using Strategy.Strategies;

Hero hero = new("Alex");
LaserCun laserGun = new LaserCun();
hero.SetWeapon(laserGun);
hero.Attack(); 
