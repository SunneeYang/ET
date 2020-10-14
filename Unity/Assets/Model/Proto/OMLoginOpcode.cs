
namespace ET
{
	[Message(OMLoginOpcode.C2L_Login)]
	public partial class C2L_Login : IRequest {}

	[Message(OMLoginOpcode.L2C_Login)]
	public partial class L2C_Login : IResponse {}

	[Message(OMLoginOpcode.C2G_Login)]
	public partial class C2G_Login : IRequest {}

	[Message(OMLoginOpcode.G2C_Login)]
	public partial class G2C_Login : IResponse {}

}
namespace ET
{
	public static partial class OMLoginOpcode
	{
		 public const uint C2L_Login = 0x99eb5d71;
		 public const uint L2C_Login = 0xb01ae249;
		 public const uint C2G_Login = 0x9bec098b;
		 public const uint G2C_Login = 0x324f7c94;
	}
}
