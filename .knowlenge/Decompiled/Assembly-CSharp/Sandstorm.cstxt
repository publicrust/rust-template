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
		base.transform.RotateAround(base.transform.position, Vector3.up, Time.deltaTime * m_flSwirl);
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = -7f + Mathf.Sin(Time.time * 2.5f) * 7f;
		base.transform.eulerAngles = eulerAngles;
		if (m_psSandStorm != null)
		{
			m_psSandStorm.startSpeed = m_flSpeed;
			m_psSandStorm.startSpeed += Mathf.Sin(Time.time * 0.4f) * (m_flSpeed * 0.75f);
			m_psSandStorm.emissionRate = m_flEmissionRate + Mathf.Sin(Time.time * 1f) * (m_flEmissionRate * 0.3f);
		}
	}
}
