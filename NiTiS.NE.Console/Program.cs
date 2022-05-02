using NiteCode;

namespace NiTiS.NE.Console
{
	public static class Program
	{
		public const string GitHubUrl = @"https://github.com/NiTiS-Dev/VE/releases/latest";
		public static void Main(string[] args)
		{
			if (args.Length == 0)
			{
#if DEBUG
				Command(SC.ReadLine().Split(" "));
#endif
			}
			Command(args);
		}
		public static void Command(params string[] args)
		{
			if (args.Length == 0) return;
			string command = args[0];

			switch (command)
			{
				case "nitecode":
					{
						string command2;
						if (args.Length == 1) { command2 = "-h"; }
						else { command2 = args[1]; }

						switch (command2)
						{
							case "-h":
							case "--help":
								{
									SC.WriteLine("-----<NiteCode>-----");
									SC.WriteLine("NVE Version: {0}", typeof(NVE).Assembly.GetName().Version);
									SC.WriteLine("Created by {0}", "NickName73");
									break;
								}
							case "build":
								{
									// -v --version 1      | as langversion
									// -b --backend nve10  | as framework
									SC.WriteLine("Build unsuported in this version");
									SC.WriteLine("You can check last version on this site: {0}", GitHubUrl);
									break;
								}
						}

						break;
					}
				default:
					{
						SC.WriteLine("Inknown command");
						break;
					}
			}
		}
	}
}
