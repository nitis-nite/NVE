// The NiTiS-Dev licenses this file to you under the MIT license.

using System.Diagnostics;

namespace NiTiS.VE.Core;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
public class Type
{
	public const string MethodSpliterator = "::";
	public const string GenericSpliterator = "`";

	public string Name { get; set; }
	internal lid lid, plid;
	public lid LID => lid;
	public lid PLID => plid;
	public static Type Void { get; } = new("NVE.Void", Marks.None, Specification.Structure);
	public static Type Byte { get; } = new("NVE.Int8", Marks.ByteAlloc, Specification.Structure);
	public readonly Type[] dependents;
	public readonly Field[] fields;
	public readonly Specification specification;
	public readonly Marks marks;
	public uint Stride()
	{
		if (lid.Pointless) return 0;
		if (marks.HasFlag(Marks.ByteAlloc))
		{
			return 1;
		}
		else return 2;
	}
	private Type(string name, Marks marks, Specification specification, params Type[] dependents) : this(name, marks, specification, System.Array.Empty<Field>(), dependents) { }
	private Type(string name, Marks marks, Specification specification, Field[] fields, params Type[] dependents)
	{
		Name = name;
		this.dependents = dependents;
		this.fields = fields;
		this.specification = specification;
		this.marks = marks;
	}
	public RuntimeInstance Initialize()
	{
		return new(this, 0, 0);
	}
	public override string ToString() 
		=> $"{Name} [LID:{lid}] [PLID:{plid}]";
	public class Member
	{
		public string Name { get; }
		public Member(string name)
		{
			this.Name = name;
		}
	}
	public class Field : Member
	{
		public Type FieldType { get; set; }
		public Field(string name, Type type) : base(name)
		{
			FieldType = type;
		}
	}
	public enum Specification : byte
	{
		/// <summary>
		/// Empty type
		/// </summary>
		Blank = 0,
		/// <summary>
		/// Basic type specification
		/// </summary>
		Structure = 1,
		/// <summary>
		/// Interface 
		/// </summary>
		Interface = 2,
		/// <summary>
		/// Can use in type header
		/// </summary>
		Attribute = 3,
		/// <summary>
		/// Can usage with throw
		/// </summary>
		Exception = 4,
	}
	[System.Flags]
	public enum Marks : short
	{
		None = 0,
		Generic = 1,
		ByteAlloc = 2,
	}
}
