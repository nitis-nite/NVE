using NiTiS.VE;

namespace NiTiS.NE.Console
{
	internal class Program
	{
		static void Main(string[] args)
		{
			NVE nve = new();
			nve.RunCode("NVE.Main::main", args);
		}
	}
}
