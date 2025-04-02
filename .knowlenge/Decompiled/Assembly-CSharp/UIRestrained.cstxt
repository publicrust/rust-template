using UnityEngine.UI;

public class UIRestrained : SingletonComponent<UIRestrained>
{
	public Image Fill;

	private void Start()
	{
		SetActive(state: false);
		SetProgress(0f);
	}

	public void SetActive(bool state)
	{
		base.gameObject.SetActive(state);
	}

	public void SetProgress(Item handcuffItem)
	{
		if (handcuffItem == null)
		{
			SetProgress(0f);
		}
		else
		{
			SetProgress(1f - handcuffItem.condition / handcuffItem.maxCondition);
		}
	}

	public void SetProgress(float progress)
	{
		Fill.fillAmount = progress;
	}
}
