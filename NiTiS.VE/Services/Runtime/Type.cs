﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;
public class Type
{
	public Name Name { get; private set; }
	public TypeMarks Marks { get; private set; }
	public MethodName[] Methods { get; private set; }

	public override string ToString() 
		=> Name.ToString();
	public class Builder
	{
		private Name name;
		private TypeMarks marks;
		private Link<Type> link = new(null!);
		private Sequence<MethodName> methods = new();
		public Builder(Name name)
			=> this.name = name;
		public Builder Method(MethodName method)
		{
			this.methods.Add(method);
			return this;
		}
		public Builder() { }
		public Builder Static()
			=> AddMark(TypeMarks.Static);
		public Builder Abstract()
			=> AddMark(TypeMarks.Abstract);
		public Builder BasicType()
			=> AddMark(TypeMarks.BasicType);
		public Builder ValueType()
			=> AddMark(TypeMarks.ValueType);
		public Builder AddMark(TypeMarks mark)
		{
			this.marks |= mark;
			return this;
		}
		public Type Build()
		{
			Type type = new()
			{
				Name = name,
				Marks = marks,
				Methods = methods.ToArray(),
			};

			return type;
		}
	}
}
