using NiTiS.Additions;
using System;
using System.Linq;

namespace NiTiS.VE.Core;

public class NVEType
{
	public static readonly NVEType RELEATIVE_TYPE = new(new(0), "!ReleativeType");
	private readonly PackageReference reference;
	private readonly string name;
	public NVEType(PackageReference package, string name)
	{
		this.reference = package;
		this.name = name;
	}
	public PackageReference Reference => reference;
	public string Name => name.IndexOf('.') == -1 ? name : name.Split('.').Last();
	public string FullName => name;
	public string Namespace => name.IndexOf('.') == -1 ? "" : Strings.FromArray(name.Split('.').SkipLast(1), String.Empty, String.Empty, ".");
}
