using VOOP;
using VOOP.Monsters;
using VOOP.Weapons;
using VOOP.Simulator;

Hero aragorn = new Swordman("Aragorn", "swordman", 100);
Hero gandalf = new Wizard("Gandalf", "wizard", 150);

Weapon spear = Spear.Instance;

Monster dragon = new Dragon(100, 20, "dragon");
Monster dragon1 = new Dragon(100, 20, "dragon");
Monster dragon2 = new Dragon(100, 20, "dragon");

Simulation simulation = new Simulation();

aragorn.pickWeapon(spear);
//borba aragorn vs dragon
simulation.simulation(aragorn, dragon);

//aragorn daje koplje gandalf
aragorn.dropWeapon(spear);
gandalf.pickWeapon(spear);

//borba gandalf vs dragon1
simulation.simulation(gandalf, dragon1);

Hero legolas = new Hunter("Legolas", "hunter", 80);

//gandalf daje koplje legolas
gandalf.dropWeapon(spear);
legolas.pickWeapon(spear);

//borba legolas vs dragon2
simulation.simulation(legolas, dragon2);



Console.WriteLine("FINISH");
Console.ReadKey();
