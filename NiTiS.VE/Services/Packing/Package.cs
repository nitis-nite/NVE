// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NiTiS.VE.Services.Packing;
public class Package : IReferencable<Package>, System.IEquatable<Package>, System.IEquatable<Reference<Package>>
{
	public readonly Mstr name;
	public readonly Version version;
	public Reference<Package> Reference { get; }
	public readonly Type[] types;
	public IEnumerable<Type> GetTypes()
		=> types;
	public bool Equals(Package? other)
		=> Reference.Equals(other);
	public bool Equals(Reference<Package> other)
		=> Reference.Equals(other);
	public static bool operator ==(Package pack, Package other)
		=> pack?.Equals(other) ?? false;
	public static bool operator !=(Package pack, Package other)
		=> !(pack?.Equals(other) ?? false);
	public static bool operator ==(Package pack, Reference<Package> other)
		=> pack?.Equals(other) ?? false;
	public static bool operator !=(Package pack, Reference<Package> other)
		=> !(pack?.Equals(other) ?? false);
	public override int GetHashCode() 
		=> Reference.GetHashCode();
	public override bool Equals(object? obj) 
		=> obj is Package pack ? Equals(pack) : obj is Reference<Package> other ? Equals(other) : false;
	public Package(string name, Version version, Type[] types) : this(new(), name, version, types)
	{
	}
	private Package(Reference<Package> fromBuilder, string name, Version version, Type[] types)
	{
		Reference = fromBuilder;
		this.name = new(name);
		this.version = version;
		this.types = types;
	}
	public class Builder
	{
		public Reference<Package> Reference { get; }
		private readonly string name;
		private readonly Version version;
		private readonly Sequence<Type> types;
		public Builder(string name, Version version)
		{
			this.types = new(16);
			this.name = name;
			this.version = version;
			Reference = new();
		}
		public Builder AppendType(Type type)
		{
			types.Add(type);
			return this;
		}
		public Package Build()
			=> new(Reference, name, version, types.ToArray());
	}
}
