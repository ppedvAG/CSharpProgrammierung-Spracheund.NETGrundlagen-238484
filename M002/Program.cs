#region Variablen
//Kommentar

/*
	Mehrzeilige
	Kommentare
 */

//Variablen
//<Datentyp> <Name>;
//<Datentyp> <Name> = <Wert>;
using System.Collections.Concurrent;

int x;
x = 5;

int y = 5;

//cw + Tab: Console.WriteLine
Console.WriteLine(x);

//Datentypen
//Wichtigsten: int, double, string, bool

//Numerische Datentypen:
//byte, short, int, long
//2^8, 2^16, 2^32, 2^64
//1B, 2B, 4B, 8B
byte b = 123;

//Dezimale Datentypen:
//double, float, decimal
double d = 23497.238479;
float f = 3284.1248571F; //Hier muss eine Konvertierung von double zu float erfolgen (F)
decimal m = 214897.2139471248M; //Hier muss eine Konvertierung von double zu decimal erfolgen (M)

//Texttypen:
//string, char
string s = "Hallo Welt"; //Hier müssen doppelte Hochkomma verwendet werden
char c = 'A'; //Char muss mit einzelnen Hochkomma definiert werden

//bool
bool a = true;
a = false;
#endregion

#region Stringverarbeitung
//Strings verbinden
string kommazahl = "Die Kommazahl ist: " + d;
Console.WriteLine(kommazahl);

string kombi = "Die Kommazahl ist: " + d + ", der String ist: " + s + ", der Boolean ist " + b;
Console.WriteLine(kombi);

//String-Interpolation ($-String): Code in einen String einbinden
string interpolation = $"Die Kommazahl ist: {d}, der String ist: {s}, der Boolean ist {b}";
Console.WriteLine(interpolation);

//Escape-Sequenzen: Undruckbare Zeichen in einen String einbauen
Console.WriteLine("Umbruch\nUmbruch");
Console.WriteLine("Tabulator\tTabulator");
//https://learn.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170

//Verbatim-String (@-String): Ignoriert Escape-Sequenzen
//string pfad = "C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.1\System.Console.dll";
string pfadV = @"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.1\System.Console.dll";
#endregion

#region Eingabe
////ReadLine: Wartet auf eine Eingabe vom Benutzer (Enter zum bestätigen)
//string eingabe = Console.ReadLine();
//Console.WriteLine($"Du hast {eingabe} eingegeben");

////ReadKey: Wartet auf einen Tastendruck (kein Enter)
//ConsoleKeyInfo info = Console.ReadKey();
//Console.WriteLine(info.Key); //Taste auf der Tastatur
//Console.WriteLine(info.KeyChar); //Zeichen hinter der Taste
#endregion

#region Konvertierungen
//Drei Arten:
//Typ -> String
//String -> Typ
//Typ -> Typ

//Typ -> String
//ToString()
Console.WriteLine(x.ToString());
Console.WriteLine($"{x}"); //Hier wird ToString() automatisch ausgeführt

//String -> Typ
//Die Parse Funktionen (Nur für String -> anderer Typ)
string userEingabe = "123";
//Console.WriteLine(userEingabe * 2); //Konvertierung notwendig
int userZahl = int.Parse(userEingabe);
double k = double.Parse(userEingabe);
Console.WriteLine(userZahl * 2); //Jetzt kann die konvertierte Zahl verarbeitet werden

//Typ -> Typ
//Cast, Casting, Typecast
//Vor die Variable, welche Konvertiert werden soll, den Typ in Klammern schreiben
double t = 123.456;
int i = (int) t; //Hier muss eine Konvertierung erzwungen werden (explizite Konvertierung)
t = i; //Implizite Konvertierung
#endregion

#region Arithmetik
int z1 = 5;
int z2 = 8;

//Unterschied zw. + und +=
//+ bildet nur die Summe, diese Summe muss weiterverwendet werden
int summe = z1 + z2;
Console.WriteLine(z1 + z2);

//+= verändert den Wert auf der linken Seite des Operators
//z2 wird auf z1 addiert
z1 += z2; //z1 wird auf 13 verändert

//Erhöht/Verringert eine Zahl um 1
z1++;
z1--;

double runden = 2374.23184;
Math.Ceiling(runden); //Aufrunden
Math.Floor(runden); //Abrunden
Math.Round(runden); //Rundet auf die nächste gerade Zahl (4.5 -> 4, 5.5 -> 6)
Math.Round(runden, 2); //Auf X Kommastellen runden
Console.WriteLine(runden); //Originaler Wert wird nicht verändert
runden = Math.Round(runden, 2); //Neuer Wert zuweisen
Console.WriteLine(runden);

//Divisionseigenheiten
Console.WriteLine(8 / 5); //1, weil eine Int-Division verwendet wird
Console.WriteLine(8.0 / 5); //1.6
Console.WriteLine(8d / 5); //1.6
Console.WriteLine(8 / 5f); //1.6
Console.WriteLine(z1 / (double) z2); //Eine Zahl Casten
#endregion