// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Packing;
[Flags]
public enum TypeMarks : Byte
{
	None = 0,
	/// <summary>
	/// Access for anyone
	/// </summary>
	Public = 1,
	/// <summary>
	/// Access from any package
	/// </summary>
	OutAccess = 2,
}
