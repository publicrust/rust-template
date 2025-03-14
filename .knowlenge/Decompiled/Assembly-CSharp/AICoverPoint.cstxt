using UnityEngine;

public class AICoverPoint : BaseMonoBehaviour
{
	public float coverDot = 0.5f;

	private BaseEntity currentUser;

	public bool InUse()
	{
		return currentUser != null;
	}

	public bool IsUsedBy(BaseEntity user)
	{
		if (!InUse())
		{
			return false;
		}
		if (user == null)
		{
			return false;
		}
		return user == currentUser;
	}

	public void SetUsedBy(BaseEntity user, float duration = 5f)
	{
		currentUser = user;
		Invoke(ClearUsed, duration);
	}

	public void ClearUsed()
	{
		currentUser = null;
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Vector3 vector = base.transform.position + Vector3.up * 1f;
		Gizmos.DrawCube(base.transform.position + Vector3.up * 0.125f, new Vector3(0.5f, 0.25f, 0.5f));
		Gizmos.DrawLine(base.transform.position, vector);
		Vector3 normalized = (base.transform.forward + base.transform.right * coverDot * 1f).normalized;
		Vector3 normalized2 = (base.transform.forward + -base.transform.right * coverDot * 1f).normalized;
		Gizmos.DrawLine(vector, vector + normalized * 1f);
		Gizmos.DrawLine(vector, vector + normalized2 * 1f);
	}
}
