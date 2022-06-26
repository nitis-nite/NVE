// The NiTiS-Dev licenses this file to you under the MIT license.

using System;

namespace NiTiS.VE.Core.Emit;

public class MethodBuilder
{
	private readonly PackageBuilder package;
	private readonly TypeBuilder type;
	private bool isStatic, generic;
	private TypeBuilder? returnType;
	private TypeBuilder[]? paramTypes;

	public string Name { get; set; } = String.Empty;
	public MethodBuilder(PackageBuilder package, TypeBuilder type)
	{
		this.package = package;
		this.type = type;
	}
	public MethodBuilder ParamTypes(params TypeBuilder[] argTypes)
	{
		this.paramTypes = argTypes;
		return this;
	}
	public MethodBuilder ReturnType(TypeBuilder returnType)
	{
		this.returnType = returnType;
		return this;
	}
}