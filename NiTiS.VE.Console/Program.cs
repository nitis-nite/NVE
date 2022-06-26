using NiTiS.Collections.Generic;
using NiTiS.Reflection;
using NiTiS.VE.Core;
using NiTiS.VE.Core.Emit;
using NiTiS.VE.Core.Meth;
using NiTiS.VE.Services;
using NiTiS.VE.Services.Build;
using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace NiTiS.VE.Console;


public unsafe class Program
{
	public static void Main(string[] args)
	{
		PackageBuilder package = new(PackageBuildStatus.Compile)
		{
			Name = "nvecorelib",
			DisplayName = "NVE.Core"
		};

		TypeBuilder voidType = package.DefineTypeBuilder();
		voidType.Name = "NVE.Void";

		TypeBuilder none = package.DefineTypeBuilder();
		none.Name = "NVE.None";

		MethodBuilder method = none.DefineMethodBuilder();
		method.ReturnType(voidType);
	}
	private static void WriteLine<T>(T obj)
	{
		System.Console.WriteLine(obj.ToString());
	}
}
