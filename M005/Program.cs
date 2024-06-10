namespace M005;

internal class Program
{
	/// <summary>
	/// Funktionen
	/// 
	/// Code kann in Funktionen abgelegt werden, um diesen wiederverwendbar zu machen
	/// Funktionen können verwendet werden, um den Code innerhalb dieser Funktionen auszuführen
	/// </summary>
	static void Main(string[] args)
	{
		int summe = Addiere(3, 4); //Das Ergebnis der Funktion, kann hier in eine Variable gespeichert werden

		PrintAddiere(7, 4); //Diese Funktion kann nicht in eine Variable geschrieben werden, weil diese den Rückgabetyp void hat

		double summe2 = Addiere(5.0, 2); //1 of 2, Funktion über Parametertypen auswählen

        Console.WriteLine(); //1 of 18, 18 Overloads

		Summiere(1, 2, 3);
		Summiere(1, 2, 3, 4, 5, 6, 7, 8);
		Summiere(1);
		Summiere(); //Summiere kann auch keine Parameter empfangen
		double[] zahlen = [3, 8, 2, 1, 8];
		Summiere(zahlen); //Auch ein Array ist möglich

		//Der optionale Parameter kann übersprungen werden, dann wird der Standardwert genommen
		AddiereOderSubtrahiere(4, 2); //false
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2, true); //Sonderfall
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);
		AddiereOderSubtrahiere(4, 2);

		//out-Parameter
		//Ermöglicht, mehrere Rückgabewerte zu definieren
		//Praktisches Beispiel: TryParse
		//Rückgabewert: bool, out Parameter: result
		string eingabe = "123";
		int ergebnis = 0; //Platzhalter Variable
		bool funktioniert = int.TryParse(eingabe, out ergebnis); //Verbindung zwischen ergebnis und TryParse herstellen (mittels out)
		if (funktioniert)
		{
            Console.WriteLine(ergebnis);
        }
		else
		{
            Console.WriteLine("Parsen hat nicht funktioniert");
        }

		//Nur DayOfWeek erlaubt
		PrintWochentag(DayOfWeek.Monday);
		//PrintWochentag(1);
    }

	/// <summary>
	/// Aufbau:
	/// <Modifier> <Rückgabewert> <Name>(<Par1>, <Par2>, ...) { ... }
	/// </summary>
	static int Addiere(int x, int y)
	{
		return x + y; //Wirft das Ergebnis aus der Funktion hinaus
	}

	/// <summary>
	/// void: Funktion führt Code aus, hat aber kein Ergebnis
	/// </summary>
	static void PrintAddiere(int x, int y)
	{
        Console.WriteLine($"{x} + {y} = {x + y}");
    }

	/// <summary>
	/// Überladung: Mehrere Funktionen mit dem selben Namen definieren
	/// Dabei müssen sich die Parameter unterscheiden
	/// </summary>
	static double Addiere(double x, double y)
	{
		return x + y;
	}

	/// <summary>
	/// params: Beliebig viele Parameter empfangen
	/// </summary>
	static double Summiere(params double[] x)
	{
		return x.Sum();
	}

	/// <summary>
	/// Optionaler Parameter: Wenn ein Parameter mit einem Standardwert belegt wird, muss dieser nicht mehr übergeben werden
	/// </summary>
	static int AddiereOderSubtrahiere(int x, int y, bool sub = false)
	{
		if (!sub)
			return x + y;
		else
			return x - y;
	}

	/// <summary>
	/// Enum Parameter: Nur bestimmte Werte erlaubt
	/// </summary>
	/// <param name="day"></param>
	static void PrintWochentag(DayOfWeek day)
	{
		//...
	}
}