using NiTiS.Collections.Generic;
using NiTiS.VE.Core;
using NiTiS.VE.Libs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NiTiS.VE;

public class NVE
{
	private readonly SmartDictonary<PackageReference, Package> packages = new( (pck) => pck.Reference );
	private readonly Dictionary<string, NVEClass> aliases = new();
	public Task LoadPackage(Package package)
	{
		packages.Add(package);
		foreach(NVEClass nveClass in package.Classes)
		{
			if (nveClass.HasAlias && !aliases.ContainsKey(nveClass.Alias))
			{
				aliases.Add(nveClass.Alias, nveClass);
			}
		}
		Console.Write("Package loaded: " + package);
		return Task.CompletedTask;
	}
	public Package GetPackageByRef(PackageReference reference)
	{
		return packages[reference];
	}
	public void RunCode(string codePath, params string[] arguments)
	{
		try
		{
			string[] classAndMethod = codePath.Split("::");
			string classFullName = classAndMethod[0];
			string methodName = classAndMethod[1];
			//GetClass(classFullName).GetMethod(methodName, MethodFlag.Static);
		} catch(System.IndexOutOfRangeException)
		{
			throw new System.Exception("Invalid code path");
		}
	}
	public NVEClass? GetClassByAlias(string aliasName)
	{
		return aliases[aliasName];
	}
	public NVEClass? GetClass(string fullName)
	{
		foreach(Package package in packages.Values)
		{
			foreach(NVEClass nveclass in package.Classes)
			{
				if (nveclass.FullName == fullName) return nveclass;
			} 
		}
		return null;
	} 
	public NVE()
	{
		NVEStandartLib.Load(this);
	}
}
