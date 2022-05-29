// The NiTiS-Dev licenses this file to you under the MIT license.

using System;

namespace NiTiS.VE.Services.Runtime;

[Flags]
public enum InstanceMarks : byte
{
	None = 0,
	Initialized = 1,
}