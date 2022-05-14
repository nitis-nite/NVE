using NiTiS.VE;
using NiTiS.VE.Services;
using NiTiS.VE.Services.Packing;
using NiTiS.VE.Services.Runtime;
using NiTiS.VE.Services.Runtime.MM;
using System.Reflection.Emit;

namespace NiTiS.NE.Console;

public unsafe class Program
{
	public static void Main(string[] args)
	{
		Type type = new("NVE", "Abc");

		Package.Builder pckBuilder = new Package.Builder("NVE");
		pckBuilder.WithVersion(new (0, 0, 0, 1));
	}
}
