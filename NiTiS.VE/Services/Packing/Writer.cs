using NiTiS.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NiTiS.VE.Services.Packing;
public unsafe class Writer : IPackable
{
	private readonly Sequence<byte> bytes;
	public Writer() : this(2048) { }
	public Writer(ulong size)
		=> bytes = new(size);
	public Writer TextBig(string text)
	{
		fixed (char* ptr = text)
		{
			int size = text.Length;

			Byte(TextSize.BIG);
			Int32(size);
			for (int i = 0; i < size; i++)
			{
				Byte(*(ptr + i));
			}
		}
		return this;
	}
	public Writer TextM256(string text)
	{
		fixed (char* ptr = text)
		{
			int size = text.Length;
			if (size == 0 && size > 256) throw new ArgumentOutOfRangeException("String is soo long");

			Byte(TextSize.M256);
			Byte((byte)(size -1));
			for (int i = 0; i < size; i++)
			{
				Byte(*(ptr + i));
			}
		}
		return this;
	}
	public Writer Int16(short num)
	{
		byte[] bytes = BitConv.GetBytes(num);
		Byte(bytes[0]);
		Byte(bytes[1]);
		return this;
	}
	public Writer UInt16(ushort num)
	{
		byte[] bytes = BitConv.GetBytes(num);
		Byte(bytes[0]);
		Byte(bytes[1]);
		return this;
	}
	public Writer Int32(int num)
	{
		byte[] bytes = BitConv.GetBytes(num);
		Byte(bytes[0]);
		Byte(bytes[1]);
		Byte(bytes[2]);
		Byte(bytes[3]);
		return this;
	}
	public Writer UInt32(uint num)
	{
		byte[] bytes = BitConv.GetBytes(num);
		Byte(bytes[0]);
		Byte(bytes[1]);
		Byte(bytes[2]);
		Byte(bytes[3]);
		return this;
	}
	public Writer Byte(Enum value)
	{
		TypeCode code = value.GetTypeCode();
		if (code is TypeCode.Byte)
		{
			Byte((byte)(object)value);
		}
		else if (code is TypeCode.SByte)
		{
			Byte((byte)(sbyte)(object)value);
		}
		else
		{
			throw new ArgumentException("Enum is not byte");
		}
		return this;
	}
	public Writer Byte(char @byte)
		=> Byte((byte)@byte);
	public Writer Byte(byte @byte)
	{
		Console.WriteLine("Writed: {0}", @byte);
		bytes.Add(@byte);
		return this;
	}
	public byte[] GetBytes()
		=> bytes.ToArray();
}
