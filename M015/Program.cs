using System.Diagnostics;
using System.Text.Json;
using System.Xml.Serialization;

namespace M015;

internal class Program
{
	static void Main(string[] args)
	{
		//Dateimanagement
		//Drei Klassen: File, Directory, Path

		string folderPath = "Output";
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//StreamWriter: Öffnet einen Stream im Schreibmodus auf das gegebene File
		//WICHTIG: Muss per Hand geschlossen werden, um den Inhalt zu schreiben
		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Hallo"); //Text in einen Buffer schreiben
		sw.WriteLine("Welt");
		sw.Flush(); //Inhalt des Writers schreiben
		sw.Close();

		//using-Block: Objekte, welche auf externe Resourcen zugreifen (Dateien, DB, Webschnittstelle, ...) können mit einem Using-Block versehen werden
		//Am Ende des Blocks wird das entsprechende Objekt automatisch geschlossen
		//Der Using-Block kann auf alle Objekte angewandt werden, welche das IDisposable Interface haben
		using (StreamReader sr = new StreamReader(filePath))
		{
			string fullFile = sr.ReadToEnd(); //Liest das gesamte File ein

			//File Zeilenweise einlesen
			List<string> lines = [];
			while (!sr.EndOfStream)
				lines.Add(sr.ReadLine());
		} //.Close()

		//using-Statement: Selbiges wie Using-Block, aber wird am Ende der Methode geschlossen
		using StreamWriter sw2 = new StreamWriter("Using.txt");

		//Die File Klasse
		//Schnelle Lese-/Schreibmethoden
		File.WriteAllText(filePath, "Hallo Welt!"); //String schreiben
		string content = File.ReadAllText(filePath);
        Console.WriteLine(content);

		string[] lines2 = File.ReadAllLines(filePath);
		File.WriteAllLines(filePath, lines2); //Array schreiben

		//////////////////////////////////////////////////////////////////////////////////////

		//NuGet-Pakete
		//Externe Pakete, welche zu unserem Projekt hinzuinstalliert werden können
		//Tools -> NuGet Package Manager -> Manage Packages
		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Newtonsoft.Json
		//string json = JsonConvert.SerializeObject(fahrzeuge);
		//string jsonPath = Path.Combine(folderPath, "Test.json");
		//File.WriteAllText(jsonPath, json);

		//string readJson = File.ReadAllText(jsonPath);
		//Fahrzeug[] readFzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson);

		//System.Text.Json
		string json = JsonSerializer.Serialize(fahrzeuge);
		string jsonPath = Path.Combine(folderPath, "Test.json");
		File.WriteAllText(jsonPath, json);

		string readJson = File.ReadAllText(jsonPath);
		Fahrzeug[] readFzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson);

		//Xml
		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (StreamWriter writer = new StreamWriter("Output\\Test.xml"))
		{
			xml.Serialize(writer, fahrzeuge);
		}

		using (StreamReader reader = new StreamReader("Output\\Test.xml"))
		{
			List<Fahrzeug> fzg = (List<Fahrzeug>) xml.Deserialize(reader);
		}
	}
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}

    public Fahrzeug()
    {
        
    }
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}