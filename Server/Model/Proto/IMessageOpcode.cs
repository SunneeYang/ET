namespace ET
{
	public static partial class IMessageOpcode
	{
		 public const uint M2M_TrasferUnitRequest = 0xc7d261b7;
		 public const uint M2M_TrasferUnitResponse = 0xb32e6ef;
		 public const uint M2A_Reload = 0x1df2596f;
		 public const uint A2M_Reload = 0x5061acae;
		 public const uint G2G_LockRequest = 0x4d8dda13;
		 public const uint G2G_LockResponse = 0xda03dea5;
		 public const uint G2G_LockReleaseRequest = 0x7bb77b50;
		 public const uint G2G_LockReleaseResponse = 0x35e0f42e;
		 public const uint ObjectAddRequest = 0x2059b7aa;
		 public const uint ObjectAddResponse = 0x68d301e0;
		 public const uint ObjectLockRequest = 0x4fe5e247;
		 public const uint ObjectLockResponse = 0xb6072370;
		 public const uint ObjectUnLockRequest = 0xe05bd7a2;
		 public const uint ObjectUnLockResponse = 0x66c88bb2;
		 public const uint ObjectRemoveRequest = 0xdee9bf38;
		 public const uint ObjectRemoveResponse = 0x762c4380;
		 public const uint ObjectGetRequest = 0x4687e285;
		 public const uint ObjectGetResponse = 0xc364e2ec;
		 public const uint R2G_GetLoginKey = 0x38f17e43;
		 public const uint G2R_GetLoginKey = 0xe63c4a4e;
		 public const uint G2M_CreateUnit = 0x6fe49945;
		 public const uint M2G_CreateUnit = 0x57e4abbf;
		 public const uint G2M_SessionDisconnect = 0x82637a70;
	}
}
