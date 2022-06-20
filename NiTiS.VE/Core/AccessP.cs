// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core;

[Flags]
public enum AccessP : byte
{
	/// <summary>
	/// Any support
	/// <br/>
	/// Access for anyone
	/// </summary>
	Public = 0,
	/// <summary>
	/// Fields, Methods support
	/// <br/>
	/// Access only for this structure
	/// </summary>
	Private = 1,
	/// <summary>
	/// Fields, Methods support
	/// <br/>
	/// Access only for dependens
	/// </summary>
	Protected = 2,
	/// <summary>
	/// Any support
	/// <br/>
	/// Access only for types in one (package, assembly, library)
	/// </summary>
	Family = 4,
	/// <summary>
	/// Any support
	/// <br/>
	/// Access only for dependens in one (package, assembly, library)
	/// </summary>
	FamilyProtected = Family | Protected,
	
}
