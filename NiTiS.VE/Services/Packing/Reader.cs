using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Packing;

public class Reader
{
	private readonly byte[] value;
	private int pos;
	public Reader(byte[] stream)
		=> this.value = stream;
	public string String()
	{
		TextSize size = (TextSize)Byte();
		int length = size switch
		{
			TextSize.BIG => Int32(),
			TextSize.M256 => Byte(),
			_ => throw new System.IO.InvalidDataException()
		};
		char[] characters = new char[length];
		for (int i = 0; i < length; i++)
		{
			characters[i] = (char)Byte();
		}
		return new(characters);
	}
	public byte Byte()
	{
		int bt = value[pos];
		pos++;
		return (byte)bt;
	} 
	public sbyte SByte()
	{
		int bt = value[pos];
		pos++;
		return (sbyte)bt;
	}
	public char Char()
		=> (char)Byte();
	public Version Version()
		=> Services.Version.Parse(new byte[] 
		{ 
			Byte(), Byte(), Byte(), Byte(),
			Byte(), Byte(), Byte(), Byte()
		});
	public bool Boolean()
		=> BitConv.ToBoolean(new byte[] { Byte() });
	public double Double()
		=> BitConv.ToDouble(new byte[]
		{
			Byte(), Byte(), Byte(), Byte(),
			Byte(), Byte(), Byte(), Byte()
		});
	public float Single()
		=> BitConv.ToSingle(new byte[] 
		{
			Byte(), Byte(), Byte(), Byte()
		});
	public ushort UInt16()
		=> BitConv.ToUInt16(new byte[] { Byte(), Byte() });
	public short Int16()
		=> BitConv.ToInt16(new byte[] { Byte(), Byte() });
	public uint UInt32()
		=> BitConv.ToUInt32(new byte[] { Byte(), Byte(), Byte(), Byte() });
	public int Int32()
		=> BitConv.ToInt32(new byte[] { Byte(), Byte(), Byte(), Byte() });
	public ulong UInt64()
		=> BitConv.ToUInt64(new byte[] { Byte(), Byte(), Byte(), Byte(), Byte(), Byte(), Byte(), Byte() });
	public long Int64()
		=> BitConv.ToInt64(new byte[] { Byte(), Byte(), Byte(), Byte(), Byte(), Byte(), Byte(), Byte() });
}
