using NiTiS.VE;
using System;
using System.Runtime.InteropServices;

namespace NiTiS.NE.Console
{
	public static unsafe class Program
	{
		static void Main(string[] args)
		{
			Scaner scaner = new(System.Console.In);
			while(true)
			{
				scaner.Scan();
			}
		}
	}
}
