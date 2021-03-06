global using System.Linq;
global using NiTiS.VE.Services.Build;

global using NiTiS.Collections.Generic;
global using NiTiS.Collections;
global using NiTiS.Additions;
global using NiTiS.Reflection;
global using NiTiS.IO;
global using SFile = System.IO.File;
global using SDir = System.IO.Directory;

global using BitConv = System.BitConverter;
global using static System.Text.Encoding;
global using static UnsafeMthds;
global using static Extensions;

global using Version64 = NiTiS.VE.Services.Version;
global using lid = NiTiS.VE.Services.Runtime.LID32;
global using lidlong = NiTiS.VE.Services.Runtime.LID64;
using System.Runtime.InteropServices;
using NiTiS.VE.Services.Runtime;
using System;

public static class Extensions
{
	public static void Exit(ExitCodes code)
	{
#if DEBUG
		Console.WriteLine("Exit with code: {0} ({1})", ((int)code).ToString("X"), code);
#endif
		System.Environment.Exit((int)code);
	}
}
public static unsafe class UnsafeMthds
{
	public static NiTiS.VE.Services.Runtime.Handle<T> __pin<T>(T item) where T : unmanaged
	{
		NiTiS.VE.Services.Runtime.Handle<T> handle = new(item);
		return handle;
	}
	public static void __free<T>(NiTiS.VE.Services.Runtime.Handle<T> handle) where T : unmanaged
	{
		handle.Dispose();
	}
	public static T* __fixed<T>(T item) where T : unmanaged
	{
		T* ptr = &item;
		return ptr;
	}
	public static int __sign(uint num)
		=> *((int*)&(num));
	public static uint __unsign(int num)
		=> *((uint*)&(num));
	public static long __sign(ulong num)
		=> *((long*)&(num));
	public static ulong __unsign(long num)
		=> *((ulong*)&(num));
}