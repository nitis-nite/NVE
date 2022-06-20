// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Core.Meth;
public enum VEEC : ushort
{
	Nope = 0,
	/// <summary>
	/// Load to current instance from stack
	/// </summary>
	///	<remarks>
	/// LID value required!
	/// </remarks>
	Load = 1,
	/// <summary>
	/// Initialize NVE.Void into stack
	/// </summary>
	InitVoid = 2,
	/// <summary>
	/// Initialize type by lid
	/// </summary>
	/// <remarks>
	/// LID value required!
	/// </remarks>
	Init = 3,
	/// <summary>
	/// Save type to typeSelect
	/// </summary>
	/// <remarks>
	/// LID value required!
	/// </remarks>
	LoadType = 31,
	/// <summary>
	/// Save this type to typeSelect
	/// </summary>
	/// <remarks>
	/// LID value required!
	/// </remarks>
	LoadTypeIt = 32,
	/// <summary>
	/// Goto specific line
	/// </summary>
	///	<remarks>
	/// LID value required!
	/// </remarks>
	GoTo = 60,
	/// <summary>
	/// Skip specific amount of lines
	/// </summary>
	///	<remarks>
	/// LID value required!
	/// </remarks>
	Skip = 61,
	Return = 780,
	///	<remarks>
	/// LID value required!
	/// </remarks>
	ReturnStack = 781,
	__unsuported = ushort.MaxValue,
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct VEECl
{
	public readonly VEEC code;
	public readonly lid lid;
	public VEECl(VEEC code, lid lid)
	{
		this.code = code;
		this.lid = lid;
	}
}
