using NiTiS.VE.Services.Packing;
using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NiTiS.VE.Console;


public unsafe class Program
{
	public static void Main(string[] args)
	{
		Name typeName = new("NVE", "Void");
		Type.Builder builder = new(typeName);
		Type @void = builder.Build();
		Instance @null = new(null);

		@null.Initialize();

		@null.Invoke();

		SC.WriteLine(@void);
	}
}
