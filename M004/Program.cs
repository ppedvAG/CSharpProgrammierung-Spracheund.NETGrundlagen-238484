#region Schleifen
//Code mehrmals Ausführen
//Vier verschiedene Schleifen:
//- while
//- do-while
//- for
//- foreach

//while
//Führt den Code solange aus, wie die Bedingung true ist
using System.Net;
using System.Net.Http.Headers;

int a = 0;
int b = 10;
while (a < b) //Im Schleifenkopf wird die Bedingung geprüft
{
    Console.WriteLine($"while: {a}");
    a++;
}

a = 0;

//do-while
//Funktioniert wie while, aber führt den Code mindestens einmal aus
do
{
    Console.WriteLine($"do-while: {a}");
	a++;
}
while (a < b);

a = 0;

//Endlosschleife
//while (true) { }

//do-while mittels while (true) repräsentiert (selbes Ergebnis)
while (true)
{
    Console.WriteLine($"while-true: {a}");
	a++;

    if (a >= b)
		break; //Springe hier aus der Schleife hinaus
}

//break und continue
//Steuern den Schleifenablauf
//break: Beendet die Schleife
//continue: Springe zum Schleifenkopf zurück, und überspringe allen Code, welcher nach continue kommt

//Aufgabenstellung: Mini-Lotto mit beliebig viele Versuchen
#region Mini-Lotto++
int[] gewinnzahlen = [33, 18, 27, 12, 75];
while (false)
{
	//string eingabe = Console.ReadLine();
	//int eingabeZahl = int.Parse(eingabe);
	//if (eingabeZahl >= 0 && eingabeZahl <= 100)
	//{
	//	if (gewinnzahlen.Contains(eingabeZahl))
	//	{
	//		Console.WriteLine("Glückwunsch!");
	//		break; //Wenn der User eine korrekte Zahl eingibt, beende die Schleife
	//	}
	//	else
	//	{
	//		Console.WriteLine("Zahl nicht enthalten");
	//	}
	//}
	//else
	//{
	//	Console.WriteLine("Zahl muss zwischen 0 und 100 liegen");
	//}

	//Mini-Lotto mit continue
	//Logik: Fehler aus dem Weg räumen, danach einfach Erfolgscode ausführen
	string eingabe = Console.ReadLine();
	int eingabeZahl = int.Parse(eingabe);
	if (eingabeZahl < 0 || eingabeZahl > 100)
	{
		Console.WriteLine("Zahl muss zwischen 0 und 100 liegen");
		continue; //Wenn der User eine Zahl außerhalb des Bereichs eingibt, starte die Schleife neu
	}

	if (!gewinnzahlen.Contains(eingabeZahl))
	{
		Console.WriteLine("Zahl nicht enthalten");
		continue;
	}

	Console.WriteLine("Glückwunsch!");
	break;
}
#endregion

//for-Schleife
//Funktioniert wie while, hat aber eine Zählervariable integriert
//for + Tab
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"for: {i}");
}

//forr + Tab
for (int i = 9; i >= 0; i--)
{
	Console.WriteLine($"forr: {i}");
}

//Aufgabenstellung: Alle Potenzen von 2^0 is 2^31 ausgeben
for (int i = 0, j = 1; i < 32; i++, j *= 2)
{
    Console.WriteLine($"2^{i}={j}");
}

//foreach
//Vorteil ggü. normaler for-Schleife
//- Kein Index
//- Direkter Zugriff auf die Elemente
int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
for (int i = 0; i < numbers.Length; i++)
{
	Console.WriteLine(numbers[i]);
	//Console.WriteLine(numbers[i + 1]); //Index kann manipuliert werden und dadurch können Fehler entstehen
}

//i repräsentiert immer das derzeitige Element
foreach (int i in numbers)
{
    Console.WriteLine($"foreach: {i}");
}
#endregion

#region Enum
//Enum: Liste von Konstanten
//Jede dieser Konstanten hat eine Zahl dahinter
//WICHTIG: Enums müssen ganz unten definiert werden

//Verwendungszweck: Sicherheit bei "Eingaben"

//Aufgabenstellung: heutigen Tag prüfen
string heute = "Mo";
if (heute == "MO")
{
	//Fehleranfällig
}

Wochentag tag = Wochentag.Mo;
if (tag == Wochentag.Mo)
{
	//Kann keine Fehler verursachen
}

//Bei dieser Funktion können nur 7 mögliche Zustände eingetragen werden
void PrintWochentag(Wochentag tag) { }

//Konvertierung mittels Cast
Console.WriteLine((int) Wochentag.Mo); //Zahl dahinter entnehmen
Console.WriteLine((Wochentag) 0); //Zahl zu Enumwert konvertieren

//Enum.GetValues: Gibt alle Werte des Enums in einem Array zurück
Wochentag[] tage = Enum.GetValues<Wochentag>();

//Enum.Parse: Wandelt einen String zu einem Enumwert um
//Funktioniert mit Zahlen und Texten
Enum.Parse<Wochentag>("1");
Enum.Parse<Wochentag>("Mo");

//Enum.IsDefined: Prüft, ob ein Enumwert in dem Enum enthalten ist
//Jede Zahl kann in ein Enum konvertiert werden und hier kommen keine Fehler
Enum.IsDefined<Wochentag>((Wochentag) 10); //false
#endregion

#region Switch
//Switch
//If-Else Bäume schöner machen

//Aufgabenstellung: Mo-Fr Wochentag, Sa-So Wochenende ausgeben
if (tag == Wochentag.Mo || tag == Wochentag.Di || tag == Wochentag.Mi || tag == Wochentag.Do || tag == Wochentag.Fr)
	Console.WriteLine("Wochentag");
else if (tag == Wochentag.Sa || tag == Wochentag.So)
	Console.WriteLine("Wochenende");
else
    Console.WriteLine("Fehler");

//Strg + .: Schnelloptionen anzeigen
switch (tag)
{
	case Wochentag.Mo:
	case Wochentag.Di:
	case Wochentag.Mi:
	case Wochentag.Do:
	case Wochentag.Fr:
        Console.WriteLine("Wochentag");
        break;
	case Wochentag.Sa:
	case Wochentag.So:
        Console.WriteLine("Wochenende");
        break;
	default:
        Console.WriteLine("Fehler");
        break;
}

//Boolescher Switch
switch (tag)
{
	case >= Wochentag.Mo and <= Wochentag.Fr:
        Console.WriteLine("Wochentag");
		break;
	case Wochentag.Sa or Wochentag.So:
        Console.WriteLine("Wochenende");
		break;
	default:
        Console.WriteLine("Fehler");
		break;
}
#endregion

enum Wochentag
{
	Mo = 1, Di, Mi, Do = 10, Fr, Sa, So
}