using M006.Data;

namespace M006;

/// <summary>
/// Klassen und Objekte
/// 
/// Klasse: Bauplan für Objekte
/// - Gibt nur eine Struktur vor (keine konkreten Werte)
/// - Aus einer Klasse können beliebig viele Objekte erzeugt werden
/// - Jede Klasse ist ein Datentyp
/// 
/// Beispiele für Datentypen: 
/// Int: Zahl
/// Double: Kommazahl
/// String: Text
/// Person, Rechnung, Kunde, ...: ?
/// -> Mit einer Klasse können komplexe Datentypen dargestellt werden
/// 
/// Objekt: Struktur, welche aus einer Klasse erstellt wird
/// Objekt bekommt seinen Aufbau aus der Klasse
/// Objekt hat konkrete Werte
/// 
/// ---------------------------------------
/// 
/// Vollständiges Beispiel:
/// Klasse: Person
/// Felder:
/// - Vorname
/// - Nachname
/// - Alter
/// - Geschlecht
/// - ...
/// 
/// Funktionen:
/// - Sprechen(text)
/// - ...
/// 
/// Objekt(e): Person
/// Variablenname: p1
/// Konkrete Werte: Max, Mustermann, 33, M
/// 
/// Variablenname: p2
/// Konkrete Werte: Anna, Musterfrau, 44, W
/// 
/// ...
/// 
/// Jedes Objekt hat alle Felder und Funktionen seiner Klasse
/// Kann auch Funktionen ausführen
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		//Objekte erstellen
		Person p1 = new Person(); //Code im Konstruktor ausführen
		//Konkrete Werte setzen
		p1.SetVorname("Max");
		p1.Nachname = "Mustermann"; //Property ermöglicht Setzen eines Wertes mit =
		p1.Alter = 33;
		p1.Geschlecht = Geschlecht.M;

		Person p2 = new Person();
		p2.SetVorname("Anna");
		p2.Nachname = "Musterfrau";
		p2.Alter = 44;
		p2.Geschlecht = Geschlecht.W;

		//Funktionen beziehen sich auf das entsprechende Objekt
		p1.Sprechen("Hallo Anna");
		p2.Sprechen("Hallo Max");

		//Person erstellt
		//Person erstellt
		//Max Mustermann (33) sagt: Hallo Anna
		//Anna Musterfrau (44) sagt: Hallo Max

		//Nach vorname, nachname Konstruktor
		Person p3 = new Person("Max", "Mustermann");
		p3.Alter = 33;
		p3.Geschlecht = Geschlecht.M;

		//Nach vorname, nachname, alter, geschlecht Konstruktor
		Person p4 = new Person("Max", "Mustermann", 33, Geschlecht.M);

		//////////////////////////////////////////////////////////////////////////////

		//Assozation von Objekten
		//Verschachtelung von Objekten in andere Objekte
		//Beispiel: Rechnung
		//- Rechnungsposten enthält ein Produkt + Menge, Preis
		//- Produkt: Name, Größe, Gewicht, ...

		//Praxisbeispiel: Kurs
		//Kurs Klasse:
		//Felder:
		//- Titel
		//- Trainer (Person)
		//- Teilnehmer (Person[])
		//- Dauer
		//Funktionen:
		//- TeilnehmerHinzufügen
		//- KursAuflisten
		//Konstruktor
		//- Titel, Trainer, Dauer, beliebig viele Teilnehmer empfangen

		Kurs k = new Kurs("C# Grundkurs", p1, 4, p2, p3, p4);
		k.KursAuflisten();
		Person p5 = new Person("", "");
		Person p6 = new Person("", "");
		k.TeilnehmerHinzufuegen(p5);
		k.TeilnehmerHinzufuegen(p6);
		k.KursAuflisten();

		//////////////////////////////////////////////////////////////////////////////
		
		//Namespaces
		//Organisation von Typen (Klassen, Enums, Structs, Interfaces, ...) in Ordnerstrukturen
		//Generell gibt es einen Wurzelnamespace der mit dem Projektnamen übereinstimmt (hier M006)
		//Jedes File (außer Program.cs) sollte in einem Unterordner liegen
		//Beispiel M006:
		//M006: Program.cs
		//M006.Data: Person.cs, Kurs.cs, Geschlecht.cs
		//In Program.cs wird using M006.Data; benötigt

		//Standardnamespaces
		//System: Wurzel von allen .NET Namespaces
		//System.IO: In-/Output, Dateien
		//System.Net: Netzwerke, HTTP, Mail, FTP
		//System.Drawing, System.Windows: GUI Entwicklung
		//System.Linq: Linq-System
		//...
	}
}