using NiTiS.IO;
using NiTiS.VE.Services.Packing;
using NiTiS.VE.Services.Runtime;
using NiTiS.VE.Services.Runtime.MM;
using System;
using NiTiS.Collections.Pseudo;
using System.Threading.Tasks;
using static NiTiS.VE.Services.Runtime.MM.MemoryGentleman;

namespace NiTiS.VE.Console;

public unsafe class Program
{
	public static void Main(string[] args)
	{
		MemoryBar bar = BarAllocate(1);

		GC.GetTotalAllocatedBytes().PrintLine();
		Fu();
		GC.Collect();
		GC.GetTotalAllocatedBytes().PrintLine();

		//File file = new NiTiS.IO.File(@"B:\Desktop\package.nlib");
		//Type type = new("NVE", "Abc");
		//file.Delete();
		//file.Create();

		//Package.Builder pckBuilder = new Package.Builder("NVE");
		//pckBuilder.WithVersion(new (0, 0, 0, 1));
		//pckBuilder.Write(file);

		//Package package = Package.Load(file);
		//SC.WriteLine(package);
	}

	private static void Fu()
	{
		foreach (int i in new RangeInt(0, 2048))
		{
			MemoryBar bar1 = BarAllocate(2048 * 1000);
			BarDispose(bar1);
		}
	}
}
