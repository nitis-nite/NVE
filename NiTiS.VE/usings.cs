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
global using static NiTiS.VE.Services.MM.nmeml;
global using static UnsafeMthds;

public static class Extensions
{
}
public static unsafe class UnsafeMthds
{
	public static T* __fixed<T>(T item) where T : unmanaged
	{
		T* ptr = &item;
		return ptr;
	}
}