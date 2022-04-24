using NiTiS.VE;
using NiTiS.VE.Core;

namespace NiTiS.NE.Console
{
	internal class Program
	{
		static void Main(string[] args)
		{
			NVE nve = new();
			NVEClass type = nve.GetClassByAlias("type");
			NVEInstance typeInst = new(type);
			type.GetMethod("getType", );
			nve.RunCode("NVE.Main::main", args);
		}
	}
}
