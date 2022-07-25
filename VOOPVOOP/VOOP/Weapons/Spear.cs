using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOOP;

namespace VOOP.Weapons
{
    public class Spear : Weapon
    {
        private int damage = 15;
        private bool owner = false;
        private string name = "spear";
        public bool IsOwned()
        {
            return owner;
        }

        public void ownership(bool x)
        {
            owner = x;
        }
        public string getName()
        {
            return name;
        }

        public int getDamage()
        {
            return damage;
        }

        private Spear() { }
        private static Spear instance = null;
        public static Spear Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Spear();
                }
                return instance;
            }
        }
    }
}
