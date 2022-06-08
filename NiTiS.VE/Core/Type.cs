// The NiTiS-Dev licenses this file to you under the MIT license.

namespace NiTiS.VE.Core;

public class Type
{
	public string Name { get; set; }
	internal lid lid, plid;
	public lid LID => lid;
	public lid PLID => plid;
	public static Type E_RZ { get; } = new("__erz");
	private readonly Type[] dependents;
	private Type(string name, params Type[] dependents)
	{
		Name = name;
		this.dependents = dependents;
	}
}
