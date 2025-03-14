using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class VitalInfo : MonoBehaviour, IClientComponent, IVitalNotice
{
	public enum Vital
	{
		BuildingBlocked,
		CanBuild,
		Crafting,
		CraftLevel1,
		CraftLevel2,
		CraftLevel3,
		DecayProtected,
		Decaying,
		SafeZone,
		Buffed,
		Pet,
		ModifyClan
	}

	public HudElement Element;

	public Image InfoImage;

	public Vital VitalType;

	public RustText text;

	public static readonly Translate.Phrase BoostActive = new Translate.Phrase("tea.boostactive", "{0} Boost active");

	public static readonly Translate.Phrase BoostsActive = new Translate.Phrase("tea.boostactive.plural", "{0} Boosts active");
}
