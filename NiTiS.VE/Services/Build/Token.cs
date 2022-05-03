namespace NiTiS.VE.Services.Build;

public struct Token
{
	public readonly uint line, @char;
	public string content;
	public readonly ByteTokenType type;
	public Token(string token, uint lineNum, uint charStartNum, ByteTokenType type)
	{
		this.content = token!;
		this.line = lineNum;
		this.@char = charStartNum;
		this.type = type;
	}
	public override string ToString() => $"{content} ({line}:{@char}) ({type})";
}
public enum ByteTokenType : byte 
{
	LITERAL = 0,
	TEXT = 1,
	INT = 2,
	FLOAT = 3,
	OPERATOR = 100,
	OPEN_OBJ = 122,
	CLOSE_OBJ = 123,
}
