using NiTiS.VE.Services.Packing;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NiTiS.VE.Console;


public unsafe class Program
{
	public static void Main(string[] args)
	{
		NVE nve = new(System.Environment.UserName);

		Package.Builder packageBuilder = new("NVE", new(0, 0, 0, 1));
		Reference<Package> reference = packageBuilder.Reference;

		Package pack = packageBuilder.Build();
		nve.LoadPackage(pack);
	}
}
