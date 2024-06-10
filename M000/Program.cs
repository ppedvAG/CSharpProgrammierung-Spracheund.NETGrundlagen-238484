Console.Write("Meter pro Sekunde: ");
int meter = int.Parse(Console.ReadLine());
Console.Write("Stunden: ");
int std = int.Parse(Console.ReadLine());
Console.Write("Minuten: ");
int min = int.Parse(Console.ReadLine());
Console.Write("Sekunden: ");
int sek = int.Parse(Console.ReadLine());

double gesamtzeit = sek + (min * 60) + (std * 3600.0);
double gesamtStd = gesamtzeit / 3600d;

Console.WriteLine($"Meter/Sekunde:\t  {Math.Round(meter / gesamtzeit, 2)}");
Console.WriteLine($"Kilometer/Stunde: {Math.Round(meter / 1000d / gesamtStd, 2)}");
Console.WriteLine($"Meilen/Stunde:\t  {Math.Round(meter / 1000d * 0.62137119 / gesamtStd, 2)}");