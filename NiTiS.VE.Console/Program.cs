using NiTiS.VE.Services.Packing;
using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NiTiS.VE.Console;


public unsafe class Program
{
	public static void Main(string[] args)
	{
		Name typeNameVoid = new("NVE", "Void");
		Name typeNameObject = new("NVE", "Object");

		Type.Builder builderVoid = Type.ValueClass(typeNameVoid);
		Type.Builder builderObject = Type.Class(typeNameObject);

		Type @void = builderVoid.Build();
		Type @object = builderObject.Build();

		Instance @null = new(null);
		Instance obj = new(@object);

		@null.Initialize();
		obj.Initialize();

		SC.WriteLine(@null.Size());
		SC.WriteLine(obj.Size());

		obj.Dispose();

		SC.WriteLine(obj.Size());
	}
}
