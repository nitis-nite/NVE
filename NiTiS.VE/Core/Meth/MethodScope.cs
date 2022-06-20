// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.VE.Services.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core.Meth;
public class MethodScope
{
	private readonly TheStack<Inst> stack;
	public MethodScope(uint stackSize)
	{
		stack = new(stackSize);
	}
	public Inst Run(Type type, params VEECl[] code)
	{
		uint codelenght = __unsign(code.Length);

		Inst select = new();
		Type? selectType = null;
		for (uint cc = 0; cc < codelenght; cc++)
		{
			VEECl codePart = code[cc];
			Console.WriteLine($"CodePart {cc} {codePart.code} {((uint)codePart.lid):X}[{(uint)codePart.lid}]");
			switch (codePart.code)
			{
				case VEEC.Nope: {
						continue;
					}
				case VEEC.Load: {
						select = stack[codePart.lid];
						continue;
					}
				case VEEC.InitVoid: {
						stack.Append(new(NVE.Void));
						continue;
					}
				case VEEC.LoadType: { 
						selectType = NVE.GetPackage(type.plid).
					}
				case VEEC.Skip: {
						cc += codePart.lid;
						continue;
					}
				case VEEC.GoTo: {
						cc = codePart.lid;
						continue;
					}
				case VEEC.Return: {
						cc = codelenght;
						return select;
					}
				case VEEC.ReturnStack: {
						cc = codelenght;
						select = stack[codePart.lid];
						return select;
					}

				default: {
						Exit(ExitCodes.UnsuportedVEECode);
						continue;
					}
			}
		}
		return select;
	}
}
