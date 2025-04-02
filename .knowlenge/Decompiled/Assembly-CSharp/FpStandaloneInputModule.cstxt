using UnityEngine.EventSystems;

public class FpStandaloneInputModule : StandaloneInputModule
{
	public PointerEventData CurrentData
	{
		get
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			if (!((PointerInputModule)this).m_PointerData.ContainsKey(-1))
			{
				return new PointerEventData(EventSystem.current);
			}
			return ((PointerInputModule)this).m_PointerData[-1];
		}
	}
}
