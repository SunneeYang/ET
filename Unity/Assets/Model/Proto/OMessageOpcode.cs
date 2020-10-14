
namespace ET
{
	[Message(OMessageOpcode.C2M_TestRequest)]
	public partial class C2M_TestRequest : IActorLocationRequest {}

	[Message(OMessageOpcode.M2C_TestResponse)]
	public partial class M2C_TestResponse : IActorLocationResponse {}

	[Message(OMessageOpcode.Actor_TransferRequest)]
	public partial class Actor_TransferRequest : IActorLocationRequest {}

	[Message(OMessageOpcode.Actor_TransferResponse)]
	public partial class Actor_TransferResponse : IActorLocationResponse {}

	[Message(OMessageOpcode.C2G_EnterMap)]
	public partial class C2G_EnterMap : IRequest {}

	[Message(OMessageOpcode.G2C_EnterMap)]
	public partial class G2C_EnterMap : IResponse {}

// 自己的unit id
// 所有的unit
	[Message(OMessageOpcode.UnitInfo)]
	public partial class UnitInfo {}

	[Message(OMessageOpcode.M2C_CreateUnits)]
	public partial class M2C_CreateUnits : IActorMessage {}

	[Message(OMessageOpcode.Frame_ClickMap)]
	public partial class Frame_ClickMap : IActorLocationMessage {}

	[Message(OMessageOpcode.M2C_PathfindingResult)]
	public partial class M2C_PathfindingResult : IActorMessage {}

	[Message(OMessageOpcode.C2R_Ping)]
	public partial class C2R_Ping : IRequest {}

	[Message(OMessageOpcode.R2C_Ping)]
	public partial class R2C_Ping : IResponse {}

	[Message(OMessageOpcode.G2C_Test)]
	public partial class G2C_Test : IMessage {}

	[Message(OMessageOpcode.C2M_Reload)]
	public partial class C2M_Reload : IRequest {}

	[Message(OMessageOpcode.M2C_Reload)]
	public partial class M2C_Reload : IResponse {}

	[Message(OMessageOpcode.C2R_Login)]
	public partial class C2R_Login : IRequest {}

	[Message(OMessageOpcode.R2C_Login)]
	public partial class R2C_Login : IResponse {}

	[Message(OMessageOpcode.C2G_LoginGate)]
	public partial class C2G_LoginGate : IRequest {}

	[Message(OMessageOpcode.G2C_LoginGate)]
	public partial class G2C_LoginGate : IResponse {}

	[Message(OMessageOpcode.G2C_TestHotfixMessage)]
	public partial class G2C_TestHotfixMessage : IMessage {}

	[Message(OMessageOpcode.C2M_TestActorRequest)]
	public partial class C2M_TestActorRequest : IActorLocationRequest {}

	[Message(OMessageOpcode.M2C_TestActorResponse)]
	public partial class M2C_TestActorResponse : IActorLocationResponse {}

	[Message(OMessageOpcode.PlayerInfo)]
	public partial class PlayerInfo : IMessage {}

	[Message(OMessageOpcode.C2G_PlayerInfo)]
	public partial class C2G_PlayerInfo : IRequest {}

	[Message(OMessageOpcode.G2C_PlayerInfo)]
	public partial class G2C_PlayerInfo : IResponse {}

}
namespace ET
{
	public static partial class OMessageOpcode
	{
		 public const uint C2M_TestRequest = 0xf7e20de7;
		 public const uint M2C_TestResponse = 0x8b70245c;
		 public const uint Actor_TransferRequest = 0x3b179425;
		 public const uint Actor_TransferResponse = 0x15cfd172;
		 public const uint C2G_EnterMap = 0xe5f62ed7;
		 public const uint G2C_EnterMap = 0xef1bb5d2;
		 public const uint UnitInfo = 0x937f81f3;
		 public const uint M2C_CreateUnits = 0x803eef2b;
		 public const uint Frame_ClickMap = 0xae4e1f31;
		 public const uint M2C_PathfindingResult = 0xc8e11be0;
		 public const uint C2R_Ping = 0xfc82da7b;
		 public const uint R2C_Ping = 0x84193af0;
		 public const uint G2C_Test = 0x4de8464e;
		 public const uint C2M_Reload = 0x54947c93;
		 public const uint M2C_Reload = 0x5fd75e12;
		 public const uint C2R_Login = 0xae0abae2;
		 public const uint R2C_Login = 0xd4187baa;
		 public const uint C2G_LoginGate = 0x18b4640d;
		 public const uint G2C_LoginGate = 0x68d47d19;
		 public const uint G2C_TestHotfixMessage = 0x5963faac;
		 public const uint C2M_TestActorRequest = 0x8e655ced;
		 public const uint M2C_TestActorResponse = 0xc777f31e;
		 public const uint PlayerInfo = 0xfbc3698e;
		 public const uint C2G_PlayerInfo = 0xe9e726cc;
		 public const uint G2C_PlayerInfo = 0xf34d92a8;
	}
}
