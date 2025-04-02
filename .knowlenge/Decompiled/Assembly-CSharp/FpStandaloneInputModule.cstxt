using UnityEngine.EventSystems;

public class FpStandaloneInputModule : StandaloneInputModule
{
	public PointerEventData CurrentData
	{
		get
		{
			if (!m_PointerData.ContainsKey(-1))
			{
				return new PointerEventData(EventSystem.current);
			}
			return m_PointerData[-1];
		}
	}
}
