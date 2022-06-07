// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE;


/// <summary>
/// UTF-8 string
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct Strlnk : IDisposable
{
	public readonly byte* text;
	public readonly uint textSize;
	public Char* Ptr => (char*)text;
	public Strlnk(string text)
	{
		fixed(char* ptr = text)
		{
			this.text = (byte*)ptr;
		}
		this.textSize = (uint)text.Length;
		for (int i = 0; i < textSize; i++)
		{
			this.text[i] = (byte)text[i];
		}
	}
	public override string ToString()
		=> UTF8.GetString(text, (int)textSize);
	[Obsolete]
	public void Dispose()
	{
		if (text != (byte*)0)
		{
			_unlock(text);
		}
	}
	public static readonly Strlnk Empty;
	static Strlnk()
	{
		Empty = new Strlnk();
	}
}