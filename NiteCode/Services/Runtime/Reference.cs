using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace NiteCode.Services.Runtime;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
public sealed class Reference<T> : IEquatable<Reference<T>>, IEquatable<T> where T : IReferenceable<T>
{
	private static ulong maxID = 0;
	private ulong id = maxID++;
	public ulong LongID => this.id;
	public Reference() { }
	public bool Equals(T? other)
		=> other?.Reference.id == this.id;
	public bool Equals(Reference<T>? other)
		=> other?.id == this.id;
	public override bool Equals(object? obj)
		=> obj is T it ? Equals(it) : obj is Reference<T> rf ? Equals(rf) : false;
	public override int GetHashCode() => HashCode.Combine(this.id);

	public static bool operator ==(Reference<T>? left, Reference<T>? right)
		=> left?.Equals(right) ?? false;

	public static bool operator !=(Reference<T>? left, Reference<T>? right)
		=> !(left == right);

	public override string ToString() => $"Reference<{typeof(T).Name}> ({this.id})";
}