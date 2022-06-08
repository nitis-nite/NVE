using NiTiS.Collections.Generic;
using NiTiS.VE.Services;
using NiTiS.VE.Services.Build;
using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using static System.Console;


namespace NiTiS.VE.Console;


public unsafe class Program
{
	public static void Main(string[] args)
	{
		NVE nve = new(System.Environment.UserName);
		nve.GetTypeByLID(LID32.Zero);
	}
}
