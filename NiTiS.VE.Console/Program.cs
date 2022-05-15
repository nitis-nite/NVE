using NiTiS.IO;
using NiTiS.VE.Services.Packing;
using NiTiS.VE.Services.Runtime;

namespace NiTiS.VE.Console;

public unsafe class Program
{
	public static void Main(string[] args)
	{
		File file = new NiTiS.IO.File(@"B:\Desktop\package.nlib");
		Type type = new("NVE", "Abc");
		file.Delete();
		file.Create();

		Package.Builder pckBuilder = new Package.Builder("NVE");
		pckBuilder.WithVersion(new (0, 0, 0, 1));
		pckBuilder.Write(file);

		Package package = Package.Load(file);
		SC.WriteLine(package);
	}
}
