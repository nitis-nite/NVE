// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core.Methods;

[Flags]
public enum MethMarks : ushort
{
	generic = 1,
	hidefromuser = 2,
	@static = 4,
	constructor = 8,
	staticconstructor = @static | constructor,

}
