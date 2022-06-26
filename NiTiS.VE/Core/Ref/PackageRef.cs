// The NiTiS-Dev licenses this file to you under the MIT license.
namespace NiTiS.VE.Core.Ref;

public class PackageRef
{
	private readonly string packageName;
	private readonly Version64 ver;

	public PackageRef(string packageName, Version64 ver)
	{
		this.packageName = packageName;
		this.ver = ver;
	}
}
