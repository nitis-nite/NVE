using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core;

public class NVEInstance
{
	private readonly NVEType @typeof;
	private readonly Dictionary<string, NVEInstance> localVariables = new();
	public NVEInstance(NVEType @typeof)
	{
		this.@typeof = @typeof;
	}

}
