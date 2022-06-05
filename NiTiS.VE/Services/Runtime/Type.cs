// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

public class Type
{
	/// <summary>
	/// Load id
	/// </summary>
	internal uint lid = 0;
	internal Type()
	{

	}
	public bool IsInternalWith(Type other)
		=> other.lid == this.lid;
}
