using NiTiS.Collections.Generic;
using System;
using System.Collections.Generic;

namespace NiTiS.VE.Services.Runtime.MM;

public static unsafe class MemoryGentleman
{
	private static List<MemoryBar> bars = new();
	public static MemoryBar BarAllocate(uint size)
	{
		MemoryBar bar = new MemoryBar(size);
		bars.Add(bar);
		return bar;
	}
	public static void BarDispose(MemoryBar bar)
		=> bars.Remove(bar);
}
