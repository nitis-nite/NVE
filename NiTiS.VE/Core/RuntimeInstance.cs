// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NiTiS.VE.Core;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
public unsafe struct RuntimeInstance
{
	private readonly Type type;
	private nint ptr;
	private Byte[] mem;
	/// <summary>
	/// 0 -> Type <br/>
	/// 1 -> ref Type (Type*) <br/>
	/// 2 -> ref ref Type (Type**) <br/>
	/// </summary>
	private readonly byte refLevel;
	public static readonly RuntimeInstance Null;
	public new Type GetType()
		=> type;
	internal RuntimeInstance(Type specificType, byte refLevel, nint reference)
	{
		// Setup type
		if (specificType is null) type = Type.Void;
		else
		{
			if (specificType.marks.HasFlag(Type.Marks.Generic))
			{
				throw new UnsupportableFeatureException("GENERIC_TYPE");
			}

			type = specificType;
		}
		this.refLevel = refLevel;
		this.ptr = reference;
		//Alloc memory
		if (refLevel == 0) //Not pointer 
		{
			this.mem = new byte[type.Stride()];
		} else
		{
			this.mem = Array.Empty<byte>();
		}
	}
	public bool IsNull()
		=> IsNullable() && ptr == 0;
	public bool IsNullable()
		=> refLevel > 0;
	public override string ToString()
		=> $"{type.Name} sizeof[{mem.Length + sizeof(nint)}] pointer[{refLevel > 0}]";
	static RuntimeInstance()
	{
		Null = new(Type.Void, 1, 0);
	}
}
