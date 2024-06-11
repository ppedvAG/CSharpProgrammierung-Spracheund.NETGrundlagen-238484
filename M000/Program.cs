while (true)
{
	double z1 = ZahlEingabe("Gib eine Zahl ein: ");
	double z2 = ZahlEingabe("Gib eine weitere Zahl ein: ");
	Rechenarten r = RechenartEingabe();

	Berechne(z1, z2, r);

    Console.WriteLine("Enter drücken zum Wiederholen");
	if (Console.ReadKey(true).Key != ConsoleKey.Enter)
		break;
	Console.Clear();
}

double Berechne(double z1, double z2, Rechenarten art)
{
	switch (art)
	{
		case Rechenarten.Addition:
			Console.WriteLine($"{z1} + {z2} = {z1 + z2}");
			return z1 + z2;
		case Rechenarten.Subtraktion:
			Console.WriteLine($"{z1} - {z2} = {z1 - z2}");
			return z1 - z2;
		case Rechenarten.Multiplikation:
			Console.WriteLine($"{z1} * {z2} = {z1 * z2}");
			return z1 * z2;
		case Rechenarten.Division:
			Console.WriteLine($"{z1} / {z2} = {z1 / z2}");
			return z1 / z2;
		default: return double.NaN;
	}
}

double ZahlEingabe(string text)
{
	while (true)
	{
		Console.Write(text);
		string eingabe = Console.ReadLine();

		int result;
		if (int.TryParse(eingabe, out result))
			return result;

        Console.WriteLine("Eingabe ist nicht numerisch!\n");
    }
}

Rechenarten RechenartEingabe()
{
	while (true)
	{
		string info = "";
		foreach (Rechenarten art in Enum.GetValues<Rechenarten>())
			info += $"{(int) art}: {art}\n";
		double zahl = ZahlEingabe($"Gib eine Rechenart ein: \n{info}");

		//if (zahl >= 1 && zahl <= 4)
		//	return (Rechenarten) zahl;

		Rechenarten r = (Rechenarten) zahl;
		if (Enum.IsDefined<Rechenarten>(r))
			return r;
        Console.WriteLine("Eingabe ist keine gültige Rechenart!\n");
    }
}

enum Rechenarten
{
	Addition = 1,
	Subtraktion,
	Multiplikation,
	Division
}