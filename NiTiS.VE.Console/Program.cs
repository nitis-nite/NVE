using NiTiS.Collections.Generic;
using NiTiS.Reflection;
using NiTiS.VE.Core;
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
		MethodScope scope = new(32);



		Inst ret = scope.Run(NVE.Void,
			new VEECl(VEEC.InitVoid, LID32.Zero),
			new VEECl(VEEC.Load, LID32.Zero),
			new VEECl(VEEC.Return, LID32.Zero)
		);
		WriteLine(ret);
	}
	private static void WriteLine<T>(T obj)
	{
		System.Console.WriteLine(obj.ToString());
	}
}
