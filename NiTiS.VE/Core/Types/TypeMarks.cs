// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core.Types;

[Flags]
public enum TypeMarks : ushort
{
	none = 0,
	generic = 1,
	hidefromuser = 2,
	lazystaticctor = 4,
}
