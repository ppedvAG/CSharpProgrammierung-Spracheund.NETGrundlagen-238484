using System.Diagnostics.CodeAnalysis;

namespace M007;

internal class Program
{
	static void Main(string[] args)
	{
		#region GC
		//int[] zahlen = Enumerable.Range(0, 1_000_000_000).ToArray();

		for (int i = 0; i < 5; i++)
		{
			Person p = new Person(); //Hier wird jedes mal der Zeiger überschrieben, welcher auf das Objekt zeigt
		}

		//Die 5 Objekte liegen weiterhin in Arbeitsspeicher
		GC.Collect();
		GC.WaitForPendingFinalizers(); //Warte auf alle Desktruktoren
									   //4 Objekte gelöscht, weil das 5. noch in p enthalten ist
		#endregion

		#region Static
		//Static: Global
		//Methode ohne Static bezieht sich immer auf Objekte die aus einer Klasse erzeugt werden
		//Methode mit Static bezieht sich nicht auf die Objekte, sondern ist nur über den Klassennamen ansprechbar

		//Beispiel nicht-statisch:
		Person p2 = new Person();
		p2.Sprechen("Hallo"); //Sprechen bezieht sich auf p2

        //Beispiel statisch:
        Console.WriteLine("Hallo"); //Hier muss kein Console Objekt erzeugt werden (new Console())

		//Person.Sprechen(""); //Hier wird ein Objekt benötigt

		//Eigene Static-Variable: Personenzähler
		//Siehe Person.cs
		//WICHTIG: Der Zähler ist bei allen Person-Objekten immer gleich

		Person p3 = new Person(); //Zähler wird bei allen Personen (p2, p3) erhöht
        Console.WriteLine(Person.Zaehler); //Statische Variable angreifen
		#endregion

		#region Arbeiten mit Datumswerten
		//Zwei Klassen: DateTime, TimeSpan

		//DateTime: Zeitpunkt mit Datum
		DateTime dt = new DateTime(2024, 06, 11);
        Console.WriteLine(dt.AddHours(12)); //Wie spät ist es in 12 Stunden?

        Console.WriteLine(dt.Day); //Nur den Tag herausgreifen
        Console.WriteLine(dt.Month);
        Console.WriteLine(dt.Year);

        //Aufgabenstellung: Alter in Tagen berechnen
        Console.WriteLine(DateTime.Now - new DateTime(1998, 07, 18));

		//Bonus: Jahre
		TimeSpan ts = DateTime.Now - new DateTime(1998, 07, 18);
        Console.WriteLine(ts.TotalDays / 365.25);

        Console.WriteLine(DateTime.Now + TimeSpan.FromDays(3)); //Welche Tag ist in 3 Tagen?
		#endregion

		#region Werte- und Referenztypen
		//In C# gibt es zwei verschiedene Arten von Typen

		//Referenztypen
		//class
		//Wenn eine Variable angelegt wird, wird in diese Variable ein Zeiger gelegt, welcher auf das unterliegende Objekt zeigt
		Person p4 = new Person(); //Objekt wird im Arbeitsspeicher angelegt, und ein Zeiger wird in p4 gelegt, welcher auf das Objekt zeigt
		Person p5 = p4; //Zeiger auf das Objekt unter p4
		p4.Alter = 50;

        Console.WriteLine(p4.GetHashCode()); //Gibt die Speicheradresse des Objekts zurück
        Console.WriteLine(p5.GetHashCode());
		//Wenn zwei Objekte eines Referenztypens verglichen werden, werden die Speicheradressen verglichen
		if (p4 == p5) { } // --> if (p4.GetHashCode() == p5.GetHashCode()) { }

		//Wertetyp
		//struct
		//Wenn eine Variable angelegt wird, wird in diese Variable der Wert selbst gelegt
		int x = 10; //int ist ein struct -> Wertetyp
		int y = x; //Wert von x wird in y kopiert
		x = 20; //y bleibt unverändert

		//Wenn zwei Objekte eines Referenztypens verglichen werden, werden die Inhalte verglichen

		//ref: Wert der Funktion wird als Referenz behandelt
		int zahl = 30;
		Test(ref zahl); //test sollte 50 sein

		Person p6 = new Person();
		Test(p6); //Funktioniert hier ohne Zusätze, weil Person eine class ist
		#endregion

		#region Null
		//Wenn eine Variable keinen Wert hat, ist diese Null
		//Null = nichts
		//Ausnahme: Wertetypen (Wertetypen können nicht null sein)

		Person p7 = null; //Null, weil kein Objekt enthalten ist
		int z; //Standardwert von int (0)

		//p7.Sprechen("Hallo"); //Absturz

		if (p7 is not null)
			p7.Sprechen("Hallo");

		if (p7 != null)
			p7.Sprechen("Hallo");

		//Kurzform
		p7?.Sprechen("Hallo"); //Führe sprechen nur aus, wenn p7 nicht null ist

		//Nullable Wertetypen
		double? d = null; //Nullable double mit ? am Ende des Typens
        #endregion
    }

	static void Test(ref int x)
	{
		x = 50;
	}

	static void Test(Person p)
	{
		p.Alter = 50;
	}
}