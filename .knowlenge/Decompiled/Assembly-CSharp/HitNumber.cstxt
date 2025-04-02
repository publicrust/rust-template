using UnityEngine;

public class HitNumber : MonoBehaviour
{
	public enum HitType
	{
		Yellow,
		Green,
		Blue,
		Purple,
		Red
	}

	public HitType hitType;

	public int ColorToMultiplier(HitType type)
	{
		return type switch
		{
			HitType.Yellow => 1, 
			HitType.Green => 3, 
			HitType.Blue => 5, 
			HitType.Purple => 10, 
			HitType.Red => 20, 
			_ => 0, 
		};
	}

	public void OnDrawGizmosSelected()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.color = Color.white;
		Gizmos.DrawSphere(((Component)this).transform.position, 0.025f);
	}
}
