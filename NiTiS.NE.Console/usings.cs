global using SC = System.Console;
using System.Diagnostics;

public static class Hide
{
	public static void PrintLine(this object obj)
	{
		System.Console.WriteLine(obj?.ToString() ?? "null");
	}
}