while (true)
{
	Console.Write("Gib eine Zahl ein: ");
	double z1 = double.Parse(Console.ReadLine());

	Console.Write("Gib eine weitere Zahl ein: ");
	double z2 = double.Parse(Console.ReadLine());

	Console.WriteLine("Gib eine Rechenart ein: ");
	foreach (Rechenarten art in Enum.GetValues<Rechenarten>())
	{
		Console.WriteLine($"{(int) art}: {art}");
	}

	Rechenarten r = Enum.Parse<Rechenarten>(Console.ReadLine());
	if (!Enum.IsDefined<Rechenarten>(r))
	{
		Console.WriteLine("Ungültige Rechenart");
		break;
	}

	switch (r)
	{
		case Rechenarten.Addition:
			Console.WriteLine($"Ergebnis: {z1 + z2}");
			break;
		case Rechenarten.Subtraktion:
			Console.WriteLine($"Ergebnis: {z1 - z2}");
			break;
		case Rechenarten.Multiplikation:
			Console.WriteLine($"Ergebnis: {z1 * z2}");
			break;
		case Rechenarten.Division:
			Console.WriteLine($"Ergebnis: {z1 / z2}");
			break;
	}

    Console.WriteLine("Enter drücken zum Wiederholen");
	if (Console.ReadKey(true).Key != ConsoleKey.Enter)
		break;
	Console.Clear();
}

enum Rechenarten
{
	Addition = 1,
	Subtraktion,
	Multiplikation,
	Division
}