// The NiTiS-Dev licenses this file to you under the MIT license.
using NiTiS.VE.Core.Ref;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core.Emit;

public class PackageBuilder
{
	private readonly PackageBuildStatus status;
	public string Name { get; set; } = String.Empty;
	public string DisplayName { get; set; } = String.Empty;
	private List<TypeBuilder> types = new();
	//private List<PackageBuilder> usingPackages = new(); TODO
	public PackageBuilder(PackageBuildStatus status)
	{
		this.status = status;
	}
	public TypeBuilder DefineTypeBuilder()
	{
		TypeBuilder builder = new(this);
		types.Add(builder);
		return builder;
	}
}
public enum PackageBuildStatus : byte
{
	Run = 1,
	Compile = 2,
}