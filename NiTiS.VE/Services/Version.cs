using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Version : IEquatable<Version>, IComparable<Version>, IFormattable
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
	public ushort Major => val[0];
	public ushort Minor => val[1];
	public ushort Build => val[2];
	public ushort Revision => val[3];
	public int CompareTo(Version other)
		=> ((ulong)this).CompareTo((ulong)other);
	public bool Equals(Version other)
	{
		if (other.Major != this.Major) return false;
		if (other.Minor != this.Minor) return false;
		if (other.Build != this.Build) return false;
		if (other.Revision != this.Revision) return false;
		return true;
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
	public override bool Equals(object? obj)
		=> obj is Version ver ? Equals(ver) : false;
	public override int GetHashCode()
		=> ((ulong)this).GetHashCode();

	public static explicit operator UInt64(Version version)
	{
		byte[][] part = new byte[4][];
		part[3] = BitConverter.GetBytes(version.val[0]);
		part[2] = BitConverter.GetBytes(version.val[1]);
		part[1] = BitConverter.GetBytes(version.val[2]);
		part[0] = BitConverter.GetBytes(version.val[3]);
		byte[] temp = new byte[sizeof(UInt64)];
		for (int i = 0; i < temp.Length; i++)
		{
			 temp[i] = part[i / 2][i % 2];
		}
		return BitConverter.ToUInt64(temp);
	}

	public static bool operator <(Version left, Version right)
		=> left.CompareTo(right) < 0;
	public static bool operator <=(Version left, Version right)
		=> left.CompareTo(right) <= 0;
	public static bool operator >(Version left, Version right)
		=> left.CompareTo(right) > 0;
	public static bool operator >=(Version left, Version right)
		=> left.CompareTo(right) >= 0;
	public static bool operator ==(Version left, Version right)
		=> left.Equals(right);
	public static bool operator !=(Version left, Version right)
		=> !left.Equals(right);
}
