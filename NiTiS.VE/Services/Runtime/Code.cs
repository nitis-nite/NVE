using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

public readonly struct Code
{
	public readonly Op operation;
	public readonly byte[] data;
	public Code(Op op, byte[] data)
	{
		this.operation = op;
		this.data = data;
	}
	public Code(Op op)
	{
		this.operation = op;
		this.data = Array.Empty<byte>();
	}
	public static readonly Code
		Nope = new(Op.No);
	public static Code Load(byte stackPos)
		=> new(Op.Load, new byte[] { stackPos });
}
public enum Op : byte
{
	/// <summary>
	/// Nothing
	/// </summary>
	/// <remarks>Data size: 0b</remarks>
	No = 0,
	/// <summary>
	/// Set value
	/// </summary>
	/// <remarks>Data size: 1b</remarks>
	Push = 1,
	/// <summary>
	/// Load value
	/// </summary>
	/// <remarks>Data size: 1b</remarks>
	Load = 2,
	/// <summary>
	/// Load string from constant field
	/// </summary>
	/// <remarks>Data size: 2b</remarks>
	LoadStr = 3,
	/// <summary>
	/// Call function
	/// </summary>
	/// <remarks>Data size: 4b type pointer, 2b func pointer </remarks>
	Call = 22,
}
