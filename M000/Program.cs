Fahrzeug f = new Fahrzeug("VW", 200, 20_000);
f.StarteMotor();
f.Beschleunige(50);
f.Beschleunige(200);
f.StoppeMotor();
f.Beschleunige(-100);
Console.WriteLine(f.Info());
f.Beschleunige(-50);
f.StoppeMotor();

class Fahrzeug
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

    public Fahrzeug(string name, int maxV, int preis)
    {
		Name = name;
		MaxV = maxV;
		Preis = preis;
    }
}