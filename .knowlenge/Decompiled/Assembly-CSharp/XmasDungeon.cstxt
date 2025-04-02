using UnityEngine;

public class XmasDungeon : HalloweenDungeon
{
	public const Flags HasPlayerOutside = Flags.Reserved7;

	public const Flags HasPlayerInside = Flags.Reserved8;

	[ServerVar(Help = "Population active on the server", ShowInAdminUI = true)]
	public static float xmaspopulation = 0f;

	[ServerVar(Help = "How long each active dungeon should last before dying", ShowInAdminUI = true)]
	public static float xmaslifetime = 1200f;

	[ServerVar(Help = "How far we detect players from our inside/outside", ShowInAdminUI = true)]
	public static float playerdetectrange = 30f;

	public override float GetLifetime()
	{
		return xmaslifetime;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		InvokeRepeating(PlayerChecks, 1f, 1f);
	}

	public void PlayerChecks()
	{
		ProceduralDynamicDungeon proceduralDynamicDungeon = dungeonInstance.Get(serverside: true);
		if (proceduralDynamicDungeon == null)
		{
			return;
		}
		bool b = false;
		bool b2 = false;
		foreach (BasePlayer activePlayer in BasePlayer.activePlayerList)
		{
			float num = Vector3.Distance(activePlayer.transform.position, base.transform.position);
			float num2 = Vector3.Distance(activePlayer.transform.position, proceduralDynamicDungeon.GetExitPortal(serverSide: true).transform.position);
			if (num < playerdetectrange)
			{
				b = true;
			}
			if (num2 < playerdetectrange * 2f)
			{
				b2 = true;
			}
		}
		SetFlag(Flags.Reserved8, b2);
		SetFlag(Flags.Reserved7, b);
		proceduralDynamicDungeon.SetFlag(Flags.Reserved7, b);
		proceduralDynamicDungeon.SetFlag(Flags.Reserved8, b2);
	}
}
