namespace ET
{
	public interface IMessageDispatcher
	{
		void Dispatch(Session session, uint opcode, object message);
	}
}
