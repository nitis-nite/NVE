// The NiTiS-Dev licenses this file to you under the MIT license.
namespace NiTiS.VE.Core;

public abstract class AbstractEntry
{
	public string Name { get; }
	public AbstractEntry(string name)
	{
		Name = name;
	}
}
