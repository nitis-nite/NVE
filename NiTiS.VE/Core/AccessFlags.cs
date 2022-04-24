using System;

namespace NiTiS.VE.Core;

[Flags]
public enum AccessFlags : byte
{
	/// <summary>
	/// Access inside member
	/// </summary>
	Private = 1 << 0,
	/// <summary>
	/// Access outside member
	/// </summary>
	Public = 1 << 1,
	/// <summary>
	/// Access by inherited members
	/// </summary>
	Protected = 1 << 2,
	/// <summary>
	/// Accesss only inside package
	/// </summary>
	PackageInternal = 1 << 3,
}
