// The NiTiS-Dev licenses this file to you under the MIT license.
using NiTiS.VE.Core;
using NiTiS.VE.Core.Packages;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;
public static unsafe class NVE
{
	public static readonly string RunnerName = System.Environment.UserName;
	private static List<Package> packages = new();
	public static Type Void;
	private static readonly NiTiS.VE.Services.Version version = new(0, 0, 0, 3);
	private static lid llid = new(1), lplid = new(1);
	public static Package GetPackage(lid lid)
		=> packages[lid];
	public static void LoadPackage(Package package)
	{
		package.plid = lplid++;
		foreach (Type type in package.types)
		{
			type.plid = package.plid;
			type.lid = llid++;
			System.Console.WriteLine(type.lid);
		}

		System.Console.WriteLine(package.plid);
	}
	static NVE()
	{
		LoadPackage(
			new Package("NVE.CoreLib", version)
			{
				types = new Type[]
				{
					Void = new("NVE.Void", AccessP.Public, TypeP.None)
					{

					},
				}
			}
		);
	}
}
