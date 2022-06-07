// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;
public unsafe class NVE
{
	private readonly string runnerName;
	private readonly NiTiS.VE.Services.Version version = new(0, 0, 0, 2);
	private readonly Sequence<Packptr> packPtrs = new(16);
	private uint lidtp = 0, lidpck = 0;
	public NVE(string runnerName)
	{
		this.runnerName = runnerName;
	}
	public void LoadPackage(byte[] rawData)
		=> throw new System.NotImplementedException();
	public void LoadPackage(Package package)
	{
		Pack pack = new(package.name);

		pack.lid = ++lidpck;

		packPtrs.Add(new(__fixed(pack)));

		foreach (Type type in package.types)
		{
			type.lid = ++lidtp;
			type.plid = pack.lid;
			System.Console.WriteLine(type);
		}

	}
	public void Execute()
	{
		throw new System.NotImplementedException();
	}
}
