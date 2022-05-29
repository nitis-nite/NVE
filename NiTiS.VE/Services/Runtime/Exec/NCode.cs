using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NiTiS.VE.Services.Runtime.Exec;

public readonly struct NCode : IEquatable<NCode>, IEquatable<byte>
{
	public readonly byte code;
	public NCode(byte code)
	{
		this.code = code;
	}

	public bool Equals(NCode other)
		=> other.code == code;
	public bool Equals(byte other)
		=> other == code;
	public override bool Equals(object? obj)
		=> obj is NCode other ? Equals(other) : obj is byte bt && Equals(bt);
	public override int GetHashCode()
		=> code;
	public override string? ToString()
		=> code.ToString("X");

	public static bool operator ==(NCode code, NCode other)
		=> code.Equals(other);
	public static bool operator !=(NCode code, NCode other)
		=> !code.Equals(other);
	public static bool operator ==(NCode code, byte other)
		=> code.Equals(other);
	public static bool operator !=(NCode code, byte other)
		=> !code.Equals(other);
}
