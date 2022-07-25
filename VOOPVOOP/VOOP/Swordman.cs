using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOOP.Weapons;

namespace VOOP
{

    public class NoWeapon : Exception
    {
        public NoWeapon(String message)
            : base(message)
        {

        }
    }
    internal class Swordman : Hero
    {

        protected int health;
        protected string name;
        protected Dictionary<string, Weapon> BackPack;
        protected int backPackSize = 2;
        protected string heroClass;
        protected Weapon activeWeapon;

        public Swordman(string name, string heroClass, int health)
        {
            this.name = name;
            this.heroClass = heroClass;
            this.health = health;
            BackPack = new Dictionary<string, Weapon>();
        }

        public void pickWeapon(Weapon s)
        {
            if (!s.IsOwned() && BackPack.Count < backPackSize && isAllowedToUse(s))
            {
                BackPack.Add(s.getName(), s);
                useWeapon();
                s.ownership(true);
            }
            else
            {
                if (s.IsOwned())
                {
                    throw new NoWeapon($"That is not your {s.getName()}!");
                }
                if (!isAllowedToUse(s))
                {
                    throw new NoWeapon($"{heroClass} cant use that weapon!");
                }
            }
        }

        public void dropWeapon(Weapon s)
        {
            BackPack.Remove(s.getName());
            activeWeapon = activeWeapon.getName() == s.getName() ? null : activeWeapon;
            useWeapon();
            s.ownership(false);
        }

        protected bool isAllowedToUse(Weapon s)
        {
            bool x = false;
            foreach (string item in Hero.allowedWeapons[heroClass])
            {
                if (item == s.getName())
                {
                    x = true;
                }      
            }
            return x;
        }

        protected void useWeapon()
        {
            if (BackPack.Count > 0 && activeWeapon == null)
            {
                activeWeapon = BackPack.First().Value;
            }
            else
            {
                //throw new NoWeapon("Inventory is empty!");
            }
        }

        public int attack()
        {
            return activeWeapon.getDamage();
        }

        public void isAttacked(int dmg)
        {
            health -= dmg;
        }

        public int getHealth()
        {
            return health;
        }

        public string getName()
        {
            return name;
        }

        public string getWeaponName()
        {
            return activeWeapon.getName();
        }
    }
}
