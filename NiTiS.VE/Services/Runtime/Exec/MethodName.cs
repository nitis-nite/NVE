// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime.Exec;
public readonly struct MethodName
{
	public readonly Type returnType;
	public readonly Type[] arguments;
	public MethodName(Type returnType, params Type[] arguments)
	{
		this.returnType = returnType;
		this.arguments = arguments;
	}
}
