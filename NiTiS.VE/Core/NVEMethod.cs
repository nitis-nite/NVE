using NiTiS.VE.Core.Exec;
using System;
using System.Diagnostics.CodeAnalysis;

namespace NiTiS.VE.Core;

public class NVEMethod : NVEMember, IEquatable<NVEMethod>
{
	private NVEType @out;
	private NVEType[] @in;
	private Execute exec;
	public NVEMethod(string name, Execute exec, NVEType outType, params NVEType[] argumetns) : base(name)
	{
		this.exec = exec;
		this.@out = outType;
		this.@in = argumetns;
	}
	public NVEInstance? Invoke(NVEInstance? instance, params NVEInstance[] arguments)
	{
		return exec.Invoke(instance, arguments);
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
