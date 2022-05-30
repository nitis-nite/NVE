// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[StructLayout(LayoutKind.Sequential)]
public unsafe class Instance
{
	public static readonly uint PointerSize = (uint)sizeof(IntPtr);
	private Type? type;
	private InstanceMarks marks;
	private byte* ptr;

	public bool IsInitialized => marks.HasFlag(InstanceMarks.Initialized);

	/// <param name="type">If null instance is null</param>
	public Instance(Type? type)
	{
		this.type = type;
	}
	public uint Size()
	{
		if (type is null) return 0;
		else
		{
			uint size = 0;
			
			return size;
		}
	}
	public void Initialize()
	{
		if (IsInitialized) throw new RuntimeException("Instance allready initialized");
		int size = (int)Size();
		//Alloc memory
		if (size > 0)
		{
			ptr = _alloc(size);

			for (int i = 0; i < size; i++)
			{
				*(ptr + i) = 0;
			}
		}
		marks |= InstanceMarks.Initialized;
	}
}