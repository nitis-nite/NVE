// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;
public class NVE
{
	private readonly string runnerName;
	private readonly Sequence<Package> packages;
	public NVE(string runnerName)
	{
		this.runnerName = runnerName;
		this.packages = new(16);
	}
	public void LoadPackage(Package pack)
	{

	}
	public void Execute()
	{

	}
}
