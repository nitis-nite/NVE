using NiTiS.Collections;
using NiTiS.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NiTiS.VE;

public class NVEType
{
	public string Name { get; }
	private Dictionary<string, NVEMethod> internalMethods = new();
	private Dictionary<string, NVEType> internalVars = new();
	public IEnumerable<NVEMethod> Methods => GetMethods();
	public IEnumerable<Twosome<string, NVEType>> Vars => GetVars();
	public NVEType Parent = NVEType.Null;
	public NVEType(string name)
	{
		Name = name;
	}
	public NVEType(string name, NVEType parent)
	{
		Name = name;
		Parent = parent;
	}

	public void AddField(string name, NVEType type) => internalVars[name] = type;
	public void AddMethod(string name, NVEMethod method) => internalMethods[name] = method;
	public NVEMethod GetMethod(string name)
	{
		NVEType _cl = this;
		while (_cl != Null)
		{
			if (_cl.internalMethods.TryGetValue(name, out NVEMethod value))
			{
				return value;
			}
			_cl = _cl.Parent;
		}
		throw new Exception("Method not found");
	}
	public IEnumerable<NVEMethod> GetMethods()
	{
		if (this == Null) return Array.Empty<NVEMethod>();
		else
		{
			return this.internalMethods.Select(s => s.Value).AppendRange(this.Parent.GetMethods());
		}
	}
	public NVEType GetVar(string name)
	{
		NVEType _cl = this;
		while (_cl != Null)
		{
			if (_cl.internalVars.TryGetValue(name, out NVEType value))
			{
				return value;
			}
			_cl = _cl.Parent;
		}
		throw new Exception("Variable not found");
	}
	public IEnumerable<Twosome<string, NVEType>> GetVars()
	{
		if (this == Null) return Array.Empty<Twosome<string, NVEType>>();
		return this.internalVars.Select(s => new Twosome<string, NVEType>(s.Key, s.Value)).AppendRange(this.Parent.GetVars());
	}
	public override string ToString() => Name;

	public static NVEType Null, Object, Type;
	public static NVEType Ret;
	public static NVEType Int8, Int16, Int32, Int64;
	public static NVEType String;
	static NVEType()
	{
		Null = new("NVE.Null");
		Object = new("NVE.Object");
		Type = new("NVE.Type", Object);
		Type.AddField("_typeref", Object);

		Ret = new("NVE.Ret", Object);
		Ret.AddField("val", NVEType.Object);
		Ret.AddMethod("toString", new(s => new Instance(String).SetValue("val", s.GetVal().ToString()), String));

		String = new("NVE.String", Ret);

		Object.AddMethod("getType", new(s => new Instance(Type).SetValue("_typeref", s.Type), Type));
		Object.AddMethod("toString", new(s => new Instance(String).SetValue("val", s.Type.ToString()), String));

		//Numerics
		Int8 = new("NVE.Int8", Ret);
		Int16 = new("NVE.Int16", Ret);
		Int32 = new("NVE.Int32", Ret);
		Int64 = new("NVE.Int64", Ret);
	}
}
