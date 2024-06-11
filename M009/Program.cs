namespace M009;

/// <summary>
/// Polymorphismus
/// -> Typkompatibilität
/// 
/// Beschreibt, welche Typen mit welchen anderen Typen kompatibel sind
/// Wichtigste Regel: Ein Typ ist immer kompatibel mit sich selbst, oder einer Unterklasse von sich selbst
/// Zweitwichtigste Regel: Überall wo ein Typ steht (Parameter, Variable, Rückgabewert, ...) gilt der Polymorphismus
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		#region Polymorphismus Theorie
		Hund h = new Hund("Bello");

		Lebewesen l = new Hund("Bello"); //Möglich, weil Hund eine Unterklasse von Lebewesen ist

		Mensch m = new Mensch("Max", 33);

		l = m; //Mensch auf Lebewesen Variable zuweisen

		object o = m; //Alle Typen in C# haben als Oberklasse die Object Klasse -> alle Typen sind mit object kompatibel
		o = 123;
		o = false;
		o = new object();

		Test(123);
		Test(h);
		Test(l);
		Test(o);
		Test("Hallo");
		#endregion

		Type t = l.GetType();
		Type t2 = typeof(Lebewesen);

		#region Genauer Typvergleich
		Lebewesen l2 = new Mensch("Max", 33);
		if (l2.GetType() == typeof(Lebewesen))
		{
			//l2.GetType(): Mensch
			//typeof(Lebewesen): Lebewesen
			//Mensch == Lebewesen
			//false

		}

		if (l2.GetType() == typeof(Mensch))
		{
			//true
		}
		#endregion

		#region Vererbungshierarchietypvergleich
		//Ist l3 ein Lebewesen, oder eine Unterklasse von Lebewesen?
		Lebewesen l3 = new Mensch("Max", 33);
		if (l3 is Lebewesen)
		{
			//true
		}

		if (l3 is Mensch)
		{
			//true
		}
		#endregion

		//Praktisches Beispiel für Polymorphismus
		Lebewesen[] zoo = new Lebewesen[3];
		zoo[0] = new Hund("");
		zoo[1] = new Mensch("", 33);
		zoo[2] = new Katze("");

		foreach (Lebewesen lw in zoo)
		{
			//Name kommt von Lebewesen -> Name muss in jeder Unterklasse enthalten sein
            Console.WriteLine(lw.Name);
			lw.Bewegen(10);

			//Mithilfe eines Typvergleichs alle Menschen zum Sprechen bringen
			if (lw is Mensch)
			{
				Mensch mensch = (Mensch)lw;
				mensch.Sprechen("Hallo");
			}
        }
	}

	/// <summary>
	/// Diese Methode kann alle Parameter empfangen
	/// </summary>
	static void Test(object o) { }

	static Lebewesen Test()
	{
		return new Hund("");
		return new Mensch("", 33);
		//return new Lebewesen("");
		//return new object(); //Nicht möglich
	}
}

public class Katze : Lebewesen
{
	public Katze(string name) : base(name)
	{
	}

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Die Katze {Name} bewegt sich um {distanz}m.");
	}
}