using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NiTiS.VE.Services.Runtime.MM;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
public unsafe class MemoryBar : IEquatable<MemoryBar>
{
	private static uint lastID = 0;
	/// <summary>
	/// ID of current memory bar
	/// </summary>
	public readonly uint barID = ++lastID;
	/// <summary>
	/// Array representation of memory
	/// </summary>
	private byte[] memory;
	/// <summary>
	/// Pointer to first element in array
	/// </summary>
	private byte* memPtr;
	/// <summary>
	/// Array size
	/// </summary>
	public readonly uint size;

	public MemoryBar(uint size)
	{
		memory = new byte[size];
		this.size = size;
		fixed (byte* ptr = memory)
		{
			memPtr = ptr;
		}
	}
	public MemoryBar() : this(128) { }
	public void Akord(uint position, byte data)
	{
		if (position > size) throw new OutOfMemoryException();
		memory[position] = data;
	}
	public byte* Dekord(uint position)
	{
		if (position > size) throw new OutOfMemoryException();
		return memPtr + position;
	}
	public byte* TrueDekord(uint position)
	{
		if (position > size) throw new OutOfMemoryException();
		fixed (byte* ptr = memory)
		{
			return memPtr + position;
		}
	}
	public bool Equals(MemoryBar other)
		=> other.barID == this.barID;
	public override bool Equals(object? obj) 
		=> obj is MemoryBar other && Equals(other);
	public override int GetHashCode() => HashCode.Combine(barID);
	public override string ToString()
		=> $"MemoryBar {barID}";
}
