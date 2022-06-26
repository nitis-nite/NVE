// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core.Emit;
public class TypeBuilder
{
	private readonly PackageBuilder package;
	private readonly List<MethodBuilder> methods = new();
	public string Name { get; set; } = String.Empty;
	public TypeBuilder(PackageBuilder packageBuilder)
	{
		this.package = packageBuilder;
	}
	public MethodBuilder DefineMethodBuilder()
	{
		MethodBuilder builder = new(package, this);
		methods.Add(builder);
		return builder;
	}
}
