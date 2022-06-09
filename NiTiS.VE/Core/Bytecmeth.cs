// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.VE.Core.Exec;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Core;
public class Bytecmeth : Method
{
	private Bytecrun runner;
	public Bytecmeth(Bytecrun run, Type returnType, params Type[] argumentType) : base(returnType, argumentType)
	{
		this.runner = run;
	}

	public override RuntimeInstance Run(NVE nve, RuntimeInstance instance, params RuntimeInstance[] arguments)
	{
		RuntimeInstance selected = instance;
		foreach (Bytecline line in runner.lines)
		{
			switch (line.bytec)
			{
				case Bytec.__instload:
					{
#if DEBUG || SUPPORT_DEBUG
						if (line.id.ToInt32() > arguments.Length) throw new RuntimeException("LID32 more than arguments list");
#endif
						if (line.id.Pointless) selected = instance;
						else selected = arguments[line.id.ToInt32() - 1];
						break;
					}
				case Bytec.__initialize:
					{
						selected = nve.GetTypeByLID(line.id).Initialize();
						break;
					}
				default:
					{
						throw new UnsupportableFeatureException($"Bytec.{line.bytec}");
					}
			}
		}


		return default;
	}
}

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct Bytecrun
{
	public readonly Bytecline[] lines;
	public Bytecrun(Bytecline[] lines)
	{
		this.lines = lines;
	}
}

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct Bytecline
{
	public readonly Bytec bytec;
	public readonly lid id;
	public Bytecline(Bytec code, lid id)
	{
		this.bytec = code;
		this.id = id;
	}
	public static readonly Bytecline argload1, argload2, argload3, loadinst0;

	static Bytecline()
	{
		loadinst0 = new(Bytec.__argload, new(0));
		argload1 = new(Bytec.__argload, new(1));
		argload2 = new(Bytec.__argload, new(2));
		argload3 = new(Bytec.__argload, new(3));
	}
}
