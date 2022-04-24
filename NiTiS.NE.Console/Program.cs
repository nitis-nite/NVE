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
			NVEInstance typeInst2 = type.GetMethod("getType").Invoke(typeInst);
			nve.RunCode("NVE.Main::main", args);
		}
	}
}
