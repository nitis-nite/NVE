using System;

namespace NiTiS.VE.Services.Build;

public enum TokenType : UInt16
{
	EMPTY = 0,
	IGNORE_LINE = 7,
	LIT_READ = 10,
	CHR_READ = 90,
	STR_READ = 100,
	STR_READ_SAVE_CHAR = 101,
	NUM_READ = 110,
}
