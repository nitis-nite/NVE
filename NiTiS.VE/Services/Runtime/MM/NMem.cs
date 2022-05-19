using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime.MM;
public static unsafe class NMem
{
	private static bool useWin;
	public static class Win
	{
		public const string NiTiSMemoryLibName = "nmeml.dll";
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc32B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock32B(byte* ptr);
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc128B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock128B(byte* ptr);
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc256B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock256B(byte* ptr);
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc512B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock512B(byte* ptr);
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc1KB();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock1KB(byte* ptr);
	}
	public static class Linux
	{
		public const string NiTiSMemoryLibName = "libnmeml.so";
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc32B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock32B(byte* ptr);
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc128B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock128B(byte* ptr);
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc256B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock256B(byte* ptr);
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc512B();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock512B(byte* ptr);
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* _alloc1KB();
		[DllImport(NiTiSMemoryLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void _unlock1KB(byte* ptr);
	}
	public static byte* _alloc32B()
		=> useWin ? Win._alloc32B() : Linux._alloc32B();
	public static void _unlock32B(byte* ptr)
	{ if (useWin) Win._unlock32B(ptr); else Linux._unlock32B(ptr); }
	public static byte* _alloc128B()
		=> useWin ? Win._alloc128B() : Linux._alloc128B();
	public static void _unlock128B(byte* ptr)
	{ if (useWin) Win._unlock128B(ptr); else Linux._unlock128B(ptr); }
	public static byte* _alloc256B()
		=> useWin ? Win._alloc256B() : Linux._alloc256B();
	public static void _unlock256B(byte* ptr)
	{ if (useWin) Win._unlock256B(ptr); else Linux._unlock256B(ptr); }
	public static byte* _alloc512B()
		=> useWin ? Win._alloc512B() : Linux._alloc512B();
	public static void _unlock512B(byte* ptr)
	{ if (useWin) Win._unlock512B(ptr); else Linux._unlock512B(ptr); }
	public static byte* _alloc1KB()
		=> useWin ? Win._alloc1KB() : Linux._alloc1KB();
	public static void _unlock1KB(byte* ptr)
	{ if (useWin) Win._unlock1KB(ptr); else Linux._unlock1KB(ptr); }

	static NMem()
	{
		NMem.useWin = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
	}
}
