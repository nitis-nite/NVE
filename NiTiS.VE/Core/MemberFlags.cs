using System;

namespace NiTiS.VE.Core;

[Flags]
public enum MemberFlags : ushort
{
	/// <summary>
	/// Access inside member
	/// </summary>
	Private = AccessFlags.Private,
	/// <summary>
	/// Access outside member
	/// </summary>
	Public = AccessFlags.Public,
	/// <summary>
	/// Access by inherited members
	/// </summary>
	Protected = AccessFlags.Protected,
	/// <summary>
	/// Accesss only inside package
	/// </summary>
	PackageInternal = AccessFlags.PackageInternal,
	/// <summary>
	/// Member not required
	/// </summary>
	Static = 1 << 8,
}
