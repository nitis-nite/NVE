using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;

public static class ObjectExtensions
{
	public static object GetVal(this object obj)
	{
		if (obj is Instance inst)
		{
			return inst.GetValue("val");
		}
		return obj;
	}
}
