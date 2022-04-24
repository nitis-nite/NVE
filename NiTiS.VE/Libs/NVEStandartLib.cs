namespace NiTiS.VE.Libs;

public static class NVEStandartLib
{
	public static void Load(NVE nve)
	{
		PackageBuilder builder = new PackageBuilder("NVEBasicPackage").WithVersion(new Version(0, 0, 0, 1));

		ClassBuilder objectBuilder = builder.CreateClassBuilder("NVE.Object").WithAlias("object");
		objectBuilder.WithMethod(new("getType"));
		objectBuilder.Build(builder);

		ClassBuilder booleanBuilder = builder.CreateClassBuilder("NVE.Boolean").WithAlias("boolean");
		booleanBuilder.Build(builder);

		ClassBuilder typeBuilder = builder.CreateClassBuilder("NVE.Reflection.Type").WithAlias("type");
		typeBuilder.Build(builder);

		ClassBuilder backendBuilder = builder.CreateClassBuilder("NVE.Backend");
		backendBuilder.Build(builder);

		Package pck = builder.Build();
		nve.LoadPackage(pck);
	}
}
