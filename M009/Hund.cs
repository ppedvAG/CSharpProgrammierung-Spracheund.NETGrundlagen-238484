namespace M009;

//Strg + .: Implement abstract Member(s)
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
