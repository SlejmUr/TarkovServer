using System;
using System.Reflection;
using UnityEngine.Networking;

public static class NRHelper
{
	// Token: 0x06002A60 RID: 10848 RVA: 0x000938F8 File Offset: 0x00091AF8
	public static object GetMBuf(this NetworkReader nr)
	{
		return fieldInfo_0.GetValue(nr);
	}

	// Token: 0x06002A61 RID: 10849 RVA: 0x00093908 File Offset: 0x00091B08
	public static byte[] GetBytes(this NetworkReader nr)
	{
		object obj = nr.GetMBuf();
		return (byte[])fieldInfo_1.GetValue(obj);
	}

	// Token: 0x06002A62 RID: 10850 RVA: 0x0009392E File Offset: 0x00091B2E
	public static int GetLenght(this NetworkReader nr)
	{
		return nr.GetBytes().Length;
	}

	// Token: 0x0400218E RID: 8590
	private static readonly FieldInfo fieldInfo_0 = typeof(NetworkReader).GetField("m_buf", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);

	// Token: 0x0400218F RID: 8591
	private static readonly FieldInfo fieldInfo_1 = fieldInfo_0.FieldType.GetField("m_Buffer", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);

	// Token: 0x04002190 RID: 8592
	private static readonly FieldInfo fieldInfo_2 = fieldInfo_0.FieldType.GetField("m_Pos", BindingFlags.Instance | BindingFlags.NonPublic);
}
