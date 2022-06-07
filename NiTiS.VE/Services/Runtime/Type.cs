// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[StructLayout(LayoutKind.Sequential)]
public unsafe class Type
{
	/// <summary>
	/// Load id
	/// </summary>
	internal uint lid = 0;
	/// <summary>
	/// Package load id
	/// </summary>
	internal uint plid = 0;
	public readonly Strlnk name;
	internal Type(Strlnk name)
	{
		this.name = name;
	}
	public bool IsInternalWith(Type other)
		=> other.lid == this.lid;
	public override string ToString()
		=> $"{name} [LID:{lid}] [PLID:{plid}]";
	public class Builder
	{
		private string name;
		public Builder(string name)
		{
			this.name = name;
		}
		public Type Build()
		{
			return new(new(name))
			{

			};
		}
	}
}
