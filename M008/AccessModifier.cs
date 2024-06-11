namespace M008;

public class AccessModifier
{
	public string Name { get; set; } //Überall sichtbar, auch außerhalb vom Projekt

	internal int Alter { get; set; } //Überall sichtbar, aber nur innerhalb vom Projekt

	private string Adresse { get; set; } //Nur innerhalb der Klasse sichtbar

	/////////////////////////////////////////////////////////////////
	
	protected int Gehalt { get; set; } //Nur innerhalb der Klasse sichtbar (private), ABER auch in Unterklassen (auch außerhalb)

	protected private string Haarfarbe { get; set; } //Nur innerhalb der Klasse sichtbar (private), aber auch in Unterklassen NUR innerhalb des Projekts

	protected internal string Job { get; set; } //Überall sichtbar, aber nur innerhalb vom Projekt (internal), UND auch in Unterklassen außerhalb
}