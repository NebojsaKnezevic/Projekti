using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOOP.Weapons;
using VOOP.Monsters;

namespace VOOP
{
    internal interface Hero : Monster
    {
        public static Dictionary<string, List<string>> allowedWeapons = new Dictionary<string, List<string>>()
        {
            {"swordman", new List<string>{"sword", "spear", "bow" } },
            {"wizard", new List<string>{"spell", "wand", "staff", "spear" } },
            {"hunter", new List<string>{"spell", "wand", "staff", "spear" } }
        };
        public void pickWeapon(Weapon s);
        public void dropWeapon(Weapon s);

        public string getWeaponName();

    }
}
