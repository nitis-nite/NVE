// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[StructLayout(LayoutKind.Sequential)]
public class Pack
{
	/// <summary>
	/// Load id
	/// </summary>
	internal uint lid;
	/// <summary>
	/// Path to package
	/// </summary>
	internal Mstr filePath;
	public readonly Mstr name;
	internal Pack(string name)
	{
		this.name = new(name);
	}
}
