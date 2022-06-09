// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core;
public class NetMethod : Method
{
	private readonly Func<RuntimeInstance, RuntimeInstance[], RuntimeInstance> method;
	public NetMethod(Func<RuntimeInstance, RuntimeInstance[], RuntimeInstance> method, Type returnType, params Type[] argumentType) : base(returnType, argumentType)
	{
		this.method = method;
	}
	public override bool IsExternal => true;
	public override RuntimeInstance Run(RuntimeInstance instance, params RuntimeInstance[] arguments)
		=> method(instance, arguments);
}
