using System;
using System.Diagnostics.CodeAnalysis;

namespace NiTiS.VE.Core;

public class NVEMethod : NVEMember, IEquatable<NVEMethod>
{
	private NVEType @out;
	private NVEType[] @in;
	public NVEMethod(string name, NVEType outType, params NVEType[] argumetns) : base(name)
	{
		this.@out = outType;
		this.@in = argumetns;
	}
	public NVEType OutParameter => @out;
	public NVEType[] Arguments => @in;
	public static bool operator ==(NVEMethod tzis, NVEMethod? other) => tzis.Equals(other);
	public static bool operator !=(NVEMethod tzis, NVEMethod? other) => !tzis.Equals(other);

	public bool Equals([AllowNull] NVEMethod other)
	{
		if (other is null) return false;
		return (@out, @in, Name) == (other.@out, other.@in, other.Name);
	}
	public override bool Equals([AllowNull] object other)
	{
		if (other is NVEMethod method) return Equals(method);
		return false;
	}

	public override int GetHashCode() => HashCode.Combine(Name, this.@out, this.@in);
}
