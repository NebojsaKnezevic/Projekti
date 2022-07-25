using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOOP.Monsters
{
    internal interface Monster
    {
        public int attack();
        public void isAttacked(int dmg);

        public int getHealth();

        public string getName();

    }
}
