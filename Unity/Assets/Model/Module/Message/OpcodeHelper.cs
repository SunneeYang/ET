using System.Collections.Generic;

namespace ET
{
	public static class OpcodeHelper
	{
		private static readonly HashSet<uint> ignoreDebugLogMessageSet = new HashSet<uint>
		{
			OMessageOpcode.C2R_Ping,
			OMessageOpcode.R2C_Ping,
		};

		public static bool IsNeedDebugLogMessage(uint opcode)
		{
			if (ignoreDebugLogMessageSet.Contains(opcode))
			{
				return false;
			}

			return true;
		}

		public static bool IsClientHotfixMessage(uint opcode)
		{
			return false;	// todo 客户端会用，考虑怎么区分
		}
	}
}