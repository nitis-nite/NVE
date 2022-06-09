// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core;
public struct RuntimeInstance
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
		//Alloc memory
		if (refLevel == 0) //Not pointer 
		{
			ptr = reference;
			this.mem = new byte[type.Stride()];
		} else
		{
			ptr = reference;
			this.mem = Array.Empty<byte>();
		}
	}
	public bool IsNull()
		=> IsNullable() && ptr == 0;
	public bool IsNullable()
		=> refLevel > 0;

	static RuntimeInstance()
	{
		Null = new(Type.Void, 1, 0);
	}
}
