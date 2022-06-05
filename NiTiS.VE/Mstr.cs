﻿// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE;

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct Mstr : IEquatable<Mstr>, IEquatable<string>
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
	public static Mstr FromBytes(byte[] bytes)
	{
		uint size = BitConv.ToUInt32(bytes, 0);
		string str = UTF8.GetString(bytes, 4, (int)size);
		return new Mstr(str);
	}
	public byte[] GetBytes()
	{
		byte[] temp = new byte[size + 4];
		fixed (byte* ptr = temp)
		{
			UTF8.GetBytes(chars:firstChar, charCount:(int)size, bytes:ptr + 4, byteCount:(int)size);

			byte[] temp2 = BitConv.GetBytes(size);
			temp[0] = temp2[0];
			temp[1] = temp2[1];
			temp[2] = temp2[2];
			temp[3] = temp2[3];
			return temp;
		}
	}
	public override string ToString()
		=> new(firstChar, 0, (int)size);
	public bool Equals(Mstr other)
		=> other.firstChar == firstChar && other.size == size;
	public bool Equals(string? other)
	{
		if (other is null) return firstChar == (char*)IntPtr.Zero;

		for (int i = 0; i < other.Length; i++)
		{
			char s = other[i];
			char ss = *(firstChar + i);
			if (s != ss) return false;
		}
		return true;
	}
	public override bool Equals(object? obj)
		=> obj is string str ? Equals(str) : obj is Mstr mstr ? Equals(mstr) : false;
	public override int GetHashCode()
		=> HashCode.Combine(*this.firstChar, this.size);

	public static bool operator ==(Mstr left, Mstr right)
		=> Equals(left, right);
	public static bool operator !=(Mstr left, Mstr right)
		=> !Equals(left, right);
	public static bool operator ==(Mstr left, string right)
		=> Equals(left, right);
	public static bool operator !=(Mstr left, string right)
		=> !Equals(left, right);
}