using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class SocketMod_TerrainCheck : SocketMod
{
	public bool wantsInTerrain = true;

	public bool preventWorldLayerInMonuments;

	private static Translate.Phrase lastError = new Translate.Phrase();

	protected override Translate.Phrase ErrorPhrase => lastError;

	public static bool IsInTerrain(Vector3 vPoint, bool worldLayerInMonuments)
	{
		if (TerrainMeta.OutOfBounds(vPoint))
		{
			if (TerrainMeta.IsPointWithinTutorialBounds(vPoint))
			{
				return Physics.Raycast(new Ray(vPoint + Vector3.up * 3f, Vector3.down), 3f, 65536);
			}
			return false;
		}
		List<RaycastHit> obj = Pool.Get<List<RaycastHit>>();
		GamePhysics.TraceAllUnordered(new Ray(vPoint + Vector3.up * 3f, Vector3.down), 0f, obj, 3f, 65536);
		using (List<RaycastHit>.Enumerator enumerator = obj.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				RaycastHit current = enumerator.Current;
				if (worldLayerInMonuments)
				{
					Pool.FreeUnmanaged(ref obj);
					return true;
				}
				if (current.collider.gameObject.HasCustomTag(GameObjectTag.BlockBarricadePlacement))
				{
					lastError = ConstructionErrors.CantPlaceOnMonument;
					Pool.FreeUnmanaged(ref obj);
					return false;
				}
				if (current.collider.gameObject.HasCustomTag(GameObjectTag.AllowBarricadePlacement))
				{
					Pool.FreeUnmanaged(ref obj);
					return true;
				}
				MonumentInfo monument = ColliderEx.GetMonument(current.collider);
				Pool.FreeUnmanaged(ref obj);
				if (monument == null)
				{
					return true;
				}
				lastError = ConstructionErrors.CantPlaceOnMonument;
				return false;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		if (!TerrainMeta.Collision || !TerrainMeta.Collision.GetIgnore(vPoint))
		{
			Terrain[] activeTerrains = Terrain.activeTerrains;
			foreach (Terrain terrain in activeTerrains)
			{
				if (terrain.SampleHeight(vPoint) + terrain.transform.position.y > vPoint.y)
				{
					return true;
				}
			}
		}
		return false;
	}

	public override bool DoCheck(Construction.Placement place)
	{
		Vector3 vPoint = place.position + place.rotation * worldPosition;
		lastError = null;
		if (IsInTerrain(vPoint, !preventWorldLayerInMonuments) == wantsInTerrain)
		{
			return true;
		}
		if (lastError == null)
		{
			lastError = ConstructionErrors.NotInTerrain;
		}
		return false;
	}
}
