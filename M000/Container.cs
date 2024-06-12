namespace M000;

public class Container : IBeladbar
{
	public Fahrzeug GeladenesFahrzeug { get; set; }

	public void Belade(Fahrzeug fzg)
	{
		if (GeladenesFahrzeug == null)
		{
			GeladenesFahrzeug = fzg;
			Console.WriteLine($"Fahrzeug {fzg.Name} geladen");
		}
		else
		{
			Console.WriteLine($"Dieser Container hat bereits ein Fahrzeug geladen: {GeladenesFahrzeug.Name}");
		}
	}

	public Fahrzeug Entlade()
	{
		if (GeladenesFahrzeug == null)
		{
            Console.WriteLine("Momentan ist kein Fahrzeug geladen");
			return null;
        }

		Fahrzeug fzg = GeladenesFahrzeug;
		GeladenesFahrzeug = null;
		return fzg;
	}
}