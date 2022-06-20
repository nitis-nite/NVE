// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;
public class TheStack<T>
{
	private T[] values;
	/// <summary>
	/// Current size (not limite)
	/// </summary>
	private uint size = 0;
	public TheStack(uint size)
	{
		values = new T[size];
	}
	public void Append(T item)
	{
		values[size] = item;
		size++;
	}
	public T this[LID32 id]
	{
		get {
			return values[size - (id+1)];
		}
		set
		{
			values[size] = value;
			size++;
		}
	}
}
