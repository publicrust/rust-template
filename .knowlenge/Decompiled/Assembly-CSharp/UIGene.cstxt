using UnityEngine;
using UnityEngine.UI;

public class UIGene : MonoBehaviour
{
	public GameObject Child;

	public Color PositiveColour;

	public Color NegativeColour;

	public Color PositiveTextColour;

	public Color NegativeTextColour;

	public Image ImageBG;

	public Text TextGene;

	public void Init(GrowableGene gene)
	{
		bool flag = gene.IsPositive();
		ImageBG.color = (flag ? PositiveColour : NegativeColour);
		TextGene.color = (flag ? PositiveTextColour : NegativeTextColour);
		TextGene.text = gene.GetDisplayCharacter();
		Show();
	}

	public void InitPrevious(GrowableGene gene)
	{
		ImageBG.color = Color.black;
		TextGene.color = Color.grey;
		TextGene.text = GrowableGene.GetDisplayCharacter(gene.PreviousType);
		Show();
	}

	public void Hide()
	{
		Child.gameObject.SetActive(value: false);
	}

	public void Show()
	{
		Child.gameObject.SetActive(value: true);
	}
}
