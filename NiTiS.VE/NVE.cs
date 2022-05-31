// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;
public class NVE
{
	private readonly string runnerName;
	private readonly Sequence<Package> packages;
	private readonly NiTiS.VE.Services.Version version = new(0, 0, 0, 2);
	public NVE(string runnerName)
	{
		this.runnerName = runnerName;
		this.packages = new(16);
	}
	public void LoadPackage(Package pack)
	{
		this.packages.Add(pack);
	}
	public void LoadPackage(byte[] rawData)
		=> throw new NotImplementedException();
	public void Execute()
	{

	}
}
