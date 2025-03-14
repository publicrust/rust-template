using UnityEngine;

public class LeavesBlowing : MonoBehaviour
{
	public ParticleSystem m_psLeaves;

	public float m_flSwirl;

	public float m_flSpeed;

	public float m_flEmissionRate;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.RotateAround(base.transform.position, Vector3.up, Time.deltaTime * m_flSwirl);
		if (m_psLeaves != null)
		{
			m_psLeaves.startSpeed = m_flSpeed;
			m_psLeaves.startSpeed += Mathf.Sin(Time.time * 0.4f) * (m_flSpeed * 0.75f);
			m_psLeaves.emissionRate = m_flEmissionRate + Mathf.Sin(Time.time * 1f) * (m_flEmissionRate * 0.3f);
		}
	}
}
