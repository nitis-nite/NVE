using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE;

public class Instance
{
	private Dictionary<string, object> vars = new();
	public NVEType Type { get; }
	public Instance(NVEType type)
	{
		Type = type;
		foreach(Collections.Generic.Twosome<string, NVEType> i in Type.GetVars())
		{
			if (IsValueInitialized(i.Left)) continue;
			SetValue(i.Left, i.Right);
		}
	}
	public Instance SetValue(string varName, object value)
	{
		this.vars[varName] = value;
		return this;
	}
	public object GetValue(string varName) => this.vars[varName];
	public bool IsValueInitialized(string varName) => this.vars.ContainsKey(varName);
	public Instance ExecMethod(string name)
	{
		return Type.GetMethod(name).Method.Invoke(this);
	}
	public override string ToString()
	{
		return $"{Type?.Name ?? "???"}";
	}
}
