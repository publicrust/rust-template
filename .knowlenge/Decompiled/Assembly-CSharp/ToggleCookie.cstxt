using Rust;
using Rust.UI;
using UnityEngine;
using UnityEngine.Events;

public class ToggleCookie : MonoBehaviour
{
	public void OnEnable()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		RustButton val = default(RustButton);
		if (((Component)this).TryGetComponent<RustButton>(ref val))
		{
			bool result;
			bool flag = (bool.TryParse(PlayerPrefs.GetString("ToggleCookie_" + ((Object)this).name), out result) ? result : val.Value);
			val.Toggle(flag, true);
			val.OnPressed.AddListener(new UnityAction(OnPressed));
			val.OnReleased.AddListener(new UnityAction(OnReleased));
		}
	}

	public void OnDisable()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		RustButton val = default(RustButton);
		if (!Application.isQuitting && ((Component)this).TryGetComponent<RustButton>(ref val))
		{
			val.OnPressed.RemoveListener(new UnityAction(OnPressed));
			val.OnReleased.RemoveListener(new UnityAction(OnReleased));
		}
	}

	private void OnPressed()
	{
		OnChanged(v: true);
	}

	private void OnReleased()
	{
		OnChanged(v: false);
	}

	private void OnChanged(bool v)
	{
		PlayerPrefs.SetString("ToggleCookie_" + ((Object)this).name, v.ToString());
	}
}
