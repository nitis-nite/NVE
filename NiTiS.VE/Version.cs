namespace NiTiS.VE;

public unsafe struct Version
{
	private fixed int numbers[4];
	public Version()
	{
		numbers[0] = 1;
		numbers[1] = -1;
		numbers[2] = -1;
		numbers[3] = -1;
	}
	public Version(int major)
	{
		numbers[0] = major;
		numbers[1] = -1;
		numbers[2] = -1;
		numbers[3] = -1;
	}
	public Version(int major, int minor)
	{
		numbers[0] = major;
		numbers[1] = minor;
		numbers[2] = -1;
		numbers[3] = -1;
	}
	public Version(int major, int minor, int patch)
	{
		numbers[0] = major;
		numbers[1] = minor;
		numbers[2] = patch;
		numbers[3] = -1;
	}
	public Version(int major, int minor, int patch, int revision)
	{
		numbers[0] = major;
		numbers[1] = minor;
		numbers[2] = patch;
		numbers[3] = revision;
	}
	public override string ToString()
	{
		int i1, i2, i3, i4;
		i1 = numbers[0];
		i2 = numbers[1];
		i3 = numbers[2];
		i4 = numbers[3];
		return $"{i1}{(i2 == -1 ? "" : i3 == -1 ? $".{i2}" : i4 == -1 ? $".{i2}.{i3}" : $".{i2}.{i3}.{i4}" )}";
	}
	public byte[] GetRaw()
	{
		byte[] bt = new byte[16];
		void setBytes(byte[] set, int index, byte[] from) {
			for (int i = 0; i < from.Length; i++)
			{
				set[i + index] = from[i];
			}
		}
		setBytes(bt, 0, System.BitConverter.GetBytes(numbers[0]));
		setBytes(bt, 4, System.BitConverter.GetBytes(numbers[1]));
		setBytes(bt, 8, System.BitConverter.GetBytes(numbers[2]));
		setBytes(bt, 12, System.BitConverter.GetBytes(numbers[3]));
		return bt;
	}
}
