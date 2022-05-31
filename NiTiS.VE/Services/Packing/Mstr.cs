// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Packing;

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct Mstr
{
	public readonly char* firstChar;
	public readonly uint size;
	public Mstr(char* ptr, uint size)
	{
		this.firstChar = ptr;
		this.size = size;
	}
	public Mstr(string text)
	{
		fixed (char* ptr = text)
		{
			this.firstChar = ptr;
			this.size = (uint)text.Length;
		}
	}
	public override string ToString()
		=> new(firstChar, 0, (int)size);
}
