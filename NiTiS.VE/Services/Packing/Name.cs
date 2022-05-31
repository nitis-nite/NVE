using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Packing;
public unsafe struct Name : IPackable
{
	private readonly Mstr* space, name;
	public Name(string space, string name)
	{
		fixed (char * ptr = space)
		{
			Mstr mstr = new(ptr, (uint)space.Length);
			this.space = &mstr;
		}
		fixed (char* ptr = name)
		{
			Mstr mstr = new(ptr, (uint)space.Length);
			this.name = &mstr;
		}
	}
	public Name(Mstr* space, Mstr* name)
	{
		this.space = space;
		this.name = name;
	}
	public string FullName => space->ToString() + "." + name->ToString();
	public string ShortName => name->ToString();
	public byte[] GetBytes()
	{
		Writer writer = new Writer();
		writer.TextBig(space->ToString());
		writer.TextM256(name->ToString());
		return writer.GetBytes();
	}
	public override string ToString()
		=> FullName;
}
