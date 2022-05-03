using NiTiS.VE;
using NiTiS.VE.Services.Packing;
using NiTiS.VE.Services.Runtime;
using NiTiS.VE.Services.Runtime.Exec;

namespace NiTiS.NE.Console;

internal class Program
{
	static void Main(string[] args)
	{
		NVE nve = new();

		Instance newObj = nve.CreateInstance(NVE.Byte);
		newObj.PrintLine();
		newObj.Add(1);
		newObj.PrintLine();
		newObj.Add(newObj);
		newObj.PrintLine();
		newObj.Add(newObj);
		newObj.PrintLine();
		newObj.Add(newObj);
		newObj.PrintLine();
		newObj.Add(newObj);
		newObj.PrintLine();
		newObj.Add(newObj);
		newObj.PrintLine();
		newObj.Add(newObj);
		newObj.PrintLine();
		newObj.Add(newObj);
		newObj.PrintLine();
		newObj.Add(newObj);
		newObj.PrintLine();
		newObj.Add(newObj);
		newObj.PrintLine();
	}
}
