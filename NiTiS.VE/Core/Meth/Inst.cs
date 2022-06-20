// The NiTiS-Dev licenses this file to you under the MIT license.
using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core.Meth;
public struct Inst
{
	public Type @typeof;
	public Inst(Type type)
	{
		this.@typeof = type;
	}
	public void Initialize()
	{

	}
	public override string ToString()
		=> $"Instance of {@typeof}";
}
