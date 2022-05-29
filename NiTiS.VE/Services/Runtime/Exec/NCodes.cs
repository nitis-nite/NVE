using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime.Exec;
public static class NCodes
{
	public static readonly NCode
		None;
	static NCodes()
	{
		None = new NCode(0);
	}
}
