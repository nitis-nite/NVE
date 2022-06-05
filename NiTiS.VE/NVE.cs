// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;
public class NVE
{
	private readonly string runnerName;
	private readonly NiTiS.VE.Services.Version version = new(0, 0, 0, 2);
	public NVE(string runnerName)
	{
		this.runnerName = runnerName;
	}
	public void LoadPackage(byte[] rawData)
		=> throw new System.NotImplementedException();
	public void Execute()
	{
		throw new System.NotImplementedException();
	}
}
