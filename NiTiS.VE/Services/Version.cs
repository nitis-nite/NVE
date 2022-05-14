using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services;

public unsafe struct Version : IFormattable
{
	private fixed UInt16 val[4];
	public Version()
		: this(0, 0, 0, 0) { }
	public Version(UInt16 major)
		: this(major, 0, 0, 0) { }
	public Version(UInt16 major, UInt16 minor)
		: this(major, minor, 0, 0) { }
	public Version(UInt16 major, UInt16 minor, UInt16 build)
		: this(major, minor, build, 0) { }
	public Version(UInt16 major, UInt16 minor, UInt16 build, UInt16 revision)
	{
		val[0] = major;
		val[1] = minor;
		val[2] = build;
		val[3] = revision;
	}
	public Byte[] GetBytes()
	{
		byte[] bytes = new byte[8];
		for (int i = 0; i < 4; i++)
		{
			byte[] cache = BitConverter.GetBytes(val[i]);
			bytes[(i * 2)] = cache[0];
			bytes[(i * 2) + 1] = cache[1];
		}
		return bytes;
	}
	public override string ToString() 
		=> ToString(4);
	public string ToString(string? format, IFormatProvider? provider)
	{
		if (format is null) return ToString(4);

		if (
			format.Length == 2 && format[0] == '!'
			&& Int32.TryParse(format[1].ToString(), out Int32 verCount)
			)
		{
			if (!(verCount > 4 || verCount < 1))
			{
				return ToString((byte)verCount);
			}
		}

		return format
			.Replace("%1", val[0].ToString())
			.Replace("%2", val[1].ToString())
			.Replace("%3", val[2].ToString())
			.Replace("%4", val[3].ToString());
	}
	public string ToString(byte versionLenght)
	{
		StringBuilder builder = new();
		for (byte i = 0; i < versionLenght; i++)
		{
			builder.Append(val[i]);
			if (i != versionLenght - 1) builder.Append('.');
		}
		return builder.ToString();
	}
	public string ToString(string format)
		=> ToString(format, null);

	public static Version Parse(byte[] bytes)
	{
		return new Version(
			BitConverter.ToUInt16(new byte[] { bytes[0], bytes[1] }),
			BitConverter.ToUInt16(new byte[] { bytes[2], bytes[3] }),
			BitConverter.ToUInt16(new byte[] { bytes[4], bytes[5] }),
			BitConverter.ToUInt16(new byte[] { bytes[6], bytes[7] })
			);
	}
}
