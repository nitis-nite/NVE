// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Pack
{
	/// <summary>
	/// Load id
	/// </summary>
	internal uint lid;
	/// <summary>
	/// Path to package
	/// </summary>
	internal Strlnk filePath;
	public readonly Strlnk name;
	public unsafe Pack(string name) : this(new Strlnk(name)) { }
	public unsafe Pack(Strlnk name)
	{
		this.name = name;
		this.filePath = Strlnk.Empty;
		lid = 0;
	}
}
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct Packptr
{
	public readonly Pack* package;
	public Packptr(Pack pack)
	{
		package = &pack;
	}
	public Packptr(Pack* packptr)
	{
		package = packptr;
	}
}