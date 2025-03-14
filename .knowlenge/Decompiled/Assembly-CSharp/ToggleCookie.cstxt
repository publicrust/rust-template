using Rust;
using Rust.UI;
using UnityEngine;

public class ToggleCookie : MonoBehaviour
{
	public void OnEnable()
	{
		if (TryGetComponent<RustButton>(out var component))
		{
			bool result;
			bool v = (bool.TryParse(PlayerPrefs.GetString("ToggleCookie_" + base.name), out result) ? result : component.Value);
			component.Toggle(v, forced: true);
			component.OnPressed.AddListener(OnPressed);
			component.OnReleased.AddListener(OnReleased);
		}
	}

	public void OnDisable()
	{
		if (!Rust.Application.isQuitting && TryGetComponent<RustButton>(out var component))
		{
			component.OnPressed.RemoveListener(OnPressed);
			component.OnReleased.RemoveListener(OnReleased);
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
		PlayerPrefs.SetString("ToggleCookie_" + base.name, v.ToString());
	}
}
