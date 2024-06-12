using M000;

Fahrzeug[] fahrzeuge = new Fahrzeug[10];
for (int i = 0; i < fahrzeuge.Length; i++)
{
	fahrzeuge[i] = Fahrzeug.GeneriereFahrzeug(i.ToString());
	Console.WriteLine(fahrzeuge[i].ToString());
}

int pkw = 0;
int schiff = 0;
int flugzeug = 0;
foreach (Fahrzeug fzg in fahrzeuge)
{
	if (fzg is PKW)
		pkw++;
	if (fzg is Schiff)
		schiff++;
	if (fzg is Flugzeug)
		flugzeug++;
}

Console.WriteLine($"Es wurden {pkw} PKW, {schiff} Schiffe, {flugzeug} Flugzeuge erzeugt");

void TesteBeladung(object o1, object o2)
{
	//if (o1 is IBeladbar)
	//{
	//	IBeladbar b = (IBeladbar) o1;
	//	if (o2 is Fahrzeug)
	//	{
	//		Fahrzeug fzg = (Fahrzeug) o2;
	//		b.Belade(fzg);
	//           Console.WriteLine("Objekt 1 hat Objekt 2 geladen");
	//       }
	//}
	//else if (o2 is IBeladbar)
	//{
	//	IBeladbar b = (IBeladbar) o2;
	//	if (o1 is Fahrzeug)
	//	{
	//		Fahrzeug fzg = (Fahrzeug) o1;
	//		b.Belade(fzg);
	//		Console.WriteLine("Objekt 2 hat Objekt 1 geladen");
	//	}
	//}
	//else
	//{
	//       Console.WriteLine("Keines der beiden Objekte kann das andere aufladen");
	//   }


	if (o1 is IBeladbar b && o2 is Fahrzeug fzg)
	{
		b.Belade(fzg);
		Console.WriteLine("Objekt 1 hat Objekt 2 geladen");
	}
	else if (o2 is IBeladbar b2 && o1 is Fahrzeug fzg2)
	{
		b2.Belade(fzg2);
		Console.WriteLine("Objekt 2 hat Objekt 1 geladen");
	}
	else
	{
		Console.WriteLine("Keines der beiden Objekte kann das andere aufladen");
	}
}