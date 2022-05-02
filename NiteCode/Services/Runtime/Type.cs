using NiTiS.VE.Services.Runtime;

namespace NiteCode.Services.Runtime;

public class Type : IVEType, IReferenceable<Type>
{
	protected Reference<Type> reference = new();
	protected Reference<Package> packageReference;
	public Reference<Type> Reference => reference;
	public Reference<Package> PackageReference => packageReference;
	private string @namespace, name;
	public bool HasNamespace => @namespace.Length != 0;
	public string Name => name;
	public string FullName => HasNamespace ? @namespace + "." + name : name;


	protected Type(string @namespace, string name, Reference<Package> package)
	{
		this.@namespace = @namespace!;
		this.name = name!;
		this.packageReference = package;
	}
}
