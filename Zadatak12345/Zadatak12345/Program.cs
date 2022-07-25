using Zadatak12345;
using Zadatak12345.Fdnevnik;

Odeljenje odeljenje5 = new Odeljenje("odeljenje5");
Odeljenje odeljenje6 = new Odeljenje("odeljenje6");

//kreiraj 5 nastavnika
Nastavnik nastavnik1 = new Nastavnik(new Adress(1, "NS", "Svetozar Markovic"), odeljenje5);
Nastavnik nastavnik2 = new Nastavnik(new Adress(1, "NS", "Svetozar Markovic"), odeljenje6);
Nastavnik nastavnik3 = new Nastavnik(new Adress(1, "NS", "Svetozar Markovic"), null);
Nastavnik nastavnik4 = new Nastavnik(new Adress(1, "NS", "Svetozar Markovic"), null);
Nastavnik nastavnik5 = new Nastavnik(new Adress(1, "NS", "Svetozar Markovic"), null);

nastavnik1.PredajePredmet = "matematika";
nastavnik2.PredajePredmet = "geografija";
nastavnik3.PredajePredmet = "istorija";
nastavnik4.PredajePredmet = "fizika";
nastavnik5.PredajePredmet = "biologija";

Dnevnik dnevnik = Dnevnik.Instance;


Student s;
for (int i = 0; i < 20; i++)
{
    s = new Student(new Adress(i, "NS", "Svetozar Markovic"));
    s.Name = $"student{s.ID}";
    odeljenje5.setStudent(s);
}
odeljenje5.Staresina = nastavnik1;

for (int i = 0; i < 20; i++)
{
    s = new Student(new Adress(i+20, "NS", "Svetozar Markovic"));
    s.Name = $"student{s.ID+20}";
    odeljenje6.setStudent(s);

}
odeljenje6.Staresina = nastavnik2;

dnevnik.addOdeljenje(odeljenje5);
dnevnik.addOdeljenje(odeljenje6);


/*int[] arr = dnevnik.GetOdeljenje("odeljenje5").studentsByID.Keys.ToArray();
for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine($"{arr[i]}");
}*/

Random rnd = new Random();
//Upis ocena za sve ucenika 1 odeljenja
for (int i = 0; i < dnevnik.GetOdeljenje("odeljenje5").studentsByID.Count; i++)
{
    nastavnik1.addGrade(odeljenje5.getStudentByID(i), Convert.ToByte((rnd.Next(1, 6))));
    nastavnik2.addGrade(odeljenje5.getStudentByID(i), Convert.ToByte((rnd.Next(1, 6))));
    nastavnik3.addGrade(odeljenje5.getStudentByID(i), Convert.ToByte((rnd.Next(1, 6))));
    nastavnik4.addGrade(odeljenje5.getStudentByID(i), Convert.ToByte((rnd.Next(1, 6))));
    nastavnik5.addGrade(odeljenje5.getStudentByID(i), Convert.ToByte((rnd.Next(1, 6))));
    Console.WriteLine($"FINISH 1");
}

//Upis ocena za sve ucenika 2 odeljenja
for (int i = 0; i < dnevnik.GetOdeljenje("odeljenje6").studentsByID.Count; i++)
{
    nastavnik1.addGrade(odeljenje6.getStudentByID(i + 20), Convert.ToByte((rnd.Next(1, 6))));
    nastavnik2.addGrade(odeljenje6.getStudentByID(i + 20), Convert.ToByte((rnd.Next(1, 6))));
    nastavnik3.addGrade(odeljenje6.getStudentByID(i + 20), Convert.ToByte((rnd.Next(1, 6))));
    nastavnik4.addGrade(odeljenje6.getStudentByID(i + 20), Convert.ToByte((rnd.Next(1, 6))));
    nastavnik5.addGrade(odeljenje6.getStudentByID(i + 20), Convert.ToByte((rnd.Next(1, 6))));
    Console.WriteLine($"FINISH 2");
}


//Ucenik 1 odsustva iz svakog od 5 predmeta koje predaje konkretan profesor i samo on moze da upise odsustvo iz svog predmeta

nastavnik1.setOdsustvo(odeljenje5.getStudentByID(3), false);
nastavnik2.setOdsustvo(odeljenje5.getStudentByID(3), false);
nastavnik3.setOdsustvo(odeljenje5.getStudentByID(3), false);
nastavnik4.setOdsustvo(odeljenje5.getStudentByID(3), false);
nastavnik5.setOdsustvo(odeljenje5.getStudentByID(3), false);

//Ucenik 2 odsustva

nastavnik1.setOdsustvo(odeljenje5.getStudentByID(7), true);
nastavnik2.setOdsustvo(odeljenje5.getStudentByID(7), true);
nastavnik3.setOdsustvo(odeljenje5.getStudentByID(7), true);
nastavnik4.setOdsustvo(odeljenje5.getStudentByID(7), true);
nastavnik5.setOdsustvo(odeljenje5.getStudentByID(7), true);


// Prosek ucenika svaki profesor moze da izracuna prosek ucenika
nastavnik3.prosekUcenika(dnevnik, $"{odeljenje5.Name}", 4);
nastavnik3.prosekUcenika(dnevnik, $"{odeljenje5.Name}", 2);
nastavnik3.prosekUcenika(dnevnik, $"{odeljenje5.Name}", 11);
nastavnik3.prosekUcenika(dnevnik, $"{odeljenje5.Name}", 16);

nastavnik4.prosekUcenika(dnevnik, $"{odeljenje6.Name}", 24);
nastavnik5.prosekUcenika(dnevnik, $"{odeljenje6.Name}", 34);
nastavnik1.prosekUcenika(dnevnik, $"{odeljenje6.Name}", 26);
nastavnik2.prosekUcenika(dnevnik, $"{odeljenje6.Name}", 33);

//Prosek odeljenja svaki profesor moze da izracuna prosek odeljenja
nastavnik1.prosekOdeljenja(dnevnik, odeljenje5);
nastavnik1.prosekOdeljenja(dnevnik, odeljenje6);



Console.WriteLine("FINISH");
Console.ReadKey();


