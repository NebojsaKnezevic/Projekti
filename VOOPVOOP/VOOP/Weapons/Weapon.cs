using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOOP.Weapons
{
    internal interface Weapon
    {
        public bool IsOwned();

        public void ownership(bool x);
        public string getName();

        public int getDamage();
    }
}
