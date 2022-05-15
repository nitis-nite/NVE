using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public partial class Type : IEquatable<Type?>, IEquatable<Reference<Type>>, IReferenceable<Type>
{
	private string name, space;
	private string Name => name;
	private string FullName => space.Length > 0 ? space + "." + name : name;
	public Reference<Type> Reference { get; }
	public Type(string space, string name)
	{
		this.space = space;
		this.name = name;
		Reference = new Reference<Type>(this);
#if DEBUG
		Console.WriteLine("Reg new type {0} by id ({1})", FullName, Reference.ID);
#endif
	}
	public override bool Equals(object? obj)
	{
		if (obj is Type type) { return Equals(type); }
		if (obj is Reference<Type> reference) { return Equals(reference); }
		return false;
	}
	public override int GetHashCode() => Reference.GetHashCode();
	public override string ToString() => $"{FullName} {Reference.ID}";
	private string GetDebuggerDisplay() => $"{FullName} {Reference.ID}";
	public bool Equals(Type? other)
		=> this.Reference == other?.Reference;
	public bool Equals(Reference<Type> reference)
		=> this.Reference == reference;

	public static bool operator ==(Type? left, Type? right)
		=> left?.Equals(right) ?? false;
	public static bool operator ==(Type? left, Reference<Type> right)
		=> left?.Equals(right) ?? false;

	public static bool operator !=(Type? left, Type? right)
		=> !(left == right);
	public static bool operator !=(Type? left, Reference<Type> right)
		=> !(left == right);
}
