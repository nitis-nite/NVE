using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;
public unsafe class Instance
{
	public Type Type { get; }
	public Instance(Type type)
	{
		Type = type;
	}
}