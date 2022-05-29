using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NiTiS.VE.Console;

public unsafe class Program
{
	public static void Main(string[] args)
	{
		Instance inst = new(null);

		int size = Marshal.SizeOf<Instance>();
		SC.WriteLine(size);
	}
}
