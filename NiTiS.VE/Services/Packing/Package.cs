using NiTiS.VE.Services.Runtime;

namespace NiTiS.VE.Services.Packing;

public class Package : IReferenceable<Package>
{
	private Reference<Package> reference = new();
	public Reference<Package> Reference => reference;
	protected string name;
	public Package(string name)
	{
		this.name = name;
	}
	public override string ToString()
		=> $"{name} 1.0.0.0";
}
