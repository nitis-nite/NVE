// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.VE.Services.Runtime;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Core;
public unsafe struct Buff
{
	public readonly byte[] mem;
	public Buff(uint size)
	{
		mem = new byte[size];
	}
	public byte Get(uint pos)
	{
		fixed (byte* p = mem)
		{
			return p[pos];
		}
	}
	public void Set(uint pos, byte val)
	{
		fixed (byte* p = mem)
		{
			p[pos] = val;
		}
	}
}
