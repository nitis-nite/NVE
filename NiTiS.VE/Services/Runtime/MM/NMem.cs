using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime.MM;
public static unsafe class NMem
{
	[DllImport("nmem.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern byte* _alloc32B();
	[DllImport("nmem.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern byte* _unlock32B(byte* ptr);
}
