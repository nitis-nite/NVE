// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core;
public class Type
{
	public readonly string Name;
	public readonly AccessP Access;
	public readonly TypeP Specifics;
	internal lid lid;
	internal lid plid;
	public Type(string Name, AccessP access, TypeP specifics)
	{
		this.Name = Name;
		this.Access = access;
		this.Specifics = specifics;
	}
	public override string ToString()
		=> $"{{{Access}}} {Name} [{Specifics}]";
}
