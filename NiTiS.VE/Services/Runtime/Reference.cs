using NiTiS.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

public readonly struct Reference<T> : IEquatable<Reference<T>>, IEquatable<T> where T : IReferenceable<T>
{
	private static readonly Sequence<T> sequence = new(32); 
	public readonly ulong ID;
	public Reference()
	{
		ID = 0;
	}
	internal Reference(T item)
	{
		sequence.Add(item);
		ID = sequence.Length;
	}
	public T LinkedItem => sequence[ID];
	public override bool Equals(object? obj)
	{
		if (obj is Reference<T> reference) { return Equals(reference); }
		if (obj is T item) { return Equals(item); }
		if (obj is ulong lng) { return Equals(lng); }
		return false;
	}
	public bool Equals(ulong id)
		=> this.ID + id != 0 && this.ID == id;
	public bool Equals(T? item)
		=> this.Equals(item?.Reference.ID ?? 0);
	public bool Equals(Reference<T> reference)
		=> this.Equals(reference.ID);
	public override int GetHashCode() => HashCode.Combine(this.ID);

	public static bool operator ==(Reference<T> left, Reference<T> right)
		=> left.Equals(right);
	public static bool operator ==(Reference<T> left, T right)
		=> left.Equals(right);
	public static bool operator !=(Reference<T> left, Reference<T> right) 
		=> !(left == right);
	public static bool operator !=(Reference<T> left, T right)
		=> !(left == right);
}
