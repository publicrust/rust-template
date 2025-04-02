using UnityEngine;

public class Sandstorm : MonoBehaviour
{
	public ParticleSystem m_psSandStorm;

	public float m_flSpeed;

	public float m_flSwirl;

	public float m_flEmissionRate;

	private void Start()
	{
	}

	private void Update()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.RotateAround(((Component)this).transform.position, Vector3.up, Time.deltaTime * m_flSwirl);
		Vector3 eulerAngles = ((Component)this).transform.eulerAngles;
		eulerAngles.x = -7f + Mathf.Sin(Time.time * 2.5f) * 7f;
		((Component)this).transform.eulerAngles = eulerAngles;
		if ((Object)(object)m_psSandStorm != (Object)null)
		{
			m_psSandStorm.startSpeed = m_flSpeed;
			ParticleSystem psSandStorm = m_psSandStorm;
			psSandStorm.startSpeed += Mathf.Sin(Time.time * 0.4f) * (m_flSpeed * 0.75f);
			m_psSandStorm.emissionRate = m_flEmissionRate + Mathf.Sin(Time.time * 1f) * (m_flEmissionRate * 0.3f);
		}
	}
}
