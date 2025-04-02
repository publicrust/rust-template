using UnityEngine;

public class StaticRespawnArea : SleepingBag
{
	public Transform[] spawnAreas;

	public bool allowHostileSpawns;

	public override bool ValidForPlayer(ulong playerID, bool ignoreTimers)
	{
		BasePlayer basePlayer = BasePlayer.FindByID(playerID);
		if ((Object)(object)basePlayer != (Object)null && basePlayer.IsInTutorial)
		{
			return false;
		}
		if (ignoreTimers || allowHostileSpawns)
		{
			return true;
		}
		return basePlayer.GetHostileDuration() <= 0f;
	}

	public override void GetSpawnPos(out Vector3 pos, out Quaternion rot)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		Transform val = spawnAreas[Random.Range(0, spawnAreas.Length)];
		pos = ((Component)val).transform.position + spawnOffset;
		Quaternion rotation = ((Component)val).transform.rotation;
		rot = Quaternion.Euler(0f, ((Quaternion)(ref rotation)).eulerAngles.y, 0f);
	}

	public override void SetUnlockTime(float newTime)
	{
		unlockTime = 0f;
	}

	public override float GetUnlockSeconds(ulong playerID)
	{
		BasePlayer basePlayer = BasePlayer.FindByID(playerID);
		if ((Object)(object)basePlayer == (Object)null || allowHostileSpawns)
		{
			return base.unlockSeconds;
		}
		return Mathf.Max(basePlayer.GetHostileDuration(), base.unlockSeconds);
	}
}
