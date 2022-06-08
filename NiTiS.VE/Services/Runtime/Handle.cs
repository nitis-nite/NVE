// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime;
public unsafe struct Handle<T> : IDisposable where T : unmanaged
{
	private readonly GCHandle handle;
	public Handle(T item)
	{
		this.handle = GCHandle.Alloc(item, GCHandleType.Pinned);
	}
	public static explicit operator T* (Handle<T> handle)
	{
		return (T*) handle.handle.AddrOfPinnedObject();
	}

	public void Free()
		=> this.handle.Free();
	public void Dispose()
		=> Free();
}
