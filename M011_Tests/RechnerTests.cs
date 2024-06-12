using M011;

namespace M011_Tests;

/// <summary>
/// UnitTests
/// Tests, welche regelmäßig ausgeführt werden, um das Projekt kontinuierlich auf Fehler zu prüfen
/// Werden täglich oder wöchentlich ausgeführt, um schnell Fehler zu erkennen und zu beheben
/// 
/// Rechtsklick auf Dependencies -> Add Project Reference -> Projekt auswählen
/// 
/// View -> Test Explorer
/// </summary>
[TestClass]
public class RechnerTests
{
	Rechner r;

	[TestInitialize]
	public void Setup() => r = new Rechner();

	[TestCleanup]
	public void Cleanup() => r = null;

	[TestMethod]
	[TestCategory("Addition")]
	public void TesteAddiere()
	{
		double ergebnis = r.Addiere(3, 4);

		//Die Assert Klasse
		//Das Ergebnis verifizieren
		Assert.AreEqual(7, ergebnis);
	}

	[TestMethod]
	[TestCategory("Subtraktion")]
	public void TesteSubtrahiere()
	{
		double ergebnis = r.Subtrahiere(8, 3);

		//Die Assert Klasse
		//Das Ergebnis verifizieren
		Assert.AreEqual(5, ergebnis);
	}
}