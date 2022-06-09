// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core;
public abstract class Method
{
	public readonly Type ReturnType;
	public readonly Type[] ArgumentType;
	internal lid lid;
	public lid LID => lid;
	public Method(Type returnType, params Type[] argumentType)
	{
		this.ReturnType = returnType;
		this.ArgumentType = argumentType;
	}
	public virtual bool IsExternal { get; }
	public abstract RuntimeInstance Run(NVE nve, RuntimeInstance instance, params RuntimeInstance[] arguments);
	static Method()
	{
	}
}
