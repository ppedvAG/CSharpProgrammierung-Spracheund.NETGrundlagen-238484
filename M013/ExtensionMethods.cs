namespace M013;

public static class ExtensionMethods
{
	public static int Quersumme(this int x)
	{
		//int summe = 0;
		//string zahlAlsString = x.ToString();
		//for (int i = 0; i < zahlAlsString.Length; i++)
		//{
		//	summe += (int) char.GetNumericValue(zahlAlsString[i]);
		//}
		//return summe;

		//Mit Linq eine Zeile daraus machen
		return x.ToString().Sum(e => (int) char.GetNumericValue(e));
	}

	public static IEnumerable<T> In<T, T2>(this IEnumerable<T> x, Func<T, T2> toSearch, IEnumerable<T2> toFind)
	{
		return x.Where(e => toFind.Contains(toSearch(e)));
	}
}