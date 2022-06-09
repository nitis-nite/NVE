// The NiTiS-Dev licenses this file to you under the MIT license.
using NiTiS.VE.Core;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;
public unsafe class NVE
{
	private readonly string runnerName;
	private readonly NiTiS.VE.Services.Version version = new(0, 0, 0, 3);
	public NVE(string runnerName)
	{
		this.runnerName = runnerName;
	}
	public void LoadPackage(byte[] rawData)
		=> throw new System.NotImplementedException();
	public Type? GetTypeByLID(lid id)
	{
		int intid = id.ToInt32();
		if (intid > 128) //Reserve 128 types + Void for NVE
		{
			return null;
		}else
		{
			return intid switch
			{
				0 => Type.Void,
				1 => Type.Byte,
				_ => null
			};
		}
	}
}
