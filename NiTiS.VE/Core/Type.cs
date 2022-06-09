// The NiTiS-Dev licenses this file to you under the MIT license.

using System.Diagnostics;

namespace NiTiS.VE.Core;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
public class Type
{
	public const string MethodSpliterator = "::";
	public const string GenericSpliterator = "`";
	public static readonly Type[] EmptyTypes = System.Array.Empty<Type>();
	public string Name { get; set; }
	internal lid lid, plid;
	public lid LID => lid;
	public lid PLID => plid;
	public static Type Void { get; } = new("NVE.Void", Marks.None, Specification.Structure);
	public static Type Byte { get; } = new("NVE._bt", Marks.ByteAlloc, Specification.Structure, new MethodField[]
	{
		new("new", new NetMethod( (inst, args) =>
		{
			return Byte!.Initialize();
		}, Byte))
	})
	{
		plid = lid.Zero,
		lid = new(1),
	};
	public readonly Type[] dependents;
	public readonly Field[] fields;
	public readonly Specification specification;
	public readonly Marks marks;
	public readonly MethodField[] methods;
	public MethodField? this[string name, Type ret, Type[] args]
		=> methods.Where(s => s.Name == name && s.Method.ReturnType == ret && s.Method.ArgumentType == args).FirstOrDefault();
	public uint Stride()
	{
		if (lid.Pointless) return 0;
		if (marks.HasFlag(Marks.ByteAlloc))
		{
			return 1;
		}
		else return 2;
	}
	private Type(string name, Marks marks, Specification specification, params Type[] dependents) : this(name, marks, specification, System.Array.Empty<MethodField>(), System.Array.Empty<Field>(), dependents) { }
	private Type(string name, Marks marks, Specification specification, MethodField[] methodFields, params Type[] dependents) : this(name, marks, specification, methodFields, System.Array.Empty<Field>(), dependents) { }
	private Type(string name, Marks marks, Specification specification, Field[] fields, params Type[] dependents) : this(name, marks, specification, System.Array.Empty<MethodField>(), fields, dependents) { }
	private Type(string name, Marks marks, Specification specification, MethodField[] methodFields, Field[] fields, params Type[] dependents)
	{
		Name = name;
		this.dependents = dependents;
		this.fields = fields;
		this.specification = specification;
		this.marks = marks;
		this.methods = methodFields;

		if (marks.HasFlag(Marks.ByteAlloc) && dependents.Length > 0)
			throw new InvalidCreateTypeException("Type with ByteAlloc mark can't have any dependents");
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
		public Type FieldType { get; }
		public Field(string name, Type type) : base(name)
		{
			FieldType = type;
		}
	}
	public class MethodField : Member
	{
		public Method Method { get; }
		public MethodField(string name, Method method) : base(name)
		{
			Method = method;
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
