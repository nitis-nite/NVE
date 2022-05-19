using NiTiS.IO;
using NiTiS.VE.Services.Packing;
using NiTiS.VE.Services.Runtime;
using NiTiS.VE.Services.Runtime.MM;
using System;
using NiTiS.Collections.Pseudo;
using System.Threading.Tasks;
using static NiTiS.VE.Services.Runtime.MM.NMem;

namespace NiTiS.VE.Console;

public unsafe class Program
{
	public static void Main(string[] args)
	{
		byte* ptr = _alloc32B();

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
}
