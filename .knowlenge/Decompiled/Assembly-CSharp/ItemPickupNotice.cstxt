using TMPro;
using UnityEngine;

public class ItemPickupNotice : MonoBehaviour
{
	public GameObject objectDeleteOnFinish;

	public TextMeshProUGUI Text;

	public TextMeshProUGUI Amount;

	public ItemDefinition itemInfo
	{
		set
		{
			Text.text = value.displayName.translated;
		}
	}

	public int amount
	{
		set
		{
			Amount.text = ((value > 0) ? value.ToString("+0") : value.ToString("0"));
		}
	}

	public void Awake()
	{
		float num = 4f;
		(base.transform as RectTransform).sizeDelta = new Vector2(1f, 0f);
		GetComponent<CanvasGroup>().alpha = 0f;
		LeanTween.size(base.transform as RectTransform, new Vector2(200f, 26f), 0.2f).setEaseOutCubic();
		LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 1f, 0.1f);
		LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 0f, 4f).setDelay(num - 2f).setOnComplete(PopupNoticeEnd);
		LeanTween.size(base.transform as RectTransform, new Vector2(200f, 0f), 1f).setEaseInCubic().setDelay(num);
	}

	public void PopupNoticeEnd()
	{
		GameManager.Destroy(objectDeleteOnFinish);
	}
}
