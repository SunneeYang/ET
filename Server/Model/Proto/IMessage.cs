using ET;
using System.Collections.Generic;
namespace ET
{
/// <summary>
/// 传送unit
/// </summary>
	[Message(IMessageOpcode.M2M_TrasferUnitRequest)]
	public partial class M2M_TrasferUnitRequest: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public Unit Unit { get; set; }

	}

	[Message(IMessageOpcode.M2M_TrasferUnitResponse)]
	public partial class M2M_TrasferUnitResponse: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

		public long InstanceId { get; set; }

	}

	[Message(IMessageOpcode.M2A_Reload)]
	public partial class M2A_Reload: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

	}

	[Message(IMessageOpcode.A2M_Reload)]
	public partial class A2M_Reload: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

	}

	[Message(IMessageOpcode.G2G_LockRequest)]
	public partial class G2G_LockRequest: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public long Id { get; set; }

		public string Address { get; set; }

	}

	[Message(IMessageOpcode.G2G_LockResponse)]
	public partial class G2G_LockResponse: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

	}

	[Message(IMessageOpcode.G2G_LockReleaseRequest)]
	public partial class G2G_LockReleaseRequest: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public long Id { get; set; }

		public string Address { get; set; }

	}

	[Message(IMessageOpcode.G2G_LockReleaseResponse)]
	public partial class G2G_LockReleaseResponse: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

	}

	[Message(IMessageOpcode.ObjectAddRequest)]
	public partial class ObjectAddRequest: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public long Key { get; set; }

		public long InstanceId { get; set; }

	}

	[Message(IMessageOpcode.ObjectAddResponse)]
	public partial class ObjectAddResponse: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

	}

	[Message(IMessageOpcode.ObjectLockRequest)]
	public partial class ObjectLockRequest: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public long Key { get; set; }

		public long InstanceId { get; set; }

		public int Time { get; set; }

	}

	[Message(IMessageOpcode.ObjectLockResponse)]
	public partial class ObjectLockResponse: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

	}

	[Message(IMessageOpcode.ObjectUnLockRequest)]
	public partial class ObjectUnLockRequest: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public long Key { get; set; }

		public long OldInstanceId { get; set; }

		public long InstanceId { get; set; }

	}

	[Message(IMessageOpcode.ObjectUnLockResponse)]
	public partial class ObjectUnLockResponse: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

	}

	[Message(IMessageOpcode.ObjectRemoveRequest)]
	public partial class ObjectRemoveRequest: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public long Key { get; set; }

	}

	[Message(IMessageOpcode.ObjectRemoveResponse)]
	public partial class ObjectRemoveResponse: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

	}

	[Message(IMessageOpcode.ObjectGetRequest)]
	public partial class ObjectGetRequest: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public long Key { get; set; }

	}

	[Message(IMessageOpcode.ObjectGetResponse)]
	public partial class ObjectGetResponse: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

		public long InstanceId { get; set; }

	}

	[Message(IMessageOpcode.R2G_GetLoginKey)]
	public partial class R2G_GetLoginKey: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public string Account { get; set; }

	}

	[Message(IMessageOpcode.G2R_GetLoginKey)]
	public partial class G2R_GetLoginKey: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

		public long Key { get; set; }

		public long GateId { get; set; }

	}

	[Message(IMessageOpcode.G2M_CreateUnit)]
	public partial class G2M_CreateUnit: IActorRequest
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

		public long PlayerId { get; set; }

		public long GateSessionId { get; set; }

	}

	[Message(IMessageOpcode.M2G_CreateUnit)]
	public partial class M2G_CreateUnit: IActorResponse
	{
		public int RpcId { get; set; }

		public int Error { get; set; }

		public string Message { get; set; }

// 自己的unit id
// 自己的unit id
		public long UnitId { get; set; }

// 所有的unit
// 所有的unit
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(IMessageOpcode.G2M_SessionDisconnect)]
	public partial class G2M_SessionDisconnect: IActorLocationMessage
	{
		public int RpcId { get; set; }

		public long ActorId { get; set; }

	}

}
