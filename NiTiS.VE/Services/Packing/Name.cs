using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Packing;
public struct Name : IPackable
{
	private readonly string space, name;
	public Name(string space, string name)
	{
		this.space = space;
		this.name = name;
	}
	public byte[] GetBytes()
	{
		Writer writer = new Writer();
		writer.TextBig(space);
		writer.TextM256(name);
		return writer.GetBytes();
	}
}
