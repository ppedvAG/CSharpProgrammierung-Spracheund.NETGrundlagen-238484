using System.Diagnostics;

namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Linq
		//Listen zu verarbeiten
		List<int> zahlen = Enumerable.Range(1, 20).ToList(); //Liste von 0 bis 20

        //Erweiterungsmethoden
        //Würfel mit Pfeil, alle Linq Methoden sind Erweiterungsmethoden
        Console.WriteLine(zahlen.Sum());

		//Ohne Linq
		int x = 0;
		foreach (int i in zahlen)
			x += i;
        Console.WriteLine(x);

        Console.WriteLine(zahlen.Average());
        Console.WriteLine(zahlen.Min());
        Console.WriteLine(zahlen.Max());

        Console.WriteLine(zahlen.First());
        Console.WriteLine(zahlen.Last());

		//Bedingung bei First: Das erste Element suchen, welches der Bedingung entspricht
		//WICHTIG: Bei Inhalten in der Klammer IMMER mit e => anfangen

		//Aufgabenstellung: Finde das erste Element, welches durch 5 teilbar ist
        Console.WriteLine(zahlen.First(e => e % 5 == 0));

		//Ohne Linq
		int first = 0;
        foreach (int i in zahlen)
        {
            if (i % 5 == 0)
			{
				first = i;
				break;
			}
        }
        Console.WriteLine(first);


        //Console.WriteLine(zahlen.First(e => e % 50 == 0)); //System.InvalidOperationException: 'Sequence contains no matching element'
        Console.WriteLine(zahlen.FirstOrDefault(e => e % 50 == 0)); //0
		#endregion

		#region Linq mit Objektliste
		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Alle Fahrzeuge finden, welche mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.MaxV >= 200);

		//Alle VWs finden, welche mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.MaxV >= 200 && e.Marke == FahrzeugMarke.VW);
		fahrzeuge.Where(e => e.MaxV >= 200).Where(e => e.Marke == FahrzeugMarke.VW); //suboptimal

		//Liste sortieren
		//WICHTIG: Originale Liste bleibt unverändert
		fahrzeuge.OrderBy(e => e.Marke);
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV); //Sekundäre, Tertiäre, ... Sortierung hinzufügen

		fahrzeuge.OrderByDescending(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.MaxV).ThenByDescending(e => e.Marke);

		//Was ist das langsamste Fahrzeug in unserer Liste?
		//Mit 2 Linq Funktionen
		fahrzeuge.OrderBy(e => e.MaxV).First();

		//MinBy, MaxBy
		//Gibt das Element mit dem gesuchten Min/Max zurück
		fahrzeuge.MinBy(e => e.MaxV); //Das langsamste Fahrzeug
		fahrzeuge.MaxBy(e => e.MaxV); //Das schnellste Fahrzeug

		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit (int)
		fahrzeuge.Max(e => e.MaxV); //Die größte Geschwindigkeit (int)

		//Was ist die Durchschnittsgeschwindigkeit aller Fahrzeuge?
		fahrzeuge.Average(e => e.MaxV); //208.41666666666666

		//Was ist die Durchschnittsgeschwindigkeit aller BMWs?
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).Average(e => e.MaxV);

		//All/Any
		//Prüft, ob alle Elemente/mindestens ein Element einer Bedingung entspricht
		//Geben einen bool zurück
		if (fahrzeuge.All(e => e.MaxV >= 200)) { } //Fahren alle Fahrzeuge mindestens 200km/h?
		if (fahrzeuge.Any(e => e.MaxV > 300)) { } //Fährt mindestens ein Fahrzeug über 300km/h?

		//Count
		//Zählt die Anzahl der Elemente anhand einer Bedingung

		//Wieviel Audis haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.Audi); //4
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.Audi).Count(); //suboptimal

		//Skip/Take
		//Teile der Liste überspringen/nehmen

		//Was sind 3 schnellsten Fahrzeuge in der Liste?
		fahrzeuge.OrderByDescending(e => e.MaxV).Take(3);

		//Webshop
		//Immer nur 5 Elemente gleichzeitig anzeigen
		int page = 0;
		fahrzeuge.Skip(page * 5).Take(5);
		page++;
		fahrzeuge.Skip(page * 5).Take(5);
		page++;
		fahrzeuge.Skip(page * 5).Take(5);

		//Select
		//Wandelt die Liste in eine neue Form um
		//-> beliebige Operationen auf eine Liste anwenden

		//Zwei Anwendungsfälle:
		//1. Fall: Einzelnes Feld entnehmen (80%)

		//Aufgabenstellung: Liste, die nur die Automarken enthält
		fahrzeuge.Select(e => e.Marke); //Nur Marken ohne Rest vom Fahrzeug

		//Schritt 2: Alle Marken eindeutig machen
		fahrzeuge.Select(e => e.Marke).Distinct(); //Marken, welche wir in unserem Autohaus haben

		//Liste mit MaxGeschwindigkeiten
		fahrzeuge.Select(e => e.MaxV); //int-Liste mit den Geschwindigkeiten

		//2. Fall: Liste transformieren (20%)
		//Beispiel 1: Liste von 0 bis 1 mit 0.1 Schritten
		List<double> kommazahlen = new();
		for (int i = 0; i < 11; i++)
		{
			kommazahlen.Add(i / 10.0);
		}

		//Mit Select
		Enumerable.Range(0, 11).Select(e => e / 10.0); //Gehe alle Elemente durch, und gib diese in der Form von dem Ausdruck innerhalb von Select zurück

		//Beispiel 2: Gesamte Liste casten
		List<int> ints = Enumerable.Range(0, 20).ToList();

		//int Liste zu double Liste umwandeln
		ints.Select(e => (double) e);

		//Beispiel 3: Gesamte Liste in schöne Ausgaben konvertieren
		fahrzeuge.Select(e => $"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV}km/h fahren.");
		#endregion

		#region IEnumerable
		//IEnumerable
		//Warum geben alle Linq Funktionen ein IEnumerable zurück und nicht ein Array oder eine List?

		//IEnumerable ist nur eine Anleitung zum Erstellen der fertigen Liste
		//Wenn die Anleitung ausgeführt wird, werden die Elemente erzeugt
		Enumerable.Range(0, 1_000_000_000); //Anleitung zum Erstellen einer Liste der Zahlen von 0 bis 10 (sofort, kein Resourcenverbrauch)
		//Enumerable.Range(0, 1_000_000_000).ToList(); //Hier werden die Werte erzeugt (dauert länger, belegt Resourcen)
		IEnumerable<Fahrzeug> vws = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW); //Wenn möglich, immer IEnumerable benutzen
		#endregion

		#region Erweiterungsmethoden
		//Erweiterungsmethoden
		//An beliebige Typen zusätzlichen Code anhängen

		//Anforderungen: static class, static Methode, this Parameter
		int zahl = 2849;
        Console.WriteLine(zahl.Quersumme()); //Alle ints im gesamten Projekt können jetzt diese Funktion

		//Eigene Linq-Funktion
		//Beispiel: Funktion schreiben, welche eine Liste nach Elementen sucht, die in einer gegebenen Liste
		//Beispiel: Prüfen, welche Fahrzeuge vom Typ BMW oder VW sind
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW || e.Marke == FahrzeugMarke.VW);

		List<FahrzeugMarke> marken = [FahrzeugMarke.BMW, FahrzeugMarke.VW];
		fahrzeuge.Where(e => marken.Contains(e.Marke));

		fahrzeuge.In(e => e.Marke, marken); //Eigene Linq Funktion verwenden
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}