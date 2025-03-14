using UnityEngine;

public class NightEyeComponent : FacepunchBehaviour, IClientComponent
{
	[SerializeField]
	private Renderer[] nightEyes;

	private bool wasDayLastCheck;

	private void OnEnable()
	{
		wasDayLastCheck = TOD_Sky.Instance.IsDay;
		Renderer[] array = nightEyes;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(TOD_Sky.Instance.IsNight);
		}
		InvokeRandomized(Tick, 5f, 5f, 2.5f);
	}

	private void OnDisable()
	{
		CancelInvoke(Tick);
	}

	private void Tick()
	{
		using (TimeWarning.New("NightEyeComponent:Tick"))
		{
			if (wasDayLastCheck && TOD_Sky.Instance.IsNight)
			{
				Renderer[] array = nightEyes;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].gameObject.SetActive(value: true);
				}
			}
			else if (!wasDayLastCheck && TOD_Sky.Instance.IsDay)
			{
				Renderer[] array = nightEyes;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].gameObject.SetActive(value: false);
				}
			}
			wasDayLastCheck = TOD_Sky.Instance.IsDay;
		}
	}
}
