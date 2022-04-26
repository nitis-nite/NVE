using NiTiS.VE;
using NiTiS.VE.Core;
using NiTiS.VE.Core.Runtime;

namespace NiTiS.NE.Console
{
	internal class Program
	{
		static void Main(string[] args)
		{
			NVE nve = new();
			NVEClass type = nve.GetClassByAlias("type");
			NVEInstance typeInst = type.CreateInstance();
			nve.RunCode("NVE.Main::main", args);
		}
	}
}
