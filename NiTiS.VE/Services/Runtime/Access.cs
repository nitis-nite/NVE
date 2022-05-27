using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;
public enum Access : byte
{
	/// <summary>
	/// Full access
	/// </summary>
	Public = 0x00,
	/// <summary>
	/// Itself access
	/// </summary>
	Private = 0x01,
	/// <summary>
	/// Child access
	/// </summary>
	Protected = 0x02,
	/// <summary>
	/// Access for childs from this package
	/// </summary>
	InternalProtected = 0x03,
	/// <summary>
	/// Full access from this package
	/// </summary>
	Internal = 0x05
}
