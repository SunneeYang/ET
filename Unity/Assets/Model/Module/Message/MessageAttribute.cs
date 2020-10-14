namespace ET
{
	public class MessageAttribute: BaseAttribute
	{
		public uint Opcode { get; }

		public MessageAttribute(uint opcode)
		{
			this.Opcode = opcode;
		}
	}
}