public class LaserDetector : BaseDetector
{
	public override void OnObjects()
	{
		foreach (BaseEntity entityContent in myTrigger.entityContents)
		{
			if (entityContent.IsVisible(base.transform.position + base.transform.forward * 0.1f, 12f))
			{
				base.OnObjects();
				break;
			}
		}
	}
}
