namespace M011;

internal class Program
{
	/// <summary>
	/// Debugging
	/// Programm Schritt für Schritt durchführen
	/// 
	/// Fenster (Bei gestartetem Programm):
	/// - Locals: Debug -> Windows -> Locals
	/// - Immediate Window: Schnell C# Code ausführen
	/// - Watch: Variablen "dauerhaft" beobachten
	/// 
	/// Navigation:
	/// - Step Over (F10): Führt die gesamte Codezeile aus
	/// - Step Into (F11): Steige in die Methode hinein (eine Ebene nach unten)
	/// - Step Out (Shift + F11): Gegenteil zu Step Into, geht eine Ebene nach oben
	/// - Continue: Führt das Programm bis zum nächsten Breakpoint aus
	/// </summary>
	static void Main(string[] args)
	{
		//try-catch
		//Fehler, welche das Programm zum Absturz bringen würden behandeln, sodass das Programm nicht mehr abstürzt

		//Beispiel: User Input und int.Parse
		try //Codeblock markieren -> Rechtsklick -> Snippet -> Surround With
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exceptions
			int x = int.Parse(eingabe);

			if (x == 0) //Eigene Fehler verursachen mittels throw
				throw new Exception("Division durch 0 nicht möglich");
		}
		catch (FormatException) //catch-Block: Wenn der entsprechende Fehler auftreten würde, wird stattdessen dieser Code ausgeführt und das Programm stürzt nicht ab
		{
            Console.WriteLine("Deine Eingabe ist keine Zahl");
        }
		catch (OverflowException)
		{
			Console.WriteLine("Die Eingegebene Zahl ist zu klein/groß");
		}
		catch (Exception e) //Alle anderen Fehler fangen
		{
            Console.WriteLine(e.Message); //C#-interne Nachricht herausgreifen
            Console.WriteLine(e.StackTrace); //Zeigt an, wo der Fehler im Code aufgetreten ist
        }
		finally //Wird immer ausgeführt
		{
            Console.WriteLine("Parsen abgeschlossen");
        }
	}
}
