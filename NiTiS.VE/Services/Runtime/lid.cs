// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[StructLayout(LayoutKind.Sequential)]
public readonly struct LID32
{
	public static readonly LID32 Zero = new LID32(0);
	private readonly uint id;
	public LID32(uint id)
	{
		this.id = id;
	}
	public bool IsPointless
		=> id == 0;
}
[StructLayout(LayoutKind.Sequential)]
public readonly struct LID64
{
	public static readonly LID64 Zero = new LID64();
	private readonly ulong id;
	public LID64(ulong id)
	{
		this.id = id;
	}
	public bool IsPointless
		=> id == 0;
}