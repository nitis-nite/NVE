// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core.Exec;
public enum Bytec : byte
{
	// 200+ unsuported features
	/// <summary>
	/// Create instance of lid
	/// </summary>
	__initialize = 200,
	/// <summary>
	/// Select instance
	/// </summary>
	__instload = 203,
	/// <summary>
	/// Load selected instance to argument
	/// </summary>
	__argload = 204,
	/// <summary>
	/// Call instance (cached in package)
	/// </summary>
	__call = 222,
	__clearb = 223,
}
