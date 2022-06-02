// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[StructLayout(LayoutKind.Sequential)]
public class Type : IReferencable<Type>, IEquatable<Type>, IEquatable<Reference<Type>>
{
	public readonly Mstr name;
	public readonly TypeMarks marks; 
	public Reference<Type> Reference { get; }
	public Reference<Package> Package { get; }
	private Type(Reference<Package> package, Reference<Type> typeref, string name, object? members, object? methods)
	{
		Reference = typeref;
		Package = package;
		this.name = new(name);
	}
	public bool Equals(Type? other)
		=> Reference.Equals(other);
	public bool Equals(Reference<Type> other)
		=> Reference.Equals(other);
	public static bool operator ==(Type? type, Type? other)
		=> type?.Reference.Equals(other) ?? false;
	public static bool operator !=(Type? type, Type? other)
		=> !(type?.Reference.Equals(other) ?? false);
	public static bool operator ==(Type? type, Reference<Type> other)
		=> type?.Reference.Equals(other) ?? false;
	public static bool operator !=(Type? type, Reference<Type> other)
		=> !(type?.Reference.Equals(other) ?? false);
	public override int GetHashCode()
		=> Reference.GetHashCode() + 214132;
	public override bool Equals(object? obj)
		=> obj is Type type ? Equals(type) : obj is Reference<Type> reference ? Equals(reference) : false;
	public class Builder
	{
		private TypeMarks marks;
		private string name;
		public readonly Reference<Type> typeRef = new();
		public readonly Package.Builder packageBuilder;
		public Builder(Package.Builder packageBuilder, string name, bool @internal)
		{
			this.name = name;
			this.packageBuilder = packageBuilder;
			this.marks = TypeMarks.Public | (@internal? TypeMarks.None : TypeMarks.OutAccess);
		}
		public Type Build()
		{
			Type type = new(packageBuilder.Reference, typeRef, name, null, null);
			packageBuilder.AppendType(type);
			return type;
		}
	}
}
