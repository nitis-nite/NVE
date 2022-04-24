using System;

namespace NiTiS.VE.Core;

public class NVEMemberAlocation : NVEType
{
	private readonly string alias;
	public NVEMemberAlocation(PackageReference reference, string name) : base(reference, name)
	{
		this.alias = String.Empty;
	}
	public NVEMemberAlocation(PackageReference reference, string name, string? alias) : base(reference, name)
	{
		this.alias = !String.IsNullOrWhiteSpace(alias) ? alias : String.Empty;
	}

	public bool HasAlias => !String.IsNullOrWhiteSpace(alias);
	public string Alias => alias;
}
