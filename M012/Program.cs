namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		//List
		//Funktioniert wie ein Array, aber kann beliebig viele Elemente halten

		//Generischer Datentyp: Überall wo innerhalb der Klasse/Methode T verwendet wird, wird dieses durch einen konkreten Typen ersetzt
		List<int> zahlen = new List<int>(); //Hier muss in der spitzen Klammer der Datentyp angegeben werden ("List von int")
		zahlen.Add(1); //Werte an das Ende der Liste anfügen
		zahlen.Add(2); //T wird durch int ersetzt
		zahlen.Add(3);
		zahlen.Add(4);

		List<string> texte = new List<string>();
		texte.Add("Hallo"); //T wird durch string ersetzt

		Console.WriteLine(zahlen[1]); //Index wie bei Array
		zahlen[1] = 10;

		zahlen.Sort();

		//Schleife wie bei Array
		foreach (int i in zahlen)
		{
            Console.WriteLine(i);
        }

		///////////////////////////////////////////////

		//Dictionary
		//Liste von Schlüssel-Wert Paaren
		//Jeder Schlüssel muss eindeutig sein
		//Jeder Wert hat einen Schlüssel
		Dictionary<string, int> einwohnerzahlen = new(); //new(): Target-Typed new, Typ der rechten Seite durch die Linke Seite ergänzen
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 2_160_000); //System.ArgumentException: 'An item with the same key has already been added. Key: Paris'

		//Schlüssel prüfen
		if (!einwohnerzahlen.ContainsKey("Paris"))
			einwohnerzahlen.Add("Paris", 2_160_000);

		//Index wie bei Array
		Console.WriteLine(einwohnerzahlen["Wien"]); //Gibt den Value des Schlüssels "Wien" zurück

		//Schleife wie bei Array
		foreach (KeyValuePair<string, int> kv in einwohnerzahlen)
		{
            Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
        }

		//var: Typ wird automatisch ergänzt
		foreach (var kv in einwohnerzahlen)
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
		}
	}
}
