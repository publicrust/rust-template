using UnityEngine;

public class NoticeArea : SingletonComponent<NoticeArea>
{
	public GameObjectRef itemPickupPrefab;

	public GameObjectRef itemPickupCondensedText;

	public GameObjectRef itemDroppedPrefab;

	public AnimationCurve pickupSizeCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public AnimationCurve pickupAlphaCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public AnimationCurve reuseAlphaCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public AnimationCurve reuseSizeCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	private IVitalNotice[] notices;

	protected override void Awake()
	{
		base.Awake();
		notices = GetComponentsInChildren<IVitalNotice>(includeInactive: true);
	}
}
