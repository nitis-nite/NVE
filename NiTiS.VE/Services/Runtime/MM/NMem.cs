using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime.MM;
public static unsafe class NMem
{
	private class Win
	{
		public const string NiTiSMemoryLibName = "nmeml.dll";
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc32B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock32B(byte* ptr);
	}
	private class Linux
	{
		public const string NiTiSMemoryLibName = "nmeml.lib";
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc32B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock32B(byte* ptr);
	}
	public static byte* _alloc32B()
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			return Win._alloc32B();
		}
		return Linux._alloc32B();
	}
	public static void _unlock32B(byte* ptr)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			Win._unlock32B(ptr);
			return;
		}
		Linux._unlock32B(ptr);
	}
}
