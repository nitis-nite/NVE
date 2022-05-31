// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Packing;
public class Package : IReferencable<Package>
{
	//TODO: Alloc this to other struct maybe
	public readonly string name;
	public readonly Version version;
	public Reference<Package> Reference { get; }
	public readonly Type[] types;
	public Package(string name, Version version, Type[] types) : this(new(), name, version, types)
	{
	}
	private Package(Reference<Package> fromBuilder, string name, Version version, Type[] types)
	{
		Reference = fromBuilder;
		this.name = name;
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
