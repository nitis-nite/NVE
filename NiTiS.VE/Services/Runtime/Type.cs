// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[StructLayout(LayoutKind.Sequential)]
public class Type : IReferencable<Type>
{
	public Reference<Type> Reference { get; }
	public Reference<Package> Package { get; }
	public class Builder
	{
		public Reference<Type> Reference { get; } = new();
		public Reference<Package> Package { get; }
		private TypeName name;
		private readonly Sequence<object> methods = new(16);
		public Builder(Reference<Package> package, TypeName name)
		{
			Package = package;

		}
		public Builder Method(object method)
		{
			return this;
		}
	}
}
[StructLayout(LayoutKind.Sequential)]
public readonly struct TypeName
{
	public readonly Mstr space, name;
	public TypeName(string space, string name)
	{
		this.space = new(space);
		this.name = new(name);
	}
	public TypeName(Mstr space, Mstr name)
	{
		this.space = space;
		this.name = name;
	}
}