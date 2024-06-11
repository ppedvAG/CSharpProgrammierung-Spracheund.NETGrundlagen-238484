namespace M007;

/// <summary>
/// Rechtsklick aufs Projekt -> Add -> Class
/// 
/// Vollständiges Beispiel:
/// Klasse: Person
/// Felder:
/// - Vorname
/// - Nachname
/// - Alter
/// - Geschlecht
/// 
/// Funktionen:
/// - Sprechen(text)
/// </summary>
public class Person
{
    #region Variable
    /// <summary>
    /// private: Dieses Feld kann nur innerhalb der Klasse angegriffen werden
    /// </summary>
    private string vorname;

    /// <summary>
    /// Get-Methode hat immer den Rückgabetyp des dahinterliegenden Felds (private string vorname)
    /// Get-Methode hat generell keine Parameter
    /// </summary>
    public string GetVorname()
    {
        return vorname;
    }

    /// <summary>
    /// Set-Methode hat generell void als Rückgabetyp
    /// Set-Methode hat immer einen Parameter, welcher dem Feld dahinter entspricht
    /// </summary>
    public void SetVorname(string vorname)
    {
        //Prüfen, ob der Vorname zw. 3 und 15 Zeichen hat, und ob der Vorname nur Buchstaben aus besteht
        if (vorname.Length >= 3 && vorname.Length <= 15 && vorname.All(char.IsLetter))
        {
            this.vorname = vorname; //this: Bei gleichnamigen Feldern unterscheiden zwischen dem inneren Feld (hier Parameter) und dem äußeren Feld (private string vorname)
        }
        else
        {
            Console.WriteLine("Vorname muss zw. 3 und 15 Zeichen haben und darf nur auf Buchstaben bestehen!");
        }
    }
    #endregion

    #region Property
    private string nachname;

    /// <summary>
    /// Property
    /// Selbiges wie Get-/Set-Methoden, aber kompakter
    /// Verwendung ist einfacher im Gegensatz zu den Methoden
    /// </summary>
    public string Nachname
    {
        get
        {
            return nachname;
        }
        set
        {
            //Der Parameter innerhalb eines Set-Accesors kommt von einem Keyword: value
            if (value.Length >= 3 && value.Length <= 15 && value.All(char.IsLetter))
            {
                nachname = value;
            }
            else
            {
                Console.WriteLine("Nachname muss zw. 3 und 15 Zeichen haben und darf nur auf Buchstaben bestehen!");
            }
        }
    }

    //Drei verschiedene Formen der Properties:
    //- Full Property: private Feld und public Property (siehe Oben)
    //- Get-Only Property: Property ohne Setter, kann nicht gesetzt werden
    //- Auto-Property: Property ohne private Feld dahinter (Verwendung: Set-Accesor mit Access Modifier (private) versehen)

    //Get-Only Property
    //Berechnet etwas, kann nicht gesetzt werden
    public string VollerName
    {
        get
        {
            return vorname + " " + nachname;
        }
    }

    public string VollerName2
    {
        get => vorname + " " + nachname;
    }

    public string VollerName3 => vorname + " " + nachname;

    //Auto-Property
    //Verhält sich wie eine normale Variable
    //- Verwendung: Json, Xml, WPF Bindings, ..
    //Sollte auf alle Variablen die nicht private sind immer angewandt werden
    public int Alter { get; set; }

    public int Gehalt { get; private set; } //Durch private set kann diese Variable nicht von außen gesetzt werden
    #endregion

    #region Funktionen
    /// <summary>
    /// WICHTIG: Funktionen in einer Klasse sind NICHT static
    /// </summary>
    public void Sprechen(string text)
    {
        Console.WriteLine($"{VollerName} ({Alter}) sagt: {text}");
    }
    #endregion

    #region Konstruktor
    /// <summary>
    /// Konstruktor
    /// Code, welcher bei Erstellung des Objekts aus der Klasse ausgeführt wird
    /// WICHTIG: Kein Rückgabewert
    /// </summary>
    public Person()
    {
        Console.WriteLine("Person erstellt");
		Zaehler++;
    }

    /// <summary>
    /// Der Konstruktor wird auch dafür verwendet, um Standardwerte zu empfangen
    /// </summary>
    public Person(string vorname, string nachname) : this()
    {
        this.vorname = vorname;
        this.nachname = nachname;
    }

    /// <summary>
    /// Konstruktoren verketten
    /// Mithilfe von this(...) können Konstruktoren verketten werden
    /// -> Wenn dieseer Konstruktor verwender wird, wird der nächste im Kettenglied auch verwendet
    /// 
    /// Vorteile:
    /// - Code wiederverwenden (kein Copy-Paste)
    /// - Wenn Code verändert wird, wird dieser in beiden Konstruktoren verändert
    /// </summary>
    public Person(string vorname, string nachname, int alter) : this(vorname, nachname) //Hier wird vorname und nachname nach oben weitergegeben
    {
        Alter = alter;
    }
    #endregion

	~Person()
	{
		Console.WriteLine("Person gelöscht");
	}

	public static int Zaehler { get; private set; }
}