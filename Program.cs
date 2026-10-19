using RaktarApp;

List<Termek> termek = new List<Termek>();

int hibasSorokSzama = 0;

var beolvas = File.ReadAllLines("termekek.txt").Skip(1);

foreach (var sor in beolvas)
{

    if (string.IsNullOrWhiteSpace(sor))
    {
        hibasSorokSzama++;
        continue;
    }

    string[] sorok = sor.Split('|');

    if (sorok.Length != 4)
    {
        hibasSorokSzama++;
        continue;
    }

    string Tipus = sorok[0];
    string Cikkszam = sorok[1];

    if (Tipus != "S" && Tipus != "G" || Cikkszam == "")
    {
        hibasSorokSzama++;
        continue;
    }

    int GaranciaEve = 0;

    if (!int.TryParse(sorok[2], out int Alapar) || !int.TryParse(sorok[3], out GaranciaEve))
    {
        hibasSorokSzama++;
        continue;
    }

    if (Tipus == "S")
    {
        Termek termek1 = new Termek(Cikkszam, Alapar);
        termek.Add(termek1);
    }
    else if (Tipus == "G")
    {
        TartosTermek termek2 = new TartosTermek(Cikkszam, Alapar, GaranciaEve);
        termek.Add(termek2);
    }
}

Console.WriteLine("Hibas sorok száma: "+ hibasSorokSzama + "db");



foreach (Termek t in termek)
{
    Console.WriteLine(t);
}


foreach (Termek t in termek)
{
    Console.WriteLine(t.ErtekSzamitas(10) + " Ft");
}

Console.WriteLine(Termek.OsszesTermekSzama + " db");










