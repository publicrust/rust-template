using UnityEngine;

public class StaticRespawnArea : SleepingBag
{
	public Transform[] spawnAreas;

	public bool allowHostileSpawns;

	public override bool ValidForPlayer(ulong playerID, bool ignoreTimers)
	{
		BasePlayer basePlayer = BasePlayer.FindByID(playerID);
		if (basePlayer != null && basePlayer.IsInTutorial)
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
		Transform transform = spawnAreas[Random.Range(0, spawnAreas.Length)];
		pos = transform.transform.position + spawnOffset;
		rot = Quaternion.Euler(0f, transform.transform.rotation.eulerAngles.y, 0f);
	}

	public override void SetUnlockTime(float newTime)
	{
		unlockTime = 0f;
	}

	public override float GetUnlockSeconds(ulong playerID)
	{
		BasePlayer basePlayer = BasePlayer.FindByID(playerID);
		if (basePlayer == null || allowHostileSpawns)
		{
			return base.unlockSeconds;
		}
		return Mathf.Max(basePlayer.GetHostileDuration(), base.unlockSeconds);
	}
}
