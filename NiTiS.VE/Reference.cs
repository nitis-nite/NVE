// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NiTiS.VE;
public struct Reference<T> : IEquatable<Reference<T>>, IEquatable<T> where T : IReferencable<T>
{
	private static uint size = 0;
	private uint id;
	public Reference()
	{
		this.id = size++;
	}
	public bool Equals(Reference<T> other)
		=> other.id == this.id;
	public bool Equals(T? other)
		=> other is not null ? Equals(other.Reference) : false;
	public override int GetHashCode() 
		=> HashCode.Combine(this.id);
	public override bool Equals(object? obj)
		=> obj is Reference<T> refer ? Equals(refer) : obj is T item ? Equals(item) : false;
	public override string ToString()
		=> $"{{{typeof(T).Name}, ({id})}}";

	public static bool operator ==(Reference<T> left, Reference<T> right)
		=> left.Equals(right);
	public static bool operator !=(Reference<T> left, Reference<T> right)
		=> left.Equals(right);
	public static bool operator ==(Reference<T> left, T right)
		=> left.Equals(right);
	public static bool operator !=(Reference<T> left, T right)
		=> left.Equals(right);
	public static bool Equals(IReferencable<T> left, IReferencable<T> right)
		=> left.Reference == right.Reference;
}
public interface IReferencable<T> where T : IReferencable<T>
{
	public Reference<T> Reference { get; }
}