// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[Flags]
public enum TypeMarks : ushort
{
	None = 0,
	Abstract = 1,
	Static = 2,
	ValueType = 4,
	Interface = 8,
	ArrayType = 16,
	Generic = 32,
	BasicType = 64,
}
