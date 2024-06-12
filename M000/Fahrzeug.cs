using M000;

public abstract class Fahrzeug
{
	public string Name { get; set; }

	public int MaxV { get; set; }

	public int AktV { get; private set; }

	public int Preis { get; set; }

	public bool MotorLaeuft { get; private set; }

	public void StarteMotor()
	{
		if (!MotorLaeuft)
		{
			MotorLaeuft = true;
			Console.WriteLine("Motor wurde gestartet");
		}
		else
		{
			Console.WriteLine("Motor ist bereits gestartet");
		}
	}

	public void StoppeMotor()
	{
		if (MotorLaeuft && AktV <= 0)
		{
			MotorLaeuft = false;
			Console.WriteLine("Motor wurde gestoppt");
		}
		else
		{
			Console.WriteLine("Motor konnte nicht gestoppt werden");
		}
	}

	public string Info()
	{
		return $"Das Fahrzeug {Name} könnte maximal {MaxV}km/h fahren, und kostet {Preis}€. {(MotorLaeuft ? $"Es fährt momentan {AktV}km/h." : "")}";
	}

	public void Beschleunige(int a)
	{
		//if (MotorLaeuft)
		//{
		//	if (AktV + a > 0)
		//	{
		//		if (AktV + a <= MaxV)
		//		{
		//			AktV += a;
		//		}
		//		else
		//		{
		//			Console.WriteLine($"Geschwindigkeit darf die Maximalgeschwindigkeit ({MaxV}km/h) nicht überschreiten");
		//		}
		//	}
		//	else
		//	{
		//		Console.WriteLine("Geschwindigkeit darf 0km/h nicht unterschreiten");
		//	}
		//}
		//else
		//{
		//		Console.WriteLine("Der Motor muss laufen um beschleunigen zu können");
		//}

		if (!MotorLaeuft)
		{
			Console.WriteLine("Der Motor muss laufen um beschleunigen zu können");
			return; //Beende die Funktion
		}

		if (AktV + a < 0)
		{
			Console.WriteLine("Geschwindigkeit darf 0km/h nicht unterschreiten");
			return;
		}

		if (AktV + a > MaxV)
		{
			Console.WriteLine($"Geschwindigkeit darf die Maximalgeschwindigkeit ({MaxV}km/h) nicht überschreiten");
			return;
		}

		//Wenn alle Fehler erfolgreich behandelt:
		AktV += a;
		Console.WriteLine($"Fahrzeug hat um {a}km/h beschleunigt");
	}

	public override string ToString()
	{
		return $"{Name}: {GetType()}";
	}

	public static Fahrzeug GeneriereFahrzeug(string name)
	{
		Random r = new Random();
		int x = r.Next(0, 3);
		switch (x)
		{
			case 0:
				return new PKW(name, 300, 20000);
			case 1:
				return new Schiff(name, 50, 20000);
			default:
				return new Flugzeug(name, 1000, 20_000_000);
		}
	}

	public Fahrzeug(string name, int maxV, int preis)
	{
		Name = name;
		MaxV = maxV;
		Preis = preis;
	}
}