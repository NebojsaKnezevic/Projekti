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
simulation.simulation(aragorn, dragon);

aragorn.dropWeapon(spear);
gandalf.pickWeapon(spear);

simulation.simulation(gandalf, dragon1);

Hero legolas = new Hunter("Legolas", "hunter", 80);

gandalf.dropWeapon(spear);
legolas.pickWeapon(spear);

simulation.simulation(legolas, dragon2);



Console.WriteLine("FINISH");
Console.ReadKey();