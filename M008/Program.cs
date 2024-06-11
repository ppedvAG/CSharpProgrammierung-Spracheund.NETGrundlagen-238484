using System.Diagnostics.Metrics;

namespace M008;

/// <summary>
/// Vererbung
/// Ermöglicht, generelle Oberklassen zu entwickeln, welche Standardaspekte der Unterklassen vorgeben
/// Die Properties und Funktionen der Oberklasse werden nach unten vererbt
/// -> Die Unterklassen haben auch diese Properties & Funktionen
/// 
/// Beispiel: Stream
/// - Stream gibt Schreib-/Leseaktionen vor
/// - FileStream, MemoryStream, ... spezifizieren dieses Konzept
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("Max", 23);
		m.Name = "Max"; //Name wurde von Lebewesen vererbt
		m.Bewegen(10); //Bewegen wurde von Lebewesen vererbt

		Hund h = new Hund("Bello");
		//Hund erbt auch Name und Bewegen, aber nicht Sprechen
	}
}

public class Lebewesen
{
	public string Name { get; set; }

	/// <summary>
	/// Virtual & Override
	/// Ermöglicht, spezifische Methoden (Methoden mit virtual) in den Unterklassen zu verändern
	/// Das Lebewesen -> Der Mensch, Der Hund
	/// </summary>
	public virtual void Bewegen(int distanz)
	{
        Console.WriteLine($"Das Lebewesen {Name} bewegt sich um {distanz}m.");
    }

	public Lebewesen(string name)
	{
		Name = name;
	}
}

/// <summary>
/// Mit : nach dem Klassennamen kann eine Oberklasse definiert werden
/// "Mensch erbt von Lebewesen"
/// "Mensch ist ein Lebewesen"
/// </summary>
public class Mensch : Lebewesen
{
	public int Alter { get; set; }

	/// <summary>
	/// Strg + . -> Generate Constructor
	/// 
	/// Extra Feld hinten anhängen um dieses beim Konstruktor hinzuzufügen
	/// </summary>
	public Mensch(string name, int alter) : base(name)
	{
		Alter = alter;
	}

	public void Sprechen(string text)
	{
		//Name von Lebewesen empfangen
        Console.WriteLine($"{Name} sagt: {text}");
    }

	/// <summary>
	/// override + Abstand -> Methode auswählen und generieren lassen
	/// Spezifische Implementation der Methode für Mensch
	/// </summary>
	public override void Bewegen(int distanz)
	{
		//base: Selbige Verwendung wie this, aber im Vererbungskontext (zwischen Unterklasse und Oberklasse)
		//base.Bewegen(distanz): Führe den Code aus der Oberklasse aus
		Console.WriteLine($"Der Mensch {Name} ({Alter}) bewegt sich um {distanz}m.");
    }
}

public class Hund : Lebewesen
{
	public Hund(string name) : base(name)
	{
	}

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Der Hund {Name} bewegt sich um {distanz}m.");
	}
}