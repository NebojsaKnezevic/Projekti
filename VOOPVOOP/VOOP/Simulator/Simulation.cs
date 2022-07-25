using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOOP.Monsters;

namespace VOOP.Simulator
{
    internal class Simulation
    {

        List<string> lines = new List<string>();
        public void simulation(Hero hero, Monster monster)
        {
            Random random = new Random();
            Console.WriteLine($"{hero.getName()} Attacks {monster.getName()}");
            while(hero.getHealth() > 0 && monster.getHealth() > 0)
            {
                if (random.Next(0, 100) < 50)
                {
                    monster.isAttacked(hero.attack());
                    lines.Add($"{hero.getName()} je napao {monster.getName()} pomocu {hero.getWeaponName()}");
                }
                else
                {
                    hero.isAttacked(monster.attack());
                    lines.Add($"{monster.getName()} je napao {hero.getName()}");
                }
            }
            string filePath = @"C:\Users\WIN10\source\repos\VOOPVOOP\VOOP\Logs\log.txt";
            File.WriteAllLines(filePath, lines);


        }
    }
}
