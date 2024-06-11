namespace M009;

public class Mensch : Lebewesen
{
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name)
	{
		Alter = alter;
	}

	public void Sprechen(string text)
	{
		Console.WriteLine($"{Name} sagt: {text}");
	}

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Der Mensch {Name} ({Alter}) bewegt sich um {distanz}m.");
	}
}
