bool schaltjahr = false;
int jahr = 2000;
if (jahr % 4 == 0)
{
	schaltjahr = true;
	if (jahr % 100 == 0)
		schaltjahr = false;
	if (jahr % 400 == 0)
		schaltjahr = true;
}
Console.WriteLine($"{jahr} ist {(schaltjahr ? "ein" : "kein")} Schaltjahr");


int[] gewinnzahlen = [33, 18, 27, 12, 75];
string eingabe = Console.ReadLine();
int eingabeZahl = int.Parse(eingabe);
if (eingabeZahl >= 0 && eingabeZahl <= 100)
{
    Console.WriteLine(gewinnzahlen.Contains(eingabeZahl) ? "Glückwunsch" : "Zahl nicht enthalten");
	//if (gewinnzahlen.Contains(eingabeZahl))
	//{
	//	Console.WriteLine("Glückwunsch!");
	//}
	//else
	//{
	//	Console.WriteLine("Zahl nicht enthalten");
	//}
}
else
{
    Console.WriteLine("Zahl muss zwischen 0 und 100 liegen");
}