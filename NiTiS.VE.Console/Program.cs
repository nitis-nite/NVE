using NiTiS.VE.Services.Packing;
using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NiTiS.VE.Console;


public unsafe class Program
{
	public static void Main(string[] args)
	{
		NVE nve = new(System.Environment.UserName);

		Package.Builder packageBuilder = new("NVE", new(0, 0, 0, 1));

		Type.Builder objectBuilder = new(packageBuilder, "NVE.Object", false);

		Type @object = objectBuilder.Build();

		Package pack = packageBuilder.Build();
		nve.LoadPackage(pack);
		foreach (Package package in nve.GetPackages())
		{

			SC.WriteLine("Package: {0}", package.name);
			foreach (Type type in pack.GetTypes())
			{
				SC.WriteLine("Type: {0}", type.name);
			}
		}
	}
}
