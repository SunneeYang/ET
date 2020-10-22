using System;

namespace ET
{
	public class ActorMessageAttribute : Attribute
	{
		public uint Opcode { get; private set; }

		public ActorMessageAttribute(uint opcode)
		{
			this.Opcode = opcode;
		}
	}
}