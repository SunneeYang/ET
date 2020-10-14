using System.Collections.Generic;

namespace ET
{
	/// <summary>
	/// 消息分发组件
	/// </summary>
	public class MessageDispatcherComponent : Entity
	{
		public static MessageDispatcherComponent Instace { get; set; }
		public readonly Dictionary<uint, List<IMHandler>> Handlers = new Dictionary<uint, List<IMHandler>>();
	}
}