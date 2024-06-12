namespace M010;

/// <summary>
/// Interfaces
/// Struktur vorgeben, welche von den Unterklassen implementiert werden muss
/// Ein Interface funktioniert wie eine abstrakte Klasse
/// - Methoden ohne Body, welche in den Unterklassen ausimplementiert werden müssen
/// - Kann nicht erstellt werden (kein new)
/// - Wird nur für Vererbung verwendet
/// 
/// Wichtiger Unterschied: Eine Klasse kann beliebig viele Interfaces haben (im Gegensatz zu Klassen)
/// 
/// Verwendungszweck: Polymorphismus
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		Smartphone s = new Smartphone();
		Wertkarte w = new Wertkarte();
		s.Aufladen(50);
		w.Aufladen(50);

		//Beiden möglich, weil beide Klassen das Interface haben
		IAufladbar a = s;
		a = w;

		s.LadestandAusgeben();

		MaximumAusgeben(s);
		MaximumAusgeben(w);

		//Beispiel aus C#: IEnumerable
		//Basis, für alle Listentypen in C#
		//Beispiel: Array, List, Dictionary, Queue, Stack, ObservableCollection, ...
		int[] zahlen = [1, 2, 3, 4]; //Array
		List<int> ints = new List<int>(); //List
		zahlen.Concat(ints); //Concat nimmt als Parameter zwei IEnumerables -> zwei beliebige Listen zusammenbauen, auch wenn diese keinen gleichen Typen haben
		zahlen.SequenceEqual(ints); //Hier können auch zwei unterschiedliche Typen verglichen werden
		ints.AddRange(zahlen); //Mithilfe von AddRange kann auch ein Array hinzugefügt werden
	}

	static void MaximumAusgeben(IAufladbar a) { }
}

/// <summary>
/// Interfaces fangen immer mit einem I an
/// 
/// Beispiel: IAufladbar mit einem Smartphone und einer Wertkarte
/// Smartphone und Wertkarte sind nicht vergleichbar
/// Dieses Interface sort dafür, das diese beiden Klassen eine Gemeinsamkeit haben können, ohne eine gemeinsame Oberklasse zu haben
/// Das Interface gibt diesen beiden Klassen eine gemeinsamen Typen, über den Objekte dieser Klassen gruppiert werden können
/// </summary>
public interface IAufladbar
{
	public int Ladestand { get; set; }

	public int Maximum { get; set; }

	public void Aufladen(int ladestand);

	public double LadeProzent();

	public void LadestandAusgeben();
}

public class Smartphone : IAufladbar
{
	public int Ladestand { get; set; }

	public int Maximum { get; set; } = 100;

	public void Aufladen(int l)
	{
		if (Ladestand + l > Maximum)
			Ladestand = Maximum;
		Ladestand += l;
	}

	public double LadeProzent()
	{
		return Ladestand / Maximum;
	}

	public void LadestandAusgeben()
	{
        Console.WriteLine($"Ladestand: {Ladestand}/{Maximum} ({LadeProzent()})");
    }
}

public class Wertkarte : IAufladbar
{
	public int Ladestand { get; set; }

	public int Maximum { get; set; } = int.MaxValue;

	public void Aufladen(int l)
	{
		Ladestand += l;
	}

	public double LadeProzent()
	{
		return -1;
	}

	public void LadestandAusgeben()
	{
        Console.WriteLine($"Ladestand: {Ladestand}€");
    }
}