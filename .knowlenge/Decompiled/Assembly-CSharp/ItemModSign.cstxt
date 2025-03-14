public class ItemModSign : ItemModAssociatedEntity<SignContent>
{
	protected override bool AllowNullParenting => true;

	protected override bool ShouldAutoCreateEntity => false;

	public void OnSignPickedUp(ISignage s, IUGCBrowserEntity ugc, Item toItem)
	{
		SignContent signContent = CreateAssociatedEntity(toItem);
		if (signContent != null)
		{
			signContent.CopyInfoFromSign(s, ugc);
		}
	}
}
