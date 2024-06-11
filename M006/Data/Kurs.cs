namespace M006.Data;

/// <summary>
/// Kurs Klasse:
/// Felder:
///		- Titel
///		- Trainer (Person)
///		- Teilnehmer (Person[])
///		- Dauer
/// Funktionen:
///		- TeilnehmerHinzufügen
///		- TeilnehmerAuflisten
/// Konstruktor:
///		- Titel, Trainer, Dauer, beliebig viele Teilnehmer empfangen
/// </summary>
public class Kurs
{
    public string Titel { get; set; }

    public Person Trainer { get; set; }

    public Person[] Teilnehmer { get; private set; }

    public int DauerInTagen { get; set; }

    public Kurs(string titel, Person trainer, int dauer, params Person[] teilnehmer)
    {
        Titel = titel;
        Trainer = trainer;
        DauerInTagen = dauer;
        Teilnehmer = teilnehmer;
    }

    public void TeilnehmerHinzufuegen(Person p)
    {
        //Array kopieren und ein weiteres Element hinzufügen
        Teilnehmer = Teilnehmer.Append(p).ToArray();
    }

    public void KursAuflisten()
    {
        Console.WriteLine($"Trainer: {Trainer.VollerName} ({Trainer.Alter}), {Trainer.Geschlecht}");
        foreach (Person p in Teilnehmer)
        {
            Console.WriteLine($"Teilnehmer: {p.VollerName} ({p.Alter}), {p.Geschlecht}");
        }
    }
}