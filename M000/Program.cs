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