using NiTiS.VE;

namespace NiTiS.NE.Console
{
	internal class Program
	{
		static void Main(string[] args)
		{
			NVE nve = new();
			Instance I_obj = new(NVEType.Object);
			Instance I_type = I_obj.ExecMethod("getType");
			Instance int8 = new(NVEType.Int8);
			I_type.PrintLine();
			int8.GetValue("val").PrintLine();
			int8.SetValue("val", 0);
			I_type.GetValue("_typeref").PrintLine();
			for (int i = 1; i < 6; i++)
			{
				int8.SetValue("val", ((int)int8.GetVal()) + 1);
				int8.ExecMethod("toString").GetVal().PrintLine();
			}
		}
	}
}
