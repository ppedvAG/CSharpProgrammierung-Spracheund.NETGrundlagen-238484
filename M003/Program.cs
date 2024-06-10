#region Arrays
//Array: Variable die mehrere Werte halten kann
int[] zahlen = new int[10]; //Array mit größe 10, Index 0-9
zahlen[2] = 10;
Console.WriteLine(zahlen[2]);

//Direkte Initialisierung
zahlen = new int[] { 1, 2, 3, 4, 5 }; //Keine Größe angeben
zahlen = new[] { 1, 2, 3, 4, 5 };
int[] zahlen2 = { 1, 2, 3, 4, 5 };
zahlen = [1, 2, 3, 4, 5]; //Ab C# 12 (2024)

//Funktionen des Arrays
Console.WriteLine(zahlen.Length); //Anzahl Stellen (5)
zahlen.Contains(5); //Prüft, ob das Array die gegebene Zahl enthält (Gibt einen bool zurück)

//Mehrdimensionale Arrays
int[,] zweiD = new int[3, 3]; //Matrix (3x3)
zweiD[1, 1] = 5;
Console.WriteLine(zweiD[1, 1]);
#endregion

#region Bedingungen
int z1 = 5;
int z2 = 8;
if (z1 > z2)
{
	Console.WriteLine("z1 ist größer als z2");
}
else
{
	if (z1 < z2)
	{
		Console.WriteLine("z1 ist kleiner als z2");
	}
	else
	{
		Console.WriteLine("z1 ist gleich z2");
	}
}

//Bei Einzeiligen Blöcken können die Klammern weggelassen werden
if (z1 > z2)
	Console.WriteLine("z1 ist größer als z2");
else if (z1 < z2)
	Console.WriteLine("z1 ist kleiner als z2");
else
	Console.WriteLine("z1 ist gleich z2");

//Ternary Operator (?-Operator)
//If/Else Bäume kompakt darstellen

//Aufgabenstellung: Den Baum darüber mit dem Ternary Operator darstellen
//? If
//: Else
Console.WriteLine(z1 > z2 ? "z1 ist größer als z2" : (z1 < z2 ? "z1 ist kleiner als z2" : "z1 ist gleich z2"));

//WICHTIG: Der Ternary Operator muss bei jedem Teil immer einen Wert als Ergebnis haben
//z1 > z2 ? Console.WriteLine("z1 ist größer als z2") : (z1 < z2 ? Console.WriteLine("z1 ist kleiner als z2") : Console.WriteLine("z1 ist gleich z2"));
#endregion