using System;
using System.Collections.Generic;
using System.IO;
using File = NiTiS.IO.File;
using System.Linq;
using System.Text;
using System.Diagnostics;
using static NiTiS.VE.Services.Build.TokenType;

namespace NiTiS.VE.Services.Build;

public class Scaner 
{
	private readonly List<Token> tokens = new(128);
	private readonly StringBuilder stringBuilder = new();
	protected uint lc = 1, cc = 0;
	protected char c;
	protected bool isLeter, isDigit;
	protected uint losedChars = 0;
	protected TokenType PreviousToken { get; set; } = EMPTY;
	public Scaner()
	{
	}
	public void Scan(File file)
		=> Scan(file.ReadText());	
	public void Scan(TextReader textReader)
		=> Scan(textReader.ReadToEnd());
	public void Scan(string code)
	{
		foreach(char c in code)
		{
			Scan(c);
		}
	}
	protected void Scan(char c)
	{
		isLeter = Char.IsLetter(c);
		isDigit = Char.IsDigit(c);
		cc++;
		if (PreviousToken is STR_READ_SAVE_CHAR)
		{
			if (c is '\n') stringBuilder.Append('\n'); //If you want to more keys add new line here and send merge request at github
			else if (c is '\r') stringBuilder.Append('\r');
			else if (c is '\f') stringBuilder.Append('\f');
			else if (c is '\0') stringBuilder.Append('\0');
			else stringBuilder.Append(c);
			PreviousToken = STR_READ;
		}
		else if (c is '\n')
		{
			IsCharIsWhiteSpace();
			if (PreviousToken is IGNORE_LINE)
			{
				PreviousToken = EMPTY;
			}
			lc++;
			cc = 0;
			return;
		}
		else if (c is '\r')
		{
			IsCharIsWhiteSpace();
			cc--;
			return;
		}
		else if (c is '\"')
		{
			if (PreviousToken is STR_READ)
			{
				FinalizeString(ByteTokenType.TEXT);
			}
			else
			{
				PreviousToken = STR_READ;
			}
		}
		else if (c is '#')
		{
			if (PreviousToken is STR_READ)
			{
				FinalizeString(ByteTokenType.TEXT);
			}
			else if (PreviousToken is LIT_READ)
			{
				FinalizeString(ByteTokenType.LITERAL);
			}
			PreviousToken = IGNORE_LINE;
		}
		else if (Char.IsWhiteSpace(c)) { IsCharIsWhiteSpace(); }
		else if (isLeter) { IsCharIsLeter(); }
		else if (isDigit) { IsCharIsDigit(); }
		else { IsCharIsAnySymbol(); }

		Log($"Char is '{(c is '\n' ? "\\n" : c is '\r' ? "\\r" : c)}' at position {lc}:{cc} is letter {isLeter} is digit {isDigit} token are {PreviousToken}");
	}
	protected void IsCharIsAnySymbol()
	{
		if (PreviousToken is STR_READ)
		{
			if (c == '\\')
			{
				PreviousToken = STR_READ_SAVE_CHAR;
				losedChars++;
			} else 
			stringBuilder.Append(c);
		}
		else if (PreviousToken is NUM_READ)
		{
			if (c == '_')
			{
				losedChars++;
			}
			else if (c == '.')
			{
				stringBuilder.Append(',');
			} 
			else
			{
				FinalizeString(ByteTokenType.INT);
				stringBuilder.Append(c);
				FinalizeString(ByteTokenType.OPERATOR);
			}
		}
		else if (PreviousToken is LIT_READ)
		{
			if (c == '_')
			{
				stringBuilder.Append(c);
			} else
			{
				FinalizeString(ByteTokenType.LITERAL);
				stringBuilder.Append(c);
				FinalizeString(ByteTokenType.OPERATOR);
			}
		}
		else if (PreviousToken is EMPTY)
		{
			stringBuilder.Append(c);
			if (c == '{') FinalizeString(ByteTokenType.OPEN_OBJ);
			else if (c == '}') FinalizeString(ByteTokenType.CLOSE_OBJ);
			else FinalizeString(ByteTokenType.OPERATOR);
		} 
	}
	protected void IsCharIsDigit()
	{
		if (PreviousToken is LIT_READ) //A1 is valid | 1A is not valid 
		{
			stringBuilder.Append(c);
		}
		else if (PreviousToken is EMPTY)
		{
			stringBuilder.Append(c);
			PreviousToken = NUM_READ;
		}
		else if (PreviousToken is NUM_READ)
		{
			stringBuilder.Append(c);
		}
	}
	protected void IsCharIsLeter()
	{
		if (PreviousToken is NUM_READ)
		{
			stringBuilder.Append(c);
			FinalizeString(ByteTokenType.FLOAT);
		}
		else if (PreviousToken is EMPTY) //Literal text start
		{
			PreviousToken = LIT_READ;
			stringBuilder.Append(c);
		}
		else if (TokenIsAny(LIT_READ, STR_READ))
		{
			stringBuilder.Append(c);
		} 
	}
	protected void IsCharIsWhiteSpace()
	{
		if (TokenIsValueText())
		{
			stringBuilder.Append(c);
		}
		else if (PreviousToken is NUM_READ)
		{
			FinalizeString(ByteTokenType.INT);
		}
		else if (PreviousToken is LIT_READ) //Literal text end
		{
			FinalizeString(ByteTokenType.LITERAL);
		}
	}
	[DebuggerStepThrough]
	protected void FinalizeString(ByteTokenType tokenType)
	{
		PreviousToken = EMPTY;
		string token = stringBuilder.ToString();
		tokens.Add(
			new(
				token, 
				lc, 
				cc - (uint)token.Length - losedChars + 1, 
				tokenType));
		Log("New token are registry: " + tokens.Last().ToString());
		losedChars = 0;
		stringBuilder.Clear();
	}
	[DebuggerStepThrough]
	protected bool TokenIsValueText()
		=> (PreviousToken is STR_READ or CHR_READ);
	[DebuggerStepThrough]
	protected bool TokenIsAny(params TokenType[] tokens)
	{
		foreach(TokenType token in tokens)
		{
			if (token == PreviousToken) return true;
		}
		return false;
	}
	[DebuggerStepThrough]
	public static void Log(object obj) => Console.WriteLine(obj.ToString());
}
