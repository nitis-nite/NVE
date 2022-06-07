using NiTiS.VE.Services.Build;
using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace NiTiS.VE.Console;


public unsafe class Program
{
	public static void Main(string[] args)
	{
		NVE nve = new(System.Environment.UserName);
		Package.Builder packageBuilder = new("NVE", new("~"));

		Type.Builder objectBuilder = new Type.Builder("NVE.Object");
		Type.Builder voidBuilder = new Type.Builder("NVE.Void");

		Type @object = objectBuilder.Build();
		Type @void = voidBuilder.Build();

		packageBuilder.AddType(@object);
		packageBuilder.AddType(@void);

		Package nvePackage = packageBuilder.Build();
		nve.LoadPackage(nvePackage);
	}
}
