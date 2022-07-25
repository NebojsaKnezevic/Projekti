using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOOP.Monsters
{
    internal class Spider : Monster
    {
        protected int generalAttack = 5;
        protected int health;
        protected int specialAttack;
        protected string name;

        public Spider(int health, int specialAttack, string name)
        {
            this.health = health;
            this.specialAttack = specialAttack;
            this.name = name;
        }
        public int attack()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100) < 50 ? generalAttack : specialAttack;
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
    }
}
