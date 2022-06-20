// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.VE.Core.Packages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core;
public readonly struct RawInst
{
	public readonly string PackName;
	public readonly string TypeName;
	public readonly byte[] Data;
	public RawInst(Type typec, byte[] data)
	{
		Package package = NVE.GetPackage(typec.plid);
		this.PackName = package.name;
		this.TypeName = typec.Name;
		this.Data = data;
	}
}
