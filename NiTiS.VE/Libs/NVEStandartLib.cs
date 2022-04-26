using NiTiS.VE.Core;
using System;

namespace NiTiS.VE.Libs;

public static class NVEStandartLib
{
	public static void Load(NVE nve)
	{
		PackageBuilder builder = new PackageBuilder("NVEBasicPackage").WithVersion(new Version(0, 0, 0, 1));

		ClassBuilder objectBuilder = builder.CreateClassBuilder("NVE.Object").WithAlias("object");
		NVEClass objectClass = objectBuilder.Build(builder);

		

		ClassBuilder booleanBuilder = builder.CreateClassBuilder("NVE.Boolean").WithAlias("boolean");
		booleanBuilder.ExtendClass(objectClass);
		booleanBuilder.Build(builder);

		ClassBuilder backendBuilder = builder.CreateClassBuilder("NVE.Backend");
		backendBuilder.ExtendClass(objectClass);
		backendBuilder.Build(builder);

		ClassBuilder typeBuilder = builder.CreateClassBuilder("NVE.Reflection.Type").WithAlias("type");
		typeBuilder.ExtendClass(objectClass);
		NVEClass typeClass = typeBuilder.Build(builder);

		Package pck = builder.Build();
		nve.LoadPackage(pck);
	}
}
