using NiTiS.Collections.Generic;
using NiTiS.VE.Services.Packing;
using NiTiS.VE.Services.Runtime;
using NiTiS.VE.Services.Runtime.Exec;

namespace NiTiS.VE;

public partial class NVE
{
	private SmartDictonary<string, Type> typeCollection = new(type => type.FullName, 128);
	public static readonly Package Core;
	public NVE()
	{
		LoadPackage(Core);
	}
	/// <summary>
	/// Register <paramref name="type"/>
	/// </summary>
	/// <param name="type"></param>
	public void RegistryType(Type type)
	{
		typeCollection.Add(type);
	}
	/// <summary>
	/// Delete <paramref name="type"/> from registry
	/// </summary>
	/// <remarks>
	/// Not recommended (use only with annotation types)
	/// </remarks>
	/// <param name="type">Type for deletion</param>
	public void RestoreType(Type type)
	{
		typeCollection.Remove(type);
	}
	public Instance CreateInstance(Class type)
		=> new Instance(type);
	public void LoadPackage(Package package)
	{
		System.Console.WriteLine("Package loaded: " + package);
	}
	public static Class Object, Byte;
	static NVE()
	{
		Core = new("NVE.Core");
		Class.Builder objBuilder = new("NVE", "Object");
		objBuilder.FromPackage(Core);
		Object = objBuilder.Build();

		Class.Builder byteBuilder = new("NVE", "Byte");
		byteBuilder.FromPackage(Core);
		byteBuilder.Depend(Object);
		Byte = byteBuilder.Build();
	}
}