namespace M009;

/// <summary>
/// abstract
/// Eine Abstrakte Klasse gibt nur die Struktur vor und kann nicht instanziert werden (kein Objekt erstellen)
/// Wird dementsprechend nur für Vererbung verwendet
/// Innerhalb einer abstrakte Klasse gibt es abstrakte Methoden/Properties, welche von den Unterklasse implementiert werden müssen
/// </summary>
public abstract class Lebewesen
{
	public string Name { get; set; }

	/// <summary>
	/// Abstrakte Methode ohne Body
	/// Alle Unterklassen müssen diese Methode implementieren
	/// </summary>
	public abstract void Bewegen(int distanz);

	public Lebewesen(string name)
	{
		Name = name;
	}
}
