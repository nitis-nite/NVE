global using SC = System.Console;
using System.Diagnostics;

public static class Hide
{
	public static void PrintLine(this object obj) 
		=> SC.WriteLine(obj?.ToString() ?? "null");
}